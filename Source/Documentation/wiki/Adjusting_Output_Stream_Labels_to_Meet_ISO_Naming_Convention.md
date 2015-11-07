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
<div class="wikidoc">
<p><strong><span style="font-size:14pt">Adjusting Output Stream Labels to Meet ISO Naming Convention</span></strong></p>
<p>Since phasor labels have traditionally been defined so poorly in synchrophasor devices the openPDC will auto-suffix labels with the phase information. This can at least &quot;hint&quot; to the data type in the phasor when the labeling is not well defined.
 However, the <em>ISO Standard Synchrophasor Naming Convention</em> now defines these labels so this feature needs to be disabled. To accommodate the naming standard, the following connection string parameters are used for ISO level output streams:</p>
<ol>
<li><strong><em>addPhaseLabelSuffix</em></strong> - a boolean value that will allow the default phase label suffix to be enabled / disabled
</li><li><strong><em>replaceWithSpaceChar</em></strong> - a character designation that will be replaced by &quot;space&quot; in the output stream
</li></ol>
<p>The following is an example connection string addition that complies with the standard:</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; addPhaseLabelSuffix=false; replaceWithSpaceChar=_</p>
<p>In this example, a label in the output stream where an underscore was encountered would be replaced with a space. Note that you can use another character if underscores are reserved and or used in the naming standard.</p>
<p>With this notion you can change the original device acronym to include the desired replacement characters before adding the device to the output stream so it is consistently named throughout the system.</p>
</div>
<div></div>
</div>
<div id="footer">
<hr />
Last edited <span class="smartDate" title="7/6/2012 6:54:55 PM" LocalTimeTicks="1341626095">Jul 6, 2012 at 6:54 PM</span> by <a id="wikiEditByLink" href="https://github.com/ritchiecarroll">ritchiecarroll</a>, version 3<br />
Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Adjusting%20Output%20Stream%20Labels%20to%20Meet%20ISO%20Naming%20Convention">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/ajstadlin">ajs</a>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
