[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# openPDC v1.5 SP1 Release, September 13, 2013

|   |   |
|---|---|
| Change Set: [CodePlex 87162](http://openpdc.codeplex.com/SourceControl/changeset/view/87162) | Released: Sep 13, 2013 |
| Dev status: Stable | Uploaded: Nov 15, 2013 |

## Recommended Download

[![](files/RuntimeBinary.gif) Synchrophasor.Installs (rev 2).zip (application, 173582K, uploaded Nov 15, 2013)](http://openpdc.codeplex.com/downloads/get/557045)

### Other Downloads

[![](files/RuntimeBinary.gif) Synchrophasor.Binaries (rev 2).zip (application, 190058K, uploaded Nov 15, 2013)](http://openpdc.codeplex.com/downloads/get/758501)

[![](files/RuntimeBinary.gif) Password Expiration Patch.zip (application, 19K, uploaded Nov 15, 2013)](http://openpdc.codeplex.com/downloads/get/761966)

## Release Notes

[![](files/project_icon_lrg.gif)]() This is the official release of the version 1.5 Service Pack 1 of the openPDC - revision 2.

### Version 1.5.247 - 09/13/2013

*Note that revision 2 includes a few GEP meta-data synchronization fixes over the initial release of service pack 1, including updated forward compatibility with openPDC 2.0 instances. If you intend on connecting to SIEGate and/or openPDC 2.0 with an instance of openPDC 1.5 - this revision is recommended.*

Latest version of the [PMU Connection Tester](https://pmuconnectiontester.codeplex.com/releases/view/109471), v4.4.0, is included with this installation.

Native OSI-PI input and output supported in this release. The OSI-PI adapters will only be available when the OSI-PI SDK is installed on the system.

This build includes a new tool called the [Gateway Exchange Protocol (GEP) Subscription Tester](GEP_Subscription_Tester.md) used to validate internal subscription style connections. This is a multi-platform application built using the [Grid Solutions Framework](https://gsf.codeplex.com/) Unity subscription API with deployment binaries or installers for Windows, Mac, Linux and Android devices.

Listed below are some of the various fixes and improvements included in the service pack, see [change log](https://openpdc.codeplex.com/SourceControl/list/changesets) for complete details.

- *New since release candidate:* Improvements and operational fixes to the UTK F-NET, BPA PDCstream and Macrodyne protocols as well as fixes for various digital fault recorders and power quality meters
- Vastly improved IP multicast support
- Statistics engine is now easier to extend - allowing simple addition of stats to custom adapters
- Optimized alarm processing in the alarm adapter.
- Replaced all blocking collections with asynchronous loop pattern (implemented via new `AysncQueue<T>` and updated `ProcessQueue<T>`) to improve performance.
- Fixed various usability issues on the Alarms page.
- Manager now avoids repeated error messages when the database is not available.
- Fixed manager issue where new data entry saved in the wrong node.
- Updated ProcessQueue implementations to take advantage of now lock-free async functionality.
- Added option for cross-domain access support for Sliverlight and Flash application accessing the openHistorian web service.
- Added maximum send queue size to TCP and UDP clients and servers.
- Added send-to capabilities to UDP client.
- Fixed TCP/UDP send operations to break large messages into multiple socket send operations.
- Fixed an issue that allowed the TCP client to attempt connections after it had already been disposed.
- Fixed exit condition of UdpServer send threads.
- Fixed issue requiring SocketAsyncEventArgs allocations for UDP send operations.
- Fixed race condition between send thread and send handler, and allowed for send handler to be called synchronously from send thread.
- Fixed unlikely race condition that would cause send operations on sockets to stop indefinitely.
- Improved socket layer error handling.
- In TcpClient, set connect wait handle on error and disconnect so that users waiting on synchronous connect operations that error out can continue.
- Added buffer parsed event to binary image parser base to be used for flow control with protocols that return very large and/or very fast buffers.
- Added code modification from ALSTOM to specify a time duration for log files and automatically purge old logs.
- Added maxSendQueueSize connection string parameter to the TCP and UDP clients and servers, which overrides the configuration file parameter if it exists.
- Corrected issue with possible overlapping log files in high volume logging situations.
- Fixed DataExtensions.AddParametersWithValues to allow for duplicate parameters in the query string.
- Fixed issue in ProcessQueue causing it to stop processing indefinitely.
- Fixed value calculation in SineWave class of TVA.NumericalAnalysis.
- Optimized implementation of MultiSourceFrameImageParserBase using concurrent dictionaries.
- Updated multi-source frame image parser to use the reusable object pool and buffer pool as an optimization.
- Added authentication success or failure logging to the Windows event log for the AdoSecurityProvider.
- Corrected issue when authenticating successfully with AD but having no ADO security database roles defined.
- Updated ADO security provider to provide logging distinguish between pass-through authentication and user acquired password authentication and make sure each is logged. Also corrected logging failure when attempting to login as an undefined user.
- Updated the ADO security provider to always log to the Windows event log, success or failure - with reason when available, for user authentication attempts.
- Corrected Macrodyne-G sub-second timestamps.
- Changed operation of keepCommandChannelOpen=false to be triggered on receipt of configuration frame.
- Updated manager to properly import alternate command channel when updating device configurations via the input wizard.
- Disabled step 1 of the input wizard when updating existing device configurations.
- Devices on the measurements page are now restricted to the current node.
- Added advanced search functionality to the Measurements page in the openPDC Manager.
- Added error log viewer to main menu.
- Fixed unlikely race condition in FrameParserBase that would cause it to stop processing frame buffer images indefinitely.
- Updated local input adapter to work for both temporal and real-time modes such that this adapter can now also be used as a primary data source to replay archived synchrophasor data for analysis.
- Updated archive reader to only manage one roll-over activity at once.
- In the device wizard, fixed request configuration when updating the configuration of existing devices.
- Updated PhasorMeasurementUserControl to save settings on application exit.
- Modified start timer thread in the schedule manager to be a background thread so that the system can shut down properly before the timer is started.
- Updated process queue to handle rare situations where collection may be modified during a context switch between GetEnumerator and MoveNext when using Linq expressions.
- Modified input wizard in the openPDC Manager to work harder to retain existing phasor and measurement configurations when updating an existing configuration.
- Updated openHistorian tools to better handle foreign date formats by auto-converting to US date format.
- Updated subscribers view model for open PG/PDC manager to issue a configuration reload rather than an initialize when authorized measurements are updated to avoid dropping existing connections.

Thanks!  
Ritchie

---

Nov 15, 2013 - Updated by [ritchiecarroll](https://github.com/ritchiecarroll)  
Oct 8, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/releases/view/98475) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)