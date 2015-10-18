

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Developers Data Access Options</title>



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

<p><strong><span style="color:#1f497d">openPDC Data Access Options: </span></strong></p>

<hr>

<ol>

<li><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">Real-time data acquisition</span>

</li><li><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">Near real-time data acquisition</span>

</li><li><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">Historical data acquisition</span>

</li></ol>

<p><span style="color:#1f497d">&nbsp;</span><span style="color:#1f497d">1) The openPDC supports real-time subscription based data acquisition via the Gateway Exchange Protocol. You can see the API in action on the&nbsp;Graph Measurements&nbsp;screen inside

 the openPDC Manager - every time you check a new point in the list it &quot;subscribes&quot; via this real-time API. Code usage is fairly simple - there is an API that can be called to &quot;subscribe&quot; to data in multiple formats (example below). API's

 exist for .NET, Java, C&#43;&#43; and Unity 3D:</span></p>

<p><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:.5in"><em><span style="color:#1f497d">Assembly: GSF.TimeSeries.dll</span></em></p>

<p style="margin-left:.5in"><em><span style="color:#1f497d">Class: GSF.TimeSeries.Transport.DataSubscriber</span></em></p>

<p style="margin-left:.5in"><em><span style="color:#1f497d">Relevant Methods:</span></em></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;summary&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span><span style="color:green"> Subscribes (or re-subscribes) to a data publisher for a synchronized set of data points.</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;/summary&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;compactFormat&quot;&gt;</span><span style="color:green">Boolean value that determines if the compact measurement format should be used. Set to

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">false</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green"> for full fidelity measurement serialization; otherwise set to

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">false</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green"> for bandwidth conservation.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;framesPerSecond&quot;&gt;</span><span style="color:green">The desired number of data frames per second.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;lagTime&quot;&gt;</span><span style="color:green">Allowed past time deviation tolerance, in seconds (can be subsecond).</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;leadTime&quot;&gt;</span><span style="color:green">Allowed future time deviation tolerance, in seconds (can be subsecond).</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;filterExpression&quot;&gt;</span><span style="color:green">Filtering expression that defines the measurements that are being subscribed.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;useLocalClockAsRealTime&quot;&gt;</span><span style="color:green">Boolean value that determines whether or not to use the local clock time as real-time.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;ignoreBadTimestamps&quot;&gt;</span><span style="color:green">Boolean value that determines if bad timestamps (as determined by measurement's timestamp quality) should be ignored

 when sorting measurements.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;allowSortsByArrival&quot;&gt;</span><span style="color:green"> Gets or sets flag that determines whether or not to allow incoming measurements with bad timestamps to be sorted

 by arrival time.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;timeResolution&quot;&gt;</span><span style="color:green">Gets or sets the maximum time resolution, in ticks, to use when sorting measurements by timestamps into their proper destination

 frame.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;allowPreemptivePublishing&quot;&gt;</span><span style="color:green">Gets or sets flag that allows system to preemptively publish frames assuming all expected measurements have

 arrived.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;downsamplingMethod&quot;&gt;</span><span style="color:green">Gets the total number of downsampled measurements processed by the concentrator.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;returns&gt;&lt;c&gt;</span><span style="color:green">true</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green"> if subscribe was successful; otherwise

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">false</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green">.</span><span style="color:gray">&lt;/returns&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:blue">public</span> <span style="color:blue">virtual</span> <span style="color:blue">

bool</span> SynchronizedSubscribe(<span style="color:blue">bool</span> compactFormat,

<span style="color:blue">int</span> framesPerSecond, <span style="color:blue">double</span> lagTime,

<span style="color:blue">double</span> leadTime, <span style="color:blue">string</span> filterExpression,

<span style="color:blue">bool</span> useLocalClockAsRealTime = <span style="color:blue">

false</span>, <span style="color:blue">bool</span> ignoreBadTimestamps = <span style="color:blue">

false</span>, <span style="color:blue">bool</span> allowSortsByArrival = <span style="color:blue">

true</span>, <span style="color:blue">long</span> timeResolution = <span style="color:#2b91af">

Ticks</span>.PerMillisecond, <span style="color:blue">bool</span> allowPreemptivePublishing =

<span style="color:blue">true</span>, <span style="color:#2b91af">DownsamplingMethod</span> downsamplingMethod =

<span style="color:#2b91af">DownsamplingMethod</span>.LastReceived)</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;summary&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span><span style="color:green"> Subscribes (or re-subscribes) to a data publisher for an unsynchronized set of data points.</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;/summary&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;compactFormat&quot;&gt;</span><span style="color:green">Boolean value that determines if the compact measurement format should be used. Set to

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">false</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green"> for full fidelity measurement serialization; otherwise set to

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">false</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green"> for bandwidth conservation.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;throttled&quot;&gt;</span><span style="color:green">Boolean value that determines if data should be throttled at a set transmission interval or sent on change.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;filterExpression&quot;&gt;</span><span style="color:green">Filtering expression that defines the measurements that are being subscribed.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;lagTime&quot;&gt;</span><span style="color:green">When

</span><span style="color:gray">&lt;paramref name=&quot;throttled&quot;/&gt;</span><span style="color:green"> is

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">true</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green">, defines the data transmission speed in seconds (can be subsecond).</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;leadTime&quot;&gt;</span><span style="color:green">When

</span><span style="color:gray">&lt;paramref name=&quot;throttled&quot;/&gt;</span><span style="color:green"> is

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">true</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green">, defines the allowed time deviation tolerance to real-time in seconds (can be subsecond).</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;param name=&quot;useLocalClockAsRealTime&quot;&gt;</span><span style="color:green">When

</span><span style="color:gray">&lt;paramref name=&quot;throttled&quot;/&gt;</span><span style="color:green"> is

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">true</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green">, defines boolean value that determines whether or not to use the local clock time as real-time. Set to

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">false</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green"> to use latest received measurement timestamp as real-time.</span><span style="color:gray">&lt;/param&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:gray">///</span> <span style="color:gray">&lt;returns&gt;&lt;c&gt;</span><span style="color:green">true</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green"> if subscribe was successful; otherwise

</span><span style="color:gray">&lt;c&gt;</span><span style="color:green">false</span><span style="color:gray">&lt;/c&gt;</span><span style="color:green">.</span><span style="color:gray">&lt;/returns&gt;</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:8.0pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:blue">public</span> <span style="color:blue">virtual</span> <span style="color:blue">

bool</span> UnsynchronizedSubscribe(<span style="color:blue">bool</span> compactFormat,

<span style="color:blue">bool</span> throttled, <span style="color:blue">string</span> filterExpression,

<span style="color:blue">double</span> lagTime = 10.0D, <span style="color:blue">

double</span> leadTime = 5.0D, <span style="color:blue">bool</span> useLocalClockAsRealTime =

<span style="color:blue">false</span>)</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">Here is an operational example:</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<a href="http://timeseriesframework.codeplex.com/SourceControl/changeset/view/61589#1011313">

http://timeseriesframework.codeplex.com/SourceControl/changeset/view/61589#1011313</a>

    ++ <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Data_Access_Options.files/DataSubscriberTest_Program-61589.zip">Archive Download</a>

                            </span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">Note that all this code exists in the Time Series Framework - this is important since phasor gateways, historians, etc. in the future can all use this same code.</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">These two API calls provide the following possible real-time data subscriptions:</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:1.0in; text-indent:-.25in"><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">1)<span style="font:7.0pt 'Times New Roman'">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span></span><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">A synchronized (i.e., concentrated by time) set of subscribed data points</span></p>

<p style="margin-left:1.0in; text-indent:-.25in"><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">2)<span style="font:7.0pt 'Times New Roman'">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span></span><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">An on-change unsynchronized set of subscribed data points

</span></p>

<p style="margin-left:1.0in; text-indent:-.25in"><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">3)<span style="font:7.0pt 'Times New Roman'">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span></span><span style="font-size:11.0pt; font-family:'Calibri','sans-serif'; color:#1f497d">A throttled (e.g., downsampled to every few seconds) &nbsp;unsynchronized set of subscribed data points</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">To pick up data you simply attach to the NewMeasurements event and receive a collection of measurements:</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:blue">static</span> <span style="color:#2b91af">DataSubscriber</span> subscriber =

<span style="color:blue">new</span> <span style="color:#2b91af">DataSubscriber</span>();</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subscriber.NewMeasurements &#43;= subscriber_NewMeasurements;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:green">// Initialize subscriber</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; subscriber.ConnectionString =

<span style="color:#a31515">&quot;server=localhost:6165&quot;</span>;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; subscriber.Initialize();</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:green">// Start subscriber connection cycle</span></span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; subscriber.Start();</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:blue">static</span> <span style="color:blue">void</span> subscriber_NewMeasurements(<span style="color:blue">object</span> sender,

<span style="color:#2b91af">EventArgs</span>&lt;<span style="color:#2b91af">ICollection</span>&lt;<span style="color:#2b91af">IMeasurement</span>&gt;&gt; e)</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dataCount &#43;= e.Argument.Count;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:blue">if</span> (dataCount % (5 * 60) == 0)</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<span style="color:#2b91af">Console</span>.WriteLine(<span style="color:blue">string</span>.Format(<span style="color:#a31515">&quot;{0} total measurements received so far: {1}&quot;</span>, dataCount, e.Argument.ToDelimitedString(<span style="color:#a31515">&quot;,

 &quot;</span>)));</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span></p>

<p style="margin-left:.5in; text-autospace:none"><span style="font-size:9.5pt; font-family:Consolas">&nbsp;</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">To better understand using this API, open the TimeSeriesFramework solution and evaluate the DataSubscriberTest application. You can run this application in debug mode (multiple instances actually) as well

 as starting an instance of the associated DataPublisherTest app to see it in action.</span></p>

<p><span style="color:#1f497d">&nbsp;</span></p>

<p><span style="color:#1f497d">2) With the development of this new real-time API, the web service based data acquisition for near-real time data that has always existed will now be optional - that is, if a user &quot;chooses&quot; to install a local historian

 (this is being added as a configuration setup screen step) then the near real-time data web service will then be available - otherwise it will not be available for data. It should be noted that the statistics historian is a separate local historian and will

 always be available. This data access option uses the web service API:</span></p>

<p><span style="color:#1f497d">&nbsp;</span></p>

<p><span style="color:#1f497d"><span style="white-space:pre"><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#time_series_web_service">Getting Started, Time Series WebService</a></span></span></p>

<p><span style="color:#1f497d">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</span><span style="color:#1f497d">&nbsp;</span></p>

<p><span style="color:#1f497d">3) When accessing the statistics historian or the optional local historian for historical data you can always use the web service aforementioned in item 2 (details in the web-link above). Note however that there is another, more

 direct, way to access the data. For faster historical data acquisition you can use the historian API directly. For an example of how to use this you can look at the statistics reader code recently added to the phasor protocol's library:</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d">&nbsp;</span></p>

<p style="margin-left:.5in"><span style="color:#1f497d"><a href="http://openpdc.codeplex.com/SourceControl/changeset/view/61586#1084098">StatisticsReader.cs</a>

     ++ <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Data_Access_Options.files/StatisticsReader-61586.zip">Archive Download</a></span></p>

<p><span style="color:#1f497d">&nbsp;</span></p>

<p><span style="color:#1f497d">This API reads data directly from the historical .D files over a given time span as fast as possible. Additionally, you can look at the source code for the Historian Playback Utility for another example of how to use the data

 read / extraction API directly.</span></p>

<p>&nbsp;</p>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="6/10/2014 3:08:40 PM" LocalTimeTicks="1402438120">Jun 10, 2014 at 3:08 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 3<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Data%20Access%20Options%20%28Developers%29">CodePlex</a> Oct 5, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


