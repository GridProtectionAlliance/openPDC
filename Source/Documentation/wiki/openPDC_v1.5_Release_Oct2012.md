[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# openPDC v1.5 Release, October 7, 2012

|   |   |
|---|---|
| Change Set: [CodePlex 80357](http://openpdc.codeplex.com/SourceControl/changeset/view/80357) | Released: Oct 7, 2012 |
| Dev status: Stable | Uploaded: Oct 11, 2012 |

## Recommended Download

[![](files/RuntimeBinary.gif) Synchrophasor.Installs (rev 2).zip (application, 28974K, uploaded Oct 11, 2012)](http://openpdc.codeplex.com/downloads/get/360228)

## Release Notes

[![](files/project_icon_lrg.gif)]() Version 1.5.143, official release of the openPDC.
        
### This is the planned 4th Quarter 2012 release of the openPDC, version 1.5

*This build includes the latest PMU Connection Tester, v4.3.7*

- All openPDC Manager screens now support paging and improved UI response for large implementations (e.g., many hundreds of thousands of measurements)
- Seamless integration with the open Phasor Gateway (openPG)
- The openPDC can now perform all the functions of the openPG
- Support for the EI phasor label naming convention in IEEE C7.118 output streams
- Major overhaul of socket system including:
    - Multicast server and improved source support (receive and transmit for all protocols)
    - Simple UDP packet splitting (software outputs to accommodate than64K (or other user selectable
    - UDP receive from IP filter
    - Ability to close TCP command channel after successful connection
    - Socket data transmission threshold monitoring available for poor connections
- New extensible statistics engine
- Updated subscriber API's – with .NET, C++ and Java support
- An alarming service that will automated notifications based on phasor data comparisons to set-points or data control bands:
    - Alarms can be set to trigger based on real‐time phasor data, calculated points, or performance data
    - Alarm state can be exported through standard phasor data streams or via the PDC web service
- Dynamic switching to a secondary communications connection on failure primary connection
- Security and performance improvements on findings from testing by vendors major universities.
- Macrodyne G and N support
- IEC 61850-90-5 input support with new missing data statistic for multiple ASDUs
- Native OSI-PI input and output adapters built using SDK for best speed
- New dynamic expression calculator
- Enhanced power calculations include sequence calculation support
- Enhanced CSV adapters with high-resolution timer and formatting support
- 1-Second frequency averaging utility with configuration screen
- Historian will now roll-over even when export and trending tools have files open
- Historian result queries are now time-sorted
- Historian will now maintain number of files based on disk space if configured to do so
- Many more hundreds of improvements and bug fixes

### Upcoming Features

- DNP3 input and output adapters - expected November 2012
- OSI-PI input and output adapters (includes temporal support) - expected November 2012
- Automatic out-of-band historical data "gap filling" in a destination openPDC as might result, for example, during times that communications is lost between a substation and the control center - expected first quarter of 2013

## Reviews for this release

Oct 30, 2012 at 6:59 PM - [patpentz](http://www.codeplex.com/site/users/view/patpentz)

GPA knows what the memory problem is (not a leak in actuality) and is working to fix. The statistics problem cannot be reproduced. 
Thanks!!

---

Oct 11, 2012 - Updated by [ritchiecarroll](https://github.com/ritchiecarroll)  
Oct 8, 2015 - Migrated from [CodePlex]() by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
