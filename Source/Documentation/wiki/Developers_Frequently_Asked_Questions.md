

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Developers Frequently Asked Questions</title>



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

<h1>openPDC Frequently Asked Questions</h1>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md#trouble_building_solution">I am having trouble building the solution, what I am doing wrong?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md#synchrophasor">Synchrophasor Questions</a>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md#synchrophasor_openpdc">openPDC Questions</a>

<br>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md#synchrophasor_project_type_not_supported">When I open the Synchrophasor solution, I get the following message: &ldquo;The project &ldquo;&hellip;&rdquo; cannot be

 opened. The project type is not supported by this installation&rdquo;. What is this?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md#synchrophasor_pmu_connection_tester_shows_a_million_errors">After I have rebuilt the Framework solution while the Synchrophasor solution is open, then try to rebuild

 Synchrophasor, the PMU Connection Tester shows a million errors, what is that?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md#synchrophasor_which_adapter_type">I'd like to create my own custom adapter. What are the various types of adapters used for?</a>

</li></ul>

</li></ul>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md#historian">Historian Questions</a>

<br>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.md#binary_format_of_history_documented">Is the binary format of the history file documented?</a>

</li></ul>

</li></ul>

<h4><a name="trouble_building_solution"></a><span style="text-decoration:underline">Question</span>: I am having trouble building the solution, what I am doing wrong?</h4>

<p><span style="text-decoration:underline">Answer</span>: The solutions have the following dependencies: Synchrophasor depends on Historian and Framework. Historian depends on Framework. So, make sure you rebuild all projects in the solutions in this order:

 Framework, Historian, Synchrophasor.<br>

<br>

</p>

<hr>

<h2><a name="synchrophasor"></a>Synchrophasor Questions</h2>

<h3><a name="synchrophasor_openpdc"></a>openPDC Questions</h3>

<h4><a name="synchrophasor_project_type_not_supported"></a><span style="text-decoration:underline">Question</span>: When I open the Synchrophasor solution, I get the following message: &ldquo;The project &ldquo;&hellip;&rdquo; cannot be opened. The project

 type is not supported by this installation&rdquo;. What is this?</h4>

<p><span style="text-decoration:underline">Answer</span>: The Synchrophasor solution includes a Silverlight application, as well as a Visual Basic application. This error can be safely ignored if you do not wish to view and/or modify the openPDCManager (based

 on Silverlight) or the PMU Connection Tester (based on VB.NET). To load the Silverlight application, install the following:</p>

<ol>

<li>Silverlight3 Tools for Visual Studio 2008 SP1: <a href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">

http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&amp;displaylang=en</a>

</li><li>Silverlight3 Toolkit July 2009: <a href="http://silverlight.codeplex.com/Release/ProjectReleases.aspx?ReleaseId=24246">

http://silverlight.codeplex.com/Release/ProjectReleases.aspx?ReleaseId=24246</a> </li></ol>

<p>To load the Visual Basic application, you will need to reinstall Visual Studio, making sure to include &ldquo;Visual Basic&rdquo; as an installed programming language.<br>

<br>

</p>

<h4><a name="synchrophasor_pmu_connection_tester_shows_a_million_errors"></a><span style="text-decoration:underline">Question</span>: After I have rebuilt the Framework solution while the Synchrophasor solution is open, then try to rebuild Synchrophasor,

 the PMU Connection Tester shows a million errors. What is that?</h4>

<p><span style="text-decoration:underline">Answer</span>: This is some kind of Visual Basic project bug related to dynamically updating its references. Right-click on the PMU Connection tester, and select &ldquo;Unload Project&rdquo;. If you are not dealing

 with the connection tester, you can leave it unloaded; otherwise, right-click the project again, and select &ldquo;Reload Project&rdquo; and the errors will be gone.<br>

<br>

</p>

<h4><a name="synchrophasor_which_adapter_type"></a><span style="text-decoration:underline">Question</span>: I'd like to create my own custom adapter. What are the various types of adapters used for?</h4>

<p><span style="text-decoration:underline">Answer</span>: You can do anything you like with any adapter. Basically all adapters are similar in nature but perform the following specific abstract tasks.<br>

<br>

InputAdapters: Typically &ldquo;maps&rdquo; measurements from a data source (i.e., assigns a timestamp and an ID to measured values parsed from a stream of data), new measurements are presented to openPDC by calling &ldquo;void OnNewMeasurements(ICollection&lt;IMeasurement&gt;

 measurements)&rdquo; method. Interface: IInputAdapter, base class: InputAdapterBase<br>

<br>

ActionAdapters: Typically filters and sorts measurements by time allowing adapter to take action on a synchronized set of data provided in the &ldquo;abstract void PublishFrame(IFrame frame, int index)&rdquo; method which adapter overrides (note that frame

 contains a collection of measurements all collected into the same time-indexed frame bucket). If the action causes the creation of new measurements (e.g., phase angle and magnitude used to calculate power), new measurements are presented to openPDC by calling

 &ldquo;void OnNewMeasurements(ICollection&lt;IMeasurement&gt; measurements)&rdquo; method. Interface: IActionAdapter, base class: ActionAdapterBase<br>

<br>

OutputAdapters: Typically queues all measurements (no sorting) for processing. Queued measurements are presented to the adapter for processing in the &ldquo;void ProcessMeasurements(IMeasurement[] measurements)&rdquo; method &ndash; if measurements continue

 to build up in memory and are not processed in a timely manner they will be removed from the queue as protective measure to prevent catastrophic out-of-memory failures. Since output adapters are used to archive data this is often the slowest part in the system

 (disks tend to be a bottleneck), outputs can optionally be set to filter based on a measurement&rsquo;s defined &ldquo;Source&rdquo; property &ndash; this allows multiple outputs to be targeted to several different distributed outputs which allows large systems

 to stay ahead of the incoming data stream. Interface: IOutputAdapter, base class: OutputAdapterBase<br>

<br>

You can read more about creating custom adapters on the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Custom_Adapter.md">

how-to page for custom adapters</a>.<br>

<br>

</p>

<hr>

<h2><a name="historian"></a>Historian Questions</h2>

<h4><a name="binary_format_of_history_documented"></a><span style="text-decoration:underline">Question</span>: Is the binary format of the history file documented?</h4>

<p><span style="text-decoration:underline">Answer</span>: Yes. Click <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Frequently_Asked_Questions.files/openPDC_D_Historical_File_Format.docx">

here</a> for a document that describes the high level format. Also, the binary format for all the data stored in the archive is documented in the individual class files in TVA.Historian class library. A good place to start would be the class files under TVA.Historian.Files

 namespace of TVA.Historian class library project.</p>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="6/25/2012 8:27:46 PM" LocalTimeTicks="1340681266">Jun 25, 2012 at 8:27 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/alexfoglia.md">alexfoglia</a>, version 4<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Frequently%20Asked%20Questions%20%28Developers%29">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


