

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Developers Custom Adapters</title>



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

<h1>How to Create a Custom Adapter</h1>

<p>This guide is designed to aid in the creation of custom adapters for the openPDC. Custom adapters allow users to easily extend the default functionality of the system. The openPDC defines three types of adapters--input, action, and output--that are each

 designed to be used for different purposes.<br>

<br>

<strong>InputAdapters</strong>: Typically &ldquo;maps&rdquo; measurements from a data source (i.e., assigns a timestamp and an ID to measured values parsed from a stream of data), new measurements are presented to openPDC by calling &ldquo;void OnNewMeasurements(ICollection&lt;IMeasurement&gt;

 measurements)&rdquo; method. Interface: IInputAdapter, base class: InputAdapterBase<br>

<br>

<strong>ActionAdapters</strong>: Typically filters and sorts measurements by time allowing adapter to take action on a synchronized set of data provided in the &ldquo;abstract void PublishFrame(IFrame frame, int index)&rdquo; method which adapter overrides

 (note that frame contains a collection of measurements all collected into the same time-indexed frame bucket). If the action causes the creation of new measurements (e.g., phase angle and magnitude used to calculate power), new measurements are presented to

 openPDC by calling &ldquo;void OnNewMeasurements(ICollection&lt;IMeasurement&gt; measurements)&rdquo; method. Interface: IActionAdapter, base class: ActionAdapterBase<br>

<br>

<strong>OutputAdapters</strong>: Typically queues all measurements (no sorting) for processing. Queued measurements are presented to the adapter for processing in the &ldquo;void ProcessMeasurements(IMeasurement[] measurements)&rdquo; method &ndash; if measurements

 continue to build up in memory and are not processed in a timely manner they will be removed from the queue as protective measure to prevent catastrophic out-of-memory failures. Since output adapters are used to archive data this is often the slowest part

 in the system (disks tend to be a bottleneck), outputs can optionally be set to filter based on a measurement&rsquo;s defined &ldquo;Source&rdquo; property &ndash; this allows multiple outputs to be targeted to several different distributed outputs which allows

 large systems to stay ahead of the incoming data stream. Interface: IOutputAdapter, base class: OutputAdapterBase<br>

<br>

If you feel that one of these adapters suits your needs, continue reading.<br>

<br>

<strong>Note</strong>: Before you begin, please note that this guide assumes you are using Microsoft Visual Studio and C#.</p>

<ul>

<li><a href="#start_new_project">Start a new project</a> </li><li><a href="#add_references">Add references</a> </li><li><a href="#extend_base_class">Extending one of the base classes</a> </li><li><a href="#implementation">Implementation</a>

<ul>

<li><a href="#all_adapters">All adapter types</a>

<ul>

<li><a href="#connectionstring_property">ConnectionString</a> </li><li><a href="#settings_property">Settings</a> </li><li><a href="#initialize_method">Initialize()</a> </li><li><a href="#start_method">Start()</a> </li><li><a href="#stop_method">Stop()</a> </li><li><a href="#dispose_method">Dispose(bool)</a> </li><li><a href="#onstatusmessage_method">OnStatusMessage(string)</a> </li><li><a href="#onprocessexception_method">OnProcessException(Exception)</a> </li><li><a href="#status_property">Status</a> </li><li><a href="#datasource_property">DataSource</a> </li><li><a href="#getshortstatus_method">GetShortStatus(int)</a> </li><li><a href="#isinputmeasurement_method">IsInputMeasurement(MeasurementKey)</a>

</li><li><a href="#waitforinitialize_method">WaitForInitialize()</a> </li></ul>

</li><li><a href="#input_adapters">Input adapters</a>

<ul>

<li><a href="#input_attemptconnection_method">AttemptConnection()</a> </li><li><a href="#input_attemptdisconnection_method">AttemptDisconnection()</a> </li><li><a href="#input_useasyncconnect_property">UseAsyncConnect</a> </li><li><a href="#input_onnewmeasurements_method">OnNewMeasurements(ICollection&lt;IMeasurement&gt;)</a>

</li></ul>

</li><li><a href="#action_adapters">Action adapters</a>

<ul>

<li><a href="#action_publishframe_method">PublishFrame(IFrame, int)</a> </li><li><a href="#action_onnewmeasurements_method">OnNewMeasurements(ICollection&lt;IMeasurement&gt;)</a>

</li><li><a href="#action_queuemeasurementsforprocessing_method">QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt;)</a>

</li></ul>

</li><li><a href="#output_adapters">Output adapters</a>

<ul>

<li><a href="#output_attemptconnection_method">AttemptConnection()</a> </li><li><a href="#output_attemptdisconnection_method">AttemptDisconnection()</a> </li><li><a href="#output_outputisforarchive_property">OutputIsForArchive</a> </li><li><a href="#output_processmeasurements_method">ProcessMeasurements()</a> </li><li><a href="#output_useasyncconnect_property">UseAsyncConnect</a> </li></ul>

</li></ul>

</li><li><a href="#adapter_use">Using your custom adapter</a>

<ul>

<li><a href="#NodeID_field">NodeID</a> </li><li><a href="#ID_field">ID</a> </li><li><a href="#AdapterName_field">AdapterName</a> </li><li><a href="#AssemblyName_field">AssemblyName</a> </li><li><a href="#TypeName_field">TypeName</a> </li><li><a href="#ConnectionString_field">ConnectionString</a> </li><li><a href="#LoadOrder_field">LoadOrder</a> </li><li><a href="#Enabled_field">Enabled</a> </li></ul>

</li><li><a href="#other_adapters">Other adapter types</a>

<ul>

<li><a href="#facile_action_adapter">Facile action adapter</a> </li><li><a href="#calculated_measurement">Calculated measurement</a>

<ul>

<li><a href="#calculatedmeasurement_inputmeasurementkeytypes_property">InputMeasurementKeyTypes</a>

</li><li><a href="#calculatedmeasurement_outputmeasurementtypes_property">OutputMeasurementTypes</a>

</li><li><a href="#calculatedmeasurement_configurationsection_property">ConfigurationSection</a>

</li></ul>

</li></ul>

</li><li><a href="#examples">Examples</a>

<ul>

<li><a href="#processqueue_example">ProcessQueue example</a> </li><li><a href="#queuemeasurementsforprocessing_example">QueueMeasurementsForProcessing example</a>

</li></ul>

</li></ul>

<hr>

<h2><a name="start_new_project"></a>Start a new project</h2>

<ol>

<li>In the toolbar within Microsoft Visual Studio, go to &quot;File &gt; New &gt; Project...&quot;

</li><li>Under &quot;Project types&quot; on the left, go to &quot;Visual C# &gt; Windows&quot;.

</li><li>Under &quot;Templates&quot; on the right, select &quot;Class library&quot;. </li><li>Enter a name and location for the project. </li><li>Select the &quot;OK&quot; button. </li></ol>

<hr>

<h2><a name="add_references"></a>Add references</h2>

<ol>

<li>In the Solution Explorer within Visual Studio, right-click &quot;References&quot; and select &quot;Add Reference...&quot;

</li><li>Select the &quot;Browse&quot; tab and navigate to your <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.md#install_directory">

installation directory</a>. </li><li>Select &quot;TVA.Core.dll&quot; and &quot;TimeSeriesFramework.dll&quot;, then choose &quot;OK&quot;.

</li><li>At the top of the autogenerated class file, add the following code to the existing using statements.

</li></ol>

<div style="color:black; background-color:white">

<pre><span style="color:blue">using</span> TimeSeriesFramework;

<span style="color:blue">using</span> TimeSeriesFramework.Adapters;

</pre>

</div>

<hr>

<h2><a name="extend_base_class"></a>Extending one of the base classes</h2>

<p>The next thing you will want to do is to change the name of the autogenerated class and extend the base class corresponding to your chosen adapter type. The following three code snippets show example class names as well as the three adapter base classes.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">class</span> MyInputAdapter : InputAdapterBase

{

}

</pre>

</div>

<p>&nbsp;</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">class</span> MyActionAdapter : ActionAdapterBase

{

}

</pre>

</div>

<p>&nbsp;</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">class</span> MyOutputAdapter : OutputAdapterBase

{

}

</pre>

</div>

<p><br>

Once you have properly entered the class definition, you can quickly generate definitions for abstract methods defined in the base class. Click on the name of the base class, click the icon that appears underneath it and click the option labeled &quot;Implement

 abstract class&quot;. The following image shows the use of this feature.<br>

<br>

<img title="implement_base_class.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Custom_Adapters.files/implement_base_class.png" alt="implement_base_class.png"></p>

<hr>

<h2><a name="implementation"></a>Implementation</h2>

<p>The following subsections will go over the details about the methods and properties in each adapter that you can override or use.</p>

<h3><a name="all_adapters"></a>All adapter types</h3>

<p>This section will go over methods and properties used by all the adapter types.</p>

<h4><a name="connectionstring_property"></a>ConnectionString</h4>

<p>Once the adapter has been fully loaded from the database, the ConnectionString property can be used to access the connection string that was defined for it. However, the system also parses the connection string and places the key-value pairs into a Dictionary

 so it is recommended to use the Settings property instead. For an example of an adapter that uses the ConnectionString property, check the adapters in the MySqlAdapters project (part of the Synchrophasor solution).</p>

<h4><a name="settings_property"></a>Settings</h4>

<p>Once the adapter has been fully loaded from the database, the connection string is parsed and the key-value pairs are placed in a Dictionary known as the Settings property. Typical usage of this property can be found below in the description of the Initalize()

 method.</p>

<h4><a name="initialize_method"></a>Initialize()</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Initialize()

{

    <span style="color:blue">base</span>.Initialize();



    <span style="color:green">// custom initialization goes here</span>

}

</pre>

</div>

<p><br>

The Initialize() method can be overridden by your custom adapter class to initialize user-definable settings. This method is called by the system after the connection string has been set and the settings have been parsed. It is typically used in the following

 manner.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:green">// Fields</span>

<span style="color:blue">private</span> <span style="color:blue">string</span> m_mandatorySetting;

<span style="color:blue">private</span> <span style="color:blue">string</span> m_optionalSetting;



<span style="color:green">// Initalize</span>

<span style="color:green">// Connection string looks something like this:</span>

<span style="color:green">//   mandatorySetting=mandatoryValue; optionalSetting=optionalValue</span>

<span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Initialize()

{

    <span style="color:blue">base</span>.Initalize();



    Dictionary&lt;<span style="color:blue">string</span>, <span style="color:blue">string</span>&gt; settings = Settings;

    <span style="color:blue">string</span> setting;



    m_mandatorySetting = settings[<span style="color:#a31515">&quot;mandatorySetting&quot;</span>];



    <span style="color:blue">if</span>(settings.TryGetValue(<span style="color:#a31515">&quot;optionalSetting&quot;</span>, <span style="color:blue">out</span> setting))

        m_optionalSetting = setting;

}

</pre>

</div>

<h4><a name="start_method"></a>Start()</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Start()

{

    <span style="color:blue">base</span>.Start();



    <span style="color:green">// custom behavior goes here</span>

}

</pre>

</div>

<p><br>

The Start() method can be overridden by your adapter to establish connections or open files. This method may be called multiple times throughout the lifetime of the adapter.</p>

<h4><a name="stop_method"></a>Stop()</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Stop()

{

    <span style="color:blue">base</span>.Stop();



    <span style="color:green">// custom behavior goes here</span>

}

</pre>

</div>

<p><br>

The Stop() method can be overridden by your adapter to close connections or files. Typically, if an adapter overrides the Start() method, the Stop() method must also be overridden. This method may be called multiple times throughout the lifetime of the adapter.</p>

<h4><a name="dispose_method"></a>Dispose(bool)</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">private</span> <span style="color:blue">bool</span> m_disposed;



<span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Dispose(<span style="color:blue">bool</span> disposing)

{

    <span style="color:blue">if</span>(!m_disposed)

    {

        <span style="color:blue">try</span>

        {

            <span style="color:green">// This will be done regardless of whether</span>

            <span style="color:green">// the object is finalized or disposed.</span>



            <span style="color:blue">if</span>(disposing)

            {

                <span style="color:green">// This will be done only when the object</span>

                <span style="color:green">// is disposed by calling Dispose().</span>

            }

        }

        <span style="color:blue">finally</span>

        {

            m_disposed = <span style="color:blue">true</span>;        <span style="color:green">// Prevent duplicate dispose.</span>

            <span style="color:blue">base</span>.Dispose(disposing);  <span style="color:green">// Call base class Dispose().</span>

        }

    }

}

</pre>

</div>

<p><br>

If your adapter has any system resources that need to be released at the end of its lifecycle, you will need to override the Dispose(bool) method to do it. Typically, any code created for custom disposal should go in the section that will be done only when

 the object is disposed of by calling Dispose(). If you are using the TVA C# code snippets, typing &quot;disposec&quot; inside your class and then pressing the Tab key on your keyboard will automatically generate the code you see above.</p>

<h4><a name="onstatusmessage_method"></a>OnStatusMessage(string) and OnStatusMessage(string, params object[])</h4>

<p>If your adapter needs to report status to the user at any time, the OnStatusMessage() method can be used to display a message on the openPDCConsole. Some typical uses of this method include the following.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre>OnStatusMessage(<span style="color:#a31515">&quot;Attempting connection...&quot;</span>);

OnStatusMessage(<span style="color:#a31515">&quot;{0} measurements processed in {1} seconds&quot;</span>, m_measurementCount, m_upTime);

</pre>

</div>

<h4><a name="onprocessexception_method"></a>OnProcessException(Exception)</h4>

<p>If your adapter encounters an error that needs to be reported, the OnProcessException(Exception) method can be used to do so. The typical use of this method is shown in the following snippet.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">try</span>

{

    <span style="color:green">// code that throws an exception goes here</span>

}

<span style="color:blue">catch</span> (Exception ex)

{

    OnProcessException(ex);

}

</pre>

</div>

<h4><a name="status_property"></a>Status</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">string</span> Status

{

    <span style="color:blue">get</span>

    {

        StringBuilder status = <span style="color:blue">new</span> StringBuilder();



        status.Append(<span style="color:blue">base</span>.Status);

        <span style="color:green">// custom code goes here</span>



        <span style="color:blue">return</span> status.ToString();

    }

}

</pre>

</div>

<p><br>

The Status property can be overridden to provide custom status information specific to your type of adapter.</p>

<h4><a name="datasource_property"></a>DataSource</h4>

<p>DataSource is a collection of database tables stored in memory. This collection is available to all adapters. The tables that are stored in DataSource are defined by the ConfigurationEntity table in the database where SourceName is the name of the table

 in the database and RuntimeName is the name by which the adapter recognizes the table. Typical use of the DataSource is shown in the following example.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:green">// Lookup alternate tag for given measurement key</span>

<span style="color:blue">private</span> <span style="color:blue">string</span> LookupAlternateTag(MeasurementKey key)

{

    <span style="color:blue">try</span>

    {

        DataRow row = DataSource.Tables[<span style="color:#a31515">&quot;ActiveMeasurements&quot;</span>].Select(<span style="color:blue">string</span>.Format(<span style="color:#a31515">&quot;ID = '{0}'&quot;</span>, key.ToString()))[0];

        <span style="color:blue">return</span> row[<span style="color:#a31515">&quot;AlternateTag&quot;</span>].ToString();

    }

    <span style="color:blue">catch</span>

    {

        <span style="color:blue">return</span> <span style="color:#a31515">&quot;undefined&quot;</span>;

    }

}

</pre>

</div>

<h4><a name="getshortstatus_method"></a>GetShortStatus(int)</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">string</span> GetShortStatus(<span style="color:blue">int</span> maxLength)

{

    <span style="color:blue">return</span> <span style="color:#a31515">&quot;Short status&quot;</span>;

}

</pre>

</div>

<p><br>

GetShortStatus(int) is used by the system when listing adapters on the console. When implementing this method, you do not need to make sure your string is shorter than maxLength. Note, however, that the system will truncate the returned string. ActionAdapterBase

 contains an implementation of this method that displays the number of input measurements and the number of output measurements.</p>

<h4><a name="isinputmeasurement_method"></a>IsInputMeasurement(MeasurementKey)</h4>

<p>Users of your adapter have the option of specifying exactly which measurements should be processed by your adapter. If you wish to enforce this constraint in your adapter's implmementation, you can use the IsInputMeasurement(MeasurementKey) method to determine

 whether a given measurement was selected by the user to be processed by the adapter. ActionAdapterBase automatically filters measurements (in QueueMeasurementsForProcessing()) using this method before they are sent to the adapter (in PublishFrame()). Typical

 use of IsInputMeasurement(MeasurementKey) is shown in the following snippet.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre>IMeasurement measurement = getMeasurementFromSomewhere();



<span style="color:blue">if</span>(IsInputMeasurement(measurement.Key))

{

    <span style="color:green">// process measurement</span>

}

</pre>

</div>

<h4><a name="waitforinitialize_method"></a>WaitForInitialize() and WaitForInitialize(int)</h4>

<p>If you feel the need to enter your custom code into the Start() method before calling

<span class="codeInline">base.Start()</span>, then your code will bypass many of the safeguards that were placed in the base class. The WaitForInitialize() method was designed to help solve this problem. If your custom code relies on objects that are initialized

 in your Initialize() method, then you have the option of calling the WaitForInitialize() method manually.<br>

<br>

Additionally, if there is a possibility that your Initialize() method will never finish (for instance, if it throws an exception), then you can specify a timeout (in milliseconds) using the parameter in the WaitForInitialize(int) method. Typical use of WaitForInitialize(int)

 is shown in the following snippet.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Start()

{

    <span style="color:green">// Make sure we are disconnected before attempting a connection</span>

    <span style="color:blue">if</span>(Enabled)

        Stop();



    WaitForInitialize(10000); <span style="color:green">// wait for ten seconds or until Initialize() is finished</span>



    <span style="color:blue">if</span>(!Initialized)

        <span style="color:blue">throw</span> <span style="color:blue">new</span> InvalidOperationException(<span style="color:#a31515">&quot;Timeout to wait for initialization expired.&quot;</span>

                &#43; <span style="color:#a31515">&quot; Start() cannot run before Initialize() is finished.&quot;</span>);



    <span style="color:green">// custom code goes here</span>



    <span style="color:blue">base</span>.Start();

}

</pre>

</div>

<hr>

<h3><a name="input_adapters"></a>Input adapters</h3>

<p>This section will go over methods and properties defined for input adapters that are not defined for all adapter types.</p>

<h4><a name="input_attemptconnection_method"></a>AttemptConnection()</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> AttemptConnection()

{

    <span style="color:green">// code to connect goes here</span>

}

</pre>

</div>

<p><br>

This method is used to attempt a connection to the data input source. Any exceptions thrown by this method will result in restart of the connection cycle.</p>

<h4><a name="input_attemptdisconnection_method"></a>AttemptDisconnection()</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> AttemptDisconnection()

{

    <span style="color:green">// code to disconnect goes here</span>

}

</pre>

</div>

<p><br>

This method is used to attempt to disconnect from the data input source.</p>

<h4><a name="input_useasyncconnect_property"></a>UseAsyncConnect</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">bool</span> UseAsyncConnect

{

    <span style="color:blue">get</span>

    {

        <span style="color:green">// return statement goes here</span>

    }

}

</pre>

</div>

<p><br>

This property is used by the system to determine whether to start processing measurements immediately or to wait for notification that the data input source is connected. If the input adapter can guarantee that the data input source is connected when the AttemptConnection()

 method is completed and also that the data input source is disconnected when the AttemptDisconnection() method is completed, this property should return false. Otherwise, this property should return true and the adapter must call OnConnected() and OnDisconnected()

 when the data input source is connected and disconnected respectively. In most cases, this property should return false.</p>

<h4><a name="input_onnewmeasurements_method"></a>OnNewMeasurements(ICollection&lt;IMeasurement&gt;)</h4>

<p>When the input adapter has received measurements from the data input source, it needs to call this method in order to notify the system and send in the new measurements.</p>

<hr>

<h3><a name="action_adapters"></a>Action adapters</h3>

<p>This section will go over methods and properties defined for action adapters that are not defined for all adapter types.</p>

<h4><a name="action_publishframe_method"></a>PublishFrame(IFrame, int)</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> PublishFrame(IFrame frame, <span style="color:blue">int</span> index)

{

    <span style="color:green">// implementation goes here</span>

}

</pre>

</div>

<p><br>

This method is called when a collection of measurements is ready to be processed. In most cases, this is where your adapter should process the measurements it receives. This method should not take longer than the time it has available to process the measurements

 (which depends on the frames per second). For an example of using TVA.Collections.ProcessQueue in order to process measurements outside of this method, see the

<a href="#processqueue_example">ProcessQueue example</a>.</p>

<h4><a name="action_onnewmeasurements_method"></a>OnNewMeasurements(ICollection&lt;IMeasurement&gt;)</h4>

<p>If the action adapter creates any measurements, it needs to call this method in order to notify the system and send in the new measurements.</p>

<h4><a name="action_queuemeasurementsforprocessing_method"></a>QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt;)</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt; measurements)

{

    List&lt;IMeasurement&gt; inputMeasurements = <span style="color:blue">new</span> List&lt;IMeasurement&gt;();



    <span style="color:green">// custom code goes here</span>



    <span style="color:blue">if</span>(inputMeasurements.Count &gt; 0)

        SortMeasurements(inputMeasurements);

}

</pre>

</div>

<p><br>

In most cases, this method should not be overridden. It should be noted, however, that it can be overridden in order to provide a custom filter for measurements that have entered the system. Any measurement sent to the SortMeasurements() method will be processed

 by the action adapter (assuming the measurements have a valid timestamp). For an example of overriding the QueueMeasurementsForProcessing() method, see the

<a href="#queuemeasurementsforprocessing_example">QueueMeasurementsForProcessing example</a>.</p>

<hr>

<h3><a name="output_adapters"></a>Output adapters</h3>

<p>This section will go over methods and properties defined for output adapters that are not defined for all adapter types.</p>

<h4><a name="output_attemptconnection_method"></a>AttemptConnection()</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> AttemptConnection()

{

    <span style="color:green">// code to connect goes here</span>

}

</pre>

</div>

<p><br>

This method is used to attempt a connection to the data output stream. Any exceptions thrown by this method will result in restart of the connection cycle.</p>

<h4><a name="output_attemptdisconnection_method"></a>AttemptDisconnection()</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> AttemptDisconnection()

{

    <span style="color:green">// code to disconnect goes here</span>

}

</pre>

</div>

<p><br>

This method is used to attempt to disconnect from the data output stream.</p>

<h4><a name="output_outputisforarchive_property"></a>OutputIsForArchive</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">bool</span> OutputIsForArchive

{

    <span style="color:blue">get</span>

    {

        <span style="color:green">// return statement goes here</span>

    }

}

</pre>

</div>

<p><br>

This property should return a flag that determines if measurements sent to the adapter are destined for archival. It allows the OutputAdapterCollection to calculate statistics on how many measurements have been archived per minute. Historians would normally

 set this property to <span class="codeInline">true</span>; other custom exports would set this property to

<span class="codeInline">false</span>.</p>

<h4><a name="output_processmeasurements_method"></a>ProcessMeasurements(IMeasurement[])</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> ProcessMeasurements(IMeasurement[] measurements)

{

    <span style="color:green">// implementation goes here</span>

}

</pre>

</div>

<p><br>

This method is called by the system when there are measurements that are ready to be processed. This is the method in which measurements should be processed by your output adapter.</p>

<h4><a name="output_useasyncconnect_property"></a>UseAsyncConnect</h4>

<div style="color:black; background-color:white">

<pre><span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">bool</span> UseAsyncConnect

{

    <span style="color:blue">get</span>

    {

        <span style="color:green">// return statement goes here</span>

    }

}

</pre>

</div>

<p><br>

This property is used by the system to determine whether to start processing measurements immediately or to wait for notification that the data output source is connected. If the output adapter can guarantee that the data output source is connected when the

 AttemptConnection() method is completed and also that the data output source is disconnected when the AttemptDisconnection() method is completed, this property should return false. Otherwise, this property should return true and the adapter must call OnConnected()

 and OnDisconnected() when the data output source is connected and disconnected respectively. In most cases, this property should return false.</p>

<hr>

<h2><a name="adapter_use"></a>Using your custom adapter</h2>

<p>In order to use the custom adapter you've just created, you must define a record in one of the custom adapter tables in the database. Input, action, and output adapters should be defined in the CustomInputAdapter, CustomActionAdapter, and CustomOutputAdapter

 tables respectively. All three tables have the exactly the same fields which are described below.</p>

<h4><a name="NodeID_field"></a>NodeID</h4>

<p>This field contains a GUID that defines which node will be using the custom adapter. The value should match one of the records in the

<a href="/openPDC/DocumentationManual_Configuration.htm#Node.ID_column">

ID</a> column in the <a href="#Manual%20Configuration%23Node_table">Node</a> table.</p>

<h4><a name="ID_field"></a>ID</h4>

<p>This field contains an integer used to identify each custom adapter. The values are unique and auto-incrementing. There is no need to manually enter a value here.</p>

<h4><a name="AdapterName_field"></a>AdapterName</h4>

<p>This field contains the <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Manual_Configuration.md#Historian.Acronym_column">

Acronym</a> used to identify the adapter. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore (_) is the only special character allowed. You can enter a maximum of 16 characters.</p>

<h4><a name="AssemblyName_field"></a>AssemblyName</h4>

<p>This field contains the name of the dll into which your custom adapter has been compiled. The dll should be located in the

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.md#install_directory">

openPDC installation directory</a>.</p>

<h4><a name="TypeName_field"></a>TypeName</h4>

<p>This field contains the name of the class (including the namespace) of the adapter you wrote.</p>

<h4><a name="ConnectionString_field"></a>ConnectionString</h4>

<p>This field contains the connection string used to set required parameters or to modify default parameters. See the

<a href="#initialize_method">Initialize() method</a> for more details.</p>

<h4><a name="LoadOrder_field"></a>LoadOrder</h4>

<p>This field defines the relative order in which to retrieve records from the database. The order goes from smallest LoadOrder to largest. The values are not required to be unique.</p>

<h4><a name="Enabled_field"></a>Enabled</h4>

<p>This field contains a boolean value indicating whether your custom adapter is enabled to be used or not. The system will not recognize adapters which are not enabled.</p>

<hr>

<h2><a name="other_adapters"></a>Other adapter types</h2>

<h3><a name="facile_action_adapter"></a>Facile action adapter</h3>

<p>The facile action adapter is a very simple action adapter with no built-in measurement concentration capabilities. This requires more work, but also allows you to implement your own concentration algorithms when the built-in concentration supplied by ActionAdapterBase

 does not suit the needs of your custom adapter. This adapter type can also be used when an adapter needs to be placed in the action adapter layer, but does not need to process its own measurements. Like the

<a href="#extend_base_class">previous adapter types</a>, the base class for this adapter is located in TimeSeriesFramework.Adapters namespace.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">using</span> TVA.Measurements.Routing;



<span style="color:blue">public</span> <span style="color:blue">class</span> MyFacileActionAdapter : FacileActionAdapter

{

}

</pre>

</div>

<p><br>

<em>Note: Since there is no built-in concentration, the user must override the <a href="#action_queuemeasurementsforprocessing_method">

QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt;) method</a>, however the SortMeasurements(IEnumerable&lt;IMeasurement&gt;) method does not exist. Measurements must be filtered and processed according to your QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt;)

 method.</em><br>

<br>

In addition to the methods and properties available to <a href="#all_adapters">

all adapter types</a>, the following methods are available to facile action adapters.</p>

<ul>

<li><a href="#action_onnewmeasurements_method">OnNewMeasurements(ICollection&lt;IMeasurement&gt;)</a>

</li><li><a href="#action_queuemeasurementsforprocessing_method">QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt;) method</a>

</li></ul>

<h3><a name="calculated_measurement"></a>Calculated measurement</h3>

<p>The calculated measurement type is an extension of the regular action adapter type. This adapter is typically used when the custom adapter needs to calculate values based on its input measurements and reintroduce the calculated values as measurements back

 into the system. More generally, this adapter type can be used whenever the custom adapter needs to know the

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Manual_Configuration.md#Measurement.SignalTypeID_column">

signal type</a> of its input measurements. The base class for this adapter is located in the TVA.PhasorProtocols namespace. You will need to

<a href="#add_references">add a reference</a> to &quot;TVA.PhasorProtocols.dll&quot; in order to use this adapter type.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">using</span> TVA.PhasorProtocols;



<span style="color:blue">public</span> <span style="color:blue">class</span> MyCalculatedMeasurement : CalculatedMeasurementBase

{

}

</pre>

</div>

<p><br>

In addition to the methods and properties available to <a href="#all_adapters">

all adapter types</a> and <a href="#action_adapters">action adapters</a>, calculated measurements have the following extra properties.</p>

<h4><a name="calculatedmeasurement_inputmeasurementkeytypes_property"></a>InputMeasurementKeyTypes</h4>

<p>Once the input measurements have been defined for this adapter, the InputMeasurementKeyTypes property can be used to access an array of signal types for the input measurements. The index of each signal type matches the index of the corresponding measurement

 key in the array returned by the InputMeasurementKeys property.</p>

<h4><a name="calculatedmeasurement_outputmeasurementtypes_property"></a>OutputMeasurementTypes</h4>

<p>Once the output measurements have been defined for this adapter, the OutputMeasurementTypes property can be used to access an array of signal types for the output measurements. The index of each signal type matches the index of the corresponding output measurement

 in the array returned by the OutputMeasurements property.</p>

<h4><a name="calculatedmeasurement_configurationsection_property"></a>ConfigurationSection</h4>

<p>If the custom adapter has settings that need to be saved in the openPDC configuration file, this property represents the section under which these settings should be placed in the configuration file.</p>

<hr>

<h2><a name="examples"></a>Examples</h2>

<h3><a name="processqueue_example"></a>ProcessQueue example</h3>

<p>This example uses ProcessQueue in order to process the measurements outside of the PublishFrame() method. This is the preferred method of processing measurements if the operation takes longer than the available time given to PublishFrame().<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">class</span> ProcessQueueExample : ActionAdapterBase

{

    <span style="color:green">// Fields</span>

    <span style="color:blue">private</span> ProcessQueue&lt;IFrame&gt; m_processQueue;

    <span style="color:blue">private</span> <span style="color:blue">bool</span> m_disposed;



    <span style="color:green">// Initialize()</span>

    <span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Initialize()

    {

        m_processQueue = ProcessQueue&lt;IFrame&gt;.CreateRealTimeQueue(ProcessFrames);

    }



    <span style="color:green">// Start()</span>

    <span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Start()

    {

        <span style="color:blue">base</span>.Start();

        m_processQueue.Start();

    }



    <span style="color:green">// Stop()</span>

    <span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Stop()

    {

        <span style="color:blue">base</span>.Stop();

        m_processQueue.Stop();

    }



    <span style="color:green">// PublishFrame(IFrame, int)</span>

    <span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> PublishFrame(IFrame frame, <span style="color:blue">int</span> index)

    {

        m_processQueue.Add(frame);

    }



    <span style="color:green">// ProcessFrames(IFrame[])</span>

    <span style="color:blue">protected</span> <span style="color:blue">void</span> ProcessFrames(IFrame[] frames)

    {

        <span style="color:green">// process measurements here</span>

    }



    <span style="color:green">// Dispose(bool)</span>

    <span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Dispose(<span style="color:blue">bool</span> disposing)

    {

        <span style="color:blue">if</span> (!m_disposed)

        {

            <span style="color:blue">try</span>

            {

                <span style="color:blue">if</span> (disposing)

                {

                    <span style="color:blue">if</span> (m_processQueue != <span style="color:blue">null</span>)

                        m_processQueue.Dispose();



                    m_processQueue = <span style="color:blue">null</span>;

                }

            }

            <span style="color:blue">finally</span>

            {

                <span style="color:blue">base</span>.Dispose(disposing);    <span style="color:green">// Call base class Dispose().</span>

                m_disposed = <span style="color:blue">true</span>;          <span style="color:green">// Prevent duplicate dispose.</span>

            }

        }

    }

}

</pre>

</div>

<h3><a name="queuemeasurementsforprocessing_example"></a>QueueMeasurementsForProcessing example</h3>

<p>This example uses QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt;) in order to filter down to the measurements that are timestamped on a specified export interval (in seconds). Note that QueueMeasurementForProcessing(IMeasurement) was also

 overridden to ensure that these measurements do not escape the filter.<br>

<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">public</span> <span style="color:blue">class</span> QueueMeasurementsForProcessingExample : ActionAdapterBase

{

    <span style="color:green">// Fields</span>

    <span style="color:blue">private</span> <span style="color:blue">int</span> m_exportInterval;



    <span style="color:green">// Initialize()</span>

    <span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> Initialize()

    {

        <span style="color:blue">base</span>.Initialize();



        Dictionary&lt;<span style="color:blue">string</span>, <span style="color:blue">string</span>&gt; settings = Settings;

        <span style="color:blue">string</span> setting, dataChannel, commandChannel;



        m_exportInterval = <span style="color:blue">int</span>.Parse(settings[<span style="color:#a31515">&quot;exportInterval&quot;</span>]);

    }



    <span style="color:green">// QueueMeasurementForProcessing(IMeasurement)</span>

    <span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> QueueMeasurementForProcessing(IMeasurement measurement)

    {

        QueueMeasurementsForProcessing(<span style="color:blue">new</span> IMeasurement[] { measurement });

    }



    <span style="color:green">// QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt;)</span>

    <span style="color:blue">public</span> <span style="color:blue">override</span> <span style="color:blue">void</span> QueueMeasurementsForProcessing(IEnumerable&lt;IMeasurement&gt; measurements)

    {

        List&lt;IMeasurement&gt; inputMeasurements = <span style="color:blue">new</span> List&lt;IMeasurement&gt;();

        Ticks timestamp;



        <span style="color:blue">foreach</span> (IMeasurement measurement <span style="color:blue">in</span> measurements)

        {

            timestamp = measurement.Timestamp;



            <span style="color:blue">bool</span> sort = (<span style="color:blue">new</span> DateTime(timestamp)).Second % m_exportInterval == 0 &amp;&amp;

                    timestamp.DistanceBeyondSecond() &lt; TicksPerFrame &amp;&amp;

                    IsInputMeasurement(measurement.Key);



            <span style="color:blue">if</span> (sort)

                inputMeasurements.Add(measurement);

        }



        <span style="color:blue">if</span>(inputMeasurements.Count &gt; 0)

            SortMeasurements(inputMeasurements);

    }



    <span style="color:green">// PublishFrame(IFrame, int)</span>

    <span style="color:blue">protected</span> <span style="color:blue">override</span> <span style="color:blue">void</span> PublishFrame(IFrame frame, <span style="color:blue">int</span> index)

    {

        <span style="color:green">// process measurements here</span>

    }

}

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

Last edited <span class="smartDate" title="6/22/2012 1:23:27 PM" LocalTimeTicks="1340396607">Jun 22, 2012 at 1:23 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/alexfoglia.md">alexfoglia</a>, version 3<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Custom%20Adapter%20%28Developers%29">CodePlex</a> Oct 5, 2015 by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


