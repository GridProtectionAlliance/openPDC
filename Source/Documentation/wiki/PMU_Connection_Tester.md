

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>PMU Connection Tester</title>



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

<h1>PMU Connection Tester</h1>

<b>Note:</b> The PMU Connection Tester is now its own open source project. For the latest documentation and program updates, please visit:

<a href="http://pmuconnectiontester.codeplex.com">http://pmuconnectiontester.codeplex.com</a>.<br>

<ul>

<li><a href="#installation">Installation</a> </li><li><a href="#overview">Overview</a> </li><li><a href="#navigation">Navigation</a>

<ul>

<li><a href="#config_frame">Configuration Frame</a> </li><li><a href="#connection_parameters">Connection Parameters</a> </li><li><a href="#graph_tab">Graph Tab</a> </li><li><a href="#messages_tab">Messages Tab</a> </li><li><a href="#protocol_specific_tab">Protocol Specific Tab</a> </li><li><a href="#settings_tab">Settings Tab</a> </li><li><a href="#header_frame">Header Frame</a> </li><li><a href="#realtime_frame_detail">Real-time Frame Detail</a></li></ul>

</li><li><a href="#operations">Operations</a>

<ul>

<li><a href="#capture_sample_frames">Capturing Sample Frames</a> </li><li><a href="#connect_devices">Connecting to Devices</a> </li><li><a href="#load_config_files">Loading Configuration Files</a> </li><li><a href="#record_data_streams">Recording Data Streams</a> </li><li><a href="#save_config_files">Saving Configuration Files</a> </li><li><a href="#use_previous_connection">Using Previous Connections</a> </li><li><a href="#stream_debug_capturing">Stream Debug Capturing</a></li></ul>

</li></ul>

<hr>

<h2><a name="installation"></a>Installation</h2>

Instructions for <a href="http://openpdc.codeplex.com/wikipage?title=Getting%20Started&referringTitle=Connection%20Tester&ANCHOR#openpdc_installers">

using the openPDC installers</a> or <a href="http://openpdc.codeplex.com/wikipage?title=Getting%20Started&referringTitle=Connection%20Tester&ANCHOR#build_synchrophasor">

building from source</a> can be found on the <a href="http://openpdc.codeplex.com/wikipage?title=Getting%20Started&referringTitle=Connection%20Tester">

Getting Started</a> page.<br>

<hr>

<h2><a name="overview"></a>Overview</h2>

The PMU Connection Tester verifies that the data stream from any known phasor measurement device is being received. Device types that can be tested through the PMU Connection Tester application may include:<br>

<ul>

<li>Phasor Measurement Unit (PMU) </li><li>Phasor Data Concentrator (PDC) </li><li>Digital Fault Recorder (DFR) </li><li>Power Quality (PQ)</li></ul>

<br>

Any device that supports one of the following phasor protocols may be tested:<br>

<ul>

<li>IEEE C37.118-2005 (Version 1/Draft 7, Draft 6) </li><li>IEEE 1344-1995 </li><li>BPA PDCstream (Revisions 0, 1, and 2, including PDCxchng formatted data) </li><li>Virginia Tech FNet </li><li>SEL Fast Message </li><li>Macrodyne</li></ul>

<hr>

<h2><a name="navigation"></a>Navigation</h2>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95637" alt="main.png" title="main.png"><br>

<br>

Some portions of the screen can be opened by clicking the Expand button (<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95638" alt="button_expand.png" title="button_expand.png">) and closed by clicking the Contract

 button (<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95639" alt="button_contract.png" title="button_contract.png">). Other sections are accessed by clicking on named tabs (<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95640" alt="tabs.png" title="tabs.png">).<br>

<hr>

<h3><a name="config_frame"></a>Configuration Frame</h3>

<br>

The Configuration Frame displays the relevant information from the configured elements in the connected device.<br>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95643" alt="configuration_pane.png" title="configuration_pane.png"><br>

<ul>

<li><b>PMU</b>: Lists all of the configured devices that are connected to the tested device.

</li><li><b>ID Code</b>: Displays the unique identifier of the tested device. This is populated from the Device ID Code entered on the Protocols tab in the Connection Parameters section.

</li><li><b>Phasor</b>: Lists the labels of all phasors measured by the selected device.

</li><li><b>Phasors</b>: Displays the total number of phasors in the selected device. </li><li><b>Analogs</b>: Displays the total number of measured analog values in the selected device.

</li><li><b>Digitals</b>: Displays the total number of digital values in the selected device.

</li><li><b>Nominal Frequency</b>: </li><li><b>Power (MW)</b>: Displays the calculated megawatts, based on the Voltage Phasor and Current Phasor selections on the

<a href="#settings_tab">Settings tab</a>. </li><li><b>Vars (MVars)</b>: Displays the calculated megavars, based on the Voltage Phasor and Current Phasor selections on the

<a href="#settings_tab">Settings tab</a>.</li></ul>

<hr>

<h3><a name="connection_parameters"></a>Connection Parameters</h3>

<br>

The Connection Parameters screen section displays the details concerning the connection between the PMU Connection Tester and the tested device. The details differ depending upon the communication protocol selected.<br>

<h4>Tcp</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95647" alt="conn_tcp.png" title="conn_tcp.png"><br>

<ul>

<li><b>Host IP</b>: The internet address of the device being tested. </li><li><b>Port</b>: The port number through which the PMU Connection Tester is connected to and receiving data from the tested device.

</li><li><b>Establish Tcp Server</b>: Select to establish a TCP Server style connection to listen for remote device data streams, such as from FNet devices.</li></ul>

<h4>Udp</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=112278" alt="conn_udp.png" title="conn_udp.png"><br>

<ul>

<li><b>Local Port</b>: The port number through which the PMU Connection Tester is receiving data from the tested device.

</li><li><b>Enable Multicast / Remote Udp</b>: If the tested device listens on UDP, select this check box which makes the following screen elements available.

</li><li><b>Host IP</b>: The internet address of the device being tested. </li><li><b>Remote Port</b>: The port number on the tested device through which the PMU Connection Tester sends commands.</li></ul>

<h4>Serial</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95649" alt="conn_serial.png" title="conn_serial.png"><br>

<ul>

<li><b>Port</b>: The local serial port through which the PMU Connection Tester is receiving data from the tested device.

</li><li><b>Baud Rate</b>: Baud rate to use during transmission to the tested device. </li><li><b>Parity</b>: Parity to use during transmission to the tested device. </li><li><b>Stop Bits</b>: Number of stop bits to use during transmission to the tested device.

</li><li><b>Data Bits</b>: Number of data bits to use during transmission to the tested device.

</li><li><b>DTR</b>: Enables the Data Terminal Ready flag. </li><li><b>RTS</b>: Enables the Ready To Send flag.</li></ul>

<h4>File</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=112277" alt="conn_file.png" title="conn_file.png"><br>

<ul>

<li><b>Filename</b>: The name of the saved file created by recording data streams.

</li><li><b>Frame Rate</b>: Number of frames per second the saved data streams are displayed.

</li><li><b>Auto-repeat captured file playback</b>: Check this box to have the PMU Connection Tester return to the beginning of the sample file once it reaches the end.</li></ul>

<h4>Protocol and ID</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=112279" alt="protocol.png" title="protocol.png"><br>

<ul>

<li><b>Protocol</b>: Lists the available phasor data protocols. </li><li><b>Device ID Code</b>: Specifies the identification code often needed to establish a connection.</li></ul>

<h4>Command</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95652" alt="command.png" title="command.png"><br>

<ul>

<li><b>Command</b>: Lists the available commands that the tested device will respond to.</li></ul>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95653" alt="command_list.png" title="command_list.png"><br>

<ul>

<li><b>Send</b>: Transmits the selected command to the device.</li></ul>

<hr>

<h3><a name="graph_tab"></a>Graph Tab</h3>

<br>

Displays graphically the real-time data stream from the tested device.<br>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95654" alt="tab_graph.png" title="tab_graph.png"><br>

<br>

The top graph shows the system frequency as measured by the tested device. The bottom graph displays the phase angles.<br>

<br>

If the <b>Phase Angle Graph Style</b> (<a href="#settings_tab">Settings tab</a>) is set to

<b>Relative</b>, all the displayed phase angles will be relative to the selected device in the

<a href="#config_frame">Configuration Frame</a>. If it is set to <b>Raw</b>, the phase angles are displayed as measured by the tested device.<br>

<br>

The legend on the bottom right of the Graph tab displays the configured devices connected to the tested device, as listed in the Phasor box on the

<a href="#config_frame">Configuration Frame</a>.<br>

<hr>

<h3><a name="messages_tab"></a>Messages Tab</h3>

<br>

The Messages tab displays any relevant information about, or errors generated by, the connection to the tested device.<br>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95655" alt="tab_messages.png" title="tab_messages.png"><br>

<hr>

<h3><a name="protocol_specific_tab"></a>Protocol Specific Tab</h3>

<br>

Displays a hierarchy of the last parsed protocol specific frames, and includes all data values relevant to the protocol.<br>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95656" alt="protocol_spec.png" title="protocol_spec.png"><br>

<br>

This tab enables quick validation of protocol-specific properties of vendor implementation.<br>

<hr>

<h3><a name="settings_tab"></a>Settings Tab</h3>

<br>

The Settings tab allows the user to configure various settings related to the PMU Connection Tester display.<br>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95657" alt="tab_settings.png" title="tab_settings.png"><br>

<ul>

<li><b>Voltage Phasor</b>: Lists the voltage phasor used in the megawatt and megavar calculation displayed on the

<a href="#config_frame">Configuration Frame</a>. </li><li><b>Current Phasor</b>: Lists the current phasor used in the megawatt and megavar calculation displayed on the

<a href="#config_frame">Configuration Frame</a>. </li><li><b>Get Parsing Status</b>: Displays the current connection status on the <a href="#messages_tab">

Messages tab</a>. </li><li><b><a href="#app_settings">Application Settings</a></b>: Defines general application settings.

</li><li><b><a href="#attribute_tree">Attribute Tree</a></b>: Defines settings associated with the attribute tree visible on the

<a href="#protocol_specific_tab">Protocol Specific tab</a>. </li><li><b><a href="#chart_settings">Chart Settings</a></b>: Defines general chart-related settings.

</li><li><b><a href="#frequency_graph">Frequency Graph</a></b>: Defines settings related to the frequency graph.

</li><li><b><a href="#phase_angle_graph">Phase Angle Graph</a></b>: Defines settings related to the phase angle graph.</li></ul>

<h4><a name="app_settings"></a>Application Settings</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95658" alt="application_settings.png" title="application_settings.png"><br>

<ul>

<li><b>AutoStartDataParsingSequence</b> [Range: <u>True</u>/False]: Set to True to automatically send commands for ConfigFrame2 and EnableRealTimeData.

</li><li><b>ExecuteParseOnSeparateThread</b> [Range: True/<u>False</u>]: Allows frame parsing to be executed on a separate thread (other than communications thread) - typically only needed when data frames are very large. This change will happen dynamically, even

 if a connection is active. </li><li><b>MaximumConnectionAttempts</b> [Range: 1-n]: Maximum number of times to attempt connection before giving up. Set the value to -1 to continue connection attempt indefinitely.

</li><li><b>MaximumFrameDisplayBytes</b> [Range: 1-n]: Maximum encoded bytes to display for frames in the

<a href="#realtime_frame_detail">Real-time Frame Detail</a>. </li><li><b>RestoreLastConnectionSettings</b> [Range: <u>True</u>/False]: Set to True to load previous connection settings at startup.</li></ul>

<h4><a name="attribute_tree"></a>Attribute Tree</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95659" alt="attribute_tree.png" title="attribute_tree.png"><br>

<ul>

<li><b>ChannelNodeBackgroundColor</b>: Defines the highlight background color for channel node entries on the attribute tree.

</li><li><b>ChannelNodeForegroundColor</b>: Defines the highlight foreground color for channel node entries on the attribute tree.

</li><li><b>InitialNodeState</b> [Range: <u>Collapsed</u>/Expanded]: Defines the initial state for nodes when added to the attribute tree. Note that a fully expanded tree will take much longer to initialize.

</li><li><b>ShowAttributesAsChildren</b> [Range: <u>True</u>/False]: Set to <span class="codeInline">

True </span>to show attributes as children of their channel entries.</li></ul>

<h4><a name="chart_settings"></a>Chart Settings</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95660" alt="chart_settings.png" title="chart_settings.png"><br>

<ul>

<li><b>BackgroundColor</b>: Select the background color for the <a href="#graph_tab">

graph region</a>. </li><li><b>ForegroundColor</b>: Select the foreground color for <a href="#graph_tab">

graph region</a> (axes, legend border, text, etc.). </li><li><b>RefreshRate</b> [Range: 0.1-n]: Chart refresh rate in seconds. The typical setting is

<span class="codeInline">0.1 </span>, increase this number if the application runs slowly.

</li><li><b>ShowDataPointsOnGraphs</b> [Range: <u>True</u>/False]: Set to <span class="codeInline">

True </span>to show data points on graphs. </li><li><b>TrendLineWidth</b> [Range: 1-n]: Enter the trend line graphing width (in pixels).</li></ul>

<h4><a name="frequency_graph"></a>Frequency Graph</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95663" alt="frequency_graph.png" title="frequency_graph.png"><br>

<ul>

<li><b>FrequencyColor</b>: Foreground color for frequency trend. </li><li><b>FrequencyPointsToPlot</b> [Range: 1-n]: Sets the total number of frequency points to display.</li></ul>

<h4><a name="phase_angle_graph"></a>Phase Angle Graph</h4>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95665" alt="phase_angle_graph.png" title="phase_angle_graph.png"><br>

<ul>

<li><b>LegendBackgroundColor</b>: Background color for phase angle legend. </li><li><b>LegendForegroundColor</b>: Foreground color for phase angle legend text. </li><li><b>PhaseAngleColors</b> [Range: Collection/]: Possible foreground colors for phase angle trends.

</li><li><b>PhaseAngleGraphStyle</b> [Range: Raw/<u>Relative</u>]: Sets the phase angle graph to plot either raw or relative phase angles.

</li><li><b>PhaseAnglePointsToPlot</b> [Range: 1-n]: Sets the total number of phase angle points to display.

</li><li><b>ShowPhaseAngleLegend</b> [Range: <u>True</u>/False]: Set to <span class="codeInline">

True </span>to show phase angle graph legend.</li></ul>

<hr>

<h3><a name="header_frame"></a>Header Frame</h3>

<br>

The Header Frame displays the user-configured information file, usually in the form of a text file, that is stored on the tested device.<br>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95671" alt="header_frame.png" title="header_frame.png"><br>

<hr>

<h3><a name="realtime_frame_detail"></a>Real-time Frame Detail</h3>

<br>

The Real-time Frame Detail section displays details about the measurements received from the tested device.<br>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95672" alt="real_time_frame_detail.png" title="real_time_frame_detail.png"><br>

<ul>

<li><b>Frame type</b>: Displays the phasor protocol frame type of the frame received from the tested device.

</li><li><b>Time</b>: Displays the time value parsed from the received frame, displayed in Universal Coordinated Time (UTC).

</li><li><b>Frequency</b>: Displays the measured system frequency received in the frame.

</li><li><b>Angle</b>: Displays the measured phase angle of the currently selected Phasor (<a href="#config_frame">Configuration Frame</a>) received in the frame.

</li><li><b>Magnitude</b>: Displays the measured magnitude of the currently selected Phasor (<a href="#config_frame">Configuration Frame</a>) received in the frame (The parenthetical value is the calculated line-to-neutral value when the selected phasor is a voltage.).

</li><li><b>Display</b>: Lists the various formats in which the binary data in the received frame can be shown.</li></ul>

<br>

<img src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=openpdc&DownloadId=95673" alt="list_display.png" title="list_display.png"><br>

<hr>

<h2><a name="operations"></a>Operations</h2>

<h3><a name="capture_sample_frames"></a>Capturing Sample Frames</h3>

<br>

The PMU Connection Tester allows the user to debug and analyze protocol-specific phasor frames from the tested device. Note that only one of each type of frame can be collected during the capture sequence.<br>

<ol>

<li>From the File menu, point to Capture and then select the Capture Sample Frames menu option.

</li><li>In the displayed save screen, enter the desired File name of the output file.

</li><li>Click OK on the displayed message (Sample frame collection will complete upon reception of a configuration frame).

</li><li>The file will be displayed in a separate window as a .txt file.</li></ol>

<br>

<a href="http://www.codeplex.com/Download?ProjectName=openpdc&DownloadId=95675">Click to view a sample file.</a><br>

<hr>

<h3><a name="connect_devices"></a>Connecting to Devices</h3>

<h4>Connecting via TCP</h4>

<ol>

<li>Click the <b>Tcp</b> tab. </li><li>Enter the <b>Host IP</b> address of the device being tested. </li><li>Enter the <b>Port</b> number through which the PMU Connection Tester is receiving the signal from the tested device.

</li><li>Click <b>Connect</b>.</li></ol>

<h4>Connecting via UDP</h4>

<ol>

<li>Click the <b>Udp</b> tab. </li><li>Enter the <b>Local Port</b> number through which the PMU Connection Tester is receiving the signal from the tested device.

</li><li>Click the <b>Remote device listens on Udp</b> check box, if applicable, and then enter the

<b>Host IP</b> and <b>Remote Port</b> of the tested device. </li><li>Click <b>Connect</b>.</li></ol>

<h4>Connecting via a Serial Port</h4>

<ol>

<li>Click the <b>Serial</b> tab. </li><li>Enter the <b>Port</b> through which the PMU Connection Tester is receiving the signal from the tested device.

</li><li>Enter the configuration details the data transfer between the PMU Connection Tester and the tested device.

</li><li>Click Connect.</li></ol>

<hr>

<h3><a name="load_config_files"></a>Loading Configuration Files</h3>

<ol>

<li>From the <b>File</b> menu, point to <b>Config File</b> and then select the <b>

Load</b> menu option. </li><li>In the displayed window, select the saved configuration file (XML format), and click

<b>Open</b>.</li></ol>

<hr>

<h3><a name="record_data_streams"></a>Recording and Replaying Data Streams</h3>

<br>

The PMU Connection Tester allows the user to record all streaming data to a file for later playback and analysis.<br>

<ol>

<li>From the <b>File</b> menu, point to <b>Capture</b> and then select the <b>Start Capture</b> menu option.

</li><li>In the displayed save screen, enter the desired <b>File name</b> of the output file.

</li><li>The capture process will continue until you select the <b>File &gt; Capture &gt; Stop Capture</b> menu option.</li></ol>

<br>

To replay the data stream:<br>

<ol>

<li>Click the <b>File</b> tab. </li><li>Enter or select the saved <b>Filename</b>. </li><li>Select the <b>Frame Rate</b> for the display. </li><li>Verify the <b>Protocol</b> on the <a href="#connection_parameters">Connection Parameters</a> screen section.

</li><li>Click <b>Connect</b>.</li></ol>

<hr>

<h3><a name="save_config_files"></a>Saving Configuration Files</h3>

<br>

To save a configuration (Only available when connected, and after a configuration frame has been received):<br>

<ol>

<li>From the <b>File</b> menu, point to <b>Config File</b> and then select the <b>

Save</b> menu option. </li><li>In the displayed save screen, enter the desired <b>File name</b> of the output file, and click

<b>Save</b>.</li></ol>

<br>

<a href="http://www.codeplex.com/Download?ProjectName=openpdc&DownloadId=95678">Click to view a sample configuration file.</a><br>

<hr>

<h3><a name="use_previous_connection"></a>Using Previous Connections</h3>

<br>

The PMU Connection Tester automatically saves the last connection by default. To save a connection for later use:<br>

<ol>

<li>From the <b>File</b> menu, point to <b>Connection</b> and then select the <b>

Save</b> menu option. </li><li>In the displayed save screen, enter the desired <b>File name</b> of the output file, and click

<b>Save</b>.</li></ol>

<br>

To use a previous connection:<br>

<ol>

<li>From the <b>File</b> menu, point to <b>Connection</b> and then select the <b>

Load</b> menu option. </li><li>In the displayed window, select the saved connection file, and click <b>Open</b>.

</li><li>Click <b>Connect</b>.</li></ol>

<br>

Connection files have a <span class="codeInline">.PMUConnection </span>extension. When installed, the PMU Connection Tester associates itself with files of that extension.<br>

<hr>

<h3><a name="stream_debug_capturing"></a>Stream Debug Capturing</h3>

<br>

The PMU Connection Tester is capable of capturing raw data to a CSV file for analysis. To capture data to a CSV file:<br>

<ol>

<li>From the <b>File</b> menu, point to <b>Capture</b> and then select the <b>Start Stream Debug Capture...</b> menu option.

</li><li>In the displayed save screen, enter the desired <b>File name</b> of the output file.

</li><li>The capture process will continue until you select the <b>File &gt; Capture &gt; Stop Stream Debug Capture</b> menu option.</li></ol>

<br>

Once you&#39;ve captured the data, you can open the file using Microsoft Office Excel and follow these steps to format the timestamps to be human readable.<br>

<ol>

<li>Select the entire first column, right-click the column header, and select &quot;Format Cells&quot;.

</li><li>In the &quot;Category&quot; list, select &quot;Custom&quot;. </li><li>Enter &quot;mm/dd/yyyy h:mm:ss.000&quot; into the &quot;Type&quot; text box and select the &quot;OK&quot; button.</li></ol>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />



</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


