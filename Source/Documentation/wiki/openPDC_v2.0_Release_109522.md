

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>openPDC v2.0 Release</title>



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

<div id="ErrorPanel" class="Error" style="clear: both; font-size: 1.25em; display: none;"></div>

                

                <h1 class="page_title wordwrap">openPDC v2.0 Release</h1>



<table id="ReleaseMetaDataBox" cellspacing="0" cellpadding="0" border="0" style="border: 1px solid #c0c0c0; margin-top: 10px;">

    <tr>

        <td valign="top" style="border-right: 1px solid #c0c0c0;">

            <div id="metadataLeft" style="width: 250px;">

            

                <div class="metadataRow">

                    <span class="metadataItemHeader">Rating:</span>

                

                    <span id="NoReviewsLabel">No reviews yet</span>

                    

</div>

                

                <div class="metadataRow">

                    <span id="DownloadsCountLabel" class="metadataItemHeader">Downloads:</span>

                    <span id="DownloadCount">3005</span>

</div>

                

                <div class="metadataRow">

                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>

                    <a id="ChangesetIDAnchor" href="http://openpdc.codeplex.com/SourceControl/changeset/view/91134">91134</a>

</div>

                

</div>

        </td>

        <td valign="top">

            <div id="metadataRight" style="width: 250px;">

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Released:</span>

                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="7/25/2014 7:00:00 AM" localtimeticks="1406296800">Jul 25, 2014</span>

</div>

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Updated:</span>

                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="7/25/2014 7:36:18 PM" localtimeticks="1406342178">Jul 25, 2014</span>

                        by <a id="UpdatedByUserAnchor" href="http://www.codeplex.com/site/users/view/ritchiecarroll">ritchiecarroll</a>

</div>

                <div class="metadataRow">

                    <span id="DevStatusLabel" class="metadataItemHeader">Dev status:</span> 

                    <span id="DevStatusValue">

                    Stable

                        <img alt="Help Icon" class="helpImage" id="DevStatusHelpImage" src="http://download-codeplex.sec.s-msft.com/Images/v21031/HelpIcon.png" title="Stable: This software is believed to be ready for use">

                    

                    </span>

</div>

                

</div>

        </td>

    </tr>

</table>

<script type="text/javascript">

    //function isPlatformInstallerAgent() {

    //    return navigator.userAgent.toLowerCase().indexOf('platform-installer/') != -1;

    //}



    function downloadFile(link, userClick, alreadyLoaded) {

        if (userClick)

            return $.release.fn.downloadFile(link);



        if (!alreadyLoaded) {

            var downloadId = $getQuerystring("DownloadId");

            if (!downloadId)

                downloadId = getIdFromFragment();

            if (downloadId) {

                var clickOncePath = $("a[fileId='" + downloadId + "']").attr('d:clickOncePath');

                var clickOnceUrl = 'http://openpdc.codeplex.com/downloads/get/clickOnce/*REPLACE*'.replace('downloads/get/clickOnce/*REPLACE*', 'downloads/get/clickOnce/' + clickOncePath);

                var fileUrl = 'http://openpdc.codeplex.com/downloads/get/0'.replace('downloads/get/0', 'downloads/get/' + downloadId);

                

                window.location = clickOncePath ? clickOnceUrl : fileUrl;

            }

        }



        return false;

    }



    function getIdFromFragment() {

        var path = document.location.toString();



        if (path.match('#')) {

            var fileID = '#' + path.split('#')[1];



            if (fileID.toLowerCase().indexOf("downloadid=") > 0) {

                fileID = fileID.split("=");



                if (fileID[1].length > 0) {

                    return fileID[1];

                }

            }

        }

    }

</script>

<div class="ReleaseNotesDiv">

    <a id="ReleaseFiles"></a>

    

        <div id="recommendedFileDiv">

            <h3>Recommended Download</h3>

            



<div id="FileListItem0" class="FileListItemDiv">

    <img id="fileImage0" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">

    <a class="FileNameLink" d:fileid="705191" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="109522" href="http://openpdc.codeplex.com/downloads/get/705191" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Installs.zip</a>

<div>

        <span id="fileItemInfo0" class="SubText">

            application,

            16386K, uploaded

            <span class="smartDate dateOnly" title="7/25/2014 7:33:27 PM" localtimeticks="1406342007">Jul 25, 2014</span>

             -

            2345 downloads

        </span>

</div>

</div>

</div>

        

        <div id="AllOtherFilesText">

            <h3>Other Available Downloads</h3>

</div>

        



<div id="FileListItem1" class="FileListItemDiv">

    <img id="fileImage1" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">

    <a class="FileNameLink" d:fileid="705192" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="109522" href="http://openpdc.codeplex.com/downloads/get/705192" id="fileDownload1" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">GEP Subscription Tester - Update 2.zip</a>

<div>

        <span id="fileItemInfo1" class="SubText">

            application,

            73107K, uploaded

            <span class="smartDate dateOnly" title="11/14/2013 2:27:31 PM" localtimeticks="1384468051">Nov 14, 2013</span>

             -

            309 downloads

        </span>

</div>

</div>



<div id="FileListItem2" class="FileListItemDiv">

    <img id="fileImage2" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">

    <a class="FileNameLink" d:fileid="714515" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="109522" href="http://openpdc.codeplex.com/downloads/get/714515" id="fileDownload2" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Binaries.zip</a>

<div>

        <span id="fileItemInfo2" class="SubText">

            application,

            31574K, uploaded

            <span class="smartDate dateOnly" title="7/25/2014 7:33:29 PM" localtimeticks="1406342009">Jul 25, 2014</span>

             -

            351 downloads

        </span>

</div>

</div>

</div>

<div class="ReleaseNotesDiv">

    <h3>Release Notes</h3>

    <div id="ReleaseNotes" class="WikiContent">

        <div class="wikidoc"><h2>This is the official release version of the <i>openPDC v2.0</i>. </h2>

<h3><i>Note recent update to version 2.0.166 - see changes below.</i></h3>

<h4>We recommend all openPDC installations be updated to this new version. This is considered a major release of the openPDC with very large investments made into improving the performance, security and stability of the system (see details below).</h4>

<h4>Version 2.0.166 - 07/25/2014</h4>

Changes since version 2.0.155:<br>

<ul><li>Fixed Data Migration Utility when migrating older schemas - if you have had issues migrating your configuration, upgrade to version 2.0.166</li>

<li>Added OSI-PI Historian Adapters to the installation package - this includes latest meta-data sync and parallel processing optimizations</li>

<li>Added support for <a href="http://openpdc.codeplex.com/wikipage?title=Custom%20Point%20Tag%20Naming%20Convention">custom tag naming expressions</a> so that end user can control format of tag names</li>

<li>Modified TLS implementations to log a security warning to the EventLog when any TLS protocol is enabled in the configuration other than TLS version 1.2</li>

<li>Adjusted local historian input adapter to accommodate future timestamps as end-time for reads such that as new data is added reader can continue to replay data from the historian. This accommodates a situation like replaying data continuously from the archive in modes such as 30 day old data</li>

<li>Fixed a bug in TimeSeriesStartupOperations that caused it to always delete and rewrite publisher and subscriber statistics in the database</li>

<li>Corrected issue with multiple temporal configuration extractions when using same cached temporal configuration</li>

<li>Modified open procedure for read-only access to wait until roll-over has completed before opening primary archive or timing out after 30 seconds</li>

<li>Corrected issue with SEL Fast Message to ignore duplicate 0xFF values in streaming data that can occur with data transmission over Ethernet when Telnet protocol is being used</li>

<li>Added run-time logs to primary service and each data subscriber</li>

<li>Modified alarm logic to improve performance of the alarm engine</li>

<li>Added an output adapter for the <a href="http://influxdb.com/">InfluxDB</a> time-series historian</li>

<li>Updated <a href="https://pmuconnectiontester.codeplex.com/releases/view/122542">PMU Connection Tester</a> to the GSF based version 4.5.5</li></ul>

<br>Changes since version 2.0.133 (abbreviated):<br>

<ul><li>Fixed an issue in FrameImageParserBase that was pooling objects in memory which were no longer in use (major issue correction)</li>

<li>Modified users of the AsyncDoubleBufferedQueue to use the new signalling mechanism of the DoubleBufferedQueue rather than polling (faster)</li>

<li>Fixed ConcentratorBase so it would work at extremely high frame rates.</li>

<li>Implemented configuration augmentation and conditional data operations for database configurations to speed up ReloadConfig for large databases (major optimization)</li>

<li>Fixed the Output Device Wizard in the Manager so that removing devices from an output stream does not take an unreasonably long amount of time (Manager scalability)</li>

<li>Added time-quality flags measurement, for phasor protocols that support this, that is associated with a connection (e.g., directly connected device or concentrator). Quality flags can then archived and/or applied to an output stream. Output stream time-quality can be a measurement derived from a hardware clock</li>

<li>Converted MeasurementKey to a class and provided more explicit factory functions for creating and/or looking up measurement keys (major optimization)</li>

<li>Fixed issues with device updates related to renaming, changing historian and changing company with associated measurement information roll down (edge case fixes)</li>

<li>Updated high-volume status message suppression logic to work better under load</li>

<li>Fixed a bug that was causing the historian to attempt to offload the active file when offloading is enabled</li>

<li>Synchronized configuration file operations to help avoid possible race conditions when dealing with new configurations</li>

<li>Added command functions to data publisher for easier status updates on temporal sessions: EnumerateTemporalClients and GetTemporalStatus.</li>

<li>Updated DataMigrationUtility to perform identity inserts as a faster way of spanning large auto-inc gaps in databases that support this.</li>

<li>Updated SQL Server schema to include WITH (NOLOCK) in views to help reduce deadlock victim errors.</li>

<li>Adjusted FRACESEC values for IEEE C37.118 and IEC 61850-90-5 timestamps in output streams to be more precise when a configuration frame is available.</li>

<li>Modified adapter initialization to operate on a small number of independent threads to optimize system start-up at scale.</li>

<li>Fixed installer action for user authentication when authenticating a managed service account</li>

<li>Improved password input for remote console applications to support backspace and escape keys for correcting mistakes when typing passwords</li>

<li>Fixed issue writing COMTRADE FRACSEC values when no subsequent digitals are being exported</li>

<li>Modified export and trend functions to &quot;re-open&quot; archive on operation such that latest point data can be loaded (basically forcing a data-block allocation table reload)</li>

<li>Updated data quality reporting screen to list all cached reports and better manage pending reports</li>

<li>Fixed timestamp alignment in COMTRADE export to fill gaps where data may be missing</li>

<li>New reporting engine for generating daily data quality reports</li>

<li>Added logic to grant permissions to existing users when migrating databases using the Configuration Setup Utility</li>

<li>Added additional security to certain remote console commands</li>

<li>Updated the openPDC Manager to be able to authenticate domain users while running as local user</li>

<li>Improved openPDC Manager remote configuration process</li></ul>

<br>This new version of the openPDC has been completely overhauled as a .NET 4.5 application built on the new integrated <a href="https://gsf.codeplex.com/">Grid Solutions Framework</a> (GSF). The Grid Solutions Framework is a combination of the <a href="https://tvacodelibrary.codeplex.com/">TVA Code Library</a> and <a href="http://timeseriesframework.codeplex.com/">Time-series Framework</a> projects on codeplex built using the new .NET 4.5 framework.  In creating the GSF, new code components have been added and all libraries have been refactored to make this integrated framework more secure and significantly better performing.<br>

<h3>Upgrade Notes</h3>

Upgrading to the 2.0 version of the openPDC will require .NET 4.5 to be installed and currently only a 64-bit installation is supported. During upgrade you must migrate your existing configuration to the new 2.0 configuration schema (this includes the release candidates). The Data Migration Utility included with the 2.0 version of the openPDC now supports <i><b>all database types</b></i> and can even migrate from one database type to another (e.g., SQLite to Oracle). OLE DB style connections are no longer required.<br><br>The release version of the openPDC 2.0 has been through extensive testing and is ready to use. The 2.0 build has all the improvements and bug fixes included in openPDC 1.5 SP1 plus a multitude of others. Upgrades to version 2.0 from older openPDC versions have been well tested and are fully supported. Note that downgrades back to 1.5 will require some manual intervention - please check with GPA staff on required steps you should need to downgrade.<br>

<h3>New Features / Improvements</h3>

Included with the openPDC 2.0 installation is a new tool called the <b>No Internet Fix Utility</b>. As its name suggests, you should run this utility when deploying the openPDC inside an environment that does not have Internet access. This tool will ensure all TLS/SSL style connections now required by the openPDC startup quickly by skipping timeouts even without Internet availability.<br><br>The <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/GEP_Subscription_Tester.md">Gateway Exchange Protocol &#40;GEP&#41; Subscription Tester</a> has been provided to validate internal subscription style connections. This is a multi-platform application was built using the <a href="http://gsf.codeplex.com/">Grid Solutions Framework</a> Unity subscription API with deployment binaries or installers for Windows, Mac, Linux and Android devices.<br><br>Listed below is a high-level summary of the various fixes and improvements included in this new 2.0 release, see the <a href="http://openpdc.codeplex.com/SourceControl/list/changesets">openPDC change log</a> and the <a href="https://gsf.codeplex.com/SourceControl/list/changesets">GSF change log</a> for complete details:<br>

<ul><li><i>Performance</i>

<ul><li>Major system performance improvements using asynchronous double-buffered processing algorithms</li>

<li>Nearly 100% of system calls are now fully asynchronous </li>

<li>GEP Compression reduces bandwidth utilization</li>

<li>High speed alarm processing for thousands of defined alarms</li>

<li>Buffer and stream pooling to reduce GC loading</li>

<li>Enabling of .NET 4.5 concurrent/server based GC to reduce CPU</li></ul></li>

<li><i>Security</i>

<ul><li>Security has been integrated into all sub-system components</li>

<li>Calls  to custom invokable adapter methods now respect role based security</li>

<li>Transport layer security (TLS) is now enabled over AD integrated security by default for all remote console based connections (including openPDC Manager)</li>

<li>TLS library is integrated as part of GSF base communications library and available in GEP</li>

<li>Services now use either local NT virtual service or AD managed accounts to limit local machine access</li>

<li>File permissions access for service access is now limited to installation directory</li></ul></li>

<li><i>Improvements</i>

<ul><li>Updated communications library has been extensively tested and debugged in a very wide set of deployment use cases</li>

<li>COMTRADE exports from Historian Trending Tool (includes support for  Annex H of IEEE C37.111-2010)</li>

<li>Native OSI-PI input and output support              </li>

<li>Vastly improved IP multicast support</li>

<li>Statistics engine is now easier to extend - allowing simple addition of stats to custom adapters</li>

<li>GEP subscription API&#39;s now include full support for the Unity platform (mono based), plus GSF based updates to C++/Java GEP libraries</li>

<li>Many hundreds of other bug fixes and improvements</li></ul></li></ul>

<br>Thanks!<br>Ritchie</div><div class="ClearBoth"></div>

</div>

</div>

<div id="ReviewsPanel">

    <a id="ReviewsAnchor"></a>

    <div id="ReviewsDivisionHeader">

        <h2>Reviews for this release</h2>

</div>

    <div id="Reviews">

        No reviews for this release.

</div>

</div>

</div>

<div id="footer">

<hr />



</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


