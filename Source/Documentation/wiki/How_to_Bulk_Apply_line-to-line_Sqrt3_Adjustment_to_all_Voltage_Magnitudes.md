

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>How to Bulk Apply line-to-line Sqrt3 Adjustment to all Voltage Magnitudes</title>



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

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->



<div class="WikiContent">

<div class="wikidoc">

<p>The following SQL server script can be run against your openPDC configuration database to convert all line-to-neutral voltage magnitudes to line-to-line by applying a square root of 3 factor to the value:<br>

<br>

</p>

<pre><span style="color:blue">USE</span> openPDC

<span style="color:blue">GO</span>

<span style="color:blue">UPDATE</span> Measurement <span style="color:blue">SET</span> Multiplier = 1.732050807568877 <span style="color:blue">WHERE</span> Measurement.PointID <span style="color:blue">IN</span>

&nbsp;&nbsp;&nbsp;(<span style="color:blue">SELECT</span> <span style="color:magenta">CONVERT</span>(<span style="color:blue">INT</span>, <span style="color:magenta">SUBSTRING</span>(ID, <span style="color:magenta">CHARINDEX</span>(<span style="color:#a31515">':'</span>, ID) &#43; 1, 10)) <span style="color:blue">AS</span> PointID

&nbsp;&nbsp;&nbsp;<span style="color:blue">FROM</span> ActiveMeasurement <span style="color:blue">WHERE</span> SignalType=<span style="color:#a31515">'VPHM'</span>)

</pre>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="8/1/2012 4:38:32 PM" LocalTimeTicks="1343864312">Aug 1, 2012 at 4:38 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 6<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Bulk%20apply%20line-to-line%20Sqrt%283%29%20adjustment%20to%20all%20voltage%20magnitudes">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


