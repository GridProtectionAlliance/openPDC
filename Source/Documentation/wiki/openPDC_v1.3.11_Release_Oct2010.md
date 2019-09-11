[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](https://github.com/GridProtectionAlliance/openPDC/wiki)** | **[Documentation](https://github.com/GridProtectionAlliance/openPDC/wiki/Documentation)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# [openPDC v1.3.11 Maintenance Release, October 1, 2010](http://openpdc.codeplex.com/releases/view/53265)

|   |   |
|---|---|
| Change Set: [58067 on CodePlex](http://openpdc.codeplex.com/SourceControl/changeset/view/58067) | Released: Oct 1, 2010 |
| Dev status: Stable | Uploaded: Oct 4, 2010 |

## Recommended Download

[![](files/RuntimeBinary.gif) openPDCSetup.zip (22847K, uploaded Oct 4, 2010)](http://openpdc.codeplex.com/downloads/get/154217)

## Release Notes

[![](files/project_icon_lrg.gif)]() This is the October 2010 maintenance release build of the openPDC, version 1.3.11.

- Migration to .NET 4.0 / Visual Studio 2010 for enhanced performance and maintainability
- Enhanced setup application to simplify installation
- Redesigned openPDC Manager
- A local, windows application that does not require a web server or IIS configuration.
- Installs along with the openPDC so no further setup or installation required.
- Better grouping of menu items for easy navigation.
- A new screen for instant real-time data stream viewing and review of PMU performance statistics.
- Tightly coupled with the openPDC service. On screen configuration changes to adapters propagate to the openPDC service automatically.
- Statistical measurements get added/verified automatically every time input or output adapter configuration changes.
- Historian metadata (for data as well as statistics archival) get refreshed automatically whenever direct or indirect measurement changes occur.
- On screen ability to initialize any individual adapter.
- Improved indication of device(s) status throughout the system.
- Better error handling and reporting with a new error log viewer.
- User preferences and settings are saved on exit and applied on start-up.
- Force IPv4 is now an application level global setting which can be managed from System Settings screen.
- Input Status and Monitoring screen can now handle PDC stream with higher latency by setting Relative Time Offset in System Settings page.
- Added a "Copy" button on Browse Devices as well as Manage Output Stream screens.
- Added a new configuration option on the Input Wizard screen to create or update configuration manually.
- Modified code to persist database connection from one function call to another for improved performance.
- Better user experience on Input Wizard screen, quick links on the home page for easier navigation, wrapping of large tool-tips in to multiple lines, advanced configuration options for output stream are collapsed by default and allows users to expand if needed, added Check-All checkbox on Output Stream Wizard screens, master-detail pages selects first record by default, etc along with number of bug fixes and improvements.
- Inclusion of a COMTRADE export adapter
- Improved acceptance testing features with ability to playback historical data to simulate real-time inputs along with a new precision timer to verify performance.
- Optional ID-Code validation in IEEE C37.118 Output Streams for simple authentication
- Product separation into independent open source projects:
    -  [Framework - TVA Code Library](http://tvacodelibrary.codeplex.com/)
    -  [Historian - openHistorian](http://openhistorian.codeplex.com/)
    -  [NASPI PMU Registry](http://pmuregistry.codeplex.com/)
    -  [PMU Connection Tester](http://pmuconnectiontester.codeplex.com/)

---

Oct 4, 2010 - Updated by [ritchiecarroll](https://github.com/ritchiecarroll)  
Oct 8, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/releases/view/53265) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)