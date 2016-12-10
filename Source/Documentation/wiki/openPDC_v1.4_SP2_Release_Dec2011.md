[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# openPDC v1.4 SP2 Release, Dec 28, 2011

|   |   |
|---|---|
| Change Set: [CodePlex 73844](http://openpdc.codeplex.com/SourceControl/changeset/view/73844) | Released: Dec 28, 2011 |
| Dev status: Stable | Uploaded: Feb 24, 2012 |

## Recommended Download

[![](files/RuntimeBinary.gif) Synchrophasor.Installs.zip (application, 128396K, uploaded Dec 28, 2011)](http://openpdc.codeplex.com/downloads/get/238624)

### Other Downloads

[![](files/RuntimeBinary.gif) Synchrophasor.Binaries.zip (application, 44918K, uploaded Dec 28, 2011)](http://openpdc.codeplex.com/downloads/get/316814)

[![](files/RuntimeBinary.gif) Historian View Tool Patch for XP Systems (application, 74K, uploaded Jan 4, 2012)](http://openpdc.codeplex.com/downloads/get/322393)

[![](files/RuntimeBinary.gif) AdoOutputAdapter Hotfix (application, 24K, uploaded Feb 7, 2012)](http://openpdc.codeplex.com/downloads/get/337400)

[![](files/RuntimeBinary.gif) Critical! Output Stream Device Wizard Patch and MS Access Fix (application, 525K, uploaded Feb 23, 2012)](http://openpdc.codeplex.com/downloads/get/340526)

[![](files/RuntimeBinary.gif) openPDC Manager - offline help fix (application, 583K, uploaded Feb 23, 2012)](http://openpdc.codeplex.com/downloads/get/346752)

[![](files/RuntimeBinary.gif) Historian Patch - Archive Files Filling Up Disk Space (application, 215K, uploaded Feb 24, 2012)](http://openpdc.codeplex.com/downloads/get/347135)

## Release Notes

[![](files/project_icon_lrg.gif)]() Version 1.4.210, official service pack 2 release of the openPDC

### This is the planned December 2011 release of the openPDC, version 1.4 SP2

*This build includes the latest PMU Connection Tester, v4.2.12*

#### SP2 Patch History

There have been several minor updates to SP2, if you installed an older version and any of the patched items addressed below are of importance to your deployment, you can update your installation to the latest version:

- 1.4.210 - Updated PMU Connection Tester installers to v4.2.12 that include synchrophasor updates from revision 209
- 1.4.209 - Updated synchrophasor protocol parsers to to leave in any duplicate white space in labels as required in some current naming conventions. Made improvements to the ICCP file based export for TVA.
- 1.4.208 - Improved asynchronous connections on single core systems.
- 1.4.207 - Updated configuration setup wizard to properly write user settings XML for data migration utility on XP based systems.
- 1.4.206 - Updated configuration caching algorithm to create multiple backup configurations, when requested. Minor schema update to allow cascade deletes all the way down from a node level. Made all openPDC Manager grids remember last selected index after update.

#### Note that this service pack includes several schema improvements as well as support for Oracle and SQLite - as a result, a schema upgrade on your existing configuration database is required.

#### Update notes:

With significant duration performance and usability improvements, openPDC 1.4 SP2 represents a major upgrade:

- Completely new user interface experience
    - Designed for flexibility
    - Allows addition of new end-user custom UI screens
    - Every screen has been revisited for usability
    - Manger UI now has back and forward buttons
- Temporal streaming data playback support
    - Allows historical playback through the native subscription services
    - openPDC Manager will now automatically support playback when a local historian is defined
    - All adapters can now be setup to connect on demand (i.e., to start only when needed)
- Many framework level optimizations
    - A shared memory buffer pool and new parse / generate scheme was implemented to reuse internal buffers instead of always dynamically creating new ones which has greatly reduced the MB/sec of memory allocations needed.
    - Several optimizations have been made to the routing layer and new lock-free concurrent dictionaries have replaced older standard dictionaries that required critical section monitors which has reduced overall lock contention.
    - In places where synchronization was critical but overall lock time was low, new spinning locks have been implemented to reduce thread context switching.
- Various improvements to the built-in historian
    - The API now supports multiple points per call
    - Returned data is now sorted by time then point
    - New post based request method has been added web service interface
    - Added a new historian trending tool to view historical data
    - The historian playback utility has been updated and improved for usability
- Updates to database schema
    - Several improvements and corrections have been made to the schema
    - Additional, support for both Oracle and SQLite have been added
    - SQLite can be used in both 64-bit and 32-bit deployments without the need to install any other database software - great for substation style deployments
- Other miscellaneous improvements include
    - Added dual-stack socket support such that IPv6 listening ports can also accept IPv4 connections
    - Improved error messages for better interpretation of exceptions
    - Keyboard / menu shortcuts added to openPDC Manager
    - Service health, status and configuration are all displayed on the home screen
    - Added a virtual input adapter to allow creation placeholder input devices
    - Several hundred bug fixes and closed work items

---

Feb 24, 2012 - Updated by [mthakkar](http://www.codeplex.com/site/users/view/mthakkar)  
Oct 8, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/releases/view/64388) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)