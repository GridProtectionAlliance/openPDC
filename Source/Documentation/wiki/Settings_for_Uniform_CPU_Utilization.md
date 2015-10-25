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
<h2>Setting for Uniform CPU Utilization </h2>
In the openPDC version 1.4 SP2 there is a new boolean config file setting called &quot;GCGenZeroInterval&quot; in the &quot;systemSettings&quot; category.<br>
<br>
This setting is used to stabilize CPU utilization on boxes with limited RAM by causing garbage collection of all generation zero objects on a quicker interval. If you installed SP2 from scratch, this option may be disabled, if you upgraded SP2 from a previous
 version, this setting may be set to fire every half second (i.e., 500 milliseconds). If the value is set to -1, it is off which means the system will allow .NET to auto-tune the garbage collection.<br>
<br>
Generally, if you have a plenty of RAM and a fast multi-core processor, you might as well leave this setting disabled (i.e., the value equals -1). However, on machines with fewer resources (e.g., memory), you may want to enable this setting (e.g., setting the
 value to 500).<br>
<br>
On a machine loaded with several PMU connections and less working memory, your processor utilization with .NET auto-tuned garbage collection (i.e., GCGenZeroInterval = -1), may look like this:<br>
<br>
<img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Settings_for_Uniform_CPU_Utilization.files/openPDC_CPU_with_auto-tuned_GC.png" alt="openPDC CPU with auto-tuned GC.png" title="openPDC CPU with auto-tuned GC.png"><br>
<br>
The CPU spike in the above graph is the .NET garbage collector running. However, with the GCGenZeroInterval setting on a tight interval (e.g., GCGenZeroInterval = 500), the processor utilization will look more like this:<br>
<br>
<img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Settings_for_Uniform_CPU_Utilization.files/openPDC_CPU_with_quick_interval_GC.png" alt="openPDC CPU with quick interval GC.png" title="openPDC CPU with quick interval GC.png"><br>
<br>
This stabalizes the CPU by not going so long before a garbage collection, however, on average the CPU will be slightly higher since it is executing the garbage collection more often, but it does not spike the CPU.<br>
<br>
It is suggested that you leave your system set for auto-tuned garbage collections if either your CPU spikes are small or you have plenty of run-time system resources, however, on a resource constrained system this may be a useful setting to enable.<br>
<br>
Generally as we keep optimizing the code, we continue to strive to reuse objects and buffers using preallocated pools to reduce the number of objects created per second, however, when items are being processed 30 to 120 times per second for hundreds of thousands
 of points some level of non-resuable allocations may always be required.</div>
</div>
<div id="footer">
<hr />
Last edited <span class="smartDate" title="7/6/2012 7:23:33 PM" LocalTimeTicks="1341627813">Jul 6, 2012 at 7:23 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 12<br />
Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Settings%20for%20Uniform%20CPU%20Utilization%20">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
