

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>openPDC v1.4 SP1 Release</title>



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

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->



<div class="WikiContent">

<div id="ErrorPanel" class="Error" style="clear: both; font-size: 1.25em; display: none;"></div>

                

                <h1 class="page_title wordwrap">openPDC v1.4 SP1 Release</h1>



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

                    <span id="DownloadCount">1632</span>

</div>

                

                <div class="metadataRow">

                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>

                    <a id="ChangesetIDAnchor" href="http://openpdc.codeplex.com/SourceControl/changeset/view/66479">66479</a>

</div>

                

</div>

        </td>

        <td valign="top">

            <div id="metadataRight" style="width: 250px;">

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Released:</span>

                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="5/2/2011 7:00:00 AM" localtimeticks="1304344800">May 2, 2011</span>

</div>

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Updated:</span>

                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="5/2/2011 3:40:45 PM" localtimeticks="1304376045">May 2, 2011</span>

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

    <a class="FileNameLink" d:fileid="228048" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64387" href="http://openpdc.codeplex.com/downloads/get/228048" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">openPDC v1.4 SP1 Setup</a>

<div>

        <span id="fileItemInfo0" class="SubText">

            application,

            31692K, uploaded

            <span class="smartDate dateOnly" title="5/2/2011 3:33:56 PM" localtimeticks="1304375636">May 2, 2011</span>

             -

            1321 downloads

        </span>

</div>

</div>

</div>

        

        <div id="AllOtherFilesText">

            <h3>Other Available Downloads</h3>

</div>

        



<div id="FileListItem1" class="FileListItemDiv">

    <img id="fileImage1" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/Documentation.gif" alt="Documentation">

    <a class="FileNameLink" d:fileid="233561" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64387" href="http://openpdc.codeplex.com/downloads/get/233561" id="fileDownload1" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">openPDC v1.4 SP1 Upgrade Notes</a>

<div>

        <span id="fileItemInfo1" class="SubText">

            documentation,

            211K, uploaded

            <span class="smartDate dateOnly" title="5/2/2011 3:33:58 PM" localtimeticks="1304375638">May 2, 2011</span>

             -

            311 downloads

        </span>

</div>

</div>

</div>

<div class="ReleaseNotesDiv">

    <h3>Release Notes</h3>

    <div id="ReleaseNotes" class="WikiContent">

        <div class="wikidoc">Version <i>1.4.110</i> - SP1 release of the openPDC

<h2>This is the official production release of the version 1.4 Service Pack 1 of the openPDC - May 2011.</h2>

<b>As a significant overall performance improvement</b>, this version includes an optional (but enabled by default) non-broadcast method of directly routing measurements within the openPDC (per suggestions by Tim Yardley and Erich Heine of the University of Illinois at Urbana-Champaign) which will provide at least a 50% reduction in CPU utilization in most configurations. Performance improvements will be greater with increased internal routing.<br><br>Other improvements include:<br>

<ul><li>Added ProcessByReceivedTimestamp property to ConcentratorBase so applications using class can sort and publish measurements by received time which is useful in scenarios where very large volumes of data need concentration, but not necessarily in real-time, such as, reading data from a file where you want it sorted and processed as fast as possible as per suggestion by Chuanlin Zhao of Washington State University - this includes a new connection string setting (&quot;processByReceivedTimestamp&quot;) to set enable processing option (defaults to False).</li>

<li>Implemented an &quot;update configuration&quot; per device connection, accessible via link on browse device screen, to simplify use case of updating a connection&#39;s modeled configuration.</li>

<li>Added a secure offline user data cache to allow caching of key user information (e.g., user&#39;s group list) when user is disconnected from domain such that when role based rights are based on active directory group associations (i.e., where openPDC group name matches AD group name), rights upon login will still be active when logged in with cached Windows credentials without domain access.</li>

<li>Added historical time tracking to the time-series framework&#39;s IFrame and IMeasurement interfaces for both received and published timestamps (used by ProcessByReceivedTimestamp).</li>

<li>Made audit log database triggers optional so that openPDC Manager can run faster when auditing is not needed.</li></ul>

<br>Service Pack 1 also corrects several issues reported by some users with Version 1.4 of the openPDC, see upgrade notes for details.<br>

<h4><i>Note: installers updated on May2, 2011 to include a few more corrections:</i></h4>

<ul><li><a href="http://openpdc.codeplex.com/workitem/8571">Local in-process historian requires manual initialize before it will pick-up points from newly added device</a></li>

<li><a href="http://openpdc.codeplex.com/workitem/8570">CPU spike on startup</a></li>

<li><a href="http://openpdc.codeplex.com/workitem/8572">ID not displayed on manage measurements screen.</a></li></ul></div><div class="ClearBoth"></div>

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


