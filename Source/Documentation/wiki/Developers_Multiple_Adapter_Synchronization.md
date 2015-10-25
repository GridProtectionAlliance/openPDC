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
<p><span style="font-size:10pt">To address limitations in the wait handle pattern for adapter synchronization, as of version 1.5.192 of the openPDC and to be included in the final release of v1.5 SP1, wait handle synchronization has been replaced by the &quot;Queue
 and Notify&quot; pattern.</span></p>
<p><em>Note: Introduction of the queue and notify pattern has replaced the wait handle pattern, in that the wait handle pattern no longer exists. Any systems using the old pattern will need to migrate their connection strings and adapter code to the queue and
 notify pattern.</em></p>
<p><span style="font-size:10pt">Usage is similar to the wait handle pattern. The following connection string parameters can now be specified on the dependent adapter.</span></p>
<ul>
<li><strong><em>dependencies</em></strong>&nbsp;- Comma separated list of adapter acronyms
</li><li><strong><em>dependencyTimeout</em></strong>&nbsp;- Maximum wait time, in seconds, before proceeding
</li></ul>
<p>These connection string parameters instruct the openPDC measurement routing system to wait for an adapter's dependencies to finish processing measurements before providing those measurements to the dependent adapter. Those measurements will instead be queued
 until either the dependency adapters notify the routing system or the timeout expires.</p>
<p>Any adapter which is acting as a dependency will now be expected to call one of the OnNotify() overloads to indicate that it has finished processing its measurements.</p>
<div style="color:black; background-color:white">
<pre>    <span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> PublishFrame(IFrame frame, <span style="color:blue">int</span> index)
    {
        <span style="color:green">// Set flags for flat-line values</span>
        SetStateFlagsForFlatLineValues(frame.Measurements.Values);
        <span style="color:green">// Release adapters waiting on flat-line state</span>
        OnNotify(frame.Measurements.Values);
    }
</pre>
</div>
<p>&nbsp;</p>
<p><em>Note: If dependency relationships are updated due to a configuration change, it will be necessary to notify the measurement routing system by sending the 'RefreshRoutes' command via the openPDC Console.</em></p>
<p>&nbsp;</p>
<h3>Advanced information</h3>
<h4>Intelligent queuing</h4>
<p>The measurement routing system attempts to determine which measurements need to be queued based on the routes that the measurement is taking through the system. For example, in the following diagram, the measurement routing system has received three measurements
 (m1, m2, and m3) which are to be routed to at least one of two adapters (Dependency Adapter and Dependent Adapter). Dependent Adapter has listed Dependency Adapter among its dependencies in its connection string.</p>
<p><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Multiple_Adapter_Synchronization.files/queue-and-notify.png" alt="Measurement routing example" width="358" height="366"></p>
<p>Measurements m1 and m3 are each being sent to only one of the adapters, so they will be provided immediately to Dependency Adapter and Dependent Adapter respectively. However, m2 is being provided to both adapters. In this case, the measurement routing system
 recognizes that there is a dependency between the two adapters receiving the measurement and will therefore only provide m2 to Dependency Adapter. It will also hold onto m2 until Dependency Adapter has sent a notification to indicate that it has finished processing.
 When the routing system receives the notification, that is when it sends m2 to Dependent Adapter.</p>
<p>The key point here is that although m3 is being sent to Dependent Adapter, the routing system recognizes that it is not also being sent to Dependency Adapter. The measurement will not be held pending notification.</p>
<p>&nbsp;</p>
<h4>Signal separation</h4>
<p>Measurements are queued by signal for each dependent adapter. This means that a set of queues is created for each dependent adapter, and the number of queues matches the number of signals being received by that dependent adapter and its dependencies. The
 following diagram shows a system with three dependent adapters and three signals, where each adapter is receiving a different set of signals.</p>
<p><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Multiple_Adapter_Synchronization.files/signal-separation.png" alt="Signal separation" width="678" height="487"></p>
<p>In this scenario, if m1.1 arrives before m2.1, but the dependency adapters finish processing m2.1 before m1.1, then m2.1 can still be dequeued and provided to the adapters without having to wait on m1.1. On the other hand, if a dependency adapter fails to
 process m1.1 but succeeds in processing m1.2, the routing system must provide these measurements to the dependent adapter in order. The routing system will automatically time out m1.1 so that both measurements can be provided to the dependent adapters immediately.</p>
<p>&nbsp;</p>
<h4>Multiple dependencies</h4>
<p>In the case of multiple dependencies, where A3 depends on both A1 and A2, this situation is handled in much the same way as the first example under intelligent queuing. For each measurement that goes through the measurement routing system, the system determines
 whether any measurements are going to A1 and A3, A2 and A3, or all three of them. Then, for each measurement added to the queue, it stores two sets: a set of the dependencies which also received the measurement and a set of the adapters that have notified.
 When the set of dependencies matches the set of notifications, the measurement is provided to A3. This way, notifications can come from A1 and A2 at any time and in either order. The measurement will not be provided to A3 until all of its dependencies which
 also received the measurement have notified.</p>
<p>&nbsp;</p>
<hr>
<p><span style="color:#1f497d">New with any adapter in v1.4 SP2 of the openPDC there are now two new connection string parameters:</span><span style="color:#1f497d">&nbsp;</span></p>
<ul>
<li><strong><em><span style="color:#1f497d">waitHandleNames</span></em></strong><span style="color:#1f497d"> - Comma separated list of wait handle names</span>
</li><li><strong><em><span style="color:#1f497d">waitHandleTimeout </span></em></strong><span style="color:#1f497d">&nbsp;- Maximum wait time, in milliseconds, before proceeding</span>
</li></ul>
<p><span style="color:#1f497d">These two parameters allow any adapter in the system to temporarily postpone processing until all the named wait handles have fired and/or the wait times-out. Waiting is built-in and automated for action and output adapters simply
 by specifying the wait handle names. This includes remote data subscribers - the subscription methods include these two items as optional parameters.</span><span style="color:#1f497d">&nbsp;</span></p>
<p><span style="color:#1f497d">The wait handle timeout is an optional parameter. The default value for the wait handle timeout on action adapters is based on the frame rate, for example, if the frame rate is 30 samples per second, the default wait handle timeout
 will be 33 milliseconds. For non-action adapters, the value will default to 33 milliseconds unless otherwise specified.</span><span style="color:#1f497d">&nbsp;</span></p>
<p><span style="color:#1f497d">The multiple wait handle names allows adapters to wait for multiple events (e.g., measurement validation and chained calculation results).</span><span style="color:#1f497d">&nbsp;</span></p>
<p><span style="color:#1f497d">The only code change that will be needed is to &quot;release&quot; the waiting adapters when your custom event or action has completed, for example, in the following code the external event wait handle named &quot;FlatLineState&quot;
 gets released once the flat-line set has been completed and the state flags have been assigned:</span></p>
<p><span style="color:#1f497d">&nbsp;</span><span style="color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:blue">protected</span>
<span style="color:blue">override</span> <span style="color:blue">void</span> PublishFrame(IFrame frame,
<span style="color:blue">int</span> index)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color:green">
// Set flags for flat-line values</span><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SetStateFlagsForFlatLineValues(frame.Measurements.Values);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color:green">
// Release adapters waiting on flat-line state</span><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GetExternalEventHandle(<span style="color:#a31515">&quot;FlatLineState&quot;</span>).Set();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span></p>
<p><span style="color:#1f497d">For the adapter that needs to wait for the state to be set before processing, you would only need to add &quot;</span><span style="color:#a31515; font-size:10pt">; waitHandleNames=FlatLineState</span><span style="color:#1f497d">&quot;
 to your connection string.</span></p>
<p><span style="color:#1f497d">That should be it - so now any adapter can &quot;wait&quot; on another for input and/or flags to be assigned before processing the measurements.</span></p>
<p><span style="color:#1f497d">Thanks!<br>
Ritchie</span></p>
</div>
<div></div>
</div>
<hr />
<div class="WikiComments">
<div id="comment26695">
<div class="SubText">
<a name="C26695"></a>
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/staphen.md">staphen</a>
<span class="smartDate" title="2/26/2013 4:29:27 PM" localtimeticks="1361924967">Feb 26, 2013 at 4:29 PM</span>&nbsp;
</div>
See this discussion for information on how adapter dependencies are normally handled &#40;in the alarm system, for instance&#41; without the need for synchronization.<br />
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Multiple_Adapter_Synchronization.files/Discussion_433859.md">Discussion 433859</a><p>
</div>
<div id="comment24851">
<div class="SubText">
<a name="C24851"></a>
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/patpentz.md">patpentz</a>
<span class="smartDate" title="8/30/2012 4:00:47 PM" localtimeticks="1346367647">Aug 30, 2012 at 4:00 PM</span>&nbsp;
</div>
I assume that multiple, dependent adapters would use this mechanism. How does the alarm system handle measurements created by multiple, dependent adapters&#63;<p>
</div>
</div>
<div id="footer">
<hr />
Last edited <span class="smartDate" title="4/17/2013 8:06:52 PM" LocalTimeTicks="1366254412">Apr 17, 2013 at 8:06 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/staphen.md">staphen</a>, version 13<br />
Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Adapter%20Synchronization%20%28Developers%29">CodePlex</a> Oct 5, 2015 by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
