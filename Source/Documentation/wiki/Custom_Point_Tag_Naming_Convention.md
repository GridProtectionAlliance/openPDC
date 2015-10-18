

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Custom_Point_Tag_Naming_Convention</title>



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

<p>&nbsp;</p>

<h1>Custom Point Tag Naming Convention</h1>

<p><span style="color:#1f497d">As of version 2.0.166, the openPDC now supports custom point tag naming conventions, i.e., the format of the point tag names automatically created by the system for device measurements can now be controlled by an expression.&nbsp;The

 expression is defined in the openPDC.exe.config file under systemSettings\PointTagNameExpression</span></p>

<p><span style="color:#1f497d">As an example, here is a possible tag naming convention expression:</span></p>

<p style="padding-left:30px"><span style="font-size:10pt; color:green">{CompanyAcronym}_{DeviceAcronym}</span>

<span style="font-size:10pt; color:green">[?{SignalType.Source}=Phasor[-{SignalType.Suffix}{SignalIndex}]]:[?{Phase}=A[PhaseA_]][?{Phase}=B[PhaseB_]][?{Phase}=C[PhaseC_]][?{Phase}=&#43;[PosSeq_]][?{Phase}=-[NegSeq_]][?{Phase}=0[ZeroSeq_]]{SignalType.LongAcronym}[?{SignalType.Source}!=Phasor[?{SignalIndex}!=-1[{SignalIndex}]]]</span></p>

<p><span style="color:#1f497d">Here are examples that would come from the expression above assuming a device name of SHELBY:</span></p>

<ul>

<li><span style="font-size:10pt; color:green">GPA_SHELBY-PM1:PosSeq_VoltageMagnitude</span>

</li><li><span style="font-size:10pt; color:green">GPA_SHELBY-PA1:PosSeq_VoltageAngle</span>

</li><li><span style="font-size:10pt; color:green">GPA_SHELBY-PM2:PosSeq_CurrentMagnitude</span>

</li><li><span style="font-size:10pt; color:green">GPA_SHELBY-PA2:PosSeq_CurrentAngle</span>

</li><li><span style="font-size:10pt; color:green">GPA_SHELBY-PM3:PhaseA_VoltageMagnitude</span>

</li><li><span style="font-size:10pt; color:green">GPA_SHELBY-PA3:PhaseA_VoltageAngle</span>

</li><li><span style="font-size:10pt; color:green">GPA_SHELBY-PM4:PhaseA_CurrentMagnitude</span>

</li><li><span style="font-size:10pt; color:green">GPA_SHELBY-PA4:PhaseA_CurrentAngle</span>

</li><li><span style="font-size:10pt; color:green">GPA_SHELBY:Frequency</span> </li><li><span style="font-size:10pt; color:green">GPA_SHELBY:DfDt</span> </li><li><span style="font-size:10pt; color:green">GPA_SHELBY:Analog1</span> </li><li><span style="font-size:10pt; color:green">GPA_SHELBY:Analog2</span> </li><li><span style="font-size:10pt; color:green">GPA_SHELBY:Digital1</span> </li><li><span style="font-size:10pt; color:green">GPA_SHELBY:Digital2</span> </li><li><span style="font-size:10pt; color:green">GPA_SHELBY:StatusFlags</span> </li><li><span style="font-size:10pt; color:green">GPA_SHELBY:QualityFlags</span> </li></ul>

<p><span style="color:#1f497d">The {</span><span style="font-size:10pt; color:green">CompanyAcronym}</span><span style="color:#1f497d">,

</span><span style="font-size:10pt; color:green">{DeviceAcronym}</span><span style="color:#1f497d">,

</span><span style="font-size:10pt; color:green">{VendorAcronym}</span><span style="color:#1f497d">,

</span><span style="font-size:10pt; color:green">{Phase}</span><span style="color:#1f497d"> and

</span><span style="font-size:10pt; color:green">{SignalIndex}</span><span style="color:#1f497d"> are fixed parameter fields.

</span><span style="font-size:10pt; color:green">{Phase}</span><span style="color:#1f497d"> defaults to &quot;_&quot; (underscore) meaning no phase (i.e., tag is not a phasor) and {</span><span style="font-size:10pt; color:green">SignalIndex}</span><span style="color:#1f497d">

 defaults to -1 meaning no signal index (i.e., tag is not enumerated). Any </span>

<span style="font-size:10pt; color:green">{SignalType.*} </span><span style="color:#1f497d">field is derived from the SignalType table in the database (see below). Note that {</span><span style="font-size:10pt; color:green">SignalIndex}</span><span style="color:#1f497d">

 will always be enumerated (i.e., not -1) for the following signal types: IPHM, IPHA, VPHM, VPHA, ALOG, DIGI and STAT; and when

</span><span style="font-size:10pt; color:green">{SignalType.Source}</span><span style="color:#1f497d">=Phasor,

</span><span style="font-size:10pt; color:green">{Phase}</span><span style="color:#1f497d"> will be one of A, B, C, &#43;, -, or 0.</span></p>

<p><span style="color:#1f497d">All field expressions surrounded in&nbsp;</span><span style="font-size:10pt; color:green">{&nbsp;}

</span><span style="color:#1f497d">will be immediately replaced with their string equivalents before further expression evaluation. Note that as a result of the expression syntax &lt;, &gt;, =, !, {, }, [, and ] are reserved symbols. To embed any of these symbols

 into the final point tag name you must prefix the symbol with a backslash, e.g., the expression

</span><span style="font-size:10pt; color:green">\[{SignalType.Acronym}\] </span>

<span style="color:#1f497d">when the acronym was VPHA would result in </span><span style="font-size:10pt; color:green">[VPHA]</span><span style="color:#1f497d">.</span></p>

<p><span style="color:#1f497d">Optional expressions are represented with </span><span style="font-size:10pt; color:green">[?expression[result]]</span><span style="color:#1f497d"> and can be nested (e.g.,

<span style="font-size:10pt; color:green">[?expression1[<font size="2" color="#008000">?expression2[result]</font>]]</span>). Expressions should not contain extraneous white space for proper evaluation.</span></p>

<p><span style="color:#1f497d">Only simple boolean comparison operations are allowed in expressions, e.g., A=B (or A==B), A!=B (or A&lt;&gt;B), A&gt;B, A&gt;=B, A&lt;B and A&lt;=B - nothing more. Any expression that fails to evaluate will be evaluated as FALSE.

 Note that if both left (A) and right (B) operands can be parsed as a number (i.e., as an integer or floating-point value) then the expression will be numerically evaluated otherwise expression will be a culture and case-insensitive string comparison. Nested

 expressions are evaluated as cumulative AND operators. There is no defined nesting limit.</span></p>

<p><span style="color:#1f497d">Note that the </span><span style="font-size:10pt; color:green">{SignalType.*}</span><span style="color:#1f497d"> parameter fields are derived from the following table:</span></p>

<table width="769">

<tbody>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">ID</span></strong></p>

</td>

<td width="169">

<p><strong><span style="color:#1f497d">Name</span></strong></p>

</td>

<td width="77">

<p><strong><span style="color:#1f497d">Acronym</span></strong></p>

</td>

<td width="57">

<p><strong><span style="color:#1f497d">Suffix</span></strong></p>

</td>

<td width="101">

<p><strong><span style="color:#1f497d">Abbreviation</span></strong></p>

</td>

<td width="136">

<p><strong><span style="color:#1f497d">LongAcronym</span></strong></p>

</td>

<td width="64">

<p><strong><span style="color:#1f497d">Source</span></strong></p>

</td>

<td width="126">

<p><strong><span style="color:#1f497d">EngineeringUnits</span></strong></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">1</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Current Magnitude</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">IPHM</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">PM</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">I</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">CurrentMagnitude</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">Phasor</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">Amps</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">2</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Current Phase Angle</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">IPHA</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">PA</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">IH</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">CurrentAngle</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">Phasor</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">Degrees</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">3</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Voltage Magnitude</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">VPHM</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">PM</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">V</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">VoltageMagnitude</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">Phasor</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">Volts</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">4</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Voltage Phase Angle</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">VPHA</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">PA</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">VH</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">VoltageAngle</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">Phasor</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">Degrees</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">5</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Frequency</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">FREQ</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">FQ</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">F</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">Frequency</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">PMU</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">Hz</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">6</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Frequency Delta (dF/dt)</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">DFDT</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">DF</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">DF</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">DfDt</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">PMU</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">&nbsp;</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">7</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Analog Value</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">ALOG</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">AV</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">AV</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">Analog</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">PMU</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">&nbsp;</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">8</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Status Flags</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">FLAG</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">SF</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">S</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">StatusFlags</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">PMU</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">&nbsp;</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">9</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Digital Value</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">DIGI</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">DV</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">DV</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">Digital</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">PMU</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">&nbsp;</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">10</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Calculated Value</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">CALC</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">CV</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">CV</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">Calculated</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">PMU</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">&nbsp;</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">11</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Statistic</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">STAT</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">ST</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">ST</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">Statistic</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">Any</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">&nbsp;</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">12</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Alarm</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">ALRM</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">AL</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">AL</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">Alarm</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">Any</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">&nbsp;</span></p>

</td>

</tr>

<tr>

<td width="36">

<p><strong><span style="color:#1f497d">13</span></strong></p>

</td>

<td width="169">

<p><span style="color:#1f497d">Quality Flags</span></p>

</td>

<td width="77">

<p><span style="color:#1f497d">QUAL</span></p>

</td>

<td width="57">

<p><span style="color:#1f497d">QF</span></p>

</td>

<td width="101">

<p><span style="color:#1f497d">QF</span></p>

</td>

<td width="136">

<p><span style="color:#1f497d">QualityFlags</span></p>

</td>

<td width="64">

<p><span style="color:#1f497d">Frame</span></p>

</td>

<td width="126">

<p><span style="color:#1f497d">&nbsp;</span></p>

</td>

</tr>

</tbody>

</table>

<p><span style="color:#1f497d">&nbsp;</span></p>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="7/25/2014 7:07:57 PM" LocalTimeTicks="1406340477">Jul 25, 2014 at 7:07 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 8<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Custom%20Point%20Tag%20Naming%20Convention">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


