

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Using a  Gateway Style Connection between openPDCs and for openPGs</title>



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

<div class="wikidoc">To connect between openPDCs and/or openPGs, in the subscribing system;<br>

<ol>

<li>Navigate to Inputs -&gt; Add New in openPG, or Devices -&gt; Add New in openPDC

</li><li>Enter the acronym you&#39;d like this device to have </li><li>Under &#39;Protocol&#39;, select &#39;Gateway Transport&#39; </li><li>With the connection string, click the &#39;&#43;&#39;, select the UDP tab, and select what local port you wish to use

</li><li>In the Connection String, type &#39;autoconnect=true;&#39; </li><li>(If using the same database as openPDC) Add &#39;synchronizeMetaData=false;&#39; to connect string

</li><li>In the Alternate Command Channel, type &#39;server=localhost:6165&#39; (Replace &#39;localhost&#39; with the host IP if not on the same system)

</li><li>Ensure &#39;Concentrator&#39; and &#39;Enabled&#39; checkboxes are checked </li><li>Click &#39;Save&#39;</li></ol>

<br>

Your connection should now be established! It may take a few moments to complete metadata exchange; refresh the device list to see the newly added devices.</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br><br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="2/15/2012 6:02:21 PM" LocalTimeTicks="1329357741">Feb 15, 2012 at 6:02 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/arkrohne.md">arkrohne</a>, version 3<br />

Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=Using%20a%20%22Gateway%20Style%20Connection%22%20between%20openPDCs%20and%2for%20openPGs">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


