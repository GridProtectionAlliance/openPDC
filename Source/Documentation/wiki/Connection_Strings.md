[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md)

|   |   |   |   |
|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC)** | **[openPDC Wiki Home](openPDC_Home.md)** | **[Documentation](openPDC_Documentation_Home.md)** |

# Connection Strings

This document goes over the options that can be specified using the connection string for each adapter in the system.

- [ActionAdapterBase ](#actionadapterbase)
- [AdapterBase](#adapterbase)
- [AdoInputAdapter](#adoinputadapter)
- [AdoOutputAdapter](#adooutputadapter)
- [BpaPdcStream.Concentrator](#bpapdcstream.concentrator)
- [CalculatedMeasurementBase](#calculatedmeasurementbase)
- [CsvAdapters.CsvInputAdapter](#csvadapters.csvinputadapter)
- [CsvAdapters.CsvOutputAdapter](#csvadapters.csvoutputadapter)
- [DataQualityMonitoring.FlatlineTest](#dataqualitymonitoring.flatlinetest)
- [DataQualityMonitoring.RangeTest](#dataqualitymonitoring.rangetest)
- [DataQualityMonitoring.TimestampTest](#dataqualitymonitoring.timestamptest)
- [FacileActionAdapterBase](#facileactionadapterbase)
- [HistorianAdapters.InputAdapter](#historianadapters.inputadapter)
- [HistorianAdapters.LocalOutputAdapter](#historianadapters.localoutputadapter)
- [HistorianAdapters.RemoteOutputAdapter](#historianadapters.remoteoutputadapter)
- [ICCPExport.FileExporter](#iccpexport.fileexporter)
- [IEEEC37_118.Concentrator](#ieeec37_118.concentrator)
- [InputAdapterBase](#inputadapterbase)
- [MySqlAdapters.MySqlInputAdapter](#mysqladapters.mysqlinputadapter)
- [MySqlAdapters.MySqlOutputAdapter](#mysqladapters.mysqloutputadapter)
- [OutputAdapterBase](#outputadapterbase)
- [PhasorDataConcentratorBase](#phasordataconcentratorbase)
- [PhasorMeasurementMapper](#phasormeasurementmapper)
- [PowerCalculations.AverageFrequency](#powercalculations.averagefrequency)
- [PowerCalculations.EventDetection.FrequencyExcursion](#powercalculations.eventdetection.frequencyexcursion)
- [PowerCalculations.EventDetection.LossOfField](#powercalculations.eventdetection.lossoffield)
- [PowerCalculations.PowerStability](#powercalculations.powerstability)
- [PowerCalculations.ReferenceAngle](#powercalculations.referenceangle)
- [PowerCalculations.ReferenceMagnitude](#powercalculations.referencemagnitude)
- [Syntax for inputMeasurementKeys and outputMeasurements](#input_and_output_syntax)
- [Typical time zones](#time_zone_ids)

## ActionAdapterBase

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| framesPerSecond | int |    | Determines how many frames are published by the action adapter each second. |
| *[lagTime](Help_Me_Choose_Diagrams.md#lag-time)* | double |    | Defines the maximum time, in seconds, that the action adapter will wait for new measurements to arrive before publishing the frame. The value must be greater than zero, but it can be less than one for subsecond tolerances. |
| *[leadTime](Help_Me_Choose_Diagrams.md#lead-time)* | double |    | Defines the maximum time, in seconds, that the action adapter will tolerate for measurements that arrive with a future timestamp as compared to "real-time" -- a relative term based on the value of *useLocalClockAsRealTime*. The *leadTime* value is also applied as the +/- tolerance of the local clock to estimate real-time when *useLocalClockAsRealTime* is false. The value must be greater than zero, but it can be less than one for subsecond tolerances. If the *leadTime* is set too short (relative to the accuracy of the local clock), measurements may be unnecessarily discarded. However, if the local clock is very accurate, and accordingly *useLocalClockAsRealTime* is set true, this number should be very small, e.g., 0.1. |
| *[useLocalClockAsRealTime](Help_Me_Choose_Diagrams.md#use-local-clock-as-realtime)* | bool | false | Indicates whether to use the local clock as real-time or to instead use the timestamp of the latest received measurement. This should only be set to true if the local system clock time is derived by GPS or otherwise very accurately synchronized to real-time. The accuracy of the local clock time relative to GPS-time determines the needed value for the *leadTime* setting. There is less processing involved when *useLocalClockAsRealTime* is set true, so having the local system clock synchronized with GPS represents a system optimization. |
| *[ignoreBadTimestamps](Help_Me_Choose_Diagrams.md#ignore-bad-timestamps)* | bool | false | Determines if bad timestamps (as determined by measurement's timestamp quality) should be ignored when sorting measurements. Setting this property to true forces system to use timestamps as-is without checking quality. If this property is true, it will supersede operation of *allowSortsByArrival*. |
| *[allowSortsByArrival](Help_Me_Choose_Diagrams.md#allow-sorts-by-arrival)* | bool | true | Indicates whether measurements with bad timestamps should instead be  sorted by their arrival time. If this property is true, any incoming measurement with a bad timestamp quality will be sorted according to its arrival time (i.e., real-time). Setting this property to false will cause all measurements with a bad timestamp quality to be discarded. This property will only be considered when *ignoreBadTimestamps* is false. |
| *initializationTimeout* | int | 15000 | Defines the maximum time, in milliseconds, adapter will wait during start for initialization to complete. Set to -1 to wait indefinitely. |
| *inputMeasurementKeys* | string | null | Defines the input measurements for the adapter. The adapter can then determine whether a given measurement was explicitly entered as an input measurement by using the `IsInputMeasurement(MeasurementKey)` method. If no input measurements are defined, `IsInputMeasurement(MeasurementKey)` will always return true. `IsInputMeasurement(MeasurementKey)` is used by the default `QueueMeasurementsForProcessing(IEnumerable<IMeasurement>)` method so that only input measurements will be processed by the action adapter. |
| *outputMeasurements | string | null | Defines the output measurements for the adapter. The adapter can access these measurements using the `OutputMeasurements` property. Adapters that create new measurements should probably clone the output measurements using `Measurement.Clone(IMeasurement)` and send the clones into the system using `OnNewMeasurements(ICollection<IMeasurement>)`. |
| *minimumMeasurementsToUse* | int | # of input measurements | Defines the number of measurements returned by the `TryGetMinimumNeededMeasurements()` method which can be called by the user-defined implementation. |
| *[timeResolution](Help_Me_Choose_Diagrams.md#time-resolution)* | long | 10000 | Determines the resolution used when sorting the measurements into their respective frames. If frames are configured to have a higher resolution than the measurements, some measurements could end up in the wrong frame due to rounding errors - use this property to assign the maximum resolution of the system frames. The maximum value possible is 10000000. The minimum value possible is 0. See table below for typical resolution values. |
| *[allowPreemptivePublishing](Help_Me_Choose_Diagrams.md#allow-preemptive-publishing)* | bool | true | Defines the flag that allows system to preemptively publish frames before the lag time expires assuming all expected data have arrived. |
| *performTimestampReasonabilityCheck* | bool | true | Defines flag that determines if timestamp reasonability checks should be performed on incoming measurements (i.e., measurement timestamps are compared to system clock for reasonability using *leadTime* tolerance). Setting this value to false will make the concentrator use the latest value received as "real-time" without validation; this is not recommended in production since time reported by source devices may be grossly incorrect. For non-production configurations, setting this value to false will allow concentration of historical data. |
| *[downsamplingMethod](Help_Me_Choose_Diagrams.md#downsampling-method)* | string | LastReceived | Defines the downsampling method to use if data is being received at a higher rate than the publishing frame rate defined by *framesPerSecond*. Can be one of LastReceived, Closest or Filtered - see table below for more detail. |
| *processByReceivedTimestamp* | bool | false | Defines flag that determines if concentrator should sort measurements by received time. Setting this value to true will make concentrator use the timestamp of measurement reception (typically the measurement creation time), for sorting and publication. This is useful in scenarios where the concentrator will be receiving very large volumes of data but not necessarily in real-time, such as, reading values from a file where you want data to be sorted and processed as fast as possible. Setting this value to true forces *useLocalClockAsRealTime* to be true and supercedes operation of
*performTimestampReasonabilityCheck*. |
| *trackPublishedTimestamp* | bool | false | Defines flag that determines if system should track timestamp of publication for all frames and measurements. Setting this value to true will cause the concentrator to mark the timestamp of publication in each frame's and measurement's *PublishedTimestamp* property. Since this is extra processing time that may not be needed except in cases of calculating statistics for system performance, this is not enabled by default. |
| *maximumPublicationTimeout* | int | milliseconds per frame + 2% | Defines the maximum frame publication timeout in milliseconds, set to -1 to wait indefinitely. The concentrator automatically defines a precision timer to provide the heatbeat for frame publication, however if the system gets busy the heartbeat signals can be missed. This property defines a maximum wait timeout before reception of the heartbeat signal to make sure frame publications continue to occur in a timely fashion even when a system is under stress. This property is automatically defined as 2% more than the number of milliseconds per frame when the *framesPerSecond* property is set. |

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of these parameters.

Time resolution value is typically a power of 10 based on the number of ticks per the desired resolution. The following are common resolutions and their respective
*timeResolution* values.

| Resolution | timeResolution |
| ---------- | -------------- |
| Seconds | 10000000 |
| Milliseconds with slack\* | 330000 |
| Milliseconds | 10000 |
| Microseconds | 10 |
| Ticks (100-nanoseconds) | 0 |

\* Use this setting for BPA PDCstreams or other devices that may have more variation in calculated timestamps. Slack value will vary with incoming frame rate, for example: use 330,000 for 30 frames per second, 160,000 for 60 frames per second, 80,000 for 120  frames per second, etc. Actual slack value may need to be more or less depending on the size of the timestamp variation in the incoming device stream.

| Downsample Method | Description |
| ----------------- | ----------- |
| LastReceived | Downsamples to the last measurement received. Use this option if no downsampling is needed or the selected value is not critical. This is the fastest option if the incoming and outgoing frame rates match. |
| Closest | Downsamples to the measurement closest to frame time. This is the typical operation used when performing simple downsampling. This is the fastest option if the incoming frame rate is faster than the outgoing frame rate. |
| Filtered | Downsamples by applying a user-defined value filter\* over all received measurements to anti-alias the results. This option will produce the best result but has a processing penalty.

\* By default all analogs are downsampled using an average, phase angles are downsampled using a wrapping-angle average and digital values (including status flags) are downsampled by selecting the majority value.

Example: `framesPerSecond=30; lagTime=3; leadTime=1; useLocalClockAsRealTime=false; allowSortsByArrival=false; inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType='FREQ'}; outputMeasurements={MYSOURCE:15;MYSOURCE:16,-180,360}; minimumMeasurementsToUse=5; timeResolution=10000; allowPreemptivePublishing=true; downsamplingMethod=Closest`

## AdapterBase

This base class is inherited by both InputAdapterBase and OutputAdapterBase.

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| 
| *initializationTimeout* | int | 15000 | Defines the maximum time, in milliseconds, adapter will wait during start for initialization to complete. Set to -1 to wait indefinitely. |
| *inputMeasurementKeys* | string | null | Defines the input measurements for the adapter. The adapter can then determine whether a given measurement was explicitly entered as an input measurement by using the `IsInputMeasurement(MeasurementKey)` method. If no input measurements are defined, `IsInputMeasurement(MeasurementKey)` will always return true. |
| *outputMeasurements* | string | null | Defines the output measurements for the adapter. The adapter can access these measurements using the OutputMeasurements property. Adapters that create new measurements should probably clone the output measurements using Measurement.Clone(IMeasurement) and send the clones into the system using `OnNewMeasurements(ICollection<IMeasurement>)`. |
| *measurementReportingInterval* | int | 100000 | Defines the measurement reporting interval used to determined how many measurements should be processed before reporting status. Set to zero to disable status reporting. |
| *connectOnDemand* | bool | false | Defines a flag that determines if adapter should always be started or only be started when measurements being handled or created are demanded by other adapters in the Iaon session. Set to false to always start adapter; otherwise set to true to start adapter only when needed. |

Example: `inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'FREQ'}; outputMeasurements={MYSOURCE:15;MYSOURCE:16,-180,360}; measurementReportingInterval=5000`

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of these parameters.

## AdoInputAdapter

Connection strings for this adapter also include all the parameters defined for [AdapterBase](#adapterbase).


| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *tableName* | string | PICOMP | The name of the database table from which measurements are to be retrieved. |
| *connectionString* | string | empty string | The connection string used to connect to the database. |
| *dataProviderString* | string | `{AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.Odbc.OdbcConnection; AdapterType=System.Data.Odbc.OdbcDataAdapter}` | The string that describes the type of connection and adapter used to connect to the database. |
| *timestampFormat* | string | dd-MMM-yyyy HH:mm:ss.fff | The format in which the timestamp is stored in the database. The value "null" indicates that the timestamp is stored as a 64-bit integer, in ticks. |
| *framePerSecond* | int | 30 | The rate at which frames are published from the database to the concentrator. |
| *simulateTimestamp* | bool | true | Indicates whether the adapter should replace the existing timestamps in order to simulate measurements entering the concentrator in real time. |

## AdoOutputAdapter

Connection strings for this adapter also include all the parameters defined for [OutputAdapterBase](#outputadapterbase) and [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *tableName* | string | PICOMP | The name of the database table to which measurements are to be stored. |
| *connectionString* | string | empty string | The connection string used to connect to the database. |
| *dataProviderString* | string |`{AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.Odbc.OdbcConnection; AdapterType=System.Data.Odbc.OdbcDataAdapter}` | The string that describes the type of connection and adapter used to connect to the database. |
| *timestampFormat* | string | dd-MMM-yyyy HH:mm:ss.fff | The format in which the timestamp is to be stored in the database. The value "null" indicates that the timestamp is to be stored as a 64-bit integer, in ticks. |

## BpaPdcStream.Concentrator

This adapter is used by the OutputStream table in the openPDC database when defining an output stream that uses the BPA PDCstream protocol. When defining an output stream in the OutputStream table, most parameters are set automatically by entering information into the columns of the table. Connection strings for this adapter also include all the parameters defined for [PhasorDataConcentratorBase](#phasordataconcentratorbase) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *iniFileName* | string |     | Defines the file name of the INI configuration file for the output stream. |

Example: `iniFileName=TESTSTREAM.ini`

## CalculatedMeasurementBase

Connection strings for this adapter also include all the parameters defined for [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *configurationSection* | string | [Acronym](Manual_Configuration.md#outputstream.acronym-column) | Allows the user to define the section under which adapter settings will be found in the configuration file. If an adapter has configuration file settings, it is up to the person implementing the calculated measurement to handle this. |

## CsvAdapters.CsvInputAdapter

Connection strings for this adapter also include all the parameters defined for [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *file* | string | measurements.csv | The path to the CSV file from which measurements are read. |
| *inputInterval* | double | 33.333333 | The interval, in milliseconds, at which measurements will be reported to the system. |
| *measurementsPerInterval* | int | 5 | The number of measurements to be read from the CSV file at each input interval. |
| *simulateTimestamp* | bool | false | Determines whether the adapter should attach a simulated timestamp to the measurements so that it appears to be reporting in real time. |

## CsvAdapters.CsvOutputAdapter

Connection strings for this adapter also include all the parameters defined for [OutputAdapterBase](#outputadapterbase) and [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *file* | string | measurements.csv | The path to the CSV file from which measurements are read. |

## DataQualityMonitoring.FlatlineTest

Connection strings for this adapter also include all the parameters defined for [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *minFlatline* | double | 4 | The amount of time, in seconds, that a measurements needs to be reporting the same value before it is considered flatlined. |
| *warnInterval* | double | 4 | The amount of time, in seconds, between warnings posted to the openPDC Console. |

Example: `minFlatline=2; warnInterval=10`

## DataQualityMonitoring.RangeTest

Connection strings for this adapter also include all the parameters defined for [ActionAdapterbase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *lowRange* | double |    | The low range for values being tested by this adapter. If a measurement that is tested by the adapter reports a value lower than the low range, it will be considered out of range. |
| *highRange* | double |    | The high range for values being tested by this adapter. If a measurement that is tested by the adapter reports a value higher than the high range, it will be considered out of range. |
| *signalType* | string | null | Defines the signal type of the measurements being tested. The lowRange and highRange parameters need not be defined if this parameter is defined (and valid). Valid values are FREQ, VPHM, IPHM, VPHA, and IPHA. |
| *timeToPurge* | double | 1.0 | Defines how much time should pass, in seconds, before out-of-range measurements should be purged from the system so that memory can be reclaimed and redundant warnings can be prevented. |
| *warnInterval* | double | 4.0 | The amount of time, in seconds, between warnings posted to the openPDC Console. |

The following default low ranges and high ranges are defined for specific signal types (the abbreviation is entered as the signalType parameter).

| Abbreviation | Signal Type | Low Range | High Range |
| ------------ | ----------- | --------- | ---------- |
| *FREQ* | Frequency | 59.95 | 60.05 |
| *VPHM* | Voltage Phasor Magnitude | 475000.0 | 525000.0 |
| *IPHM* | Current Phasor Magnitude | 0.0 | 3000.0 |
| *VPHA* | Voltage Phasor Angle | -180.0 | 180.0 |
| *IPHA* | Current Phasor Angle | -180.0 | 180.0 |

Example: `lowRange=59.95; highRange=60.05; signalType=FREQ; timeToPurge=5.0; warnInterval=10.0`

## DataQualityMonitoring.TimestampTest

Connection strings for this adapter also include all the parameters defined for [FacileActionAdapterBase](#facileactionadapterbase) and [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *concentratorName* | string |    | Defines which concentrator will be used to determine whether measurements arrived with bad timestamps. The value of this parameter must be the name of an action adapter. |
| *timeToPurge* | double | 1.0 | Defines how much time should pass, in seconds, before out-of-range measurements should be purged from the system so that memory can be reclaimed and redundant warnings can be prevented. |
| *warnInterval* | double | 4.0 | The amount of time, in seconds, between warnings posted to the openPDC Console. |

Example: `concentratorName=TESTSTREAM; timeToPurge=5.0; warnInterval=10.0`

## FacileActionAdapterBase

Connection strings for this adapter also include all the parameters defined for [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *framesPerSecond* | int | 0 | The rate at which frames are published in frames per second. |

Example: `framesPerSecond=30`

## HistorianAdapters.InputAdapter

Connection strings for this adapter also include all the parameters defined for [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *server* | string |     | The location of the server broadcasting historic data. |
| *port* | int |     | The port through which the server is broadcasting data. |
| *protocol* | string |    | The protocol used by the server to broadcast the data. Can be either Tcp or Udp. |
| *initiateconnection* | bool |    | Indicates whether the adapter needs to connect to the server or if the server will connect to the adapter on the specified port. |

Example: `protocol=Udp; server=openpdc; port=2004; initiateconnection=true`

## HistorianAdapters.LocalOutputAdapter

This adapter is used by default when defining a [local historian](Manual_Configuration.md#historian.islocal-column) in the database. Connection strings for this  adapter also include all the parameters defined for [OutputAdapterBase](#outputadapterbase) and [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *instancename* | string |    | Determines the name by which certain historian files will be prefixed. If you are using the Historian table in the database to define a local historian, this option is not required and will default to the value in the Historian.Acronym field. Otherwise, it is required. The value will be converted to lowercase before being used. |
| *archivepath* | string | The openPDC [installation directory](Getting_Started.md#installion-directory). | Determines the location where the adapter will place the archive files. |
| *refreshmetadata* | bool | true | Determines whether or not to refresh the metadata when the historian is attempting to connect. |

Also note that the sourceids parameter is automatically defined when using the Historian table in the database. It will default to the value in the *Historian.Acronym* field.

Example: `instancename=devarchive; archivepath=C:\My Archives; refreshmetadata=false`

## HistorianAdapters.RemoteOutputAdapter

This adapter is used by default when defining a [non-local historian](Manual_Configuration.md#historian.islocal-column) in the database. Connection strings for this adapter also include all the parameters defined for [OutputAdapterBase](#outputadapterbase) and [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *server* | string |    | The name or address of the remote historian. |
| *port* | string | 1003 | The TCP port on which the remote historian is listening. |
| *payloadaware* | bool | true | Indicates whether the payload boundaries are to be preserved during transmission. |
| *conservebandwidth* | bool | true | Determines the packet type to use when sending data to the server. |
| *outputisforarchive* | bool | true | Determines whether the measurements are destined for archival. |
| *throttletransmission* | bool | true | Determines whether to wait for acknowledgment from the historian that the last set of points have been received before attempting to send the next set of points. |
| *samplespertransmission* | int | 100000 | The maximum number of points to be published to the historian at once. |

Example: `server=localhost; port=1003; payloadAware=True; conserveBandwidth=True; outputIsForArchive=True; throttleTransmission=True; samplesPerTransmission=100000`

## ICCPExport.FileExporter

Connection strings for this adapter also include all the parameters defined for [CalculatedMeasurement](#calculatedmeasurement) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *exportInterval* | int |    | Defines the time interval, in seconds, between exporting frames of data. This parameter cannot be zero. |
| *inputMeasurementKeys* | string |    | At least one input measurement must be specified for this adapter. |
| *useReferenceAngle* | bool |    | Determines whether this adapter should use a reference angle when exporting phase angles. |
| *referenceAngleMeasurement* | MeasurementKey |      | This parameter is not required when useReferenceAngle is set to false. The values of phase angles will be adjusted based on the value of the reference angle before being exported. The specified measurement key must belong to a phase angle measurement. |
| *companyTagPrefix* | string | null | Defines the company acronym used to prefix the measurements' tags. The prefix will be attached to the tag if it is not already present. |
| *useNumericQuality* | bool | false | Determines whether the system should export a textual representation or a numeric representation of the measurement  quality. |

Example: `exportInterval=5; useReferenceAngle=True; referenceAngleMeasurement=DEVARCHIVE:6; companyTagPrefix=TVA; useNumericQuality=True; inputMeasurementKeys={FILTER ActiveMeasurements WHERE Device='SHELBY' AND SignalType='FREQ'}`

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of inputMeasurementKeys.

## IEEEC37_118.Concentrator

This adapter is used by the OutputStream table in the openPDC database. When defining an output stream in the OutputStream table, most parameters are set automatically by entering information into the columns of the table. Connection strings for this adapter also include all the parameters defined for [PhasorDataConcentratorBase](#phasordataconcentratorbase) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *timeBase* | uint | 16777215 | Defines the resolution of fractional time stamps in IEEE C37.118 configuration frames. |
| *validateIDCode* | bool | false | Defines flag that determines if the IEEE C37.118 concentrator will validate the ID code in command frames before processing. |

Example: `timeBase=16777215; validateIDCode=true`

## InputAdapterBase

This class does not define any parameters of its own, however it does include all the parameters defined for [AdapterBase](#adapterbase).

## MySqlAdapters.MySqlInputAdapter

Connection strings for this adapter also include all the parameters defined for [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *inputInterval* | int | 33 | Indicates the amount of time, in milliseconds, that the adapter should pause between retrieving measurements from the database. |
| *measurementsPerInput* | int | 5 | Determines how many measurements the adapter should retrieve from the database at each input interval. |
| *fakeTimestamps* | bool | false | Indicates whether the adapter should apply fake timestamps to the measurements in order to simulate measurements coming in real time. |
| *server* | string | localhost | The hostname or IP address of the MySQL server. Multiple hosts can be specified separated by `&`. |
| *port* | int | 3306 | The port on which the MySQL server is listening for connections. | 
| *protocol* | string | socket | Specifies the type of connection to make to the server. Values can be: socket or tcp for a socket connection, pipe for a named pipe connection, unix for a Unix socket connection, memory to use MySQL shared memory. |
| *database* | string | mysql | The name of the database to use intially. |
| *uid* | string |    | The MySQL login account being used. |
| *pwd* | string |    | The password for the MySQL account being used. |
| *encrypt* | string | false | When true, SSL encryption is used for all data sent between the client and server if the server has a certificate installed. Recognized values are `true`, `false`, `yes`, and `no`. |
| *charset* | string |    | Specifies the character set that should be used to encode all queries sent to the server. Resultsets are still returned in the character set of the data returned. |
| *default command timeout* | int | 30 | Sets the default value of the command timeout to be used. |
| *connection timeout* | int | 15 | The length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error. |
| *shared memory name* | string | MYSQL | The name of the shared memory object to use for communication if the connection protocol is set to memory. |

## MySqlAdapters.MySqlOutputAdapter

Connection strings for this adapter also include all the parameters defined for [OutputAdapterBase](#outputadapterbase) and [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *server* | string | localhost | The hostname or IP address of the MySQL server. Multiple hosts can be specified separated by `&`. |
| *port* | int | 3306 | The port on which the MySQL server is listening for connections. |
| *protocol* | string | socket | Specifies the type of connection to make to the server. Values can be: socket or tcp for a socket connection, pipe for a named pipe connection, unix for a Unix socket connection, memory to use MySQL shared memory. |
| *database* | string | mysql | The name of the database to use intially. |
| *uid* | string |    | The MySQL login account being used. |
| *pwd* | string |    | The password for the MySQL account being used. |
| *encrypt* | string | false | When true, SSL encryption is used for all data sent between the client and server if the server has a certificate installed. Recognized values are `true`, `false`, `yes`, and `no`. |
| *charset* | string |    | Specifies the character set that should be used to encode all queries sent to the server. Resultsets are still returned in the character set of the data returned. |
| *default command timeout* | int | 30 | Sets the default value of the command timeout to be used. |
| *connection timeout* | int | 15 | The length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error. |
| *shared memory name* | string | MYSQL | The name of the shared memory object to use for communication if the connection protocol is set to memory. |

## OutputAdapterBase

Connection strings for this class also include all the parameters defined for [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *sourceids* | string | null | A comma-separated list of sources that defines which measurements are to be processed by the output adapter. The source of a measurement is usually defined as the acronym of the historian which is archiving that measurement. |

Example: `sourceids=DEVARCHIVE,OTHERSOURCE`

## PhasorDataConcentratorBase

Connection strings for this adapter also include all the parameters defined for [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *IDCode* | ushort |     | Defines an identification code for the concentrator. |
| *dataChannel* | string | null | Defines a connection string for a UDP data stream. |
| *commandChannel* | string | null | Defines a connection string for a TCP data stream that can be used to send commands to the concentrator. |
| *[autoPublishConfigFrame](Help_Me_Choose_Diagrams.md#auto-publish-config-frame)* | bool | true if commandChannel is undefined; false otherwise | Indicates whether the concentrator should publish the configuration frame automatically or if it should wait for the command to be given on the command channel. |
| *[](Help_Me_Choose_Diagrams.md#auto-start-data-channel)autoStartDataChannel)* | bool | true | Indicates whether the data channel should be started automatically when the adapter is started or if it should wait to be explicitly started by the user. |
| *nominalFrequency* | int | 60 | Determines the line frequency to use when transmitting the concentrated measurements. Possible values are 50 and 60. |
| *dataFormat* | string | FloatingPoint | Defines the default data format of the concentrator if no other format is specified for the output device. Can be either FixedInteger or FloatingPoint. |
| *coordinateFormat* | string | Polar | Defines the default coordinate format of the concentrator if no other format is specified for the output device. Can be either Rectangular or Polar. |
| *currentScalingValue* | uint | 2423 | Defines the default current value scaling factor to apply if the <em>dataFormat</em> is set to FixedInteger and no other scaling value is specified for the output device. |
| *voltageScalingValue* | uint | 2725785 | Defines the default voltage value scaling factor to apply if the <em>dataFormat</em> is set to FixedInteger and no other scaling value is specified for the output device. |
| *analogScalingValue* | uint | 1373291 | Defines the default analog value scaling factor to apply if the <em>dataFormat</em> is set to FixedInteger and no other scaling value is specified for the output device. |
| *digitalMaskValue* | uint | 0xFFFF0000 | Defines the default digital mask value made available in configuration frames for use with digital values published by the concentrator if no other mask value is specified for the output device. In IEEE C37.118 configuration frames this value represents two mask words for use with digital status values where the low word represents the the normal status of the digital inputs and the high word represents the valid inputs. |
| *processDataValidFlag* | bool | true | Defines flag that determines if the data valid flag assignments should be processed during frame publication. In cases where client applications ignore the data validity flag, setting this flag to false will provide a slight processing optimization, especially useful on very large data streams. |

At least one of either dataChannel or commandChannel must be specified. If dataChannel is not specified, the command channel will be used to transmit data from the concentrator and issue commands to the concentrator. Otherwise, the data channel is used to broadcast and the command channel, if specified, is used to issue commands. The data channel and command channel each have their own connection string parameters. Check the example to see how to enter them.

**dataChannel**

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *port* | int |    | Defines the local port for the data channel. A value of -1 tells it not to use a local port. A value of 0 tells it to use any port. |
| *clients* | string |     | Defines a comma-separated list of machines to which the data is sent. |
*interface* | string | empty string | Defines the local interface through which the UDP connection is made. |

**commandChannel**

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *port* | int |     | Defines the local port on which the concentrator is listening for commands. |
| *interface* | string | empty string | Defines the local interface through which the TCP connection is made. |

Example: `IDCode=235; dataChannel={port=-1; clients=localhost:8800; interface=0.0.0.0}; commandChannel={port=8900; interface=0.0.0.0}; autoPublishConfigFrame=false; autoStartDataChannel=true; nominalFrequency=60; dataFormat=FloatingPoint; coordinateFormat=Polar`

## PhasorMeasurementMapper

PhasorMeasurementMapper is used by the Device table in the openPDC database. When defining a device in the Device table, most parameters are set automatically by entering information into the columns of the device table. Connection strings for this adapter also include all the parameters defined for [AdapterBase](#adapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *isConcentrator* | bool | false | Indicates whether or not the device represented by this PhasorMeasurementMapper is a concentrator. |
| *accessID* | ushort | 1 | The Access ID or Device ID of the device represented by this PhasorMeasurementMapper. |
| *forceLabelMapping* | bool | false | Forces the preferred use of the device label over the device ID code when mapping devices from a data frame to the local configuration. Enabling this option is less optimal than using a numeric ID code for mapping, but is useful when local configuration ID code does not match that of device configuration. Label lookups are case-insensitive. |
| *primaryDataSource* | string | null | Specifies the acronym of a device using the Gateway Exchange Protocol (GEP) that will be used as the primary data source for this device. When defined, this connection will only activate as a backup connection when the primary GEP connection goes offline - when GEP connection comes back online, this device connection will disconnect. For example, this could be used as a direct backup connection to a substation PMU whose primary data feed is provided through a GEP style connection to a substation PDC connected to the PMU - this connection would only be enabled when the PDC's GEP connection was offline. |
| *sharedMapping* | string | null | Specifies the acronym of another device which will be used as the configuration source for this device. When defined, this device is assumed to be a redundant connection to a source device (e.g., PDC or PMU). Enabling the shared mapping allows a device to be defined with only connection information and no direct configuration; the device "assumes" the configuration of the specified device acronym. In this way the primary device configuration can be maintained once and other multiple redundant connections, as many as needed, can be defined associated with same single configuration. Redundant data will pass through the system and be handled via concentrator [downsampling method](Help_Me_Choose_Diagrams.md#downsampling-method). |
| *phasorProtocol* | PhasorProtocol | IeeeC37_118V1 | Defines the phasor protocol used by the device. The value can be one of IeeeC37_118V1, IeeeC37_118D6, Ieee1344, BpaPdcStream, FNet, SelFastMessage, or Macrodyne. |
| *transportProtocol* | TransportProtocol | Tcp | Defines the protocol used by the device to send its data. The value can be one of Tcp, Udp, Serial, or File. |
| *commandChannel* | string | not defined | If defined, the value of this parameter is the connection string of the command channel. |
| *timeZone* | string | UTC | ID of the time zone for time as reported by device used to offset time back to UTC. See [typical time zones](#time-zone-ids) for possible IDs. |
| *timeAdjustmentTicks* | long | 0 | Allows for manual high-resolution +/- adjustment of the frame timestamps, in ticks, if necessary. One tick = 100 nanoseconds, one millisecond = 10000 ticks. |
| *autoStartDataParsingSequence* | bool | true | Defines flag to automatically send the ConfigFrame2 and EnableRealTimeData command frames used to start a typical data parsing sequence. |
| *skipDisableRealTimeData* | bool | false | Defines flag to skip automatic disabling of the real-time data stream on shutdown or startup. Useful when using UDP multicast with several subscribed clients. |
| executeParseOnSeparateThread* | bool | false | Defines flag that allows frame parsing to be executed on a separate thread (i.e., other than communications thread). Rarely used unless data frames are very large. |
| *simulateTimestamp* | bool | true if transportProtocol = File; false otherwise | Defines flag indicating whether or not to inject local system time (UTC) into parsed data frames. |
| *configurationFile* | string | null | If defined, loads serialized configuration from specified filename before connection is established - useful when receiving UDP only data without the ability to receive a config frame. |
| *dataLossInterval* | double | 5.0 | Defines the amount of time, in seconds, that the PhasorMeasurementMapper should wait before reconnecting to a device which has stopped sending data. |
| allowUseOfCachedConfiguration | bool | true | Defines flag that determines if use of cached configuration during initial connection is allowed when a configuration has not been received within the "*dataLossInterval*". |
| *allowedParsingExceptions* | int | 10 | Defines the number of parsing exceptions allowed during "*parsingExceptionWindow*" before connection is reset. |
| *parsingExceptionWindow* | double | 5.0 | Defines time duration, in seconds, to monitor parsing exceptions. |
| *delayedConnectionInterval* | double | 1.5 | Defines the delay, in seconds, before connecting or reconnecting to a device. Set to zero for minimum delay (1 millisecond). One to two second delay recommended for new device turn-up. |

**commandChannel connection string parameters** (also includes [transport protocol specific parameters](Getting_Started.md#configure-connection-string))

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *protocol* | TransportProtocol |     | Defines the protocol used by the device to receive commands. The value can be one of Tcp, Serial, or File. |
| *islistener* | bool | false | Indicates whether to use a TCP server or a TCP client for the command channel. |

Example: `isConcentrator=false; accessID=235; timeZone=UTC; timeAdjustmentTicks=10000000; dataLossInterval=20.0; phasorProtocol=Ieee1344; transportProtocol=Udp; commandChannel={protocol=Tcp; islistener=true}`

#### Additional parameters for PhasorMeasurementMapper

**if phasorProtocol=BpaPdcStream**

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *iniFileName* | string |     | The value of this parameter is the path to the INI file which contains settings for the device. |
| *refreshConfigFileOnChange* | bool | true | Determines whether the INI configuration file is automatically reloaded when it has changed on disk. |
| *parseWordCountFromByte* | bool | false | Determines whether to interpret the the word count in the packet header from a byte instead of a word. |

Example: `phasorProtocol=BpaPdcStream; iniFileName=TESTSTREAM.ini; refreshConfigFileOnChange=true; parseWordCountFromByte=true`

**if phasorProtocol=FNet**

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *timeOffset* | long | 110000000 | F-NET devices normally report time in 11 seconds past real-time, this property defines the offset for this this artificial delay. Note that the parameter value is in ticks to allow a very high-resolution offset; 1 second = 10,000,000 ticks. |
| *stationName* | string | F-Net Unit | Defines the station name for the F-Net device. |
| *frameRate* | ushort | 10 | The configured frame rate for the F-Net device. |
| *nominalFrequency* | int | 60 | The nominal line frequency of the F-Net device. The value can be either 50 or 60. |

Example: `phasorProtocol=FNet; timeOffset=50000000; stationName=Poppy; frameRate=15; nominalFrequency=60`

**if phasorProtocol=SelFastMessage**

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *messagePeriod* | MessagePeriod | DefaultRate | The value can be one of DefaultRate (20 messages per second), TwentyPerSecond, TenPerSecond, FivePerSecond, FourPerSecond, TwoPerSecond, OnePerSecond, ThirtyPerMinute, FifteenPerMinute, TwelvePerMinute, TenPerMinute, SixPerMinute, FourPerMinute, ThreePerMinute, TwoPerMinute, or OnePerMinute. |

Example: `phasorProtocol=SelFastMessage; messagePeriod=TwoPerSecond`

**if transportProtocol=File*

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *definedFrameRate* | double | 30.0 | Defines the desired frame rate to use for maintaining captured frame replay timing. |
| *useHighResolutionInputTimer* | bool | true | Defines flag that determines if a high-resolution precision timer should be used for file based input. Useful when input frames need be accurately time-aligned to the local clock to better simulate an input device and calculate downstream latencies. |
| *autoRepeatFile* | bool | true | Defines flag that determines if a file used for replaying data should be restarted at the beginning once it has been completed. |

Example: `transportProtocol=File; file=Sample1344.PmuCapture; definedFrameRate=60; simulateTimestamp=false; autoRepeatFile=false`

## PowerCalculations.AverageFrequency

Connection strings for this adapter also include all the parameters defined for [CalculatedMeasurement](#calculatedmeasurement) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *inputMeasurementKeys* | string |    | All non-frequency measurements will be ignored by this adapter. At least one frequency must be defined in the  inputMeasurementKeys parameter. |
| *outputMeasurements* | string |    | At least three measurements must be defined by this parameter. The first three output measurements represent the average, maximum, and minimum of the input frequencies respectively. Additional output measurements will be ignored. |

Example: `inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'FREQ'}; outputMeasurements={AVERAGE:1; AVERAGE:2; AVERAGE:3}`

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of these parameters.

## PowerCalculations.EventDetection.FrequencyExcursion

Connection strings for this adapter also include all the parameters defined for [CalculatedMeasurement](#calculatedmeasurement) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *inputMeasurementKeys* | string |     |  All non-frequency measurements will be ignored by this adapter. At least one frequency must be defined in the inputMeasurementKeys parameter. Additionally, there must be at least as many input frequencies defined as the value defined for minimumValidChannels. |
| *outputMeasurements* | string |    | At least four measurements must be defined by this parameter. The first four output measurements represent the Warning Signal Status, Frequency Delta, Type of Excursion, and Estimated Size respectively. Additional output measurements will be ignored. |
| *estimateTriggerThreshold* | double | .0256 | Defines the threshold of the estimation trigger. |
| *analysisWindowSize* | int | 4 \* framesPerSecond | Defines the sample size of the analysis window. |
| *analysisInterval* | int | framesPerSecond | Defines the frame interval between two adjacent frequency tests. | 
| *consecutiveDetections* | int | 2 | Defines the number of consecutive excursions to be detected before triggering the alarm. |
| *minimumValidChannels* | int | 3 | Defines the minimum number of valid channels for conducting the frequency tests. |
| *powerEstimateRatio* | double | 19530.0 | Defines the ratio of the total amount of generator (load) trip over the frequency excursion. |
| *minimumAlarmInterval* | int | 20 | Defines the minimum duration between alarms in seconds. |

Example: `inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'FREQ'}; outputMeasurements={EXCURSION:1; EXCURSION:2; EXCURSION:3; EXCURSION:4}; estimateTriggerThreshold=.0256; analysisWindowSize=150; analysisInterval=15; consecutiveDetections=3; minimumValidChannels=5; powerEstimateRatio=19530.0; minimumAlarmInterval=10`

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of these parameters.

## PowerCalculations.EventDetection.LossOfField

Connection strings for this adapter also include all the parameters defined for [CalculatedMeasurement](#calculatedmeasurement) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *inputMeasurementKeys* | string |     | All non-phasor measurements will be ignored by this adapter. At least one each of voltage magnitude, voltage angle, current magnitude, and current angle must be specified as input measurements to this adapter. If more than one of any of these is specified, only the first one will be used. |
| *outputMeasurements* | string |     | At least four measurements must be defined by this parameter. The first four output measurements represent the Warning Signal Status, Real Power, Reactive Power, and Q-Area Value respectively. Additional output measurements will be ignored. |
| *pSet* | double | -600 | This is the pre-set value for MW power-flow from bus A to bus B. Usually the absolute value of pSet is smaller than the absolute value of power-flow in normal condition. |
| *qSet* | double | 200 | This is the pre-set value for MVar flow from bus A to bus B. Usually the absolute value of qSet is larger than the absolute value of Mvar flow in normal condition.
| *qAreaSet* | double | 500| This the pre-set threshold for qArea. qArea is the accumulation of excessive Mvar flow if abs(P) < abs(pSet) and abs(Q) > abs(qSet). (P is the current MW power-flow and Q is the current Mvar flow) |
| *voltageThreshold* | double | 475000 | This is the pre-set voltage threshold for the bus, on which the loss-of-field is monitored. |
| *analysisInterval* | int | framesPerSecond | Defines the frame interval between two adjacent phasor tests. |

Example: `inputMeasurementKeys={DEVARCHIVE:5; DEVARCHIVE:6; DEVARCHIVE:9; DEVARCHIVE:10}; outputMeasurements={LOF:1; LOF:2; LOF:3; LOF:4}; pSet=-500; qSet=300; qAreaSet=600; voltageThreshold=475000; analysisInterval=15`

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of these parameters.

## PowerCalculations.PowerStability

Connection strings for this adapter also include all the parameters defined for [CalculatedMeasurement](#calculatedmeasurement) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *inputMeasurementKeys* | string |     | All non-phasor measurements will be ignored by this adapter. At least one each of voltage magnitude, voltage angle, current magnitude, and current angle must be specified as input measurements to this adapter. Additionally, the number of voltage angles must match the number of voltage magnitudes and the number of current magnitudes must match the number of current angles. The definition order of angles and magnitudes must match so that the angle/magnitude pairs can be matched up appropriately. |
| *outputMeasurements* | string |     | At least two measurements must be defined by this parameter. The first two output measurements represent the Calculated Power and the Standard Deviation of Power respectively. Additional output measurements will be ignored. |
| *sampleSize* | int | 15 | Defines the data sample size to monitor in seconds. |
| *energizedThreshold* | double | 58000.0 | Defines the energized bus threshold in volts. The recommended value is 20% of the nominal line-to-neutral voltage. |

Example: `inputMeasurementKeys={DEVARCHIVE:6; DEVARCHIVE:5; DEVARCHIVE:8; DEVARCHIVE:7; DEVARCHIVE:10; DEVARCHIVE:9; DEVARCHIVE:12; DEVARCHIVE:11; DEVARCHIVE:14; DEVARCHIVE:13}; outputMeasurements={POWER:1; POWER:2}; sampleSize=20; energizedThreshold=58000.0`

*Note: Ordering by PhasorID allows angle and magnitude measurements to be sorted together so they can be identified as a pair.*

Example2: `inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType LIKE '*PH*' AND Device = 'SHELBY' ORDER BY PhasorID}; outputMeasurements={POWER:1; POWER:2}; sampleSize=20; energizedThreshold=58000.0`

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of these parameters.

## PowerCalculations.ReferenceAngle

Connection strings for this adapter also include all the parameters defined for [CalculatedMeasurement](#calculatedmeasurement) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *inputMeasurementKeys* | string |    | All non-phase angle measurements will be ignored by this adapter. At least one phase angle must be specified as an input measurement to this adapter. Additionally, phase types must not be mixed; only voltage angles or only current angles should be specified. |
| *outputMeasurements* | string |    | At least one measurement must be defined by this parameter. The first measurement represents the Calculated Reference Angle value. Additional output measurements will be ignored. |

Example: `inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'IPHA'}; outputMeasurements={REF_IPHA:1}`

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of these parameters.

## PowerCalculations.ReferenceMagnitude

Connection strings for this adapter also include all the parameters defined for [CalculatedMeasurement](#calculatedmeasurement) and [ActionAdapterBase](#actionadapterbase).

| Key | Value | Default | Description |
| --- | ----- | ------- | ----------- |
| *inputMeasurementKeys* | string |     | All non-phase magnitude measurements will be ignored by this adapter. At least one phase magnitude must be specified as an input measurement to this adapter. Additionally, phase types must not be mixed; only voltage magnitudes or only voltage angles should be specified. |
| *outputMeasurements* | string |    | At least one measurement must be defined by this parameter. The first measurement represents the Calculated Reference Magnitude value. Additional output measurements will be ignored. |

Example: `inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'IPHM'}; outputMeasurements={REF_IPHM:1}`

See [Syntax for inputMeasurementKeys and outputMeasurements](#input-and-output-syntax) for help with the syntax of these parameters.

## Syntax for inputMeasurementKeys and outputMeasurements

The syntax for inputMeasurementKeys and outputMeasurements is either:

- *Filter syntax*: `FILTER <TableName> WHERE <Expression> [ORDER BY <SortField>]`
- *-or-*
- *Field syntax*: `<Source>:<ID>[,<Adder>,<Multiplier>];`

The syntax for both the input and output parameters is identical except that outputMeasurements allows the defintion of an adder and a multiplier using the field syntax whereas inputMeasurementKeys does not. In the following examples, the acronym of the historian archiving the measurements is called DEVARCHIVE.

1. `inputMeasurementKeys={DEVARCHIVE:1;DEVARCHIVE:2;DEVARCHIVE:5;DEVARCHIVE:12}`
2. `outputMeasurements={SOURCENAME:6,5,9;SOURCENAME:18,59.5,0.1;SOURCENAME:20}`
3. `inputMeasurementKeys={FILTER ActiveMeasurements WHERE Device = 'SHELBY' AND SignalType = 'VPHM'}`
4. `inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType LIKE '*PH*' AND Device = 'SHELBY' ORDER BY PhasorID}`

In example 1, we define four input measurements corresponding to the measurement keys `DEVARCHIVE:1`, `DEVARCHIVE:2`, `DEVARCHIVE:5`, and `DEVARCHIVE:12`. The `IsInputMeasurement(MeasurementKey)` method will only return true if the `MeasurementKey` argument matches one of those four keys. Had we used `outputMeasurements` instead of `inputMeasurementKeys`, it would have created four measurements with the default adder and multiplier, 0 and 1 respectively.

Example 2 syntax only applies to the `outputMeasurements` parameter and defines the adder and multiplier of the measurements in addition to the measurement key. In this example, we define three output measurements with the following keys: `SOURCENAME:6`, `SOURCENAME:18`, and `SOURCENAME:20`. The adder for each is 5, 59.5, and 0 respectively. The multiplier for each is 9, 0.1, and 1 respectively.

In example 3, we use a statement with SQL-like syntax in order to determine which measurements are defined as the input measurements. The ConfigurationEntity table defines the table names you can use in place of "ActiveMeasurements". `ConfigurationEntity.SourceName` defines the name of the table or view in the database and
`ConfigurationEntity.RuntimeName` defines the name used in place of "ActiveMeasurements". When using the inputMeasurementKeys parameter, the system uses only the "ID" column of the given table or view in order to determine the MeasurementKey of each of the input measurements. When using the outputMeasurements parameter, the system uses the "ID", "PointTag", "Adder", and "Multiplier" columns to create the output measurements.

In example 4, we apply a "LIKE" expression to get any signal type that has "PH" as the middle two letters (i.e., IPHM, VPHM, IPHA or VPHA -or- current phasor magnitude, voltage phasor magnitude, current phasor angle or voltage phasor angle respectively). Additonally we apply an "ORDER BY" expression so that the selected results are ordered by their unique phasor ID, by doing this all magnitude and phase angles associated with the same phasor will be sorted side-by-side allowing the consumer to automatically know which angle and magnitude vector component pairs go together simply by their ordered grouping.

Click [here](http://www.csharp-examples.net/dataview-rowfilter/) for more help on proper and allowed syntax for expressions.

## Typical Time Zones

| ID | Display Name | 
| --- | ------------ |
| UTC | Universal Coordinated Time (GMT without daylight savings adjustments) |
| GMT Standard Time | (GMT) Greenwich Mean Time : Dublin, Edinburgh, Lisbon, London |
| Greenwich Standard Time | (GMT) Casablanca, Monrovia, Reykjavik< |
| W. Europe Standard Time | (GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna |
| Central Europe Standard Time | (GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague |
| Romance Standard Time | (GMT+01:00) Brussels, Copenhagen, Madrid, Paris |
| Central European Standard Time | (GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb |
| W. Central Africa Standard Time | (GMT+01:00) West Central Africa |
| Jordan Standard Time | (GMT+02:00) Amman |
| GTB Standard Time | (GMT+02:00) Athens, Bucharest, Istanbul |
| Middle East Standard Time | (GMT+02:00) Beirut |
| Egypt Standard Time | (GMT+02:00) Cairo |
| South Africa Standard Time | (GMT+02:00) Harare, Pretoria |
| FLE Standard Time | (GMT+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius |
| Israel Standard Time | (GMT+02:00) Jerusalem |
| E. Europe Standard Time | (GMT+02:00) Minsk |
| Namibia Standard Time | (GMT+02:00) Windhoek |
| Arabic Standard Time | (GMT+03:00) Baghdad |
| Arab Standard Time | (GMT+03:00) Kuwait, Riyadh |
| Russian Standard Time | (GMT+03:00) Moscow, St. Petersburg, Volgograd |
| E. Africa Standard Time | (GMT+03:00) Nairobi |
| Georgian Standard Time | (GMT+03:00) Tbilisi |
| Iran Standard Time | (GMT+03:30) Tehran |
| Arabian Standard Time | (GMT+04:00) Abu Dhabi, Muscat |
| Azerbaijan Standard Time | (GMT+04:00) Baku |
| Caucasus Standard Time | (GMT+04:00) Caucasus Standard Time |
| Armenian Standard Time | (GMT+04:00) Yerevan |
| Afghanistan Standard Time | (GMT+04:30) Kabul |
| Ekaterinburg Standard Time | (GMT+05:00) Ekaterinburg | 
| West Asia Standard Time | (GMT+05:00) Islamabad, Karachi, Tashkent |
| India Standard Time | (GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi |
| Sri Lanka Standard Time | (GMT+05:30) Sri Jayawardenepura |
| Nepal Standard Time | (GMT+05:45) Kathmandu |
| N. Central Asia Standard Time | (GMT+06:00) Almaty, Novosibirsk |
| Central Asia Standard Time | (GMT+06:00) Astana, Dhaka |
| Myanmar Standard Time | (GMT+06:30) Yangon (Rangoon) |
| SE Asia Standard Time | (GMT+07:00) Bangkok, Hanoi, Jakarta |
| North Asia Standard Time | (GMT+07:00) Krasnoyarsk |
| China Standard Time | (GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi |
| North Asia East Standard Time | (GMT+08:00) Irkutsk, Ulaan Bataar |
| Singapore Standard Time | (GMT+08:00) Kuala Lumpur, Singapore |
| W. Australia Standard Time | (GMT+08:00) Perth |
| Taipei Standard Time | (GMT+08:00) Taipei |
| Tokyo Standard Time | (GMT+09:00) Osaka, Sapporo, Tokyo |
| Korea Standard Time | (GMT+09:00) Seoul |
| Yakutsk Standard Time | (GMT+09:00) Yakutsk |
| Cen. Australia Standard Time | (GMT+09:30) Adelaide |
| AUS Central Standard Time | (GMT+09:30) Darwin |
| E. Australia Standard Time | (GMT+10:00) Brisbane |
| AUS Eastern Standard Time | (GMT+10:00) Canberra, Melbourne, Sydney |
| West Pacific Standard Time | (GMT+10:00) Guam, Port Moresby |
| Tasmania Standard Time | (GMT+10:00) Hobart | 
| Vladivostok Standard Time | (GMT+10:00) Vladivostok |
| Central Pacific Standard Time | (GMT+11:00) Magadan, Solomon Is., New Caledonia |
| New Zealand Standard Time | (GMT+12:00) Auckland, Wellington |
| Fiji Standard Time | (GMT+12:00) Fiji, Kamchatka, Marshall Is. |
| Tonga Standard Time + (GMT+13:00) Nuku'alofa |
| Azores Standard Time | (GMT-01:00) Azores |
| Cape Verde Standard Time | (GMT-01:00) Cape Verde Is. |
| Mid-Atlantic Standard Time | (GMT-02:00) Mid-Atlantic |
| E. South America Standard Time | (GMT-03:00) Brasilia |
| SA Eastern Standard Time |(GMT-03:00) Buenos Aires, Georgetown |
| Greenland Standard Time | (GMT-03:00) Greenland |
| Montevideo Standard Time | (GMT-03:00) Montevideo |
| Newfoundland Standard Time | (GMT-03:30) Newfoundland |
| Atlantic Standard Time | (GMT-04:00) Atlantic Time (Canada) |
| SA Western Standard Time | (GMT-04:00) La Paz |
| Central Brazilian Standard Time | (GMT-04:00) Manaus |
| Pacific SA Standard Time | (GMT-04:00) Santiago |
| Venezuela Standard Time | (GMT-04:30) Caracas |
| SA Pacific Standard Time | (GMT-05:00) Bogota, Lima, Quito, Rio Branco |
| Eastern Standard Time | (GMT-05:00) Eastern Time (US & Canada) |
| US Eastern Standard Time | (GMT-05:00) Indiana (East) |
| Central America Standard Time | (GMT-06:00) Central America |
| Central Standard Time | (GMT-06:00) Central Time (US & Canada) |
| Central Standard Time (Mexico) | (GMT-06:00) Guadalajara, Mexico City, Monterrey - New |
| Mexico Standard Time | (GMT-06:00) Guadalajara, Mexico City, Monterrey - Old |
| Canada Central Standard Time | (GMT-06:00) Saskatchewan |
| US Mountain Standard Time |(GMT-07:00) Arizona |
| Mountain Standard Time (Mexico) | (GMT-07:00) Chihuahua, La Paz, Mazatlan - New |
| Mexico Standard Time | (GMT-07:00) Chihuahua, La Paz, Mazatlan - Old |
| Mountain Standard Time | (GMT-07:00) Mountain Time (US & Canada) |
| Pacific Standard Time | (GMT-08:00) Pacific Time (US & Canada) |
| Pacific Standard Time (Mexico) | (GMT-08:00) Tijuana, Baja California |
| Alaskan Standard Time | (GMT-09:00) Alaska |
| Hawaiian Standard Time | (GMT-10:00) Hawaii |
| Samoa Standard Time | (GMT-11:00) Midway Island, Samoa |
| Dateline Standard Time | (GMT-12:00) International Date Line West |

---

Jul 24, 2013 at 7:48:27 PM Last edited by [kevinjones](Contributors/kevinjones.md), version 112  
Oct 4, 2015 Migrated from [CodePlex](https://openpdc.codeplex.com/wikipage?title=Connection%20Strings) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
