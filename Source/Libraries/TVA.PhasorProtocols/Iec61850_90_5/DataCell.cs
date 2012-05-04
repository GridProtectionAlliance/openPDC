//******************************************************************************************************
//  DataCell.cs - Gbtc
//
//  Copyright © 2012, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  04/19/2012 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using TVA.IO;

namespace TVA.PhasorProtocols.Iec61850_90_5
{
    /// <summary>
    /// Represents the IEC 61850-90-5 implementation of a <see cref="IDataCell"/> that can be sent or received.
    /// </summary>
    [Serializable()]
    public class DataCell : DataCellBase
    {
        #region [ Members ]

        // Fields
        private string m_msvID;
        private string m_dataSet;
        private ushort m_sampleCount;
        private uint m_configurationRevision;
        private byte m_sampleSynchronization;
        private ushort m_sampleRate;
        private ushort m_idCode;
        private string m_stationName;
        private ConfigurationFrame m_configuration;
        private int m_parsedBodyLength;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="DataCell"/>.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="IDataFrame"/> of this <see cref="DataCell"/>.</param>
        /// <param name="configurationCell">The <see cref="IConfigurationCell"/> associated with this <see cref="DataCell"/>.</param>
        public DataCell(IDataFrame parent, IConfigurationCell configurationCell)
            : base(parent, configurationCell, 0x0000, Common.MaximumPhasorValues, Common.MaximumAnalogValues, Common.MaximumDigitalValues)
        {
            // Define new parsing state which defines constructors for key data values
            State = new DataCellParsingState(
                configurationCell,
                Iec61850_90_5.PhasorValue.CreateNewValue,
                Iec61850_90_5.FrequencyValue.CreateNewValue,
                Iec61850_90_5.AnalogValue.CreateNewValue,
                Iec61850_90_5.DigitalValue.CreateNewValue);
        }

        /// <summary>
        /// Creates a new <see cref="DataCell"/> from specified parameters.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="DataFrame"/> of this <see cref="DataCell"/>.</param>
        /// <param name="configurationCell">The <see cref="ConfigurationCell"/> associated with this <see cref="DataCell"/>.</param>
        /// <param name="addEmptyValues">If <c>true</c>, adds empty values for each defined configuration cell definition.</param>
        public DataCell(DataFrame parent, ConfigurationCell configurationCell, bool addEmptyValues)
            : this(parent, configurationCell)
        {
            if (addEmptyValues)
            {
                int x;

                // Define needed phasor values
                for (x = 0; x < configurationCell.PhasorDefinitions.Count; x++)
                {
                    PhasorValues.Add(new PhasorValue(this, configurationCell.PhasorDefinitions[x]));
                }

                // Define a frequency and df/dt
                FrequencyValue = new FrequencyValue(this, configurationCell.FrequencyDefinition);

                // Define any analog values
                for (x = 0; x < configurationCell.AnalogDefinitions.Count; x++)
                {
                    AnalogValues.Add(new AnalogValue(this, configurationCell.AnalogDefinitions[x]));
                }

                // Define any digital values
                for (x = 0; x < configurationCell.DigitalDefinitions.Count; x++)
                {
                    DigitalValues.Add(new DigitalValue(this, configurationCell.DigitalDefinitions[x]));
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="DataCell"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected DataCell(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Deserialize data cell elements...
            m_msvID = info.GetString("msvID");
            m_dataSet = info.GetString("dataSet");
            m_sampleCount = info.GetUInt16("sampleCount");
            m_configurationRevision = info.GetUInt32("configurationRevision");
            m_sampleSynchronization = info.GetByte("sampleSynchronization");
            m_sampleRate = info.GetUInt16("sampleRate");
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the reference to parent <see cref="DataFrame"/> of this <see cref="DataCell"/>.
        /// </summary>
        public new DataFrame Parent
        {
            get
            {
                return base.Parent as DataFrame;
            }
            set
            {
                base.Parent = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ConfigurationCell"/> associated with this <see cref="DataCell"/>.
        /// </summary>
        public new ConfigurationCell ConfigurationCell
        {
            get
            {
                return base.ConfigurationCell as ConfigurationCell;
            }
            set
            {
                base.ConfigurationCell = value;
            }
        }

        /// <summary>
        /// Gets or sets status flags for this <see cref="DataCell"/>.
        /// </summary>
        public new StatusFlags StatusFlags
        {
            get
            {
                return (StatusFlags)(base.StatusFlags & ~(ushort)(StatusFlags.UnlockedTimeMask | StatusFlags.TriggerReasonMask));
            }
            set
            {
                base.StatusFlags = (ushort)((base.StatusFlags & (ushort)(StatusFlags.UnlockedTimeMask | StatusFlags.TriggerReasonMask)) | (ushort)value);
            }
        }

        /// <summary>
        /// Gets or sets unlocked time of this <see cref="DataCell"/>.
        /// </summary>
        public UnlockedTime UnlockedTime
        {
            get
            {
                return (UnlockedTime)(base.StatusFlags & (ushort)StatusFlags.UnlockedTimeMask);
            }
            set
            {
                base.StatusFlags = (ushort)((base.StatusFlags & ~(ushort)StatusFlags.UnlockedTimeMask) | (ushort)value);
                SynchronizationIsValid = (value == Iec61850_90_5.UnlockedTime.SyncLocked);
            }
        }

        /// <summary>
        /// Gets or sets trigger reason of this <see cref="DataCell"/>.
        /// </summary>
        public TriggerReason TriggerReason
        {
            get
            {
                return (TriggerReason)(base.StatusFlags & (short)StatusFlags.TriggerReasonMask);
            }
            set
            {
                base.StatusFlags = (ushort)((base.StatusFlags & ~(short)StatusFlags.TriggerReasonMask) | (ushort)value);
                DeviceTriggerDetected = (value != Iec61850_90_5.TriggerReason.Manual);
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if data of this <see cref="DataCell"/> is valid.
        /// </summary>
        public override bool DataIsValid
        {
            get
            {
                // TODO: Should data be considered invalid when signature check fails? On my test device this would always be invalid since SHA is fixed...
                return (StatusFlags & Iec61850_90_5.StatusFlags.DataIsValid) == 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DataIsValid;
                else
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DataIsValid;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if timestamp of this <see cref="DataCell"/> is valid based on GPS lock.
        /// </summary>
        public override bool SynchronizationIsValid
        {
            get
            {
                // TODO: Not sure which synchronization flag should take priority here - so using both for now...
                return (StatusFlags & Iec61850_90_5.StatusFlags.DeviceSynchronizationError) == 0 && m_sampleSynchronization > 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DeviceSynchronizationError;
                else
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DeviceSynchronizationError;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="PhasorProtocols.DataSortingType"/> of this <see cref="DataCell"/>.
        /// </summary>
        public override DataSortingType DataSortingType
        {
            get
            {
                return (((StatusFlags & Iec61850_90_5.StatusFlags.DataSortingType) == 0) ? PhasorProtocols.DataSortingType.ByTimestamp : PhasorProtocols.DataSortingType.ByArrival);
            }
            set
            {
                if (value == PhasorProtocols.DataSortingType.ByTimestamp)
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DataSortingType;
                else
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DataSortingType;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if source device of this <see cref="DataCell"/> is reporting an error.
        /// </summary>
        public override bool DeviceError
        {
            get
            {
                return (StatusFlags & Iec61850_90_5.StatusFlags.DeviceError) > 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DeviceError;
                else
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DeviceError;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if device trigger is detected for this <see cref="DataCell"/>.
        /// </summary>
        public bool DeviceTriggerDetected
        {
            get
            {
                return (StatusFlags & Iec61850_90_5.StatusFlags.DeviceTriggerDetected) > 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.DeviceTriggerDetected;
                else
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.DeviceTriggerDetected;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if configuration change was detected for this <see cref="DataCell"/>.
        /// </summary>
        public bool ConfigurationChangeDetected
        {
            get
            {
                return (StatusFlags & Iec61850_90_5.StatusFlags.ConfigurationChanged) > 0;
            }
            set
            {
                if (value)
                    StatusFlags = StatusFlags | Iec61850_90_5.StatusFlags.ConfigurationChanged;
                else
                    StatusFlags = StatusFlags & ~Iec61850_90_5.StatusFlags.ConfigurationChanged;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for the <see cref="ChannelFrameBase{T}"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                baseAttributes.Add("MSVID", m_msvID);
                baseAttributes.Add("Dataset", m_dataSet);
                baseAttributes.Add("Sample Count", m_sampleCount.ToString());
                baseAttributes.Add("Configuration Revision", m_configurationRevision.ToString());
                baseAttributes.Add("Sample Synchronization", m_sampleSynchronization + ": " + (m_sampleSynchronization == 0 ? "Not Synchronized" : "Synchronized"));
                baseAttributes.Add("Sample Rate", m_sampleRate.ToString());
                baseAttributes.Add("Unlocked Time", (int)UnlockedTime + ": " + UnlockedTime);
                baseAttributes.Add("Device Trigger Detected", DeviceTriggerDetected.ToString());
                baseAttributes.Add("Trigger Reason", (int)TriggerReason + ": " + TriggerReason);
                baseAttributes.Add("Configuration Change Detected", ConfigurationChangeDetected.ToString());

                return baseAttributes;
            }
        }

        /// <summary>
        /// Gets the length of the body.
        /// </summary>
        protected override int BodyLength
        {
            get
            {
                if (m_parsedBodyLength == 0)
                    return base.BodyLength;

                return m_parsedBodyLength;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Parses the binary body image.
        /// </summary>
        /// <param name="buffer">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="buffer"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="buffer"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        protected override int ParseBodyImage(byte[] buffer, int startIndex, int length)
        {
            const decimal timebase = 16777216;
            CommonFrameHeader header = Parent.CommonHeader;
            int tagLength, index = startIndex;

            // Get reference to configuration frame, if available
            m_configuration = Parent.ConfigurationFrame;

            // Parse each ASDU in incoming frame (e.g, DataCell(t-2), DataCell(t-1), DataCell(t))
            for (int i = 0; i < header.AsduCount; i++)
            {
                // Handle redundant ASDU - last one parsed will be newest and exposed normally
                if (i > 0)
                {
                    if (header.ParseRedundantASDUs)
                    {
                        // Create a new data frame to hold redundant ASDU data
                        DataFrame dataFrame = new DataFrame
                        {
                            ConfigurationFrame = m_configuration,
                            CommonHeader = header
                        };

                        // Add a copy of the current data cell to the new frame 
                        dataFrame.Cells.Add(this.MemberwiseClone() as DataCell);

                        // Publish new data frame with redundant ASDU data
                        header.PublishFrame(dataFrame);
                    }

                    // Clear any existing ASDU values from this data cell
                    PhasorValues.Clear();
                    AnalogValues.Clear();
                    DigitalValues.Clear();
                }

                // Validate ASDU sequence tag exists and skip past it
                buffer.ValidateTag(SampledValueTag.AsduSequence, ref index);

                // Parse MSVID value
                m_msvID = buffer.ParseStringTag(SampledValueTag.MsvID, ref index);

                // If formatted according to implementation agreement, MSVID value will contain an ID code and station name
                if (!string.IsNullOrWhiteSpace(m_msvID))
                {
                    int underscoreIndex = m_msvID.IndexOf("_");

                    if (underscoreIndex > 0)
                    {
                        if (!ushort.TryParse(m_msvID.Substring(0, underscoreIndex), out m_idCode))
                        {
                            m_idCode = 1;
                            m_stationName = m_msvID;
                        }
                        else
                        {
                            m_stationName = m_msvID.Substring(underscoreIndex + 1);
                        }
                    }
                    else
                    {
                        m_idCode = 1;
                        m_stationName = m_msvID;
                    }
                }
                else
                {
                    m_idCode = 1;
                    m_stationName = "IEC61850Dataset";
                }

                // Parse dataset name
                m_dataSet = buffer.ParseStringTag(SampledValueTag.Dataset, ref index);

                // Parse sample count (for some reason this is coming in as 3 bytes)
                m_sampleCount = buffer.ParseUInt16Tag(SampledValueTag.SmpCnt, ref index);

                // Parse configuration revision (for some reason this is coming in as 5 bytes)
                m_configurationRevision = buffer.ParseUInt32Tag(SampledValueTag.ConfRev, ref index);

                // Parse refresh time
                if ((SampledValueTag)buffer[index] != SampledValueTag.RefrTm)
                    throw new InvalidOperationException("Encountered out-of-sequence or unknown sampled value tag: 0x" + buffer[startIndex].ToString("X").PadLeft(2, '0'));

                index++;
                tagLength = buffer.GetTagLength(ref index);

                if (tagLength < 8)
                    throw new InvalidOperationException(string.Format("Unexpected length for \"{0}\" tag: {1}", SampledValueTag.RefrTm, tagLength));

                uint secondOfCentury = EndianOrder.BigEndian.ToUInt32(buffer, index);
                uint fractionOfSecond = EndianOrder.BigEndian.ToUInt32(buffer, index + 4);
                index += 8;

                // Get whole seconds of timestamp
                long timestamp = (new UnixTimeTag((double)secondOfCentury)).ToDateTime().Ticks;

                // Add fraction seconds of timestamp
                decimal fractionalSeconds = (fractionOfSecond & ~Common.TimeQualityFlagsMask) / (decimal)timebase;
                timestamp += (long)(fractionalSeconds * (decimal)Ticks.PerSecond);

                // Apply parsed timestamp to common header
                header.Timestamp = timestamp;
                header.TimeQualityFlags = (TimeQualityFlags)(fractionOfSecond & Common.TimeQualityFlagsMask);

                // Parse sample synchronization state
                m_sampleSynchronization = buffer.ParseByteTag(SampledValueTag.SmpSynch, ref index);

                // Parse optional sample rate
                if ((SampledValueTag)buffer[index] == SampledValueTag.SmpRate)
                    m_sampleRate = buffer.ParseUInt16Tag(SampledValueTag.SmpRate, ref index);

                // Validate that next tag is for sample values
                if ((SampledValueTag)buffer[index] != SampledValueTag.Samples)
                    throw new InvalidOperationException("Encountered out-of-sequence or unknown sampled value tag: 0x" + buffer[startIndex].ToString("X").PadLeft(2, '0'));

                index++;
                tagLength = buffer.GetTagLength(ref index);

                // Attempt to derive a configuration if none is defined
                if ((object)m_configuration == null)
                {
                    // If requested, attempt to load configuration from an associated ETR file
                    if (header.UseETRConfiguration)
                        ParseETRConfiguration();

                    // If we still have no configuration, see if a "guess" is requested
                    if ((object)m_configuration == null && header.GuessConfiguration)
                        GuessAtConfiguration(tagLength);
                }

                if ((object)m_configuration == null)
                {
                    // If the configuration is still unavailable, skip past sample values - don't know the details otherwise
                    index += tagLength;
                }
                else
                {
                    // Validate that sample size matches current configuration
                    if (tagLength != m_configuration.GetCalculatedSampleLength())
                        throw new InvalidOperationException("Configuration does match data sample size - cannot parse data");

                    // Parse standard synchrophasor sequence
                    index += base.ParseBodyImage(buffer, index, length);
                }

                // Skip past optional sample mod tag, if defined
                if ((SampledValueTag)buffer[startIndex] == SampledValueTag.SmpMod)
                    buffer.ValidateTag(SampledValueTag.SmpMod, ref index);

                // Skip past optional UTC timestamp tag, if defined
                if ((SampledValueTag)buffer[startIndex] == SampledValueTag.UtcTimestamp)
                    buffer.ValidateTag(SampledValueTag.UtcTimestamp, ref index);
            }

            // Get parsed body length
            m_parsedBodyLength = index - startIndex;

            return m_parsedBodyLength;
        }

        // Attempt to parse an associated ETR configuration
        private void ParseETRConfiguration()
        {
            if (!string.IsNullOrWhiteSpace(m_msvID))
            {
                // See if an associated ETR file exists
                string etrFileName = m_msvID + ".etr";
                string etrFilePath = FilePath.GetAbsolutePath(etrFileName);
                bool foundETRFile = File.Exists(etrFilePath);

                if (!foundETRFile)
                {
                    // Also test for ETR in configuration cache folder
                    etrFilePath = FilePath.GetAbsolutePath("ConfigurationCache\\" + etrFileName);
                    foundETRFile = File.Exists(etrFilePath);
                }

                if (foundETRFile)
                {
                    try
                    {
                        StreamReader reader = new StreamReader(etrFilePath);
                        SignalType signalType, lastSignalType = SignalType.NONE;
                        string label;
                        bool statusDefined = false;
                        int magnitudeSignals = 0;
                        int angleSignals = 0;

                        ConfigurationFrame configFrame = new ConfigurationFrame(16777216, 1, DateTime.UtcNow.Ticks, m_sampleRate);
                        ConfigurationCell configCell = new ConfigurationCell(configFrame, m_idCode, LineFrequency.Hz60)
                        {
                            StationName = m_stationName
                        };

                        // Keep parsing records until there are no more...
                        while (ParseNextSampleDefinition(reader, out signalType, out label))
                        {
                            bool badOrder = false;

                            // Validate signal order
                            switch (signalType)
                            {
                                case SignalType.FLAG:
                                    badOrder = lastSignalType != SignalType.NONE;
                                    statusDefined = true;
                                    break;
                                case SignalType.VPHM:
                                case SignalType.IPHM:
                                    badOrder = (lastSignalType != SignalType.FLAG && lastSignalType != SignalType.VPHA && lastSignalType != SignalType.IPHA);
                                    PhasorDefinition phasor = new PhasorDefinition(configCell, label, 1, 0.0D, signalType == SignalType.VPHM ? PhasorType.Voltage : PhasorType.Current, null);
                                    configCell.PhasorDefinitions.Add(phasor);
                                    magnitudeSignals++;
                                    break;
                                case SignalType.VPHA:
                                    badOrder = lastSignalType != SignalType.VPHM;
                                    angleSignals++;
                                    break;
                                case SignalType.IPHA:
                                    badOrder = lastSignalType != SignalType.IPHM;
                                    angleSignals++;
                                    break;
                                case SignalType.FREQ:
                                    badOrder = (lastSignalType != SignalType.VPHA && lastSignalType != SignalType.IPHA);
                                    break;
                                case SignalType.DFDT:
                                    badOrder = lastSignalType != SignalType.FREQ;
                                    configCell.FrequencyDefinition = new FrequencyDefinition(configCell, "Frequency");
                                    break;
                                case SignalType.ALOG:
                                    badOrder = (lastSignalType != SignalType.DFDT && lastSignalType != SignalType.ALOG);
                                    AnalogDefinition analog = new AnalogDefinition(configCell, label, 1, 0.0D, AnalogType.SinglePointOnWave);
                                    configCell.AnalogDefinitions.Add(analog);
                                    break;
                                case SignalType.DIGI:
                                    badOrder = (lastSignalType != SignalType.DFDT && lastSignalType != SignalType.ALOG && lastSignalType != SignalType.DIGI);
                                    DigitalDefinition digital = new DigitalDefinition(configCell, label, 0, 1);
                                    configCell.DigitalDefinitions.Add(digital);
                                    break;
                                default:
                                    throw new InvalidOperationException("Unxpected signal type enecountered: " + signalType);
                            }

                            if (badOrder)
                                throw new InvalidOperationException(string.Format("Invalid signal order encountered - {0} cannot follow {1}. Standard synchrophasor order is: status flags, one or more phasor magnitude/angle pairs, frequency, dF/dt, optional analogs, optional digitals", signalType, lastSignalType));

                            lastSignalType = signalType;
                        }

                        if (!statusDefined)
                            throw new InvalidOperationException("No status flag signal was defined.");

                        if (configCell.PhasorDefinitions.Count == 0)
                            throw new InvalidOperationException("No phasor magnitude/angle signal pairs were defined.");

                        if (magnitudeSignals != angleSignals)
                            throw new InvalidOperationException("Phasor magnitude/angle signal pair mismatch - there must be a one-to-one defintion between angle and magnitude signals.");

                        if (configCell.FrequencyDefinition == null)
                            throw new InvalidOperationException("No frequency and dF/dt signal pair was defined.");

                        // Add cell to configuration frame
                        configFrame.Cells.Add(configCell);

                        // Publish configuration frame
                        PublishNewConfigurationFrame(configFrame);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException(string.Format("Failed to parse associated ETR configuration \"{0}\": {1}", etrFilePath, ex.Message), ex);
                    }
                }
            }
        }

        // Complex function used to read next signal type and lable from the ETR file...
        private bool ParseNextSampleDefinition(StreamReader reader, out SignalType signalType, out string label)
        {
            string signalLabel, dataType, signalDetail;
            bool result = false;

            signalType = SignalType.NONE;
            label = null;

            // Attempt to read signal definition and label line
            signalLabel = reader.ReadLine();

            if (signalLabel != null)
            {
                // Attempt to reader data type line
                dataType = reader.ReadLine();

                if (dataType != null)
                {
                    // Clean up data type
                    dataType = dataType.Trim().ToLower();

                    int index = signalLabel.IndexOf("-");

                    // Get defined signal label
                    label = signalLabel.Substring(index + 1).Trim();

                    // See if signal type contains ST
                    index = signalLabel.IndexOf(".ST.");

                    if (index > 0)
                    {
                        // Get detail portion of signal type label
                        signalDetail = signalLabel.Substring(index + 4);

                        // Status or digital value
                        if (signalDetail.StartsWith("Ind1"))
                        {
                            // Status word value
                            signalType = SignalType.FLAG;

                            if (dataType != "i2")
                                throw new InvalidOperationException(string.Format("Invalid data type size {0} specified for signal type {1} parsed from {2}", dataType, signalType, signalLabel));

                            result = true;
                        }
                        else if (signalDetail.StartsWith("Ind2"))
                        {
                            // Digital value
                            signalType = SignalType.DIGI;

                            if (dataType != "i2")
                                throw new InvalidOperationException(string.Format("Invalid data type size {0} specified for signal type {1} parsed from {2}", dataType, signalType, signalLabel));

                            result = true;
                        }
                        else
                        {
                            // Unable to determine signal type
                            throw new InvalidOperationException(string.Format("Unable to determine ETR signal type for {0} ({1})", signalLabel, dataType));
                        }
                    }
                    else
                    {
                        // See if signal type contains MX
                        index = signalLabel.IndexOf(".MX.");

                        if (index > 0)
                        {
                            // Get detail portion of signal type label
                            signalDetail = signalLabel.Substring(index + 4);

                            // Frequency or phasor value
                            if (signalDetail.StartsWith("HzRte"))
                            {
                                // dF/dt value
                                signalType = SignalType.DFDT;

                                if (dataType != "f4")
                                    throw new InvalidOperationException(string.Format("Invalid data type size {0} specified for signal type {1} parsed from {2}", dataType, signalType, signalLabel));

                                result = true;
                            }
                            else if (signalDetail.StartsWith("Hz"))
                            {
                                // Frequency value
                                signalType = SignalType.FREQ;

                                if (dataType != "f4")
                                    throw new InvalidOperationException(string.Format("Invalid data type size {0} specified for signal type {1} parsed from {2}", dataType, signalType, signalLabel));

                                result = true;
                            }
                            else if (signalDetail.StartsWith("PhV") || signalDetail.StartsWith("SeqV"))
                            {
                                if (signalDetail.Contains(".mag."))
                                {
                                    // Voltage phase magnitude
                                    signalType = SignalType.VPHM;
                                }
                                else if (signalDetail.Contains(".ang."))
                                {
                                    // Voltage phase angle
                                    signalType = SignalType.VPHA;
                                }
                                else
                                {
                                    // Unable to determine signal type
                                    throw new InvalidOperationException(string.Format("Unable to determine ETR signal type for {0} ({1})", signalLabel, dataType));
                                }

                                if (dataType != "f4")
                                    throw new InvalidOperationException(string.Format("Invalid data type size {0} specified for signal type {1} parsed from {2}", dataType, signalType, signalLabel));

                                result = true;
                            }
                            else if (signalDetail.StartsWith("SeqA") || signalDetail.StartsWith("A"))
                            {
                                if (signalDetail.Contains(".mag."))
                                {
                                    // Current phase magnitude
                                    signalType = SignalType.IPHM;
                                }
                                else if (signalDetail.Contains(".ang."))
                                {
                                    // Current phase angle
                                    signalType = SignalType.IPHA;
                                }
                                else
                                {
                                    // Unable to determine signal type
                                    throw new InvalidOperationException(string.Format("Unable to determine ETR signal type for {0} ({1})", signalLabel, dataType));
                                }

                                if (dataType != "f4")
                                    throw new InvalidOperationException(string.Format("Invalid data type size {0} specified for signal type {1} parsed from {2}", dataType, signalType, signalLabel));

                                result = true;
                            }
                            else
                            {
                                // Unable to determine signal type
                                throw new InvalidOperationException(string.Format("Unable to determine ETR signal type for {0} ({1})", signalLabel, dataType));
                            }
                        }
                        else
                        {
                            // Assuming anything else is an Analog value
                            signalType = SignalType.ALOG;

                            if (dataType != "f4")
                                throw new InvalidOperationException(string.Format("Invalid data type size {0} specified for assumed analog signal type parsed from {1}", dataType, signalLabel));

                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        // Attempt to guess at the configuration
        private void GuessAtConfiguration(int sampleLength)
        {
            // Removed fixed length for 2-byte status, 4-byte frequency and 4-byte dF/dt
            int test = sampleLength - 10;

            // Assume remaining even 8-byte pairs are phasor values (i.e., 4-byte magnitude and 4-byte angle)
            int phasors = test / 8;
            test -= phasors * 8;

            // Assume remaining even 2-byte items are digital values
            int digitals = test / 2;
            test -= digitals * 2;

            // If no bytes remain, we'll assume this distribution as a guess configuration
            if (test == 0)
            {
                // Just assume some details for a configuration frame
                ConfigurationFrame configFrame = new ConfigurationFrame(16777216, 1, DateTime.UtcNow.Ticks, m_sampleRate);
                ConfigurationCell configCell = new ConfigurationCell(configFrame, m_idCode, LineFrequency.Hz60)
                {
                    StationName = m_stationName
                };

                // Add phasors
                for (int i = 0; i < phasors; i++)
                {
                    PhasorType type = i < phasors / 2 ? PhasorType.Voltage : PhasorType.Current;
                    PhasorDefinition phasor = new PhasorDefinition(configCell, "Phasor " + (i + 1), 1, 0.0D, type, null);
                    configCell.PhasorDefinitions.Add(phasor);
                }

                // Add frequency
                configCell.FrequencyDefinition = new FrequencyDefinition(configCell, "Frequency");

                // Add digitals
                for (int i = 0; i < digitals; i++)
                {
                    DigitalDefinition digital = new DigitalDefinition(configCell, "Digital " + (i + 1), 0, 1);
                    configCell.DigitalDefinitions.Add(digital);
                }

                configFrame.Cells.Add(configCell);
                PublishNewConfigurationFrame(configFrame);
            }
        }

        // Exposes a newly created configuration frame
        private void PublishNewConfigurationFrame(ConfigurationFrame configFrame)
        {
            // Cache new configuration
            m_configuration = configFrame;

            // Provide new configuration to the parent data frame
            Parent.ConfigurationFrame = configFrame;

            // Update local associated configuration cell
            ConfigurationCell = configFrame.Cells[0];

            // Update local parsing state with new configuration info
            State = new DataCellParsingState(
                ConfigurationCell,
                Iec61850_90_5.PhasorValue.CreateNewValue,
                Iec61850_90_5.FrequencyValue.CreateNewValue,
                Iec61850_90_5.AnalogValue.CreateNewValue,
                Iec61850_90_5.DigitalValue.CreateNewValue);

            // Publish the configuration frame to the rest of the system
            Parent.CommonHeader.PublishFrame(configFrame);
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Add data cell elements for serialization...
            info.AddValue("msvID", m_msvID);
            info.AddValue("dataSet", m_dataSet);
            info.AddValue("sampleCount", m_sampleCount);
            info.AddValue("configurationRevision", m_configurationRevision);
            info.AddValue("sampleSynchronization", m_sampleSynchronization);
            info.AddValue("sampleRate", m_sampleRate);
        }

        #endregion

        #region [ Static ]

        // Static Methods

        // Delegate handler to create a new IEC 61850-90-5 data cell
        internal static IDataCell CreateNewCell(IChannelFrame parent, IChannelFrameParsingState<IDataCell> state, int index, byte[] buffer, int startIndex, out int parsedLength)
        {
            IDataFrameParsingState parsingState = state as IDataFrameParsingState;
            IConfigurationCell configurationCell = null;

            // With or without an associated configuration, we'll parse the data cell
            if (parsingState != null && parsingState.ConfigurationFrame != null)
                configurationCell = parsingState.ConfigurationFrame.Cells[index];

            DataCell dataCell = new DataCell(parent as IDataFrame, configurationCell);

            parsedLength = dataCell.ParseBinaryImage(buffer, startIndex, 0);

            return dataCell;
        }

        #endregion
    }
}