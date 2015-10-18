

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Move Local Historian to Another Folder</title>



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

<div class="wikidoc">

<h2>Change the Local Historian Archive Location</h2>

The following steps outline how to move the statistics historian to another folder. To move you primary data historian (e.g., PPA) to another folder, the steps would be the same but the category settings name would start with &quot;ppa&quot; instead of &quot;stat&quot;:<br>

<br>

<ol>

<li>Stop the openPDC Windows service </li><li>Open the XML Configuration Editor (Start Menu \ openPDC \ XML Configuration Editor)

</li><li>Click the &quot;...&quot; button and select the openPDC.exe.config in the openPDC installation folder (typically C:\Program Files\openPDC\)

</li><li>Click &quot;Load Settings&quot; button </li><li>Modify the following configuration settings:

<ol>

<li>statArchiveFile \ FileName - change path to desired location - leave file name as-is

</li><li>statIntercomFile \ FileName - change path to desired location - leave file name as-is

</li><li>statMetadataFile \ FileName - change path to desired location - leave file name as-is

</li><li>statStateFile \ FileName - change path to desired location - leave file name as-is</li></ol>

</li><li>Click the &quot;Save Settings&quot; button </li><li>If desired, while service is not running move all the existing files to the new location

</li><li>Restart the openPDC Windows service</li></ol>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="7/3/2014 4:35:03 PM" LocalTimeTicks="1404430503">Jul 3, 2014 at 4:35 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 3<br />

Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=Move%20Local%20Historian%20to%20Another%20Folder">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


