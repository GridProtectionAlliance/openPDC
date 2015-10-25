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
<div id="ErrorPanel" class="Error" style="clear: both; font-size: 1.25em; display: none;"></div>
                
                <h1 class="page_title wordwrap">openPDC v1.4 SP2 Release</h1>
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
                    <span id="DownloadCount">2345</span>
</div>
                
                <div class="metadataRow">
                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>
                    <a id="ChangesetIDAnchor" href="http://openpdc.codeplex.com/SourceControl/changeset/view/73844">73844</a>
</div>
                
</div>
        </td>
        <td valign="top">
            <div id="metadataRight" style="width: 250px;">
                
                <div class="metadataRow">
                    <span class="metadataItemHeader">Released:</span>
                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="12/28/2011 7:00:00 AM" localtimeticks="1325084400">Dec 28, 2011</span>
</div>
                
                <div class="metadataRow">
                    <span class="metadataItemHeader">Updated:</span>
                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="2/24/2012 9:01:28 PM" localtimeticks="1330146088">Feb 24, 2012</span>
                        by <a id="UpdatedByUserAnchor" href="http://www.codeplex.com/site/users/view/mthakkar">mthakkar</a>
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
    <a class="FileNameLink" d:fileid="238624" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64388" href="http://openpdc.codeplex.com/downloads/get/238624" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Installs.zip</a>
<div>
        <span id="fileItemInfo0" class="SubText">
            application,
            28396K, uploaded
            <span class="smartDate dateOnly" title="12/28/2011 7:34:16 PM" localtimeticks="1325129656">Dec 28, 2011</span>
             -
            1851 downloads
        </span>
</div>
</div>
</div>
        
        <div id="AllOtherFilesText">
            <h3>Other Available Downloads</h3>
</div>
        
<div id="FileListItem1" class="FileListItemDiv">
    <img id="fileImage1" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">
    <a class="FileNameLink" d:fileid="316814" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64388" href="http://openpdc.codeplex.com/downloads/get/316814" id="fileDownload1" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Binaries.zip</a>
<div>
        <span id="fileItemInfo1" class="SubText">
            application,
            44918K, uploaded
            <span class="smartDate dateOnly" title="12/28/2011 7:34:17 PM" localtimeticks="1325129657">Dec 28, 2011</span>
             -
            117 downloads
        </span>
</div>
</div>
<div id="FileListItem2" class="FileListItemDiv">
    <img id="fileImage2" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">
    <a class="FileNameLink" d:fileid="322393" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64388" href="http://openpdc.codeplex.com/downloads/get/322393" id="fileDownload2" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Historian View Tool Patch for XP Systems</a>
<div>
        <span id="fileItemInfo2" class="SubText">
            application,
            74K, uploaded
            <span class="smartDate dateOnly" title="1/4/2012 7:21:08 PM" localtimeticks="1325733668">Jan 4, 2012</span>
             -
            76 downloads
        </span>
</div>
</div>
<div id="FileListItem3" class="FileListItemDiv">
    <img id="fileImage3" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">
    <a class="FileNameLink" d:fileid="337400" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64388" href="http://openpdc.codeplex.com/downloads/get/337400" id="fileDownload3" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">AdoOutputAdapter Hotfix</a>
<div>
        <span id="fileItemInfo3" class="SubText">
            application,
            24K, uploaded
            <span class="smartDate dateOnly" title="2/7/2012 3:03:14 PM" localtimeticks="1328655794">Feb 7, 2012</span>
             -
            78 downloads
        </span>
</div>
</div>
<div id="FileListItem4" class="FileListItemDiv">
    <img id="fileImage4" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">
    <a class="FileNameLink" d:fileid="340526" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64388" href="http://openpdc.codeplex.com/downloads/get/340526" id="fileDownload4" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Critical&#33; Output Stream Device Wizard Patch &#38; MS Access Fix</a>
<div>
        <span id="fileItemInfo4" class="SubText">
            application,
            525K, uploaded
            <span class="smartDate dateOnly" title="2/23/2012 2:57:01 PM" localtimeticks="1330037821">Feb 23, 2012</span>
             -
            88 downloads
        </span>
</div>
</div>
<div id="FileListItem5" class="FileListItemDiv">
    <img id="fileImage5" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">
    <a class="FileNameLink" d:fileid="346752" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64388" href="http://openpdc.codeplex.com/downloads/get/346752" id="fileDownload5" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">openPDC Manager - offline help fix</a>
<div>
        <span id="fileItemInfo5" class="SubText">
            application,
            583K, uploaded
            <span class="smartDate dateOnly" title="2/23/2012 2:53:41 PM" localtimeticks="1330037621">Feb 23, 2012</span>
             -
            75 downloads
        </span>
</div>
</div>
<div id="FileListItem6" class="FileListItemDiv">
    <img id="fileImage6" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">
    <a class="FileNameLink" d:fileid="347135" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="64388" href="http://openpdc.codeplex.com/downloads/get/347135" id="fileDownload6" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Historian Patch - Archive Files Filling Up Disk Space</a>
<div>
        <span id="fileItemInfo6" class="SubText">
            application,
            215K, uploaded
            <span class="smartDate dateOnly" title="2/24/2012 9:01:20 PM" localtimeticks="1330146080">Feb 24, 2012</span>
             -
            60 downloads
        </span>
</div>
</div>
</div>
<div class="ReleaseNotesDiv">
    <h3>Release Notes</h3>
    <div id="ReleaseNotes" class="WikiContent">
        <div class="wikidoc"><b><i>Version 1.4.210, official service pack 2 release of the openPDC</i></b><br>
<h2>This is the planned December 2011 release of the openPDC, version 1.4 SP2</h2>
<h4>This build includes the latest PMU Connection Tester, v4.2.12</h4>
<h4>SP2 Patch History:</h4>
There have been several minor updates to SP2, if you installed an older version and any of the patched items addressed below are of importance to your deployment, you can update your installation to the latest version:
<ul><li>1.4.210 - Updated PMU Connection Tester installers to v4.2.12 that include synchrophasor updates from revision 209</li>
<li>1.4.209 - Updated synchrophasor protocol parsers to to leave in any duplicate white space in labels as required in some current naming conventions. Made improvements to the ICCP file based export for TVA.</li>
<li>1.4.208 - Improved asynchronous connections on single core systems.</li>
<li>1.4.207 - Updated configuration setup wizard to properly write user settings XML for data migration utility on XP based systems.</li>
<li>1.4.206 - Updated configuration caching algorithm to create multiple backup configurations, when requested. Minor schema update to allow cascade deletes all the way down from a node level. Made all openPDC Manager grids remember last selected index after update.</li></ul>
<h4>Note that this service pack includes several schema improvements as well as support for Oracle and SQLite - as a result, a schema upgrade on your existing configuration database is required.</h4>
<h4>Update notes:</h4>
With significant duration performance and usability improvements, openPDC 1.4 SP2 represents a major upgrade:
<ul><li>Completely new user interface experience
<ul><li>Designed for flexibility</li>
<li>Allows addition of new end-user custom UI screens</li>
<li>Every screen has been revisited for usability</li>
<li>Manger UI now has back and forward buttons</li></ul></li>
<li>Temporal streaming data playback support
<ul><li>Allows historical playback through the native subscription services</li>
<li>openPDC Manager will now automatically support playback when a local historian is defined</li>
<li>All adapters can now be setup to connect on demand (i.e., to start only when needed)</li></ul></li>
<li>Many framework level optimizations
<ul><li>A shared memory buffer pool and new parse / generate scheme was implemented to reuse internal buffers instead of always dynamically creating new ones which has greatly reduced the MB/sec of memory allocations needed.</li>
<li>Several optimizations have been made to the routing layer and new lock-free concurrent dictionaries have replaced older standard dictionaries that required critical section monitors which has reduced overall lock contention.</li>
<li>In places where synchronization was critical but overall lock time was low, new spinning locks have been implemented to reduce thread context switching.</li></ul></li>
<li>Various improvements to the built-in historian 
<ul><li>The API now supports multiple points per call</li>
<li>Returned data is now sorted by time then point</li>
<li>New post based request method has been added web service interface</li>
<li>Added a new historian trending tool to view historical data</li>
<li>The historian playback utility has been updated and improved for usability</li></ul></li>
<li>Updates to database schema
<ul><li>Several improvements and corrections have been made to the schema</li>
<li>Additional, support for both Oracle and SQLite have been added</li>
<li>SQLite can be used in both 64-bit and 32-bit deployments without the need to install any other database software - great for substation style deployments</li></ul></li>
<li>Other miscellaneous improvements include
<ul><li>Added dual-stack socket support such that IPv6 listening ports can also accept IPv4 connections</li>
<li>Improved error messages for better interpretation of exceptions</li>
<li>Keyboard / menu shortcuts added to openPDC Manager</li>
<li>Service health, status and configuration are all displayed on the home screen</li>
<li>Added a virtual input adapter to allow creation placeholder input devices</li>
<li>Several hundred bug fixes and closed work items</li></ul></li></ul></div><div class="ClearBoth"></div>
</div>
</div>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
