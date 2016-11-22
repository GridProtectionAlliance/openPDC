[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md)

|   |   |   |   |
|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC)** | **[openPDC Wiki Home](openPDC_Home.md)** | **[Documentation](openPDC_Documentation_Home.md)** |

# Configuration File Settings

This document contains a list of settings that are saved in the configuration files used by the openPDC applications. Keep in mind that most category names can be changed and, in fact, are often changed. A settings category you see in your configuration file may go by a different name by default.

##### Navigate by configuration file

- openPDC.exe.Config
    - [devarchiveAdoMetadataProvider](#adometadataprovider)
    - [devarchiveArchiveFile](#archivefile)
    - [devarchiveIntercomFile](#isamdatafilebase)
    - [devarchiveMetadataFile](#isamdatafilebase)
    - [devarchiveMetadataService](#restservice)
    - [devarchiveOleDbMetadataProvider](#oledbmetadataprovider)
    - [devarchiveRestWebServiceMetadataProvider](#restwebservicemetadataprovider)
    - [devarchiveStateFile](#isamdatafilebase)
    - [devarchiveTimeSeriesDataService](#restservice)
    - [errorLog](#logfile)
    - [errorLogger](#errorlogger)
    - [exampleSettings](#servicehost-examplesettings)
    - [healthExporter](#multipledestinationexporter)
    - [systemSettings](#servicehost-systemsettings)
    - [serviceHelper](#servicehelper)
    - [processScheduler](#schedulemanager)
    - [remotingServer](#tcpserver)
    - [statAdoMetadataProvider](#adometadataprovider)
    - [statArchiveFile](#archivefile)
    - [statIntercomFile](#isamdatafilebase)
    - [statMetadataFile](#isamdatafilebase)
    - [statMetadataService](#restservice)
    - [statOleDbMetadataProvider](#oledbmetadataprovider)
    - [statRestWebServiceMetadataProvider](#restwebservicemetadataprovider)
    - [statStateFile](#isamdatafilebase)
    - [statTimeSeriesDataService](#restservice)
    - [statusExporter](#multipledestinationexporter)
    - [statusLog](#logfile)
    - [thresholdSettings](#servicehost-thresholdsettings)
    
##### Navigate by class

- [AdoMetadataProvider](#adometadataprovider)
- [ArchiveFile](#archivefile)
- [ErrorLogger](#errorlogger)
- [IsamDataFileBase](#isamdatafilebase)
- [LogFile](#logfile)
- [MetadataProviderBase](#metadataproviderbase)
- [MultipleDestinationExporter](#multipledestinationexporter)
- [OleDbMetadataProvider](#oledbmetadataprovider)
- [RestService](#restservice)
- [RestWebServiceMetadataProvider](#restwebservicemetadataprovider)
- [ScheduleManager](#schedulemanager)
- [ServerBase](#serverbase)
- [ServiceHelper](#servicehelper)
- [ServiceHost](#servicehost)
    - [exampleSettings category](#servicehost-examplesettings)
    - [systemSettings category](#servicehost-systemsettings)
    - [thresholdSettings category](#servicehost-thresholdsettings)
- [TcpServer](#tcpserver)

##### Navigate by adapter

- [DataQualityMonitoring.FlatlineTest](#restservice) (aDAPTER_NAMEFlatlineService)
- [DataQualityMonitoring.RangeTest](#restservice) (outOfRangeService)
- [DataQualityMonitoring.TimestampTest](#restservice) (aDAPTER_NAMETimestampService)
- [HistorianAdapters.LocalOutputAdapter](#adometadataprovider) (adapter_nameAdoMetadataProvider)
- [HistorianAdapters.LocalOutputAdapter](#archivefile) (adapter_nameArchiveFile)
- [HistorianAdapters.LocalOutputAdapter](#isamdatafilebase) (adapter_nameIntercomFile)
- [HistorianAdapters.LocalOutputAdapter](#isamdatafilebase) (adapter_nameMetadataFile)
- [HistorianAdapters.LocalOutputAdapter](#restservice) (adapter_nameMetadataService)
- [HistorianAdapters.LocalOutputAdapter](#oledbmetadataprovider) (adapter_nameOleDbMetadataProvider)
- [HistorianAdapters.LocalOutputAdapter](#restwebservicemetadataprovider) (adapter_nameRestWebServiceMetadataProvider)
- [HistorianAdapters.LocalOutputAdapter](#isamdatafilebase) (adapter_nameStateFile)
- [HistorianAdapters.LocalOutputAdapter](#restservice) (adapter_nameTimeSeriesDataService)

---

## AdoMetadataProvider

**Default category**

`AdoMetadataProvider`

**Settings*

This section also includes settings from [MetadataProviderBase](#metadataproviderbase).

| Name | Default Value | Description | 
| ---- | ------------- | ----------- |
| ConnectionString   |      | Connection string for connecting to the ADO.NET based data store of metadata. |
| DataProviderString |      | The ADO.NET data provider assembly type creation string used to create a connection to the data store of metadata. |
| SelectString       |      | SELECT statement for retrieving metadata from the ADO.NET based data store. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| HistorianAdapters.LocalOutputAdapter | adapter_nameAdoMetadataProvider | SelectString | `SELECT * FROM HistorianMetadata WHERE PlantCode = 'DEVARCHIVE'` |
| HistorianAdapters.LocalOutputAdapter | adapter_nameAdoMetadataProvider | ConnectionString | *same as in [systemSettings](#servicehost-systemsettings)* |
| HistorianAdapters.LocalOutputAdapter | adapter_nameAdoMetadataProvider | DataProviderString |*same as in [systemSettings](#servicehost-systemsettings)* |

---

## ArchiveFile

**Default category**

`archiveFile`

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| FileName | ArchiveFile.d | Name of the file including its path. |
| FileType | Active | Type (Active; Standby; Historic) of the file. |
| FileSize | 1500 | Size (in MB) of the file. |
| DataBlockSize | 8 | Size (in KB of the data blocks in the file. |
| RolloverPreparationThreshold | 75 | Percentage file full when the rollover preparation should begin. |
| ArchiveOffloadLocation |   | Path to the location where historic files are to be moved when disk start getting full. |
| ArchiveOffloadCount | 5 | Number of files that are to be moved to the offload location when the disk starts getting full. |
| ArchiveOffloadThreshold | 90 | Percentage disk full when the historic files should be moved to the offload location. |
| MaxHistoricArchiveFiles | -1 | Maximum number of historic files to be kept at both the primary and offload locations combined. |
| LeadTimeTolerance | 15 | Number of minutes by which incoming data points can be ahead of local system clock and still be considered valid. |
| CompressData | True | True if compression is to be performed on the incoming data points; otherwise False. |
| DiscardOutOfSequenceData | True | True if out-of-sequence data points are to be discarded; otherwise False. |
| CacheWrites | False | True if writes are to be cached for performance; otherwise False. |
| ConserveMemory | True | True if attempts are to be made to conserve memory; otherwise False. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| DataOperation (Optimize Local Historian Settings) | adapter_nameArchiveFile | CacheWrites | True |
| DataOperation (Optimize Local Historian Settings) | adapter_nameArchiveFile | ConserveMemory | False |
| HistorianAdapters.LocalOutputAdapter | adapter_nameArchiveFile | FileName | `workingdir\adapter_name_archive.d` |
| HistorianAdapters.LocalOutputAdapter | adapter_nameArchiveFile | FileSize | 100 |
| HistorianAdapters.LocalOutputAdapter | adapter_nameArchiveFile | CompressData | False |

---

## ErrorLogger

**Default category**

`errorLogger`

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| LogToUI | False | True if an encountered exception is to be logged to the User Interface; otherwise False. |
| LogToFile | True | True if an encountered exception is to be logged to a file; otherwise False. |
| LogToEmail | False | True if an email is to be sent to ContactEmail with the details of an encountered exception; otherwise False. |
| LogToEventLog | True | True if an encountered exception is to be logged to the Event Log; otherwise False. |
| LogToScreenshot | False | True if a screenshot is to be taken when an exception is encountered; otherwise False. |
| LogUserInfo | False | True if user information is to be logged along with exception information; otherwise False. |
| SmtpServer | localhost | Name of the SMTP server to be used for sending the email messages. |
| ContactName |    | Name of the person that the end-user can contact when an exception is encountered. |
| ContactEmail |   | Comma-separated list of recipient email addresses for the email message. |
| ContactPhone |   | Phone number of the person that the end-user can contact when an exception is encountered. |
| HandleUnhandledException | True | True if unhandled exceptions are to be handled automatically; otherwise False. |
| ExitOnUnhandledException | False | True if the application must exit when an unhandled exception is encountered; otherwise False. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| openPDC.ServiceHost | errorLogger | LogToEventLog | False |
| openPDC.ServiceHost | errorLogger | SmtpServer |    |

---

## IsamDataFileBase

**Default category**

`isamDataFile`

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| FileName | IsamDataFile.dat | Name of the file including its path. |
| FileAccessMode | ReadWrite | Access mode (Read; Write; ReadWrite) to be used when opening the file. |
| AutoSaveInterval | -1 | Interval in milliseconds at which the file records loaded in memory are to be saved automatically to disk. Use -1 to disable automatic saving. |
| LoadOnOpen | False | True if file records are to be loaded in memory when opened; otherwise False. |
| SaveOnClose | False | True if file records loaded in memory are to be saved to disk when file is closed; otherwise False. |
| ReloadOnModify | False | True if file records loaded in memory are to be re-loaded when file is modified on disk; otherwise False. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| DataOperation (Optimize Local Historian Settings) | adapter_nameMetadataFile, adapter_nameStateFile, adapter_nameIntercomFile | LoadOnOpen | True |
| DataOperation (Optimize Local Historian Settings) | adapter_nameMetadataFile, adapter_nameStateFile, adapter_nameIntercomFile | ReloadOnModify | True |
| HistorianAdapters.LocalOutputAdapter | adapter_nameMetadataFile | FileName | `workingdir\adapter_name_dbase.dat` |
| HistorianAdapters.LocalOutputAdapter | adapter_nameStateFile | FileName | `workingdir\adapter_name_startup.dat` |
| HistorianAdapters.LocalOutputAdapter | adapter_nameIntercomFile | FileName | `workingdir\scratch.dat` |

---

## LogFile

**Default category**

`logFile`

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| FileName | LogFile.txt | Name of the log file including its path. |
| FileSize | 3 | Maximum size of the log file in MB. |
| FileFullOperation | Truncate | Operation(Truncate; Rollover) that is to be performed on the file when it is full. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| TVA.ErrorManagement.ErrorLogger | errorLog | FileName | [installation directory](Getting_Started.md#installation-directory)\ErrorLog.txt |
| openPDC.ServiceHost | statusLog | FileName | [installation directory](Getting_Started.md#installation-directory)\StatusLog.txt |

---

## MetadataProviderBase

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| Enabled | False | True if this metadata provider is enabled; otherwise False. |
| RefreshTimeout | 60 | Number of seconds to wait for metadata refresh to complete. |
| RefreshInterval | -1 | Interval in minutes at which the metadata is to be refreshed. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- | 
| HistorianAdapters.LocalOutputAdapter | adapter_nameAdoMetadataProvider | Enabled | True |

---

## MultipleDestinationExporter

**Default category**

`ExportDestinations`

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| ExportTimeout | -1 | Total allowed time for all exports to execute in milliseconds. |
| ExportCount | 1 | Total number of export files to produce. |
| ExportDestination1 | `C:\` | Root path for export destination. Use UNC path (`\\server\share`) with no trailing slash for network shares. |
| ExportDestination1.ConnectToShare | False | Set to True to attempt authentication to network share. |
| ExportDestination1.Domain | domain | Domain used for authentication to network share (computer name for local accounts). |
| ExportDestination1.UserName | username |User name used for authentication to network share. |
| ExportDestination1.Password | password | Encrypted password used for authentication to network share. |
| ExportDestination1.FileName | filename.txt | Path and file name of data export (do not include drive letter or UNC share). Prefix with slash when using UNC paths (\path\filename.txt). |

**Overridden values**
| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| openPDC.ServiceHost | healthExporter, statusExporter | ExportDestination1 | drive letter of the [Installation directory](Getting_Started.md#installation-directory") |
| openPDC.ServiceHost | healthExporter, statusExporter | ExportDestination1.Domain |   |
| openPDC.ServiceHost | healthExporter, statusExporter | ExportDestination1.UserName |   |
| openPDC.ServiceHost | healthExporter, statusExporter |ExportDestination1.Password |   |
| openPDC.ServiceHost | healthExporter | ExportDestination1.FileName | [installation directory](Getting_Started.md#installation-directory)\Health.txt |
| openPDC.ServiceHost | statusExporter | ExportDestination1.FileName | [installation directory](Getting_Started.md#installation-directory)\Status.txt

---

## OleDbMetadataProvider

**Default category**

`OleDbMetadataProvider`

**Settings**

This section also includes settings from [MetadataProviderBase](#metadataproviderbase)

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| ConnectionString |    | Connection string for connecting to the OLE DB data store of metadata. |
| SelectString |    | SELECT statement for retrieving metadata from the OLE DB data store. |

---

## RestService

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| Enabled | False | True if this web service is enabled; otherwise False. |
| ServiceUri |   | URI where this web service is to be hosted. |
| ServiceContract | *Namespace*.I*ClassName*, *AssemblyName* |Assembly qualified name of the contract interface implemented by this web service. |
| ServiceDataFlow | BothWays | Flow of data (Incoming; Outgoing; BothWays) allowed for this web service. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| HistorianAdapters.LocalOutputAdapter | adapter_nameMetadataService, adapter_nameTimeSeriesDataService | Enabled | True |
| TVA.Historian.DataServices.MetadataService | adapter_nameMetadataService | ServiceUri | `http://localhost:6151/historian` |
| TVA.Historian.DataServices.TimeSeriesDataService | adapter_nameTimeSeriesDataService | ServiceUri | `http://localhost:6152/historian` |

---

## RestWebServiceMetadataProvider

**Default category*

`RestWebServiceMetadataProvider`

**Settings**

This section also includes settings from [MetadataProviderBase](#MetadataProviderBase)

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| ServiceUri |   | URI where the REST web service is hosted. |
| ServiceDataFormat | PoxRest | Format (Json; PoxAsmx; PoxRest) in which the REST web service exposes the data. |

---

## ScheduleManager

**Default category**

`scheduleManager`

Name, value, and description are all dependent upon the schedules added to the schedule manager.

openPDC.exe.Config processScheduler category:

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| HealthMonitor | * * * * * | Any Minute, Any Hour, Any Day, Any Month, Any DayOfWeek |
| StatusExport | */30 * * * * | Every 30 Minute, Any Hour, Any Day, Any Month, Any DayOfWeek |

---

## ServerBase

**Default category**

`communicationServer`

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| ConfigurationString |    | Data required by the server to initialize. |
| MaxClientConnections | -1 | Maximum number of clients that can connect to the server. |
| Handshake | False | True if the server will do a handshake with the client after the connection has been established; otherwise False. |
| HandshakeTimeout | 3000 | Number of milliseconds the server will wait for the clients to initiate the Handshake process. |
| SharedSecret | `6572a33d-826f-4d96-8c28-8be66bbc700e` | Key to be used for ciphering the data exchanged between the server and clients. |
| Encryption | None | Cipher strength (None; Aes128; Aes256) to be used for ciphering the data exchanged between the server and clients. |
| SecureSession | False | True if the data exchanged between the server and clients will be encrypted using a private session passphrase; otherwise False. |
| ReceiveTimeout | -1 | Number of milliseconds the server will wait for data to be received from the clients. |
| ReceiveBufferSize | 8192 | Size of the buffer used by the server for receiving data from the clietns. |
| Compression | NoCompression | Compression strength (NoCompression; DefaultCompression; BestSpeed; BestCompression; MultiPass) to be used for compressing the data exchanged between the server and clients. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| openPDC.exe.Config | remotingServer | ConfigurationString | Port = 8500 |
| openPDC.exe.Config | remotingServer | Handshake | True |
| openPDC.exe.Config | remotingServer | SharedSecret | openPDC |

---

## ServiceHelper

**Default category**

`serviceHelper`

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| LogStatusUpdates | True | True if status update messages are to be logged to a text file; otherwise False. |
| MaxStatusUpdatesLength | 8192 | Maximum numbers of characters allowed in update status messages without getting suppressed from being displayed. |
| MaxStatusUpdatesFrequency | 30 | Maximum number of status update messages that can be issued in a second without getting suppressed from being displayed. |
| MonitorServiceHealth | False | True if the service health is to be monitored; otherwise False. |
| RequestHistoryLimit | 50 | Number of client request entries to be kept in the history. |
| SupportTelnetSessions | False | True to enable the support for remote telnet-like sessions; otherwise False. |
| AllowedRemoteUsers | * | Comma or semicolon delimited list of user logins allowed to connect to the service remotely. |
| ImpersonateRemoteUser | False | True to execute remote commands under the identity of the remote user; otherwise False. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| openPDC.exe.Config | serviceHelper | MaxStatusUpdatesLength | 262144 |
| openPDC.exe.Config | serviceHelper | MaxStatusUpdatesFrequency | 100 |
| openPDC.exe.Config | serviceHelper | MonitorServiceHealth | True |

---

## ServiceHost

ServiceHost does not implement the IPersistSettings interface. It manipulates the configuration file directly.<br>

### systemSettings category

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| NodeID | Random GUID | Unique Node ID |
| ConfigurationType | Database | Specifies type of configuration: Database, WebService or XmlFile |
| ConnectionString | Provider = Microsoft.Jet.OLEDB.4.0; Data Source = openPDC.mdb | Configuration database connection string |
| DataProviderString | AssemblyName = {System.Data, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.OleDb.OleDbConnection; AdapterType = System.Data.OleDb.OleDbDataAdapter | Configuration database ADO.NET data provider assembly type creation string. |
| ConfigurationCachePath | [installation directory](Getting_Started.md#installation-directory)\ConfigurationCache\ | Defines the path used to cache serialized configurations |
| CachedConfigurationFile | SystemConfiguration.xml | File name for the last known good system configuration ( only cached for a dAtabase or WebService connection) |
| UniqueAdaptersIDs | True | Set to true if all runtime adapter ID's will be unique to allow for easier adapter specification |
| ProcessPriority RealTime | Sets desired process priority: Normal, AboveNormal, High, RealTime |

**Overridden value**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| openPDC.exe.Config | systemSettings | NodeID | `e7a5235d-cb6f-4864-a96e-a8686f36e599` |

### exampleSettings category

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| SqlServer.ConnectionString | Data Source = serverName; Initial Catalog = openPDC; User Id = userName; Password = password | Example SQL Server database connection string |
| SqlServer.DataProviderString | AssemblyName = {System.Data, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.SqlClient.SqlConnection; AdapterType = System.Data.SqlClient.SqlDataAdapter | Example SQL Server database .NET provider string |
| MySQL.ConnectionString | Server = serverName; Database = openPDC; Uid = root; Pwd = password | Example MySQL database connection string |
| MySQL.DataProviderString | AssemblyName = {MySql.Data, Version = 5.2.7.0, Culture = neutral, PublicKeyToken = c5687fc88969c44d}; ConnectionType = MySql.Data.MySqlClient.MySqlConnection; AdapterType = MySql.Data.MySqlClient.MySqlDataAdapter | Example MySQL database .NET provider string |
| Oracle.ConnectionString | Data Source = openPDC; User Id = username; Password = password; Integrated Security = no | Example Oracle database connection string |
| Oracle.DataProviderString | AssemblyName = {System.Data.OracleClient, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.OracleClient.OracleConnection; AdapterType = System.Data.OracleClient.OracleDataAdapter | Example Oracle database .NET provider string |
| OleDB.ConnectionString | Provider = Microsoft.Jet.OLEDB.4.0; Data Source = openPDC.mdb | Example Microsoft Access (via OleDb) database connection string |
| OleDB.DataProviderString | AssemblyName = {System.Data, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.OleDb.OleDbConnection; AdapterType = System.Data.OleDb.OleDbDataAdapter | Example OleDb database .NET provider string |
| Odbc.ConnectionString | Driver = {SQL Server Native Client 10.0}; Server = serverName; Database = openPDC; Uid = userName; Pwd = password | Example ODBC database connection string |
| Odbc.DataProviderString | AssemblyName = {System.Data, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.Odbc.OdbcConnection; AdapterType = System.Data.Odbc.OdbcDataAdapter | Example ODBC database .NET provider string |
| WebService.ConnectionString | https://naspi.tva.com/openPDC/LoadConfigurationData.aspx | Example web service connection string |
| XmlFile.ConnectionString | SystemConfiguration.xml | Example XML configuration file connection string |

### thresholdSettings category

**Settings**

| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| MeasurementWarningThreshold | 100000 | Number of unarchived measurements allowed in any output adapter queue before displaying a warning message |
| MeasurementDumpingThreshold | 500000 | Number of unarchived measurements allowed in any output adapter queue before taking evasive action and dumping data |
| DefaultSampleSizeWarningThreshold | 10 | Default number of unpublished samples (in seconds ) allowed in any action adapter queue before displaying a warning message |

---

## TcpServer

**Default category**

`communicationServer`

**Settings**

This section also includes settings from <a href="#ServerBase">ServerBase</a>.<br>


| Name | Default Value | Description |
| ---- | ------------- | ----------- |
| PayloadAware | False | True if payload boundaries are to be preserved during transmission, otherwise False. |

**Overridden values**

| Source | Category | Name | Value |
| ------ | -------- | ---- | ----- |
| openPDC.exe.Config | remotingServer | PayloadAware | True |

---

Jun 23, 2010 at 1:46:27 PM Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 8  
Oct 4, 2015 Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Config%20File) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)