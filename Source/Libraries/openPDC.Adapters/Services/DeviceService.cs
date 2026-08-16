using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using GSF.PhasorProtocols;
using GSF.Security.Model;
using openPDC.Adapters.Constants;
using openPDC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace openPDC.Adapters.Services
{
    /// <summary>
    /// Provides device (PMU) persistence operations backing <see cref="DeviceController"/>,
    /// covering .PmuConnection-file based upserts and batch upserts.
    /// </summary>
    public partial class DeviceService : IDeviceService
    {
        #region [ Members ]

        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(DeviceService), MessageClass.Application);

        #endregion [ Members ]

        #region [ Properties ]

        /// <summary>
        /// Gets the DataContext for database operations.
        /// </summary>
        private static AdoDataConnection DataContext
        {
            get
            {
                return new AdoDataConnection(StringConstant.SystemSettings);
            }
        }

        #endregion [ Properties ]

        #region [ Methods ]

        /// <inheritdoc/>
        public async Task<int> ProcessConfigurationFrameAsync(ConnectionSettings settings, IConfigurationFrame configFrame, DeviceMetadata validRequest, string userName)
        {
            using AdoDataConnection context = DataContext;

            int? protocolID = CommonController.GetProtocolID(settings.PhasorProtocol, context);
            bool isConcentrator = configFrame.Cells.Count > 1;
            string deviceConnectionString = $"TransportProtocol={settings.TransportProtocol};{settings.ConnectionString}";

            var deviceMetadata = CommonController.ResolveDeviceMetadata(validRequest, context);

            var parentDevice = BuildParentDevice(validRequest, isConcentrator, protocolID, settings, configFrame, deviceConnectionString, deviceMetadata);

            var parentDeviceID = UpsertDeviceRecord(parentDevice, userName);

            int savedDeviceCount = 1;

            ProcessAllCells(configFrame, settings, parentDeviceID, protocolID, isConcentrator, validRequest, deviceMetadata, userName, ref savedDeviceCount);

            Log.Publish(MessageLevel.Info, nameof(ProcessConfigurationFrameAsync),
                $"Saved {savedDeviceCount} device(s) for acronym '{validRequest.Acronym}'");

            return await Task.FromResult(savedDeviceCount);
        }

        /// <inheritdoc/>
        public UpsertDeviceResponse UpsertDevices(IReadOnlyList<Device> devices, string userName)
        {
            Log.Publish(MessageLevel.Info, nameof(UpsertDevices), $"Upserting {devices.Count} device record(s)");

            using AdoDataConnection context = DataContext;

            TableOperations<Node> nodeTable = new(context);
            RecordRestriction nodeRestriction = new("Master = {0} AND Enabled = {1}", true, true);

            var defaultNode = nodeTable.QueryRecords(nodeRestriction)
                                       .OrderBy(n => n.CreatedOn)
                                       .FirstOrDefault();

            TableOperations<Device> deviceTable = new(context);

            // Load all existing devices once instead of one query per item, so batches of hundreds
            // of PMUs remain fast and duplicates within the batch itself (repeated
            // acronyms) resolve as inserts followed by updates rather than duplicate inserts.
            var devicesByAcronym = deviceTable.QueryRecords(StringConstant.Acronym)
                .Where(d => d.Acronym != null)
                .GroupBy(d => d.Acronym, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

            var upsertDeviceResponse = new UpsertDeviceResponse
            {
                NumberOfReceivedRecords = devices.Count,
                NumberOfRecordsProcessedWithSuccess = 0,
                NumberOfRecordsWithFail = 0,
                Details = []
            };

            var nowTime = DateTime.Now;
            var nowTimeFormatted = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, nowTime.Second, nowTime.Millisecond, DateTimeKind.Local);

            foreach (var device in devices)
            {
                var upsertDeviceResponseDetail = new UpsertDeviceResponseDetail
                {
                    DeviceAcronym = device?.Acronym
                };

                try
                {
                    if (device == null || string.IsNullOrWhiteSpace(device.Acronym))
                        throw new InvalidOperationException("Device Acronym is required.");

                    bool deviceExists = devicesByAcronym.TryGetValue(device.Acronym, out var deviceInDatabase);

                    device.NodeID = defaultNode.ID;
                    device.UniqueID = Guid.NewGuid();
                    device.CreatedBy = userName;
                    device.UpdatedBy = userName;
                    device.CreatedOn = nowTimeFormatted;
                    device.UpdatedOn = nowTimeFormatted;

                    if (!deviceExists)
                    {
                        var rowsAddedAffected = deviceTable.AddNewRecord(device);

                        if (rowsAddedAffected <= 0)
                            throw new InvalidOperationException("Failed to add device, problem in database connection.");

                        // Track the newly inserted device so a repeated acronym later in the same
                        // batch is treated as an update instead of a duplicate insert.
                        devicesByAcronym[device.Acronym] = device;

                        upsertDeviceResponseDetail.Status = UpsertDeviceStatus.Included.ToString();

                        Log.Publish(MessageLevel.Info, nameof(UpsertDevices), "Device added successfully", details: device.Acronym);
                    }
                    else
                    {
                        var restriction = new RecordRestriction("Acronym = {0}", deviceInDatabase.Acronym);
                        var rowsUpdatedAffected = deviceTable.UpdateRecord(device, restriction);

                        if (rowsUpdatedAffected <= 0)
                            throw new InvalidOperationException("Failed to update device, problem in database connection.");

                        devicesByAcronym[device.Acronym] = device;

                        upsertDeviceResponseDetail.Status = UpsertDeviceStatus.Updated.ToString();

                        Log.Publish(MessageLevel.Info, nameof(UpsertDevices), "Device updated successfully", details: deviceInDatabase.Acronym);
                    }

                    upsertDeviceResponse.NumberOfRecordsProcessedWithSuccess++;
                }
                catch (Exception ex)
                {
                    upsertDeviceResponse.NumberOfRecordsWithFail++;

                    upsertDeviceResponseDetail.Status = UpsertDeviceStatus.Failed.ToString();
                    upsertDeviceResponseDetail.Message = $"Failed to upsert device, exception: {ex.Message}";

                    Log.Publish(MessageLevel.Error, nameof(UpsertDevices),
                        $"Failed to upsert device '{upsertDeviceResponseDetail.DeviceAcronym}', exception occurred.", exception: ex);
                }

                upsertDeviceResponse.Details.Add(upsertDeviceResponseDetail);
            }

            return upsertDeviceResponse;
        }

        /// <inheritdoc/>
        public async Task<DeviceMetadata> ValidateRequestAsync(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
                throw new InvalidOperationException("Expected multipart/form-data content with a .PmuConnection file");

            var provider = new MultipartMemoryStreamProvider();
            await request.Content.ReadAsMultipartAsync(provider);

            string acronym = null;
            string name = null;
            byte[] fileBytes = null;
            string companyAcronym = null;
            string historianAcronym = null;
            string vendorDeviceName = null;
            string interconnectionName = null;

            foreach (var content in provider.Contents)
            {
                string fieldName = content.Headers.ContentDisposition?.Name?.Trim('"');
                bool isFile = content.Headers.ContentDisposition?.FileName != null;

                if (isFile)
                    fileBytes = await content.ReadAsByteArrayAsync();
                else if (string.Equals(fieldName, "acronym", StringComparison.OrdinalIgnoreCase))
                    acronym = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "name", StringComparison.OrdinalIgnoreCase))
                    name = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "companyAcronym", StringComparison.OrdinalIgnoreCase))
                    companyAcronym = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "historianAcronym", StringComparison.OrdinalIgnoreCase))
                    historianAcronym = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "vendorDeviceName", StringComparison.OrdinalIgnoreCase))
                    vendorDeviceName = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "interconnectionName", StringComparison.OrdinalIgnoreCase))
                    interconnectionName = await content.ReadAsStringAsync();
            }

            if (fileBytes == null || fileBytes.Length == 0)
                throw new InvalidOperationException("A .PmuConnection file is required");

            if (string.IsNullOrWhiteSpace(acronym))
                throw new InvalidOperationException("The 'acronym' form field is required");

            name = string.IsNullOrWhiteSpace(name) ? acronym : name;

            var deviceByPmuConnectionFile = new DeviceMetadata
            {
                Acronym = acronym,
                Name = name,
                FileBytes = fileBytes,
                CompanyAcronym = companyAcronym,
                HistorianAcronym = historianAcronym,
                VendorDeviceName = vendorDeviceName,
                InterconnectionName = interconnectionName
            };

            return deviceByPmuConnectionFile;
        }

        /// <summary>
        /// Inserts a new device record or updates the existing one (matched by Acronym). Returns
        /// the ID of the saved device.
        /// </summary>
        private static int UpsertDeviceRecord(Device device, string userName)
        {
            Log.Publish(MessageLevel.Info, nameof(UpsertDeviceRecord), $"Upserting device record");

            using AdoDataConnection context = DataContext;

            TableOperations<Node> nodeTable = new(context);

            RecordRestriction nodeRestriction = new("Master = {0} AND Enabled = {1}", true, true);

            var defaultNode = nodeTable.QueryRecords(nodeRestriction)
                                       .OrderBy(n => n.CreatedOn)
                                       .FirstOrDefault();

            TableOperations<Device> deviceTable = new(context);
            var deviceInDatabase = deviceTable.QueryRecordWhere("Acronym = {0}", device.Acronym);

            var nowTime = DateTime.Now;
            var nowTimeFormatted = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, nowTime.Second, nowTime.Millisecond, DateTimeKind.Local);

            device.NodeID = defaultNode.ID;
            device.UniqueID = Guid.NewGuid();
            device.CreatedBy = userName;
            device.UpdatedBy = userName;
            device.CreatedOn = nowTimeFormatted;
            device.UpdatedOn = nowTimeFormatted;

            if (deviceInDatabase == null)
            {
                deviceTable.AddNewRecord(device);
                Log.Publish(MessageLevel.Info, nameof(UpsertDeviceRecord), $"Device added successfully");
                deviceInDatabase = deviceTable.QueryRecordWhere("Acronym = {0}", device.Acronym);
            }
            else
            {
                var restriction = new RecordRestriction("Acronym = {0}", deviceInDatabase.Acronym);
                deviceTable.UpdateRecord(device, restriction);
                Log.Publish(MessageLevel.Info, nameof(UpsertDeviceRecord), $"Device updated successfully");
            }

            return deviceInDatabase.ID;
        }

        /// <summary>
        /// Builds a Device object for the parent/main device (either concentrator or standalone PMU).
        /// </summary>
        private Device BuildParentDevice(DeviceMetadata validRequest,
                                         bool isConcentrator,
                                         int? protocolID,
                                         ConnectionSettings settings,
                                         IConfigurationFrame configFrame,
                                         string deviceConnectionString,
                                         DeviceMetadata deviceMetadata)
        {
            return new Device
            {
                Acronym = validRequest.Acronym,
                Name = validRequest.Name,
                IsConcentrator = isConcentrator,
                ProtocolID = protocolID,
                CompanyID = deviceMetadata.CompanyID,
                HistorianID = deviceMetadata.HistorianID,
                VendorDeviceID = deviceMetadata.VendorDeviceID,
                InterconnectionID = deviceMetadata.InterconnectionID,
                AccessID = isConcentrator
                    ? (int)configFrame.IDCode
                    : (int)configFrame.Cells.Cast<IConfigurationCell>().First().IDCode,
                FramesPerSecond = settings.FrameRate > 0 ? settings.FrameRate : 30,
                ConnectionString = deviceConnectionString,
                Enabled = true,
                AllowUseOfCachedConfiguration = true,
                AutoStartDataParsingSequence = true,
                ConnectOnDemand = true,
                DataLossInterval = 5.0,
                AllowedParsingExceptions = 10,
                ParsingExceptionWindow = 5.0,
                DelayedConnectionInterval = 5.0,
                MeasurementReportingInterval = 100000,
            };
        }

        /// <summary>
        /// Processes all cells from the configuration frame, creating child devices (if
        /// concentrator) and saving their phasor definitions and measurements.
        /// </summary>
        private void ProcessAllCells(IConfigurationFrame configFrame,
                                     ConnectionSettings settings,
                                     int parentDeviceID,
                                     int? protocolID,
                                     bool isConcentrator,
                                     DeviceMetadata validRequest,
                                     DeviceMetadata deviceMetadata,
                                     string userName,
                                     ref int savedDeviceCount)
        {
            using AdoDataConnection context = DataContext;
            TableOperations<Phasor> phasorTable = new(context);
            TableOperations<Measurement> measurementTable = new(context);

            foreach (IConfigurationCell cell in configFrame.Cells)
            {
                int targetDeviceID;
                string targetAcronym;
                string targetName;

                if (isConcentrator)
                {
                    targetDeviceID = ProcessAndSaveChildDevice(cell, settings, parentDeviceID, protocolID, deviceMetadata, userName);
                    targetAcronym = CommonController.SanitizeAcronym(cell.StationName);
                    targetName = cell.StationName;
                    savedDeviceCount++;
                }
                else
                {
                    targetDeviceID = parentDeviceID;
                    targetAcronym = validRequest.Acronym;
                    targetName = validRequest.Name;
                }

                SavePhaseorsForCell(cell, targetDeviceID, phasorTable, userName);
                SaveMeasurementsForCell(cell, targetDeviceID, targetAcronym, targetName, deviceMetadata.HistorianID, measurementTable, context, userName);
            }
        }

        /// <summary>
        /// Processes a cell from a concentrator, creating a child device record for it. Returns the
        /// ID of the created or updated child device.
        /// </summary>
        private int ProcessAndSaveChildDevice(IConfigurationCell cell,
                                              ConnectionSettings settings,
                                              int parentDeviceID,
                                              int? protocolID,
                                              DeviceMetadata deviceMetadata,
                                              string userName)
        {
            string cellAcronym = CommonController.SanitizeAcronym(cell.StationName);

            var concentrator = new Device
            {
                Acronym = cellAcronym,
                Name = cell.StationName,
                IsConcentrator = false,
                ProtocolID = protocolID,
                CompanyID = deviceMetadata.CompanyID,
                HistorianID = deviceMetadata.HistorianID,
                VendorDeviceID = deviceMetadata.VendorDeviceID,
                InterconnectionID = deviceMetadata.InterconnectionID,
                AccessID = (int)cell.IDCode,
                ParentID = parentDeviceID,
                FramesPerSecond = settings.FrameRate > 0 ? settings.FrameRate : 30,
                ConnectionString = string.Empty,
                Enabled = true,
                AllowUseOfCachedConfiguration = true,
                AutoStartDataParsingSequence = true,
                ConnectOnDemand = false,
                DataLossInterval = 5.0,
                AllowedParsingExceptions = 10,
                ParsingExceptionWindow = 5.0,
                DelayedConnectionInterval = 5.0,
                MeasurementReportingInterval = 100000
            };

            return UpsertDeviceRecord(concentrator, userName);
        }

        /// <summary>
        /// Creates or updates all measurements for a configuration cell: PMU-level signals
        /// (frequency, dF/dt, status flags), phasor magnitude/angle pairs, analog values, and
        /// digital values. Matches openPDCManager's SaveDevice/SavePhasor measurement pattern.
        /// PointTag format mirrors the Device Wizard: PMU signals :
        /// {company}_{device}:{vendor}{abbreviation} e.g. GPA_SHELBY:SHELPMUF Phasors :
        /// {company}_{device}-{suffix}{idx}:{vendor}{abbreviation} e.g. GPA_SHELBY-PM1:SHELPMУВ
        /// Analog : {company}_{device}:{vendor}A{idx} Digital : {company}_{device}:{vendor}D{idx}
        /// </summary>
        private void SaveMeasurementsForCell(IConfigurationCell cell,
                                             int deviceID,
                                             string deviceAcronym,
                                             string deviceName,
                                             int? historianID,
                                             TableOperations<Measurement> measurementTable,
                                             AdoDataConnection context,
                                             string userName)
        {
            TableOperations<DeviceDetail> DeviceTable = new(context);
            var Device = DeviceTable.QueryRecordWhere("Acronym = {0}", deviceAcronym);
            string companyAcronym = Device?.CompanyAcronym ?? string.Empty;

            var nowTime = DateTime.Now;
            var now = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, nowTime.Second, nowTime.Millisecond, DateTimeKind.Local);

            // Pre-load SignalType records. PMU types (FQ/DF/SF) carry their Acronym used verbatim
            // in the tag. Phasor types are keyed by Suffix (PM/PA) in separate voltage/current
            // maps; only the first char of Abbreviation is used in the phasor tag.
            TableOperations<GSF.TimeSeries.Model.SignalType> sigTypeTable = new(context);

            var pmuTypes = new Dictionary<string, (int ID, string Acronym)>();
            foreach (string pmuSuffix in new[] { "FQ", "DF", "SF" })
            {
                var st = sigTypeTable.QueryRecordWhere("Suffix = {0} AND Source = 'PMU'", pmuSuffix);
                if (st?.ID > 0)
                    pmuTypes[pmuSuffix] = (st.ID, st.Acronym ?? pmuSuffix);
            }

            // Voltage phasors: VPHM (PM, Abbreviation='V') and VPHA (PA, Abbreviation='VH')
            var voltagePhasorTypes = new Dictionary<string, (int ID, string Abbreviation)>();
            foreach (string acronym in new[] { "VPHM", "VPHA" })
            {
                var st = sigTypeTable.QueryRecordWhere("Acronym = {0}", acronym);
                if (st?.ID > 0)
                    voltagePhasorTypes[st.Suffix] = (st.ID, st.Abbreviation ?? string.Empty);
            }

            // Current phasors: IPHM (PM, Abbreviation='I') and IPHA (PA, Abbreviation='IH')
            var currentPhasorTypes = new Dictionary<string, (int ID, string Abbreviation)>();
            foreach (string acronym in new[] { "IPHM", "IPHA" })
            {
                var st = sigTypeTable.QueryRecordWhere("Acronym = {0}", acronym);
                if (st?.ID > 0)
                    currentPhasorTypes[st.Suffix] = (st.ID, st.Abbreviation ?? string.Empty);
            }

            var alogST = sigTypeTable.QueryRecordWhere("Acronym = {0}", "ALOG");
            var digiST = sigTypeTable.QueryRecordWhere("Acronym = {0}", "DIGI");

            // Phasors are saved by SavePhaseorsForCell before this call; read their Phase values so
            // the PointTag reflects the correct phase. Default is '+' (positive sequence).
            TableOperations<Phasor> phasorTable = new(context);
            var savedPhasors = phasorTable
                .QueryRecords(restriction: new RecordRestriction("DeviceID = {0}", deviceID))
                .ToDictionary(p => p.SourceIndex, p => p.Phase ?? "+");

            // PMU-level signals — PointTag: {company}_{device}:{SignalType.Acronym} Matches
            // expression: [?Source!=Phasor[?Acronym!=ALOG[:{SignalType.Acronym}]]]
            foreach (string suffix in new[] { "FQ", "DF", "SF" })
            {
                if (!pmuTypes.TryGetValue(suffix, out var pmuType))
                    continue;

                CommonController.UpsertMeasurement(measurementTable, new Measurement
                {
                    DeviceID = deviceID,
                    HistorianID = historianID,
                    PointTag = $"{companyAcronym}_{deviceAcronym}:{pmuType.Acronym}",
                    SignalTypeID = pmuType.ID,
                    SignalReference = $"{deviceAcronym}-{suffix}",
                    Description = $"{deviceName} {CommonController.PmuSignalDescription(suffix)}",
                    Internal = true,
                    Enabled = true,
                    Adder = 0.0d,
                    Multiplier = 1.0d,
                    CreatedBy = userName,
                    UpdatedBy = userName,
                    CreatedOn = now,
                    UpdatedOn = now
                });
            }

            // Phasor measurements: magnitude (PM) and angle (PA) for each defined phasor.
            // PointTag: {company}_{device}:{cleanLabel}_{Abbr[0]}{phaseStr}[.MAG|.ANG]
            // Replicates: eval{Label.Trim().ToUpper().Replace(' ','_')}_eval{Abbr.Substring(0,1)} eval{Phase=='+'?'1':(Phase=='-'?'2':Phase)}[.MAG|.ANG]
            int phasorIndex = 1;
            foreach (IPhasorDefinition phasorDef in cell.PhasorDefinitions)
            {
                string label = phasorDef.Label?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(label) || label.Equals("unused", StringComparison.OrdinalIgnoreCase))
                {
                    phasorIndex++;
                    continue;
                }

                bool isVoltage = phasorDef.PhasorType == GSF.Units.EE.PhasorType.Voltage;
                var phasorTypes = isVoltage ? voltagePhasorTypes : currentPhasorTypes;

                string phase = savedPhasors.TryGetValue(phasorIndex, out string savedPhase) ? savedPhase : "+";
                string phaseStr = phase == "+" ? "1" : (phase == "-" ? "2" : phase);
                string cleanLabel = label.ToUpper().Replace(' ', '_');

                foreach (string sfx in new[] { "PM", "PA" })
                {
                    if (!phasorTypes.TryGetValue(sfx, out var phasorType))
                        continue;

                    string abbrFirst = phasorType.Abbreviation.Length > 0
                        ? phasorType.Abbreviation.Substring(0, 1)
                        : string.Empty;
                    string tagSuffix = sfx == "PM" ? ".MAG" : ".ANG";
                    string measurementLabel = sfx == "PM"
                        ? (isVoltage ? "Voltage Magnitude" : "Current Magnitude")
                        : (isVoltage ? "Voltage Angle" : "Current Angle");

                    CommonController.UpsertMeasurement(measurementTable, new Measurement
                    {
                        DeviceID = deviceID,
                        HistorianID = historianID,
                        PointTag = $"{companyAcronym}_{deviceAcronym}:{cleanLabel}_{abbrFirst}{phaseStr}{tagSuffix}",
                        SignalTypeID = phasorType.ID,
                        PhasorSourceIndex = phasorIndex,
                        SignalReference = $"{deviceAcronym}-{sfx}{phasorIndex}",
                        Description = $"{deviceName} {label} {measurementLabel}",
                        Internal = true,
                        Enabled = true,
                        Adder = 0.0d,
                        Multiplier = 1.0d,
                        CreatedBy = userName,
                        UpdatedBy = userName,
                        CreatedOn = now,
                        UpdatedOn = now
                    });
                }

                phasorIndex++;
            }

            // Analog values — PointTag: {company}_{device}:{cleanLabel} or :ALOG{idx:D2}
            // Replicates: [?Acronym=ALOG[:eval{Label.Length>0?Label.Trim().ToUpper():ALOG+idx:D2}]]
            if (alogST?.ID > 0)
            {
                int analogIndex = 1;
                foreach (IAnalogDefinition analogDef in cell.AnalogDefinitions)
                {
                    string analogLabel = analogDef.Label?.Trim() ?? string.Empty;
                    string analogTag = !string.IsNullOrEmpty(analogLabel)
                        ? analogLabel.ToUpper().Replace(' ', '_')
                        : $"ALOG{analogIndex:D2}";

                    CommonController.UpsertMeasurement(measurementTable, new Measurement
                    {
                        DeviceID = deviceID,
                        HistorianID = historianID,
                        PointTag = $"{companyAcronym}_{deviceAcronym}:{analogTag}",
                        SignalTypeID = alogST.ID,
                        SignalReference = $"{deviceAcronym}-AV{analogIndex}",
                        Description = $"{deviceName} Analog Value {analogIndex}",
                        Internal = true,
                        Enabled = true,
                        Adder = 0.0d,
                        Multiplier = 1.0d,
                        CreatedBy = userName,
                        UpdatedBy = userName,
                        CreatedOn = now,
                        UpdatedOn = now
                    });
                    analogIndex++;
                }
            }

            // Digital values — PointTag: {company}_{device}:DIGI{idx:D2}
            if (digiST?.ID > 0)
            {
                int digitalIndex = 1;
                foreach (IDigitalDefinition _ in cell.DigitalDefinitions)
                {
                    CommonController.UpsertMeasurement(measurementTable, new Measurement
                    {
                        DeviceID = deviceID,
                        HistorianID = historianID,
                        PointTag = $"{companyAcronym}_{deviceAcronym}:DIGI{digitalIndex:D2}",
                        SignalTypeID = digiST.ID,
                        SignalReference = $"{deviceAcronym}-DV{digitalIndex}",
                        Description = $"{deviceName} Digital Value {digitalIndex}",
                        Internal = true,
                        Enabled = true,
                        Adder = 0.0d,
                        Multiplier = 1.0d,
                        CreatedBy = userName,
                        UpdatedBy = userName,
                        CreatedOn = now,
                        UpdatedOn = now
                    });
                    digitalIndex++;
                }
            }

            Log.Publish(MessageLevel.Info, nameof(SaveMeasurementsForCell),
                $"Measurements saved for device '{deviceAcronym}'");
        }

        /// <summary>
        /// Saves all phasor definitions from a configuration cell to the database, inserting new
        /// phasors or updating existing ones matched by DeviceID and SourceIndex. Skips phasors
        /// with empty or "unused" labels.
        /// </summary>
        private void SavePhaseorsForCell(IConfigurationCell cell, int targetDeviceID, TableOperations<Phasor> phasorTable, string userName)
        {
            int sourceIndex = 1;

            foreach (IPhasorDefinition phasorDef in cell.PhasorDefinitions)
            {
                string label = phasorDef.Label?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(label) ||
                    label.Equals("unused", StringComparison.OrdinalIgnoreCase))
                {
                    sourceIndex++;
                    continue;
                }

                var existingPhasor = phasorTable.QueryRecordWhere(
                    "DeviceID = {0} AND SourceIndex = {1}", targetDeviceID, sourceIndex);

                var phasor = new Phasor
                {
                    DeviceID = targetDeviceID,
                    Label = label,
                    Type = phasorDef.PhasorType == GSF.Units.EE.PhasorType.Current ? "I" : "V",
                    Phase = "+",
                    SourceIndex = sourceIndex
                };

                var nowTime = DateTime.Now;
                var nowTimeFormatted = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, nowTime.Second, nowTime.Millisecond, DateTimeKind.Local);

                phasor.CreatedBy = userName;
                phasor.UpdatedBy = userName;
                phasor.CreatedOn = nowTimeFormatted;
                phasor.UpdatedOn = nowTimeFormatted;

                if (existingPhasor == null)
                    phasorTable.AddNewRecord(phasor);
                else
                    phasorTable.UpdateRecord(phasor, new RecordRestriction(
                        "DeviceID = {0} AND SourceIndex = {1}", targetDeviceID, sourceIndex));

                sourceIndex++;
            }
        }

        #endregion [ Methods ]
    }
}