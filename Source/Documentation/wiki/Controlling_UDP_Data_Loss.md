

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Controlling UDP Data Loss</title>



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

<p>Regarding the issues that some openPDC users have reported about UDP data loss on 120 fps streams, a new parameter has been introduced to the connection string for input devices called

<em>bufferSize</em>. This property controls the size of the kernel buffer used to receive data from the device so that packets will not be dropped during garbage collection. If you are experiencing UDP data loss, try increasing the buffer size by setting this

 property via the connection string used to connect to your device.</p>

<p>Example connection string (2 MB buffer):<br>

localport=4712; transportprotocol=udp; interface=0.0.0.0;&nbsp;<strong>bufferSize=2097152</strong>&nbsp;</p>

<p>If modifying this property does not solve the UDP data loss, you may also try reading the information below.</p>

<p>&nbsp;</p>

<p>

<hr>

<p>

<p>Some openPDC users have reported UDP data loss on 120 fps streams and/or systems that were heavily loaded. That is even though Wireshark reported all the data arriving on the system, the openPDC wasn't receiving all the data. The issue here is the .NET Garbage

 Collector that blocks threads during a blocking/forced unused memory collection every 10-15 seconds - the more memory that is in use amplifies the time required to collect. More specifically, if you do not retrieve data from the Windows UDP socket buffer queue

 fast enough it will replace the existing buffer with new data. When the garbage collector starts taking more time there is more opportunity for loss (data replacement with new data) on the UDP socket.&nbsp;<span style="font-size:10pt">During garbage collection

 data loss can simply be caused by amplification in memory usage (which causes GC to take longer) or heavily loaded system (meaning the GC is competing for CPU and therefore taking longer).&nbsp; The issue can occur simply by increasing samples per second and/or

 using large lag times, like 30 seconds.</span></p>

<p><span style="font-size:10pt">The solution is to force garbage collection more often.&nbsp;</span><span style="font-size:10pt">All recent versions of the openPDC include a setting in the configuration file to do a generation zero garbage collection on a specified

 interval - increasing the frequency of garbage collection for generation zero objects on the 4.0 framework will resolve data loss when lag times (i.e., basic memory utilization) are reasonable (e.g., 3-5 seconds of lag time) even when receiving data at 120

 samples per second.</span></p>

<p><span style="font-size:10pt">On .NET 4.0 builds the issue can return once lag times are increased (e.g., to 30 seconds) thereby increasing memory pressure and the need to collect large volumes of data - this is because with a large lag time the allocated

 memory will be promoted to generation 2 and 3 and a generation zero collection will be ineffective. Increasing the garbage collection to generation to 2 or 3 on an interval may increase CPU loading to a point where data can again occur.</span></p>

<p><span style="font-size:10pt">On .NET 4.5 the garbage collector has been vastly improved - the improvements include an &quot;optimized&quot; collect as well the ability to perform a non-blocking collect. On the .NET 4.5 build of the openPDC, code has been

 modified such that the interval garbage collection method can be performed against generation 1 through 3 objects using optimized, non-blocking garbage collection running every 5 milliseconds without a significant impact on CPU loading*. With this in place

 testing showed no data loss even with significant memory usage at 120 samples per second.</span><span style="font-size:10pt">&nbsp;</span></p>

<p><strong><em>Bottom line:</em></strong></p>

<p><span style="font-size:10pt">If you are experiencing UDP data loss on GPA products where you can confirm that data is being received (e.g., with Wireshark), simply enabling the interval garbage collection method may help (i.e., change the

<span style="color:#ff0000">systemSettings/GCGenZeroInterval</span> to 50 milliseconds); continuing to increase frequency (i.e., lower interval) could make a difference. Upgrading the system to the .NET 4.5 version of the openPDC (version 2.0) will resolve

 the issue entirely.</span></p>

<p><span style="font-size:10pt">* Note that on .NET 4.5 deployments, garbage collection performance can be affected by the runtime settings in the config file (e.g., openPDC.exe.config). If these settings are defined in config file (see example below), please

 remove them so that the default settings will be used:</span></p>

<p><span style="font-size:10pt; color:red">&nbsp;</span></p>

<div style="color:black; background-color:white">

<pre>  <span style="color:blue">&lt;</span><span style="color:#a31515">runtime</span><span style="color:blue">&gt;</span>

    <span style="color:blue">&lt;</span><span style="color:#a31515">gcConcurrent</span> <span style="color:red">enabled</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">false</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>

    <span style="color:blue">&lt;</span><span style="color:#a31515">gcServer</span> <span style="color:red">enabled</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">true</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>

  <span style="color:blue">&lt;/</span><span style="color:#a31515">runtime</span><span style="color:blue">&gt;</span>

</pre>

</div>

<p><span style="font-size:10pt; color:red">&nbsp;</span></p>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="4/22/2013 3:30:20 PM" LocalTimeTicks="1366669820">Apr 22, 2013 at 3:30 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/staphen.md">staphen</a>, version 4<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Controlling%20UDP%20Data%20Loss">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


