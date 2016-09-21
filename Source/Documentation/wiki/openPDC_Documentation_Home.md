[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md)

|   |   |   |
|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC)** | **[Documentation](openPDC_Documentation_Home.md)** |

##### Note on IPv4 vs IPv6 in the openPDC:

The default IP stack for most new Windows systems is IPv6, this means all connections will default to IPv6 unless otherwise specified. If you want the openPDC to use IPv4, the server and client connections can be configured to use the IPv4 stack by specifying “;interface=0.0.0.0” in the relevant configuration settings and connection strings. The interface setting is used to specify the IP address of the network interface controller (NIC) to use for the connection – an IP of zero means that the default NIC should be used for the connection; the format of the interface IP setting determines the IP stack version, i.e., IPv4 or IPv6, to use for the connection, for example, to force use of IPv6 you would use “;interface=::0”.

-  User's Documentation
    -  [Getting Started](Getting_Started.md)
    -  [Frequently Asked Questions](FAQ.md)
    -  [Use and Configuration Guides](Use_and_Configuration_Guides.md)
    -  [Overview of the openPDC Management System](Introducing_the_openPDC_Manager.md)
    -  [How to Use the openPDC Manager](openPDC_Manager_Configuration.md)
    -  [Default openPDC Ports](FAQ.files/Default_openPDC_Ports.rtf "Default openPDC Ports")
    -  [Running openPDC on Linux / Mac](Running_openPDC_on_Linux_and_Mac.md) _**NEW**_
    -  [Running openPDC on a Raspberry Pi](Running_openPDC_on_a_Raspberry_Pi.md) _**NEW**_
    -  [Data Quality Reporting Services](openPDC_Data_Quality_Reports.md) _**NEW**_
    -  [Custom Point Tag Naming Convention](Custom_Point_Tag_Naming_Convention.md) _**NEW**_
    -  [Enabling Security for Historian Web Services](Enabling_Security_for_Historian_Web_Services.md)
    -  [The GEP Subscription Tester](GEP_Subscription_Tester.md)
    -  [Running the openPDC in Virtual Machine](Running_openPDC_in_Virtual_Machine.md)
    -  [Moving Historian to Another Location](Move_Local_Historian_to_Another_Folder.md)
    -  [Using a "Gateway Style Connection" between openPDCs and/or openPGs](Using_a_Gateway_Style_Connection_between_openPDCs_and_for_openPGs.md)
    -  [Controlling UDP data loss](Controlling_UDP_Data_Loss.md)
    -  [Remote Console Security](Remote_Console_Security.md)
    -  [Help Me Choose Diagrams](Help_Me_Choose_Diagrams.md)
    -  [Configuration File Settings](Config_File.md)
    -  [Setting for Uniform CPU Utilization](Settings_for_Uniform_CPU_Utilization.md)
    -  [openPDC Console Commands to Adjust Configuration Settings](Configuration_Commands.md)
    -  [openPDC OSI-PI Adapters](OSI-PI_Adapters.md) _**UPDATED**_
    -  [Data Quality Monitoring Adapters](Data_Quality_Monitoring.md)
    -  [Adapter Connection String Syntax](Connection_Strings.md)
    -  [openHistorian 1.0 Archive Size Calculator](https://docs.google.com/spreadsheet/ccc?key=0AsRzeFw8l0JLdDNjN3hscml2ZV9SWVZGOS1jT0lqOWc&usp=sharing) ++ [Archived XLSX](Use_and_Configuration_Guides.files/Archive_Sizing_Spreadsheet_473120.xlsx)
    -  [Distributed Historian Setup Notes](Historian_Distribution_Notes.md)
    -  [Automated Archive Data Recovery Operation](Automated_Archive_Data_Recovery_Operation.md)  (a.k.a. Missing Data Gap Filling)
    -  [Automated Connection Failover Operation](Automated_Connection_Failover.md)
    -  [Adjusting Output Stream Labels to Meet ISO Naming Standard](Adjusting_Output_Stream_Labels_to_Meet_ISO_Naming_Convention.md)
    -  [PMU Connection Tester](http://pmuconnectiontester.codeplex.com/documentation) (accessed via host site)
    -  [How to Manually Configure the openPDC](Manual_Configuration.md)
    -  [How to Bulk Apply line-to-line Sqrt(3) Adjustment to all Voltage Magnitudes](How_to_Bulk_Apply_line-to-line_Sqrt3_Adjustment_to_all_Voltage_Magnitudes.md)
    -  [Single Page Overview](openPDC_Overview.md)
-  Developer's Documentation
    -  [Getting Started](Developers_Getting_Started.md)
    -  [Frequently Asked Questions](Developers_Frequently_Asked_Questions.md)
    -  [Build the openPDC Manager](Developers_Build_the_openPDC_Manager.md)
    -  [Data Access Options for the openPDC](Developers_Data_Access_Options.md)
    -  [Device to Data in 5 Easy Steps](Developers_Device_to_Data_in_5_Easy_Steps.md)
    -  [High-level Code Structure and Class Relationships](Developers_About_the_Code.md)
    -  [How to Create a Custom Adapter](Developers_Custom_Adapters.md)
    -  [Two Custom Adapter Examples](Developers_Two_Custom_Adapter_Examples.md)
    -  [Multiple Adapter Synchronization](Developers_Multiple_Adapter_Synchronization.md)
    -  [Automated Phasor Tag Naming Convention](Developers_Automated_Phasor_Tag_Naming_Convention.md)
    -  [About the Signal Reference Field](Developers_About_the_Signal_Reference.md)
    -  [Processing openPDC data with Hadoop](Developers_Using_Hadoop.md)
    -  [Code Change Notes](Developers_Code_Change_Notes.md)

**Note:** you can get a quick optimization of the openPDC run-time assemblies by using the .NET native image cache NGen. To apply these optimizations after the openPDC has been installed, run the following commands from an administrative console:

-  ```CD "C:\\Program Files\\openPDC\\"```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install openPDC.exe```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install TVA.PhasorProtocols.dll```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install HistorianAdapters.dll```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install PowerCalculations.dll```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install ICCPExport.dll```

The most recent system API help and documentation can be downloaded from the [Nightly Builds](Nightly_Builds.md) - it's included with the binaries. This help can be used as standalone, compiled help files (.chm) or can be directly [integrated within Visual Studio](Developers_Getting_Started.md). We have also made our help system available online: [Synchrophasor Protocol Classes Documentation](http://www.gridsolutions.org/NightlyBuilds/openPDC/Help/)

---

- Sep 12, 2016 HTML to Markdown by [chefsteph9](https://github.com/chefsteph9)
- Oct 5, 2015 Migrated from [CodePlex](http://openpdc.codeplex.com/documentation) by [ajs](https://github.com/ajstadlin)
- May 29, 2015 4:39 PM Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 97

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
