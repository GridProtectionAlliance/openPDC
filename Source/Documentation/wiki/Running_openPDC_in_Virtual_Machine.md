

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Running openPDC in Virtual Machine</title>



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

<div class="wikidoc">Although the openPDC will run in a virtualized environment, and many deployments do this, there are various constraints which should be considered. Normally, GPA does not recommend running a

<i>production</i> instance of the openPDC in a virtualized environment: phasor data input to the PDC is continuous and VM time slicing can result in bursts of output that are dependent on overall hardware loading of other virtualized machines running on the

 same hardware.<br>

<br>

Accurate time management is a critical dimension of any PDC functionality, but is especially problematic under Hyper-V, which does not provide CPU clock counts during the VM sleep state. Other VM solutions, such as VMware attempt to make clock count adjustments

 based on sleep state.<br>

<br>

As a massively multi-threaded application, the openPDC effectively utilizes all of the CPU cores available. Additionally, multiple streams of high volume network traffic being routed to the same physical network cards hosting the multiple virtual servers may

 cause I/O throttling or high collision rates. Therefore, the preferred solution is properly sizing physical hardware for the PDC.<br>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="2/23/2015 2:51:57 PM" LocalTimeTicks="1424731917">Feb 23 at 2:51 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 2<br />

Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=Running%20openPDC%20in%20Virtual%20Machine">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


