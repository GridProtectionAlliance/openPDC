

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Connection Strings</title>



<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body>

<h1><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>

<hr />

<!--HtmlToGmd.Body-->

<div id="NavigationMenu">

<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">

<tr>

<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->



<div class="WikiContent">

<div class="wikidoc">

<h1>Connection Strings</h1>

<p>This document goes over the options that can be specified using the connection string for each adapter in the system.</p>

<ul>

<li><a href="#ActionAdapterBase">ActionAdapterBase</a> </li><li><a href="#AdapterBase">AdapterBase</a> </li><li><a href="#AdoInputAdapter">AdoInputAdapter</a> </li><li><a href="#AdoOutputAdapter">AdoOutputAdapter</a> </li><li><a href="#BpaPdcStream.Concentrator">BpaPdcStream.Concentrator</a> </li><li><a href="#CalculatedMeasurementBase">CalculatedMeasurementBase</a> </li><li><a href="#CsvAdapters.CsvInputAdapter">CsvAdapters.CsvInputAdapter</a> </li><li><a href="#CsvAdapters.CsvOutputAdapter">CsvAdapters.CsvOutputAdapter</a> </li><li><a href="#DataQualityMonitoring.FlatlineTest">DataQualityMonitoring.FlatlineTest</a>

</li><li><a href="#DataQualityMonitoring.RangeTest">DataQualityMonitoring.RangeTest</a>

</li><li><a href="#DataQualityMonitoring.TimestampTest">DataQualityMonitoring.TimestampTest</a>

</li><li><a href="#FacileActionAdapterBase">FacileActionAdapterBase</a> </li><li><a href="#HistorianAdapters.InputAdapter">HistorianAdapters.InputAdapter</a>

</li><li><a href="#HistorianAdapters.LocalOutputAdapter">HistorianAdapters.LocalOutputAdapter</a>

</li><li><a href="#HistorianAdapters.RemoteOutputAdapter">HistorianAdapters.RemoteOutputAdapter</a>

</li><li><a href="#ICCPExport.FileExporter">ICCPExport.FileExporter</a> </li><li><a href="#IEEEC37_118.Concentrator">IEEEC37_118.Concentrator</a> </li><li><a href="#InputAdapterBase">InputAdapterBase</a> </li><li><a href="#MySqlAdapters.MySqlInputAdapter">MySqlAdapters.MySqlInputAdapter</a>

</li><li><a href="#MySqlAdapters.MySqlOutputAdapter">MySqlAdapters.MySqlOutputAdapter</a>

</li><li><a href="#OutputAdapterBase">OutputAdapterBase</a> </li><li><a href="#PhasorDataConcentratorBase">PhasorDataConcentratorBase</a> </li><li><a href="#PhasorMeasurementMapper">PhasorMeasurementMapper</a> </li><li><a href="#PowerCalculations.AverageFrequency">PowerCalculations.AverageFrequency</a>

</li><li><a href="#PowerCalculations.EventDetection.FrequencyExcursion">PowerCalculations.EventDetection.FrequencyExcursion</a>

</li><li><a href="#PowerCalculations.EventDetection.LossOfField">PowerCalculations.EventDetection.LossOfField</a>

</li><li><a href="#PowerCalculations.PowerStability">PowerCalculations.PowerStability</a>

</li><li><a href="#PowerCalculations.ReferenceAngle">PowerCalculations.ReferenceAngle</a>

</li><li><a href="#PowerCalculations.ReferenceMagnitude">PowerCalculations.ReferenceMagnitude</a>

</li><li><a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a>

</li><li><a href="#time_zone_ids">Typical time zones</a> </li></ul>

<h2><a name="ActionAdapterBase"></a>ActionAdapterBase</h2>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>framesPerSecond</td>

<td>int</td>

<td>&nbsp;</td>

<td>Determines how many frames are published by the action adapter each second.</td>

</tr>

<tr>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Lag_Time">lagTime</a></td>

<td>double</td>

<td>&nbsp;</td>

<td>Defines the maximum time, in seconds, that the action adapter will wait for new measurements to arrive before publishing the frame. The value must be greater than zero, but it can be less than one for subsecond tolerances.</td>

</tr>

<tr>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Lead_Time">leadTime</a></td>

<td>double</td>

<td>&nbsp;</td>

<td>Defines the maximum time, in seconds, that the action adapter will tolerate for measurements that arrive with a future timestamp as compared to &quot;real-time&quot; -- a relative term based on the value of

<em>useLocalClockAsRealTime</em>. The <em>leadTime</em> value is also applied as the &#43;/- tolerance of the local clock to estimate real-time when

<em>useLocalClockAsRealTime</em> is false. The value must be greater than zero, but it can be less than one for subsecond tolerances. If the

<em>leadTime</em> is set too short (relative to the accuracy of the local clock), measurements may be unnecessarily discarded. However, if the local clock is very accurate, and accordingly

<em>useLocalClockAsRealTime</em> is set true, this number should be very small, e.g., 0.1.</td>

</tr>

<tr>

<td><em><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Use_Local_Clock_as_RealTime">useLocalClockAsRealTime</a></em></td>

<td>bool</td>

<td>false</td>

<td>Indicates whether to use the local clock as real-time or to instead use the timestamp of the latest received measurement. This should only be set to true if the local system clock time is derived by GPS or otherwise very accurately synchronized to real-time.

 The accuracy of the local clock time relative to GPS-time determines the needed value for the

<em>leadTime</em> setting. There is less processing involved when <em>useLocalClockAsRealTime</em> is set true, so having the local system clock synchronized with GPS represents a system optimization.</td>

</tr>

<tr>

<td><em><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Ignore_Bad_Timestamps">ignoreBadTimestamps</a></em></td>

<td>bool</td>

<td>false</td>

<td>Determines if bad timestamps (as determined by measurement's timestamp quality) should be ignored when sorting measurements. Setting this property to true forces system to use timestamps as-is without checking quality. If this property is true, it will

 supersede operation of <em>allowSortsByArrival</em>.</td>

</tr>

<tr>

<td><em><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Allow_Sorts_By_Arrival">allowSortsByArrival</a></em></td>

<td>bool</td>

<td>true</td>

<td>Indicates whether measurements with bad timestamps should instead be sorted by their arrival time. If this property is true, any incoming measurement with a bad timestamp quality will be sorted according to its arrival time (i.e., real-time). Setting this

 property to false will cause all measurements with a bad timestamp quality to be discarded. This property will only be considered when

<em>ignoreBadTimestamps</em> is false.</td>

</tr>

<tr>

<td><em>initializationTimeout</em></td>

<td>int</td>

<td>15000</td>

<td>Defines the maximum time, in milliseconds, adapter will wait during start for initialization to complete. Set to -1 to wait indefinitely.</td>

</tr>

<tr>

<td><em>inputMeasurementKeys</em></td>

<td>string</td>

<td>null</td>

<td>Defines the input measurements for the adapter. The adapter can then determine whether a given measurement was explicitly entered as an input measurement by using the IsInputMeasurement(MeasurementKey) method. If no input measurements are defined, IsInputMeasurement(MeasurementKey)

 will always return true. IsInputMeasurement(MeasurementKey) is used by the default QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt;) method so that only input measurements will be processed by the action adapter.</td>

</tr>

<tr>

<td><em>outputMeasurements</em></td>

<td>string</td>

<td>null</td>

<td>Defines the output measurements for the adapter. The adapter can access these measurements using the OutputMeasurements property. Adapters that create new measurements should probably clone the output measurements using Measurement.Clone(IMeasurement) and

 send the clones into the system using OnNewMeasurements(ICollection&lt;IMeasurement&gt;).</td>

</tr>

<tr>

<td><em>minimumMeasurementsToUse</em></td>

<td>int</td>

<td># of input measurements</td>

<td>Defines the number of measurements returned by the TryGetMinimumNeededMeasurements() method which can be called by the user-defined implementation.</td>

</tr>

<tr>

<td><em><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Time_Resolution">timeResolution</a></em></td>

<td>long</td>

<td>10000</td>

<td>Determines the resolution used when sorting the measurements into their respective frames. If frames are configured to have a higher resolution than the measurements, some measurements could end up in the wrong frame due to rounding errors - use this property

 to assign the maximum resolution of the system frames. The maximum value possible is 10000000. The minimum value possible is 0. See table below for typical resolution values.</td>

</tr>

<tr>

<td><em><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Allow_Preemptive_Publishing">allowPreemptivePublishing</a></em></td>

<td>bool</td>

<td>true</td>

<td>Defines the flag that allows system to preemptively publish frames before the lag time expires assuming all expected data have arrived.</td>

</tr>

<tr>

<td><em>performTimestampReasonabilityCheck</em></td>

<td>bool</td>

<td>true</td>

<td>Defines flag that determines if timestamp reasonability checks should be performed on incoming measurements (i.e., measurement timestamps are compared to system clock for reasonability using

<em>leadTime</em> tolerance). Setting this value to false will make the concentrator use the latest value received as &quot;real-time&quot; without validation; this is not recommended in production since time reported by source devices may be grossly incorrect.

 For non-production configurations, setting this value to false will allow concentration of historical data.</td>

</tr>

<tr>

<td><em><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Downsampling_Method">downsamplingMethod</a></em></td>

<td>string</td>

<td>LastReceived</td>

<td>Defines the downsampling method to use if data is being received at a higher rate than the publishing frame rate defined by

<em>framesPerSecond</em>. Can be one of LastReceived, Closest or Filtered - see table below for more detail.</td>

</tr>

<tr>

<td><em>processByReceivedTimestamp</em></td>

<td>bool</td>

<td>false</td>

<td>Defines flag that determines if concentrator should sort measurements by received time. Setting this value to true will make concentrator use the timestamp of measurement reception (typically the measurement creation time), for sorting and publication.

 This is useful in scenarios where the concentrator will be receiving very large volumes of data but not necessarily in real-time, such as, reading values from a file where you want data to be sorted and processed as fast as possible. Setting this value to

 true forces <em>useLocalClockAsRealTime</em> to be true and supercedes operation of

<em>performTimestampReasonabilityCheck</em>.</td>

</tr>

<tr>

<td><em>trackPublishedTimestamp</em></td>

<td>bool</td>

<td>false</td>

<td>Defines flag that determines if system should track timestamp of publication for all frames and measurements. Setting this value to true will cause the concentrator to mark the timestamp of publication in each frame's and measurement's PublishedTimestamp

 property. Since this is extra processing time that may not be needed except in cases of calculating statistics for system performance, this is not enabled by default.</td>

</tr>

<tr>

<td><em>maximumPublicationTimeout</em></td>

<td>int</td>

<td>milliseconds per frame &#43; 2%</td>

<td>Defines the maximum frame publication timeout in milliseconds, set to -1 to wait indefinitely. The concentrator automatically defines a precision timer to provide the heatbeat for frame publication, however if the system gets busy the heartbeat signals

 can be missed. This property defines a maximum wait timeout before reception of the heartbeat signal to make sure frame publications continue to occur in a timely fashion even when a system is under stress. This property is automatically defined as 2% more

 than the number of milliseconds per frame when the <em>framesPerSecond</em> property is set.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of these parameters.<br>

<br>

Time resolution value is typically a power of 10 based on the number of ticks per the desired resolution. The following are common resolutions and their respective

<em>timeResolution</em> values.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Resolution </th>

<th>timeResolution </th>

</tr>

<tr>

<td>Seconds</td>

<td>10000000</td>

</tr>

<tr>

<td>Milliseconds with slack*</td>

<td>330000</td>

</tr>

<tr>

<td>Milliseconds</td>

<td>10000</td>

</tr>

<tr>

<td>Microseconds</td>

<td>10</td>

</tr>

<tr>

<td>Ticks (100-nanoseconds)</td>

<td>0</td>

</tr>

</tbody>

</table>

<p><br>

* Use this setting for BPA PDCstreams or other devices that may have more variation in calculated timestamps. Slack value will vary with incoming frame rate, for example: use 330,000 for 30 frames per second, 160,000 for 60 frames per second, 80,000 for 120

 frames per second, etc. Actual slack value may need to be more or less depending on the size of the timestamp variation in the incoming device stream.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Downsample Method </th>

<th>Description </th>

</tr>

<tr>

<td>LastReceived</td>

<td>Downsamples to the last measurement received. Use this option if no downsampling is needed or the selected value is not critical. This is the fastest option if the incoming and outgoing frame rates match.</td>

</tr>

<tr>

<td>Closest</td>

<td>Downsamples to the measurement closest to frame time. This is the typical operation used when performing simple downsampling. This is the fastest option if the incoming frame rate is faster than the outgoing frame rate.</td>

</tr>

<tr>

<td>Filtered</td>

<td>Downsamples by applying a user-defined value filter* over all received measurements to anti-alias the results. This option will produce the best result but has a processing penalty.</td>

</tr>

</tbody>

</table>

<p><br>

* By default all analogs are downsampled using an average, phase angles are downsampled using a wrapping-angle average and digital values (including status flags) are downsampled by selecting the majority value.<br>

<br>

Example: <span class="codeInline">framesPerSecond=30; lagTime=3; leadTime=1; useLocalClockAsRealTime=false; allowSortsByArrival=false; inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType='FREQ'}; outputMeasurements={MYSOURCE:15;MYSOURCE:16,-180,360};

 minimumMeasurementsToUse=5; timeResolution=10000; allowPreemptivePublishing=true; downsamplingMethod=Closest

</span></p>

<h2><a name="AdapterBase"></a>AdapterBase</h2>

<p>This base class is inherited by both InputAdapterBase and OutputAdapterBase.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>initializationTimeout</em></td>

<td>int</td>

<td>15000</td>

<td>Defines the maximum time, in milliseconds, adapter will wait during start for initialization to complete. Set to -1 to wait indefinitely.</td>

</tr>

<tr>

<td><em>inputMeasurementKeys</em></td>

<td>string</td>

<td>null</td>

<td>Defines the input measurements for the adapter. The adapter can then determine whether a given measurement was explicitly entered as an input measurement by using the IsInputMeasurement(MeasurementKey) method. If no input measurements are defined, IsInputMeasurement(MeasurementKey)

 will always return true.</td>

</tr>

<tr>

<td><em>outputMeasurements</em></td>

<td>string</td>

<td>null</td>

<td>Defines the output measurements for the adapter. The adapter can access these measurements using the OutputMeasurements property. Adapters that create new measurements should probably clone the output measurements using Measurement.Clone(IMeasurement) and

 send the clones into the system using OnNewMeasurements(ICollection&lt;IMeasurement&gt;).</td>

</tr>

<tr>

<td><em>measurementReportingInterval</em></td>

<td>int</td>

<td>100000</td>

<td>Defines the measurement reporting interval used to determined how many measurements should be processed before reporting status. Set to zero to disable status reporting.</td>

</tr>

<tr>

<td><em>connectOnDemand</em></td>

<td>bool</td>

<td>false</td>

<td>Defines a flag that determines if adapter should always be started or only be started when measurements being handled or created are demanded by other adapters in the Iaon session. Set to false to always start adapter; otherwise set to true to start adapter

 only when needed.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'FREQ'}; outputMeasurements={MYSOURCE:15;MYSOURCE:16,-180,360}; measurementReportingInterval=5000

</span><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of these parameters.</p>

<h2><a name="AdoInputAdapter"></a>AdoInputAdapter</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#AdapterBase">AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>tableName</em></td>

<td>string</td>

<td>PICOMP</td>

<td>The name of the database table from which measurements are to be retrieved.</td>

</tr>

<tr>

<td><em>connectionString</em></td>

<td>string</td>

<td>empty string</td>

<td>The connection string used to connect to the database.</td>

</tr>

<tr>

<td><em>dataProviderString</em></td>

<td>string</td>

<td>{AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.Odbc.OdbcConnection; AdapterType=System.Data.Odbc.OdbcDataAdapter}</td>

<td>The string that describes the type of connection and adapter used to connect to the database.</td>

</tr>

<tr>

<td><em>timestampFormat</em></td>

<td>string</td>

<td>dd-MMM-yyyy HH:mm:ss.fff</td>

<td>The format in which the timestamp is stored in the database. The value &quot;null&quot; indicates that the timestamp is stored as a 64-bit integer, in ticks.</td>

</tr>

<tr>

<td><em>framePerSecond</em></td>

<td>int</td>

<td>30</td>

<td>The rate at which frames are published from the database to the concentrator.</td>

</tr>

<tr>

<td><em>simulateTimestamp</em></td>

<td>bool</td>

<td>true</td>

<td>Indicates whether the adapter should replace the existing timestamps in order to simulate measurements entering the concentrator in real time.</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<h2><a name="AdoOutputAdapter"></a>AdoOutputAdapter</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#OutputAdapterBase">OutputAdapterBase</a> and <a href="#AdapterBase">

AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>tableName</em></td>

<td>string</td>

<td>PICOMP</td>

<td>The name of the database table to which measurements are to be stored.</td>

</tr>

<tr>

<td><em>connectionString</em></td>

<td>string</td>

<td>empty string</td>

<td>The connection string used to connect to the database.</td>

</tr>

<tr>

<td><em>dataProviderString</em></td>

<td>string</td>

<td>{AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.Odbc.OdbcConnection; AdapterType=System.Data.Odbc.OdbcDataAdapter}</td>

<td>The string that describes the type of connection and adapter used to connect to the database.</td>

</tr>

<tr>

<td><em>timestampFormat</em></td>

<td>string</td>

<td>dd-MMM-yyyy HH:mm:ss.fff</td>

<td>The format in which the timestamp is to be stored in the database. The value &quot;null&quot; indicates that the timestamp is to be stored as a 64-bit integer, in ticks.</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<h2><a name="BpaPdcStream.Concentrator"></a>BpaPdcStream.Concentrator</h2>

<p>This adapter is used by the OutputStream table in the openPDC database when defining an output stream that uses the BPA PDCstream protocol. When defining an output stream in the OutputStream table, most parameters are set automatically by entering information

 into the columns of the table. Connection strings for this adapter also include all the parameters defined for

<a href="#PhasorDataConcentratorBase">PhasorDataConcentratorBase</a> and <a href="#ActionAdapterBase">

ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>iniFileName</td>

<td>string</td>

<td>&nbsp;</td>

<td>Defines the file name of the INI configuration file for the output stream.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">iniFileName=TESTSTREAM.ini </span></p>

<h2><a name="CalculatedMeasurementBase"></a>CalculatedMeasurementBase</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#ActionAdapterBase">ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>configurationSection</em></td>

<td>string</td>

<td><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Manual_Configuration.md#OutputStream.Acronym_column">Acronym</a></td>

<td>Allows the user to define the section under which adapter settings will be found in the configuration file. If an adapter has configuration file settings, it is up to the person implementing the calculated measurement to handle this.</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<h2><a name="CsvAdapters.CsvInputAdapter"></a>CsvAdapters.CsvInputAdapter</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#AdapterBase">AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>file</em></td>

<td>string</td>

<td>measurements.csv</td>

<td>The path to the CSV file from which measurements are read.</td>

</tr>

<tr>

<td><em>inputInterval</em></td>

<td>double</td>

<td>33.333333</td>

<td>The interval, in milliseconds, at which measurements will be reported to the system.</td>

</tr>

<tr>

<td><em>measurementsPerInterval</em></td>

<td>int</td>

<td>5</td>

<td>The number of measurements to be read from the CSV file at each input interval.</td>

</tr>

<tr>

<td><em>simulateTimestamp</em></td>

<td>bool</td>

<td>false</td>

<td>Determines whether the adapter should attach a simulated timestamp to the measurements so that it appears to be reporting in real time.</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<h2><a name="CsvAdapters.CsvOutputAdapter"></a>CsvAdapters.CsvOutputAdapter</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#OutputAdapterBase">OutputAdapterBase</a> and <a href="#AdapterBase">

AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>file</em></td>

<td>string</td>

<td>measurements.csv</td>

<td>The path to the CSV file from which measurements are read.</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<h2><a name="DataQualityMonitoring.FlatlineTest"></a>DataQualityMonitoring.FlatlineTest</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#ActionAdapterBase">ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>minFlatline</em></td>

<td>double</td>

<td>4</td>

<td>The amount of time, in seconds, that a measurements needs to be reporting the same value before it is considered flatlined.</td>

</tr>

<tr>

<td><em>warnInterval</em></td>

<td>double</td>

<td>4</td>

<td>The amount of time, in seconds, between warnings posted to the openPDC Console.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">minFlatline=2; warnInterval=10 </span></p>

<h2><a name="DataQualityMonitoring.RangeTest"></a>DataQualityMonitoring.RangeTest</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#ActionAdapterbase">ActionAdapterbase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>lowRange</td>

<td>double</td>

<td>&nbsp;</td>

<td>The low range for values being tested by this adapter. If a measurement that is tested by the adapter reports a value lower than the low range, it will be considered out of range.</td>

</tr>

<tr>

<td>highRange</td>

<td>double</td>

<td>&nbsp;</td>

<td>The high range for values being tested by this adapter. If a measurement that is tested by the adapter reports a value higher than the high range, it will be considered out of range.</td>

</tr>

<tr>

<td><em>signalType</em></td>

<td>string</td>

<td>null</td>

<td>Defines the signal type of the measurements being tested. The lowRange and highRange parameters need not be defined if this parameter is defined (and valid). Valid values are FREQ, VPHM, IPHM, VPHA, and IPHA.</td>

</tr>

<tr>

<td><em>timeToPurge</em></td>

<td>double</td>

<td>1.0</td>

<td>Defines how much time should pass, in seconds, before out-of-range measurements should be purged from the system so that memory can be reclaimed and redundant warnings can be prevented.</td>

</tr>

<tr>

<td><em>warnInterval</em></td>

<td>double</td>

<td>4.0</td>

<td>The amount of time, in seconds, between warnings posted to the openPDC Console.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

The following default low ranges and high ranges are defined for specific signal types (the abbreviation is entered as the signalType parameter).<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Abbreviation </th>

<th>Signal Type </th>

<th>Low Range </th>

<th>High Range </th>

</tr>

<tr>

<td>FREQ</td>

<td>Frequency</td>

<td>59.95</td>

<td>60.05</td>

</tr>

<tr>

<td>VPHM</td>

<td>Voltage Phasor Magnitude</td>

<td>475000.0</td>

<td>525000.0</td>

</tr>

<tr>

<td>IPHM</td>

<td>Current Phasor Magnitude</td>

<td>0.0</td>

<td>3000.0</td>

</tr>

<tr>

<td>VPHA</td>

<td>Voltage Phasor Angle</td>

<td>-180.0</td>

<td>180.0</td>

</tr>

<tr>

<td>IPHA</td>

<td>Current Phasor Angle</td>

<td>-180.0</td>

<td>180.0</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">lowRange=59.95; highRange=60.05; signalType=FREQ; timeToPurge=5.0; warnInterval=10.0

</span></p>

<h2><a name="DataQualityMonitoring.TimestampTest"></a>DataQualityMonitoring.TimestampTest</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#FacileActionAdapterBase">FacileActionAdapterBase</a> and <a href="#AdapterBase">

AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>concentratorName</td>

<td>string</td>

<td>&nbsp;</td>

<td>Defines which concentrator will be used to determine whether measurements arrived with bad timestamps. The value of this parameter must be the name of an action adapter.</td>

</tr>

<tr>

<td><em>timeToPurge</em></td>

<td>double</td>

<td>1.0</td>

<td>Defines how much time should pass, in seconds, before out-of-range measurements should be purged from the system so that memory can be reclaimed and redundant warnings can be prevented.</td>

</tr>

<tr>

<td><em>warnInterval</em></td>

<td>double</td>

<td>4.0</td>

<td>The amount of time, in seconds, between warnings posted to the openPDC Console.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">concentratorName=TESTSTREAM; timeToPurge=5.0; warnInterval=10.0

</span></p>

<h2><a name="FacileActionAdapterBase"></a>FacileActionAdapterBase</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#AdapterBase">AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>framesPerSecond</em></td>

<td>int</td>

<td>0</td>

<td>The rate at which frames are published in frames per second.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">framesPerSecond=30 </span></p>

<h2><a name="HistorianAdapters.InputAdapter"></a>HistorianAdapters.InputAdapter</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#AdapterBase">AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>server</td>

<td>string</td>

<td>&nbsp;</td>

<td>The location of the server broadcasting historic data.</td>

</tr>

<tr>

<td>port</td>

<td>int</td>

<td>&nbsp;</td>

<td>The port through which the server is broadcasting data.</td>

</tr>

<tr>

<td>protocol</td>

<td>string</td>

<td>&nbsp;</td>

<td>The protocol used by the server to broadcast the data. Can be either Tcp or Udp.</td>

</tr>

<tr>

<td>initiateconnection</td>

<td>bool</td>

<td>&nbsp;</td>

<td>Indicates whether the adapter needs to connect to the server or if the server will connect to the adapter on the specified port.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">protocol=Udp; server=openpdc; port=2004; initiateconnection=true

</span></p>

<h2><a name="HistorianAdapters.LocalOutputAdapter"></a>HistorianAdapters.LocalOutputAdapter</h2>

<p>This adapter is used by default when defining a <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Manual_Configuration.md#Historian.IsLocal_column">

local historian</a> in the database. Connection strings for this adapter also include all the parameters defined for

<a href="#OutputAdapterBase">OutputAdapterBase</a> and <a href="#AdapterBase">

AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>instancename</td>

<td>string</td>

<td>&nbsp;</td>

<td>Determines the name by which certain historian files will be prefixed. If you are using the Historian table in the database to define a local historian, this option is not required and will default to the value in the Historian.Acronym field. Otherwise,

 it is required. The value will be converted to lowercase before being used.</td>

</tr>

<tr>

<td><em>archivepath</em></td>

<td>string</td>

<td>The openPDC <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.md#install_directory">

installation directory</a>.</td>

<td>Determines the location where the adapter will place the archive files.</td>

</tr>

<tr>

<td><em>refreshmetadata</em></td>

<td>bool</td>

<td>true</td>

<td>Determines whether or not to refresh the metadata when the historian is attempting to connect.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Also note that the sourceids parameter is automatically defined when using the Historian table in the database. It will default to the value in the Historian.Acronym field.<br>

<br>

Example: <span class="codeInline">instancename=devarchive; archivepath=C:\My Archives; refreshmetadata=false

</span></p>

<h2><a name="HistorianAdapters.RemoteOutputAdapter"></a>HistorianAdapters.RemoteOutputAdapter</h2>

<p>This adapter is used by default when defining a <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Manual_Configuration.md#Historian.IsLocal_column">

non-local historian</a> in the database. Connection strings for this adapter also include all the parameters defined for

<a href="#OutputAdapterBase">OutputAdapterBase</a> and <a href="#AdapterBase">

AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>server</td>

<td>string</td>

<td>&nbsp;</td>

<td>The name or address of the remote historian.</td>

</tr>

<tr>

<td><em>port</em></td>

<td>string</td>

<td>1003</td>

<td>The TCP port on which the remote historian is listening.</td>

</tr>

<tr>

<td><em>payloadaware</em></td>

<td>bool</td>

<td>true</td>

<td>Indicates whether the payload boundaries are to be preserved during transmission.</td>

</tr>

<tr>

<td><em>conservebandwidth</em></td>

<td>bool</td>

<td>true</td>

<td>Determines the packet type to use when sending data to the server.</td>

</tr>

<tr>

<td><em>outputisforarchive</em></td>

<td>bool</td>

<td>true</td>

<td>Determines whether the measurements are destined for archival.</td>

</tr>

<tr>

<td><em>throttletransmission</em></td>

<td>bool</td>

<td>true</td>

<td>Determines whether to wait for acknowledgment from the historian that the last set of points have been received before attempting to send the next set of points.</td>

</tr>

<tr>

<td><em>samplespertransmission</em></td>

<td>int</td>

<td>100000</td>

<td>The maximum number of points to be published to the historian at once.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">server=localhost; port=1003; payloadAware=True; conserveBandwidth=True; outputIsForArchive=True; throttleTransmission=True; samplesPerTransmission=100000

</span></p>

<h2><a name="ICCPExport.FileExporter"></a>ICCPExport.FileExporter</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#CalculatedMeasurement">CalculatedMeasurement</a> and <a href="#ActionAdapterBase">

ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>exportInterval</td>

<td>int</td>

<td>&nbsp;</td>

<td>Defines the time interval, in seconds, between exporting frames of data. This parameter cannot be zero.</td>

</tr>

<tr>

<td>inputMeasurementKeys</td>

<td>string</td>

<td>&nbsp;</td>

<td>At least one input measurement must be specified for this adapter.</td>

</tr>

<tr>

<td>useReferenceAngle</td>

<td>bool</td>

<td>&nbsp;</td>

<td>Determines whether this adapter should use a reference angle when exporting phase angles.</td>

</tr>

<tr>

<td>referenceAngleMeasurement</td>

<td>MeasurementKey</td>

<td>&nbsp;</td>

<td>This parameter is not required when useReferenceAngle is set to false. The values of phase angles will be adjusted based on the value of the reference angle before being exported. The specified measurement key must belong to a phase angle measurement.</td>

</tr>

<tr>

<td><em>companyTagPrefix</em></td>

<td>string</td>

<td>null</td>

<td>Defines the company acronym used to prefix the measurements' tags. The prefix will be attached to the tag if it is not already present.</td>

</tr>

<tr>

<td><em>useNumericQuality</em></td>

<td>bool</td>

<td>false</td>

<td>Determines whether the system should export a textual representation or a numeric representation of the measurement quality.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">exportInterval=5; useReferenceAngle=True; referenceAngleMeasurement=DEVARCHIVE:6; companyTagPrefix=TVA; useNumericQuality=True; inputMeasurementKeys={FILTER ActiveMeasurements WHERE Device='SHELBY' AND SignalType='FREQ'}

</span><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of inputMeasurementKeys.</p>

<h2><a name="IEEEC37_118.Concentrator"></a>IEEEC37_118.Concentrator</h2>

<p>This adapter is used by the OutputStream table in the openPDC database. When defining an output stream in the OutputStream table, most parameters are set automatically by entering information into the columns of the table. Connection strings for this adapter

 also include all the parameters defined for <a href="#PhasorDataConcentratorBase">

PhasorDataConcentratorBase</a> and <a href="#ActionAdapterBase">ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>timeBase</em></td>

<td>uint</td>

<td>16777215</td>

<td>Defines the resolution of fractional time stamps in IEEE C37.118 configuration frames.</td>

</tr>

<tr>

<td><em>validateIDCode</em></td>

<td>bool</td>

<td>false</td>

<td>Defines flag that determines if the IEEE C37.118 concentrator will validate the ID code in command frames before processing.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">timeBase=16777215; validateIDCode=true </span>

</p>

<h2><a name="InputAdapterBase"></a>InputAdapterBase</h2>

<p>This class does not define any parameters of its own, however it does include all the parameters defined for

<a href="#AdapterBase">AdapterBase</a>.</p>

<h2><a name="MySqlAdapters.MySqlInputAdapter"></a>MySqlAdapters.MySqlInputAdapter</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#AdapterBase">AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>inputInterval</em></td>

<td>int</td>

<td>33</td>

<td>Indicates the amount of time, in milliseconds, that the adapter should pause between retrieving measurements from the database.</td>

</tr>

<tr>

<td><em>measurementsPerInput</em></td>

<td>int</td>

<td>5</td>

<td>Determines how many measurements the adapter should retrieve from the database at each input interval.</td>

</tr>

<tr>

<td><em>fakeTimestamps</em></td>

<td>bool</td>

<td>false</td>

<td>Indicates whether the adapter should apply fake timestamps to the measurements in order to simulate measurements coming in real time.</td>

</tr>

<tr>

<td><em>server</em></td>

<td>string</td>

<td>localhost</td>

<td>The hostname or IP address of the MySQL server. Multiple hosts can be specified separated by &amp;.</td>

</tr>

<tr>

<td><em>port</em></td>

<td>int</td>

<td>3306</td>

<td>The port on which the MySQL server is listening for connections.</td>

</tr>

<tr>

<td><em>protocol</em></td>

<td>string</td>

<td>socket</td>

<td>Specifies the type of connection to make to the server. Values can be: socket or tcp for a socket connection, pipe for a named pipe connection, unix for a Unix socket connection, memory to use MySQL shared memory.</td>

</tr>

<tr>

<td><em>database</em></td>

<td>string</td>

<td>mysql</td>

<td>The name of the database to use intially.</td>

</tr>

<tr>

<td><em>uid</em></td>

<td>string</td>

<td>&nbsp;</td>

<td>The MySQL login account being used.</td>

</tr>

<tr>

<td><em>pwd</em></td>

<td>string</td>

<td>&nbsp;</td>

<td>The password for the MySQL account being used.</td>

</tr>

<tr>

<td><em>encrypt</em></td>

<td>string</td>

<td>false</td>

<td>When true, SSL encryption is used for all data sent between the client and server if the server has a certificate installed. Recognized values are

<span class="codeInline">true</span>, <span class="codeInline">false</span>, <span class="codeInline">

yes</span>, and <span class="codeInline">no</span>.</td>

</tr>

<tr>

<td><em>charset</em></td>

<td>string</td>

<td>&nbsp;</td>

<td>Specifies the character set that should be used to encode all queries sent to the server. Resultsets are still returned in the character set of the data returned.</td>

</tr>

<tr>

<td><em>default command timeout</em></td>

<td>int</td>

<td>30</td>

<td>Sets the default value of the command timeout to be used.</td>

</tr>

<tr>

<td><em>connection timeout</em></td>

<td>int</td>

<td>15</td>

<td>The length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error.</td>

</tr>

<tr>

<td><em>shared memory name</em></td>

<td>string</td>

<td>MYSQL</td>

<td>The name of the shared memory object to use for communication if the connection protocol is set to memory.</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<h2><a name="MySqlAdapters.MySqlOutputAdapter"></a>MySqlAdapters.MySqlOutputAdapter</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#OutputAdapterBase">OutputAdapterBase</a> and <a href="#AdapterBase">

AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>server</em></td>

<td>string</td>

<td>localhost</td>

<td>The hostname or IP address of the MySQL server. Multiple hosts can be specified separated by &amp;.</td>

</tr>

<tr>

<td><em>port</em></td>

<td>int</td>

<td>3306</td>

<td>The port on which the MySQL server is listening for connections.</td>

</tr>

<tr>

<td><em>protocol</em></td>

<td>string</td>

<td>socket</td>

<td>Specifies the type of connection to make to the server. Values can be: socket or tcp for a socket connection, pipe for a named pipe connection, unix for a Unix socket connection, memory to use MySQL shared memory.</td>

</tr>

<tr>

<td><em>database</em></td>

<td>string</td>

<td>mysql</td>

<td>The name of the database to use intially.</td>

</tr>

<tr>

<td><em>uid</em></td>

<td>string</td>

<td>&nbsp;</td>

<td>The MySQL login account being used.</td>

</tr>

<tr>

<td><em>pwd</em></td>

<td>string</td>

<td>&nbsp;</td>

<td>The password for the MySQL account being used.</td>

</tr>

<tr>

<td><em>encrypt</em></td>

<td>string</td>

<td>false</td>

<td>When true, SSL encryption is used for all data sent between the client and server if the server has a certificate installed. Recognized values are

<span class="codeInline">true</span>, <span class="codeInline">false</span>, <span class="codeInline">

yes</span>, and <span class="codeInline">no</span>.</td>

</tr>

<tr>

<td><em>charset</em></td>

<td>string</td>

<td>&nbsp;</td>

<td>Specifies the character set that should be used to encode all queries sent to the server. Resultsets are still returned in the character set of the data returned.</td>

</tr>

<tr>

<td><em>default command timeout</em></td>

<td>int</td>

<td>30</td>

<td>Sets the default value of the command timeout to be used.</td>

</tr>

<tr>

<td><em>connection timeout</em></td>

<td>int</td>

<td>15</td>

<td>The length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error.</td>

</tr>

<tr>

<td><em>shared memory name</em></td>

<td>string</td>

<td>MYSQL</td>

<td>The name of the shared memory object to use for communication if the connection protocol is set to memory.</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<h2><a name="OutputAdapterBase"></a>OutputAdapterBase</h2>

<p>Connection strings for this class also include all the parameters defined for <a href="#AdapterBase">

AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>sourceids</em></td>

<td>string</td>

<td>null</td>

<td>A comma-separated list of sources that defines which measurements are to be processed by the output adapter. The source of a measurement is usually defined as the acronym of the historian which is archiving that measurement.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">sourceids=DEVARCHIVE,OTHERSOURCE </span></p>

<h2><a name="PhasorDataConcentratorBase"></a>PhasorDataConcentratorBase</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#ActionAdapterBase">ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>IDCode</td>

<td>ushort</td>

<td>&nbsp;</td>

<td>Defines an identification code for the concentrator.</td>

</tr>

<tr>

<td>dataChannel</td>

<td>string</td>

<td>null</td>

<td>Defines a connection string for a UDP data stream.</td>

</tr>

<tr>

<td>commandChannel</td>

<td>string</td>

<td>null</td>

<td>Defines a connection string for a TCP data stream that can be used to send commands to the concentrator.</td>

</tr>

<tr>

<td><em><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Auto_Publish_Config_Frame">autoPublishConfigFrame</a></em></td>

<td>bool</td>

<td>true if commandChannel is undefined; false otherwise</td>

<td>Indicates whether the concentrator should publish the configuration frame automatically or if it should wait for the command to be given on the command channel.</td>

</tr>

<tr>

<td><em><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Auto_Start_Data_Channel">autoStartDataChannel</a></em></td>

<td>bool</td>

<td>true</td>

<td>Indicates whether the data channel should be started automatically when the adapter is started or if it should wait to be explicitly started by the user.</td>

</tr>

<tr>

<td><em>nominalFrequency</em></td>

<td>int</td>

<td>60</td>

<td>Determines the line frequency to use when transmitting the concentrated measurements. Possible values are 50 and 60.</td>

</tr>

<tr>

<td><em>dataFormat</em></td>

<td>string</td>

<td>FloatingPoint</td>

<td>Defines the default data format of the concentrator if no other format is specified for the output device. Can be either FixedInteger or FloatingPoint.</td>

</tr>

<tr>

<td><em>coordinateFormat</em></td>

<td>string</td>

<td>Polar</td>

<td>Defines the default coordinate format of the concentrator if no other format is specified for the output device. Can be either Rectangular or Polar.</td>

</tr>

<tr>

<td><em>currentScalingValue</em></td>

<td>uint</td>

<td>2423</td>

<td>Defines the default current value scaling factor to apply if the <em>dataFormat</em> is set to FixedInteger and no other scaling value is specified for the output device.</td>

</tr>

<tr>

<td><em>voltageScalingValue</em></td>

<td>uint</td>

<td>2725785</td>

<td>Defines the default voltage value scaling factor to apply if the <em>dataFormat</em> is set to FixedInteger and no other scaling value is specified for the output device.</td>

</tr>

<tr>

<td><em>analogScalingValue</em></td>

<td>uint</td>

<td>1373291</td>

<td>Defines the default analog value scaling factor to apply if the <em>dataFormat</em> is set to FixedInteger and no other scaling value is specified for the output device.</td>

</tr>

<tr>

<td><em>digitalMaskValue</em></td>

<td>uint</td>

<td>0xFFFF0000</td>

<td>Defines the default digital mask value made available in configuration frames for use with digital values published by the concentrator if no other mask value is specified for the output device. In IEEE C37.118 configuration frames this value represents

 two mask words for use with digital status values where the low word represents the the normal status of the digital inputs and the high word represents the valid inputs.</td>

</tr>

<tr>

<td><em>processDataValidFlag</em></td>

<td>bool</td>

<td>true</td>

<td>Defines flag that determines if the data valid flag assignments should be processed during frame publication. In cases where client applications ignore the data validity flag, setting this flag to false will provide a slight processing optimization, especially

 useful on very large data streams.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

At least one of either dataChannel or commandChannel must be specified. If dataChannel is not specified, the command channel will be used to transmit data from the concentrator and issue commands to the concentrator. Otherwise, the data channel is used to broadcast

 and the command channel, if specified, is used to issue commands. The data channel and command channel each have their own connection string parameters. Check the example to see how to enter them.<br>

<br>

<strong>dataChannel</strong></p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>port</td>

<td>int</td>

<td>&nbsp;</td>

<td>Defines the local port for the data channel. A value of -1 tells it not to use a local port. A value of 0 tells it to use any port.</td>

</tr>

<tr>

<td>clients</td>

<td>string</td>

<td>&nbsp;</td>

<td>Defines a comma-separated list of machines to which the data is sent.</td>

</tr>

<tr>

<td><em>interface</em></td>

<td>string</td>

<td>empty string</td>

<td>Defines the local interface through which the UDP connection is made.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

<strong>commandChannel</strong></p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>port</td>

<td>int</td>

<td>&nbsp;</td>

<td>Defines the local port on which the concentrator is listening for commands.</td>

</tr>

<tr>

<td><em>interface</em></td>

<td>string</td>

<td>empty string</td>

<td>Defines the local interface through which the TCP connection is made.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">IDCode=235; dataChannel={port=-1; clients=localhost:8800; interface=0.0.0.0}; commandChannel={port=8900; interface=0.0.0.0}; autoPublishConfigFrame=false; autoStartDataChannel=true; nominalFrequency=60; dataFormat=FloatingPoint;

 coordinateFormat=Polar </span></p>

<h2><a name="PhasorMeasurementMapper"></a>PhasorMeasurementMapper</h2>

<p>PhasorMeasurementMapper is used by the Device table in the openPDC database. When defining a device in the Device table, most parameters are set automatically by entering information into the columns of the device table. Connection strings for this adapter

 also include all the parameters defined for <a href="#AdapterBase">AdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>isConcentrator</em></td>

<td>bool</td>

<td>false</td>

<td>Indicates whether or not the device represented by this PhasorMeasurementMapper is a concentrator.</td>

</tr>

<tr>

<td><em>accessID</em></td>

<td>ushort</td>

<td>1</td>

<td>The Access ID or Device ID of the device represented by this PhasorMeasurementMapper.</td>

</tr>

<tr>

<td><em>forceLabelMapping</em></td>

<td>bool</td>

<td>false</td>

<td>Forces the preferred use of the device label over the device ID code when mapping devices from a data frame to the local configuration. Enabling this option is less optimal than using a numeric ID code for mapping, but is useful when local configuration

 ID code does not match that of device configuration. Label lookups are case-insensitive.</td>

</tr>

<tr>

<td><em>primaryDataSource</em></td>

<td>string</td>

<td>null</td>

<td>Specifies the acronym of a device using the Gateway Exchange Protocol (GEP) that will be used as the primary data source for this device. When defined, this connection will only activate as a backup connection when the primary GEP connection goes offline

 - when GEP connection comes back online, this device connection will disconnect. For example, this could be used as a direct backup connection to a substation PMU whose primary data feed is provided through a GEP style connection to a substation PDC connected

 to the PMU - this connection would only be enabled when the PDC's GEP connection was offline.</td>

</tr>

<tr>

<td><em>sharedMapping</em></td>

<td>string</td>

<td>null</td>

<td>Specifies the acronym of another device which will be used as the configuration source for this device. When defined, this device is assumed to be a redundant connection to a source device (e.g., PDC or PMU). Enabling the shared mapping allows a device

 to be defined with only connection information and no direct configuration; the device &quot;assumes&quot; the configuration of the specified device acronym. In this way the primary device configuration can be maintained once and other multiple redundant connections,

 as many as needed, can be defined associated with same single configuration. Redundant data will pass through the system and be handled via concentrator

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Help_Me_Choose_Diagrams.md#Downsampling_Method">

downsampling method</a>.</td>

</tr>

<tr>

<td><em>phasorProtocol</em></td>

<td>PhasorProtocol</td>

<td>IeeeC37_118V1</td>

<td>Defines the phasor protocol used by the device. The value can be one of IeeeC37_118V1, IeeeC37_118D6, Ieee1344, BpaPdcStream, FNet, SelFastMessage, or Macrodyne.</td>

</tr>

<tr>

<td><em>transportProtocol</em></td>

<td>TransportProtocol</td>

<td>Tcp</td>

<td>Defines the protocol used by the device to send its data. The value can be one of Tcp, Udp, Serial, or File.</td>

</tr>

<tr>

<td><em>commandChannel</em></td>

<td>string</td>

<td>not defined</td>

<td>If defined, the value of this parameter is the connection string of the command channel.</td>

</tr>

<tr>

<td><em>timeZone</em></td>

<td>string</td>

<td>UTC</td>

<td>ID of the time zone for time as reported by device used to offset time back to UTC. See

<a href="#time_zone_ids">typical time zones</a> for possible IDs.</td>

</tr>

<tr>

<td><em>timeAdjustmentTicks</em></td>

<td>long</td>

<td>0</td>

<td>Allows for manual high-resolution &#43;/- adjustment of the frame timestamps, in ticks, if necessary. One tick = 100 nanoseconds, one millisecond = 10000 ticks.</td>

</tr>

<tr>

<td><em>autoStartDataParsingSequence</em></td>

<td>bool</td>

<td>true</td>

<td>Defines flag to automatically send the ConfigFrame2 and EnableRealTimeData command frames used to start a typical data parsing sequence.</td>

</tr>

<tr>

<td><em>skipDisableRealTimeData</em></td>

<td>bool</td>

<td>false</td>

<td>Defines flag to skip automatic disabling of the real-time data stream on shutdown or startup. Useful when using UDP multicast with several subscribed clients.</td>

</tr>

<tr>

<td><em>executeParseOnSeparateThread</em></td>

<td>bool</td>

<td>false</td>

<td>Defines flag that allows frame parsing to be executed on a separate thread (i.e., other than communications thread). Rarely used unless data frames are very large.</td>

</tr>

<tr>

<td><em>simulateTimestamp</em></td>

<td>bool</td>

<td>true if transportProtocol = File; false otherwise</td>

<td>Defines flag indicating whether or not to inject local system time (UTC) into parsed data frames.</td>

</tr>

<tr>

<td><em>configurationFile</em></td>

<td>string</td>

<td>null</td>

<td>If defined, loads serialized configuration from specified filename before connection is established - useful when receiving UDP only data without the ability to receive a config frame.</td>

</tr>

<tr>

<td><em>dataLossInterval</em></td>

<td>double</td>

<td>5.0</td>

<td>Defines the amount of time, in seconds, that the PhasorMeasurementMapper should wait before reconnecting to a device which has stopped sending data.</td>

</tr>

<tr>

<td><em>allowUseOfCachedConfiguration</em></td>

<td>bool</td>

<td>true</td>

<td>Defines flag that determines if use of cached configuration during initial connection is allowed when a configuration has not been received within the &quot;<em>dataLossInterval</em>&quot;.</td>

</tr>

<tr>

<td><em>allowedParsingExceptions</em></td>

<td>int</td>

<td>10</td>

<td>Defines the number of parsing exceptions allowed during &quot;<em>parsingExceptionWindow</em>&quot; before connection is reset.</td>

</tr>

<tr>

<td><em>parsingExceptionWindow</em></td>

<td>double</td>

<td>5.0</td>

<td>Defines time duration, in seconds, to monitor parsing exceptions.</td>

</tr>

<tr>

<td><em>delayedConnectionInterval</em></td>

<td>double</td>

<td>1.5</td>

<td>Defines the delay, in seconds, before connecting or reconnecting to a device. Set to zero for minimum delay (1 millisecond). One to two second delay recommended for new device turn-up.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

<strong>commandChannel connection string parameters</strong> (also includes <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.md#configure_connection_string">

transport protocol specific parameters</a>)</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>protocol</td>

<td>TransportProtocol</td>

<td>&nbsp;</td>

<td>Defines the protocol used by the device to receive commands. The value can be one of Tcp, Serial, or File.</td>

</tr>

<tr>

<td><em>islistener</em></td>

<td>bool</td>

<td>false</td>

<td>Indicates whether to use a TCP server or a TCP client for the command channel.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">isConcentrator=false; accessID=235; timeZone=UTC; timeAdjustmentTicks=10000000; dataLossInterval=20.0; phasorProtocol=Ieee1344; transportProtocol=Udp; commandChannel={protocol=Tcp; islistener=true}

</span></p>

<h4>Additional parameters for PhasorMeasurementMapper</h4>

<p><br>

<strong>if phasorProtocol=BpaPdcStream</strong></p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>iniFileName</td>

<td>string</td>

<td>&nbsp;</td>

<td>The value of this parameter is the path to the INI file which contains settings for the device.</td>

</tr>

<tr>

<td><em>refreshConfigFileOnChange</em></td>

<td>bool</td>

<td>true</td>

<td>Determines whether the INI configuration file is automatically reloaded when it has changed on disk.</td>

</tr>

<tr>

<td><em>parseWordCountFromByte</em></td>

<td>bool</td>

<td>false</td>

<td>Determines whether to interpret the the word count in the packet header from a byte instead of a word.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">phasorProtocol=BpaPdcStream; iniFileName=TESTSTREAM.ini; refreshConfigFileOnChange=true; parseWordCountFromByte=true

</span><br>

<br>

<strong>if phasorProtocol=FNet</strong></p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>timeOffset</em></td>

<td>long</td>

<td>110000000</td>

<td>F-NET devices normally report time in 11 seconds past real-time, this property defines the offset for this this artificial delay. Note that the parameter value is in ticks to allow a very high-resolution offset; 1 second = 10,000,000 ticks.</td>

</tr>

<tr>

<td><em>stationName</em></td>

<td>string</td>

<td>F-Net Unit</td>

<td>Defines the station name for the F-Net device.</td>

</tr>

<tr>

<td><em>frameRate</em></td>

<td>ushort</td>

<td>10</td>

<td>The configured frame rate for the F-Net device.</td>

</tr>

<tr>

<td><em>nominalFrequency</em></td>

<td>int</td>

<td>60</td>

<td>The nominal line frequency of the F-Net device. The value can be either 50 or 60.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">phasorProtocol=FNet; timeOffset=50000000; stationName=Poppy; frameRate=15; nominalFrequency=60

</span><br>

<br>

<strong>if phasorProtocol=SelFastMessage</strong></p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>messagePeriod</em></td>

<td>MessagePeriod</td>

<td>DefaultRate</td>

<td>The value can be one of DefaultRate (20 messages per second), TwentyPerSecond, TenPerSecond, FivePerSecond, FourPerSecond, TwoPerSecond, OnePerSecond, ThirtyPerMinute, FifteenPerMinute, TwelvePerMinute, TenPerMinute, SixPerMinute, FourPerMinute, ThreePerMinute,

 TwoPerMinute, or OnePerMinute.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">phasorProtocol=SelFastMessage; messagePeriod=TwoPerSecond

</span><br>

<br>

<strong>if transportProtocol=File</strong></p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td><em>definedFrameRate</em></td>

<td>double</td>

<td>30.0</td>

<td>Defines the desired frame rate to use for maintaining captured frame replay timing.</td>

</tr>

<tr>

<td><em>useHighResolutionInputTimer</em></td>

<td>bool</td>

<td>true</td>

<td>Defines flag that determines if a high-resolution precision timer should be used for file based input. Useful when input frames need be accurately time-aligned to the local clock to better simulate an input device and calculate downstream latencies.</td>

</tr>

<tr>

<td><em>autoRepeatFile</em></td>

<td>bool</td>

<td>true</td>

<td>Defines flag that determines if a file used for replaying data should be restarted at the beginning once it has been completed.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">transportProtocol=File; file=Sample1344.PmuCapture; definedFrameRate=60; simulateTimestamp=false; autoRepeatFile=false

</span></p>

<h2><a name="PowerCalculations.AverageFrequency"></a>PowerCalculations.AverageFrequency</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#CalculatedMeasurement">CalculatedMeasurement</a> and <a href="#ActionAdapterBase">

ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>inputMeasurementKeys</td>

<td>string</td>

<td>&nbsp;</td>

<td>All non-frequency measurements will be ignored by this adapter. At least one frequency must be defined in the inputMeasurementKeys parameter.</td>

</tr>

<tr>

<td>outputMeasurements</td>

<td>string</td>

<td>&nbsp;</td>

<td>At least three measurements must be defined by this parameter. The first three output measurements represent the average, maximum, and minimum of the input frequencies respectively. Additional output measurements will be ignored.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'FREQ'}; outputMeasurements={AVERAGE:1; AVERAGE:2; AVERAGE:3}

</span><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of these parameters.</p>

<h2><a name="PowerCalculations.EventDetection.FrequencyExcursion"></a>PowerCalculations.EventDetection.FrequencyExcursion</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#CalculatedMeasurement">CalculatedMeasurement</a> and <a href="#ActionAdapterBase">

ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>inputMeasurementKeys</td>

<td>string</td>

<td>&nbsp;</td>

<td>All non-frequency measurements will be ignored by this adapter. At least one frequency must be defined in the inputMeasurementKeys parameter. Additionally, there must be at least as many input frequencies defined as the value defined for minimumValidChannels.</td>

</tr>

<tr>

<td>outputMeasurements</td>

<td>string</td>

<td>&nbsp;</td>

<td>At least four measurements must be defined by this parameter. The first four output measurements represent the Warning Signal Status, Frequency Delta, Type of Excursion, and Estimated Size respectively. Additional output measurements will be ignored.</td>

</tr>

<tr>

<td><em>estimateTriggerThreshold</em></td>

<td>double</td>

<td>.0256</td>

<td>Defines the threshold of the estimation trigger.</td>

</tr>

<tr>

<td><em>analysisWindowSize</em></td>

<td>int</td>

<td>4 * framesPerSecond</td>

<td>Defines the sample size of the analysis window.</td>

</tr>

<tr>

<td><em>analysisInterval</em></td>

<td>int</td>

<td>framesPerSecond</td>

<td>Defines the frame interval between two adjacent frequency tests.</td>

</tr>

<tr>

<td><em>consecutiveDetections</em></td>

<td>int</td>

<td>2</td>

<td>Defines the number of consecutive excursions to be detected before triggering the alarm.</td>

</tr>

<tr>

<td><em>minimumValidChannels</em></td>

<td>int</td>

<td>3</td>

<td>Defines the minimum number of valid channels for conducting the frequency tests.</td>

</tr>

<tr>

<td><em>powerEstimateRatio</em></td>

<td>double</td>

<td>19530.0</td>

<td>Defines the ratio of the total amount of generator (load) trip over the frequency excursion.</td>

</tr>

<tr>

<td><em>minimumAlarmInterval</em></td>

<td>int</td>

<td>20</td>

<td>Defines the minimum duration between alarms in seconds.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'FREQ'}; outputMeasurements={EXCURSION:1; EXCURSION:2; EXCURSION:3; EXCURSION:4}; estimateTriggerThreshold=.0256; analysisWindowSize=150; analysisInterval=15;

 consecutiveDetections=3; minimumValidChannels=5; powerEstimateRatio=19530.0; minimumAlarmInterval=10

</span><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of these parameters.</p>

<h2><a name="PowerCalculations.EventDetection.LossOfField"></a>PowerCalculations.EventDetection.LossOfField</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#CalculatedMeasurement">CalculatedMeasurement</a> and <a href="#ActionAdapterBase">

ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>inputMeasurementKeys</td>

<td>string</td>

<td>&nbsp;</td>

<td>All non-phasor measurements will be ignored by this adapter. At least one each of voltage magnitude, voltage angle, current magnitude, and current angle must be specified as input measurements to this adapter. If more than one of any of these is specified,

 only the first one will be used.</td>

</tr>

<tr>

<td>outputMeasurements</td>

<td>string</td>

<td>&nbsp;</td>

<td>At least four measurements must be defined by this parameter. The first four output measurements represent the Warning Signal Status, Real Power, Reactive Power, and Q-Area Value respectively. Additional output measurements will be ignored.</td>

</tr>

<tr>

<td><em>pSet</em></td>

<td>double</td>

<td>-600</td>

<td>This is the pre-set value for MW power-flow from bus A to bus B. Usually the absolute value of pSet is smaller than the absolute value of power-flow in normal condition.</td>

</tr>

<tr>

<td><em>qSet</em></td>

<td>double</td>

<td>200</td>

<td>This is the pre-set value for MVar flow from bus A to bus B. Usually the absolute value of qSet is larger than the absolute value of Mvar flow in normal condition.</td>

</tr>

<tr>

<td><em>qAreaSet</em></td>

<td>double</td>

<td>500</td>

<td>This the pre-set threshold for qArea. qArea is the accumulation of excessive Mvar flow if abs(P) &lt;abs(pSet) and abs(Q) &gt;abs(qSet). (P is the current MW power-flow and Q is the current Mvar flow)</td>

</tr>

<tr>

<td><em>voltageThreshold</em></td>

<td>double</td>

<td>475000</td>

<td>This is the pre-set voltage threshold for the bus, on which the loss-of-field is monitored.</td>

</tr>

<tr>

<td><em>analysisInterval</em></td>

<td>int</td>

<td>framesPerSecond</td>

<td>Defines the frame interval between two adjacent phasor tests.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">inputMeasurementKeys={DEVARCHIVE:5; DEVARCHIVE:6; DEVARCHIVE:9; DEVARCHIVE:10}; outputMeasurements={LOF:1; LOF:2; LOF:3; LOF:4}; pSet=-500; qSet=300; qAreaSet=600; voltageThreshold=475000; analysisInterval=15

</span><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of these parameters.</p>

<h2><a name="PowerCalculations.PowerStability"></a>PowerCalculations.PowerStability</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#CalculatedMeasurement">CalculatedMeasurement</a> and <a href="#ActionAdapterBase">

ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>inputMeasurementKeys</td>

<td>string</td>

<td>&nbsp;</td>

<td>All non-phasor measurements will be ignored by this adapter. At least one each of voltage magnitude, voltage angle, current magnitude, and current angle must be specified as input measurements to this adapter. Additionally, the number of voltage angles

 must match the number of voltage magnitudes and the number of current magnitudes must match the number of current angles. The definition order of angles and magnitudes must match so that the angle/magnitude pairs can be matched up appropriately.</td>

</tr>

<tr>

<td>outputMeasurements</td>

<td>string</td>

<td>&nbsp;</td>

<td>At least two measurements must be defined by this parameter. The first two output measurements represent the Calculated Power and the Standard Deviation of Power respectively. Additional output measurements will be ignored.</td>

</tr>

<tr>

<td><em>sampleSize</em></td>

<td>int</td>

<td>15</td>

<td>Defines the data sample size to monitor in seconds.</td>

</tr>

<tr>

<td><em>energizedThreshold</em></td>

<td>double</td>

<td>58000.0</td>

<td>Defines the energized bus threshold in volts. The recommended value is 20% of the nominal line-to-neutral voltage.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">inputMeasurementKeys={DEVARCHIVE:6; DEVARCHIVE:5; DEVARCHIVE:8; DEVARCHIVE:7; DEVARCHIVE:10; DEVARCHIVE:9; DEVARCHIVE:12; DEVARCHIVE:11; DEVARCHIVE:14; DEVARCHIVE:13}; outputMeasurements={POWER:1; POWER:2}; sampleSize=20;

 energizedThreshold=58000.0 </span><br>

<br>

<em>Note: Ordering by PhasorID allows angle and magnitude measurements to be sorted together so they can be identified as a pair.</em><br>

<br>

Example2: <span class="codeInline">inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType LIKE '*PH*' AND Device = 'SHELBY' ORDER BY PhasorID}; outputMeasurements={POWER:1; POWER:2}; sampleSize=20; energizedThreshold=58000.0

</span><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of these parameters.</p>

<h2><a name="PowerCalculations.ReferenceAngle"></a>PowerCalculations.ReferenceAngle</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#CalculatedMeasurement">CalculatedMeasurement</a> and <a href="#ActionAdapterBase">

ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>inputMeasurementKeys</td>

<td>string</td>

<td>&nbsp;</td>

<td>All non-phase angle measurements will be ignored by this adapter. At least one phase angle must be specified as an input measurement to this adapter. Additionally, phase types must not be mixed; only voltage angles or only current angles should be specified.</td>

</tr>

<tr>

<td>outputMeasurements</td>

<td>string</td>

<td>&nbsp;</td>

<td>At least one measurement must be defined by this parameter. The first measurement represents the Calculated Reference Angle value. Additional output measurements will be ignored.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'IPHA'}; outputMeasurements={REF_IPHA:1}

</span><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of these parameters.</p>

<h2><a name="PowerCalculations.ReferenceMagnitude"></a>PowerCalculations.ReferenceMagnitude</h2>

<p>Connection strings for this adapter also include all the parameters defined for

<a href="#CalculatedMeasurement">CalculatedMeasurement</a> and <a href="#ActionAdapterBase">

ActionAdapterBase</a>.<br>

<br>

</p>

<table>

<tbody>

<tr>

<th>Key </th>

<th>Value </th>

<th>Default </th>

<th>Description </th>

</tr>

<tr>

<td>inputMeasurementKeys</td>

<td>string</td>

<td>&nbsp;</td>

<td>All non-phase magnitude measurements will be ignored by this adapter. At least one phase magnitude must be specified as an input measurement to this adapter. Additionally, phase types must not be mixed; only voltage magnitudes or only voltage angles should

 be specified.</td>

</tr>

<tr>

<td>outputMeasurements</td>

<td>string</td>

<td>&nbsp;</td>

<td>At least one measurement must be defined by this parameter. The first measurement represents the Calculated Reference Magnitude value. Additional output measurements will be ignored.</td>

</tr>

</tbody>

</table>

<p><br>

<br>

Example: <span class="codeInline">inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType = 'IPHM'}; outputMeasurements={REF_IPHM:1}

</span><br>

<br>

See <a href="#input_and_output_syntax">Syntax for inputMeasurementKeys and outputMeasurements</a> for help with the syntax of these parameters.</p>

<h2><a name="input_and_output_syntax"></a>Syntax for inputMeasurementKeys and outputMeasurements</h2>

<p>The syntax for inputMeasurementKeys and outputMeasurements is either:</p>

<ul>

<li><em>Filter syntax</em>: <span class="codeInline">FILTER &lt;TableName&gt; WHERE &lt;Expression&gt; [ORDER BY &lt;SortField&gt;]

</span><em>-or-</em> </li><li><em>Field syntax</em>: <span class="codeInline">&lt;Source&gt;:&lt;ID&gt;[,&lt;Adder&gt;,&lt;Multiplier&gt;];

</span></li></ul>

<p><br>

The syntax for both the input and output parameters is identical except that outputMeasurements allows the defintion of an adder and a multiplier using the field syntax whereas inputMeasurementKeys does not. In the following examples, the acronym of the historian

 archiving the measurements is called DEVARCHIVE.</p>

<ol>

<li><span class="codeInline">inputMeasurementKeys={DEVARCHIVE:1;DEVARCHIVE:2;DEVARCHIVE:5;DEVARCHIVE:12}

</span></li><li><span class="codeInline">outputMeasurements={SOURCENAME:6,5,9;SOURCENAME:18,59.5,0.1;SOURCENAME:20}

</span></li><li><span class="codeInline">inputMeasurementKeys={FILTER ActiveMeasurements WHERE Device = 'SHELBY' AND SignalType = 'VPHM'}

</span></li><li><span class="codeInline">inputMeasurementKeys={FILTER ActiveMeasurements WHERE SignalType LIKE '*PH*' AND Device = 'SHELBY' ORDER BY PhasorID}

</span></li></ol>

<p><br>

In example 1, we define four input measurements corresponding to the measurement keys DEVARCHIVE:1, DEVARCHIVE:2, DEVARCHIVE:5, and DEVARCHIVE:12. The IsInputMeasurement(MeasurementKey) method will only return true if the MeasurementKey argument matches one

 of those four keys. Had we used outputMeasurements instead of inputMeasurementKeys, it would have created four measurements with the default adder and multiplier, 0 and 1 respectively.<br>

<br>

Example 2 syntax only applies to the outputMeasurements parameter and defines the adder and multiplier of the measurements in addition to the measurement key. In this example, we define three output measurements with the following keys: SOURCENAME:6, SOURCENAME:18,

 and SOURCENAME:20. The adder for each is 5, 59.5, and 0 respectively. The multiplier for each is 9, 0.1, and 1 respectively.<br>

<br>

In example 3, we use a statement with SQL-like syntax in order to determine which measurements are defined as the input measurements. The ConfigurationEntity table defines the table names you can use in place of &quot;ActiveMeasurements&quot;.

<span class="codeInline">ConfigurationEntity.SourceName </span>defines the name of the table or view in the database and

<span class="codeInline">ConfigurationEntity.RuntimeName </span>defines the name used in place of &quot;ActiveMeasurements&quot;. When using the inputMeasurementKeys parameter, the system uses only the &quot;ID&quot; column of the given table or view in order

 to determine the MeasurementKey of each of the input measurements. When using the outputMeasurements parameter, the system uses the &quot;ID&quot;, &quot;PointTag&quot;, &quot;Adder&quot;, and &quot;Multiplier&quot; columns to create the output measurements.<br>

<br>

In example 4, we apply a &quot;LIKE&quot; expression to get any signal type that has &quot;PH&quot; as the middle two letters (i.e., IPHM, VPHM, IPHA or VPHA -or- current phasor magnitude, voltage phasor magnitude, current phasor angle or voltage phasor angle

 respectively). Additonally we apply an &quot;ORDER BY&quot; expression so that the selected results are ordered by their unique phasor ID, by doing this all magnitude and phase angles associated with the same phasor will be sorted side-by-side allowing the

 consumer to automatically know which angle and magnitude vector component pairs go together simply by their ordered grouping.<br>

<br>

Click <a href="http://www.csharp-examples.net/dataview-rowfilter/">here</a> for more help on proper and allowed syntax for expressions.</p>

<h2><a name="time_zone_ids"></a>Typical Time Zones</h2>

<table>

<tbody>

<tr>

<th>ID </th>

<th>Display Name </th>

</tr>

<tr>

<td>UTC</td>

<td>Universal Coordinated Time (GMT without daylight savings adjustments)</td>

</tr>

<tr>

<td>GMT Standard Time</td>

<td>(GMT) Greenwich Mean Time : Dublin, Edinburgh, Lisbon, London</td>

</tr>

<tr>

<td>Greenwich Standard Time</td>

<td>(GMT) Casablanca, Monrovia, Reykjavik</td>

</tr>

<tr>

<td>W. Europe Standard Time</td>

<td>(GMT&#43;01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna</td>

</tr>

<tr>

<td>Central Europe Standard Time</td>

<td>(GMT&#43;01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague</td>

</tr>

<tr>

<td>Romance Standard Time</td>

<td>(GMT&#43;01:00) Brussels, Copenhagen, Madrid, Paris</td>

</tr>

<tr>

<td>Central European Standard Time</td>

<td>(GMT&#43;01:00) Sarajevo, Skopje, Warsaw, Zagreb</td>

</tr>

<tr>

<td>W. Central Africa Standard Time</td>

<td>(GMT&#43;01:00) West Central Africa</td>

</tr>

<tr>

<td>Jordan Standard Time</td>

<td>(GMT&#43;02:00) Amman</td>

</tr>

<tr>

<td>GTB Standard Time</td>

<td>(GMT&#43;02:00) Athens, Bucharest, Istanbul</td>

</tr>

<tr>

<td>Middle East Standard Time</td>

<td>(GMT&#43;02:00) Beirut</td>

</tr>

<tr>

<td>Egypt Standard Time</td>

<td>(GMT&#43;02:00) Cairo</td>

</tr>

<tr>

<td>South Africa Standard Time</td>

<td>(GMT&#43;02:00) Harare, Pretoria</td>

</tr>

<tr>

<td>FLE Standard Time</td>

<td>(GMT&#43;02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius</td>

</tr>

<tr>

<td>Israel Standard Time</td>

<td>(GMT&#43;02:00) Jerusalem</td>

</tr>

<tr>

<td>E. Europe Standard Time</td>

<td>(GMT&#43;02:00) Minsk</td>

</tr>

<tr>

<td>Namibia Standard Time</td>

<td>(GMT&#43;02:00) Windhoek</td>

</tr>

<tr>

<td>Arabic Standard Time</td>

<td>(GMT&#43;03:00) Baghdad</td>

</tr>

<tr>

<td>Arab Standard Time</td>

<td>(GMT&#43;03:00) Kuwait, Riyadh</td>

</tr>

<tr>

<td>Russian Standard Time</td>

<td>(GMT&#43;03:00) Moscow, St. Petersburg, Volgograd</td>

</tr>

<tr>

<td>E. Africa Standard Time</td>

<td>(GMT&#43;03:00) Nairobi</td>

</tr>

<tr>

<td>Georgian Standard Time</td>

<td>(GMT&#43;03:00) Tbilisi</td>

</tr>

<tr>

<td>Iran Standard Time</td>

<td>(GMT&#43;03:30) Tehran</td>

</tr>

<tr>

<td>Arabian Standard Time</td>

<td>(GMT&#43;04:00) Abu Dhabi, Muscat</td>

</tr>

<tr>

<td>Azerbaijan Standard Time</td>

<td>(GMT&#43;04:00) Baku</td>

</tr>

<tr>

<td>Caucasus Standard Time</td>

<td>(GMT&#43;04:00) Caucasus Standard Time</td>

</tr>

<tr>

<td>Armenian Standard Time</td>

<td>(GMT&#43;04:00) Yerevan</td>

</tr>

<tr>

<td>Afghanistan Standard Time</td>

<td>(GMT&#43;04:30) Kabul</td>

</tr>

<tr>

<td>Ekaterinburg Standard Time</td>

<td>(GMT&#43;05:00) Ekaterinburg</td>

</tr>

<tr>

<td>West Asia Standard Time</td>

<td>(GMT&#43;05:00) Islamabad, Karachi, Tashkent</td>

</tr>

<tr>

<td>India Standard Time</td>

<td>(GMT&#43;05:30) Chennai, Kolkata, Mumbai, New Delhi</td>

</tr>

<tr>

<td>Sri Lanka Standard Time</td>

<td>(GMT&#43;05:30) Sri Jayawardenepura</td>

</tr>

<tr>

<td>Nepal Standard Time</td>

<td>(GMT&#43;05:45) Kathmandu</td>

</tr>

<tr>

<td>N. Central Asia Standard Time</td>

<td>(GMT&#43;06:00) Almaty, Novosibirsk</td>

</tr>

<tr>

<td>Central Asia Standard Time</td>

<td>(GMT&#43;06:00) Astana, Dhaka</td>

</tr>

<tr>

<td>Myanmar Standard Time</td>

<td>(GMT&#43;06:30) Yangon (Rangoon)</td>

</tr>

<tr>

<td>SE Asia Standard Time</td>

<td>(GMT&#43;07:00) Bangkok, Hanoi, Jakarta</td>

</tr>

<tr>

<td>North Asia Standard Time</td>

<td>(GMT&#43;07:00) Krasnoyarsk</td>

</tr>

<tr>

<td>China Standard Time</td>

<td>(GMT&#43;08:00) Beijing, Chongqing, Hong Kong, Urumqi</td>

</tr>

<tr>

<td>North Asia East Standard Time</td>

<td>(GMT&#43;08:00) Irkutsk, Ulaan Bataar</td>

</tr>

<tr>

<td>Singapore Standard Time</td>

<td>(GMT&#43;08:00) Kuala Lumpur, Singapore</td>

</tr>

<tr>

<td>W. Australia Standard Time</td>

<td>(GMT&#43;08:00) Perth</td>

</tr>

<tr>

<td>Taipei Standard Time</td>

<td>(GMT&#43;08:00) Taipei</td>

</tr>

<tr>

<td>Tokyo Standard Time</td>

<td>(GMT&#43;09:00) Osaka, Sapporo, Tokyo</td>

</tr>

<tr>

<td>Korea Standard Time</td>

<td>(GMT&#43;09:00) Seoul</td>

</tr>

<tr>

<td>Yakutsk Standard Time</td>

<td>(GMT&#43;09:00) Yakutsk</td>

</tr>

<tr>

<td>Cen. Australia Standard Time</td>

<td>(GMT&#43;09:30) Adelaide</td>

</tr>

<tr>

<td>AUS Central Standard Time</td>

<td>(GMT&#43;09:30) Darwin</td>

</tr>

<tr>

<td>E. Australia Standard Time</td>

<td>(GMT&#43;10:00) Brisbane</td>

</tr>

<tr>

<td>AUS Eastern Standard Time</td>

<td>(GMT&#43;10:00) Canberra, Melbourne, Sydney</td>

</tr>

<tr>

<td>West Pacific Standard Time</td>

<td>(GMT&#43;10:00) Guam, Port Moresby</td>

</tr>

<tr>

<td>Tasmania Standard Time</td>

<td>(GMT&#43;10:00) Hobart</td>

</tr>

<tr>

<td>Vladivostok Standard Time</td>

<td>(GMT&#43;10:00) Vladivostok</td>

</tr>

<tr>

<td>Central Pacific Standard Time</td>

<td>(GMT&#43;11:00) Magadan, Solomon Is., New Caledonia</td>

</tr>

<tr>

<td>New Zealand Standard Time</td>

<td>(GMT&#43;12:00) Auckland, Wellington</td>

</tr>

<tr>

<td>Fiji Standard Time</td>

<td>(GMT&#43;12:00) Fiji, Kamchatka, Marshall Is.</td>

</tr>

<tr>

<td>Tonga Standard Time</td>

<td>(GMT&#43;13:00) Nuku'alofa</td>

</tr>

<tr>

<td>Azores Standard Time</td>

<td>(GMT-01:00) Azores</td>

</tr>

<tr>

<td>Cape Verde Standard Time</td>

<td>(GMT-01:00) Cape Verde Is.</td>

</tr>

<tr>

<td>Mid-Atlantic Standard Time</td>

<td>(GMT-02:00) Mid-Atlantic</td>

</tr>

<tr>

<td>E. South America Standard Time</td>

<td>(GMT-03:00) Brasilia</td>

</tr>

<tr>

<td>SA Eastern Standard Time</td>

<td>(GMT-03:00) Buenos Aires, Georgetown</td>

</tr>

<tr>

<td>Greenland Standard Time</td>

<td>(GMT-03:00) Greenland</td>

</tr>

<tr>

<td>Montevideo Standard Time</td>

<td>(GMT-03:00) Montevideo</td>

</tr>

<tr>

<td>Newfoundland Standard Time</td>

<td>(GMT-03:30) Newfoundland</td>

</tr>

<tr>

<td>Atlantic Standard Time</td>

<td>(GMT-04:00) Atlantic Time (Canada)</td>

</tr>

<tr>

<td>SA Western Standard Time</td>

<td>(GMT-04:00) La Paz</td>

</tr>

<tr>

<td>Central Brazilian Standard Time</td>

<td>(GMT-04:00) Manaus</td>

</tr>

<tr>

<td>Pacific SA Standard Time</td>

<td>(GMT-04:00) Santiago</td>

</tr>

<tr>

<td>Venezuela Standard Time</td>

<td>(GMT-04:30) Caracas</td>

</tr>

<tr>

<td>SA Pacific Standard Time</td>

<td>(GMT-05:00) Bogota, Lima, Quito, Rio Branco</td>

</tr>

<tr>

<td>Eastern Standard Time</td>

<td>(GMT-05:00) Eastern Time (US &amp; Canada)</td>

</tr>

<tr>

<td>US Eastern Standard Time</td>

<td>(GMT-05:00) Indiana (East)</td>

</tr>

<tr>

<td>Central America Standard Time</td>

<td>(GMT-06:00) Central America</td>

</tr>

<tr>

<td>Central Standard Time</td>

<td>(GMT-06:00) Central Time (US &amp; Canada)</td>

</tr>

<tr>

<td>Central Standard Time (Mexico)</td>

<td>(GMT-06:00) Guadalajara, Mexico City, Monterrey - New</td>

</tr>

<tr>

<td>Mexico Standard Time</td>

<td>(GMT-06:00) Guadalajara, Mexico City, Monterrey - Old</td>

</tr>

<tr>

<td>Canada Central Standard Time</td>

<td>(GMT-06:00) Saskatchewan</td>

</tr>

<tr>

<td>US Mountain Standard Time</td>

<td>(GMT-07:00) Arizona</td>

</tr>

<tr>

<td>Mountain Standard Time (Mexico)</td>

<td>(GMT-07:00) Chihuahua, La Paz, Mazatlan - New</td>

</tr>

<tr>

<td>Mexico Standard Time 2</td>

<td>(GMT-07:00) Chihuahua, La Paz, Mazatlan - Old</td>

</tr>

<tr>

<td>Mountain Standard Time</td>

<td>(GMT-07:00) Mountain Time (US &amp; Canada)</td>

</tr>

<tr>

<td>Pacific Standard Time</td>

<td>(GMT-08:00) Pacific Time (US &amp; Canada)</td>

</tr>

<tr>

<td>Pacific Standard Time (Mexico)</td>

<td>(GMT-08:00) Tijuana, Baja California</td>

</tr>

<tr>

<td>Alaskan Standard Time</td>

<td>(GMT-09:00) Alaska</td>

</tr>

<tr>

<td>Hawaiian Standard Time</td>

<td>(GMT-10:00) Hawaii</td>

</tr>

<tr>

<td>Samoa Standard Time</td>

<td>(GMT-11:00) Midway Island, Samoa</td>

</tr>

<tr>

<td>Dateline Standard Time</td>

<td>(GMT-12:00) International Date Line West</td>

</tr>

</tbody>

</table>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="7/24/2013 7:48:27 PM" LocalTimeTicks="1374720507">Jul 24, 2013 at 7:48 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/kevinjones.md">kevinjones</a>, version 112<br />

Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=Connection%20Strings">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


