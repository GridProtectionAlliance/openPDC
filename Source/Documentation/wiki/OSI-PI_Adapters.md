

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>OSI-PI Adapters</title>



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

<div class="wikidoc">

<h1>openPDC OSI-PI Adapters</h1>

<h3>Minimum Requirements</h3>

<ol>

<li>For openPDC v2.1 or newer, the PI AF-SDK is required to be installed on the openPDC server. For openPDC v2.0 or older, the PI SDK v1.4.0 or greater (use 32-bit or 64-bit to match openPDC) must be installed on the openPDC server. For 64-bit installations

 you must install <b>both</b> the 64-bit SDK and the 32-bit SDK. The GSF OSI-PI adapter library depends on the 64-bit OSI-PI SDK libraries as well as the OSI-PI Buffering Subsystem which is only installed with the 32-bit SDK.

</li><li>Desired PI server connection must be added to the SDK </li><li>Access to PI system using PI trust (preferred) or explicit login

<ol>

<li>Connection must have access to read/write any points mapped to openPDC. </li><li>If the metadata synchronization is enabled, connection must also have read/write access to the pipoint database.</li></ol>

</li></ol>

<br>

<h3>Output Configuration on an Existing openPDC Installation</h3>

<ol>

<li>Open the openPDC manager and navigate to <b>Outputs &gt; Historians</b>. </li><li>Click the <b>Clear</b> button to create a new historian. </li><li>Type name is PIAdapters.PIOutputAdapter. Assembly name is PIAdapters.dll. </li><li>Connection string should be the following: server=<i>&lt;servername&gt;</i>;

<ol>

<li>For explicit logins, add the following: username=<i>&lt;pi username&gt;</i>;password=<i>&lt;pi password&gt;</i>;

</li><li>To have openPDC create new PI tags for all archived measurements if they don&#39;t already exist, add the following: runMetadataSync=True;</li></ol>

</li><li>Save the adapter configuration. </li><li>Navigate to <b>Manage &gt; Measurements</b>. </li><li>Choose each measurement that should be archived to PI, and change its historian to the PI historian that was set up on the Historians page.</li></ol>

<br>

<h3>Output Configuration on a new openPDC Installation</h3>

<ol>

<li>In the configuration setup utility, make sure to check the &quot;Setup / change the primary historian&quot; checkbox on the &quot;Apply configuration changes&quot; screen.

</li><li>On the next screen, which is the &quot;Set up primary historian&quot; screen, select &quot;PI: Archives measurements to a PI server using AF-SDK&quot;

</li><li>On the &quot;Set up historian connection string&quot; screen, set the servername property to the name of your PI server from the AF-SDK.

<ol>

<li>For explicit logins, set the values of the username and password properties. </li><li>To have openPDC create new PI tags for all archived measurements if they don&#39;t already exist, set the RunMetadataSync Property to True. Otherwise, set it to false.</li></ol>

</li><li>Continue with the setup utility. This will make all your measurements archive to PI by default.</li></ol>

<br>

<h3>Real-time Input Adapter Configuration</h3>

The real-time PI input adapter connects to PI using event pipes, which is the same mechanism process book uses to retrieve real-time data. The adapter also uses the connect on demand feature in openPDC, which allows it to only query PI for data being used by

 an action adapter or output adapter.<br>

<ol>

<li>In the openPDC manager, go to <b>Adapters &gt; Input Adapters</b>. </li><li>Enter a name for the PI input adapter. </li><li>For the type of adapter, choose &quot;PI: Reads real-time measurements from a PI server using AF-SDK.&quot;

</li><li>Set the ServerName property to the name of the PI server from the AF-SDK </li><li>If you wish to connect to the PI server using explicit logins, set the UserName and Password properties too.

</li><li>Add an additional property to the connection string: &quot;ConnectOnDemand=True;&quot;

</li><li>Next, go to the <b>Manage &gt; Measurements</b> screen. </li><li>You will need to manually add measurements that you wish to make available in openPDC. Either the point tag or the alternate tag must match the point&#39;s tag in PI. It is recommended to create a separate historian (probably a virtual output historian)

 to archive all measurements and set the PI adapter&#39;s output measurement key to everything on the historian with a FILTER expression.</li></ol>

</div>

<div></div>

</div>



<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br><br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="2/9/2015 4:30:07 PM" LocalTimeTicks="1423528207">Feb 9 at 4:30 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 4<br />

Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=OSI-PI%20Adapters">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


