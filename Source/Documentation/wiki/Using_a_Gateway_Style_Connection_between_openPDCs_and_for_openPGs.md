[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Using a Gateway Style Connection Between openPDCs and for openPGs

## How to connect between openPDCs and/or openPGs, in the subscribing system.

1. Navigate to Inputs -> Add New in openPG, or Devices -> Add New in openPDC
2. Enter the acronym you want this device to have
3. Under 'Protocol', select 'Gateway Transport'
4. With the connection string, click the '+', select the UDP tab, and select what local port you wish to use
5. In the Connection String, type 'autoconnect=true'
6. (If using the same database as openPDC) Add 'synchronizeMetaData=false' to connect string
7. In the Alternate Command Channel, type 'server=localhost:6165' (Replace 'localhost' with the host IP if not on the same system)
8. Ensure 'Concentrator' and 'Enabled' checkboxes are checked
9. Click 'Save'

Your connection should now be established! It may take a few moments to complete metadata exchange; refresh the device list to see the newly added devices.

---

Feb 15, 2012 6:02 PM - Last edited by [arkrohne](Contributors/arkrohne.md), version 3  
Oct 4, 2015 - Migrated from [CodePlex](https://openpdc.codeplex.com/wikipage?title=Using%20a%20%22Gateway%20Style%20Connection%22%20between%20openPDCs%20and%2for%20openPGs) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
