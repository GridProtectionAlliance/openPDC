

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Developers Getting Started</title>



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

<h1>Getting Started with openPDC</h1>

<div class="wikidoc">This guide is intended to aid in building the openPDC software. If you're already familiar with the guide, feel free to use this navigation tool to jump around. If you need to see how to configure the openPDC, please refer to the

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md">Getting Started</a> page, under the User's Documentation.<br>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md#openpdc_developers">Build openPDC from source code</a>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md#get_dev_tools">Get the development tools</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md#get_source_code">Get the source code</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md#build_software">Build the software</a>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md#build_tvacodelibrary">Build the TVA Code Library</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md#build_timeseriesframework">Build the Time Series Framework</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md#build_historian">Build the openPDC Historian</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Getting_Started.md#build_synchrophasor">Build the openPDC Synchrophasor</a>

</li></ul>

</li></ul>

</li></ul>

</div>

<ol>

<hr />

<h2><a name="openpdc_developers"></a>Build openPDC from source code</h2>

<p>OpenPDC is an orchestration of multiple sub projects. The following describes the requirements for configuring a typical development system.</p>

<h3><a name="get_dev_tools"></a>Get the development tools</h3>

<p>You will need to have Microsoft Visual Studio 2010 in order to build and run the openPDC. You can download the trial or purchase the software from Microsoft's website at

<a href="http://msdn.microsoft.com/">Microsoft MSDN</a>.</p>

<p>The openPDC system uses the Microsoft .NET 4.0 Framework. The .NET 4.0 redistributables may be downloaded from:&nbsp;<a href="http://msdn.microsoft.com/en-us/library/5a4x27ek.aspx">.NET 4.0 Framework Stand Alone and Web Installation Instructions</a>.<br>

&nbsp;<br>

Optionally, you can install Microsoft SQL Server Express during the Visual Studio installation if you plan on using a SQL Server database with openPDC.<br>

&nbsp;<br>

Additionally, if you don't have the Team version of Microsoft Visual Studio 2010, you will need to install FxCop. You can download that for free from Microsoft's website at

<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=917023f6-d5b7-41bb-bbc0-411a7d66cf3c&displaylang=en">

FxCop 10.0</a>.</p>

<h3><a name="get_source_code"></a>Get the source code</h3>

<p>To download the source code:</p>

<ol>

<li>Browse to each project site home page listed below </li><li>Click the Source Code tab at the top of the page </li><li>On the right side of the page, under the heading &quot;Latest Version&quot;, click the &quot;Download&quot; link.

</li><li>Click &quot;I Agree&quot; to accept the license agreement. </li><li>Select &quot;Save&quot; and select a destination for the compressed source code files.

</li><li>Navigate to the location where you downloaded the compressed source code files, and extract the source code from the zip archive.

</li></ol>

<p>Source code project site home pages</p>

<ul>

<li><a href="http://tvacodelibrary.codeplex.com">TVA Code Library</a> </li><li><a href="http://timeseriesframework.codeplex.com">Time Series Framework</a> </li><li>Historian (included in the openPDC source code) </li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Synchrophasor</a> (includes Historian - soon to become its own project)

</li><li><a href="http://pmuconnectiontester.codeplex.com">PMU Connection Tester</a> </li><li><a href="http://pmuregistry.codeplex.com">PMU Registry</a> </li></ul>

<h3><a name="build_software"></a>Build the software</h3>

<p>The following subsections describes the requirements for building the openPDC software from the source code using Microsoft Visual Studio.<br>

&nbsp;<br>

<strong>Note 1</strong>:&nbsp; If you're having trouble, you may find that you need to build the solutions in the following order:</p>

<ol>

<li>TVA Code Library </li><li>Time Series Framework </li><li>openPDC TVA.Historian </li><li>openPDC Synchrophasor </li></ol>

<p>See the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#trouble_building_solution">

FAQ</a> for more details.<br>

&nbsp;<br>

<strong>Note 2</strong>:&nbsp; When loading the solutions or projects you may be prompted to use source code control.</p>

<p><strong><a name="build_tvacodelibrary"></a>Build the TVA Code Library</strong></p>

<p>After extracting the TVA Code Library source code, the Visual Studio solution is located in the

<strong>SOURCEDIR\Main\Source</strong> folder.&nbsp;&nbsp;SOURCEDIR is the directory you extracted the source code files to.</p>

<ol>

<li>Open Microsoft Visual Studio </li><li>In the toolbar, go to &quot;File &gt; Open &gt; Project/Solution...&quot; </li><li>Navigate to &quot;SOURCEDIR\Main\Source&quot;, select &quot;TVACodeLibrary.sln&quot;, and click &quot;Open&quot;

</li><li>In the toolbar, go to &quot;Build &gt; Build Solution&quot; </li></ol>

<p><strong><a name="build_timeseriesframework"></a>Build the Time Series Framework</strong></p>

<p>After extracting the Time Series Framework source code, the Visual Studio solution is located in the

<strong>SOURCEDIR\Main\Source</strong> folder.&nbsp; SOURCEDIR is the directory you extracted the source code files to.<br>

&nbsp;<br>

<em><strong>Dependencies</strong></em></p>

<ul>

<li><a href="http://tvacodelibrary.codeplex.com">TVA Code Library</a> </li></ul>

<p><em><strong>Typical Build Procedure</strong></em></p>

<ol>

<li>Open Microsoft Visual Studio </li><li>In the toolbar, go to &quot;File &gt; Open &gt; Project/Solution...&quot; </li><li>Navigate to &quot;SOURCEDIR\Main\Source&quot;, select &quot;TimeSeriesFramework.sln&quot;, and click &quot;Open&quot;

</li><li>If you made changes to the TVA Code Library, then be sure to replace the Project References for the dependency.

</li><li>In the toolbar, go to &quot;Build &gt; Build Solution&quot; </li></ol>

<p><strong><a name="build_historian"></a>Build the openPDC Historian</strong></p>

<p>After extracting the openPDC source code, the Visual Studio solution is located in the

<strong>SOURCEDIR\Historian\Current Version\Source</strong> folder.&nbsp;&nbsp;SOURCEDIR is the directory&nbsp;you extracted the source code files to.<br>

&nbsp;<br>

<em><strong>Dependencies</strong></em></p>

<ul>

<li><a href="http://tvacodelibrary.codeplex.com">TVA Code Library</a> </li><li><a href="http://timeseriesframework.codeplex.com">Time Series Framework</a> </li></ul>

<p><em><strong>Typical Build Procedure</strong></em></p>

<ol>

<li>Open Microsoft Visual Studio </li><li>In the toolbar, go to &quot;File &gt; Open &gt; Project/Solution...&quot; </li><li>Navigate to &quot;SOURCEDIR\Historian\Current Version\Source&quot;, select &quot;Historian.sln&quot;, and click &quot;Open&quot;

</li><li>If you made changes to the TVA Code Library or Time Series Framework, then be sure to replace the Project References for those dependencies.

</li><li>In the toolbar, go to &quot;Build &gt; Build Solution&quot; </li></ol>

<p><strong><a name="build_synchrophasor"></a>Build the openPDC Synchrophasor</strong></p>

<p>After extracting the openPDC source code, the Visual Studio solution is located in the

<strong>SOURCEDIR\Current Version\Source</strong> folder.&nbsp; SOURCEDIR is the directory you extracted the source code files to.<br>

&nbsp;<br>

<em><strong>Dependencies</strong></em></p>

<ul>

<li><a href="http://tvacodelibrary.codeplex.com">TVA Code Library</a> </li><li><a href="http://timeseriesframework.codeplex.com">Time Series Framework</a> </li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">TVA.Historian</a> </li></ul>

<p><em><strong>Typical Build Procedure</strong></em></p>

<ol>

<li>Open Microsoft Visual Studio </li><li>In the toolbar, go to &quot;File &gt; Open &gt; Project/Solution...&quot; </li><li>Navigate to &quot;SOURCEDIR\Synchrophasor\Current Version\Source&quot;, select &quot;Synchrophasor.sln&quot;, and click &quot;Open&quot;

</li><li>If you made changes to the TVA Code Library, Time Series Framework, or TVA.Historian, then be sure to replace the Project References for those dependencies.

</li><li>In the toolbar, go to &quot;Build &gt; Build Solution&quot; </li></ol>

<hr>

</li></ol>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="6/25/2012 8:25:00 PM" LocalTimeTicks="1340681100">Jun 25, 2012 at 8:25 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/alexfoglia.md">alexfoglia</a>, version 3<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Getting%20Started%20%28Developers%29">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


