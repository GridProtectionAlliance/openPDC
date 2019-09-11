[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](https://github.com/GridProtectionAlliance/openPDC/wiki)** | **[Documentation](https://github.com/GridProtectionAlliance/openPDC/wiki/Documentation)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Change the Local Historian Archive Location

The following steps outline how to move the statistics historian to another folder. To move you primary data historian (e.g., PPA) to another folder, the steps would be the same but the category settings name would start with "ppa" instead of "stat":

1. Stop the openPDC Windows service
2. Open the XML Configuration Editor (Start Menu / openPDC / XML Configuration Editor)
2. Click the "..." button and select the openPDC.exe.config in the openPDC installation folder (typically `C:\Program Files\openPDC\`)
3. Click "Load Settings" button 
4. Modify the following configuration settings:
    1. `statArchiveFile \ FileName` - change path to desired location - leave file name as-is
    2. `statIntercomFile \ FileName` - change path to desired location - leave file name as-is
    3. `statMetadataFile \ FileName` - change path to desired location - leave file name as-is
    4. `statStateFile \ FileName` - change path to desired location - leave file name as-is
5. Click the "Save Settings" button
6. If desired, while service is not running move all the existing files to the new location
7. Restart the openPDC Windows service

---

Jul 3, 2014 4:35 PM - Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 3  
Oct 4, 2015 - Migrated from [CodePlex](https://openpdc.codeplex.com/wikipage?title=Move%20Local%20Historian%20to%20Another%20Folder) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)