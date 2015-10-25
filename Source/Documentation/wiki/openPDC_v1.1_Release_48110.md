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
                <h1 class="page_title wordwrap">June 2010 openPDC v1.1 Release</h1>
                
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
                    <span id="DownloadCount">609</span>
</div>
                
                <div class="metadataRow">
                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>
                    <a id="ChangesetIDAnchor" href="http://openpdc.codeplex.com/SourceControl/changeset/view/54206">54206</a>
</div>
                
</div>
        </td>
        <td valign="top">
            <div id="metadataRight" style="width: 250px;">
                
                <div class="metadataRow">
                    <span class="metadataItemHeader">Released:</span>
                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="6/30/2010 7:00:00 AM" localtimeticks="1277906400">Jun 30, 2010</span>
</div>
                
                <div class="metadataRow">
                    <span class="metadataItemHeader">Updated:</span>
                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="7/6/2010 1:24:00 PM" localtimeticks="1278447840">Jul 6, 2010</span>
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
<div class="ReleaseNotesDiv">
    <a id="ReleaseFiles"></a>
    
        <div id="recommendedFileDiv">
            <h3>Recommended Download</h3>
            
<div id="FileListItem0" class="FileListItemDiv">
    <img id="fileImage0" class="FileTypeImage" style="vertical-align:middle;" src="http://download-codeplex.sec.s-msft.com/Images/v21031/RuntimeBinary.gif" alt="Application">
    <a class="FileNameLink" d:fileid="129928" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="48110" href="http://openpdc.codeplex.com/downloads/get/129928" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Installs.zip</a>
<div>
        <span id="fileItemInfo0" class="SubText">
            application,
            17815K, uploaded
            <span class="smartDate dateOnly" title="7/6/2010 1:23:57 PM" localtimeticks="1278447837">Jul 6, 2010</span>
             -
            609 downloads
        </span>
</div>
</div>
</div>
        
</div>
<div class="ReleaseNotesDiv">
    <h3>Release Notes</h3>
    <div id="ReleaseNotes" class="WikiContent">
        <div class="wikidoc"><img src="http://i3.codeplex.com/Project/Download/FileDownload.aspx?ProjectName=CodePlex&amp;DownloadId=3753"> This is the current recommended release build of the openPDC, version 1.1.79.54105.<br><br>This download contains installers for the following:<br>
<ul><li><b>openPDC Windows Service (32-bit)</b> (Release\Applications\openPDC\openPDCSetup.msi) </li>
<li><b>openPDC Windows Service (64-bit)</b> (Release\Applications\openPDC\openPDCSetup64.msi) </li>
<li><b>PMU Connection Tester (32-bit)</b> (Release\Tools\PMUConnectionTester\PMUConnectionTesterSetup.msi) </li>
<li><b>PMU Connection Tester (64-bit)</b> (Release\Tools\PMUConnectionTester\PMUConnectionTesterSetup64.msi) </li>
<li><b>openPDC Manager Services</b> (Release\Applications\openPDC\openPDCManager\openPDCManagerServicesSetup.msi) </li>
<li><b>openPDC Manager Application</b> (Release\Applications\openPDC\openPDCManager\openPDCManagerWebSetup.msi)</li></ul>
<br>Latest Features and Updates<br>
<ul><li><b>Framework</b>
<ul><li>The Configuration Editor now supports encrypted settings</li>
<li>Added authentication API for improved security</li>
<li>Improved lPv6 UDP support</li>
<li>New threading improvements</li>
<li>The discarded measurements event now available</li></ul></li>
<li><b>Synchrophasor</b>
<ul><li>System wide statistics</li>
<li>New 64-bit installation packages (openPDC &amp; Connection Tester)</li>
<li>Enhanced Hadoop Replication Provider (detailed logging &amp; multiple recursive folder watching)</li>
<li>New console commands</li>
<li>New Database upgrade utility (can migrate data between different schemas)</li>
<li>Flatline Tester now detects measurements that have not been published (discovers unconnected devices)</li>
<li>Improved reloadConfig command that removes the need for service restart</li>
<li>Added Data Discarded flag to high word of Status Flags to indicate measurement not being published to real-time stream due to late arrival</li>
<li>Data with bad time but good quality now marked as “old”, bad data quality is &quot;suspect&quot;</li>
<li>Added new scaling factor fields in output stream</li>
<li>Can now query a concentrator’s status on HeaderFrame request</li>
<li>Made data validity processing optional</li>
<li>Updates to BPA PDCstream for more complete output support</li></ul></li>
<li><b>openPDC Manager</b>
<ul><li>New Statistics Monitor page</li>
<li>User input validation and new default values for faster input</li>
<li>New connection string builder interface when connection file is not available</li>
<li>Request PMU configuration from web interface and import directly into Add Device Wizard (allows updating existing)</li>
<li>More comprehensive database structure (20+ fields added)</li>
<li>Devices can now be deleted/enabled/disabled from device screen</li></ul></li></ul></div><div class="ClearBoth"></div>
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
