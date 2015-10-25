<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8" />
</head>
<body>
<!--HtmlToGmd.Body-->
<h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>
<hr />
<div id="NavigationMenu">
<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">
<tr>
<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>
</tr>
</table>
</div>
<hr />
<!--/HtmlToGmd.Body-->
<div class="WikiContent">
<div class="wikidoc">
<h5><strong><em>Note on IPv4 vs IPv6 in the openPDC:</em></strong></h5>
<p style="padding-left:60px"><span style="color:#1f497d">The default IP stack for most new Windows systems is IPv6, this means all connections will default to IPv6 unless otherwise specified. If you want the openPDC to use IPv4, the server and client connections
 can be configured to use the IPv4 stack by specifying &ldquo;; interface=0.0.0.0&rdquo; in the relevant configuration settings and connection strings. The interface setting is used to specify the IP address of the network interface controller (NIC) to use
 for the connection &ndash; an IP of zero means that the default NIC should be used for the connection; the format of the interface IP setting determines the IP stack version, i.e., IPv4 or IPv6, to use for the connection, for example, to force use of IPv6
 you would use &ldquo;; interface=::0&rdquo;.</span></p>
<ul>
<li>User's Documentation<br>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md">Getting Started</a>
</li></ul>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md">Frequently Asked Questions</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Use_and_Configuration_Guides.md">Use and Configuration Guides</a>
</li></ul>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Introducing_the_openPDC_Manager.md">Overview of the openPDC Management System</a>
</li></ul>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Manager_Configuration.md">How to Use the openPDC Manager</a>
</li><li><a title="Default openPDC Ports" href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/FAQ.files/Default_openPDC_Ports.rtf" target="_blank">Default openPDC Ports</a>
</li><li><a title="Running openPDC on Linux / Mac" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_on_Linux_and_Mac.md">Running openPDC on Linux / Mac</a>&nbsp;<span style="color:#ff0000"><em><strong>NEW</strong></em></span>
</li><li><a title="Running openPDC on a Raspberry Pi" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_on_a_Raspberry_Pi.md">Running openPDC on a Raspberry Pi</a>&nbsp;<span style="color:#ff0000"><em><strong>NEW</strong></em></span>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Data_Quality_Reports.md">Data Quality Reporting Services</a>&nbsp;<span style="color:#ff0000"><em><strong>NEW</strong></em></span>
</li><li><span style="color:#ff0000"><a title="Custom Point Tag Naming Convention" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Custom_Point_Tag_Naming_Convention.md">Custom Point Tag Naming Convention</a>&nbsp;<span style="color:#ff0000"><em><strong>NEW</strong></em></span></span>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Enabling_Security_for_Historian_Web_Services.md">Enabling Security for Historian Web Services</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/GEP_Subscription_Tester.md">The GEP Subscription Tester</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_in_Virtual_Machine.md">Running the openPDC in Virtual Machine</a>
</li></ul>
<ul>
<li><a title="Moving Historian to Another Location" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Move_Local_Historian_to_Another_Folder.md">Moving Historian to Another Location</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Using_a_Gateway_Style_Connection_between_openPDCs_and_for_openPGs.md">Using a &quot;Gateway Style Connection&quot; between openPDCs and/or openPGs</a>
</li><li><a title="Controlling UDP data loss" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Controlling_UDP_Data_Loss.md">Controlling UDP data loss</a>
</li><li><span style="color:#ff0000"><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Remote_Console_Security.md">Remote Console Security</a></span>
</li></ul>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md">Help Me Choose Diagrams</a>
</li></ul>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Config_File.md">Configuration File Settings</a>
</li></ul>
<ul>
<li><a title="Uniform CPU Utilization Settings" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Settings_for_Uniform_CPU_Utilization.md">Setting for Uniform CPU Utilization</a>
</li></ul>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Configuration_Commands.md">openPDC Console Commands to Adjust Configuration Settings</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/OSI-PI_Adapters.md">openPDC OSI-PI Adapters</a>&nbsp;<span style="color:#ff0000"><em><strong>UPDATED</strong></em></span>
</li></ul>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Data_Quality_Monitoring.md">Data Quality Monitoring Adapters</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Connection_Strings.md">Adapter Connection String Syntax</a>
</li><li><a href="https://docs.google.com/spreadsheet/ccc?key=0AsRzeFw8l0JLdDNjN3hscml2ZV9SWVZGOS1jT0lqOWc&usp=sharing" target="_blank">openHistorian 1.0 Archive Size Calculator</a>
    ++ <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Use_and_Configuration_Guides.files/Archive_Sizing_Spreadsheet_473120.xlsx">Archived XLSX</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Historian_Distribution_Notes.md">Distributed Historian Setup Notes</a>
</li><li><a title="Automated Archive Data Recovery Operation" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Automated_Archive_Data_Recovery_Operation.md">Automated Archive Data Recovery Operation</a>&nbsp; (a.k.a., Missing Data Gap Filling)
</li><li><a title="Automated Connection Failover Operation" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Automated_Connection_Failover.md">Automated Connection Failover Operation</a>
</li><li><a title="Adjusting Output Stream Labels to Meet ISO Naming Standard" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Adjusting_Output_Stream_Labels_to_Meet_ISO_Naming_Convention.md">Adjusting Output Stream Labels to Meet ISO Naming Standard</a>
</li><li><a href="http://pmuconnectiontester.codeplex.com/documentation" target="_blank">PMU Connection Tester</a> (accessed via host site)
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md">How to Manually Configure the openPDC</a>
</li><li><a title="Bulk apply line-to-line adjustment" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/How_to_Bulk_Apply_line-to-line_Sqrt3_Adjustment_to_all_Voltage_Magnitudes.md">How to Bulk Apply line-to-line Sqrt(3) Adjustment to all Voltage Magnitudes</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Overview.md">Single Page Overview</a>
</li></ul>
</li><li>Developer's Documentation
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md">Getting Started</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md">Frequently Asked Questions</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Build_the_openPDC_Manager.md">Build the openPDC Manager</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Data_Access_Options.md">Data Access Options for the openPDC</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Device_to_Data_in_5_Easy_Steps.md">Device to Data in 5 Easy Steps</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_About_the_Code.md">High-level Code Structure and Class Relationships</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Custom_Adapters.md">How to Create a Custom Adapter</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Two_Custom_Adapter_Examples.md">Two Custom Adapter Examples</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Multiple_Adapter_Synchronization.md">Multiple Adapter Synchronization</a>
</li><li><a title="Automated Phasor Tag Naming Convention" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Automated_Phasor_Tag_Naming_Convention.md">Automated Phasor Tag Naming Convention</a>
</li><li><a title="About the Signal Reference" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_About_the_Signal_Reference.md">About the Signal Reference Field</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Using_Hadoop.md">Processing openPDC data with Hadoop</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Code_Change_Notes.md">Code Change Notes</a>
</li></ul>
</li></ul>
<p><strong>Note:</strong> you can get a quick optimization of the openPDC run-time assemblies by using the .NET native image cache NGen. To apply these optimizations after the openPDC has been installed, run the following commands from an administrative console:</p>
<ul>
<li>CD &quot;C:\Program Files\openPDC\&quot; </li><li>C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngen install openPDC.exe </li><li>C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngen install TVA.PhasorProtocols.dll
</li><li>C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngen install HistorianAdapters.dll
</li><li>C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngen install PowerCalculations.dll
</li><li>C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngen install ICCPExport.dll </li></ul>
<p>The most recent system API help and documentation can be downloaded from the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Nightly_Builds.md">
Nightly Builds</a> - it's included with the binaries. This help can be used as standalone, compiled help files (.chm) or can be directly
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md"> integrated within Visual Studio</a>. We have also made our help system available online:
<a href="http://www.gridsolutions.org/NightlyBuilds/openPDC/Help/">Synchrophasor Protocol Classes Documentation</a></p>
</div>
</div>
<div id="footer">
<hr />
Last edited <span class="smartDate" title="5/29/2015 4:39:56 PM" LocalTimeTicks="1432942796">May 29, 2015 at 4:39 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 97<br />
Migrated from <a href="http://openpdc.codeplex.com/documentation">CodePlex</a> Oct 5, 2015 by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
