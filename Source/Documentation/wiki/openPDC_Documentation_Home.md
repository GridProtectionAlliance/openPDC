[![The Open Source Phasor Data Concentrator](https://raw.githubusercontent.com/GridProtectionAlliance/openPDC/master/Source/Documentation/wiki/openPDC_Logo.png)](https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md)

|   |   |   |   |
|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC)** | **[openPDC Wiki Home](Home)** | **[Documentation](Documentation)** |

##### Note on IPv4 vs IPv6 in the openPDC:

The default IP stack for most new Windows systems is IPv6, this means all connections will default to IPv6 unless otherwise specified. If you want the openPDC to use IPv4, the server and client connections can be configured to use the IPv4 stack by specifying “;interface=0.0.0.0” in the relevant configuration settings and connection strings. The interface setting is used to specify the IP address of the network interface controller (NIC) to use for the connection – an IP of zero means that the default NIC should be used for the connection; the format of the interface IP setting determines the IP stack version, i.e., IPv4 or IPv6, to use for the connection, for example, to force use of IPv6 you would use “;interface=::0”.

-  User's Documentation
    -  [Getting Started](GettingStarted)
    -  [Frequently Asked Questions](FAQ)
    -  [Use and Configuration Guides](UseAndConfigurationGuides)
    -  [Overview of the openPDC Management System](IntroducingTheOpenPDCManager)
    -  [How to Use the openPDC Manager](OpenPDCManagerConfiguration)
    -  [Default openPDC Ports](https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/FAQ.files/Default_openPDC_Ports.rtf "Default openPDC Ports")
    -  [Running openPDC on Linux / Mac](RunningOpenPDCOnLinuxAndMac) _**NEW**_
    -  [Running openPDC on a Raspberry Pi](RunningOpenPDCOnARaspberryPi) _**NEW**_
    -  [Data Quality Reporting Services](OpenPDCDataQualityReports) _**NEW**_
    -  [Custom Point Tag Naming Convention](CustomPointTagNamingConvention) _**NEW**_
    -  [Enabling Security for Historian Web Services](EnablingSecurityForHistorianWebServices.md)
    -  [The GEP Subscription Tester](GEPSubscriptionTester.md)
    -  [Running the openPDC in Virtual Machine](RunningOpenPDCInVirtualMachine)
    -  [Moving Historian to Another Location](MoveLocalHistorianToAnotherFolder)
    -  [Using a "Gateway Style Connection" between openPDCs and/or openPGs](UsingAGatewayStyleConnectionBetweenOpenPDCsAndForOpenPGs)
    -  [Controlling UDP data loss](ControllingUDPDataLoss)
    -  [Remote Console Security](RemoteConsoleSecurity)
    -  [Help Me Choose Diagrams](HelpMeChooseDiagrams)
    -  [Configuration File Settings](ConfigFile)
    -  [Setting for Uniform CPU Utilization](SettingsForUniformCPUUtilization)
    -  [openPDC Console Commands to Adjust Configuration Settings](ConfigurationCommands)
    -  [openPDC OSI-PI Adapters](OSI-PIAdapters) _**UPDATED**_
    -  [Data Quality Monitoring Adapters](DataQualityMonitoring)
    -  [Adapter Connection String Syntax](ConnectionStrings)
    -  [openHistorian 1.0 Archive Size Calculator](https://docs.google.com/spreadsheet/ccc?key=0AsRzeFw8l0JLdDNjN3hscml2ZV9SWVZGOS1jT0lqOWc&usp=sharing) ++ [Archived XLSX](https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Use_and_Configuration_Guides.files/Archive_Sizing_Spreadsheet_473120.xlsx)
    -  [Distributed Historian Setup Notes](HistorianDistributionNotes)
    -  [Automated Archive Data Recovery Operation](AutomatedArchiveDataRecoveryOperation)  (a.k.a. Missing Data Gap Filling)
    -  [Automated Connection Failover Operation](AutomatedConnectionFailover.md)
    -  [Adjusting Output Stream Labels to Meet ISO Naming Standard](AdjustingOutputStreamLabelsToMeetISONamingConvention)
    -  [PMU Connection Tester](http://pmuconnectiontester.codeplex.com/documentation) (accessed via host site)
    -  [How to Manually Configure the openPDC](ManualConfiguration)
    -  [How to Bulk Apply line-to-line Sqrt(3) Adjustment to all Voltage Magnitudes](HowToBulkApplyLineToLineSqrt3AdjustmentToAllVoltageMagnitudes)
    -  [Single Page Overview](openPDCOverview)
-  Developer's Documentation
    -  [Getting Started](DevelopersGettingStarted)
    -  [Frequently Asked Questions](DevelopersFrequentlyAskedQuestions)
    -  [Build the openPDC Manager](DevelopersBuildTheOpenPDCManager)
    -  [Data Access Options for the openPDC](DevelopersDataAccessOptions)
    -  [Device to Data in 5 Easy Steps](DevelopersDeviceToDataIn5EasySteps)
    -  [High-level Code Structure and Class Relationships](DevelopersAboutTheCode)
    -  [How to Create a Custom Adapter](DevelopersCustomAdapters)
    -  [Two Custom Adapter Examples](DevelopersTwoCustomAdapterExamples)
    -  [Multiple Adapter Synchronization](DevelopersMultipleAdapterSynchronization)
    -  [Automated Phasor Tag Naming Convention](DevelopersAutomatedPhasorTagNamingConvention)
    -  [About the Signal Reference Field](DevelopersAboutTheSignalReference)
    -  [Processing openPDC data with Hadoop](DevelopersUsingHadoop)
    -  [Code Change Notes](DevelopersCodeChangeNotes)

**Note:** you can get a quick optimization of the openPDC run-time assemblies by using the .NET native image cache NGen. To apply these optimizations after the openPDC has been installed, run the following commands from an administrative console:

-  ```CD "C:\\Program Files\\openPDC\\"```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install openPDC.exe```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install TVA.PhasorProtocols.dll```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install HistorianAdapters.dll```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install PowerCalculations.dll```
-  ```C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\ngen install ICCPExport.dll```

The most recent system API help and documentation can be downloaded from the [Nightly Builds](NightlyBuilds) - it's included with the binaries. This help can be used as standalone, compiled help files (.chm) or can be directly [integrated within Visual Studio](DevelopersGettingStarted). We have also made our help system available online: [Synchrophasor Protocol Classes Documentation](http://www.gridsolutions.org/NightlyBuilds/openPDC/Help/)

---

- Sep 12, 2016 HTML to Markdown by [chefsteph9](https://github.com/chefsteph9)
- Oct 5, 2015 Migrated from [CodePlex](http://openpdc.codeplex.com/documentation) by [ajs](https://github.com/ajstadlin)
- May 29, 2015 4:39 PM Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 97

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
