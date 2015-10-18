

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>openPDC v1.5 Release</title>



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

                

                <h1 class="page_title wordwrap">openPDC v1.5 Release</h1>



<table id="ReleaseMetaDataBox" cellspacing="0" cellpadding="0" border="0" style="border: 1px solid #c0c0c0; margin-top: 10px;">

    <tr>

        <td valign="top" style="border-right: 1px solid #c0c0c0;">

            <div id="metadataLeft" style="width: 250px;">

            

                <div class="metadataRow">

                    <span class="metadataItemHeader">Rating:</span>

                <span id="releaseRatingContainer" title="4 star rating"><span id="releaseRating_Star_0" class="RatingStar FilledRatingStar" d:rating="1" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="releaseRating_Star_1" class="RatingStar FilledRatingStar" d:rating="2" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="releaseRating_Star_2" class="RatingStar FilledRatingStar" d:rating="3" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="releaseRating_Star_3" class="RatingStar FilledRatingStar" d:rating="4" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="releaseRating_Star_4" class="RatingStar EmptyRatingStar" d:rating="5" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="releaseratingName"></span><input id="releasecurrentRating" type="hidden" value="4"></span>

                    &nbsp;<span id="RatingsBasedOnXReviewsLabel" style="font-size: 8pt;">Based on 1 rating</span>

</div>

                <div class="metadataRow">

                    <span id="BasedOnLabel" class="metadataItemHeader">Reviewed:&nbsp;</span> <a id="xReviewsLink" href="#ReviewsAnchor">1 review</a>

</div>

                

                <div class="metadataRow">

                    <span id="DownloadsCountLabel" class="metadataItemHeader">Downloads:</span>

                    <span id="DownloadCount">1082</span>

</div>

                

                <div class="metadataRow">

                    <span id="ChangesetIDLabel" class="metadataItemHeader">Change Set:</span>

                    <a id="ChangesetIDAnchor" href="http://openpdc.codeplex.com/SourceControl/changeset/view/80357">80357</a>

</div>

                

</div>

        </td>

        <td valign="top">

            <div id="metadataRight" style="width: 250px;">

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Released:</span>

                    <span id="ReleaseDateLiteral" class="smartDate dateOnlyNoShort" title="10/7/2012 7:00:00 AM" localtimeticks="1349618400">Oct 7, 2012</span>

</div>

                

                <div class="metadataRow">

                    <span class="metadataItemHeader">Updated:</span>

                        <span id="ReleaseModifierDateLiteral" class="smartDate dateOnlyNoShort" title="10/11/2012 3:41:25 AM" localtimeticks="1349952085">Oct 11, 2012</span>

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

    <a class="FileNameLink" d:fileid="360228" d:posturl="http://openpdc.codeplex.com/releases/captureDownload" d:releaseid="76146" href="http://openpdc.codeplex.com/downloads/get/360228" id="fileDownload0" onclick="suppressUnsavedData();return downloadFile(this, true, false)" tabindex="9">Synchrophasor.Installs.zip</a>

<div>

        <span id="fileItemInfo0" class="SubText">

            application,

            28974K, uploaded

            <span class="smartDate dateOnly" title="10/11/2012 3:41:15 AM" localtimeticks="1349952075">Oct 11, 2012</span>

             -

            1082 downloads

        </span>

</div>

</div>

</div>

        

</div>

<div class="ReleaseNotesDiv">

    <h3>Release Notes</h3>

    <div id="ReleaseNotes" class="WikiContent">

        <div class="wikidoc"><b><i>Version 1.5.143, official release of the openPDC</i></b><br>

<h2>This is the planned 4th Quarter 2012 release of the openPDC, version 1.5</h2>

<h4>This build includes the latest PMU Connection Tester, v4.3.7</h4>

<h4>Release Notes:</h4>

<ul><li>All openPDC Manager screens now support paging and improved UI response for large implementations (e.g., many hundreds of thousands of measurements)</li>

<li>Seamless integration with the open Phasor Gateway (openPG)</li>

<li>The openPDC can now perform all the functions of the openPG</li>

<li>Support for the EI phasor label naming convention in IEEE C7.118 output streams</li>

<li>Major overhaul of socket system including:

<ul><li>Multicast server and improved source support (receive and transmit for all protocols)</li>

<li>Simple UDP packet splitting (software outputs to accommodate than64K (or other user selectable </li>

<li>UDP receive from IP filter</li>

<li>Ability to close TCP command channel after successful connection</li>

<li>Socket data transmission threshold monitoring available for poor connections</li></ul></li>

<li>New extensible statistics engine</li>

<li>Updated subscriber API&#39;s – with .NET, C++ and Java support</li>

<li>An alarming service that will automated notifications based on phasor data comparisons to set-points or data control bands:

<ul><li>Alarms can be set to trigger based on real‐time phasor data, calculated points, or performance data</li>

<li>Alarm state can be exported through standard phasor data streams or via the PDC web service</li></ul></li>

<li>Dynamic switching to a secondary communications connection on failure primary connection</li>

<li>Security and performance improvements on findings from testing by vendors major universities. </li>

<li>Macrodyne G and N support </li>

<li>IEC 61850-90-5 input support with new missing data statistic for multiple ASDUs</li>

<li>Native OSI-PI input and output adapters built using SDK for best speed </li>

<li>New dynamic expression calculator </li>

<li>Enhanced power calculations include sequence calculation support</li>

<li>Enhanced CSV adapters with high-resolution timer and formatting support </li>

<li>1-Second frequency averaging utility with configuration screen</li>

<li>Historian will now roll-over even when export and trending tools have files open</li>

<li>Historian result queries are now time-sorted</li>

<li>Historian will now maintain number of files based on disk space if configured to do so</li>

<li>Many more hundreds of improvements and bug fixes</li></ul>



<h4>Upcoming Features</h4>

<ul><li>DNP3 input and output adapters - expected November 2012</li>

<li>OSI-PI input and output adapters (includes temporal support) - expected November 2012</li>

<li>Automatic out-of-band historical data “gap filling” in a destination openPDC as might result, for example, during times that communications is lost between a substation and the control center - expected first quarter of 2013</li></ul></div><div class="ClearBoth"></div>

</div>

</div>

<div id="ReviewsPanel">

    <a id="ReviewsAnchor"></a>

    <div id="ReviewsDivisionHeader">

        <h2>Reviews for this release</h2>

</div>

    <div id="Reviews">

        <div id="ReviewsList">

                <a id="ReviewBy-patpentz"></a>

                <div class="ReviewListItem">

                    <span id="review0RatingContainer" title="4 star rating"><span id="review0Rating_Star_0" class="RatingStar FilledRatingStar" d:rating="1" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="review0Rating_Star_1" class="RatingStar FilledRatingStar" d:rating="2" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="review0Rating_Star_2" class="RatingStar FilledRatingStar" d:rating="3" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="review0Rating_Star_3" class="RatingStar FilledRatingStar" d:rating="4" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="review0Rating_Star_4" class="RatingStar EmptyRatingStar" d:rating="5" onclick="MvcValidation_ClearErrors('Rating');">&nbsp;</span><span id="review0ratingName"></span><input id="review0currentRating" type="hidden" value="4"></span><br>

                    <span id="ReviewListText0">GPA knows what the memory problem is &#40;not a leak in actuality&#41; and is working to fix.&#10;The statistics problem cannot be reproduced. Thanks&#33;&#33;</span><br>

                    by <a id="ReviewListReviewUserHyperlink0" href="http://www.codeplex.com/site/users/view/patpentz">patpentz</a>

                    on <span id="reviewDate0" class="smartDate" title="10/30/2012 6:59:20 PM" localtimeticks="1351648760">Oct 30, 2012 at 6:59 PM</span>

                    <br>

</div>

</div>

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


