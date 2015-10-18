

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Developers Automated Phasor Tag Naming Convention</title>



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

<p>&nbsp;</p>

<p><strong><span style="font-size:2em">Automated Phasor Tag Naming Convention</span></strong></p>

<p>&nbsp;</p>

<p><span style="color:navy; font-family:Arial,sans-serif; font-size:10pt">In a semi-formal summary, the following is the format the openPDC uses for its automated tag naming convention &nbsp;used to identify measurements:</span></p>

<p><span style="color:navy; font-family:Arial,sans-serif; font-size:10pt"><br>

</span></p>

<div>

<p><strong><em><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">BNF Grammar:</span></em></strong></p>

<table border="0" cellspacing="0" cellpadding="0" style="border-collapse:collapse">

<tbody>

<tr style="height:.2in">

<td width="102" valign="top" style="width:76.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">Digit</span></strong></p>

</td>

<td width="30" valign="top" style="width:22.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">:=</span></p>

</td>

<td width="179" valign="top" style="width:134.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">[&quot;A-Z&quot;, &quot;0-9&quot;, -, !, _, @, #, \$]</span></p>

</td>

<td width="708" valign="top" style="width:531.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">Upper case letters, numbers, '!', '-', '@', '#', '_' and '$' are allowed characters</span></p>

</td>

</tr>

<tr style="height:.2in">

<td width="102" valign="top" style="width:76.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">CompanyID</span></strong></p>

</td>

<td width="30" valign="top" style="width:22.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">:=</span></p>

</td>

<td width="179" valign="top" style="width:134.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">&lt;Digit&gt;{3}

</span></p>

</td>

<td width="708" valign="top" style="width:531.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">3 Digit company abbreviation, example list below</span></p>

</td>

</tr>

<tr style="height:.2in">

<td width="102" valign="top" style="width:76.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">PMUID</span></strong></p>

</td>

<td width="30" valign="top" style="width:22.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">:=</span></p>

</td>

<td width="179" valign="top" style="width:134.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">&lt;Digit&gt;&#43;</span></p>

</td>

<td width="708" valign="top" style="width:531.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">Variable length device acronymn</span></p>

</td>

</tr>

<tr style="height:.2in">

<td width="102" valign="top" style="width:76.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">Constraint</span></strong></p>

</td>

<td width="30" valign="top" style="width:22.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">:=</span></p>

</td>

<td width="179" valign="top" style="width:134.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">&lt;Digit&gt;&#43;</span></p>

</td>

<td width="708" valign="top" style="width:531.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">Optional variable length uniqueness constraint, typically phase angle or magnitude reference and index (e.g., PA1 or PM3)</span></p>

</td>

</tr>

<tr style="height:.2in">

<td width="102" valign="top" style="width:76.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">PMUType</span></strong></p>

</td>

<td width="30" valign="top" style="width:22.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">:=</span></p>

</td>

<td width="179" valign="top" style="width:134.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">&lt;Digit&gt;{3}</span></p>

</td>

<td width="708" valign="top" style="width:531.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">Optional 3 digit PMU Type/Brand, list suggested below</span></p>

</td>

</tr>

<tr style="height:.2in">

<td width="102" valign="top" style="width:76.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">SignalType</span></strong></p>

</td>

<td width="30" valign="top" style="width:22.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">:=</span></p>

</td>

<td width="179" valign="top" style="width:134.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">&lt;Digit&gt;&lt;Digit&gt;?</span></p>

</td>

<td width="708" valign="top" style="width:531.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">1 or 2 digit signal type code, list suggested below</span></p>

</td>

</tr>

<tr style="height:.2in">

<td width="102" valign="top" style="width:76.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">TagName</span></strong></p>

</td>

<td width="30" valign="top" style="width:22.8pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">:=</span></p>

</td>

<td colspan="2" width="887" valign="top" style="width:665.0pt; padding:0in 5.4pt 0in 5.4pt; height:.2in">

<p><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:navy">&lt;CompanyID&gt; &ldquo;_&rdquo; &lt;PMUID&gt; ( &ldquo;-&rdquo; &lt;Constraint&gt; )? &ldquo;:&rdquo; &lt;PMUType&gt;? &lt;SignalType&gt;</span></p>

</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<p><strong><em><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Described verbally, the measurement point tag name will be defined as follows:</span></em></strong></p>

<p style="margin-left:.5in; text-indent:-.5in"><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">1)</span><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">A three digit company ID followed by an underscore, followed by</span></p>

<p style="margin-left:.5in; text-indent:-.5in"><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">2)</span><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">The PMU/device acronym, followed by</span></p>

<p style="margin-left:.5in; text-indent:-.5in"><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">3)</span><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">A dash and optionally a phase angle (i.e., &quot;PA&quot;) or magnitude (i.e., &quot;PM&quot;) marker with index needed to create a unique point name, followed by</span></p>

<p style="margin-left:.5in; text-indent:-.5in"><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">4)</span><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">A colon and an optional three digit PMU brand abbreviation, followed by</span></p>

<p style="margin-left:.5in; text-indent:-.5in"><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">5)</span><span style="font-size:7.0pt; color:navy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">A 1 or 2 digit signal type</span></p>

<p style="margin-left:.5in; text-indent:-.5in"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">&nbsp;</span><span style="color:navy; font-family:Arial,sans-serif; font-size:10pt">&nbsp;</span></p>

<p><strong><em><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Example 3-Digit Company Abbreviations:</span></em></strong><span style="color:navy; font-family:Arial,sans-serif; font-size:10pt">&nbsp;</span></p>

<table border="0" cellspacing="0" cellpadding="0" style="border-collapse:collapse">

<tbody>

<tr>

<td valign="top" style="border:solid #669999 1.0pt; background:navy; padding:0in 5.4pt 0in 5.4pt">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#ffff99">Company Name</span></strong></p>

</td>

<td valign="top" style="border:solid #669999 1.0pt; border-left:none; background:navy; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><strong><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#ffff99">Abbreviation</span></strong></p>

</td>

</tr>

<tr>

<td valign="top" style="border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Entergy</span></p>

</td>

<td valign="top" style="border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">ENT</span></p>

</td>

</tr>

<tr>

<td valign="top" style="border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">TVA</span></p>

</td>

<td valign="top" style="border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">TVA</span></p>

</td>

</tr>

<tr>

<td valign="top" style="border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Amern</span></p>

</td>

<td valign="top" style="border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">AMR</span></p>

</td>

</tr>

<tr>

<td valign="top" style="border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">New York</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy"> ISO</span></p>

</td>

<td valign="top" style="border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">NYI</span></p>

</td>

</tr>

<tr>

<td valign="top" style="border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">New York</span><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy"> Power Authority</span></p>

</td>

<td valign="top" style="border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">NYP</span></p>

</td>

</tr>

<tr>

<td valign="top" style="border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">NERC</span></p>

</td>

<td valign="top" style="border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">NRC</span></p>

</td>

</tr>

<tr>

<td valign="top" style="border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">AEP</span></p>

</td>

<td valign="top" style="border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">AEP</span></p>

</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<p><strong><em><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Suggested PMU Type/Brand List:</span></em></strong></p>

<table border="0" cellspacing="0" cellpadding="0" style="border-collapse:collapse">

<tbody>

<tr>

<td width="107" valign="top" style="width:80.6pt; border:solid #669999 1.0pt; background:navy; padding:0in 5.4pt 0in 5.4pt">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#ffff99">PMU Brand</span></strong></p>

</td>

<td width="96" valign="top" style="width:1.0in; border:solid #669999 1.0pt; border-left:none; background:navy; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><strong><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#ffff99">Abbreviation</span></strong></p>

</td>

</tr>

<tr>

<td width="107" valign="top" style="width:80.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Arbiter</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">ARB</span></p>

</td>

</tr>

<tr>

<td width="107" valign="top" style="width:80.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">ABB</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">ABB</span></p>

</td>

</tr>

<tr>

<td width="107" valign="top" style="width:80.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Mehtatech</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">MTA</span></p>

</td>

</tr>

<tr>

<td width="107" valign="top" style="width:80.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Machrodyne</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">MAC</span></p>

</td>

</tr>

<tr>

<td width="107" valign="top" style="width:80.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Schweitzer</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">SEL</span></p>

</td>

</tr>

</tbody>

</table>

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">&nbsp;</span></p>

<p><strong><em><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Signal Type Code List:</span></em></strong></p>

<table border="0" cellspacing="0" cellpadding="0" style="border-collapse:collapse">

<tbody>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; background:navy; padding:0in 5.4pt 0in 5.4pt">

<p><strong><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#ffff99">Signal Type</span></strong></p>

</td>

<td width="96" valign="top" style="width:1.0in; border:solid #669999 1.0pt; border-left:none; background:navy; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><strong><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#ffff99">Abbreviation</span></strong></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Current</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">I</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Voltage</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">V</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Frequency</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">F</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Phase Angle</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">H</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Frequency Error</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">DF</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Status</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">S</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Digital Value 1</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">D1</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Digital Value 2</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">D2</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Analog Value 2</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">A1</span></p>

</td>

</tr>

<tr>

<td width="119" valign="top" style="width:89.6pt; border:solid #669999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">

<p><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">Analog Value 2</span></p>

</td>

<td width="96" valign="top" style="width:1.0in; border-top:none; border-left:none; border-bottom:solid #669999 1.0pt; border-right:solid #669999 1.0pt; padding:0in 5.4pt 0in 5.4pt">

<p style="text-align:center"><span style="font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:navy">A2</span></p>

</td>

</tr>

</tbody>

</table>

</div>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="8/7/2013 5:07:27 PM" LocalTimeTicks="1375920447">Aug 7, 2013 at 5:07 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 6<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Automated%20Phasor%20Tag%20Naming%20Convention">CodePlex</a> Oct 5, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


