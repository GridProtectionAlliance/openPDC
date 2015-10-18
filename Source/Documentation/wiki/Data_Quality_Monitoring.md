

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Data Quality Monitoring</title>



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

<h1>Data Quality Monitoring Adapters</h1>

The data quality monitoring adapters are available in the DataQualityMonitoring project of the Synchrophasor solution. There are three adapters available for monitoring the quality of your data. The flatline test detects when the values of each measurement

 changes in order to determine whether these measurements are continuously reporting the same values. The range test checks the values of incoming measurements to determine whether they fall outside a valid range of values. The timestamp test checks the timestamps

 of the measurements to determine whether they arrived within the lag and lead time constraints defined for the system. This document is intended to aid in the use of these three tests in common openPDC setups.<br>

<ul>

<li><a href="#flatline">Flatline test</a>

<ul>

<li><a href="#configure_flatline">Configuring the flatline test</a> </li><li><a href="#configure_flatline_service">Configuring the flatline test&#39;s web service</a>

</li><li><a href="#use_flatline_service">Using the flatline test&#39;s web service</a></li></ul>

</li><li><a href="#rangetest">Range Test</a>

<ul>

<li><a href="#configure_rangetest">Configuring the range test</a> </li><li><a href="#configure_rangetest_service">Configuring the range test&#39;s web service</a>

</li><li><a href="#use_rangetest_service">Using the range test&#39;s web service</a></li></ul>

</li><li><a href="#timestamp">Timestamp test</a>

<ul>

<li><a href="#configure_timestamp">Configuring the timestamp test</a> </li><li><a href="#configure_timestamp_service">Configuring the timestamp test&#39;s web service</a>

</li><li><a href="#use_timestamp_service">Using the timestamp test&#39;s web service</a></li></ul>

</li></ul>

<hr>

<h2><a name="flatline"></a>Flatline test</h2>

The flatline test is located in the aptly named <span class="codeInline">FlatlineTest.cs</span> file. This test is used to determine whether incoming measurements have been reporting the same value for an unusually long period of time. When running the test,

 there are two ways to determine whether a measurement has flatlined. The first is to read the openPDC Console as the test is designed to periodically send warning messages about flatlined measurements. The second is to query the web service hosted by the adapter.

 The following subsections will describe how to configure the adapter, configure the web service, and use the web service.<br>

<h3><a name="configure_flatline"></a>Configuring the flatline test</h3>

The flatline test is an action adapter and should therefore be entered into the CustomActionAdapter table in the openPDC database. There are eight columns in the CustomActionAdapter table which should be entered as follows.<br>

<br>

<table>

<tbody>

<tr>

<th>Column </th>

<th>Value </th>

</tr>

<tr>

<td>NodeID </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md#Node.ID_column">Node.ID</a>

</td>

</tr>

<tr>

<td>ID </td>

<td><i>default value</i> </td>

</tr>

<tr>

<td>AdapterName </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md#OutputStream.Acronym_column">Acronym</a>

</td>

</tr>

<tr>

<td>AssemblyName </td>

<td>DataQualityMonitoring.dll </td>

</tr>

<tr>

<td>TypeName </td>

<td>DataQualityMonitoring.FlatlineTest </td>

</tr>

<tr>

<td>ConnectionString </td>

<td>See <a href="#flatline_connection_string_examples">examples</a> and <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Connection_Strings.md#DataQualityMonitoring.FlatlineTest">

syntax</a>. </td>

</tr>

<tr>

<td>LoadOrder </td>

<td><i>an integer</i> </td>

</tr>

<tr>

<td>Enabled </td>

<td>true </td>

</tr>

</tbody>

</table>

<br>

<br>

<a name="flatline_connection_string_examples"></a><b>Connection string examples</b><br>

<ul>

<li>Required parameters are <span class="codeInline">lagTime</span>, <span class="codeInline">

leadTime</span>, and <span class="codeInline">framesPerSecond</span>. </li><li>It is highly recommended to use the <span class="codeInline">inputMeasurementKeys</span> parameter.

</li><li>Other optional parameters include <span class="codeInline">minFlatline</span> and

<span class="codeInline">warnInterval</span>. </li><li>See <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Connection_Strings.md#DataQualityMonitoring.FlatlineTest">

adapter connection string syntax</a> for more information.</li></ul>

<br>

This configuration receives all measurements defined in the ActiveMeasurement view. It posts warnings to the console at four second intervals if any measurements have been continuously reporting the same value for at least four seconds.<br>

<span class="codeInline">lagTime=3; leadTime=1; framesPerSecond=30; inputMeasurementKeys={FILTER ActiveMeasurements WHERE ID LIKE &#39;*&#39;}

</span><br>

<br>

This configuration receives all frequencies and phasor measurements defined in the ActiveMeasurement view. It posts warnings to the console at 10 second intervals if any measurements have been continuously reporting the same value for at least one second.<br>

<span class="codeInline">lagTime=3; leadTime=1; framesPerSecond=30; inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = &#39;FREQ&#39; OR SignalType LIKE &#39;*PH*&#39;}; minFlatline=1; warnInterval=10

</span><br>

<br>

<h3><a name="configure_flatline_service"></a>Configuring the flatline test&#39;s web service</h3>

After configuring the flatline test, running the openPDC once will populate the configuration file (openPDC.exe.config) with the settings you need in order to configure the flatline service. These settings will be stored in the section labeled

<span class="codeInline">&lt;aDAPTER_NAMEFlatlineService&gt;</span> (where <span class="codeInline">

aDAPTER_NAME</span> is the name of your adapter with the first letter lowercase). There are only two settings that you may wish to modify.<br>

<br>

<span class="codeInline">Enabled</span> - By default, the value is <span class="codeInline">

false</span>. By setting the value to <span class="codeInline">true</span>, you allow the web service to listen for requests on the specified port. Leaving it false will disable the web service and you will not be able to query for flatlined measurements.<br>

<br>

<span class="codeInline">ServiceUri</span> - By default, the web service will listen on port 6100. If you define more than one flatline test in your system configuration or if port 6100 is already taken by another process, you will need to change the port

 in the ServiceUri to a port that is not in use.<br>

<br>

Note: It is recommended to use only a single flatline test per node and filter all the measurements that need to be tested to that one test. If configured this way, you most likely will not need to modify

<span class="codeInline">ServiceUri</span>.<br>

<br>

<h3><a name="use_flatline_service"></a>Using the flatline test&#39;s web service</h3>

By default, the service can be accessed at the http://localhost:6100/flatlinetest URL. You can view the data in the following ways.<br>

<br>

- http://localhost:6100/flatlinetest/flatlinedmeasurements/read/[xml|json]<br>

Returns all currently flatlined measurements.<br>

<br>

- http://localhost:6100/flatlinetest/flatlinedmeasurements/read/&lt;device acronym&gt;/[xml|json]<br>

Returns all currently flatlined measurements belonging to a particular device.<br>

<hr>

<h2><a name="rangetest"></a>Range test</h2>

When creating the range test, we used the same rationale for naming as we did when creating the flatline test so we decided to place it in the

<span class="codeInline">RangeTest.cs</span> file. This test is used to find when measurements fall outside of a specified range of values. As with the flatline test, there are two ways to determine whether a measurement has fallen outside the specified range.

 The first is to read the openPDC Console as the test is designed to periodically send warning messages about out of range measurements. The second is to query the web service hosted by the adapter. The following subsections will describe how to configure the

 adapter, configure the web service, and use the web service.<br>

<h3><a name="configure_rangetest"></a>Configuring the range test</h3>

The range test is an action adapter and should therefore be entered into the CustomActionAdapter table in the openPDC database. There are eight columns in the CustomActionAdapter table which should be entered as follows.<br>

<br>

<table>

<tbody>

<tr>

<th>Column </th>

<th>Value </th>

</tr>

<tr>

<td>NodeID </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md#Node.ID_column">Node.ID</a>

</td>

</tr>

<tr>

<td>ID </td>

<td><i>default value</i> </td>

</tr>

<tr>

<td>AdapterName </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md#OutputStream.Acronym_column">Acronym</a>

</td>

</tr>

<tr>

<td>AssemblyName </td>

<td>DataQualityMonitoring.dll </td>

</tr>

<tr>

<td>TypeName </td>

<td>DataQualityMonitoring.RangeTest </td>

</tr>

<tr>

<td>ConnectionString </td>

<td>See <a href="#rangetest_connection_string_examples">examples</a> and <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Connection_Strings.md#DataQualityMonitoring.RangeTest">

syntax</a>. </td>

</tr>

<tr>

<td>LoadOrder </td>

<td><i>an integer</i> </td>

</tr>

<tr>

<td>Enabled </td>

<td>true </td>

</tr>

</tbody>

</table>

<br>

<br>

<a name="rangetest_connection_string_examples"></a><b>Connection string examples</b><br>

<ul>

<li>Required parameters are <span class="codeInline">lagTime</span>, <span class="codeInline">

leadTime</span>, and <span class="codeInline">framesPerSecond</span>. </li><li>One or the other of either <span class="codeInline">signalType</span> or <span class="codeInline">

lowRange</span> and <span class="codeInline">highRange</span> are also required. (<span class="codeInline">signalType</span> takes precedence over

<span class="codeInline">lowRange</span> and <span class="codeInline">highRange</span>.)

</li><li>It is highly recommended to use the <span class="codeInline">inputMeasurementKeys</span> parameter.

</li><li>Other optional parameters include <span class="codeInline">timeToPurge</span> and

<span class="codeInline">warnInterval</span>. </li><li>See <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Connection_Strings.md#DataQualityMonitoring.RangeTest">

adapter connection string syntax</a> for more information.</li></ul>

<br>

This configuration receives all phasor angles defined in the ActiveMeasurement view. It posts warnings to the console at 4 second intervals if any measurements have fallen outside the range of -180 to 180 within the last 1 second.<br>

<span class="codeInline">lagTime=3; leadTime=1; framesPerSecond=30; inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType LIKE &#39;*PHA&#39;}; lowRange=-180; highRange=180

</span><br>

<br>

This configuration receives all frequencies defined in the ActiveMeasurement view. It posts warnings to the console at 10 second intervals if any measurements have fallen outside the

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Connection_Strings.md#DataQualityMonitoring.RangeTest">

default frequency range</a> within the last 2 seconds.<br>

<span class="codeInline">lagTime=3; leadTime=1; framesPerSecond=30; inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = &#39;FREQ&#39;}; signalType=FREQ; timeToPurge=2; warnInterval=10

</span><br>

<br>

<h3><a name="configure_rangetest_service"></a>Configuring the range test&#39;s web service</h3>

After configuring the range test, running the openPDC once will populate the configuration file (openPDC.exe.config) with the settings you need in order to configure the range test&#39;s service. These settings will be stored in the section labeled

<span class="codeInline">&lt;outOfRangeService&gt;</span>. There are only two settings that you may wish to modify.<br>

<br>

<span class="codeInline">Enabled</span> - By default, the value is <span class="codeInline">

false</span>. By setting the value to <span class="codeInline">true</span>, you allow the web service to listen for requests on the specified port. Leaving it false will disable the web service and you will not be able to query for out of range measurements.<br>

<br>

<span class="codeInline">ServiceUri</span> - By default, the web service will listen on port 6101. If port 6101 is already taken by another process, you will need to change the port in the ServiceUri to a port that is not in use.<br>

<br>

Note: Unlike the flatline test, you will need to create multiple instances of the range test in order to test different types of measurements. As a result, the web service is designed to include all range tests defined for the system. There will only be one

 service regardless of the number of tests. As a result, it is not necessary to change any ports if you have defined multiple range tests.<br>

<br>

<h3><a name="use_rangetest_service"></a>Using the range test&#39;s web service</h3>

By default, the service can be accessed at the http://localhost:6101/rangetest URL. You can view the data in the following ways.<br>

<br>

- http://localhost:6101/rangetest/outofrangemeasurements/read/[xml|json]<br>

Returns all measurements that are currently out of range.<br>

<br>

- http://localhost:6101/rangetest/outofrangemeasurements/read/signaltype:&lt;signal type acronym&gt;/[xml|json]<br>

Returns all measurements that are currently out of range with the given signal type.<br>

<br>

- http://localhost:6101/rangetest/outofrangemeasurements/read/device:&lt;device acronym&gt;/[xml|json]<br>

Returns all measurements that are currently out of range belonging to a particular device.<br>

<br>

- http://localhost:6101/rangetest/outofrangemeasurements/read/test:&lt;range test acronym&gt;/[xml|json]<br>

Returns all measurements that are being tested by a specific range test and are currently out of range.<br>

<hr>

<h2><a name="timestamp"></a>Timestamp test</h2>

The timestamp test is located in the <span class="codeInline">TimestampTest.cs</span> file. This test is used to find when measurements arrive to the system with bad timestamps. As with the the other tests, there are two ways to determine whether a measurement

 has arrived with a bad timestamp. The first is to read the openPDC Console as the test is designed to periodically send warning messages about measurements with bad timestamps. The second is to query the web service hosted by the adapter. The following subsections

 will describe how to configure the adapter, configure the web service, and use the web service.<br>

<h3><a name="configure_timestamp"></a>Configuring the timestamp test</h3>

The timestamp test is an action adapter and should therefore be entered into the CustomActionAdapter table in the openPDC database. There are eight columns in the CustomActionAdapter table which should be entered as follows.<br>

<br>

<table>

<tbody>

<tr>

<th>Column </th>

<th>Value </th>

</tr>

<tr>

<td>NodeID </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md#Node.ID_column">Node.ID</a>

</td>

</tr>

<tr>

<td>ID </td>

<td><i>default value</i> </td>

</tr>

<tr>

<td>AdapterName </td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md#OutputStream.Acronym_column">Acronym</a>

</td>

</tr>

<tr>

<td>AssemblyName </td>

<td>DataQualityMonitoring.dll </td>

</tr>

<tr>

<td>TypeName </td>

<td>DataQualityMonitoring.TimestampTest </td>

</tr>

<tr>

<td>ConnectionString </td>

<td>See <a href="#timestamp_connection_string_examples">examples</a> and <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Connection_Strings.md#DataQualityMonitoring.TimestampTest">

syntax</a>. </td>

</tr>

<tr>

<td>LoadOrder </td>

<td><i>an integer</i> </td>

</tr>

<tr>

<td>Enabled </td>

<td>true </td>

</tr>

</tbody>

</table>

<br>

<br>

<a name="timestamp_connection_string_examples"></a><b>Connection string examples</b><br>

<ul>

<li>Only one required parameter, <span class="codeInline">concentratorName</span>.

</li><li>Other optional parameters include <span class="codeInline">timeToPurge</span> and

<span class="codeInline">warnInterval</span>. </li><li>The <span class="codeInline">concentratorName</span> parameter is the name or acronym of another action adapter that makes use of its DiscardingMeasurements event (ActionAdapterBase makes use of this event).

</li><li>See <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Connection_Strings.md#DataQualityMonitoring.TimestampTest">

adapter connection string syntax</a> for more information.</li></ul>

<br>

This configuration receives all measurements that arrived with bad timestamps to the TESTSTREAM adapter. It posts warnings to the console at 4 second intervals if any measurements have arrived with bad timestamps within the last 1 second.<br>

<span class="codeInline">concentratorName=TESTSTREAM </span><br>

<br>

This configuration receives all measurements that arrived with bad timestamps to the TESTSTREAM adapter. It posts warnings to the console at 10 second intervals if any measurements have arrived with bad timestamps within the last 2 seconds.<br>

<span class="codeInline">concentratorname=TESTSTREAM; timeToPurge=2; warnInterval=10

</span><br>

<br>

<h3><a name="configure_timestamp_service"></a>Configuring the timestamp test&#39;s web service</h3>

After configuring the timestamp test, running the openPDC once will populate the configuration file (openPDC.exe.config) with the settings you need in order to configure the timestamp test&#39;s service. These settings will be stored in the section labeled

<span class="codeInline">&lt;aDAPTER_NAMETimestampService&gt;</span> (where <span class="codeInline">

aDAPTER_NAME</span> is the name of your adapter with the first letter lowercase). There are only two settings that you may wish to modify.<br>

<br>

<span class="codeInline">Enabled</span> - By default, the value is <span class="codeInline">

false</span>. By setting the value to <span class="codeInline">true</span>, you allow the web service to listen for requests on the specified port. Leaving it false will disable the web service and you will not be able to query for out of range measurements.<br>

<br>

<span class="codeInline">ServiceUri</span> - By default, the web service will listen on port 6102. If you define more than one timestamp test in your system configuration or if port 6102 is already taken by another process, you will need to change the port

 in the ServiceUri to a port that is not in use.<br>

<br>

<h3><a name="use_timestamp_service"></a>Using the timestamp test&#39;s web service</h3>

By default, the service can be accessed at the http://localhost:6102/timestamptest URL. You can view the data in the following ways.<br>

<br>

- http://localhost:6102/timestamptest/badtimestampmeasurements/read/[xml|json]<br>

Returns all measurements that have recently arrived with bad timestamps.<br>

<br>

- http://localhost:6102/timestamptest/badtimestampmeasurements/read/&lt;device acronym&gt;/[xml|json]<br>

Returns all measurements from the specified device that have recently arrived with bad timestamps.</div>

<div></div>

</div>



<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br><br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="4/29/2010 4:11:27 PM" LocalTimeTicks="1272582687">Apr 29, 2010 at 4:11 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/staphen.md">staphen</a>, version 13<br />

Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=Data%20Quality%20Monitoring">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


