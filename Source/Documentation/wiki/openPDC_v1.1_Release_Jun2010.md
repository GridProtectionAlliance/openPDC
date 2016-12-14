[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated. Please see the latest version of the openPDC project at [https://github.com/GridProtectionAlliance/openPDC](https://github.com/GridProtectionAlliance/openPDC).***

---

# openPDC v1.1 Release, June 30, 2010

|   |   |
|---|---|
| Change Set: [CodePlex 54206](http://openpdc.codeplex.com/SourceControl/changeset/view/54206) | Released: Jun 30, 2010 |
| Dev status: Stable | Uploaded: Jul 6, 2010 |

## Recommended Download

[![](files/RuntimeBinary.gif) Synchrophasor.Installs.zip (17815K, uploaded Jul 6, 2010)](http://openpdc.codeplex.com/downloads/get/129928)

## Release Notes

[![](files/project_icon_lrg.gif)]() This is the current recommended release build of the openPDC, version 1.1.79.54105.

### This download contains installers for the following:

- **openPDC Windows Service (32-bit)** `Release\Applications\openPDC\openPDCSetup.msi`
- **openPDC Windows Service (64-bit)** `Release\Applications\openPDC\openPDCSetup64.msi`
- **PMU Connection Tester (32-bit)** `Release\Tools\PMUConnectionTester\PMUConnectionTesterSetup.msi`
- **PMU Connection Tester (64-bit)** `Release\Tools\PMUConnectionTester\PMUConnectionTesterSetup64.msi`
- **openPDC Manager Services** `Release\Applications\openPDC\openPDCManager\openPDCManagerServicesSetup.msi`
- **openPDC Manager Application** `Release\Applications\openPDC\openPDCManager\openPDCManagerWebSetup.msi`

### Latest Features and Updates
- **Framework**
    - The Configuration Editor now supports encrypted settings
    - Added authentication API for improved security
    - Improved lPv6 UDP support
    - New threading improvements
    - The discarded measurements event now available
- **Synchrophasor**
    - System wide statistics
    - New 64-bit installation packages (openPDC and Connection Tester)
    - Enhanced Hadoop Replication Provider (detailed logging and multiple recursive folder watching)
    - New console commands
    - New Database upgrade utility (can migrate data between different schemas)
    - Flatline Tester now detects measurements that have not been published (discovers unconnected devices)
    - Improved reloadConfig command that removes the need for service restart
    - Added Data Discarded flag to high word of Status Flags to indicate measurement not being published to real-time stream due to late arrival
    - Data with bad time but good quality now marked as "old", bad data quality is "suspect"
    - Added new scaling factor fields in output stream
    - Can now query a concentrator’s status on HeaderFrame request
    - Made data validity processing optional
    - Updates to BPA PDCstream for more complete output support
- **openPDC Manager**
    - New Statistics Monitor page
    - User input validation and new default values for faster input
    - New connection string builder interface when connection file is not available
    - Request PMU configuration from web interface and import directly into Add Device Wizard (allows updating existing)
    - More comprehensive database structure (20+ fields added)
    - Devices can now be deleted/enabled/disabled from device screen

---

Jul 6, 2010 - Updated by [staphen](http://www.codeplex.com/site/users/view/staphen)  
Oct 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/releases/view/48110) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)