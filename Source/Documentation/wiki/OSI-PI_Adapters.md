[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](https://github.com/GridProtectionAlliance/openPDC/wiki)** | **[Documentation](https://github.com/GridProtectionAlliance/openPDC/wiki/Documentation)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# openPDC OSI-PI Adapters

## Minimum Requirements

1. For openPDC v2.1 or newer, the PI AF-SDK is required to be installed on the openPDC server. For openPDC v2.0 or older, the PI SDK v1.4.0 or greater (use 32-bit or 64-bit to match openPDC) must be installed on the openPDC server. For 64-bit installations you must install <b>both</b> the 64-bit SDK and the 32-bit SDK. The GSF OSI-PI adapter library depends on the 64-bit OSI-PI SDK libraries as well as the OSI-PI Buffering Subsystem which is only installed with the 32-bit SDK.
2. Desired PI server connection must be added to the SDK 
3. Access to PI system using PI trust (preferred) or explicit login
    1. Connection must have access to read/write any points mapped to openPDC.
    2. If the metadata synchronization is enabled, connection must also have read/write access to the pipoint database.

## Output Configuration on an Existing openPDC Installation

1. Open the openPDC manager and navigate to **Outputs > Historians**.
2. Click the **Clear** button to create a new historian.
3. Type name is PIAdapters.PIOutputAdapter. Assembly name is PIAdapters.dll.
4. Connection string should be the following: server=*<servername>*;
    1. For explicit logins, add the following: username=*<pi username>*;password=*<pi password>*;
    2. To have openPDC create new PI tags for all archived measurements if they don't already exist, add the following: runMetadataSync=True;
5. Save the adapter configuration.
6. Navigate to **Manage > Measurements**.
7. Choose each measurement that should be archived to PI, and change its historian to the PI historian that was set up on the Historians page.

## Output Configuration on a new openPDC Installation

1. In the configuration setup utility, make sure to check the "Setup / change the primary historian" checkbox on the "Apply configuration changes" screen.
2. On the next screen, which is the "Set up primary historian" screen, select "PI: Archives measurements to a PI server using AF-SDK"
3. On the "Set up historian connection string" screen, set the servername property to the name of your PI server from the AF-SDK.
    1. For explicit logins, set the values of the username and password properties.
    2. To have openPDC create new PI tags for all archived measurements if they don't already exist, set the RunMetadataSync Property to True. Otherwise, set it to false.
4. Continue with the setup utility. This will make all your measurements archive to PI by default.

## Real-time Input Adapter Configuration

The real-time PI input adapter connects to PI using event pipes, which is the same mechanism process book uses to retrieve real-time data. The adapter also uses the connect on demand feature in openPDC, which allows it to only query PI for data being used by an action adapter or output adapter.

1. In the openPDC manager, go to **Adapters > Input Adapters**.
2. Enter a name for the PI input adapter.
3. For the type of adapter, choose "PI: Reads real-time measurements from a PI server using AF-SDK."
4. Set the ServerName property to the name of the PI server from the AF-SDK
5. If you wish to connect to the PI server using explicit logins, set the UserName and Password properties too.
6. Add an additional property to the connection string: "ConnectOnDemand=True;"
7. Next, go to the **Manage > Measurements** screen.
8. You will need to manually add measurements that you wish to make available in openPDC. Either the point tag or the alternate tag must match the point's tag in PI. It is recommended to create a separate historian (probably a virtual output historian) to archive all measurements and set the PI adapter's output measurement key to everything on the historian with a FILTER expression.

---

Feb 9, 2015 4:30 PM - Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 4  
Oct 4, 2015 - Migrated from [CodePlex](https://openpdc.codeplex.com/wikipage?title=OSI-PI%20Adapters) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)