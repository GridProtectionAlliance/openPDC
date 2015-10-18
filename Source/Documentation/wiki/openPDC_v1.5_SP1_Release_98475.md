

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>openPDC v1.5 SP1 Release</title>



<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body>

<h1><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>

<hr />

<!--HtmlToGmd.Body-->

<div id="NavigationMenu">

<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">

<tr>

<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->



<div class="WikiContent">

<div id="ErrorPanel" class="Error" style="clear: both; font-size: 1.25em; display: none;"></div>

                

                <h1 class="page_title wordwrap">openPDC v1.5 SP1 Release</h1>



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

                    <span id="DownloadCount">1336</span>

</div>

                

                <div class="metadataRow">

                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>

                    <a id="ChangesetIDAnchor" href="http://openpdc.codeplex.com/SourceControl/changeset/view/87162">87162</a>

</div>

                

</div>

        </td>

        <td valign="top">

            <div id="metadataRight" style="width: 250px;">

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Released:</span>

                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="9/13/2013 7:00:00 AM" localtimeticks="1379080800">Sep 13, 2013</span>

</div>

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Updated:</span>

                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="11/25/2013 2:39:48 PM" localtimeticks="1385419188">Nov 25, 2013</span>

                        by <a id="UpdatedByUserAnchor" href="http://www.codeplex.com/site/users/view/staphen">staphen</a>

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

    <a class="FileNameLink" d:fileid="557045" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="98475" href="http://openpdc.codeplex.com/downloads/get/557045" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Installs &#40;rev 2&#41;.zip</a>

<div>

        <span id="fileItemInfo0" class="SubText">

            application,

            173582K, uploaded

            <span class="smartDate dateOnly" title="11/15/2013 6:23:26 PM" localtimeticks="1384568606">Nov 15, 2013</span>

             -

            1282 downloads

        </span>

</div>

</div>

</div>

        

        <div id="AllOtherFilesText">

            <h3>Other Available Downloads</h3>

</div>

        



<div id="FileListItem1" class="FileListItemDiv">

    <img id="fileImage1" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">

    <a class="FileNameLink" d:fileid="758501" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="98475" href="http://openpdc.codeplex.com/downloads/get/758501" id="fileDownload1" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Binaries &#40;rev 2&#41;.zip</a>

<div>

        <span id="fileItemInfo1" class="SubText">

            application,

            190058K, uploaded

            <span class="smartDate dateOnly" title="11/15/2013 6:23:16 PM" localtimeticks="1384568596">Nov 15, 2013</span>

             -

            27 downloads

        </span>

</div>

</div>



<div id="FileListItem2" class="FileListItemDiv">

    <img id="fileImage2" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">

    <a class="FileNameLink" d:fileid="761966" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="98475" href="http://openpdc.codeplex.com/downloads/get/761966" id="fileDownload2" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Password Expiration Patch.zip</a>

<div>

        <span id="fileItemInfo2" class="SubText">

            application,

            19K, uploaded

            <span class="smartDate dateOnly" title="11/25/2013 2:39:34 PM" localtimeticks="1385419174">Nov 25, 2013</span>

             -

            27 downloads

        </span>

</div>

</div>

</div>

<div class="ReleaseNotesDiv">

    <h3>Release Notes</h3>

    <div id="ReleaseNotes" class="WikiContent">

        <div class="wikidoc">This is the official release of the version 1.5 Service Pack 1 of the openPDC - revision 2.<br><br>Version 1.5.247 - 09/13/2013<br><br><i>Note that revision 2 includes a few GEP meta-data synchronization fixes over the initial release of service pack 1, including updated forward compatibility with openPDC 2.0 instances. If you intend on connecting to SIEGate and/or openPDC 2.0 with an instance of openPDC 1.5 - this revision is recommended.</i><br><br>Latest version of the <a href="https://pmuconnectiontester.codeplex.com/releases/view/109471">PMU Connection Tester</a>, v4.4.0, is included with this installation.<br><br>Native OSI-PI input and output supported in this release. The OSI-PI adapters will only be available when the OSI-PI SDK is installed on the system.<br><br>This build includes a new tool called the <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/GEP_Subscription_Tester.md">Gateway Exchange Protocol &#40;GEP&#41; Subscription Tester</a> used to validate internal subscription style connections. This is a multi-platform application built using the <a href="https://gsf.codeplex.com/">Grid Solutions Framework</a> Unity subscription API with deployment binaries or installers for Windows, Mac, Linux and Android devices.<br><br>Listed below are some of the various fixes and improvements included in the service pack, see <a href="https://openpdc.codeplex.com/SourceControl/list/changesets">change log</a> for complete details.<br>

<ul><li><i>New since release candidate:</i> Improvements and operational fixes to the UTK F-NET, BPA PDCstream and Macrodyne protocols as well as fixes for various digital fault recorders and power quality meters </li>

<li>Vastly improved IP multicast support</li>

<li>Statistics engine is now easier to extend - allowing simple addition of stats to custom adapters</li>

<li>Optimized alarm processing in the alarm adapter.</li>

<li>Replaced all blocking collections with asynchronous loop pattern (implemented via new AysncQueue&lt;T&gt; and updated ProcessQueue&lt;T&gt;) to improve performance.</li>

<li>Fixed various usability issues on the Alarms page.</li>

<li>Manager now avoids repeated error messages when the database is not available.</li>

<li>Fixed manager issue where new data entry saved in the wrong node. </li>

<li>Updated ProcessQueue implementations to take advantage of now lock-free async functionality.</li>

<li>Added option for cross-domain access support for Sliverlight and Flash application accessing the openHistorian web service.</li>

<li>Added maximum send queue size to TCP and UDP clients and servers.</li>

<li>Added send-to capabilities to UDP client.</li>

<li>Fixed TCP/UDP send operations to break large messages into multiple socket send operations.</li>

<li>Fixed an issue that allowed the TCP client to attempt connections after it had already been disposed.</li>

<li>Fixed exit condition of UdpServer send threads.</li>

<li>Fixed issue requiring SocketAsyncEventArgs allocations for UDP send operations.</li>

<li>Fixed race condition between send thread and send handler, and allowed for send handler to be called synchronously from send thread.</li>

<li>Fixed unlikely race condition that would cause send operations on sockets to stop indefinitely.</li>

<li>Improved socket layer error handling.</li>

<li>In TcpClient, set connect wait handle on error and disconnect so that users waiting on synchronous connect operations that error out can continue.</li>

<li>Added buffer parsed event to binary image parser base to be used for flow control with protocols that return very large and/or very fast buffers.</li>

<li>Added code modification from ALSTOM to specify a time duration for log files and automatically purge old logs.</li>

<li>Added maxSendQueueSize connection string parameter to the TCP and UDP clients and servers, which overrides the configuration file parameter if it exists.</li>

<li>Corrected issue with possible overlapping log files in high volume logging situations.</li>

<li>Fixed DataExtensions.AddParametersWithValues to allow for duplicate parameters in the query string.</li>

<li>Fixed issue in ProcessQueue causing it to stop processing indefinitely.</li>

<li>Fixed value calculation in SineWave class of TVA.NumericalAnalysis.</li>

<li>Optimized implementation of MultiSourceFrameImageParserBase using concurrent dictionaries.</li>

<li>Updated multi-source frame image parser to use the reusable object pool and buffer pool as an optimization.</li>

<li>Added authentication success or failure logging to the Windows event log for the AdoSecurityProvider.</li>

<li>Corrected issue when authenticating successfully with AD but having no ADO security database roles defined.</li>

<li>Updated ADO security provider to provide logging distinguish between pass-through authentication and user acquired password authentication and make sure each is logged. Also corrected logging failure when attempting to login as an undefined user.</li>

<li>Updated the ADO security provider to always log to the Windows event log, success or failure - with reason when available, for user authentication attempts.</li>

<li>Corrected Macrodyne-G sub-second timestamps.</li>

<li>Changed operation of keepCommandChannelOpen=false to be triggered on receipt of configuration frame.</li>

<li>Updated manager to properly import alternate command channel when updating device configurations via the input wizard.</li>

<li>Disabled step 1 of the input wizard when updating existing device configurations.</li>

<li>Devices on the measurements page are now restricted to the current node.</li>

<li>Added advanced search functionality to the Measurements page in the openPDC Manager.</li>

<li>Added error log viewer to main menu.</li>

<li>Fixed unlikely race condition in FrameParserBase that would cause it to stop processing frame buffer images indefinitely.</li>

<li>Updated local input adapter to work for both temporal and real-time modes such that this adapter can now also be used as a primary data source to replay archived synchrophasor data for analysis.</li>

<li>Updated archive reader to only manage one roll-over activity at once.</li>

<li>In the device wizard, fixed request configuration when updating the configuration of existing devices.</li>

<li>Updated PhasorMeasurementUserControl to save settings on application exit.</li>

<li>Modified start timer thread in the schedule manager to be a background thread so that the system can shut down properly before the timer is started.</li>

<li>Updated process queue to handle rare situations where collection may be modified during a context switch between GetEnumerator and MoveNext when using Linq expressions.</li>

<li>Modified input wizard in the openPDC Manager to work harder to retain existing phasor and measurement configurations when updating an existing configuration.</li>

<li>Updated openHistorian tools to better handle foreign date formats by auto-converting to US date format.</li>

<li>Updated subscribers view model for open PG/PDC manager to issue a configuration reload rather than an initialize when authorized measurements are updated to avoid dropping existing connections.</li></ul>

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


