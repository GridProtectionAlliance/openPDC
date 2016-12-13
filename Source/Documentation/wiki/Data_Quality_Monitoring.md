[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Data Quality Monitoring Adapters

The data quality monitoring adapters are available in the DataQualityMonitoring project of the Synchrophasor solution. There are three adapters available for monitoring the quality of your data. The flatline test detects when the values of each measurement  changes in order to determine whether these measurements are continuously reporting the same values. The range test checks the values of incoming measurements to determine whether they fall outside a valid range of values. The timestamp test checks the timestamps of the measurements to determine whether they arrived within the lag and lead time constraints defined for the system. This document is intended to aid in the use of these three tests in common openPDC setups.

- [Flatline Test](#flatline-test)
    - [Configuring the Flatline Test](#configuring-the-flateline-test)
        - [Flatline Connection String Examples](#flatline-connection-string-examples)
    - [Configuring the Flatline Test's Web Service](#configuring-the-flatline-tests-web-service)
    - [Using the Flatline Test's Web Service](#using-the-flatline-tests-web-service)
- [Range Test](#range-test)
    - [Configuring the Range Test](#configuring-the-range-test)
        - [Range Test Connection String Examples](#range-test-connection-string-examples)
    - [Configuring the Range Test's Web Service](#configuring-the-range-tests-web-service)
    - [Using the Range Test's Web Service](#using-the-range-tests-web-service)
- [Timestamp Test](#timestamp-test)
    - [Configuring the Timestamp Test](#configuring-the-timestamp-test)
        - [Timestamp Test Connection String Examples](#timestamp-test-connection-string-examples)
    - [Configuring the Timestamp Test's Web Service](#configuring-the-timestamp-tests-web-service)
    - [Using the Timestamp Test's Web Service](#using-the-timestamp-tests-web-service)

---

## Flatline Test

The flatline test is located in the aptly named `FlatlineTest.cs` file. This test is used to determine whether incoming measurements have been reporting the same value for an unusually long period of time. When running the test, there are two ways to determine whether a measurement has flatlined. The first is to read the openPDC Console as the test is designed to periodically send warning messages about flatlined measurements. The second is to query the web service hosted by the adapter. The following subsections will describe how to configure the adapter, configure the web service, and use the web service.

### Configuring the Flatline Test

The flatline test is an action adapter and should therefore be entered into the CustomActionAdapter table in the openPDC database. There are eight columns in the CustomActionAdapter table which should be entered as follows.<br>

| Column | Value |
| ------ | ----- |
| NodeID | [Node.ID](Manual_Configuration.md#the-nodeid-column-2) |
| ID | *default value* |
| AdapterName | [Acronym](Manual_Configuration.md#the-acronym-column-2) |
| AssemblyName | DataQualityMonitoring.dll |
| TypeName | DataQualityMonitoring.FlatlineTest |
| ConnectionString | See [examples](#flatline-connection-string-examples) and  [syntax](Connection_Strings.md#dataqualitymonitoringflatlinetest). |
| LoadOrder | *an integer* | 
| Enabled | true |

#### Flatline Connection String Examples

- Required parameters are `lagTime`, `leadTime`, and `framesPerSecond`.
- It is highly recommended to use the `inputMeasurementKeys` parameter.
- Other optional parameters include `minFlatline` and `warnInterval`.
- See [adapter connection string syntax](Connection_Strings.md#dataqualitymonitoringflatlinetest) for more information.

This configuration receives all measurements defined in the ActiveMeasurement view. It posts warnings to the console at four second intervals if any measurements have been continuously reporting the same value for at least four seconds.

`lagTime=3; leadTime=1; framesPerSecond=30; inputMeasurementKeys={FILTER ActiveMeasurements WHERE ID LIKE '*'}`

This configuration receives all frequencies and phasor measurements defined in the ActiveMeasurement view. It posts warnings to the console at 10 second intervals if any measurements have been continuously reporting the same value for at least one second.

`lagTime=3; leadTime=1; framesPerSecond=30; inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'FREQ' OR SignalType LIKE '*PH*'}; minFlatline=1; warnInterval=10`

### Configuring the Flatline Test's Web Service

After configuring the flatline test, running the openPDC once will populate the configuration file (openPDC.exe.config) with the settings you need in order to configure the flatline service. These settings will be stored in the section labeled `<aDAPTER_NAMEFlatlineService>` (where `aDAPTER_NAME` is the name of your adapter with the first letter lowercase). There are only two settings that you may wish to modify.

`Enabled` - By default, the value is `false`. By setting the value to `true`, you allow the web service to listen for requests on the specified port. Leaving it false will disable the web service and you will not be able to query for flatlined measurements.

`ServiceUri` - By default, the web service will listen on port 6100. If you define more than one flatline test in your system configuration or if port 6100 is already taken by another process, you will need to change the port in the ServiceUri to a port that is not in use.

Note: It is recommended to use only a single flatline test per node and filter all the measurements that need to be tested to that one test. If configured this way, you most likely will not need to modify `ServiceUri`.

### Using the Flatline Test's Web Service

By default, the service can be accessed at the http://localhost:6100/flatlinetest URL. You can view the data in the following ways.

- `http://localhost:6100/flatlinetest/flatlinedmeasurements/read/[xml|json]`
    - Returns all currently flatlined measurements.

- `http://localhost:6100/flatlinetest/flatlinedmeasurements/read/<device acronym>/[xml|json]`
    - Returns all currently flatlined measurements belonging to a particular device.

---

### Range Test

When creating the range test, we used the same rationale for naming as we did when creating the flatline test so we decided to place it in the `RangeTest.cs` file. This test is used to find when measurements fall outside of a specified range of values. As with the flatline test, there are two ways to determine whether a measurement has fallen outside the specified range. The first is to read the openPDC Console as the test is designed to periodically send warning messages about out of range measurements. The second is to query the web service hosted by the adapter. The following subsections will describe how to configure the adapter, configure the web service, and use the web service.

### Configuring the Range Test

The range test is an action adapter and should therefore be entered into the CustomActionAdapter table in the openPDC database. There are eight columns in the CustomActionAdapter table which should be entered as follows.

| Column | Value |
| ------ | ----- |
| NodeID | [Node.ID](Manual_Configuration.md#the-nodeid-column-2) |
| ID |*default value* |
| AdapterName | [Acronym](Manual_Configuration.md#the-acronym-column-2) |
| AssemblyName | DataQualityMonitoring.dll |
| TypeName | DataQualityMonitoring.RangeTest |
| ConnectionString | See [examples](#range-test-connection-string-examples) and [syntax](Connection_Strings.md#dataqualitymonitoringrangetest). |
| LoadOrder | *an integer* |
| Enabled | true |

#### Range Test Connection String Examples

- Required parameters are `lagTime`, `leadTime`, and `framesPerSecond`.
- One or the other of either `signalType` or `lowRange` and `highRange` are also required. (`signalType` takes precedence over `lowRange` and `highRange`.)
- It is highly recommended to use the `inputMeasurementKeys` parameter.
- Other optional parameters include `timeToPurge` and `warnInterval`. 
- See [adapter connection string syntax](Connection_Strings.md#dataqualitymonitoringrangetest) for more information.

This configuration receives all phasor angles defined in the ActiveMeasurement view. It posts warnings to the console at 4 second intervals if any measurements have fallen outside the range of -180 to 180 within the last 1 second.

`lagTime=3; leadTime=1; framesPerSecond=30; inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType LIKE '*PHA'}; lowRange=-180; highRange=180`

This configuration receives all frequencies defined in the ActiveMeasurement view. It posts warnings to the console at 10 second intervals if any measurements have fallen outside the [default frequency range](Connection_Strings.md#dataqualitymonitoringrangetest) within the last 2 seconds.

`lagTime=3; leadTime=1; framesPerSecond=30; inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'FREQ'}; signalType=FREQ; timeToPurge=2; warnInterval=10`

### Configuring the Range Test's Web Sservice

After configuring the range test, running the openPDC once will populate the configuration file (openPDC.exe.config) with the settings you need in order to configure the range test's service. These settings will be stored in the section labeled `<outOfRangeService>`. There are only two settings that you may wish to modify.

`Enabled` - By default, the value is `false`. By setting the value to `true`, you allow the web service to listen for requests on the specified port. Leaving it false will disable the web service and you will not be able to query for out of range measurements.

`ServiceUri` - By default, the web service will listen on port 6101. If port 6101 is already taken by another process, you will need to change the port in the ServiceUri to a port that is not in use.

Note: Unlike the flatline test, you will need to create multiple instances of the range test in order to test different types of measurements. As a result, the web service is designed to include all range tests defined for the system. There will only be one  service regardless of the number of tests. As a result, it is not necessary to change any ports if you have defined multiple range tests.

### Using the Range Test's Web Service

By default, the service can be accessed at the `http://localhost:6101/rangetest` URL. You can view the data in the following ways.

- `http://localhost:6101/rangetest/outofrangemeasurements/read/[xml|json]`
    - Returns all measurements that are currently out of range.

- `http://localhost:6101/rangetest/outofrangemeasurements/read/signaltype:<signal type acronym>/[xml|json]`
    - Returns all measurements that are currently out of range with the given signal type.

- `http://localhost:6101/rangetest/outofrangemeasurements/read/device:Mdevice acronym>/[xml|json]`
    - Returns all measurements that are currently out of range belonging to a particular device.

- `http://localhost:6101/rangetest/outofrangemeasurements/read/test:<range test acronym>/[xml|json]`
    - Returns all measurements that are being tested by a specific range test and are currently out of range.

---

## Timestamp Test

The timestamp test is located in the `TimestampTest.cs` file. This test is used to find when measurements arrive to the system with bad timestamps. As with the the other tests, there are two ways to determine whether a measurement has arrived with a bad timestamp. The first is to read the openPDC Console as the test is designed to periodically send warning messages about measurements with bad timestamps. The second is to query the web service hosted by the adapter. The following subsections will describe how to configure the adapter, configure the web service, and use the web service.

### Configuring the Timestamp Test

The timestamp test is an action adapter and should therefore be entered into the CustomActionAdapter table in the openPDC database. There are eight columns in the CustomActionAdapter table which should be entered as follows.

| Column | Value |
| ------ | ----- |
| NodeID | [Node.ID](Manual_Configuration.md#the-nodeid-column-2) |
| ID |*default value* |
| AdapterName | [Acronym](Manual_Configuration.md#the-acronym-column-2) |
| AssemblyName | DataQualityMonitoring.dll |
| TypeName | DataQualityMonitoring.TimestampTest |
| ConnectionString | See [examples](#timestamp-test-connection-string-examples) and [syntax](Connection_Strings.md#dataqualitymonitoringtimestamptest). |
| LoadOrder | *an integer* |
| Enabled | true |

#### Timestamp Test Connection String Examples

- Only one required parameter, `concentratorName`.
- Other optional parameters include `timeToPurge` and `warnInterval`.
- The `concentratorName` parameter is the name or acronym of another action adapter that makes use of its `DiscardingMeasurements` event (`ActionAdapterBase` makes use of this event).
- See [adapter connection string syntax](Connection_Strings.md#dataqualitymonitoringtimestamptest) for more information.

This configuration receives all measurements that arrived with bad timestamps to the TESTSTREAM adapter. It posts warnings to the console at 4 second intervals if any measurements have arrived with bad timestamps within the last 1 second.

`concentratorName=TESTSTREAM`

This configuration receives all measurements that arrived with bad timestamps to the TESTSTREAM adapter. It posts warnings to the console at 10 second intervals if any measurements have arrived with bad timestamps within the last 2 seconds.

`concentratorname=TESTSTREAM; timeToPurge=2; warnInterval=10`

### Configuring the Timestamp Test's Web Service

After configuring the timestamp test, running the openPDC once will populate the configuration file `openPDC.exe.config` with the settings you need in order to configure the timestamp test's service. These settings will be stored in the section labeled `<aDAPTER_NAMETimestampService>` (where `aDAPTER_NAME` is the name of your adapter with the first letter lowercase). There are only two settings that you may wish to modify.

`Enabled` - By default, the value is `false`. By setting the value to `true`, you allow the web service to listen for requests on the specified port. Leaving it false will disable the web service and you will not be able to query for out of range measurements.

`ServiceUri` - By default, the web service will listen on port 6102. If you define more than one timestamp test in your system configuration or if port 6102 is already taken by another process, you will need to change the port in the ServiceUri to a port that is not in use.

### Using the Timestamp Test's Web Service

By default, the service can be accessed at the http://localhost:6102/timestamptest URL. You can view the data in the following ways.

- `http://localhost:6102/timestamptest/badtimestampmeasurements/read/[xml|json]`
    - Returns all measurements that have recently arrived with bad timestamps.

- `http://localhost:6102/timestamptest/badtimestampmeasurements/read/<device acronym>/[xml|json]`
    - Returns all measurements from the specified device that have recently arrived with bad timestamps.

---

Apr 29, 2010 4:11:27 PM Last Edit by [staphen](http://www.codeplex.com/site/users/view/staphen), version 13  
Oct 4, 2015 Migrated from [CodePlex](https://openpdc.codeplex.com/wikipage?title=Data%20Quality%20Monitoring) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)