

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Config File</title>



<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body>

<h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>

<hr />

<!--HtmlToGmd.Body-->

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

<h1>Configuration File Settings</h1>

This document contains a list of settings that are saved in the configuration files used by the openPDC applications. Keep in mind that most category names can be changed and, in fact, are often changed. A settings category you see in your configuration file

 may go by a different name by default.<br>

<h5>Navigate by configuration file</h5>

<ul>

<li>openPDC.exe.Config

<ul>

<li><a href="#AdoMetadataProvider">devarchiveAdoMetadataProvider</a> </li><li><a href="#ArchiveFile">devarchiveArchiveFile</a> </li><li><a href="#IsamDataFileBase">devarchiveIntercomFile</a> </li><li><a href="#IsamDataFileBase">devarchiveMetadataFile</a> </li><li><a href="#RestService">devarchiveMetadataService</a> </li><li><a href="#OleDbMetadataProvider">devarchiveOleDbMetadataProvider</a> </li><li><a href="#RestWebServiceMetadataProvider">devarchiveRestWebServiceMetadataProvider</a>

</li><li><a href="#IsamDataFileBase">devarchiveStateFile</a> </li><li><a href="#RestService">devarchiveTimeSeriesDataService</a> </li><li><a href="#LogFile">errorLog</a> </li><li><a href="#ErrorLogger">errorLogger</a> </li><li><a href="#ServiceHost_exampleSettings">exampleSettings</a> </li><li><a href="#MultipleDestinationExporter">healthExporter</a> </li><li><a href="#ServiceHost_systemSettings">systemSettings</a> </li><li><a href="#ServiceHelper">serviceHelper</a> </li><li><a href="#ScheduleManager">processScheduler</a> </li><li><a href="#TcpServer">remotingServer</a> </li><li><a href="#AdoMetadataProvider">statAdoMetadataProvider</a> </li><li><a href="#ArchiveFile">statArchiveFile</a> </li><li><a href="#IsamDataFileBase">statIntercomFile</a> </li><li><a href="#IsamDataFileBase">statMetadataFile</a> </li><li><a href="#RestService">statMetadataService</a> </li><li><a href="#OleDbMetadataProvider">statOleDbMetadataProvider</a> </li><li><a href="#RestWebServiceMetadataProvider">statRestWebServiceMetadataProvider</a>

</li><li><a href="#IsamDataFileBase">statStateFile</a> </li><li><a href="#RestService">statTimeSeriesDataService</a> </li><li><a href="#MultipleDestinationExporter">statusExporter</a> </li><li><a href="#LogFile">statusLog</a> </li><li><a href="#ServiceHost_thresholdSettings">thresholdSettings</a></li></ul>

</li></ul>

<h5>Navigate by class</h5>

<ul>

<li><a href="#AdoMetadataProvider">AdoMetadataProvider</a> </li><li><a href="#ArchiveFile">ArchiveFile</a> </li><li><a href="#ErrorLogger">ErrorLogger</a> </li><li><a href="#IsamDataFileBase">IsamDataFileBase</a> </li><li><a href="#LogFile">LogFile</a> </li><li><a href="#MetadataProviderBase">MetadataProviderBase</a> </li><li><a href="#MultipleDestinationExporter">MultipleDestinationExporter</a> </li><li><a href="#OleDbMetadataProvider">OleDbMetadataProvider</a> </li><li><a href="#RestService">RestService</a> </li><li><a href="#RestWebServiceMetadataProvider">RestWebServiceMetadataProvider</a>

</li><li><a href="#ScheduleManager">ScheduleManager</a> </li><li><a href="#ServerBase">ServerBase</a> </li><li><a href="#ServiceHelper">ServiceHelper</a> </li><li><a href="#ServiceHost">ServiceHost</a>

<ul>

<li><a href="#ServiceHost_exampleSettings">exampleSettings category</a> </li><li><a href="#ServiceHost_systemSettings">systemSettings category</a> </li><li><a href="#ServiceHost_thresholdSettings">thresholdSettings category</a></li></ul>

</li><li><a href="#TcpServer">TcpServer</a></li></ul>

<h5>Navigate by adapter</h5>

<ul>

<li><a href="#RestService">DataQualityMonitoring.FlatlineTest</a> (aDAPTER_NAMEFlatlineService)

</li><li><a href="#RestService">DataQualityMonitoring.RangeTest</a> (outOfRangeService)

</li><li><a href="#RestService">DataQualityMonitoring.TimestampTest</a> (aDAPTER_NAMETimestampService)

</li><li><a href="#AdoMetadataProvider">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameAdoMetadataProvider)

</li><li><a href="#ArchiveFile">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameArchiveFile)

</li><li><a href="#IsamDataFileBase">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameIntercomFile)

</li><li><a href="#IsamDataFileBase">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameMetadataFile)

</li><li><a href="#RestService">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameMetadataService)

</li><li><a href="#OleDbMetadataProvider">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameOleDbMetadataProvider)

</li><li><a href="#RestWebServiceMetadataProvider">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameRestWebServiceMetadataProvider)

</li><li><a href="#IsamDataFileBase">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameStateFile)

</li><li><a href="#RestService">HistorianAdapters.LocalOutputAdapter</a> (adapter_nameTimeSeriesDataService)</li></ul>

<hr>

<h2><a name="AdoMetadataProvider"></a>AdoMetadataProvider</h2>

<b>Default category</b><br>

<span class="codeInline">AdoMetadataProvider</span><br>

<br>

<b>Settings</b><br>

This section also includes settings from <a href="#MetadataProviderBase">MetadataProviderBase</a>.<br>

<br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>ConnectionString </td>

<td></td>

<td>Connection string for connecting to the ADO.NET based data store of metadata.

</td>

</tr>

<tr>

<td>DataProviderString </td>

<td></td>

<td>The ADO.NET data provider assembly type creation string used to create a connection to the data store of metadata.

</td>

</tr>

<tr>

<td>SelectString </td>

<td></td>

<td>SELECT statement for retrieving metadata from the ADO.NET based data store. </td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameAdoMetadataProvider </td>

<td>SelectString </td>

<td>SELECT * FROM HistorianMetadata WHERE PlantCode = &#39;DEVARCHIVE&#39; </td>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameAdoMetadataProvider </td>

<td>ConnectionString </td>

<td><i>same as in <a href="#ServiceHost_systemSettings">systemSettings</a></i> </td>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameAdoMetadataProvider </td>

<td>DataProviderString </td>

<td><i>same as in <a href="#ServiceHost_systemSettings">systemSettings</a></i> </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="ArchiveFile"></a>ArchiveFile</h2>

<b>Default category</b><br>

<span class="codeInline">archiveFile</span><br>

<br>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>FileName </td>

<td>ArchiveFile.d </td>

<td>Name of the file including its path. </td>

</tr>

<tr>

<td>FileType </td>

<td>Active </td>

<td>Type (Active; Standby; Historic) of the file. </td>

</tr>

<tr>

<td>FileSize </td>

<td>1500 </td>

<td>Size (in MB) of the file. </td>

</tr>

<tr>

<td>DataBlockSize </td>

<td>8 </td>

<td>Size (in KB of the data blocks in the file. </td>

</tr>

<tr>

<td>RolloverPreparationThreshold </td>

<td>75 </td>

<td>Percentage file full when the rollover preparation should begin. </td>

</tr>

<tr>

<td>ArchiveOffloadLocation </td>

<td></td>

<td>Path to the location where historic files are to be moved when disk start getting full.

</td>

</tr>

<tr>

<td>ArchiveOffloadCount</td>

<td>5 </td>

<td>Number of files that are to be moved to the offload location when the disk starts getting full.

</td>

</tr>

<tr>

<td>ArchiveOffloadThreshold </td>

<td>90 </td>

<td>Percentage disk full when the historic files should be moved to the offload location.

</td>

</tr>

<tr>

<td>MaxHistoricArchiveFiles </td>

<td>-1 </td>

<td>Maximum number of historic files to be kept at both the primary and offload locations combined.

</td>

</tr>

<tr>

<td>LeadTimeTolerance </td>

<td>15 </td>

<td>Number of minutes by which incoming data points can be ahead of local system clock and still be considered valid.

</td>

</tr>

<tr>

<td>CompressData </td>

<td>True </td>

<td>True if compression is to be performed on the incoming data points; otherwise False.

</td>

</tr>

<tr>

<td>DiscardOutOfSequenceData </td>

<td>True </td>

<td>True if out-of-sequence data points are to be discarded; otherwise False. </td>

</tr>

<tr>

<td>CacheWrites </td>

<td>False </td>

<td>True if writes are to be cached for performance; otherwise False. </td>

</tr>

<tr>

<td>ConserveMemory </td>

<td>True </td>

<td>True if attempts are to be made to conserve memory; otherwise False. </td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>DataOperation (Optimize Local Historian Settings) </td>

<td>adapter_nameArchiveFile </td>

<td>CacheWrites </td>

<td>True </td>

</tr>

<tr>

<td>DataOperation (Optimize Local Historian Settings) </td>

<td>adapter_nameArchiveFile </td>

<td>ConserveMemory </td>

<td>False </td>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameArchiveFile </td>

<td>FileName </td>

<td>workingdir\adapter_name_archive.d </td>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameArchiveFile </td>

<td>FileSize </td>

<td>100 </td>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameArchiveFile </td>

<td>CompressData </td>

<td>False </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="ErrorLogger"></a>ErrorLogger</h2>

<b>Default category</b><br>

<span class="codeInline">errorLogger</span><br>

<br>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>LogToUI </td>

<td>False </td>

<td>True if an encountered exception is to be logged to the User Interface; otherwise False.

</td>

</tr>

<tr>

<td>LogToFile </td>

<td>True </td>

<td>True if an encountered exception is to be logged to a file; otherwise False. </td>

</tr>

<tr>

<td>LogToEmail </td>

<td>False </td>

<td>True if an email is to be sent to ContactEmail with the details of an encountered exception; otherwise False.

</td>

</tr>

<tr>

<td>LogToEventLog </td>

<td>True </td>

<td>True if an encountered exception is to be logged to the Event Log; otherwise False.

</td>

</tr>

<tr>

<td>LogToScreenshot </td>

<td>False </td>

<td>True if a screenshot is to be taken when an exception is encountered; otherwise False.

</td>

</tr>

<tr>

<td>LogUserInfo </td>

<td>False </td>

<td>True if user information is to be logged along with exception information; otherwise False.

</td>

</tr>

<tr>

<td>SmtpServer </td>

<td>localhost </td>

<td>Name of the SMTP server to be used for sending the email messages. </td>

</tr>

<tr>

<td>ContactName </td>

<td></td>

<td>Name of the person that the end-user can contact when an exception is encountered.

</td>

</tr>

<tr>

<td>ContactEmail </td>

<td></td>

<td>Comma-separated list of recipient email addresses for the email message. </td>

</tr>

<tr>

<td>ContactPhone </td>

<td></td>

<td>Phone number of the person that the end-user can contact when an exception is encountered.

</td>

</tr>

<tr>

<td>HandleUnhandledException </td>

<td>True </td>

<td>True if unhandled exceptions are to be handled automatically; otherwise False.

</td>

</tr>

<tr>

<td>ExitOnUnhandledException </td>

<td>False </td>

<td>True if the application must exit when an unhandled exception is encountered; otherwise False.

</td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>errorLogger </td>

<td>LogToEventLog </td>

<td>False </td>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>errorLogger </td>

<td>SmtpServer </td>

<td></td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="IsamDataFileBase"></a>IsamDataFileBase</h2>

<b>Default category</b><br>

<span class="codeInline">isamDataFile</span><br>

<br>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>FileName </td>

<td>IsamDataFile.dat </td>

<td>Name of the file including its path. </td>

</tr>

<tr>

<td>FileAccessMode </td>

<td>ReadWrite </td>

<td>Access mode (Read; Write; ReadWrite) to be used when opening the file. </td>

</tr>

<tr>

<td>AutoSaveInterval </td>

<td>-1 </td>

<td>Interval in milliseconds at which the file records loaded in memory are to be saved automatically to disk. Use -1 to disable automatic saving.

</td>

</tr>

<tr>

<td>LoadOnOpen </td>

<td>False </td>

<td>True if file records are to be loaded in memory when opened; otherwise False.

</td>

</tr>

<tr>

<td>SaveOnClose </td>

<td>False </td>

<td>True if file records loaded in memory are to be saved to disk when file is closed; otherwise False.

</td>

</tr>

<tr>

<td>ReloadOnModify </td>

<td>False </td>

<td>True if file records loaded in memory are to be re-loaded when file is modified on disk; otherwise False.

</td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>DataOperation (Optimize Local Historian Settings) </td>

<td>adapter_nameMetadataFile, adapter_nameStateFile, adapter_nameIntercomFile </td>

<td>LoadOnOpen </td>

<td>True </td>

</tr>

<tr>

<td>DataOperation (Optimize Local Historian Settings) </td>

<td>adapter_nameMetadataFile, adapter_nameStateFile, adapter_nameIntercomFile </td>

<td>ReloadOnModify </td>

<td>True </td>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameMetadataFile </td>

<td>FileName </td>

<td>workingdir\adapter_name_dbase.dat </td>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameStateFile </td>

<td>FileName </td>

<td>workingdir\adapter_name_startup.dat </td>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameIntercomFile </td>

<td>FileName </td>

<td>workingdir\scratch.dat </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="LogFile"></a>LogFile</h2>

<b>Default category</b><br>

<span class="codeInline">logFile</span><br>

<br>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>FileName </td>

<td>LogFile.txt </td>

<td>Name of the log file including its path. </td>

</tr>

<tr>

<td>FileSize </td>

<td>3 </td>

<td>Maximum size of the log file in MB. </td>

</tr>

<tr>

<td>FileFullOperation </td>

<td>Truncate </td>

<td>Operation(Truncate; Rollover) that is to be performed on the file when it is full.

</td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>TVA.ErrorManagement.ErrorLogger </td>

<td>errorLog </td>

<td>FileName </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">installation directory</a>\ErrorLog.txt

</td>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>statusLog </td>

<td>FileName </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">installation directory</a>\StatusLog.txt

</td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="MetadataProviderBase"></a>MetadataProviderBase</h2>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>Enabled </td>

<td>False </td>

<td>True if this metadata provider is enabled; otherwise False. </td>

</tr>

<tr>

<td>RefreshTimeout </td>

<td>60 </td>

<td>Number of seconds to wait for metadata refresh to complete. </td>

</tr>

<tr>

<td>RefreshInterval </td>

<td>-1 </td>

<td>Interval in minutes at which the metadata is to be refreshed. </td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameAdoMetadataProvider </td>

<td>Enabled </td>

<td>True </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="MultipleDestinationExporter"></a>MultipleDestinationExporter</h2>

<b>Default category</b><br>

<span class="codeInline">ExportDestinations</span><br>

<br>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>ExportTimeout </td>

<td>-1 </td>

<td>Total allowed time for all exports to execute in milliseconds. </td>

</tr>

<tr>

<td>ExportCount </td>

<td>1 </td>

<td>Total number of export files to produce. </td>

</tr>

<tr>

<td>ExportDestination1 </td>

<td>C:\ </td>

<td>Root path for export destination. Use UNC path (\\server\share) with no trailing slash for network shares.

</td>

</tr>

<tr>

<td>ExportDestination1.ConnectToShare </td>

<td>False </td>

<td>Set to True to attempt authentication to network share. </td>

</tr>

<tr>

<td>ExportDestination1.Domain </td>

<td>domain </td>

<td>Domain used for authentication to network share (computer name for local accounts).

</td>

</tr>

<tr>

<td>ExportDestination1.UserName </td>

<td>username </td>

<td>User name used for authentication to network share. </td>

</tr>

<tr>

<td>ExportDestination1.Password </td>

<td>password </td>

<td>Encrypted password used for authentication to network share. </td>

</tr>

<tr>

<td>ExportDestination1.FileName </td>

<td>filename.txt </td>

<td>Path and file name of data export (do not include drive letter or UNC share). Prefix with slash when using UNC paths (\path\filename.txt).

</td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>healthExporter, statusExporter </td>

<td>ExportDestination1 </td>

<td>drive letter of the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">

installation directory</a> </td>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>healthExporter, statusExporter </td>

<td>ExportDestination1.Domain </td>

<td></td>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>healthExporter, statusExporter </td>

<td>ExportDestination1.UserName </td>

<td></td>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>healthExporter, statusExporter </td>

<td>ExportDestination1.Password </td>

<td></td>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>healthExporter </td>

<td>ExportDestination1.FileName </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">installation directory</a>\Health.txt

</td>

</tr>

<tr>

<td>openPDC.ServiceHost </td>

<td>statusExporter </td>

<td>ExportDestination1.FileName </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">installation directory</a>\Status.txt

</td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="OleDbMetadataProvider"></a>OleDbMetadataProvider</h2>

<b>Default category</b><br>

<span class="codeInline">OleDbMetadataProvider</span><br>

<br>

<b>Settings</b><br>

This section also includes settings from <a href="#MetadataProviderBase">MetadataProviderBase</a>.<br>

<br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>ConnectionString </td>

<td></td>

<td>Connection string for connecting to the OLE DB data store of metadata. </td>

</tr>

<tr>

<td>SelectString </td>

<td></td>

<td>SELECT statement for retrieving metadata from the OLE DB data store. </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="RestService"></a>RestService</h2>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>Enabled </td>

<td>False </td>

<td>True if this web service is enabled; otherwise False. </td>

</tr>

<tr>

<td>ServiceUri </td>

<td></td>

<td>URI where this web service is to be hosted. </td>

</tr>

<tr>

<td>ServiceContract </td>

<td><i>Namespace</i>.I<i>ClassName</i>, <i>AssemblyName</i> </td>

<td>Assembly qualified name of the contract interface implemented by this web service.

</td>

</tr>

<tr>

<td>ServiceDataFlow </td>

<td>BothWays </td>

<td>Flow of data (Incoming; Outgoing; BothWays) allowed for this web service. </td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>HistorianAdapters.LocalOutputAdapter </td>

<td>adapter_nameMetadataService, adapter_nameTimeSeriesDataService </td>

<td>Enabled </td>

<td>True </td>

</tr>

<tr>

<td>TVA.Historian.DataServices.MetadataService </td>

<td>adapter_nameMetadataService </td>

<td>ServiceUri </td>

<td>http://localhost:6151/historian </td>

</tr>

<tr>

<td>TVA.Historian.DataServices.TimeSeriesDataService </td>

<td>adapter_nameTimeSeriesDataService </td>

<td>ServiceUri </td>

<td>http://localhost:6152/historian </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="RestWebServiceMetadataProvider"></a>RestWebServiceMetadataProvider</h2>

<b>Default category</b><br>

<span class="codeInline">RestWebServiceMetadataProvider</span><br>

<br>

<b>Settings</b><br>

This section also includes settings from <a href="#MetadataProviderBase">MetadataProviderBase</a>.<br>

<br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>ServiceUri </td>

<td></td>

<td>URI where the REST web service is hosted. </td>

</tr>

<tr>

<td>ServiceDataFormat </td>

<td>PoxRest </td>

<td>Format (Json; PoxAsmx; PoxRest) in which the REST web service exposes the data.

</td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="ScheduleManager"></a>ScheduleManager</h2>

<b>Default category</b><br>

<span class="codeInline">scheduleManager</span><br>

<br>

Name, value, and description are all dependent upon the schedules added to the schedule manager.<br>

<br>

openPDC.exe.Config processScheduler category:<br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>HealthMonitor </td>

<td>* * * * * </td>

<td>Any Minute, Any Hour, Any Day, Any Month, Any DayOfWeek </td>

</tr>

<tr>

<td>StatusExport </td>

<td>*/30 * * * * </td>

<td>Every 30 Minute, Any Hour, Any Day, Any Month, Any DayOfWeek </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="ServerBase"></a>ServerBase</h2>

<b>Default category</b><br>

<span class="codeInline">communicationServer</span><br>

<br>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>ConfigurationString </td>

<td></td>

<td>Data required by the server to initialize. </td>

</tr>

<tr>

<td>MaxClientConnections </td>

<td>-1 </td>

<td>Maximum number of clients that can connect to the server. </td>

</tr>

<tr>

<td>Handshake </td>

<td>False </td>

<td>True if the server will do a handshake with the client after the connection has been established; otherwise False.

</td>

</tr>

<tr>

<td>HandshakeTimeout </td>

<td>3000 </td>

<td>Number of milliseconds the server will wait for the clients to initiate the Handshake process.

</td>

</tr>

<tr>

<td>SharedSecret </td>

<td>6572a33d-826f-4d96-8c28-8be66bbc700e </td>

<td>Key to be used for ciphering the data exchanged between the server and clients.

</td>

</tr>

<tr>

<td>Encryption </td>

<td>None </td>

<td>Cipher strength (None; Aes128; Aes256) to be used for ciphering the data exchanged between the server and clients.

</td>

</tr>

<tr>

<td>SecureSession </td>

<td>False </td>

<td>True if the data exchanged between the server and clients will be encrypted using a private session passphrase; otherwise False.

</td>

</tr>

<tr>

<td>ReceiveTimeout </td>

<td>-1 </td>

<td>Number of milliseconds the server will wait for data to be received from the clients.

</td>

</tr>

<tr>

<td>ReceiveBufferSize </td>

<td>8192 </td>

<td>Size of the buffer used by the server for receiving data from the clietns. </td>

</tr>

<tr>

<td>Compression </td>

<td>NoCompression </td>

<td>Compression strength (NoCompression; DefaultCompression; BestSpeed; BestCompression; MultiPass) to be used for compressing the data exchanged between the server and clients.

</td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>openPDC.exe.Config </td>

<td>remotingServer </td>

<td>ConfigurationString </td>

<td>Port = 8500 </td>

</tr>

<tr>

<td>openPDC.exe.Config </td>

<td>remotingServer </td>

<td>Handshake </td>

<td>True </td>

</tr>

<tr>

<td>openPDC.exe.Config </td>

<td>remotingServer </td>

<td>SharedSecret </td>

<td>openPDC </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="ServiceHelper"></a>ServiceHelper</h2>

<b>Default category</b><br>

<span class="codeInline">serviceHelper</span><br>

<br>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>LogStatusUpdates </td>

<td>True </td>

<td>True if status update messages are to be logged to a text file; otherwise False.

</td>

</tr>

<tr>

<td>MaxStatusUpdatesLength </td>

<td>8192 </td>

<td>Maximum numbers of characters allowed in update status messages without getting suppressed from being displayed.

</td>

</tr>

<tr>

<td>MaxStatusUpdatesFrequency </td>

<td>30 </td>

<td>Maximum number of status update messages that can be issued in a second without getting suppressed from being displayed.

</td>

</tr>

<tr>

<td>MonitorServiceHealth </td>

<td>False </td>

<td>True if the service health is to be monitored; otherwise False. </td>

</tr>

<tr>

<td>RequestHistoryLimit </td>

<td>50 </td>

<td>Number of client request entries to be kept in the history. </td>

</tr>

<tr>

<td>SupportTelnetSessions </td>

<td>False </td>

<td>True to enable the support for remote telnet-like sessions; otherwise False. </td>

</tr>

<tr>

<td>AllowedRemoteUsers </td>

<td>* </td>

<td>Comma or semicolon delimited list of user logins allowed to connect to the service remotely.

</td>

</tr>

<tr>

<td>ImpersonateRemoteUser </td>

<td>False </td>

<td>True to execute remote commands under the identity of the remote user; otherwise False.

</td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>openPDC.exe.Config </td>

<td>serviceHelper </td>

<td>MaxStatusUpdatesLength </td>

<td>262144 </td>

</tr>

<tr>

<td>openPDC.exe.Config </td>

<td>serviceHelper </td>

<td>MaxStatusUpdatesFrequency </td>

<td>100 </td>

</tr>

<tr>

<td>openPDC.exe.Config </td>

<td>serviceHelper </td>

<td>MonitorServiceHealth </td>

<td>True </td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="ServiceHost"></a>ServiceHost</h2>

ServiceHost does not implement the IPersistSettings interface. It manipulates the configuration file directly.<br>

<h3><a name="ServiceHost_systemSettings"></a>systemSettings category</h3>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>NodeID </td>

<td>Random GUID </td>

<td>Unique Node ID </td>

</tr>

<tr>

<td>ConfigurationType </td>

<td>Database </td>

<td>Specifies type of configuration: Database, WebService or XmlFile </td>

</tr>

<tr>

<td>ConnectionString </td>

<td>Provider = Microsoft.Jet.OLEDB.4.0; Data Source = openPDC.mdb </td>

<td>Configuration database connection string </td>

</tr>

<tr>

<td>DataProviderString </td>

<td>AssemblyName = {System.Data, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.OleDb.OleDbConnection; AdapterType = System.Data.OleDb.OleDbDataAdapter

</td>

<td>Configuration database ADO.NET data provider assembly type creation string. </td>

</tr>

<tr>

<td>ConfigurationCachePath </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">installation directory</a>\ConfigurationCache\

</td>

<td>Defines the path used to cache serialized configurations </td>

</tr>

<tr>

<td>CachedConfigurationFile </td>

<td>SystemConfiguration.xml </td>

<td>File name for the last known good system configuration ( only cached for a dAtabase or WebService connection)

</td>

</tr>

<tr>

<td>UniqueAdaptersIDs </td>

<td>True </td>

<td>Set to true if all runtime adapter ID&#39;s will be unique to allow for easier adapter specification

</td>

</tr>

<tr>

<td>ProcessPriority </td>

<td>RealTime </td>

<td>Sets desired process priority: Normal, AboveNormal, High, RealTime </td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden value</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>openPDC.exe.Config </td>

<td>systemSettings </td>

<td>NodeID </td>

<td>e7a5235d-cb6f-4864-a96e-a8686f36e599 </td>

</tr>

</tbody>

</table>

<br>

<h3><a name="ServiceHost_exampleSettings"></a>exampleSettings category</h3>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>SqlServer.ConnectionString </td>

<td>Data Source = serverName; Initial Catalog = openPDC; User Id = userName; Password = password

</td>

<td>Example SQL Server database connection string </td>

</tr>

<tr>

<td>SqlServer.DataProviderString </td>

<td>AssemblyName = {System.Data, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.SqlClient.SqlConnection; AdapterType = System.Data.SqlClient.SqlDataAdapter

</td>

<td>Example SQL Server database .NET provider string </td>

</tr>

<tr>

<td>MySQL.ConnectionString </td>

<td>Server = serverName; Database = openPDC; Uid = root; Pwd = password </td>

<td>Example MySQL database connection string </td>

</tr>

<tr>

<td>MySQL.DataProviderString </td>

<td>AssemblyName = {MySql.Data, Version = 5.2.7.0, Culture = neutral, PublicKeyToken = c5687fc88969c44d}; ConnectionType = MySql.Data.MySqlClient.MySqlConnection; AdapterType = MySql.Data.MySqlClient.MySqlDataAdapter

</td>

<td>Example MySQL database .NET provider string </td>

</tr>

<tr>

<td>Oracle.ConnectionString </td>

<td>Data Source = openPDC; User Id = username; Password = password; Integrated Security = no

</td>

<td>Example Oracle database connection string </td>

</tr>

<tr>

<td>Oracle.DataProviderString </td>

<td>AssemblyName = {System.Data.OracleClient, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.OracleClient.OracleConnection; AdapterType = System.Data.OracleClient.OracleDataAdapter

</td>

<td>Example Oracle database .NET provider string </td>

</tr>

<tr>

<td>OleDB.ConnectionString </td>

<td>Provider = Microsoft.Jet.OLEDB.4.0; Data Source = openPDC.mdb </td>

<td>Example Microsoft Access (via OleDb) database connection string </td>

</tr>

<tr>

<td>OleDB.DataProviderString </td>

<td>AssemblyName = {System.Data, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.OleDb.OleDbConnection; AdapterType = System.Data.OleDb.OleDbDataAdapter

</td>

<td>Example OleDb database .NET provider string </td>

</tr>

<tr>

<td>Odbc.ConnectionString </td>

<td>Driver = {SQL Server Native Client 10.0}; Server = serverName; Database = openPDC; Uid = userName; Pwd = password

</td>

<td>Example ODBC database connection string </td>

</tr>

<tr>

<td>Odbc.DataProviderString </td>

<td>AssemblyName = {System.Data, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089}; ConnectionType = System.Data.Odbc.OdbcConnection; AdapterType = System.Data.Odbc.OdbcDataAdapter

</td>

<td>Example ODBC database .NET provider string </td>

</tr>

<tr>

<td>WebService.ConnectionString </td>

<td>https://naspi.tva.com/openPDC/LoadConfigurationData.aspx </td>

<td>Example web service connection string </td>

</tr>

<tr>

<td>XmlFile.ConnectionString </td>

<td>SystemConfiguration.xml </td>

<td>Example XML configuration file connection string </td>

</tr>

</tbody>

</table>

<br>

<h3><a name="ServiceHost_thresholdSettings"></a>thresholdSettings category</h3>

<b>Settings</b><br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>MeasurementWarningThreshold </td>

<td>100000 </td>

<td>Number of unarchived measurements allowed in any output adapter queue before displaying a warning message

</td>

</tr>

<tr>

<td>MeasurementDumpingThreshold </td>

<td>500000 </td>

<td>Number of unarchived measurements allowed in any output adapter queue before taking evasive action and dumping data

</td>

</tr>

<tr>

<td>DefaultSampleSizeWarningThreshold </td>

<td>10 </td>

<td>Default number of unpublished samples (in seconds ) allowed in any action adapter queue before displaying a warning message

</td>

</tr>

</tbody>

</table>

<br>

<hr>

<h2><a name="TcpServer"></a>TcpServer</h2>

<b>Default category</b><br>

<span class="codeInline">communicationServer</span><br>

<br>

<b>Settings</b><br>

This section also includes settings from <a href="#ServerBase">ServerBase</a>.<br>

<br>

<table>

<tbody>

<tr>

<th>Name </th>

<th>Default Value </th>

<th>Description </th>

</tr>

<tr>

<td>PayloadAware </td>

<td>False </td>

<td>True if payload boundaries are to be preserved during transmission, otherwise False.

</td>

</tr>

</tbody>

</table>

<br>

<br>

<b>Overridden values</b><br>

<table>

<tbody>

<tr>

<th>Source </th>

<th>Category </th>

<th>Name </th>

<th>Value </th>

</tr>

<tr>

<td>openPDC.exe.Config </td>

<td>remotingServer </td>

<td>PayloadAware </td>

<td>True </td>

</tr>

</tbody>

</table>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="6/23/2010 1:46:27 PM" LocalTimeTicks="1277325987">Jun 23, 2010 at 1:46 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 8<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Config%20File">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


