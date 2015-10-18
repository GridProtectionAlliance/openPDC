

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Developers About the Signal Reference</title>



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

<p><strong><span style="font-size:14pt">Signal Reference Notes:</span></strong></p>

<p>For synchrophasor measurements the signal reference field is critical - it is used to map device elements in a protocol frame (e.g., IEEE C37.118) to and from measurements. The format of this field is very regular:&nbsp;</p>

<p style="padding-left:60px">The text based signal reference field must contain the Acroynm of the associated Device, followed by a dash (&lsquo;-&lsquo;), followed by the two character SignalType Suffix then optionally followed by an index. Note that the mapping

 is by order, not by index or name.&nbsp; Thus, it is critical that the indexed measurements be modeled in the order that they are returned from the source device. For example SHELBY-PM4 represents the fourth phasor magnitude for the SHELBY Device and&nbsp;

 SHELBY-SF represents its status flags.</p>

<p>The information below describes the original specification:</p>

<hr>

<p><span style="font-size:10pt">In order to rebroadcast data from the sub-second sources, a field is required to be able to associate each point with its associated &quot;field&quot; in a synchrophasor protocol data frame. This document defines these relations.</span></p>

<p><span style="font-size:10pt">This field is normally for internal use only and is stored in a field associated with each defined measurement point:</span></p>

<div style="padding-left:60px">

<table border="1" cellspacing="0" cellpadding="0">

<tbody>

<tr align="center" valign="middle" style="background-color:#c4bfc1; height:50px">

<td width="205"><span style="color:#000000"><strong><span style="font-size:8pt">Type of Point</span></strong></span></td>

<td width="85"><span style="color:#000000"><strong><span style="font-size:8pt">Abbreviation</span></strong></span></td>

<td width="84"><span style="color:#000000"><strong><span style="font-size:8pt">Indexed?</span></strong></span></td>

</tr>

<tr align="center" valign="middle" style="height:50px">

<td width="205"><span style="font-size:8pt">Phasor Magnitude<br>

i.e., Voltage (Volts) or Current (Amps)</span></td>

<td width="85"><strong><span style="font-size:8pt">PM</span></strong></td>

<td width="84"><span style="font-size:8pt">Yes</span></td>

</tr>

<tr align="center" valign="middle" style="height:50px">

<td width="205"><span style="font-size:8pt">Phasor Angle<br>

i.e., Angle (Degrees)</span></td>

<td width="85"><strong><span style="font-size:8pt">PA</span></strong></td>

<td width="84"><span style="font-size:8pt">Yes</span></td>

</tr>

<tr align="center" valign="middle" style="height:50px">

<td width="205"><span style="font-size:8pt">Frequency<br>

i.e., Frequency (Hz)</span></td>

<td width="85"><strong><span style="font-size:8pt">FQ</span></strong></td>

<td width="84"><span style="font-size:8pt">No</span></td>

</tr>

<tr align="center" valign="middle" style="height:50px">

<td width="205"><span style="font-size:8pt">dF/dt<br>

i.e., Frequency rate of change</span></td>

<td width="85"><strong><span style="font-size:8pt">DF</span></strong></td>

<td width="84"><span style="font-size:8pt">No</span></td>

</tr>

<tr align="center" valign="middle" style="height:50px">

<td width="205"><span style="font-size:8pt">Digital Value</span></td>

<td width="85"><strong><span style="font-size:8pt">DV</span> </strong></td>

<td width="84"><span style="font-size:8pt">Yes</span></td>

</tr>

<tr align="center" valign="middle" style="height:50px">

<td width="205"><span style="font-size:8pt">&nbsp;</span><span style="font-size:8pt">Analog Value</span></td>

<td width="85"><strong><span style="font-size:8pt">AV&nbsp;</span></strong></td>

<td width="84"><span style="font-size:8pt">&nbsp;Yes</span></td>

</tr>

<tr align="center" valign="middle" style="height:50px">

<td width="205"><span style="font-size:8pt">Status Flags</span></td>

<td width="85"><strong><span style="font-size:8pt">SF</span></strong></td>

<td width="84"><span style="font-size:8pt">No</span></td>

</tr>

</tbody>

</table>

</div>

<div><span style="font-size:10pt">&nbsp;</span></div>

<div><span style="font-size:10pt">Examples below follow the prescribed format of: the PMU/device acronym, a dash and one of the above abbreviations. Also, if the type of point is indexed, adding the associated entry index, for example:</span></div>

<div><span style="font-size:10pt">&nbsp;</span></div>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PM1&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Magnitude associated with Phasor1 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PA1&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Angle associated with Phasor1 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PM2&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Magnitude associated with Phasor2 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PA2&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Angle associated with Phasor2 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PM3&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Magnitude associated with Phasor3 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PA3&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Angle associated with Phasor3 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PM4&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Magnitude associated with Phasor4 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PA4&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Angle associated with Phasor4 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PM5&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Magnitude associated with Phasor5 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-PA5&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Angle associated with Phasor5 entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-FQ&nbsp;&nbsp;&nbsp;

</span><span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Frequency value associated with Frequency entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-DF&nbsp;&nbsp;&nbsp;

</span><span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Rate of frequency change associated with Frequency entry</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-DV1&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Digital Value 1</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-DV2&nbsp;&nbsp; </span>

<span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Digital Value 2</span></p>

<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; line-height:normal; page-break-after:avoid">

<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;">SHELBY-SF&nbsp;&nbsp;&nbsp;

</span><span style="font-size:9.0pt; font-family:Wingdings">&szlig;</span><span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"> Status Flags</span></p>

<p><span style="font-size:10pt">&nbsp;</span></p>

<p><span style="font-size:10pt">Using this information you can map individual measurements to and from most any synchrophasor protocol data frame.</span></p>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="4/12/2013 5:55:03 PM" LocalTimeTicks="1365814503">Apr 12, 2013 at 5:55 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 7<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=About%20the%20Signal%20Reference">CodePlex</a> Oct 5, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


