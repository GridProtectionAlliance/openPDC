

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>openPDC v1.4 Release</title>



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

                

                <h1 class="page_title wordwrap">openPDC v1.4 Release</h1>



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

                    <span id="DownloadCount">754</span>

</div>

                

                <div class="metadataRow">

                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>

                    <a id="ChangesetIDAnchor" href="http://openpdc.codeplex.com/SourceControl/changeset/view/64506">64506</a>

</div>

                

</div>

        </td>

        <td valign="top">

            <div id="metadataRight" style="width: 250px;">

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Released:</span>

                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="3/11/2011 7:00:00 AM" localtimeticks="1299855600">Mar 11, 2011</span>

</div>

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Updated:</span>

                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="4/28/2011 7:18:23 PM" localtimeticks="1304043503">Apr 28, 2011</span>

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

    <a class="FileNameLink" d:fileid="152722" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="52461" href="http://openpdc.codeplex.com/downloads/get/152722" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">openPDCSetup.zip</a>

<div>

        <span id="fileItemInfo0" class="SubText">

            application,

            30925K, uploaded

            <span class="smartDate dateOnly" title="3/11/2011 10:47:04 PM" localtimeticks="1299912424">Mar 11, 2011</span>

             -

            754 downloads

        </span>

</div>

</div>

</div>

        

</div>

<div class="ReleaseNotesDiv">

    <h3>Release Notes</h3>

    <div id="ReleaseNotes" class="WikiContent">

        <div class="wikidoc">Version 1.4 release of the openPDC <br>

<h2>This is the official production release of the version 1.4 openPDC - March 2011.</h2>

Update notes:<br>

<ul><li>Integrated security with detailed configuration change audit logging</li>

<li>Real-time data access / subscription based API available supporting full resolution as well as down-sampled data</li>

<li>Improved UDP_T support (control channel failure monitoring independent of data channel)</li>

<li>Added API support for querying statistics from the archive</li>

<li>Added multi-homed source device idempotence features such that multiple connections to a source device can be defined mapping data to a single set of measurements</li>

<li>New “Best Quality” as a down-sampling method</li>

<li>Output stream statistics updated to take into account disconnected states</li>

<li>Statistic to track latency of last discarded measurement to indicate what lag should be configured</li>

<li>Ease-of-use improvements to installation package</li>

<li>Improved manual connection management</li>

<li>Dynamic switching between synchronized and unsynchronized data feeds</li>

<li>openPDC Manager Enhancements

<ul><li>Integrated application security with support for definition of roles and users</li>

<li>Major improvements and optimizations to the openPDC Manager Input Status &amp; Monitoring screen</li>

<li>Adding sort ability to all columns in Devices list</li>

<li>“Help-Me-Choose” diagrams added for contextual help with settings</li>

<li>Home Status screen readability improvements</li>

<li>Support for non-60Hz users</li>

<li>Added option to perform timestamp reasonability check on the Output Stream and Calculated Measurement screens.</li>

<li>Ability to restart the service from the openPDC Manager</li></ul></li></ul>



<h2>Known issues:</h2>

<ol><li>Enabling the optional encryption on the connection strings on Windows 7 / 2008 requires that openPDC Manager be run as administrator or be installed into a non-protected folder such that it can have read/write access to the crypto-key cache. Otherwise an error will be displayed on startup of the openPDC Manager similar to: &quot;Access Denied - Error loading security provider: Failed to decrypt connection string&quot;.</li>

<li>The openPDC Console configuration file that gets deployed in v1.4.90 is missing a default setting, running application as administrator once will add the new setting on shutdown. Alternately you can manually update the config file adding the IntegratedSecurity setting from <a href="http://openpdc.codeplex.com/SourceControl/changeset/view/64534#522160">here</a>. Without the setting the console will throw an exception on shutdown. Installing from the <a href="http://openpdc.codeplex.com/wikipage?title=Nightly%20Builds">nightly build</a> will also correct this error.</li>

<li>Addition of duplicate settings in the connection strings (e.g., manually adding Integrated Security string along with checking the checkbox for this feature) will cause an error to be displayed on startup of openPDC Manager as &quot;Access Denied - Error loading security provider&quot;. Make sure there is one key per parameter in the connection string entries until duplicates can be ignored in a future release.</li></ol></div><div class="ClearBoth"></div>

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


