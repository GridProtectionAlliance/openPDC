[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# openPDC v2.0 Release, July 25, 2014

|   |   |
|---|---|
| Change Set: [CodePlex 91134](http://openpdc.codeplex.com/SourceControl/changeset/view/91134) | Released: Jul 25, 2014 |
| Dev status: Stable | Uploaded: Jul 25, 2014 |

## Recommended Download

[![](files/RuntimeBinary.gif) Synchrophasor.Installs.zip (application, 16386K, uploaded Jul 25, 2014)](http://openpdc.codeplex.com/downloads/get/705191)

### Other Downloads

[![](files/RuntimeBinary.gif) GEP Subscription Tester - Update 2.zip (application, 73107K, uploaded Nov 14, 2013)](http://openpdc.codeplex.com/downloads/get/705192)

[![](files/RuntimeBinary.gif) Synchrophasor.Binaries.zip (application, 31574K, uploaded Jul 25, 2014)](http://openpdc.codeplex.com/downloads/get/714515)

## Release Notes

[![](files/project_icon_lrg.gif)]() This is the official release version of the **openPDC v2.0**

### *Note recent update to version 2.0.166 - see changes below.*

#### We recommend all openPDC installations be updated to this new version. This is considered a major release of the openPDC with very large investments made into improving the performance, security and stability of the system (see details below).

#### Version 2.0.166 - 07/25/2014

##### Changes since version 2.0.155

- Fixed Data Migration Utility when migrating older schemas - if you have had issues migrating your configuration, upgrade to version 2.0.166
- Added OSI-PI Historian Adapters to the installation package - this includes latest meta-data sync and parallel processing optimizations
- Added support for [custom tag naming expressions](http://openpdc.codeplex.com/wikipage?title=Custom%20Point%20Tag%20Naming%20Convention) so that end user can control format of tag names
- Modified TLS implementations to log a security warning to the EventLog when any TLS protocol is enabled in the configuration other than TLS version 1.2
- Adjusted local historian input adapter to accommodate future timestamps as end-time for reads such that as new data is added reader can continue to replay data from the historian. This accommodates a situation like replaying data continuously from the archive in modes such as 30 day old data
- Fixed a bug in TimeSeriesStartupOperations that caused it to always delete and rewrite publisher and subscriber statistics in the database
- Corrected issue with multiple temporal configuration extractions when using same cached temporal configuration
- Modified open procedure for read-only access to wait until roll-over has completed before opening primary archive or timing out after 30 seconds
- Corrected issue with SEL Fast Message to ignore duplicate 0xFF values in streaming data that can occur with data transmission over Ethernet when Telnet protocol is being used
- Added run-time logs to primary service and each data subscriber
- Modified alarm logic to improve performance of the alarm engine
- Added an output adapter for the [InfluxDB](http://influxdb.com/) time-series historian
- Updated [PMU Connection Tester](https://pmuconnectiontester.codeplex.com/releases/view/122542) to the GSF based version 4.5.5

##### Changes since version 2.0.133 (abbreviated)

- Fixed an issue in FrameImageParserBase that was pooling objects in memory which were no longer in use (major issue correction)
- Modified users of the AsyncDoubleBufferedQueue to use the new signalling mechanism of the DoubleBufferedQueue rather than polling (faster)
- Fixed ConcentratorBase so it would work at extremely high frame rates.
- Implemented configuration augmentation and conditional data operations for database configurations to speed up ReloadConfig for large databases (major optimization)
- Fixed the Output Device Wizard in the Manager so that removing devices from an output stream does not take an unreasonably long amount of time (Manager scalability)
- Added time-quality flags measurement, for phasor protocols that support this, that is associated with a connection (e.g., directly connected device or concentrator). Quality flags can then archived and/or applied to an output stream. Output stream time-quality can be a measurement derived from a hardware clock
- Converted MeasurementKey to a class and provided more explicit factory functions for creating and/or looking up measurement keys (major optimization)
- Fixed issues with device updates related to renaming, changing historian and changing company with associated measurement information roll down (edge case fixes)
- Updated high-volume status message suppression logic to work better under load
- Fixed a bug that was causing the historian to attempt to offload the active file when offloading is enabled
- Synchronized configuration file operations to help avoid possible race conditions when dealing with new configurations
- Added command functions to data publisher for easier status updates on temporal sessions: EnumerateTemporalClients and GetTemporalStatus.
- Updated DataMigrationUtility to perform identity inserts as a faster way of spanning large auto-inc gaps in databases that support this.
- Updated SQL Server schema to include WITH (NOLOCK) in views to help reduce deadlock victim errors.
- Adjusted FRACESEC values for IEEE C37.118 and IEC 61850-90-5 timestamps in output streams to be more precise when a configuration frame is available.
- Modified adapter initialization to operate on a small number of independent threads to optimize system start-up at scale.
- Fixed installer action for user authentication when authenticating a managed service account
- Improved password input for remote console applications to support backspace and escape keys for correcting mistakes when typing passwords
- Fixed issue writing COMTRADE FRACSEC values when no subsequent digitals are being exported
- Modified export and trend functions to &quot;re-open&quot; archive on operation such that latest point data can be loaded (basically forcing a data-block allocation table reload)
- Updated data quality reporting screen to list all cached reports and better manage pending reports
- Fixed timestamp alignment in COMTRADE export to fill gaps where data may be missing
- New reporting engine for generating daily data quality reports
- Added logic to grant permissions to existing users when migrating databases using the Configuration Setup Utility
- Added additional security to certain remote console commands
- Updated the openPDC Manager to be able to authenticate domain users while running as local user
- Improved openPDC Manager remote configuration process

This new version of the openPDC has been completely overhauled as a .NET 4.5 application built on the new integrated [Grid Solutions Framework (GSF)](https://gsf.codeplex.com/). The Grid Solutions Framework is a combination of the [TVA Code Library](https://tvacodelibrary.codeplex.com/) and [Time-series Framework](http://timeseriesframework.codeplex.com/) projects on codeplex built using the new .NET 4.5 framework.  In creating the GSF, new code components have been added and all libraries have been refactored to make this integrated framework more secure and significantly better performing.<br>

#### Upgrade Notes

Upgrading to the 2.0 version of the openPDC will require .NET 4.5 to be installed and currently only a 64-bit installation is supported. During upgrade you must migrate your existing configuration to the new 2.0 configuration schema (this includes the release candidates). The Data Migration Utility included with the 2.0 version of the openPDC now supports ***all database types*** and can even migrate from one database type to another (e.g., SQLite to Oracle). OLE DB style connections are no longer required.

The release version of the openPDC 2.0 has been through extensive testing and is ready to use. The 2.0 build has all the improvements and bug fixes included in openPDC 1.5 SP1 plus a multitude of others. Upgrades to version 2.0 from older openPDC versions have been well tested and are fully supported. Note that downgrades back to 1.5 will require some manual intervention - please check with GPA staff on required steps you should need to downgrade.

##### New Features / Improvements

Included with the openPDC 2.0 installation is a new tool called the **No Internet Fix Utility**. As its name suggests, you should run this utility when deploying the openPDC inside an environment that does not have Internet access. This tool will ensure all TLS/SSL style connections now required by the openPDC startup quickly by skipping timeouts even without Internet availability.

The [Gateway Exchange Protocol (GEP) Subscription Tester](GEP_Subscription_Tester.md) has been provided to validate internal subscription style connections. This is a multi-platform application was built using the [Grid Solutions Framework](http://gsf.codeplex.com/) Unity subscription API with deployment binaries or installers for Windows, Mac, Linux and Android devices.<br><br>Listed below is a high-level summary of the various fixes and improvements included in this new 2.0 release, see the [openPDC change log](http://openpdc.codeplex.com/SourceControl/list/changesets) and the [GSF change log](https://gsf.codeplex.com/SourceControl/list/changesets) for complete details:<br>

- **Performance**
    - Major system performance improvements using asynchronous double-buffered processing algorithms
    - Nearly 100% of system calls are now fully asynchronous 
    - GEP Compression reduces bandwidth utilization
    - High speed alarm processing for thousands of defined alarms
    - Buffer and stream pooling to reduce GC loading
    - Enabling of .NET 4.5 concurrent/server based GC to reduce CPU
- **Security**
    - Security has been integrated into all sub-system components
    - Calls  to custom invokable adapter methods now respect role based security
    - Transport layer security (TLS) is now enabled over AD integrated security by default for all remote console based connections (including openPDC Manager)
    - TLS library is integrated as part of GSF base communications library and available in GEP
    - Services now use either local NT virtual service or AD managed accounts to limit local machine access
    - File permissions access for service access is now limited to installation directory
- **Improvements**
    - Updated communications library has been extensively tested and debugged in a very wide set of deployment use cases
    - COMTRADE exports from Historian Trending Tool (includes support for  Annex H of IEEE C37.111-2010)
    - Native OSI-PI input and output support              
    - Vastly improved IP multicast support
    - Statistics engine is now easier to extend - allowing simple addition of stats to custom adapters
    - GEP subscription API&#39;s now include full support for the Unity platform (mono based), plus GSF based updates to C++/Java GEP libraries
    - Many hundreds of other bug fixes and improvements

Thanks!  
Ritchie

---

Jul 25, 2014 - Updated by [ritchiecarroll](https://github.com/ritchiecarroll)  
Oct 8, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/releases/view/109522) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
