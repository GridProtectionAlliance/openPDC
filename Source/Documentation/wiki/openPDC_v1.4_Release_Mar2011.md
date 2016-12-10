[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# openPDC v1.4 Release, March 11, 2011

|   |   |
|---|---|
| Change Set: [CodePlex 64506](http://openpdc.codeplex.com/SourceControl/changeset/view/64506) | Released: March 11, 2011 |
| Dev status: Stable | Uploaded: March 11, 2011 |

## Recommended Download

[![](files/RuntimeBinary.gif) openPDCSetup.zip (30925K, uploaded Mar 11, 2011)](http://openpdc.codeplex.com/downloads/get/152722)

## Release Notes

[![](files/project_icon_lrg.gif)]() Version 1.4 release of the openPDC

## This is the official production release of the version 1.4 openPDC - March 2011.

### Update notes

- Integrated security with detailed configuration change audit logging
- Real-time data access / subscription based API available supporting full resolution as well as down-sampled data
- Improved UDP_T support (control channel failure monitoring independent of data channel)
- Added API support for querying statistics from the archive
- Added multi-homed source device idempotence features such that multiple connections to a source device can be defined mapping data to a single set of measurements
- New "Best Quality" as a down-sampling method
- Output stream statistics updated to take into account disconnected states
- Statistic to track latency of last discarded measurement to indicate what lag should be configured
- Ease-of-use improvements to installation package
- Improved manual connection management
- Dynamic switching between synchronized and unsynchronized data feeds
- openPDC Manager Enhancements
    - Integrated application security with support for definition of roles and users
    - Major improvements and optimizations to the openPDC Manager Input Status &amp; Monitoring screen
    - Adding sort ability to all columns in Devices list
    - "Help-Me-Choose" diagrams added for contextual help with settings
    - Home Status screen readability improvements
    - Support for non-60Hz users
    - Added option to perform timestamp reasonability check on the Output Stream and Calculated Measurement screens.
    - Ability to restart the service from the openPDC Manager

## Known issues

1. Enabling the optional encryption on the connection strings on Windows 7 / 2008 requires that openPDC Manager be run as administrator or be installed into a non-protected folder such that it can have read/write access to the crypto-key cache. Otherwise an error will be displayed on startup of the openPDC Manager similar to: "Access Denied - Error loading security provider: Failed to decrypt connection string".
2. The openPDC Console configuration file that gets deployed in v1.4.90 is missing a default setting, running application as administrator once will add the new setting on shutdown. Alternately you can manually update the config file adding the `IntegratedSecurity` setting from [here](http://openpdc.codeplex.com/SourceControl/changeset/view/64534#522160). Without the setting the console will throw an exception on shutdown. Installing from the [nightly build](http://openpdc.codeplex.com/wikipage?title=Nightly%20Builds) will also correct this error.
3. Addition of duplicate settings in the connection strings (e.g., manually adding Integrated Security string along with checking the checkbox for this feature) will cause an error to be displayed on startup of openPDC Manager as "Access Denied - Error loading security provider". Make sure there is one key per parameter in the connection string entries until duplicates can be ignored in a future release.

---

Apr 28, 2011 - Updated by [ritchiecarroll](https://github.com/ritchiecarroll)  
Oct 8, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/releases/view/52461) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)