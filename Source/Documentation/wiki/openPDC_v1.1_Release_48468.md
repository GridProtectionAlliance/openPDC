
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
                <h1 class="page_title wordwrap">August 2010 openPDC v1.2 Release</h1>
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
                    <span id="DownloadCount">293</span>
</div>
                
                <div class="metadataRow">
                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>
                    <a id="ChangesetIDAnchor" href="http://openpdc.codeplex.com/SourceControl/changeset/view/57499">57499</a>
</div>
                
</div>
        </td>
        <td valign="top">
            <div id="metadataRight" style="width: 250px;">
                
                <div class="metadataRow">
                    <span class="metadataItemHeader">Released:</span>
                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="9/15/2010 7:00:00 AM" localtimeticks="1284559200">Sep 15, 2010</span>
</div>
                
                <div class="metadataRow">
                    <span class="metadataItemHeader">Updated:</span>
                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="9/23/2010 8:43:52 PM" localtimeticks="1285299832">Sep 23, 2010</span>
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
    <a class="FileNameLink" d:fileid="151227" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="48468" href="http://openpdc.codeplex.com/downloads/get/151227" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">openPDCSetup.zip</a>
<div>
        <span id="fileItemInfo0" class="SubText">
            application,
            18731K, uploaded
            <span class="smartDate dateOnly" title="9/21/2010 8:27:42 PM" localtimeticks="1285126062">Sep 21, 2010</span>
             -
            293 downloads
        </span>
</div>
</div>
</div>
        
</div>
<div class="ReleaseNotesDiv">
    <h3>Release Notes</h3>
    <div id="ReleaseNotes" class="WikiContent">
        <div class="wikidoc">This is the August 2010 release build of the openPDC, version 1.2.40<br><br>Note that this version of the openPDC has been upgraded to work with .NET 4.0. Make sure your system has .NET 4.0 before installation:<br><br><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=9cfb2d51-5ff4-4491-b0e5-b386f32c0992&amp;displaylang=en">Microsoft .NET Framework 4 (Web Installer)</a><br><br><a href="http://www.youtube.com/watch?v=TmuQD3dluxM">See our YouTube video for quick installation of the openPDC August 2010 Release</a><br><br>The August release has three improvement focus areas:<br>
<ul><li>Performance</li>
<li>Stability</li>
<li>Simplicity</li></ul>
<br>A multitude of performance and stability enhancements are included with this release - see the deep <a href="http://openpdc.codeplex.com/SourceControl/list/changesets">change log</a> for details. Additional performance and stability benefits, including fundamental multi-threading improvements, come from the upgrade to .NET 4.0.<br><br>Simplicity was targeted at both ease-of-use in the user interface and easier installation. This version of the openPDC comes with a completely new, tightly integrated GUI based version of the openPDC manager. The GUI manager automatically installs along with the openPDC so no further setup or installation will be required to use the system. The web based openPDC manager is still available for web based deployments where desired, but this is now an optional component and the more complicated IIS installation can be turned over to IT staff.<br><br><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/August_2010_version_1_2_release_Features.files/openPDCManager.png"></div><div class="ClearBoth"></div>
</div>
</div>
</div>
<div id="footer">
<hr />
Migrated from <a href="http://openpdc.codeplex.com/releases/view/48468">CodePlex</a> Oct 8, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
