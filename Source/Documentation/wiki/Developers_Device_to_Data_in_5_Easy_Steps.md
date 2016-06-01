<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8" />
</head>
<body>
<!--HtmlToGmd.Body-->
<h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>
<hr />
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
<h1>Device to Data in 5 Easy Steps</h1>
<p>This guide is intended to aid you in getting data from your device as quickly and easily as possible. The steps are as follows:</p>
<ol>
<li><a href="#step1">Create a project</a> </li><li><a href="#step2">Add references</a> </li><li><a href="#step3">Copy in the code snippet</a> </li><li><a href="#step4">Set up your data source</a> </li><li><a href="#step5">Run the application</a> </li></ol>
<h2><a name="step1"></a>Step 1: Create a project</h2>
<p>The first thing you need to do is create a console application in Microsoft Visual Studio 2015. The following are detailed steps to guide you through the process.</p>
<ol>
<li>Launch Microsoft Visual Studio </li><li>In the toolbar, go to &quot;File &gt; New &gt; Project...&quot; </li><li>In the left pane, navigate to &quot;Installed &gt; Templates &gt; Visual C#&quot;. </li><li>In the center pane, select &quot;Console Application&quot;. </li><li>In the text box labeled &quot;Name&quot;, enter the name of your application (i.e. &quot;DeviceToData&quot;).
</li><li>Click the button labeled &quot;Browse...&quot; and select a directory to store the project.
</li><li>Click the &quot;OK&quot; button </li><li>Right Click on your new project and select &quot;Properties&quot; </li><li>In the Application settings, change the Target Framework to &quot;.NET Framework 4.6&quot;
</li></ol>
<h2><a name="step2"></a>Step 2: Add references</h2>
<p>In order to get the code to run, you will need to add references to the openPDC assemblies. The following are detailed steps to guide you through the process.<br>
<strong>Note</strong>: In order to complete this step, you will need to <a href="http://www.gridprotectionalliance.org/NightlyBuilds/openPDC/Beta-VS2012/Synchrophasor.Binaries.zip">
download the latest openPDC binaries</a>.</p>
<ol>
<li>In your project's Solution Explorer on the right, right-click &quot;References&quot;, select &quot;Add Reference...&quot;, then click the Browse button
</li><li>Navigate to &quot;BINARIESDIR\Applications\openPDC&quot; (BINARIESDIR is the directory where you extracted the openPDC binaries).
</li><li>Select &quot;GSF.Communication.dll&quot;, &quot;GSF.Core.dll&quot;, &quot;GSF.PhasorProtocols.dll&quot;, and &quot;GSF.TimeSeries.dll&quot; then click the &quot;OK&quot; button
</li></ol>
<h2><a name="step3"></a>Step 3: Copy in the code snippet</h2>
<p>Now you are ready to copy the source code that will interface with your device. Remove everything in Program.cs and replace it with the following code snippet.<br>
<br>
</p>
<div style="color:black; background-color:white">
<pre><span style="color:blue">using</span> System;
<span style="color:blue">using</span> GSF;
<span style="color:blue">using</span> GSF.PhasorProtocols;
<span style="color:blue">namespace</span> DeviceToData
{
    <span style="color:blue">class</span> Program
    {
        <span style="color:blue">static</span> MultiProtocolFrameParser parser;
        <span style="color:blue">static</span> <span style="color:blue">long</span> frameCount;
        <span style="color:blue">static</span> <span style="color:blue">void</span> Main(<span style="color:blue">string</span>[] args)
        {
            <span style="color:green">// Create a new protocol parser</span>
            parser = <span style="color:blue">new</span> MultiProtocolFrameParser();
            <span style="color:green">// Attach to desired events</span>
            parser.ConnectionAttempt &#43;= parser_ConnectionAttempt;
            parser.ConnectionEstablished &#43;= parser_ConnectionEstablished;
            parser.ConnectionException &#43;= parser_ConnectionException;
            parser.ParsingException &#43;= parser_ParsingException;
            parser.ReceivedConfigurationFrame &#43;= parser_ReceivedConfigurationFrame;
            parser.ReceivedDataFrame &#43;= parser_ReceivedDataFrame;
            <span style="color:green">// Define the connection string</span>
            parser.ConnectionString =
                <span style="color:#a31515">&quot;phasorProtocol=Ieee1344; accessID=2; &quot;</span> &#43;
                <span style="color:#a31515">&quot;transportProtocol=File; file=Sample1344.PmuCapture&quot;</span>;
            
            <span style="color:green">// When connecting to a file based resource you may want to loop the data</span>
            parser.AutoRepeatCapturedPlayback = <span style="color:blue">true</span>;
            <span style="color:green">// Start frame parser</span>
            parser.AutoStartDataParsingSequence = <span style="color:blue">true</span>;
            parser.Start();
            <span style="color:green">// Keep the console open while receiving live data; application will be terminated when the user presses the Enter key:</span>
            Console.ReadLine();
        }
        <span style="color:blue">static</span> <span style="color:blue">void</span> parser_ReceivedDataFrame(<span style="color:blue">object</span> sender, EventArgs&lt;IDataFrame&gt; e)
        {
            <span style="color:green">// Increase the frame count each time a frame is received</span>
            frameCount&#43;&#43;;
            <span style="color:green">// Print information each time we receive 60 frames (every 2 seconds for 30 frames per second)</span>
            <span style="color:green">// Also check to assure the DataFrame has at least one Cell</span>
            <span style="color:blue">if</span> ((frameCount % 60 == 0) &amp;&amp; (e.Argument.Cells.Count &gt; 0))
            {
                IDataCell device = e.Argument.Cells[0];
                Console.WriteLine(<span style="color:#a31515">&quot;Received {0} data frames so far...&quot;</span>, frameCount);
                Console.WriteLine(<span style="color:#a31515">&quot;    Last frequency: {0}Hz&quot;</span>, device.FrequencyValue.Frequency);
                <span style="color:blue">for</span> (int x = 0; x &lt; device.PhasorValues.Count; x&#43;&#43;)
                {
                    Console.WriteLine(<span style="color:#a31515">&quot;PMU {0} Phasor {1} Angle = {2}&quot;</span>, device.IDCode, x, device.PhasorValues[x].Angle);
                    Console.WriteLine(<span style="color:#a31515">&quot;PMU {0} Phasor {1} Magnitude = {2}&quot;</span>, device.IDCode, x, device.PhasorValues[x].Magnitude);
                }
                Console.WriteLine(<span style="color:#a31515">&quot;    Last Timestamp: {0}&quot;</span>, ((DateTime)e.Argument.Timestamp).ToString(<span style="color:#a31515">&quot;yyyy-MM-dd HH:mm:ss.fff&quot;</span>));
            }
        }
        <span style="color:blue">static</span> <span style="color:blue">void</span> parser_ReceivedConfigurationFrame(<span style="color:blue">object</span> sender, EventArgs&lt;IConfigurationFrame&gt; e)
        {
            <span style="color:green">// Notify the user when a configuration frame is received</span>
            Console.WriteLine(<span style="color:#a31515">&quot;Received configuration frame with {0} device(s)&quot;</span>, e.Argument.Cells.Count);
        }
        <span style="color:blue">static</span> <span style="color:blue">void</span> parser_ParsingException(<span style="color:blue">object</span> sender, EventArgs&lt;Exception&gt; e)
        {
            <span style="color:green">// Output the exception to the user</span>
            Console.WriteLine(<span style="color:#a31515">&quot;Parsing exception: {0}&quot;</span>, e.Argument);
        }
        <span style="color:blue">static</span> <span style="color:blue">void</span> parser_ConnectionException(<span style="color:blue">object</span> sender, EventArgs&lt;Exception, <span style="color:blue">int</span>&gt; e)
        {
            <span style="color:green">// Display which connection attempt failed and the exception that occurred</span>
            Console.WriteLine(<span style="color:#a31515">&quot;Connection attempt {0} failed due to exception: {1}&quot;</span>,
                e.Argument2, e.Argument1);
        }
        <span style="color:blue">static</span> <span style="color:blue">void</span> parser_ConnectionEstablished(<span style="color:blue">object</span> sender, EventArgs e)
        {
            <span style="color:green">// Notify the user when the connection is established</span>
            Console.WriteLine(<span style="color:#a31515">&quot;Initiating {0} {1} based connection...&quot;</span>,
                parser.PhasorProtocol.GetFormattedProtocolName(),
                parser.TransportProtocol.ToString().ToUpper());
        }
        <span style="color:blue">static</span> <span style="color:blue">void</span> parser_ConnectionAttempt(<span style="color:blue">object</span> sender, EventArgs e)
        {
            <span style="color:green">// Let the user know we are attempting to connect</span>
            Console.WriteLine(<span style="color:#a31515">&quot;Attempting connection...&quot;</span>);
        }
    }
}
</pre>
</div>
<h2><a name="step4"></a>Step 4: Set up your data source</h2>
<p>This step will vary depending on your data source. Information on setting up the connection string can be found on the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#configure_connection_string">
Getting Started</a> page.<br>
<br>
This&nbsp;example uses the sample data file in the <a href="http://pmuconnectiontester.codeplex.com">
PMU Connection Tester</a> project.&nbsp; Copy the &quot;Sample1344.PmuCapture&quot; file from PMU Connection Tester's &quot;SOURCEDIR\Main\Source\Tools\PMUConnectionTester&quot; to &quot;PROJECTDIR\bin\Debug&quot;</p>
<p>(SOURCEDIR is the directory where you extracted the PMU Connection Tester source code files, and PROJECTDIR is the directory where you stored your project in step 1).</p>
<h2><a name="step5"></a>Step 5: Run the application</h2>
<p>If you followed all the other steps correctly, you should be able to run the project by pressing &quot;F5&quot; from within Microsoft Visual Studio. The result should look something like the example image below.<br>
<br>
<img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Device_to_Data_in_5_Easy_Steps.files/device_to_data2.png" alt="Device_To_Data_Example" width="669" height="1047" /></p>
</div>
</div>
</body>
</html>
