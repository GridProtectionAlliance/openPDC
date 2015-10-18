

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Enabling_Security_for_Historian_Web_Services</title>



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

<h2>Enabling Security for Historian Web Services</h2>

Below are a few easy steps to turn on security for the historian time-series data services. This uses the same role-based security as defined in the openPDC, i.e., you will control access to the web service using the openPDC Manager security configuration.<br>

<br>

In the example configuration steps defined below as long as a user and/or group has a &quot;role&quot; defined in the openPDC security system (i.e., a Windows user and/or group has a defined role of Administrator, Editor or Viewer) then they can access the

 read portion of the web service. Only Administrator and Editor roles will have write access.<br>

<br>

You can modify the IncludedResources value to further control security if needed, e.g., allow different access control to statistics and data historians. For example, setting the IncludedResources value to &quot;*:6152/historian/timeseriesdata/read/*=*; *:6152/historian/timeseriesdata/write/*=Administrator,Editor;&quot;

 would turn on security for data historian but not statistics historian.<br>

<br>

If you want any user or group that has a role defined in the openPDC to have access to read or writes in any of the historian web services, the value to insert into IncludedResources can be very simple: &quot;*/historian/*=*; &quot;.<br>

<br>

Configuration steps:<br>

<ol>

<li>Stop openPDC service </li><li>Edit openPDC.exe.config file (have to run editor with admin access) and make following changes:

<ul>

<li><b>configuration\categorizedSettings\securityProvider\add name=&quot;IncludedResources&quot;</b>- insert the following text into the value &quot;*/historian/timeseriesdata/read/*=*; */historian/timeseriesdata/write/*=Administrator,Editor; &quot;

</li><li><b>configuration\categorizedSettings\ppaTimeSeriesDataService\add name=&quot;SecurityPolicy&quot;</b> - set value to &quot;GSF.ServiceModel.SecurityPolicy, GSF.ServiceModel&quot;</li></ul>

</li><li>Save openPDC.exe.config </li><li>Restart openPDC service</li></ol>

<br>

XML updates should look similar to the following:<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">&lt;</span><span style="color:#A31515">configuration</span><span style="color:Blue">&gt;</span>

  <span style="color:Blue">&lt;</span><span style="color:#A31515">categorizedSettings</span><span style="color:Blue">&gt;</span>

    <span style="color:Blue">&lt;</span><span style="color:#A31515">securityProvider</span><span style="color:Blue">&gt;</span>

      <span style="color:Blue">&lt;</span><span style="color:#A31515">add</span> <span style="color:Red">name</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">IncludedResources</span><span style="color:Black">&quot;</span> 

        <span style="color:Red">value</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">*/historian/timeseriesdata/read/*=*; */historian/timeseriesdata/write/*=Administrator,Editor;  UpdateSettings,UpdateConfigFile=Special; Settings,Schedules,Help,Status,Version,Time,Health,List,Invoke,ListCommands,ListReports,GetReport=*; Processes,Start,ReloadCryptoCache,ReloadSettings,Reschedule,Unschedule,SaveSchedules,LoadSchedules,ResetHealthMonitor,Connect,Disconnect,Initialize,ReloadConfig,Authenticate,RefreshRoutes,TemporalSupport,LogEvent,GenerateReport,ReportingConfig=Administrator,Editor; *=Administrator</span><span style="color:Black">&quot;</span>

        <span style="color:Red">description</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">Semicolon delimited list of resources to be secured along with role names.</span><span style="color:Black">&quot;</span> <span style="color:Red">encrypted</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">false</span><span style="color:Black">&quot;</span> <span style="color:Blue">/&gt;</span>

    <span style="color:Blue">&lt;/</span><span style="color:#A31515">securityProvider</span><span style="color:Blue">&gt;</span>

    <span style="color:Blue">&lt;</span><span style="color:#A31515">ppaTimeSeriesDataService</span><span style="color:Blue">&gt;</span>

      <span style="color:Blue">&lt;</span><span style="color:#A31515">add</span> <span style="color:Red">name</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">SecurityPolicy</span><span style="color:Black">&quot;</span> 

        <span style="color:Red">value</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">GSF.ServiceModel.SecurityPolicy, GSF.ServiceModel</span><span style="color:Black">&quot;</span>

        <span style="color:Red">description</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">Assembly qualified name of the authorization policy to be used for securing the web service.</span><span style="color:Black">&quot;</span> <span style="color:Red">encrypted</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">false</span><span style="color:Black">&quot;</span> <span style="color:Blue">/&gt;</span>

    <span style="color:Blue">&lt;/</span><span style="color:#A31515">ppaTimeSeriesDataService</span><span style="color:Blue">&gt;</span>

  <span style="color:Blue">&lt;/</span><span style="color:#A31515">categorizedSettings</span><span style="color:Blue">&gt;</span>

<span style="color:Blue">&lt;/</span><span style="color:#A31515">configuration</span><span style="color:Blue">&gt;</span>

</pre>

</div>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="6/19/2014 6:56:04 PM" LocalTimeTicks="1403229364">Jun 19, 2014 at 6:56 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 7<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Enabling%20Security%20for%20Historian%20Web%20Services">CodePlex</a> Oct 2, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


