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
                
                <h1 class="page_title wordwrap">PMU Connection Tester v4.4.0</h1>
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
                    <span id="DownloadCount">1039</span>
</div>
                
                <div class="metadataRow">
                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>
                    <a id="ChangesetIDAnchor" href="http://pmuconnectiontester.codeplex.com/SourceControl/changeset/view/101795">101795</a>
</div>
                
</div>
        </td>
        <td valign="top">
            <div id="metadataRight" style="width: 250px;">
                
                <div class="metadataRow">
                    <span class="metadataItemHeader">Released:</span>
                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="7/16/2013 7:00:00 AM" localtimeticks="1373983200">Jul 16, 2013</span>
</div>
                
                <div class="metadataRow">
                    <span class="metadataItemHeader">Updated:</span>
                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="5/23/2014 6:08:07 PM" localtimeticks="1400893687">May 23, 2014</span>
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
                var clickOnceUrl = 'http://pmuconnectiontester.codeplex.com/downloads/get/clickOnce/*REPLACE*'.replace('downloads/get/clickOnce/*REPLACE*', 'downloads/get/clickOnce/' + clickOncePath);
                var fileUrl = 'http://pmuconnectiontester.codeplex.com/downloads/get/0'.replace('downloads/get/0', 'downloads/get/' + downloadId);
                
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
    <a class="FileNameLink" d:fileid="704847" d:posturl="http://pmuconnectiontester.codeplex.com/releases/captureDownload" d:releaseid="109471" href="http://pmuconnectiontester.codeplex.com/downloads/get/704847" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Installers.zip</a>
<div>
        <span id="fileItemInfo0" class="SubText">
            application,
            9879K, uploaded
            <span class="smartDate dateOnly" title="7/16/2013 1:07:05 PM" localtimeticks="1374005225">Jul 16, 2013</span>
             -
            962 downloads
        </span>
</div>
</div>
</div>
        
        <div id="AllOtherFilesText">
            <h3>Other Available Downloads</h3>
</div>
        
<div id="FileListItem1" class="FileListItemDiv">
    <img id="fileImage1" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">
    <a class="FileNameLink" d:fileid="704848" d:posturl="http://pmuconnectiontester.codeplex.com/releases/captureDownload" d:releaseid="109471" href="http://pmuconnectiontester.codeplex.com/downloads/get/704848" id="fileDownload1" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Binaries.zip</a>
<div>
        <span id="fileItemInfo1" class="SubText">
            application,
            2269K, uploaded
            <span class="smartDate dateOnly" title="7/16/2013 1:07:06 PM" localtimeticks="1374005226">Jul 16, 2013</span>
             -
            77 downloads
        </span>
</div>
</div>
</div>
<div class="ReleaseNotesDiv">
    <h3>Release Notes</h3>
    <div id="ReleaseNotes" class="WikiContent">
        <div class="wikidoc">This version of the connection tester was released with openPDC 1.5 SP1 and openPDC 2.0 BETA.<br><br><i>This application requires that <a href="http://www.microsoft.com/en-us/download/details.aspx?id=17851">.NET 4.0</a> already be installed on your system.</i><br><br><b>Note this is the last release of the PMU Connection Tester that will built on .NET 4.0 using the <a href="https://tvacodelibrary.codeplex.com/">TVA Code Library</a> and the <a href="https://timeseriesframework.codeplex.com/">Time-series Framework</a>. Future releases of the PMU Connection Tester will be built on .NET 4.5 (or later) using the <a href="https://gsf.codeplex.com/">Grid Solutions Framework</a> (GSF). If you want to use or browse protocol source code, please download the <a href="https://gsf.codeplex.com/SourceControl/latest">GSF source code</a> and look for the GSF.PhasorProtocols project.</b><br>
<h2>Recent Improvements:</h2>
Improvements and operational fixes to the UTK F-NET, BPA PDCstream and Macrodyne protocols as well as fixes for various digital fault recorders and power quality meters - these changes are inherited from the <a href="https://openpdc.codeplex.com/releases/view/98475">openPDC 1.5 SP1 official release</a>.<br><br>For more details, see closed items in <a href="http://pmuconnectiontester.codeplex.com/workitem/list/advanced">PMU Connection Tester Issue Tracker</a> and <a href="http://openpdc.codeplex.com/workitem/list/advanced">openPDC Issue Tracker</a> as well as check-in history for the following related projects:<br>
<ul><li><a href="https://openpdc.codeplex.com/SourceControl/list/changesets">openPDC Change Log</a></li>
<li><a href="https://tvacodelibrary.codeplex.com/SourceControl/list/changesets">TVA Code Library Change Log</a></li>
<li><a href="https://timeseriesframework.codeplex.com/SourceControl/list/changesets">Time-series Framework Change Log</a></li></ul>
<h3>Other recent improvements include:</h3>
As of 4.3.10, includes protocol support for IEC 61850-90-5, Macrodyne-G with INI file support and improved UDP &quot;receive from&quot; capability when using multicast connections.<br><br>Includes updates to allow selection of a specific network interface when using a TCP or UDP socket as well as allowing specification of a multicast source IP for multicast subscriptions that require this. Additionally users now have the ability to specify a receive from IP filter for UDP broadcasts (when multiple broadcast are being sent to the same endpoint) and a new feature to allow control of whether or not to keep the command channel open when a data channel and command channel is defined.<br><br>As of 4.2.12, includes updates to Macrodyne protocol as well as other bug fixes specific to the connection tester.<br><br>Includes support for BPA Phasor Data File Format files (i.e., .DST files) for replay (from updates in v4.2.8).<br><br>Use the following steps to enable playback from a .DST file:<br>
<ol><li>Select the <i>File</i> tab under the <i>Connection Parameters</i> section.</li>
<li>Click the <i>Browse</i> button.</li>
<li>Select <i>BPA Phasor Data Files (*.dst)</i> from the file types pick list (bottom right).</li>
<li>Browse to the desired .DST file to playback.</li>
<li>Verify that the selected protocol is <i>BPA PDCstream</i>.</li>
<li>Click on the <i>Extra Parameters</i> tab.</li>
<li>Verify that <i>UsePhasorDataFileFormat</i> is set to <i>True</i>.</li>
<li>Select the <i>ConfigurationFileName</i> field and click the elipse &quot;...&quot; button (far right).</li>
<li>Browse to the .INI file associated with the previously selected .DST file.</li>
<li>Click the <i>Protocol</i> tab to close the <i>Extra Parameters</i> tab.</li>
<li>Click <i>Connect</i>.</li></ol>
<br>Thanks!<br>Ritchie</div><div class="ClearBoth"></div>
</div>
</div>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
