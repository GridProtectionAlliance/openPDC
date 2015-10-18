

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>openPDC v2.1 SP1 Release</title>



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

                

                <h1 class="page_title wordwrap">openPDC v2.1 SP1 Release</h1>

                

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

                    <span id="DownloadCount">321</span>

</div>

                

                <div class="metadataRow">

                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>

                    <a id="ChangesetIDAnchor" href="https://openpdc.codeplex.com/SourceControl/changeset/view/97300">97300</a>

</div>

                

</div>

        </td>

        <td valign="top">

            <div id="metadataRight" style="width: 250px;">

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Released:</span>

                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="7/30/2015 7:00:00 AM" localtimeticks="1438264800">Jul 30, 2015</span>

</div>

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Updated:</span>

                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="7/30/2015 1:59:53 PM" localtimeticks="1438289993">Jul 30, 2015</span>

                        by <a id="UpdatedByUserAnchor" href="https://www.codeplex.com/site/users/view/ritchiecarroll">ritchiecarroll</a>

</div>

                <div class="metadataRow">

                    <span id="DevStatusLabel" class="metadataItemHeader">Dev status:</span> 

                    <span id="DevStatusValue">

                    Stable

                        <img alt="Help Icon" class="helpImage" id="DevStatusHelpImage" src="https://download-codeplex.sec.s-msft.com/Images/v21031/HelpIcon.png" title="Stable: This software is believed to be ready for use">

                    

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

                var clickOnceUrl = 'https://openpdc.codeplex.com/downloads/get/clickOnce/*REPLACE*'.replace('downloads/get/clickOnce/*REPLACE*', 'downloads/get/clickOnce/' + clickOncePath);

                var fileUrl = 'https://openpdc.codeplex.com/downloads/get/0'.replace('downloads/get/0', 'downloads/get/' + downloadId);

                

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

    <img id="fileImage0" class="FileTypeImage" style="vertical-align:middle;" src="https://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">

    <a class="FileNameLink" d:fileid="1476243" d:posturl="https://openpdc.codeplex.com/releases/captureDownload" d:releaseid="615595" href="https://openpdc.codeplex.com/downloads/get/1476243" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Installs.zip</a>

<div>

        <span id="fileItemInfo0" class="SubText">

            application,

            16223K, uploaded

            <span class="smartDate dateOnly" title="7/30/2015 1:59:37 PM" localtimeticks="1438289977">Jul 30</span>

             -

            267 downloads

        </span>

</div>

</div>

</div>

        

        <div id="AllOtherFilesText">

            <h3>Other Available Downloads</h3>

</div>

        



<div id="FileListItem1" class="FileListItemDiv">

    <img id="fileImage1" class="FileTypeImage" style="vertical-align:middle;" src="https://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">

    <a class="FileNameLink" d:fileid="1476244" d:posturl="https://openpdc.codeplex.com/releases/captureDownload" d:releaseid="615595" href="https://openpdc.codeplex.com/downloads/get/1476244" id="fileDownload1" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Binaries.zip</a>

<div>

        <span id="fileItemInfo1" class="SubText">

            application,

            32389K, uploaded

            <span class="smartDate dateOnly" title="7/30/2015 1:59:38 PM" localtimeticks="1438289978">Jul 30</span>

             -

            54 downloads

        </span>

</div>

</div>

</div>

<div class="ReleaseNotesDiv">

    <h3>Release Notes</h3>

    <div id="ReleaseNotes" class="WikiContent">

        <div class="wikidoc"><h2>This is the planned release of the openPDC v2.1.120 Service Pack 1</h2>

<h3>Notes</h3>

<h4>This release adds:</h4>

<ul><li>Completeness report, that replaces existing data quality report, and a new Correctness report that will provide reasonability and validity checks on synchrophasor data based on any configured alarms with a severity of “Unreasonable” or “Latched”.</li>

<li>Configuration options to allow reports, both completeness and correctness, to be delivered via e-mail. Settings can be configured using the XML Configuration Editor.</li>

<li>Improved alarm configuration and monitoring screens to provide better usability and feedback.</li>

<li>New “CountOnlyMappedMeasurements” configuration setting for synchrophasor inputs that will only count measurements that are enabled so that disabled measurements that are not received will not count against expected measurements and skew daily report numbers.</li>

<li>An optional logging path for data gap recovery operations so that clustered implementations can use DFS replication to maintain runtime and outage log synchronization for subscriptions with automatic data recovery enabled.</li>

<li>Support for GEP sessions using ZeroMQ.</li>

<li>Message throttling in the 1.0 Historian for data with bad timestamps.</li>

<li>Optimized AF-SDK based OSI-PI adapter to always insert given point IDs from the same thread (can make older PI instances happier) - this also includes a minor improvement in connection handling.</li>

<li>Updated measurement metadata UI to do a full reload config to make sure changes are fully propagated to output adapters, e.g., flowing any updates to OSI-PI for metadata sync.</li>

<li>New &quot;TagNamePrefixRemoveCount&quot; configuration setting to the OSI-PI adapter to remove desired levels of tag name prefixes (like those acquired from a subscription, e.g., &quot;SOURCE!&quot;) from PI tag names when performing automated metadata synchronization.</li>

<li>Change of openPDC installer license to MIT.</li></ul>

<h4>This release also includes fixes that have been applied via GSF and the openPDC since the original version 2.1 release, including:</h4>

<ul><li>Issue where leaving openPDC Manager running on the home screen and connected to the openPDC service would keep allocated pinned buffers manifesting as a slow memory leak. Occurred due to use of the .NET FileSystemWatcher as a class member and parent class would not get a dispose call. In this case backup finalizer would not get called since watcher maintains a dangling reference to parent class via its internal pinned buffer. This can occur even with a properly implemented IDisposable pattern. Implemented and globally applied a  SafeFileWatcher wrapper that uses weak references to correct.</li>

<li>Removed reusable memory streams in GEP engine to allow system to properly reclaim memory resources after periods of stress.</li>

<li>Issue where OSI-PI adapter would not properly rename existing points under some conditions. Was due to fallback tag lookup procedure not properly finding associated measurement by signal ID stored in the  exdesc attribute.</li>

<li>Issue where OSI-PI points keep updating after openPDC measurements have been removed.</li>

<li>Exception while adding new phasors to input devices via the Manager.</li>

<li>Updated phasor UI to check for duplicate source indexes when adding phasors manually.</li>

<li>Confusing message in synchrophasor parser when receiving an exception related to data received on the command channel.</li>

<li>Error messages in the DataPublisher’s  UpdateCertificateChecker during reconfiguration due to null subscriber identities.</li>

<li>Issue in GSF.StringExtensions.ParseKeyValuePairs where certain character encodings would be decoded automatically by the parser.</li>

<li>Adding Macrodyne Controller config file to setup package to prevent error message at startup.</li>

<li>Issue where the TLS remoting server never properly disconnected unauthenticated clients.</li>

<li>Cleared the wait handle upon completion of any successful send operations in the TlsServer.</li>

<li>Updated the status of the TlsServer to include client send queue sizes so resource utilization can be better monitored.</li>

<li>Fixed the SubscriberStatusQuery, used on the external subscription monitoring UI screen, to properly query the TLS!DATAPUBLISHER rather than the EXTERNAL!DATAPUBLISHER.</li></ul></div><div class="ClearBoth"></div>

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


