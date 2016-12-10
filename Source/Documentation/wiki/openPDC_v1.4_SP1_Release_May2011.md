[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# openPDC v1.4 SP1 Release, May 2, 2011

|   |   |
|---|---|
| Change Set: [CodePlex 66479](http://openpdc.codeplex.com/SourceControl/changeset/view/66479) | Released: May 2, 2011 |
| Dev status: Stable | Uploaded: May 2, 2011 |

## Recommended Download

[![](files/RuntimeBinary.gif) openPDC v1.4 SP1 Setup (application, 31692K, uploaded May 2, 2011)](http://openpdc.codeplex.com/downloads/get/228048)

### Other Downloads

[![](files/documentation.gif) openPDC v1.4 SP1 Upgrade Notes (documentation, 211K, uploaded May 2, 2011)](http://openpdc.codeplex.com/downloads/get/233561)

## Release Notes

Version 1.4.110 - SP1 release of the openPDC

[![](files/project_icon_lrg.gif)]() This is the official production release of the version 1.4 Service Pack 1 of the openPDC - May 2011.

**As a significant overall performance improvement**, this version includes an optional (but enabled by default) non-broadcast method of directly routing measurements within the openPDC (per suggestions by Tim Yardley and Erich Heine of the University of Illinois at Urbana-Champaign) which will provide at least a 50% reduction in CPU utilization in most configurations. Performance improvements will be greater with increased internal routing.

#### Other improvements include

- Added ProcessByReceivedTimestamp property to ConcentratorBase so applications using class can sort and publish measurements by received time which is useful in scenarios where very large volumes of data need concentration, but not necessarily in real-time, such as, reading data from a file where you want it sorted and processed as fast as possible as per suggestion by Chuanlin Zhao of Washington State University - this includes a new connection string setting (&quot;processByReceivedTimestamp&quot;) to set enable processing option (defaults to False).
- Implemented an &quot;update configuration&quot; per device connection, accessible via link on browse device screen, to simplify use case of updating a connection&#39;s modeled configuration.
- Added a secure offline user data cache to allow caching of key user information (e.g., user&#39;s group list) when user is disconnected from domain such that when role based rights are based on active directory group associations (i.e., where openPDC group name matches AD group name), rights upon login will still be active when logged in with cached Windows credentials without domain access.
- Added historical time tracking to the time-series framework&#39;s IFrame and IMeasurement interfaces for both received and published timestamps (used by ProcessByReceivedTimestamp).
- Made audit log database triggers optional so that openPDC Manager can run faster when auditing is not needed.

Service Pack 1 also corrects several issues reported by some users with Version 1.4 of the openPDC, see upgrade notes for details.

#### *Note: installers updated on May2, 2011 to include a few more corrections*

- [Local in-process historian requires manual initialize before it will pick-up points from newly added device](http://openpdc.codeplex.com/workitem/8571)
- [CPU spike on startup](http://openpdc.codeplex.com/workitem/8570)
- [ID not displayed on manage measurements screen.](http://openpdc.codeplex.com/workitem/8572)

---

May 2, 2011 - Updated by [ritchiecarroll](https://github.com/ritchiecarroll), on [CodePlex](http://www.codeplex.com/site/users/view/ritchiecarroll)  
Oct 8, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/releases/view/64387) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)