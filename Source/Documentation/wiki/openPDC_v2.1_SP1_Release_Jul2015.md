[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md)

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC)** | **[openPDC Wiki](openPDC_Home.md)** | **[Documentation](openPDC_Documentation_Home.md)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases)** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# openPDC v2.1 SP1 Release, July 30, 2015

|   |   |
|---|---|
| Change Set: [CodePlex 97300](https://openpdc.codeplex.com/SourceControl/changeset/view/97300) | Released: Jul 30, 2015 |
| Dev status: Stable | Uploaded: Jul 30, 2015 |

## Recommended Download

[![](files/RuntimeBinary.gif) Synchrophasor.Installs.zip  (16223K, uploaded Jul 30, 2015)](http://openpdc.codeplex.com/downloads/get/1476243)

### Other Available Download

[![](files/RuntimeBinary.gif) Synchrophasor.Binaries.zip (32389K, uploaded Jul 30, 2015)](http://openpdc.codeplex.com/downloads/get/1476244)

## Release Notes - This is the planned release of the openPDC v2.1.120 Service Pack 1

#### This release adds:

- Completeness report, that replaces existing data quality report, and a new Correctness report that will provide reasonability and validity checks on synchrophasor data based on any configured alarms with a severity of "Unreasonable" or "Latched".
- Configuration options to allow reports, both completeness and correctness, to be delivered via e-mail. Settings can be configured using the XML Configuration Editor.
- Improved alarm configuration and monitoring screens to provide better usability and feedback.
- New `CountOnlyMappedMeasurements` configuration setting for synchrophasor inputs that will only count measurements that are enabled so that disabled measurements that are not received will not count against expected measurements and skew daily report numbers.
- An optional logging path for data gap recovery operations so that clustered implementations can use DFS replication to maintain runtime and outage log synchronization for subscriptions with automatic data recovery enabled.
- Support for GEP sessions using ZeroMQ.
- Message throttling in the 1.0 Historian for data with bad timestamps.
- Optimized AF-SDK based OSI-PI adapter to always insert given point IDs from the same thread (can make older PI instances happier) - this also includes a minor improvement in connection handling.
- Updated measurement metadata UI to do a full reload config to make sure changes are fully propagated to output adapters, e.g., flowing any updates to OSI-PI for metadata sync.
- New `TagNamePrefixRemoveCount` configuration setting to the OSI-PI adapter to remove desired levels of tag name prefixes (like those acquired from a subscription, e.g., "SOURCE!") from PI tag names when performing automated metadata synchronization.
- Change of openPDC installer license to MIT.

#### This release also includes fixes that have been applied via GSF and the openPDC since the original version 2.1 release, including:

- Issue where leaving openPDC Manager running on the home screen and connected to the openPDC service would keep allocated pinned buffers manifesting as a slow memory leak. Occurred due to use of the .NET FileSystemWatcher as a class member and parent class would not get a dispose call. In this case backup finalizer would not get called since watcher maintains a dangling reference to parent class via its internal pinned buffer. This can occur even with a properly implemented IDisposable pattern. Implemented and globally applied a  SafeFileWatcher wrapper that uses weak references to correct.
- Removed reusable memory streams in GEP engine to allow system to properly reclaim memory resources after periods of stress.
- Issue where OSI-PI adapter would not properly rename existing points under some conditions. Was due to fallback tag lookup procedure not properly finding associated measurement by signal ID stored in the  exdesc attribute.
- Issue where OSI-PI points keep updating after openPDC measurements have been removed.
- Exception while adding new phasors to input devices via the Manager.
- Updated phasor UI to check for duplicate source indexes when adding phasors manually.
- Confusing message in synchrophasor parser when receiving an exception related to data received on the command channel.
- Error messages in the DataPublisher’s  UpdateCertificateChecker during reconfiguration due to null subscriber identities.
- Issue in GSF.StringExtensions.ParseKeyValuePairs where certain character encodings would be decoded automatically by the parser.
- Adding Macrodyne Controller config file to setup package to prevent error message at startup.
- Issue where the TLS remoting server never properly disconnected unauthenticated clients.
- Cleared the wait handle upon completion of any successful send operations in the TlsServer.
- Updated the status of the TlsServer to include client send queue sizes so resource utilization can be better monitored.
- Fixed the SubscriberStatusQuery, used on the external subscription monitoring UI screen, to properly query the TLS!DATAPUBLISHER rather than the EXTERNAL!DATAPUBLISHER.

---

Apr 20, 2016 - Updated by [ritchiecarroll](https://github.com/ritchiecarroll)  
Oct 8, 2015 - Migrated from [CodePlex] by [aj](https://github.com/ajstadlin)

---

Copyright 2015-2017 [Grid Protection Alliance](http://www.gridprotectionalliance.org)