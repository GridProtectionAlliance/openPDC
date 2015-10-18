

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Developers About the Code</title>



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

<h1>About the Code</h1>

<p>Below you will find a high level hierarchical overview of the code which provides a summary of solutions, namespaces and classes within the API portions of the openPDC. For more detail about the code you can download the

<a href="http://www.gridsolutions.org/NightlyBuilds/openPDC/Help/">API help</a> which includes standalone compiled help files (.chm) as well as help 2 files that directly

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Getting_Started.md#integrate_help">

integrate within Visual Studio.</a> We have also made our help system available online, here are the primary help links for each of the major solutions:</p>

<ul>

<li><a href="http://tvacodelibrary.codeplex.com/documentation">Framework</a> </li><li><a href="http://www.gridprotectionalliance.org/NightlyBuilds/openHistorian/Help/">Historian</a>

</li><li><a href="http://www.gridprotectionalliance.org/NightlyBuilds/openPDC/Beta/Libraries/Help/">Synchrophasor</a>

</li></ul>

<ul>

<li><a href="#solution_and_namespace_overview">TVA Solution and Namespace Overview</a>

<ul>

<li><a href="#solution_overview">TVA Solution Overview</a> </li><li><a href="#namespace_overview">TVA Code Namespace Overview</a> </li></ul>

</li><li><a href="#hierarchical_overview">TVA Class Hierarchical Overview</a> </li><li><a href="#phasor_protocol_relationship_diagrams">Phasor Protocol Relationship Diagrams</a>

<ul>

<li><a href="#analog_definition_relationships">Analog Definition Relationships</a>

</li><li><a href="#analog_value_relationships">Analog Value Relationships</a> </li><li><a href="#command_cell_collection_relationships">CommandCell Collection Relationships</a>

</li><li><a href="#command_cell_relationships">CommandCell Relationships</a> </li><li><a href="#command_frame_relationships">CommandFrame Relationships</a> </li><li><a href="#configuration_cell_collection_relationships">ConfigurationCell Collection Relationships</a>

</li><li><a href="#configuration_cell_relationships">ConfigurationCell Relationships</a>

</li><li><a href="#configuration_frame_relationships">ConfigurationFrame Relationships</a>

</li><li><a href="#data_cell_collection_relationships">DataCell Collection Relationships</a>

</li><li><a href="#data_cell_relationships">DataCell Relationships</a> </li><li><a href="#data_frame_relationships">DataFrame Relationships</a> </li><li><a href="#digital_definition_relationships">Digital Definition Relationships</a>

</li><li><a href="#digital_value_relationships">Digital Value Relationships</a> </li><li><a href="#frame_parser_relationships">FrameParser Relationships</a> </li><li><a href="#frequency_definition_relationships">Frequency Definition Relationships</a>

</li><li><a href="#frequency_value_relationships">Frequency Value Relationships</a> </li><li><a href="#header_cell_collection_relationship">HeaderCell Collection Relationships</a>

</li><li><a href="#header_cell_relationships">HeaderCell Relationships</a> </li><li><a href="#header_frame_relationships">HeaderFrame Relationships</a> </li><li><a href="#phasor_definition_relationships">Phasor Definition Relationships</a>

</li><li><a href="#phasor_value_relationships">Phasor Value Relationships</a> </li></ul>

</li></ul>

<hr>

<h2><a name="solution_and_namespace_overview"></a>TVA Solution and Namespace Overview</h2>

<p>This section offers brief descriptions of the solutions and namespaces as well as a list of the assemblies associated with them.</p>

<h3><a name="solution_overview"></a>TVA Solution Overview</h3>

<table>

<tbody>

<tr>

<th>Solution </th>

<th>Description </th>

<th>Assemblies </th>

</tr>

<tr>

<td><a href="#Framework_solution">Framework</a></td>

<td>The framework solution contains all code that is foundational to all other code within the openPDC; it is the &quot;code library&quot; that all other solutions and code depend on.</td>

<td>TVA.Core.dll, TVA.Communication.dll, TVA.Windows.dll, TVA.Services.dll</td>

</tr>

<tr>

<td><a href="#Historian_solution">Historian</a></td>

<td>The historian solution contains all code that is used for archiving data within the openPDC; specifically, this is the code that allows the system to perform basic in-process archiving.</td>

<td>TVA.Historian.dll</td>

</tr>

<tr>

<td>Synchrophasor</td>

<td>The synchrophasor solution contains all code related to the primary system executables of the openPDC as well as the phasor protocol parsing and generating library.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<h3><a name="namespace_overview"></a>TVA Code Namespace Overview</h3>

<table>

<tbody>

<tr>

<th>Namespace </th>

<th>Description </th>

<th>Assembly Location </th>

</tr>

<tr>

<td><a href="#TVA_namespace">TVA</a></td>

<td>Contains fundamental classes that define commonly-used value and reference data types, interfaces, and basic type extension functions.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Collections_namespace">TVA.Collections</a></td>

<td>Contains classes and type extension functions related to any fundamental collection, including thread-based processing queues.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Communication_namespace">TVA.Communication</a></td>

<td>Contains high-level classes and components related to any data communications, including sockets, as well as serial- and file-based transports used to simplify and standardize data access.</td>

<td>TVA.Communication.dll</td>

</tr>

<tr>

<td><a href="#TVA.Configuration_namespace">TVA.Configuration</a></td>

<td>Contains classes, base classes, and attributes related to simplifying access to configuration files, including creating a categorized settings section.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Console_namespace">TVA.Console</a></td>

<td>Contains classes used for parsing command line parameters and managing console applications.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Data_namespace">TVA.Data</a></td>

<td>Contains extension functions used to simplify and standardize database access.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Diagnostics_namespace">TVA.Diagnostics</a></td>

<td>Contains classes used to simplify and standardize performance monitoring for applications.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Drawing_namespace">TVA.Drawing</a></td>

<td>Contains extension functions used to simplify managing images.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.ErrorManagement_namespace">TVA.ErrorManagement</a></td>

<td>Contains classes used to simplify and standardize error management for applications.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Historian_namespace">TVA.Historian</a></td>

<td>Contains fundamental classes used by all historian code.</td>

<td>TVA.Historian.dll</td>

</tr>

<tr>

<td><a href="#TVA.Historian.Exporters_namespace">TVA.Historian.Exporters</a></td>

<td>Contains classes used for automating data exports in a variety of formats.</td>

<td>TVA.Historian.dll</td>

</tr>

<tr>

<td><a href="#TVA.Historian.Files_namespace">TVA.Historian.Files</a></td>

<td>Contains classes used for manipulating archive files.</td>

<td>TVA.Historian.dll</td>

</tr>

<tr>

<td><a href="#TVA.Historian.MetadataProviders_namespace">TVA.Historian.MetadataProviders</a></td>

<td>Contains classes that allow the historian to collect its required point metadata definitions from a variety of sources.</td>

<td>TVA.Historian.dll</td>

</tr>

<tr>

<td><a href="#TVA.Historian.Notifiers_namespace">TVA.Historian.Notifiers</a></td>

<td>Contains classes and interfaces that allow standard and custom historian notifications about critical system events.</td>

<td>TVA.Historian.dll</td>

</tr>

<tr>

<td><a href="#TVA.Historian.Packets_namespace">TVA.Historian.Packets</a></td>

<td>Contains classes that define packet definitions used for transmission of data points and metadata.</td>

<td>TVA.Historian.dll</td>

</tr>

<tr>

<td><a href="#TVA.Historian.Services_namespace">TVA.Historian.Services</a></td>

<td>Contains classes that define the fundamental web services for a historian.</td>

<td>TVA.Historian.dll</td>

</tr>

<tr>

<td><a href="#TVA.Identity_namespace">TVA.Identity</a></td>

<td>Contains classes used to simplify and standardize access to information about a domain user retrieved from Active Directory.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Interop_namespace">TVA.Interop</a></td>

<td>Contains classes used to handle interoperability with older legacy applications.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.IO_namespace">TVA.IO</a></td>

<td>Contains classes and extension functions used to simplify and standardize operations related to files and streams.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.IO.Checksums_namespace">TVA.IO.Checksums</a></td>

<td>Contains classes and extension functions used to calculate standard checksums and CRC&rsquo;s.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.IO.Compression_namespace">TVA.IO.Compression</a></td>

<td>Contains classes and extension functions used to simplify and standardize using compression in applications.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Measurements_namespace">TVA.Measurements</a></td>

<td>Contains classes used to abstractly define measured values and to provide mechanisms for concentrating streaming measurements.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Measurements.Routing_namespace">TVA.Measurements.Routing</a></td>

<td>Contains classes that define an adapter interface layer used to route measurements through a cycle of input, sorted actions, and queued output.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Media_namespace">TVA.Media</a></td>

<td>Contains classes used to create and manipulate waveform audio format (WAV) files.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Media.Sound_namespace">TVA.Media.Sound</a></td>

<td>Contains classes used to create dual-tone, multi-frequency sounds and standard touch tones.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Net.Ftp_namespace">TVA.Net.Ftp</a></td>

<td>Contains classes used to create client connections to FTP servers for uploading and downloading files.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Net.Smtp_namespace">TVA.Net.Smtp</a></td>

<td>Contains classes used to simplify and standardize operations related to sending e-mail messages.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.NumericalAnalysis_namespace">TVA.NumericalAnalysis</a></td>

<td>Contains classes and extension functions used to calculate common numerical operations such as curve fits and standard deviations.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Parsing_namespace">TVA.Parsing</a></td>

<td>Contains classes used to simplify, standardize and automate any kind of stream-based parsing operation.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.PhasorProtocols_namespace">TVA.PhasorProtocols</a></td>

<td>Contains fundamental classes and interfaces used by all phasor protocol parsing and generating code.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

<tr>

<td><a href="#TVA.PhasorProtocols.Anonymous_namespace">TVA.PhasorProtocols.Anonymous</a></td>

<td>Contains a generic implementation of phasor classes used to represent phasor data that is not associated with any particular protocol.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

<tr>

<td><a href="#TVA.PhasorProtocols.BpaPdcStream_namespace">TVA.PhasorProtocols.BpaPdcStream</a></td>

<td>Contains an implementation of the phasor classes used to parse or generate a stream of data in the BPA PDCstream format.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

<tr>

<td><a href="#TVA.PhasorProtocols.FNet_namespace">TVA.PhasorProtocols.FNet</a></td>

<td>Contains an implementation of the phasor classes used to parse or generate a stream of data in the F-NET device format.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

<tr>

<td><a href="#TVA.PhasorProtocols.Ieee1344_namespace">TVA.PhasorProtocols.Ieee1344</a></td>

<td>Contains an implementation of the phasor classes used to parse or generate a stream of data in the IEEE 1344-1995 standard format.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

<tr>

<td><a href="#TVA.PhasorProtocols.IeeeC37_118_namespace">TVA.PhasorProtocols.IeeeC37_118</a></td>

<td>Contains an implementation of the phasor classes used to parse or generate a stream of data in the IEEE C37.118-2005 standard format.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

<tr>

<td><a href="#TVA.PhasorProtocols.Macrodyne_namespace">TVA.PhasorProtocols.Macrodyne</a></td>

<td>Contains an implementation of the phasor classes used to parse or generate a stream of data in the Macrodyne PMU device format.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

<tr>

<td><a href="#TVA.PhasorProtocols.SelFastMessage_namespace">TVA.PhasorProtocols.SelFastMessage</a></td>

<td>Contains an implementation of the phasor classes used to parse or generate a stream of data in the SEL Fast Message format used by a variety of SEL devices.</td>

<td>TVA.PhasorProtocols.dll</td>

</tr>

<tr>

<td><a href="#TVA.Reflection_namespace">TVA.Reflection</a></td>

<td>Contains classes and extension functions used to simplify and standardize access to assembly information and attributes in applications.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Scheduling_namespace">TVA.Scheduling</a></td>

<td>Contains classes used to schedule operations using standard UNIX crontab syntax.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Security.Cryptography_namespace">TVA.Security.Cryptography</a></td>

<td>Contains classes and extension functions used to simplify and standardize usage of basic cryptography using a combination of standard and proprietary encryption algorithms to produce decent obfuscations of strings, buffers and streams of data.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Services_namespace">TVA.Services</a></td>

<td>Contains classes used to simplify and standardize development and operation of Windows services that are remotely manageable.</td>

<td>TVA.Services.dll</td>

</tr>

<tr>

<td><a href="#TVA.Threading_namespace">TVA.Threading</a></td>

<td>Contains classes used to define managed threads that can be used for debugging threads by providing automatic tracking, total thread runtime, and the ability to run threads in alternate execution contexts.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td><a href="#TVA.Units_namespace">TVA.Units</a></td>

<td>Contains classes used to simplify and standardize standard unit and SI conversions.</td>

<td>TVA.Core.dll</td>

</tr>

<tr>

<td>TVA.Windows.Forms (<a href="#TVA.Windows.Forms_namespace">TVA.Core</a>, <a href="#TVA.Windows.Forms_namespace2">

TVA.Windows</a>)</td>

<td>Contains classes, extension functions, and forms used to simplify and standardize usage of basic Windows forms.</td>

<td>TVA.Core.dll, TVA.Windows.dll</td>

</tr>

<tr>

<td><a href="#TVA.Xml_namespace">TVA.Xml</a></td>

<td>Contains extension functions used to simplify and standardize usage of standard XML objects.</td>

<td>TVA.Core.dll</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<hr>

<h2><a name="hierarchical_overview"></a>TVA Class Hierarchical Overview</h2>

<ul>

<li><a href="#Framework_solution">Framework</a>

<ul>

<li><a href="#TVA.Communication_project">TVA.Communication</a>

<ul>

<li>TVA

<ul>

<li><a href="#TVA.Communication_namespace">Communication</a>

<ul>

<li><a href="#TVA.Communication.ClientBase_class">ClientBase</a> </li><li><a href="#TVA.Communication.ClientState_enumeration">ClientState</a> </li><li><a href="#TVA.Communication.FileClient_class">FileClient</a> </li><li><a href="#TVA.Communication.IClient_interface">IClient</a> </li><li><a href="#TVA.Communication.IServer_interface">IServer</a> </li><li><a href="#TVA.Communication.Payload_class">Payload</a> </li><li><a href="#TVA.Communication.SerialClient_class">SerialClient</a> </li><li><a href="#TVA.Communication.ServerBase_class">ServerBase</a> </li><li><a href="#TVA.Communication.ServerState_enumeration">ServerState</a> </li><li><a href="#TVA.Communication.TcpClient_class">TcpClient</a> </li><li><a href="#TVA.Communication.TcpServer_class">TcpServer</a> </li><li><a href="#TVA.Communication.Transport_class">Transport</a> </li><li><a href="#TVA.Communication.TransportProtocol_enumeration">TransportProtocol</a>

</li><li><a href="#TVA.Communication.TransportProvider_class">TransportProvider</a> </li><li><a href="#TVA.Communication.TransportStatistics_class">TransportStatistics</a>

</li><li><a href="#TVA.Communication.UdpClient_class">UdpClient</a> </li><li><a href="#TVA.Communication.UdpServer_class">UdpServer</a> </li></ul>

</li></ul>

</li></ul>

</li><li><a href="#TVA.Core_project">TVA.Core</a>

<ul>

<li><a href="#TVA_namespace">TVA</a>

<ul>

<li><a href="#TVA.AdapterLoader_class">AdapterLoader</a> </li><li><a href="#TVA.ApplicationType_enumeration">ApplicationType</a> </li><li><a href="#TVA.BaselineTimeInterval_enumeration">BaselineTimeInterval</a> </li><li><a href="#TVA.BigBinaryValue_class">BigBinaryValue</a> </li><li><a href="#TVA.BigEndianOrder_class">BigEndianOrder</a> </li><li><a href="#TVA.BinaryCodedDecimal_class">BinaryCodedDecimal</a> </li><li><a href="#TVA.BinaryValue_class">BinaryValue</a> </li><li><a href="#TVA.BinaryValueBase_class">BinaryValueBase</a> </li><li><a href="#TVA.BitExtensions_class">BitExtensions</a> </li><li><a href="#TVA.Bits_enumeration">Bits</a> </li><li><a href="#TVA.BitwiseCast_class">BitwiseCast</a> </li><li><a href="#TVA.BufferExtensions_class">BufferExtensions</a> </li><li><a href="#TVA.ByteEncoding_class">ByteEncoding</a> </li><li><a href="#TVA.CharExtensions_class">CharExtensions</a> </li><li><a href="#TVA.Common_class">Common</a> </li><li><a href="#TVA.ComplexNumber_structure">ComplexNumber</a> </li><li><a href="#TVA.CompoundValue_class">CompoundValue</a> </li><li><a href="#TVA.DateTimeExtensions_class">DateTimeExtensions</a> </li><li><a href="#TVA.Endianness_enumeration">Endianness</a> </li><li><a href="#TVA.EndianOrder_class">EndianOrder</a> </li><li><a href="#TVA.EventArgs_class">EventArgs</a> </li><li><a href="#TVA.IdentifiableItem_class">IdentifiableItem</a> </li><li><a href="#TVA.Int24_structure">Int24</a> </li><li><a href="#TVA.IProvideStatus_interface">IProvideStatus</a> </li><li><a href="#TVA.ISupportLifecycle_interface">ISupportLifecycle</a> </li><li><a href="#TVA.LittleBinaryValue_class">LittleBinaryValue</a> </li><li><a href="#TVA.LittleEndianOrder_class">LittleEndianOrder</a> </li><li><a href="#TVA.NativeEndianOrder_class">NativeEndianOrder</a> </li><li><a href="#TVA.NtpTimeTag_class">NtpTimeTag</a> </li><li><a href="#TVA.NumericExtensions_class">NumericExtensions</a> </li><li><a href="#TVA.ObjectState_class">ObjectState</a> </li><li><a href="#TVA.PrecisionTimer_class">PrecisionTimer</a> </li><li><a href="#TVA.ProcessProgress_class">ProcessProgress</a> </li><li><a href="#TVA.ProcessProgressHandler_class">ProcessProgressHandler</a> </li><li><a href="#TVA.Serialization_class">Serialization</a> </li><li><a href="#TVA.StringExtensions_class">StringExtensions</a> </li><li><a href="#TVA.Ticks_structure">Ticks</a> </li><li><a href="#TVA.TimerCapabilities_structure">TimerCapabilities</a> </li><li><a href="#TVA.TimerStartException_class">TimerStartException</a> </li><li><a href="#TVA.TimeTagBase_class">TimeTagBase</a> </li><li><a href="#TVA.TypeExtensions_class">TypeExtensions</a> </li><li><a href="#TVA.UInt24_structure">UInt24</a> </li><li><a href="#TVA.UnixTimeTag_class">UnixTimeTag</a> </li><li><a href="#TVA.USTimeZones_class">USTimeZones</a> </li><li><a href="#TVA.Word_class">Word</a> </li><li><a href="#TVA.Collections_namespace">Collections</a>

<ul>

<li><a href="#TVA.Collections.CollectionExtensions_class">CollectionExtensions</a>

</li><li><a href="#TVA.Collections.DictionaryList_class">DictionaryList</a> </li><li><a href="#TVA.Collections.KeyedProcessQueue_class">KeyedProcessQueue</a> </li><li><a href="#TVA.Collections.ProcessQueue_class">ProcessQueue</a> </li><li><a href="#TVA.Collections.ProcessQueueStatistics_structure">ProcessQueueStatistics</a>

</li><li><a href="#TVA.Collections.QueueProcessingStyle_enumeration">QueueProcessingStyle</a>

</li><li><a href="#TVA.Collections.QueueThreadingMode_enumeration">QueueThreadingMode</a>

</li><li><a href="#TVA.Collections.RequeueMode_enumeration">RequeueMode</a> </li></ul>

</li><li><a href="#TVA.Configuration_namespace">Configuration</a>

<ul>

<li><a href="#TVA.Configuration.AppSettingsBase_class">AppSettingsBase</a> </li><li><a href="#TVA.Configuration.CategorizedSettingsBase_class">CategorizedSettingsBase</a>

</li><li><a href="#TVA.Configuration.CategorizedSettingsElement_class">CategorizedSettingsElement</a>

</li><li><a href="#TVA.Configuration.CategorizedSettingsElementCollection_class">CategorizedSettingsElementCollection</a>

</li><li><a href="#TVA.Configuration.CategorizedSettingsSection_class">CategorizedSettingsSection</a>

</li><li><a href="#TVA.Configuration.ConfigurationFile_class">ConfigurationFile</a> </li><li><a href="#TVA.Configuration.EncryptSettingAttribute_class">EncryptSettingAttribute</a>

</li><li><a href="#TVA.Configuration.IniSettingsBase_class">IniSettingsBase</a> </li><li><a href="#TVA.Configuration.IPersistSettings_interface">IPersistSettings</a>

</li><li><a href="#TVA.Configuration.RegistrySettingsBase_class">RegistrySettingsBase</a>

</li><li><a href="#TVA.Configuration.SerializeSettingAttribute_class">SerializeSettingAttribute</a>

</li><li><a href="#TVA.Configuration.SettingNameAttribute_class">SettingNameAttribute</a>

</li><li><a href="#TVA.Configuration.SettingsBase_class">SettingsBase</a> </li></ul>

</li><li><a href="#TVA.Console_namespace">Console</a>

<ul>

<li><a href="#TVA.Console.Arguments_class">Arguments</a> </li><li><a href="#TVA.Console.Events_class">Events</a> </li></ul>

</li><li><a href="#TVA.Data_namespace">Data</a>

<ul>

<li><a href="#TVA.Data.DataExtensions_class">DataExtensions</a> </li></ul>

</li><li><a href="#TVA.Diagnostics_namespace">Diagnostics</a>

<ul>

<li><a href="#TVA.Diagnostics.PerformanceCounter_class">PerformanceCounter</a> </li><li><a href="#TVA.Diagnostics.PerformanceMonitor_class">PerformanceMonitor</a> </li></ul>

</li><li><a href="#TVA.Drawing_namespace">Drawing</a>

<ul>

<li><a href="#TVA.Drawing.BitmapExtensions_class">BitmapExtensions</a> </li></ul>

</li><li><a href="#TVA.ErrorManagement_namespace">ErrorManagement</a>

<ul>

<li><a href="#TVA.ErrorManagement.ErrorDialog_class">ErrorDialog</a> </li><li><a href="#TVA.ErrorManagement.ErrorLogger_class">ErrorLogger</a> </li><li><a href="#TVA.ErrorManagement.ErrorModule_class">ErrorModule</a> </li><li><a href="#TVA.ErrorManagement.SmtpTraceListener_class">SmtpTraceListener</a>

</li></ul>

</li><li><a href="#TVA.Identity_namespace">Identity</a>

<ul>

<li><a href="#TVA.Identity.UserInfo_class">UserInfo</a> </li></ul>

</li><li><a href="#TVA.Interop_namespace">Interop</a>

<ul>

<li><a href="#TVA.Interop.IniFile_class">IniFile</a> </li><li><a href="#TVA.Interop.VBArrayDescriptor_class">VBArrayDescriptor</a> </li><li><a href="#TVA.Interop.WindowsApi_class">WindowsApi</a> </li></ul>

</li><li><a href="#TVA.IO_namespace">IO</a>

<ul>

<li><a href="#TVA.IO.ExportDestination_class">ExportDestination</a> </li><li><a href="#TVA.IO.FilePath_class">FilePath</a> </li><li><a href="#TVA.IO.IsamDataFileBase_class">IsamDataFileBase</a> </li><li><a href="#TVA.IO.LogFile_class">LogFile</a> </li><li><a href="#TVA.IO.LogFileFullOperation_enumeration">LogFileFullOperation</a>

</li><li><a href="#TVA.IO.MultipleDestinationExporter_class">MultipleDestinationExporter</a>

</li><li><a href="#TVA.IO.StreamExtensions_class">StreamExtensions</a> </li><li><a href="#TVA.IO.Checksums_namespace">Checksums</a>

<ul>

<li><a href="#TVA.IO.Checksums.ChecksumExtensions_class">ChecksumExtensions</a>

</li><li><a href="#TVA.IO.Checksums.ChecksumType_enumeration">ChecksumType</a> </li><li><a href="#TVA.IO.Checksums.Crc16_class">Crc16</a> </li><li><a href="#TVA.IO.Checksums.Crc32_class">Crc32</a> </li><li><a href="#TVA.IO.Checksums.CrcCCITT_class">CrcCCITT</a> </li><li><a href="#TVA.IO.Checksums.Xor16_class">Xor16</a> </li><li><a href="#TVA.IO.Checksums.Xor32_class">Xor32</a> </li><li><a href="#TVA.IO.Checksums.Xor64_class">Xor64</a> </li><li><a href="#TVA.IO.Checksums.Xor8_class">Xor8</a> </li></ul>

</li><li><a href="#TVA.IO.Compression_namespace">Compression</a>

<ul>

<li><a href="#TVA.IO.Compression.CompressionExtensions_class">CompressionExtensions</a>

</li><li><a href="#TVA.IO.Compression.CompressionStrength_enumeration">CompressionStrength</a>

</li><li><a href="#TVA.IO.Compression.FileCompressor_class">FileCompressor</a> </li></ul>

</li></ul>

</li><li><a href="#TVA.Measurements_namespace">Measurements</a>

<ul>

<li><a href="#TVA.Measurements.ConcentratorBase_class">ConcentratorBase</a> </li><li><a href="#TVA.Measurements.Frame_class">Frame</a> </li><li><a href="#TVA.Measurements.FrameQueue_class">FrameQueue</a> </li><li><a href="#TVA.Measurements.IFrame_interface">IFrame</a> </li><li><a href="#TVA.Measurements.IMeasurement_interface">IMeasurement</a> </li><li><a href="#TVA.Measurements.ImmediateMeasurements_class">ImmediateMeasurements</a>

</li><li><a href="#TVA.Measurements.Measurement_class">Measurement</a> </li><li><a href="#TVA.Measurements.MeasurementKey_structure">MeasurementKey</a> </li><li><a href="#TVA.Measurements.TemporalMeasurement_class">TemporalMeasurement</a>

</li><li><a href="#TVA.Measurements.Routing_namespace">Routing</a>

<ul>

<li><a href="#TVA.Measurements.Routing.ActionAdapterBase_class">ActionAdapterBase</a>

</li><li><a href="#TVA.Measurements.Routing.ActionAdapterCollection_class">ActionAdapterCollection</a>

</li><li><a href="#TVA.Measurements.Routing.AdapterBase_class">AdapterBase</a> </li><li><a href="#TVA.Measurements.Routing.AdapterCollectionBase_class">AdapterCollectionBase</a>

</li><li><a href="#TVA.Measurements.Routing.AdapterCommandAttribute_class">AdapterCommandAttribute</a>

</li><li><a href="#TVA.Measurements.Routing.AllAdaptersCollection_class">AllAdaptersCollection</a>

</li><li><a href="#TVA.Measurements.Routing.IActionAdapter_interface">IActionAdapter</a>

</li><li><a href="#TVA.Measurements.Routing.IAdapter_interface">IAdapter</a> </li><li><a href="#TVA.Measurements.Routing.IAdapterCollection_interface">IAdapterCollection</a>

</li><li><a href="#TVA.Measurements.Routing.IInputAdapter_interface">IInputAdapter</a>

</li><li><a href="#TVA.Measurements.Routing.InputAdapterBase_class">InputAdapterBase</a>

</li><li><a href="#TVA.Measurements.Routing.InputAdapterCollection_class">InputAdapterCollection</a>

</li><li><a href="#TVA.Measurements.Routing.IOutputAdapter_interface">IOutputAdapter</a>

</li><li><a href="#TVA.Measurements.Routing.OutputAdapterBase_class">OutputAdapterBase</a>

</li><li><a href="#TVA.Measurements.Routing.OutputAdapterCollection_class">OutputAdapterCollection</a>

</li></ul>

</li></ul>

</li><li><a href="#TVA.Media_namespace">Media</a>

<ul>

<li><a href="#TVA.Media.BitsPerSample_enumeration">BitsPerSample</a> </li><li><a href="#TVA.Media.DataChannels_enumeration">DataChannels</a> </li><li><a href="#TVA.Media.DataFormatSubType_class">DataFormatSubType</a> </li><li><a href="#TVA.Media.RiffChunk_class">RiffChunk</a> </li><li><a href="#TVA.Media.RiffHeaderChunk_class">RiffHeaderChunk</a> </li><li><a href="#TVA.Media.SampleRate_enumeration">SampleRate</a> </li><li><a href="#TVA.Media.Speakers_enumeration">Speakers</a> </li><li><a href="#TVA.Media.WaveDataChunk_class">WaveDataChunk</a> </li><li><a href="#TVA.Media.WaveFile_class">WaveFile</a> </li><li><a href="#TVA.Media.WaveFormat_enumeration">WaveFormat</a> </li><li><a href="#TVA.Media.WaveFormatChunk_class">WaveFormatChunk</a> </li><li><a href="#TVA.Media.WaveFormatExtensible_class">WaveFormatExtensible</a> </li><li><a href="#TVA.Media.Sound_namespace">Sound</a>

<ul>

<li><a href="#TVA.Media.Sound.DTMF_class">DTMF</a> </li><li><a href="#TVA.Media.Sound.TouchTone_class">TouchTone</a> </li><li><a href="#TVA.Media.Sound.TouchToneKey_enumeration">TouchToneKey</a> </li></ul>

</li></ul>

</li><li>Net

<ul>

<li><a href="#TVA.Net.Ftp_namespace">Ftp</a>

<ul>

<li><a href="#TVA.Net.Ftp.FtpAsyncResult_class">FtpAsyncResult</a> </li><li><a href="#TVA.Net.Ftp.FtpAuthenticationException_class">FtpAuthenticationException</a>

</li><li><a href="#TVA.Net.Ftp.FtpClient_class">FtpClient</a> </li><li><a href="#TVA.Net.Ftp.FtpCommandException_class">FtpCommandException</a> </li><li><a href="#TVA.Net.Ftp.FtpControlChannel_class">FtpControlChannel</a> </li><li><a href="#TVA.Net.Ftp.FtpDataStream_class">FtpDataStream</a> </li><li><a href="#TVA.Net.Ftp.FtpDataTransferException_class">FtpDataTransferException</a>

</li><li><a href="#TVA.Net.Ftp.FtpDirectory_class">FtpDirectory</a> </li><li><a href="#TVA.Net.Ftp.FtpExceptionBase_class">FtpExceptionBase</a> </li><li><a href="#TVA.Net.Ftp.FtpFile_class">FtpFile</a> </li><li><a href="#TVA.Net.Ftp.FtpFileNotFoundException_class">FtpFileNotFoundException</a>

</li><li><a href="#TVA.Net.Ftp.FtpFileWatcher_class">FtpFileWatcher</a> </li><li><a href="#TVA.Net.Ftp.FtpInputDataStream_class">FtpInputDataStream</a> </li><li><a href="#TVA.Net.Ftp.FtpInvalidResponseException_class">FtpInvalidResponseException</a>

</li><li><a href="#TVA.Net.Ftp.FtpOutputDataStream_class">FtpOutputDataStream</a> </li><li><a href="#TVA.Net.Ftp.FtpResponse_class">FtpResponse</a> </li><li><a href="#TVA.Net.Ftp.FtpResumeNotSupportedException_class">FtpResumeNotSupportedException</a>

</li><li><a href="#TVA.Net.Ftp.FtpServerDownException_class">FtpServerDownException</a>

</li><li><a href="#TVA.Net.Ftp.FtpUserAbortException_class">FtpUserAbortException</a>

</li><li><a href="#TVA.Net.Ftp.IFtpFile_interface">IFtpFile</a> </li><li><a href="#TVA.Net.Ftp.TransferDirection_enumeration">TransferDirection</a> </li><li><a href="#TVA.Net.Ftp.TransferMode_enumeration">TransferMode</a> </li></ul>

</li><li><a href="#TVA.Net.Smtp_namespace">Smtp</a>

<ul>

<li><a href="#TVA.Net.Smtp.Mail_class">Mail</a> </li></ul>

</li></ul>

</li><li><a href="#TVA.NumericalAnalysis_namespace">NumericalAnalysis</a>

<ul>

<li><a href="#TVA.NumericalAnalysis.CurveFit_class">CurveFit</a> </li><li><a href="#TVA.NumericalAnalysis.NumericalAnalysisExtensions_class">NumericalAnalysisExtensions</a>

</li><li><a href="#TVA.NumericalAnalysis.RealTimeSlope_class">RealTimeSlope</a> </li></ul>

</li><li><a href="#TVA.Parsing_namespace">Parsing</a>

<ul>

<li><a href="#TVA.Parsing.BinaryImageBase_class">BinaryImageBase</a> </li><li><a href="#TVA.Parsing.BinaryImageParserBase_class">BinaryImageParserBase</a>

</li><li><a href="#TVA.Parsing.CommonHeaderBase_class">CommonHeaderBase</a> </li><li><a href="#TVA.Parsing.FrameImageParserBase_class">FrameImageParserBase</a> </li><li><a href="#TVA.Parsing.IBinaryImageParser_interface">IBinaryImageParser</a> </li><li><a href="#TVA.Parsing.ICommonHeader_interface">ICommonHeader</a> </li><li><a href="#TVA.Parsing.IFrameImageParser_interface">IFrameImageParser</a> </li><li><a href="#TVA.Parsing.ISupportBinaryImage_interface">ISupportBinaryImage</a>

</li><li><a href="#TVA.Parsing.ISupportFrameImage_interface">ISupportFrameImage</a> </li><li><a href="#TVA.Parsing.MultiSourceFrameImageParserBase_class">MultiSourceFrameImageParserBase</a>

</li></ul>

</li><li><a href="#TVA.Reflection_namespace">Reflection</a>

<ul>

<li><a href="#TVA.Reflection.AssemblyExtensions_class">AssemblyExtensions</a> </li><li><a href="#TVA.Reflection.AssemblyInfo_class">AssemblyInfo</a> </li><li><a href="#TVA.Reflection.MemberInfoExtensions_class">MemberInfoExtensions</a>

</li></ul>

</li><li><a href="#TVA.Scheduling_namespace">Scheduling</a>

<ul>

<li><a href="#TVA.Scheduling.DateTimePart_enumeration">DateTimePart</a> </li><li><a href="#TVA.Scheduling.Schedule_class">Schedule</a> </li><li><a href="#TVA.Scheduling.ScheduleManager_class">ScheduleManager</a> </li><li><a href="#TVA.Scheduling.SchedulePart_class">SchedulePart</a> </li><li><a href="#TVA.Scheduling.SchedulePartTextSyntax_enumeration">SchedulePartTextSyntax</a>

</li></ul>

</li><li>Security

<ul>

<li><a href="#TVA.Security.Cryptography_namespace">Cryptography</a>

<ul>

<li><a href="#TVA.Security.Cryptography.Cipher_class">Cipher</a> </li><li><a href="#TVA.Security.Cryptography.CipherStrength_enumeration">CipherStrength</a>

</li><li><a href="#TVA.Security.Cryptography.Random_class">Random</a> </li><li><a href="#TVA.Security.Cryptography.SymmetricAlgorithmExtensions_class">SymmetricAlgorithmExtensions</a>

</li></ul>

</li></ul>

</li><li><a href="#TVA.Threading_namespace">Threading</a>

<ul>

<li><a href="#TVA.Threading.ManagedThread_class">ManagedThread</a> </li><li><a href="#TVA.Threading.ManagedThreadPool_class">ManagedThreadPool</a> </li><li><a href="#TVA.Threading.ManagedThreads_class">ManagedThreads</a> </li><li><a href="#TVA.Threading.ThreadStatus_enumeration">ThreadStatus</a> </li><li><a href="#TVA.Threading.ThreadType_enumeration">ThreadType</a> </li></ul>

</li><li><a href="#TVA.Units_namespace">Units</a>

<ul>

<li><a href="#TVA.Units.Angle_structure">Angle</a> </li><li><a href="#TVA.Units.Charge_structure">Charge</a> </li><li><a href="#TVA.Units.Current_structure">Current</a> </li><li><a href="#TVA.Units.Energy_structure">Energy</a> </li><li><a href="#TVA.Units.Length_structure">Length</a> </li><li><a href="#TVA.Units.Mass_structure">Mass</a> </li><li><a href="#TVA.Units.Power_structure">Power</a> </li><li><a href="#TVA.Units.SI_class">SI</a> </li><li><a href="#TVA.Units.SI2_class">SI2</a> </li><li><a href="#TVA.Units.Speed_structure">Speed</a> </li><li><a href="#TVA.Units.Temperature_structure">Temperature</a> </li><li><a href="#TVA.Units.Time_structure">Time</a> </li><li><a href="#TVA.Units.Voltage_structure">Voltage</a> </li><li><a href="#TVA.Units.Volume_structure">Volume</a> </li></ul>

</li><li>Windows

<ul>

<li><a href="#TVA.Windows.Forms_namespace">Forms</a>

<ul>

<li><a href="#TVA.Windows.Forms.FormExtensions_class">FormExtensions</a> </li><li><a href="#TVA.Windows.Forms.ScreenArea_class">ScreenArea</a> </li></ul>

</li></ul>

</li><li><a href="#TVA.Xml_namespace">Xml</a>

<ul>

<li><a href="#TVA.Xml.XmlExtensions_class">XmlExtensions</a> </li></ul>

</li></ul>

</li></ul>

</li><li><a href="#TVA.Services_project">TVA.Services</a>

<ul>

<li>TVA

<ul>

<li><a href="#TVA.Services_namespace">Services</a>

<ul>

<li><a href="#TVA.Services.ClientHelper_class">ClientHelper</a> </li><li><a href="#TVA.Services.ClientInfo_class">ClientInfo</a> </li><li><a href="#TVA.Services.ClientRequest_class">ClientRequest</a> </li><li><a href="#TVA.Services.ClientRequestHandler_class">ClientRequestHandler</a>

</li><li><a href="#TVA.Services.ClientRequestInfo_class">ClientRequestInfo</a> </li><li><a href="#TVA.Services.IdentityToken_enumeration">IdentityToken</a> </li><li><a href="#TVA.Services.ServiceHelper_class">ServiceHelper</a> </li><li><a href="#TVA.Services.ServiceProcess_class">ServiceProcess</a> </li><li><a href="#TVA.Services.ServiceProcessState_enumeration">ServiceProcessState</a>

</li><li><a href="#TVA.Services.ServiceResponse_class">ServiceResponse</a> </li><li><a href="#TVA.Services.ServiceState_enumeration">ServiceState</a> </li></ul>

</li></ul>

</li></ul>

</li><li><a href="#TVA.Windows_project">TVA.Windows</a>

<ul>

<li>TVA

<ul>

<li>Windows

<ul>

<li><a href="#TVA.Windows.Forms_namespace2">Forms</a>

<ul>

<li><a href="#TVA.Windows.Forms.AboutDialog_class">AboutDialog</a> </li><li><a href="#TVA.Windows.Forms.PropertyGridExtensions_class">PropertyGridExtensions</a>

</li></ul>

</li></ul>

</li></ul>

</li></ul>

</li></ul>

</li><li><a href="#historian_solution">Historian</a>

<ul>

<li><a href="#TVA.Historian_project">TVA.Historian</a>

<ul>

<li>TVA

<ul>

<li><a href="#TVA.Historian_namespace">Historian</a>

<ul>

<li><a href="#TVA.Historian.DataListener_class">DataListener</a> </li><li><a href="#TVA.Historian.IArchive_interface">IArchive</a> </li><li><a href="#TVA.Historian.IDataPoint_interface">IDataPoint</a> </li><li><a href="#TVA.Historian.Quality_enumeration">Quality</a> </li><li><a href="#TVA.Historian.TimeTag_class">TimeTag</a> </li><li><a href="#TVA.Historian.Exporters_namespace">Exporters</a>

<ul>

<li><a href="#TVA.Historian.Exporters.CsvExporter_class">CsvExporter</a> </li><li><a href="#TVA.Historian.Exporters.DataMonitorExporter_class">DataMonitorExporter</a>

</li><li><a href="#TVA.Historian.Exporters.Export_class">Export</a> </li><li><a href="#TVA.Historian.Exporters.ExporterBase_class">ExporterBase</a> </li><li><a href="#TVA.Historian.Exporters.ExportProcessResult_enumeration">ExportProcessResult</a>

</li><li><a href="#TVA.Historian.Exporters.ExportRecord_class">ExportRecord</a> </li><li><a href="#TVA.Historian.Exporters.ExportSetting_class">ExportSetting</a> </li><li><a href="#TVA.Historian.Exporters.ExportType_enumeration">ExportType</a> </li><li><a href="#TVA.Historian.Exporters.FileHelper_class">FileHelper</a> </li><li><a href="#TVA.Historian.Exporters.IExporter_interface">IExporter</a> </li><li><a href="#TVA.Historian.Exporters.RawDataExporter_class">RawDataExporter</a>

</li><li><a href="#TVA.Historian.Exporters.RebroadcastExporter_class">RebroadcastExporter</a>

</li><li><a href="#TVA.Historian.Exporters.RollingHistoryExporter_class">RollingHistoryExporter</a>

</li><li><a href="#TVA.Historian.Exporters.StatisticsExporter_class">StatisticsExporter</a>

</li><li><a href="#TVA.Historian.Exporters.XmlExporter_class">XmlExporter</a> </li></ul>

</li><li><a href="#TVA.Historian.Files_namespace">Files</a>

<ul>

<li><a href="#TVA.Historian.Files.ArchiveData_class">ArchiveData</a> </li><li><a href="#TVA.Historian.Files.ArchiveDataBlock_class">ArchiveDataBlock</a> </li><li><a href="#TVA.Historian.Files.ArchiveDataBlockPointer_class">ArchiveDataBlockPointer</a>

</li><li><a href="#TVA.Historian.Files.ArchiveFile_class">ArchiveFile</a> </li><li><a href="#TVA.Historian.Files.ArchiveFileAllocationTable_class">ArchiveFileAllocationTable</a>

</li><li><a href="#TVA.Historian.Files.ArchiveFileStatistics_class">ArchiveFileStatistics</a>

</li><li><a href="#TVA.Historian.Files.ArchiveFileType_enumeration">ArchiveFileType</a>

</li><li><a href="#TVA.Historian.Files.DataType_enumeration">DataType</a> </li><li><a href="#TVA.Historian.Files.IntercomFile_class">IntercomFile</a> </li><li><a href="#TVA.Historian.Files.IntercomRecord_class">IntercomRecord</a> </li><li><a href="#TVA.Historian.Files.MetadataFile_class">MetadataFile</a> </li><li><a href="#TVA.Historian.Files.MetadataRecord_class">MetadataRecord</a> </li><li><a href="#TVA.Historian.Files.MetadataRecordAlarmFlags_class">MetadataRecordAlarmFlags</a>

</li><li><a href="#TVA.Historian.Files.MetadataRecordAnalogFields_class">MetadataRecordAnalogFields</a>

</li><li><a href="#TVA.Historian.Files.MetadataRecordComposedFields_class">MetadataRecordComposedFields</a>

</li><li><a href="#TVA.Historian.Files.MetadataRecordConstantFields_class">MetadataRecordConstantFields</a>

</li><li><a href="#TVA.Historian.Files.MetadataRecordDigitalFields_class">MetadataRecordDigitalFields</a>

</li><li><a href="#TVA.Historian.Files.MetadataRecordGeneralFlags_class">MetadataRecordGeneralFlags</a>

</li><li><a href="#TVA.Historian.Files.MetadataRecordSecurityFlags_class">MetadataRecordSecurityFlags</a>

</li><li><a href="#TVA.Historian.Files.MetadataRecordSummary_class">MetadataRecordSummary</a>

</li><li><a href="#TVA.Historian.Files.StateFile_class">StateFile</a> </li><li><a href="#TVA.Historian.Files.StateRecord_class">StateRecord</a> </li><li><a href="#TVA.Historian.Files.StateRecordData_class">StateRecordData</a> </li><li><a href="#TVA.Historian.Files.StateRecordSummary_class">StateRecordSummary</a>

</li></ul>

</li><li><a href="#TVA.Historian.MetadataProviders_namespace">MetadataProviders</a>

<ul>

<li><a href="#TVA.Historian.MetadataProviders.AdoMetadataProvider_class">AdoMetadataProvider</a>

</li><li><a href="#TVA.Historian.MetadataProviders.IMetadataProvider_interface">IMetadataProvider</a>

</li><li><a href="#TVA.Historian.MetadataProviders.MetadataProviderBase_class">MetadataProviderBase</a>

</li><li><a href="#TVA.Historian.MetadataProviders.MetadataProviders_class">MetadataProviders</a>

</li><li><a href="#TVA.Historian.MetadataProviders.MetadataUpdater_class">MetadataUpdater</a>

</li><li><a href="#TVA.Historian.MetadataProviders.OleDbMetadataProvider_class">OleDbMetadataProvider</a>

</li><li><a href="#TVA.Historian.MetadataProviders.RestWebServiceMetadataProvider_class">RestWebServiceMetadataProvider</a>

</li></ul>

</li><li><a href="#TVA.Historian.Notifiers_namespace">Notifiers</a>

<ul>

<li><a href="#TVA.Historian.Notifiers.EmailNotifier_class">EmailNotifier</a> </li><li><a href="#TVA.Historian.Notifiers.INotifier_interface">INotifier</a> </li><li><a href="#TVA.Historian.Notifiers.NotificationTypes_enumeration">NotificationTypes</a>

</li><li><a href="#TVA.Historian.Notifiers.NotifierBase_class">NotifierBase</a> </li><li><a href="#TVA.Historian.Notifiers.Notifiers_class">Notifiers</a> </li></ul>

</li><li><a href="#TVA.Historian.Packets_namespace">Packets</a>

<ul>

<li><a href="#TVA.Historian.Packets.IPacket_interface">IPacket</a> </li><li><a href="#TVA.Historian.Packets.PacketBase_class">PacketBase</a> </li><li><a href="#TVA.Historian.Packets.PacketCommonHeader_class">PacketCommonHeader</a>

</li><li><a href="#TVA.Historian.Packets.PacketParser_class">PacketParser</a> </li><li><a href="#TVA.Historian.Packets.PacketType1_class">PacketType1</a> </li><li><a href="#TVA.Historian.Packets.PacketType101_class">PacketType101</a> </li><li><a href="#TVA.Historian.Packets.PacketType101Data_class">PacketType101Data</a>

</li><li><a href="#TVA.Historian.Packets.PacketType11_class">PacketType11</a> </li><li><a href="#TVA.Historian.Packets.PacketType2_class">PacketType2</a> </li><li><a href="#TVA.Historian.Packets.PacketType3_class">PacketType3</a> </li><li><a href="#TVA.Historian.Packets.PacketType4_class">PacketType4</a> </li><li><a href="#TVA.Historian.Packets.PacketType5_class">PacketType5</a> </li><li><a href="#TVA.Historian.Packets.QueryPacketBase_class">QueryPacketBase</a> </li></ul>

</li><li><a href="#TVA.Historian.Services_namespace">Services</a>

<ul>

<li><a href="#TVA.Historian.Services.DataFlowDirection_enumeration">DataFlowDirection</a>

</li><li><a href="#TVA.Historian.Services.IMetadataService_interface">IMetadataService</a>

</li><li><a href="#TVA.Historian.Services.IService_interface">IService</a> </li><li><a href="#TVA.Historian.Services.ITimeSeriesDataService_interface">ITimeSeriesDataService</a>

</li><li><a href="#TVA.Historian.Services.MetadataService_class">MetadataService</a>

</li><li><a href="#TVA.Historian.Services.SerializableMetadata_class">SerializableMetadata</a>

</li><li><a href="#TVA.Historian.Services.SerializableMetadataRecord_class">SerializableMetadataRecord</a>

</li><li><a href="#TVA.Historian.Services.SerializableTimeSeriesData_class">SerializableTimeSeriesData</a>

</li><li><a href="#TVA.Historian.Services.SerializableTimeSeriesDataPoint_class">SerializableTimeSeriesDataPoint</a>

</li><li><a href="#TVA.Historian.Services.Serialization_class">Serialization</a> </li><li><a href="#TVA.Historian.Services.SerializationFormat_enumeration">SerializationFormat</a>

</li><li><a href="#TVA.Historian.Services.Service_class">Service</a> </li><li><a href="#TVA.Historian.Services.Services_class">Services</a> </li><li><a href="#TVA.Historian.Services.TimeSeriesDataService_class">TimeSeriesDataService</a>

</li></ul>

</li></ul>

</li></ul>

</li></ul>

</li></ul>

</li><li><a href="#Synchrophasor_solution">Synchrophasor</a>

<ul>

<li><a href="#TVA.PhasorProtocols_project">TVA.PhasorProtocols</a>

<ul>

<li>TVA

<ul>

<li><a href="#TVA.PhasorProtocols_namespace">PhasorProtocols</a>

<ul>

<li><a href="#TVA.PhasorProtocols.AnalogDefinitionBase_class">AnalogDefinitionBase</a>

</li><li><a href="#TVA.PhasorProtocols.AnalogDefinitionCollection_class">AnalogDefinitionCollection</a>

</li><li><a href="#TVA.PhasorProtocols.AnalogType_enumeration">AnalogType</a> </li><li><a href="#TVA.PhasorProtocols.AnalogValueBase_class">AnalogValueBase</a> </li><li><a href="#TVA.PhasorProtocols.AnalogValueCollection_class">AnalogValueCollection</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelBase_class">ChannelBase</a> </li><li><a href="#TVA.PhasorProtocols.ChannelCellBase_class">ChannelCellBase</a> </li><li><a href="#TVA.PhasorProtocols.ChannelCellCollectionBase_class">ChannelCellCollectionBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelCellParsingStateBase_class">ChannelCellParsingStateBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelCollectionBase_class">ChannelCellCollectionBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelDefinitionBase_class">ChannelDefinitionBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelDefinitionCollectionBase_class">ChannelDefinitionCollectionBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelFrameBase_class">ChannelFrameBase</a> </li><li><a href="#TVA.PhasorProtocols.ChannelFrameCollectionBase_class">ChannelFrameCollectionBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelFrameParsingStateBase_class">ChannelFrameParsingStateBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelParsingStateBase_class">ChannelParsingStateBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelValueBase_class">ChannelValueBase</a> </li><li><a href="#TVA.PhasorProtocols.ChannelValueCollectionBase_class">ChannelValueCollectionBase</a>

</li><li><a href="#TVA.PhasorProtocols.ChannelValueMeasurement_class">ChannelValueMeasurement</a>

</li><li><a href="#TVA.PhasorProtocols.CommandCell_class">CommandCell</a> </li><li><a href="#TVA.PhasorProtocols.CommandCellCollection_class">CommandCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.CommandFrameBase_class">CommandFrameBase</a> </li><li><a href="#TVA.PhasorProtocols.CommandFrameParsingState_class">CommandFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.Common_class">Common</a> </li><li><a href="#TVA.PhasorProtocols.CommonStatusFlags_enumeration">CommonStatusFlags</a>

</li><li><a href="#TVA.PhasorProtocols.CompositeFrequencyValue_enumeration">CompositeFrequencyValue</a>

</li><li><a href="#TVA.PhasorProtocols.CompositePhasorValue_enumeration">CompositePhasorValue</a>

</li><li><a href="#TVA.PhasorProtocols.ConfigurationCellBase_class">ConfigurationCellBase</a>

</li><li><a href="#TVA.PhasorProtocols.ConfigurationCellCollection_class">ConfigurationCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.ConfigurationCellParsingState_class">ConfigurationCellParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.ConfigurationFrameBase_class">ConfigurationFrameBase</a>

</li><li><a href="#TVA.PhasorProtocols.ConfigurationFrameCollection_class">ConfigurationFrameCollection</a>

</li><li><a href="#TVA.PhasorProtocols.ConfigurationFrameParsingState_class">ConfigurationFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.ConnectionParametersBase_class">ConnectionParametersBase</a>

</li><li><a href="#TVA.PhasorProtocols.CoordinateFormat_enumeration">CoordinateFormat</a>

</li><li><a href="#TVA.PhasorProtocols.DataCellBase_class">DataCellBase</a> </li><li><a href="#TVA.PhasorProtocols.DataCellCollection_class">DataCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.DataCellParsingState_class">DataCellParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.DataFormat_enumeration">DataFormat</a> </li><li><a href="#TVA.PhasorProtocols.DataFrameBase_class">DataFrameBase</a> </li><li><a href="#TVA.PhasorProtocols.DataFrameCollection_class">DataFrameCollection</a>

</li><li><a href="#TVA.PhasorProtocols.DataFrameParsingState_class">DataFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.DataSortingType_enumeration">DataSortingType</a>

</li><li><a href="#TVA.PhasorProtocols.DeviceCommand_enumeration">DeviceCommand</a> </li><li><a href="#TVA.PhasorProtocols.DigitalDefinitionBase_class">DigitalDefinitionBase</a>

</li><li><a href="#TVA.PhasorProtocols.DigitalDefinitionCollection_class">DigitalDefinitionCollection</a>

</li><li><a href="#TVA.PhasorProtocols.DigitalValueBase_class">DigitalValueBase</a> </li><li><a href="#TVA.PhasorProtocols.DigitalValueCollection_class">DigitalValueCollection</a>

</li><li><a href="#TVA.PhasorProtocols.FrameParserBase_class">FrameParserBase</a> </li><li><a href="#TVA.PhasorProtocols.FrequencyDefinitionBase_class">FrequencyDefinitionBase</a>

</li><li><a href="#TVA.PhasorProtocols.FrequencyDefinitionCollection_class">FrequencyDefinitionCollection</a>

</li><li><a href="#TVA.PhasorProtocols.FrequencyValueBase_class">FrequencyValueBase</a>

</li><li><a href="#TVA.PhasorProtocols.FrequencyValueCollection_class">FrequencyValueCollection</a>

</li><li><a href="#TVA.PhasorProtocols.FundamentalFrameType_enumeration">FundamentalFrameType</a>

</li><li><a href="#TVA.PhasorProtocols.HeaderCell_class">HeaderCell</a> </li><li><a href="#TVA.PhasorProtocols.HeaderCellCollection_class">HeaderCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.HeaderFrameBase_class">HeaderFrameBase</a> </li><li><a href="#TVA.PhasorProtocols.HeaderFrameParsingState_class">HeaderFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IAnalogDefinition_interface">IAnalogDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IAnalogValue_interface">IAnalogValue</a> </li><li><a href="#TVA.PhasorProtocols.IChannel_interface">IChannel</a> </li><li><a href="#TVA.PhasorProtocols.IChannelCell_interface">IChannelCell</a> </li><li><a href="#TVA.PhasorProtocols.IChannelCellCollection_interface">IChannelCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.IChannelCellParsingState_interface">IChannelCellParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IChannelCollection_interface">IChannelCollection</a>

</li><li><a href="#TVA.PhasorProtocols.IChannelDefinition_interface">IChannelDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IChannelFrame_interface">IChannelFrame</a> </li><li><a href="#TVA.PhasorProtocols.IChannelFrameParsingState_interface">IChannelFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IChannelParsingState_interface">IChannelParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IChannelValue_interface">IChannelValue</a> </li><li><a href="#TVA.PhasorProtocols.ICommandCell_interface">ICommandCell</a> </li><li><a href="#TVA.PhasorProtocols.ICommandFrame_interface">ICommandFrame</a> </li><li><a href="#TVA.PhasorProtocols.ICommandFrameParsingState_interface">ICommandFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IConfigurationCell_interface">IConfigurationCell</a>

</li><li><a href="#TVA.PhasorProtocols.IConfigurationCellParsingState_interface">IConfigurationCellParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">IConfigurationFrame</a>

</li><li><a href="#TVA.PhasorProtocols.IConfigurationFrameParsingState_interface">IConfigurationFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IConnectionParameters_interface">IConnectionParameters</a>

</li><li><a href="#TVA.PhasorProtocols.IDataCell_interface">IDataCell</a> </li><li><a href="#TVA.PhasorProtocols.IDataCellParsingState_interface">IDataCellParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IDataFrame_interface">IDataFrame</a> </li><li><a href="#TVA.PhasorProtocols.IDataFrameParsingState_interface">IDataFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IDigitalDefinition_interface">IDigitalDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IDigitalValue_interface">IDigitalValue</a> </li><li><a href="#TVA.PhasorProtocols.IFrameParser_interface">IFrameParser</a> </li><li><a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">IFrequencyDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IFrequencyValue%20_interface">IFrequencyValue</a>

</li><li><a href="#TVA.PhasorProtocols.IHeaderCell_interface">IHeaderCell</a> </li><li><a href="#TVA.PhasorProtocols.IHeaderFrame_interface">IHeaderFrame</a> </li><li><a href="#TVA.PhasorProtocols.IHeaderFrameParsingState_interface">IHeaderFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.IPhasorDefinition_interface">IPhasorDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IPhasorValue_interface">IPhasorValue</a> </li><li><a href="#TVA.PhasorProtocols.LineFrequency_enumeration">LineFrequency</a> </li><li><a href="#TVA.PhasorProtocols.MultiProtocolFrameParser_class">MultiProtocolFrameParser</a>

</li><li><a href="#TVA.PhasorProtocols.PhasorDataConcentratorBase_class">PhasorDataConcentratorBase</a>

</li><li><a href="#TVA.PhasorProtocols.PhasorDefinitionBase_class">PhasorDefinitionBase</a>

</li><li><a href="#TVA.PhasorProtocols.PhasorDefinitionCollection_class">PhasorDefinitionCollection</a>

</li><li><a href="#TVA.PhasorProtocols.PhasorMeasurementMapper_class">PhasorMeasurementMapper</a>

</li><li><a href="#TVA.PhasorProtocols.PhasorProtocol_enumeration">PhasorProtocol</a>

</li><li><a href="#TVA.PhasorProtocols.PhasorType_enumeration">PhasorType</a> </li><li><a href="#TVA.PhasorProtocols.PhasorValueBase_class">PhasorValueBase</a> </li><li><a href="#TVA.PhasorProtocols.PhasorValueCollection_class">PhasorValueCollection</a>

</li><li><a href="#TVA.PhasorProtocols.SignalReference_structure">SignalReference</a>

</li><li><a href="#TVA.PhasorProtocols.SignalReferenceMeasurement_class">SignalReferenceMeasurement</a>

</li><li><a href="#TVA.PhasorProtocols.SignalType_enumeration">SignalType</a> </li><li><a href="#TVA.PhasorProtocols.Anonymous_namespace">Anonymous</a>

<ul>

<li><a href="#TVA.PhasorProtocols.Anonymous.AnalogDefinition_class">AnalogDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Anonymous.ConfigurationCell_class">ConfigurationCell</a>

</li><li><a href="#TVA.PhasorProtocols.Anonymous.ConfigurationCellCollection_class">ConfigurationCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.Anonymous.ConfigurationFrame_class">ConfigurationFrame</a>

</li><li><a href="#TVA.PhasorProtocols.Anonymous.DigitalDefinition_class">DigitalDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Anonymous.FrequencyDefinition_class">FrequencyDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Anonymous.PhasorDefinition_class">PhasorDefinition</a>

</li></ul>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream_namespace">BpaPdcStream</a>

<ul>

<li><a href="#TVA.PhasorProtocols.BpaPdcStream.AnalogDefinition_class">AnalogDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.AnalogValue_class">AnalogValue</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.ChannelFlags_enumeration">ChannelFlags</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.Common_class">Common</a> </li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.CommonFrameHeader_class">CommonFrameHeader</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.ConfigurationCell_class">ConfigurationCell</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.ConfigurationCellCollection_class">ConfigurationCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.ConfigurationFrame_class">ConfigurationFrame</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.ConfigurationFrameParsingState_class">ConfigurationFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.ConnectionParameters_class">ConnectionParameters</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.DataCell_class">DataCell</a> </li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.DataCellCollection_class">DataCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.DataFrame_class">DataFrame</a> </li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.DataFrameParsingState_class">DataFrameParsingState</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.DigitalDefinition_class">DigitalDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.DigitalValue_class">DigitalValue</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.FormatFlags_enumeration">FormatFlags</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.FrameParser_class">FrameParser</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.FrameType_enumeration">FrameType</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.FrequencyDefinition_class">FrequencyDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.FrequencyValue_class">FrequencyValue</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.IniFileNameEditor_class">IniFileNameEditor</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.PhasorDefinition_class">PhasorDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.PhasorValue_class">PhasorValue</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.PMUStatusFlags_enumeration">PMUStatusFlags</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.ReservedFlags_enumeration">ReservedFlags</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.RevisionNumber_enumeration">RevisionNumber</a>

</li><li><a href="#TVA.PhasorProtocols.BpaPdcStream.StreamType_enumeration">StreamType</a>

</li></ul>

</li><li><a href="#TVA.PhasorProtocols.FNet_namespace">FNet</a>

<ul>

<li><a href="#TVA.PhasorProtocols.FNet.Common_class">Common</a> </li><li><a href="#TVA.PhasorProtocols.FNet.CommonFrameHeader_class">CommonFrameHeader</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.ConfigurationCell_class">ConfigurationCell</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.ConfigurationCellCollection_class">ConfigurationCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.ConfigurationFrame_class">ConfigurationFrame</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.ConnectionParameters_class">ConnectionParameters</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.DataCell_class">DataCell</a> </li><li><a href="#TVA.PhasorProtocols.FNet.DataCellCollection_class">DataCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.DataFrame_class">DataFrame</a> </li><li><a href="#TVA.PhasorProtocols.FNet.FrameParser_class">FrameParser</a> </li><li><a href="#TVA.PhasorProtocols.FNet.FrequencyDefinition_class">FrequencyDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.FrequencyValue_class">FrequencyValue</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.PhasorDefinition_class">PhasorDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.FNet.PhasorValue_class">PhasorValue</a> </li></ul>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344_namespace">Ieee1344</a>

<ul>

<li><a href="#TVA.PhasorProtocols.Ieee1344.CommandFrame_class">CommandFrame</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.Common_class">Common</a> </li><li><a href="#TVA.PhasorProtocols.Ieee1344.CommonFrameHeader_class">CommonFrameHeader</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.ConfigurationCell_class">ConfigurationCell</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.ConfigurationCellCollection_class">ConfigurationCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.ConfigurationFrame_class">ConfigurationFrame</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.DataCell_class">DataCell</a> </li><li><a href="#TVA.PhasorProtocols.Ieee1344.DataCellCollection_class">DataCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.DataFrame_class">DataFrame</a> </li><li><a href="#TVA.PhasorProtocols.Ieee1344.DigitalDefinition_class">DigitalDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.DigitalValue_class">DigitalValue</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.FrameImageCollector_class">FrameImageCollector</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.FrameParser_class">FrameParser</a> </li><li><a href="#TVA.PhasorProtocols.Ieee1344.FrameType_enumeration">FrameType</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.FrequencyDefinition_class">FrequencyDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.FrequencyValue_class">FrequencyValue</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.HeaderFrame_class">HeaderFrame</a> </li><li><a href="#TVA.PhasorProtocols.Ieee1344.PhasorDefinition_class">PhasorDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Ieee1344.PhasorValue_class">PhasorValue</a> </li><li><a href="#TVA.PhasorProtocols.Ieee1344.TriggerStatus_enumeration">TriggerStatus</a>

</li></ul>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118_namespace">IeeeC37_118</a>

<ul>

<li><a href="#TVA.PhasorProtocols.IeeeC37_118.AnalogDefinition_class">AnalogDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.AnalogValue_class">AnalogValue</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.CommandFrame_class">CommandFrame</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.Common_class">Common</a> </li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.CommonFrameHeader_class">CommonFrameHeader</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.Concentrator_class">Concentrator</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.ConfigurationCell_class">ConfigurationCell</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.ConfigurationCellCollection_class">ConfigurationCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.ConfigurationFrame1_class">ConfigurationFrame1</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.ConfigurationFrame1Draft6_class">ConfigurationFrame1Draft6</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.ConfigurationFrame2_class">ConfigurationFrame2</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.ConfigurationFrame2Draft6_class">ConfigurationFrame2Draft6</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.DataCell_class">DataCell</a> </li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.DataCellCollection_class">DataCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.DataFrame_class">DataFrame</a> </li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.DigitalDefinition_class">DigitalDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.DigitalValue_class">DigitalValue</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.DraftRevision_enumeration">DraftRevision</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.FormatFlags_enumeration">FormatFlags</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.FrameParser_class">FrameParser</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.FrameType_enumeration">FrameType</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.FrequencyDefinition_class">FrequencyDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.FrequencyValue_class">FrequencyValue</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.HeaderFrame_class">HeaderFrame</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.PhasorDefinition_class">PhasorDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.PhasorValue_class">PhasorValue</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.StatusFlags_enumeration">StatusFlags</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.TimeQualityFlags_enumeration">TimeQualityFlags</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.TimeQualityIndicatorCode_enumeration">TimeQualityIndicatorCode</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.TriggerReason_enumeration">TriggerReason</a>

</li><li><a href="#TVA.PhasorProtocols.IeeeC37_118.UnlockedTime_enumeration">UnlockedTime</a>

</li></ul>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne_namespace">Macrodyne</a>

<ul>

<li><a href="#TVA.PhasorProtocols.Macrodyne.ClockStatusFlags_enumeration">ClockStatusFlags</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.CommandFrame_class">CommandFrame</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.Common_class">Common</a> </li><li><a href="#TVA.PhasorProtocols.Macrodyne.CommonFrameHeader_class">CommonFrameHeader</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.ConfigurationCell_class">ConfigurationCell</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.ConfigurationCellCollection_class">ConfigurationCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.ConfigurationFrame_class">ConfigurationFrame</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.DataCell_class">DataCell</a> </li><li><a href="#TVA.PhasorProtocols.Macrodyne.DataCellCollection_class">DataCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.DataFrame_class">DataFrame</a> </li><li><a href="#TVA.PhasorProtocols.Macrodyne.DataInputCommand_enumeration">DataInputCommand</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.DeviceCommand_enumeration">DeviceCommand</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.DevicePort_enumeration">DevicePort</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.DigitalDefinition_class">DigitalDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.DigitalValue_class">DigitalValue</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.FrameParser_class">FrameParser</a> </li><li><a href="#TVA.PhasorProtocols.Macrodyne.FrequencyDefinition_class">FrequencyDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.FrequencyValue_class">FrequencyValue</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.GpsStatus_enumeration">GpsStatus</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.OnlineDataFormatFlags_enumeration">OnlineDataFormatFlags</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.OperationalLimitFlags_enumeration">OperationalLimitFlags</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.PhasorDefinition_class">PhasorDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.PhasorValue_class">PhasorValue</a> </li><li><a href="#TVA.PhasorProtocols.Macrodyne.StatusFlags_enumeration">StatusFlags</a>

</li><li><a href="#TVA.PhasorProtocols.Macrodyne.TriggerReason_enumeration">TriggerReason</a>

</li></ul>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage_namespace">SelFastMessage</a>

<ul>

<li><a href="#TVA.PhasorProtocols.SelFastMessage.CommandFrame_class">CommandFrame</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.Common_class">Common</a> </li><li><a href="#TVA.PhasorProtocols.SelFastMessage.CommonFrameHeader_class">CommonFrameHeader</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.ConfigurationCell_class">ConfigurationCell</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.ConfigurationCellCollection_class">ConfigurationCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.ConfigurationFrame_class">ConfigurationFrame</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.ConnectionParameters_class">ConnectionParameters</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.DataCell_class">DataCell</a> </li><li><a href="#TVA.PhasorProtocols.SelFastMessage.DataCellCollection_class">DataCellCollection</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.DataFrame_class">DataFrame</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.DeviceCommand_enumeration">DeviceCommand</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.FrameParser_class">FrameParser</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.FrameSize_enumeration">FrameSize</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.FrequencyDefinition_class">FrequencyDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.FrequencyValue_class">FrequencyValue</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.MessagePeriod_enumeration">MessagePeriod</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.PhasorDefinition_class">PhasorDefinition</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.PhasorValue_class">PhasorValue</a>

</li><li><a href="#TVA.PhasorProtocols.SelFastMessage.StatusFlags_enumeration">StatusFlags</a>

</li></ul>

</li></ul>

</li></ul>

</li></ul>

</li></ul>

</li></ul>

<hr>

<h2><a name="Framework_solution"></a>Framework</h2>

<p>The framework solution contains all code that is foundational to all other code within the openPDC; it is the &quot;code library&quot; that all other solutions and code depend on.<br>

<br>

TVA.Core.dll, TVA.Communications.dll, TVA.Windows.dll, TVA.Services.dll</p>

<h3><a name="TVA.Communication_project"></a>TVA.Communication</h3>

<p>This assembly contains high-level classes and components related to any data communications, including sockets, as well as serial- and file-based transports used to simplify and standardize data access.<br>

<br>

TVA.Communication.dll</p>

<h4><a name="TVA.Communication_namespace"></a>TVA.Communication</h4>

<p>Contains high-level classes and components related to any data communications, including sockets, as well as serial- and file-based transports used to simplify and standardize data access.<br>

<br>

<a name="TVA.Communication.ClientBase_class"></a><strong>ClientBase</strong><br>

Base class for a client involved in server-client communication.<br>

<br>

<a name="TVA.Communication.ClientState_enumeration"></a><strong>ClientState</strong><br>

Indicates the current state of the client.<br>

<br>

<a name="TVA.Communication.FileClient_class"></a><strong>FileClient</strong><br>

Represents a communication client based on FileStream.<br>

<br>

<a name="TVA.Communication.IClient_interface"></a><strong>IClient</strong><br>

Defines a client involved in server-client communication.<br>

<br>

<a name="TVA.Communication.IServer_interface"></a><strong>IServer</strong><br>

Defines a server involved in server-client communication.<br>

<br>

<a name="TVA.Communication.Payload_class"></a><strong>Payload</strong><br>

A helper class containing methods for manipulation of payload.<br>

<br>

<a name="TVA.Communication.SerialClient_class"></a><strong>SerialClient</strong><br>

Represents a communication client based on SerialPort.<br>

<br>

<a name="TVA.Communication.ServerBase_class"></a><strong>ServerBase</strong><br>

Base class for a server involved in server-client communication.<br>

<br>

<a name="TVA.Communication.ServerState_enumeration"></a><strong>ServerState</strong><br>

Indicates the current state of the server.<br>

<br>

<a name="TVA.Communication.TcpClient_class"></a><strong>TcpClient</strong><br>

Represents a TCP-based communication client.<br>

<br>

<a name="TVA.Communication.TcpServer_class"></a><strong>TcpServer</strong><br>

Represents a TCP-based communication server.<br>

<br>

<a name="TVA.Communication.Transport_class"></a><strong>Transport</strong><br>

A helper class containing methods related to server-client communication.<br>

<br>

<a name="TVA.Communication.TransportProtocol_enumeration"></a><strong>TransportProtocol</strong><br>

Indicates the protocol used in server-client communication.<br>

<br>

<a name="TVA.Communication.TransportProvider_class"></a><strong>TransportProvider</strong><br>

A class for managing the communication between server and client.<br>

<br>

<a name="TVA.Communication.TransportStatistics_class"></a><strong>TransportStatistics</strong><br>

A class for statistics related to server-client communication.<br>

<br>

<a name="TVA.Communication.UdpClient_class"></a><strong>UdpClient</strong><br>

Represents a UDP-based communication server.<br>

<br>

<a name="TVA.Communication.UdpServer_class"></a><strong>UdpServer</strong><br>

Represents a UDP-based communication server.</p>

<hr>

<h3><a name="TVA.Core_project"></a>TVA.Core</h3>

<p>This assembly contains fundamental classes that define commonly-used value and reference data types, interfaces, and basic type extension functions.<br>

<br>

TVA.Core.dll</p>

<h4><a name="TVA_namespace"></a>TVA</h4>

<p>Contains fundamental classes that define commonly-used value and reference data types, interfaces, and basic type extension functions.<br>

<br>

<a name="TVA.AdapterLoader_class"></a><strong>AdapterLoader</strong><br>

Represents a generic loader of adapters.<br>

<br>

<a name="TVA.ApplicationType_enumeration"></a><strong>ApplicationType</strong><br>

Specifies the type of the application.<br>

<br>

<a name="TVA.BaselineTimeInterval_enumeration"></a><strong>BaselineTimeInterval</strong><br>

Time intervals enumeration used by BaselinedTimestamp(BaselineTimeInterval) method.<br>

<br>

<a name="TVA.BigBinaryValue_class"></a><strong>BigBinaryValue</strong><br>

Represents a big-endian ordered binary data sample stored as a byte array, but implicitly castable to most common native types.<br>

<br>

<a name="TVA.BigEndianOrder_class"></a><strong>BigEndianOrder</strong><br>

Represents a big-endian byte order interoperability class.<br>

<br>

<a name="TVA.BinaryCodedDecimal_class"></a><strong>BinaryCodedDecimal</strong><br>

Defines functions related to binary-coded decimals.<br>

<br>

<a name="TVA.BinaryValue_class"></a><strong>BinaryValue</strong><br>

Represents a binary data sample stored as a byte array ordered in the endianness of the OS, but implicitly castable to most common native types.<br>

<br>

<a name="TVA.BinaryValueBase_class"></a><strong>BinaryValueBase</strong><br>

Represents the base class for a binary data sample stored as a byte array, but implicitly castable to most common native types.<br>

<br>

<a name="TVA.BitExtensions_class"></a><strong>BitExtensions</strong><br>

Defines extension methods related to bit operations.<br>

<br>

<a name="TVA.Bits_enumeration"></a><strong>Bits</strong><br>

Represents bits in a signed or unsigned integer value.<br>

<br>

<a name="TVA.BitwiseCast_class"></a><strong>BitwiseCast</strong><br>

Defines specialized bitwise integer data type conversion functions.<br>

<br>

<a name="TVA.BufferExtensions_class"></a><strong>BufferExtensions</strong><br>

Defines extension functions related to buffer manipulation.<br>

<br>

<a name="TVA.ByteEncoding_class"></a><strong>ByteEncoding</strong><br>

Defines a set of methods used to convert byte buffers to and from user presentable data formats.<br>

<br>

<a name="TVA.CharExtensions_class"></a><strong>CharExtensions</strong><br>

Defines extension functions related to character manipulation.<br>

<br>

<a name="TVA.Common_class"></a><strong>Common</strong><br>

Defines common global functions.<br>

<br>

<a name="TVA.ComplexNumber_structure"></a><strong>ComplexNumber</strong><br>

Represents a complex number.<br>

<br>

<a name="TVA.CompoundValue_class"></a><strong>CompoundValue</strong><br>

Represents a collection of individual values that together represent a compound value once all the values have been assigned.<br>

<br>

<a name="TVA.DateTimeExtensions_class"></a><strong>DateTimeExtensions</strong><br>

Defines extension functions related to Date/Time manipulation.<br>

<br>

<a name="TVA.Endianness_enumeration"></a><strong>Endianness</strong><br>

Endian Byte Order Enumeration<br>

<br>

<a name="TVA.EndianOrder_class"></a><strong>EndianOrder</strong><br>

Represents an endian byte order interoperability class.<br>

<br>

<a name="TVA.EventArgs_class"></a><strong>EventArgs</strong><br>

Represents a generic event arguments class with one data argument.<br>

<br>

<a name="TVA.IdentifiableItem_class"></a><strong>IdentifiableItem</strong><br>

Represents an identifiable item.<br>

<br>

<a name="TVA.Int24_structure"></a><strong>Int24</strong><br>

Represents a 3-byte, 24-bit signed integer.<br>

<br>

<a name="TVA.IProvideStatus_interface"></a><strong>IProvideStatus</strong><br>

Defines an interface for any object to allow it to provide a name and status that can be displayed for informational purposes.<br>

<br>

<a name="TVA.ISupportLifecycle_interface"></a><strong>ISupportLifecycle</strong><br>

Specifies that this object provides support for performing tasks during the key stages of object lifecycle.<br>

<br>

<a name="TVA.LittleBinaryValue_class"></a><strong>LittleBinaryValue</strong><br>

Represents a little-endian ordered binary data sample stored as a byte array, but implicitly castable to most common native types.<br>

<br>

<a name="TVA.LittleEndianOrder_class"></a><strong>LittleEndianOrder</strong><br>

Represents a little-endian byte order interoperability class.<br>

<br>

<a name="TVA.NativeEndianOrder_class"></a><strong>NativeEndianOrder</strong><br>

Represents a native-endian byte order interoperability class.<br>

<br>

<a name="TVA.NtpTimeTag_class"></a><strong>NtpTimeTag</strong><br>

Represents a standard Network Time Protocol (NTP) timetag.<br>

<br>

<a name="TVA.NumericExtensions_class"></a><strong>NumericExtensions</strong><br>

Defines extension functions related to numbers.<br>

<br>

<a name="TVA.ObjectState_class"></a><strong>ObjectState</strong><br>

A serializable class that can be used to track the current and previous state of an object.<br>

<br>

<a name="TVA.PrecisionTimer_class"></a><strong>PrecisionTimer</strong><br>

Represents a high-resolution timer and timestamp class. <br>

<br>

<a name="TVA.ProcessProgress_class"></a><strong>ProcessProgress</strong><br>

Represents current process progress for an operation.<br>

<br>

<a name="TVA.ProcessProgressHandler_class"></a><strong>ProcessProgressHandler</strong><br>

Defines a delegate handler for a <a href="#TVA.ProcessProgress_class">TVA.ProcessProgress</a> instance.<br>

<br>

<a name="TVA.Serialization_class"></a><strong>Serialization</strong><br>

Common serialization related functions.<br>

<br>

<a name="TVA.StringExtensions_class"></a><strong>StringExtensions</strong><br>

Defines extension functions related to string manipulation.<br>

<br>

<a name="TVA.Ticks_structure"></a><strong>Ticks</strong><br>

Represents an instant in time, or time period, as a 64-bit signed integer with a value that is expressed as the number of 100-nanosecond intervals that have elapsed since 12:00:00 midnight, January 1, 0001.<br>

<br>

<a name="TVA.TimerCapabilities_structure"></a><strong>TimerCapabilities</strong><br>

Represents information about the system's multimedia timer capabilities.<br>

<br>

<a name="TVA.TimerStartException_class"></a><strong>TimerStartException</strong><br>

Represents an exception that is thrown when a <a href="#TVA.PrecisionTimer_class">

PrecisionTimer</a> fails to start.<br>

<br>

<a name="TVA.TimeTagBase_class"></a><strong>TimeTagBase</strong><br>

Represents tha base class for alternate timetag implementations.<br>

<br>

<a name="TVA.TypeExtensions_class"></a><strong>TypeExtensions</strong><br>

Extensions to all Type objects.<br>

<br>

<a name="TVA.UInt24_structure"></a><strong>UInt24</strong><br>

Represents a 3-byte, 24-bit unsigned integer.<br>

<br>

<a name="TVA.UnixTimeTag_class"></a><strong>UnixTimeTag</strong><br>

Represents a standard Unix timetag.<br>

<br>

<a name="TVA.USTimeZones_class"></a><strong>USTimeZones</strong><br>

Defines a few common United States time zones.<br>

<br>

<a name="TVA.Word_class"></a><strong>Word</strong><br>

Represents functions and extensions related to 16-bit words, 32-bit double-words and 64-bit quad-words.</p>

<hr>

<h4><a name="TVA.Collections_namespace"></a>TVA.Collections</h4>

<p>Contains classes and type extension functions related to any fundamental collection, including thread-based processing queues.<br>

<br>

<a name="TVA.Collections.CollectionExtensions_class"></a><strong>CollectionExtensions</strong><br>

Defines extension functions related to manipulation of arrays and collections.<br>

<br>

<a name="TVA.Collections.DictionaryList_class"></a><strong>DictionaryList</strong><br>

Represents a sorted dictionary style list that supports IList.<br>

<br>

<a name="TVA.Collections.KeyedProcessQueue_class"></a><strong>KeyedProcessQueue</strong><br>

Represents a keyed collection of items that get processed on independent threads with a consumer provided function.<br>

<br>

<a name="TVA.Collections.ProcessQueue_class"></a><strong>ProcessQueue</strong><br>

Represents a collection of items that get processed on independent threads with a consumer provided function.<br>

<br>

<a name="TVA.Collections.ProcessQueueStatistics_structure"></a><strong>ProcessQueueStatistics</strong><br>

Represents the statistics of a <a href="#TVA.Collections.ProcessQueue_class">ProcessQueue</a>.<br>

<br>

<a name="TVA.Collections.QueueProcessingStyle_enumeration"></a><strong>QueueProcessingStyle</strong><br>

Enumeration of possible <a href="#TVA.Collections.ProcessQueue_class">ProcessQueue</a> processing styles.<br>

<br>

<a name="TVA.Collections.QueueThreadingMode_enumeration"></a><strong>QueueThreadingMode</strong><br>

Enumeration of possible <a href="#TVA.Collections.ProcessQueue_class">ProcessQueue</a> threading modes.<br>

<br>

<a name="TVA.Collections.RequeueMode_enumeration"></a><strong>RequeueMode</strong><br>

Enumeration of possible requeue modes.</p>

<hr>

<h4><a name="TVA.Configuration_namespace"></a>TVA.Configuration</h4>

<p>Contains classes, base classes and attributes related to simplifying access to configuration files including creating a categorized settings section.<br>

<br>

<a name="TVA.Configuration.AppSettingsBase_class"></a><strong>AppSettingsBase</strong><br>

Represents the base class for application settings that are synchronized with the &quot;appSettings&quot; section in a configuration file.<br>

<br>

<a name="TVA.Configuration.CategorizedSettingsBase_class"></a><strong>CategorizedSettingsBase</strong><br>

Represents the base class for application settings that are synchronized with a categorized section in a configuration file.<br>

<br>

<a name="TVA.Configuration.CategorizedSettingsElement_class"></a><strong>CategorizedSettingsElement</strong><br>

Represents a settings entry in the config file.<br>

<br>

<a name="TVA.Configuration.CategorizedSettingsElementCollection_class"></a><strong>CategorizedSettingsElementCollection</strong><br>

Represents a collection of <a href="#TVA.Configuration.CategorizedSettingsElement_class">

CategorizedSettingsElement</a> objects.<br>

<br>

<a name="TVA.Configuration.CategorizedSettingsSection_class"></a><strong>CategorizedSettingsSection</strong><br>

Represents a section in the config file with one or more <a href="#TVA.Configuration.CategorizedSettingsElementCollection_class">

CategorizedSettingsElementCollection</a> representing categories, each containing one or more

<a href="#TVA.Configuration.CategorizedSettingsElement_class">CategorizedSettingsElement</a> objects representing settings under a specific category.<br>

<br>

<a name="TVA.Configuration.ConfigurationFile_class"></a><strong>ConfigurationFile</strong><br>

Represents a configuration file of a Windows or Web application.<br>

<br>

<a name="TVA.Configuration.EncryptSettingAttribute_class"></a><strong>EncryptSettingAttribute</strong><br>

Represents an attribute that determines if a property or field in a class derived from

<a href="#TVA.Configuration.CategorizedSettingsBase_class">CategorizedSettingsBase</a> or

<a href="#TVA.Configuration.AppSettingsBase_class">AppSettingsBase</a> should be encrypted when it is serialized to the configuration file.<br>

<br>

<a name="TVA.Configuration.IniSettingsBase_class"></a><strong>IniSettingsBase</strong><br>

Represents the base class for application settings that are synchronized to an INI file.<br>

<br>

<a name="TVA.Configuration.IPersistSettings_interface"></a><strong>IPersistSettings</strong><br>

Defines as interface that specifies that this object can persists settings to a config file.<br>

<br>

<a name="TVA.Configuration.RegistrySettingsBase_class"></a><strong>RegistrySettingsBase</strong><br>

Represents the base class for application settings that are synchronized to the registry.<br>

<br>

<a name="TVA.Configuration.SerializeSettingAttribute_class"></a><strong>SerializeSettingAttribute</strong><br>

Represents an attribute that determines if a property or field in a class derived from

<a href="#TVA.Configuration.CategorizedSettingsBase_class">CategorizedSettingsBase</a> or

<a href="#TVA.Configuration.AppSettingsBase_class">AppSettingsBase</a> should be serialized to the configuration file.<br>

<br>

<a name="TVA.Configuration.SettingNameAttribute_class"></a><strong>SettingNameAttribute</strong><br>

Represents an attribute that defines the setting name of a property or field in a class derived from

<a href="#TVA.Configuration.CategorizedSettingsBase_class">CategorizedSettingsBase</a> or

<a href="#TVA.Configuration.AppSettingsBase_class">AppSettingsBase</a> when serializing the value to the configuration file.<br>

<br>

<a name="TVA.Configuration.SettingsBase_class"></a><strong>SettingsBase</strong><br>

Represents the base class for application settings that are synchronized with its configuration file.</p>

<hr>

<h4><a name="TVA.Console_namespace"></a>TVA.Console</h4>

<p>Contains classes used for parsing command line parameters and managing console applications.<br>

<br>

<a name="TVA.Console.Arguments_class"></a><strong>Arguments</strong><br>

Represents an ordered set of arguments along with optional arguments parsed from a command-line.<br>

<br>

<a name="TVA.Console.Events_class"></a><strong>Events</strong><br>

Defines a set of consumable events that can be raised by a console application.</p>

<hr>

<h4><a name="TVA.Data_namespace"></a>TVA.Data</h4>

<p>Contains extension functions used to simplify and standardize database access.<br>

<br>

<a name="TVA.Data.DataExtensions_class"></a><strong>DataExtensions</strong><br>

Defines extension functions related to database and SQL interaction.</p>

<hr>

<h4><a name="TVA.Diagnostics_namespace"></a>TVA.Diagnostics</h4>

<p>Contains classes used to simplify and standardize performance monitoring for applications.<br>

<br>

<a name="TVA.Diagnostics.PerformanceCounter_class"></a><strong>PerformanceCounter</strong><br>

Represents an extension of the basic System.Diagnostics.PerformanceCounter providing additional statistical logic.<br>

<br>

<a name="TVA.Diagnostics.PerformanceMonitor_class"></a><strong>PerformanceMonitor</strong><br>

Represents a process performance monitor that operates similar to the Windows Performance Monitor utility that can be used to monitor system performance.</p>

<hr>

<h4><a name="TVA.Drawing_namespace"></a>TVA.Drawing</h4>

<p>Contains extension functions used to simplify managing images.<br>

<br>

<a name="TVA.Drawing.BitmapExtensions_class"></a><strong>BitmapExtensions</strong><br>

Defines extension functions related to bitmap image manipulation.</p>

<hr>

<h4><a name="TVA.ErrorManagement_namespace"></a>TVA.ErrorManagement</h4>

<p>Contains classes used to simplify and standardize error management for applications.<br>

<br>

<a name="TVA.ErrorManagement.ErrorDialog_class"></a><strong>ErrorDialog</strong><br>

Represents a dialog box that can be used to display detailed exception inmormation.<br>

<br>

<a name="TVA.ErrorManagement.ErrorLogger_class"></a><strong>ErrorLogger</strong><br>

Represents a logger that can be used for logging handled as well as unhandled exceptions across multiple application types (Windows Application, Console Application, Windows Service, Web Application, Web Service).<br>

<br>

<a name="TVA.ErrorManagement.ErrorModule_class"></a><strong>ErrorModule</strong><br>

Represents an HTTP module that can be used to handle exceptions globally in Web Sites and Web Services.<br>

<br>

<a name="TVA.ErrorManagement.SmtpTraceListener_class"></a><strong>SmtpTraceListener</strong><br>

Represents an e-mail based TraceListener.</p>

<hr>

<h4><a name="TVA.Identity_namespace"></a>TVA.Identity</h4>

<p>Contains classes used to simplify and standardize access to information about a domain user retrieved from Active Directory.<br>

<br>

<a name="TVA.Identity.UserInfo_class"></a><strong>UserInfo</strong><br>

Represents information about a domain user retrieved from Active Directory.</p>

<hr>

<h4><a name="TVA.Interop_namespace"></a>TVA.Interop</h4>

<p>Contains classes used to handle interoperability with older legacy applications.<br>

<br>

<a name="TVA.Interop.IniFile_class"></a><strong>IniFile</strong><br>

Represents a Windows INI style configuration file.<br>

<br>

<a name="TVA.Interop.VBArrayDescriptor_class"></a><strong>VBArrayDescriptor</strong><br>

Represents an old style Visual Basic array descriptor.<br>

<br>

<a name="TVA.Interop.WindowsApi_class"></a><strong>WindowsApi</strong><br>

Defines common Windows API functions.</p>

<hr>

<h4><a name="TVA.IO_namespace"></a>TVA.IO</h4>

<p>Contains classes and extension functions used to simplify and standardize operations related to files and streams.<br>

<br>

<a name="TVA.IO.ExportDestination_class"></a><strong>ExportDestination</strong><br>

Represents a destination location when exporting data using <a href="#TVA.IO.MultipleDestinationExporter_class">

MultipleDestinationExporter</a>.<br>

<br>

<a name="TVA.IO.FilePath_class"></a><strong>FilePath</strong><br>

Contains File and Path manipulation methods.<br>

<br>

<a name="TVA.IO.IsamDataFileBase_class"></a><strong>IsamDataFileBase</strong><br>

An abstract class that defines the read/write capabilities for ISAM (Indexed Sequential Access Method) file.<br>

<br>

<a name="TVA.IO.LogFile_class"></a><strong>LogFile</strong><br>

Represents a file that can be used for logging messages in real-time.<br>

<br>

<a name="TVA.IO.LogFileFullOperation_enumeration"></a><strong>LogFileFullOperation</strong><br>

Specifies the operation to be performed on the <a href="#TVA.IO.LogFile_class">

LogFile</a> when it is full.<br>

<br>

<a name="TVA.IO.MultipleDestinationExporter_class"></a><strong>MultipleDestinationExporter</strong><br>

Handles the exporting of a file to multiple destinations that are defined in the config file.<br>

<br>

<a name="TVA.IO.StreamExtensions_class"></a><strong>StreamExtensions</strong><br>

Defines extension functions related to Stream manipulation.</p>

<hr>

<h4><a name="TVA.IO.Checksums_namespace"></a>TVA.Checksums</h4>

<p>Contains classes and extension functions used to calculate standard checksums and CRC&rsquo;s.<br>

<br>

<a name="TVA.IO.Checksums.ChecksumExtensions_class"></a><strong>ChecksumExtensions</strong><br>

Defines extension functions related to computing checksums.<br>

<br>

<a name="TVA.IO.Checksums.ChecksumType_enumeration"></a><strong>ChecksumType</strong><br>

Indicates type of CRC-16 calculation performed.<br>

<br>

<a name="TVA.IO.Checksums.Crc16_class"></a><strong>Crc16</strong><br>

Generates a byte-wise 16-bit CRC calculation.<br>

<br>

<a name="TVA.IO.Checksums.Crc32_class"></a><strong>Crc32</strong><br>

Generates a byte-wise 32-bit CRC calculation.<br>

<br>

<a name="TVA.IO.Checksums.CrcCCITT_class"></a><strong>CrcCCITT</strong><br>

Generates a 16-bit CRC-CCITT checksum.<br>

<br>

<a name="TVA.IO.Checksums.Xor16_class"></a><strong>Xor16</strong><br>

Calculates word length (16-bit) XOR-based check-sum on specified portion of a buffer.<br>

<br>

<a name="TVA.IO.Checksums.Xor32_class"></a><strong>Xor32</strong><br>

Calculates double-word length (32-bit) XOR-based check-sum on specified portion of a buffer.<br>

<br>

<a name="TVA.IO.Checksums.Xor64_class"></a><strong>Xor64</strong><br>

Calculates quad-word length (64-bit) XOR-based check-sum on specified portion of a buffer.<br>

<br>

<a name="TVA.IO.Checksums.Xor8_class"></a><strong>Xor8</strong><br>

Calculates byte length (8-bit) XOR-based check-sum on specified portion of a buffer.</p>

<hr>

<h4><a name="TVA.IO.Compression_namespace"></a>TVA.Compression</h4>

<p>Contains classes and extension functions used to simplify and standardize using compression in applications.<br>

<br>

<a name="TVA.IO.Compression.CompressionExtensions_class"></a><strong>CompressionExtensions</strong><br>

Defines extension functions related to compression.<br>

<br>

<a name="TVA.IO.Compression.CompressionStrength_enumeration"></a><strong>CompressionStrength</strong><br>

Level of compression enumeration.<br>

<br>

<a name="TVA.IO.Compression.FileCompressor_class"></a><strong>FileCompressor</strong><br>

Performs basic compression and decompression on a file.</p>

<hr>

<h4><a name="TVA.Measurements_namespace"></a>TVA.Measurements</h4>

<p>Contains classes used to abstractly define measured values and provide mechanisms for concentrating streaming measurements.<br>

<br>

<a name="TVA.Measurements.ConcentratorBase_class"></a><strong>ConcentratorBase</strong><br>

Measurement concentrator base class.<br>

<br>

<a name="TVA.Measurements.Frame_class"></a><strong>Frame</strong><br>

Implementation of a basic <a href="#TVA.Measurements.IFrame_interface">IFrame</a>.<br>

<br>

<a name="TVA.Measurements.FrameQueue_class"></a><strong>FrameQueue</strong><br>

Represents a real-time queue of <a href="#TVA.Measurements.IFrame_interface">IFrame</a> instances used by the

<a href="#TVA.Measurements.ConcentratorBase_class">ConcentratorBase</a> class.<br>

<br>

<a name="TVA.Measurements.IFrame_interface"></a><strong>IFrame</strong><br>

Abstract frame interface representing a collection of measurements at an exact moment in time.<br>

<br>

<a name="TVA.Measurements.IMeasurement_interface"></a><strong>IMeasurement</strong><br>

Represents an interface for an abstract measurement value measured by a device at an extact time.<br>

<br>

<a name="TVA.Measurements.ImmediateMeasurements_class"></a><strong>ImmediateMeasurements</strong><br>

Represents the absolute latest measurement values received by a <a href="#TVA.Measurements.ConcentratorBase_class">

ConcentratorBase</a> implementation.<br>

<br>

<a name="TVA.Measurements.Measurement_class"></a><strong>Measurement</strong><br>

Implementation of a basic measurement.<br>

<br>

<a name="TVA.Measurements.MeasurementKey_structure"></a><strong>MeasurementKey</strong><br>

Represents a primary key for a measurement.<br>

<br>

<a name="TVA.Measurements.TemporalMeasurement_class"></a><strong>TemporalMeasurement</strong><br>

Represents a time constrained measured value.</p>

<hr>

<h4><a name="TVA.Measurements.Routing_namespace"></a>TVA.Measurements.Routing</h4>

<p>Contains classes that define an adapter interface layer used to route measurements through a cycle of input, sorted actions and queued output.<br>

<br>

<a name="TVA.Measurements.Routing.ActionAdapterBase_class"></a><strong>ActionAdapterBase</strong><br>

Represents the base class for action adapters.<br>

<br>

<a name="TVA.Measurements.Routing.ActionAdapterCollection_class"></a><strong>ActionAdapterCollection</strong><br>

Represents a collection of <a href="#TVA.Measurements.Routing.IActionAdapter_interface">

IActionAdapter</a> implementations.<br>

<br>

<a name="TVA.Measurements.Routing.AdapterBase_class"></a><strong>AdapterBase</strong><br>

Represents the base class for any adapter.<br>

<br>

<a name="TVA.Measurements.Routing.AdapterCollectionBase_class"></a><strong>AdapterCollectionBase</strong><br>

Represents a collection of <a href="#TVA.Measurements.Routing.IAdapter_interface">

IAdapter</a> implementations.<br>

<br>

<a name="TVA.Measurements.Routing.AdapterCommandAttribute_class"></a><strong>AdapterCommandAttribute</strong><br>

Represents an attribute that allows a method in an <a href="#TVA.Measurements.Routing.IAdapter_interface">

IAdapter</a> class to be exposed as an invokable command.<br>

<br>

<a name="TVA.Measurements.Routing.AllAdaptersCollection_class"></a><strong>AllAdaptersCollection</strong><br>

Represents a collection of all <a href="#TVA.Measurements.Routing.IAdapterCollection_interface">

IAdapterCollection</a> implementations (i.e., a collection of <a href="#TVA.Measurements.Routing.IAdapterCollection_interface">

IAdapterCollection</a>'s).<br>

<br>

<a name="TVA.Measurements.Routing.IActionAdapter_interface"></a><strong>IActionAdapter</strong><br>

Represents thet abstract interface for any action adapter.<br>

<br>

<a name="TVA.Measurements.Routing.IAdapter_interface"></a><strong>IAdapter</strong><br>

Represents the abstract interface for any adapter.<br>

<br>

<a name="TVA.Measurements.Routing.IAdapterCollection_interface"></a><strong>IAdapterCollection</strong><br>

Represents the abstract interface for a collection of adapters.<br>

<br>

<a name="TVA.Measurements.Routing.IInputAdapter_interface"></a><strong>IInputAdapter</strong><br>

Represents the abstract interface for any incoming adapter.<br>

<br>

<a name="TVA.Measurements.Routing.InputAdapterBase_class"></a><strong>InputAdapterBase</strong><br>

Represents the base class for any incoming input adapter.<br>

<br>

<a name="TVA.Measurements.Routing.InputAdapterCollection_class"></a><strong>InputAdapterCollection</strong><br>

Represents a collection of <a href="#TVA.Measurements.Routing.IInputAdapter_interface">

IInputAdapter</a> implementations.<br>

<br>

<a name="TVA.Measurements.Routing.IOutputAdapter_interface"></a><strong>IOutputAdapter</strong><br>

Represents that abstract interface for any outgoing adapter.<br>

<br>

<a name="TVA.Measurements.Routing.OutputAdapterBase_class"></a><strong>OutputAdapterBase</strong><br>

Represents that base class for any outgoing data stream.<br>

<br>

<a name="TVA.Measurements.Routing.OutputAdapterCollection_class"></a><strong>OutputAdapterCollection</strong><br>

Represents a collection of <a href="#TVA.Measurements.Routing.IOutputAdapter_interface">

IOutputAdapter</a> implementations.</p>

<hr>

<h4><a name="TVA.Media_namespace"></a>TVA.Media</h4>

<p>Contains classes used to create and manipulate waveform audio format (WAV) files.<br>

<br>

<a name="TVA.Media.BitsPerSample_enumeration"></a><strong>BitsPerSample</strong><br>

Typical bit sizes supported by wave files.<br>

<br>

<a name="TVA.Media.DataChannels_enumeration"></a><strong>DataChannels</strong><br>

Typical number of data channels used by wave files.<br>

<br>

<a name="TVA.Media.DataFormatSubType_class"></a><strong>DataFormatSubType</strong><br>

Common sub-type GUID's for SubFormat property.<br>

<br>

<a name="TVA.Media.RiffChunk_class"></a><strong>RiffChunk</strong><br>

Represents the type ID and size for a &quot;chunk&quot; in a RIFF media format file.<br>

<br>

<a name="TVA.Media.RiffHeaderChunk_class"></a><strong>RiffHeaderChunk</strong><br>

Represents the header chunk in a RIFF media format file.<br>

<br>

<a name="TVA.Media.SampleRate_enumeration"></a><strong>SampleRate</strong><br>

Typical samples rates supported by wave files.<br>

<br>

<a name="TVA.Media.Speakers_enumeration"></a><strong>Speakers</strong><br>

Spatial positioning flags for ChannelMask property.<br>

<br>

<a name="TVA.Media.WaveDataChunk_class"></a><strong>WaveDataChunk</strong><br>

Represents the data chunk in a WAVE media format file.<br>

<br>

<a name="TVA.Media.WaveFile_class"></a><strong>WaveFile</strong><br>

Represents a waveform audio format file (WAV).<br>

<br>

<a name="TVA.Media.WaveFormat_enumeration"></a><strong>WaveFormat</strong><br>

Common WAVE audio encoding formats.<br>

<br>

<a name="TVA.Media.WaveFormatChunk_class"></a><strong>WaveFormatChunk</strong><br>

Represents the format chunk in a WAVE media format file.<br>

<br>

<a name="TVA.Media.WaveFormatExtensible_class"></a><strong>WaveFormatExtensible</strong><br>

Represents the &quot;extensible&quot; format structure for a WAVE media format file.</p>

<hr>

<h4><a name="TVA.Media.Sound_namespace"></a>TVA.Media.Sound</h4>

<p>Contains classes used to create dual tone multi-frequency sounds and standard touch tones.<br>

<br>

<a name="TVA.Media.Sound.DTMF_class"></a><strong>DTMF</strong><br>

Dual Tone Multi-Frequency Class.<br>

<br>

<a name="TVA.Media.Sound.TouchTone_class"></a><strong>TouchTone</strong><br>

Touch tone generator.<br>

<br>

<a name="TVA.Media.Sound.TouchToneKey_enumeration"></a><strong>TouchToneKey</strong><br>

Touch tone key enumeration.</p>

<hr>

<h4><a name="TVA.Net.Ftp_namespace"></a>TVA.Net.Ftp</h4>

<p>Contains classes used to create client connections to FTP servers for uploading and downloading files.<br>

<br>

<a name="TVA.Net.Ftp.FtpAsyncResult_class"></a><strong>FtpAsyncResult</strong><br>

Asynchronous transfer result.<br>

<br>

<a name="TVA.Net.Ftp.FtpAuthenticationException_class"></a><strong>FtpAuthenticationException</strong><br>

FTP authentication exception. <br>

<br>

<a name="TVA.Net.Ftp.FtpClient_class"></a><strong>FtpClient</strong><br>

Represents a FTP session.<br>

<br>

<a name="TVA.Net.Ftp.FtpCommandException_class"></a><strong>FtpCommandException</strong><br>

FTP command exception.<br>

<br>

<a name="TVA.Net.Ftp.FtpControlChannel_class"></a><strong>FtpControlChannel</strong><br>

FTP control channel.<br>

<br>

<a name="TVA.Net.Ftp.FtpDataStream_class"></a><strong>FtpDataStream</strong><br>

FTP data stream.<br>

<br>

<a name="TVA.Net.Ftp.FtpDataTransferException_class"></a><strong>FtpDataTransferException</strong><br>

FTP data transfer exception.<br>

<br>

<a name="TVA.Net.Ftp.FtpDirectory_class"></a><strong>FtpDirectory</strong><br>

Represents a FTP directory.<br>

<br>

<a name="TVA.Net.Ftp.FtpExceptionBase_class"></a><strong>FtpExceptionBase</strong><br>

FTP exception base class.<br>

<br>

<a name="TVA.Net.Ftp.FtpFile_class"></a><strong>FtpFile</strong><br>

Represents a FTP file.<br>

<br>

<a name="TVA.Net.Ftp.FtpFileNotFoundException_class"></a><strong>FtpFileNotFoundException</strong><br>

FTP file not found exception.<br>

<br>

<a name="TVA.Net.Ftp.FtpFileWatcher_class"></a><strong>FtpFileWatcher</strong><br>

FTP File Watcher<br>

<br>

<a name="TVA.Net.Ftp.FtpInputDataStream_class"></a><strong>FtpInputDataStream</strong><br>

Defines a FTP data input stream for remote files.<br>

<br>

<a name="TVA.Net.Ftp.FtpInvalidResponseException_class"></a><strong>FtpInvalidResponseException</strong><br>

Invalid FTP response exception.<br>

<br>

<a name="TVA.Net.Ftp.FtpOutputDataStream_class"></a><strong>FtpOutputDataStream</strong><br>

Defines a FTP data output stream for remote files.<br>

<br>

<a name="TVA.Net.Ftp.FtpResponse_class"></a><strong>FtpResponse</strong><br>

Defines a FTP response.<br>

<br>

<a name="TVA.Net.Ftp.FtpResumeNotSupportedException_class"></a><strong>FtpResumeNotSupportedException</strong><br>

FTP resume not supported exception.<br>

<br>

<a name="TVA.Net.Ftp.FtpServerDownException_class"></a><strong>FtpServerDownException</strong><br>

FTP server down exception.<br>

<br>

<a name="TVA.Net.Ftp.FtpUserAbortException_class"></a><strong>FtpUserAbortException</strong><br>

FTP user abort exception.<br>

<br>

<a name="TVA.Net.Ftp.IFtpFile_interface"></a><strong>IFtpFile</strong><br>

Abstract representation of a FTP file or directory.<br>

<br>

<a name="TVA.Net.Ftp.TransferDirection_enumeration"></a><strong>TransferDirection</strong><br>

FTP file transfer direction enumeration.<br>

<br>

<a name="TVA.Net.Ftp.TransferMode_enumeration"></a><strong>TransferMode</strong><br>

FTP transfer mode enumeration.</p>

<hr>

<h4><a name="TVA.Net.Smtp_namespace"></a>TVA.Net.Smtp</h4>

<p>Contains classes used to simplify and standardize operations related to sending e-mail messages.<br>

<br>

<a name="TVA.Net.Smtp.Mail_class"></a><strong>Mail</strong><br>

A wrapper class to the MailMessage class that simplifies sending mail messages.</p>

<hr>

<h4><a name="TVA.NumericalAnalysis_namespace"></a>TVA.NumericalAnalysis</h4>

<p>Contains classes and extension functions used to calculate common numerical operations such as curve fits and standard deviations.<br>

<br>

<a name="TVA.NumericalAnalysis.CurveFit_class"></a><strong>CurveFit</strong><br>

Linear regression algorithm.<br>

<br>

<a name="TVA.NumericalAnalysis.NumericalAnalysisExtensions_class"></a><strong>NumericalAnalysisExtensions</strong><br>

Defines extension functions related to numerical analysis over a sequence of data.<br>

<br>

<a name="TVA.NumericalAnalysis.RealTimeSlope_class"></a><strong>RealTimeSlope</strong><br>

Calculates slope for a real-time continuous data stream.</p>

<hr>

<h4><a name="TVA.Parsing_namespace"></a>TVA.Parsing</h4>

<p>Contains classes used to simplify, standardize and automate any kind of stream based parsing operation.<br>

<br>

<a name="TVA.Parsing.BinaryImageBase_class"></a><strong>BinaryImageBase</strong><br>

Defines a base class that represents binary images for parsing or generation in terms of a header, body and footer.<br>

<br>

<a name="TVA.Parsing.BinaryImageParserBase_class"></a><strong>BinaryImageParserBase</strong><br>

This class defines the fundamental functionality for parsing any stream of binary data.<br>

<br>

<a name="TVA.Parsing.CommonHeaderBase_class"></a><strong>CommonHeaderBase</strong><br>

Represents the base class for a common binary image header implementation.<br>

<br>

<a name="TVA.Parsing.FrameImageParserBase_class"></a><strong>FrameImageParserBase</strong><br>

This class defines a basic implementation of parsing functionality suitable for automating the parsing of a binary data stream represented as frames with common headers and returning the parsed data via an event.<br>

<br>

<a name="TVA.Parsing.IBinaryImageParser_interface"></a><strong>IBinaryImageParser</strong><br>

This interface represents the protocol independent representation of a streaming data parser.<br>

<br>

<a name="TVA.Parsing.ICommonHeader_interface"></a><strong>ICommonHeader</strong><br>

Defines the common header of a frame image for a set of parsed types, consisting at least of a type ID.<br>

<br>

<a name="TVA.Parsing.IFrameImageParser_interface"></a><strong>IFrameImageParser</strong><br>

This interface represents a basic implementation of parsing functionality suitable for automating the parsing of a binary data stream represented as frames with common headers and returning the parsed data via an event.<br>

<br>

<a name="TVA.Parsing.ISupportBinaryImage_interface"></a><strong>ISupportBinaryImage</strong><br>

Specifies that this Type can support production or consumption of a binary image that represents the object.<br>

<br>

<a name="TVA.Parsing.ISupportFrameImage_interface"></a><strong>ISupportFrameImage</strong><br>

Specifies that this Type can produce or consume a frame of data represented as a binary image.<br>

<br>

<a name="TVA.Parsing.MultiSourceFrameImageParserBase_class"></a><strong>MultiSourceFrameImageParserBase</strong><br>

This class defines a basic implementation of parsing functionality suitable for automating the parsing of multiple binary data streams, each represented as frames with common headers and returning the parsed data via an event.</p>

<hr>

<h4><a name="TVA.Reflection_namespace"></a>TVA.Reflection</h4>

<p>Contains classes and extension functions used to simplify and standardize access to assembly information and attributes in applications.<br>

<br>

<a name="TVA.Reflection.AssemblyExtensions_class"></a><strong>AssemblyExtensions</strong><br>

Defines extension functions related to Assemblies.<br>

<br>

<a name="TVA.Reflection.AssemblyInfo_class"></a><strong>AssemblyInfo</strong><br>

Assembly Information Class.<br>

<br>

<a name="TVA.Reflection.MemberInfoExtensions_class"></a><strong>MemberInfoExtensions</strong><br>

Defines extensions methods related to MemberInfo objects and derived types (e.g., FieldInfo, PropertyInfo, MethodInfo, etc.)</p>

<hr>

<h4><a name="TVA.Scheduling_namespace"></a>TVA.Scheduling</h4>

<p>Contains classes used to schedule operations using standard UNIX crontab syntax.<br>

<br>

<a name="TVA.Scheduling.DateTimePart_enumeration"></a><strong>DateTimePart</strong><br>

Indicates the date/time element that a <a href="#TVA.Scheduling.SchedulePart_class">

SchedulePart</a> represents.<br>

<br>

<a name="TVA.Scheduling.Schedule_class"></a><strong>Schedule</strong><br>

Represents a schedule defined using UNIX crontab syntax.<br>

<br>

<a name="TVA.Scheduling.ScheduleManager_class"></a><strong>ScheduleManager</strong><br>

Monitors multiple <a href="#TVA.Scheduling.Schedule_class">Schedule</a> at an interval of one minute to check if they are due.<br>

<br>

<a name="TVA.Scheduling.SchedulePart_class"></a><strong>SchedulePart</strong><br>

Represents a part of the <a href="#TVA.Scheduling.Schedule_class">Schedule</a>.<br>

<br>

<a name="TVA.Scheduling.SchedulePartTextSyntax_enumeration"></a><strong>SchedulePartTextSyntax</strong><br>

Indicates the syntax used in a <a href="#TVA.Scheduling.SchedulePart_class">SchedulePart</a> for specifying its values.</p>

<hr>

<h4><a name="TVA.Security.Cryptography_namespace"></a>TVA.Security.Cryptography</h4>

<p>Contains classes and extension functions used to simplify and standardize usage of basic cryptography using a combination of standard and proprietary encryption algorithms to produce decent obfuscations of strings, buffers and streams of data.<br>

<br>

<a name="TVA.Security.Cryptography.Cipher_class"></a><strong>Cipher</strong><br>

Provides general use cryptographic functions.<br>

<br>

<a name="TVA.Security.Cryptography.CipherStrength_enumeration"></a><strong>CipherStrength</strong><br>

Cryptographic strength enumeration.<br>

<br>

<a name="TVA.Security.Cryptography.Random_class"></a><strong>Random</strong><br>

Generates cryptographically strong random numbers.<br>

<br>

<a name="TVA.Security.Cryptography.SymmetricAlgorithmExtensions_class"></a><strong>SymmetricAlgorithmExtensions</strong><br>

Defines extension functions related to cryptographic SymmetricAlgorithm objects.</p>

<hr>

<h4><a name="TVA.Threading_namespace"></a>TVA.Threading</h4>

<p>Contains classes used to define managed threads that can be used for debugging threads by providing automatic tracking, total thread runtime and the ability to run threads in alternate execution contexts.<br>

<br>

<a name="TVA.Threading.ManagedThread_class"></a><strong>ManagedThread</strong><br>

Defines a managed thread<br>

<br>

<a name="TVA.Threading.ManagedThreadPool_class"></a><strong>ManagedThreadPool</strong><br>

Defines a managed thread pool<br>

<br>

<a name="TVA.Threading.ManagedThreads_class"></a><strong>ManagedThreads</strong><br>

Maintains a reference to all managed threads<br>

<br>

<a name="TVA.Threading.ThreadStatus_enumeration"></a><strong>ThreadStatus</strong><br>

Managed Thread States<br>

<br>

<a name="TVA.Threading.ThreadType_enumeration"></a><strong>ThreadType</strong><br>

Managed Thread Types</p>

<hr>

<h4><a name="TVA.Units_namespace"></a>TVA.Units</h4>

<p>Contains classes used to simplify and standardize standard unit and SI conversions.<br>

<br>

<a name="TVA.Units.Angle_structure"></a><strong>Angle</strong><br>

Represents an angle, in radians, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Charge_structure"></a><strong>Charge</strong><br>

Represents an electric charge measurement, in coulombs (i.e., ampere-seconds), as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Current_structure"></a><strong>Current</strong><br>

Represents an electric current measurement, in amperes, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Energy_structure"></a><strong>Energy</strong><br>

Represents an energy measurement, in joules (i.e., watt-seconds), as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Length_structure"></a><strong>Length</strong><br>

Represents a length measurement, in meters, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Mass_structure"></a><strong>Mass</strong><br>

Represents a mass measurement, in kilograms, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Power_structure"></a><strong>Power</strong><br>

Represents a power measurement, in watts, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.SI_class"></a><strong>SI</strong><br>

Defines constant factors for SI units of measure to handle metric conversions.<br>

<br>

<a name="TVA.Units.SI2_class"></a><strong>SI2</strong><br>

Defines constant factors based on 1024 for related binary SI units of measure used in computational measurements.<br>

<br>

<a name="TVA.Units.Speed_structure"></a><strong>Speed</strong><br>

Represents a speed measurement, in meters per second, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Temperature_structure"></a><strong>Temperature</strong><br>

Represents a temperature, in kelvin, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Time_structure"></a><strong>Time</strong><br>

Represents a time measurement, in seconds, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Voltage_structure"></a><strong>Voltage</strong><br>

Represents an electromotive force (i.e., voltage) measurement, in volts, as a double-precision floating-point number.<br>

<br>

<a name="TVA.Units.Volume_structure"></a><strong>Volume</strong><br>

Represents a volume measurement, in cubic meters, as a double-precision floating-point number.</p>

<hr>

<h4><a name="TVA.Windows.Forms_namespace"></a>TVA.Windows.Forms</h4>

<p>Contains classes, extension functions and forms used to simplify and standardize usage of basic Windows forms.<br>

<br>

<a name="TVA.Windows.Forms.FormExtensions_class"></a><strong>FormExtensions</strong><br>

Extensions applied to all System.Windows.Forms.Form objects.<br>

<br>

<a name="TVA.Windows.Forms.ScreenArea_class"></a><strong>ScreenArea</strong><br>

Returns screen area statistics and capture functionality for all connected screens.</p>

<hr>

<h4><a name="TVA.Xml_namespace"></a>TVA.Xml</h4>

<p>Contains extension functions used to simplify and standardize usage of standard Xml objects.<br>

<br>

<a name="TVA.Xml.XmlExtensions_class"></a><strong>XmlExtensions</strong><br>

Defines extension functions related to Xml elements.</p>

<hr>

<h3><a name="TVA.Services_project"></a>TVA.Services</h3>

<p>This assembly contains classes used to simplify and standardize development and operation of Windows services that are remotely manageable.<br>

<br>

TVA.Services.dll</p>

<h4><a name="TVA.Services_namespace"></a>TVA.Services</h4>

<p>Contains classes used to simplify and standardize development and operation of Windows services that are remotely manageable.<br>

<br>

<a name="TVA.Services.ClientHelper_class"></a><strong>ClientHelper</strong><br>

Component that provides client-side functionality to <a href="#TVA.Services.ServiceHelper_class">

ServiceHelper</a>.<br>

<br>

<a name="TVA.Services.ClientInfo_class"></a><strong>ClientInfo</strong><br>

Represents information about a client using <a href="#TVA.Services.ClientHelper_class">

ClientHelper</a> for connecting to a Windows Service that uses <a href="#TVA.Services.ServiceHelper_class">

ServiceHelper</a>.<br>

<br>

<a name="TVA.Services.ClientRequest_class"></a><strong>ClientRequest</strong><br>

Represents a request sent by <a href="#TVA.Services.ClientHelper_class">ClientHelper</a> to

<a href="#TVA.Services.ServiceHelper_class">ServiceHelper</a>.<br>

<br>

<a name="TVA.Services.ClientRequestHandler_class"></a><strong>ClientRequestHandler</strong><br>

Represents a handler for <a href="#TVA.Services.ClientRequest_class">ClientRequest</a>s sent by

<a href="#TVA.Services.ClientHelper_class">ClientHelper</a>.<br>

<br>

<a name="TVA.Services.ClientRequestInfo_class"></a><strong>ClientRequestInfo</strong><br>

Represents information about a <a href="#TVA.Services.ClientRequest_class">ClientRequest</a> sent by

<a href="#TVA.Services.ClientHelper_class">ClientHelper</a>.<br>

<br>

<a name="TVA.Services.IdentityToken_enumeration"></a><strong>IdentityToken</strong><br>

Indicates the type of SecurityToken to be sent to the <a href="#TVA.Services.ServiceHelper_class">

ServiceHelper</a> for authentication.<br>

<br>

<a name="TVA.Services.ServiceHelper_class"></a><strong>ServiceHelper</strong><br>

Component that provides added functionality to a Windows Service.<br>

<br>

<a name="TVA.Services.ServiceProcess_class"></a><strong>ServiceProcess</strong><br>

Represents a process that executes asynchronously inside a <a href="#TVA.Services.ServiceHelper_class">

ServiceHelper</a>.<br>

<br>

<a name="TVA.Services.ServiceProcessState_enumeration"></a><strong>ServiceProcessState</strong><br>

Indicates the current state of <a href="#TVA.Services.ServiceProcess_class">ServiceProcess</a>.<br>

<br>

<a name="TVA.Services.ServiceResponse_class"></a><strong>ServiceResponse</strong><br>

Represents a response sent by the <a href="#TVA.Services.ServiceHelper_class">ServiceHelper</a> to a

<a href="#TVA.Services.ClientRequest_class">ClientRequest</a> from the <a href="#TVA.Services.ClientHelper_class">

ClientHelper</a>.<br>

<br>

<a name="TVA.Services.ServiceState_enumeration"></a><strong>ServiceState</strong><br>

Indicates the state of a Windows Service.</p>

<hr>

<h3><a name="TVA.Windows_project"></a>TVA.Windows</h3>

<p>This assembly contains classes, extension functions, and forms used to simplify and standardize usage of basic Windows forms.</p>

<h4><a name="TVA.Windows.Forms_namespace2"></a>TVA.Windows.Forms</h4>

<p>Contains classes, extension functions, and forms used to simplify and standardize usage of basic Windows forms.<br>

<br>

<a name="TVA.Windows.Forms.AboutDialog_class"></a><strong>AboutDialog</strong><br>

Represents a common about dialog box.<br>

<br>

<a name="TVA.Windows.Forms.PropertyGridExtensions_class"></a><strong>PropertyGridExtensions</strong><br>

Defines extension functions for the PropertyGrid control.</p>

<hr>

<h3><a name="TVA.Historian_project"></a>TVA.Historian</h3>

<p>This assembly contains fundamental classes used by all historian code.</p>

<h4><a name="TVA.Historian_namespace"></a>TVA.Historian</h4>

<p>Contains fundamental classes used by all historian code.<br>

<br>

<a name="TVA.Historian.DataListener_class"></a><strong>DataListener</strong><br>

Represents a listener that can receive time series data in real-time using Sockets.<br>

<br>

<a name="TVA.Historian.IArchive_interface"></a><strong>IArchive</strong><br>

Defines a repository where time series data is warehoused by a historian.<br>

<br>

<a name="TVA.Historian.IDataPoint_interface"></a><strong>IDataPoint</strong><br>

Defines time series data warehoused by a historian.<br>

<br>

<a name="TVA.Historian.Quality_enumeration"></a><strong>Quality</strong><br>

Indicates the quality of time series data.<br>

<br>

<a name="TVA.Historian.TimeTag_class"></a><strong>TimeTag</strong><br>

Represents a historian time tag as number of seconds from the BaseDate.</p>

<hr>

<h4><a name="TVA.Historian.Exporters_namespace"></a>TVA.Historian.Exporters</h4>

<p>Contains classes used for automating data exports in a variety of formats.<br>

<br>

<a name="TVA.Historian.Exporters.CsvExporter_class"></a><strong>CsvExporter</strong><br>

Represents an exporter that can export the current time series data in CSV format to a file.<br>

<br>

<a name="TVA.Historian.Exporters.DataMonitorExporter_class"></a><strong>DataMonitorExporter</strong><br>

Represents an exporter that can export real-time time series data over a TCP server socket.<br>

<br>

<a name="TVA.Historian.Exporters.Export_class"></a><strong>Export</strong><br>

A class with information that can be used by an exporter for exporting time series data.<br>

<br>

<a name="TVA.Historian.Exporters.ExporterBase_class"></a><strong>ExporterBase</strong><br>

A base class for an exporter of real-time time series data.<br>

<br>

<a name="TVA.Historian.Exporters.ExportProcessResult_enumeration"></a><strong>ExportProcessResult</strong><br>

Indicates the processing result of an <a href="#TVA.Historian.Exporters.Export_class">

Export</a>.<br>

<br>

<a name="TVA.Historian.Exporters.ExportRecord_class"></a><strong>ExportRecord</strong><br>

A class that can be used to define the time series data to be exported for an <a href="#TVA.Historian.Exporters.Export_class">

Export</a>.<br>

<br>

<a name="TVA.Historian.Exporters.ExportSetting_class"></a><strong>ExportSetting</strong><br>

A class that can be used to add custom settings to an <a href="#TVA.Historian.Exporters.Export_class">

Export</a>.<br>

<br>

<a name="TVA.Historian.Exporters.ExportType_enumeration"></a><strong>ExportType</strong><br>

Indicates the processing frequency of an <a href="#TVA.Historian.Exporters.Export_class">

Export</a>.<br>

<br>

<a name="TVA.Historian.Exporters.FileHelper_class"></a><strong>FileHelper</strong><br>

A class with helper methods for file related operations.<br>

<br>

<a name="TVA.Historian.Exporters.IExporter_interface"></a><strong>IExporter</strong><br>

Defines an exporter of real-time time series data.<br>

<br>

<a name="TVA.Historian.Exporters.RawDataExporter_class"></a><strong>RawDataExporter</strong><br>

Represents an exporter that can export real-time time series data in CSV or XML format to a file.<br>

<br>

<a name="TVA.Historian.Exporters.RebroadcastExporter_class"></a><strong>RebroadcastExporter</strong><br>

Represents an exporter that can export real-time time series data using TCP or UDP to a listening Socket.<br>

<br>

<a name="TVA.Historian.Exporters.RollingHistoryExporter_class"></a><strong>RollingHistoryExporter</strong><br>

Represents an exporter that can export current and runtime historic time series data in CSV or XML format to a file.<br>

<br>

<a name="TVA.Historian.Exporters.StatisticsExporter_class"></a><strong>StatisticsExporter</strong><br>

Represents an exporter that can export the StatisticsExporter.Statistics in CSV or XML format to a file.<br>

<br>

<a name="TVA.Historian.Exporters.XmlExporter_class"></a><strong>XmlExporter</strong><br>

Represents an exporter that can export the current time series data in XML format to a file.</p>

<hr>

<h4><a name="TVA.Historian.Files_namespace"></a>TVA.Historian.Files</h4>

<p>Contains classes used for manipulating archive files.<br>

<br>

<a name="TVA.Historian.Files.ArchiveData_class"></a><strong>ArchiveData</strong><br>

Represents time series data stored in <a href="#TVA.Historian.Files.ArchiveFile_class">

ArchiveFile</a>.<br>

<br>

<a name="TVA.Historian.Files.ArchiveDataBlock_class"></a><strong>ArchiveDataBlock</strong><br>

Represents a block of <a href="#TVA.Historian.Files.ArchiveData_class">ArchiveData</a> in an

<a href="#TVA.Historian.Files.ArchiveFile_class">ArchiveFile</a>.<br>

<br>

<a name="TVA.Historian.Files.ArchiveDataBlockPointer_class"></a><strong>ArchiveDataBlockPointer</strong><br>

Represents a pointer to an <a href="#TVA.Historian.Files.ArchiveDataBlock_class">

ArchiveDataBlock</a>.<br>

<br>

<a name="TVA.Historian.Files.ArchiveFile_class"></a><strong>ArchiveFile</strong><br>

Represents a file that contains <a href="#TVA.Historian.Files.ArchiveData_class">

ArchiveData</a>.<br>

<br>

<a name="TVA.Historian.Files.ArchiveFileAllocationTable_class"></a><strong>ArchiveFileAllocationTable</strong><br>

Represents the File Allocation Table of an <a href="#TVA.Historian.Files.ArchiveFile_class">

ArchiveFile</a>.<br>

<br>

<a name="TVA.Historian.Files.ArchiveFileStatistics_class"></a><strong>ArchiveFileStatistics</strong><br>

A class that contains the statistics of an <a href="#TVA.Historian.Files.ArchiveFile_class">

ArchiveFile</a>.<br>

<br>

<a name="TVA.Historian.Files.ArchiveFileType_enumeration"></a><strong>ArchiveFileType</strong><br>

Indicates the type of <a href="#TVA.Historian.Files.ArchiveFile_class">ArchiveFile</a>.<br>

<br>

<a name="TVA.Historian.Files.DataType_enumeration"></a><strong>DataType</strong><br>

Indicates the type of data being archived for a <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>.<br>

<br>

<a name="TVA.Historian.Files.IntercomFile_class"></a><strong>IntercomFile</strong><br>

Represents a file containing <a href="#TVA.Historian.Files.IntercomRecord_class">

IntercomRecord</a>s.<br>

<br>

<a name="TVA.Historian.Files.IntercomRecord_class"></a><strong>IntercomRecord</strong><br>

Represents a record in the <a href="#TVA.Historian.Files.IntercomFile_class">IntercomFile</a> that contains runtime information of a historian.<br>

<br>

<a name="TVA.Historian.Files.MetadataFile_class"></a><strong>MetadataFile</strong><br>

Represents a file containing <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>s.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecord_class"></a><strong>MetadataRecord</strong><br>

Represents a record in the <a href="#TVA.Historian.Files.MetadataFile_class">MetadataFile</a> that contains the various attributes associates to a HistorianID.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecordAlarmFlags_class"></a><strong>MetadataRecordAlarmFlags</strong><br>

Defines which data <a href="#TVA.Historian.Quality_enumeration">Quality</a> should trigger an alarm notification.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecordAnalogFields_class"></a><strong>MetadataRecordAnalogFields</strong><br>

Defines specific fields for <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>s that are of type Analog.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecordComposedFields_class"></a><strong>MetadataRecordComposedFields</strong><br>

Defines specific fields for <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>s that are of type Composed.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecordConstantFields_class"></a><strong>MetadataRecordConstantFields</strong><br>

Defines specific fields for <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>s that are of type Constant.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecordDigitalFields_class"></a><strong>MetadataRecordDigitalFields</strong><br>

Defines specific fields for <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>s that are of type Digital.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecordGeneralFlags_class"></a><strong>MetadataRecordGeneralFlags</strong><br>

Defines general boolean settings for a <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecordSecurityFlags_class"></a><strong>MetadataRecordSecurityFlags</strong><br>

Defines the security level for a <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>.<br>

<br>

<a name="TVA.Historian.Files.MetadataRecordSummary_class"></a><strong>MetadataRecordSummary</strong><br>

A class with a subset of information defined in <a href="#TVA.Historian.Files.MetadataRecord_class">

MetadataRecord</a>. The BinaryImage of <strong>MetadataRecordSummary</strong> is sent back as a reply to

<a href="#TVA.Historian.Packets.PacketType3_class">PacketType3</a> and <a href="#TVA.Historian.Packets.PacketType4_class">

PacketType4</a>.<br>

<br>

<a name="TVA.Historian.Files.StateFile_class"></a><strong>StateFile</strong><br>

Represents a file containing <a href="#TVA.Historian.Files.StateRecord_class">StateRecord</a>s.<br>

<br>

<a name="TVA.Historian.Files.StateRecord_class"></a><strong>StateRecord</strong><br>

Represents a record in the <a href="#TVA.Historian.Files.StateFile_class">StateFile</a> that contains the state information associated to a HistorianID.<br>

<br>

<a name="TVA.Historian.Files.StateRecordData_class"></a><strong>StateRecordData</strong><br>

Represents time series data stored in <a href="#TVA.Historian.Files.StateFile_class">

StateFile</a>.<br>

<br>

<a name="TVA.Historian.Files.StateRecordSummary_class"></a><strong>StateRecordSummary</strong><br>

A class with just CurrentData. The BinaryImage of <a href="#TVA.Historian.Files.MetadataRecordSummary_class">

MetadataRecordSummary</a> is sent back as a reply to <a href="#TVA.Historian.Packets.PacketType11_class">

PacketType11</a>.</p>

<hr>

<h4><a name="TVA.Historian.MetadataProviders_namespace"></a>TVA.Historian.MetadataProviders</h4>

<p>Contains classes that allow the historian to collect its required point metadata definitions from a variety of sources.<br>

<br>

<a name="TVA.Historian.MetadataProviders.AdoMetadataProvider_class"></a><strong>AdoMetadataProvider</strong><br>

Represents a provider of data to a <a href="#TVA.Historian.Files.MetadataFile_class">

MetadataFile</a> from any ADO.NET based data store.<br>

<br>

<a name="TVA.Historian.MetadataProviders.IMetadataProvider_interface"></a><strong>IMetadataProvider</strong><br>

Defines a provider of updates to the data in a <a href="#TVA.Historian.Files.MetadataFile_class">

MetadataFile</a>.<br>

<br>

<a name="TVA.Historian.MetadataProviders.MetadataProviderBase_class"></a><strong>MetadataProviderBase</strong><br>

A base class for a provider of updates to the data in a <a href="#TVA.Historian.Files.MetadataFile_class">

MetadataFile</a>.<br>

<br>

<a name="TVA.Historian.MetadataProviders.MetadataProviders_class"></a><strong>MetadataProviders</strong><br>

A class that loads all Metadata Provider adapters.<br>

<br>

<a name="TVA.Historian.MetadataProviders.MetadataUpdater_class"></a><strong>MetadataUpdater</strong><br>

A class that can update data in a <a href="#TVA.Historian.Files.MetadataFile_class">

MetadataFile</a>.<br>

<br>

<a name="TVA.Historian.MetadataProviders.OleDbMetadataProvider_class"></a><strong>OleDbMetadataProvider</strong><br>

Represents a provider of data to a <a href="#TVA.Historian.Files.MetadataFile_class">

MetadataFile</a> from any OLE DB data store.<br>

<br>

<a name="TVA.Historian.MetadataProviders.RestWebServiceMetadataProvider_class"></a><strong>RestWebServiceMetadataProvider</strong><br>

Represents a provider of data to a <a href="#TVA.Historian.Files.MetadataFile_class">

MetadataFile</a> from a REST (Representational State Transfer) web service.</p>

<hr>

<h4><a name="TVA.Historian.Notifiers_namespace"></a>TVA.Historian.Notifiers</h4>

<p>Contains classes and interfaces that allow standard and custom historian notifications about critical system events.<br>

<br>

<a name="TVA.Historian.Notifiers.EmailNotifier_class"></a><strong>EmailNotifier</strong><br>

Represents a notifier that can send notifications in email messages.<br>

<br>

<a name="TVA.Historian.Notifiers.INotifier_interface"></a><strong>INotifier</strong><br>

Defines a notifier that can process notification messages.<br>

<br>

<a name="TVA.Historian.Notifiers.NotificationTypes_enumeration"></a><strong>NotificationTypes</strong><br>

Indicates the type of notification being sent using a Notifier.<br>

<br>

<a name="TVA.Historian.Notifiers.NotifierBase_class"></a><strong>NotifierBase</strong><br>

A base class for a notifier that can process notification messages.<br>

<br>

<a name="TVA.Historian.Notifiers.Notifiers_class"></a><strong>Notifiers</strong><br>

A class that loads all Notifier adapters.</p>

<hr>

<h4><a name="TVA.Historian.Packets_namespace"></a>TVA.Historian.Packets</h4>

<p>Contains classes that define packet definitions used for transmission of data points and metadata.<br>

<br>

<a name="TVA.Historian.Packets.IPacket_interface"></a><strong>IPacket</strong><br>

Defines a binary packet received by a historian.<br>

<br>

<a name="TVA.Historian.Packets.PacketBase_class"></a><strong>PacketBase</strong><br>

A base class for a binary packet received by a historian.<br>

<br>

<a name="TVA.Historian.Packets.PacketCommonHeader_class"></a><strong>PacketCommonHeader</strong><br>

Represents the common header information that is present in the binary image of all Types that implement the

<a href="#TVA.Historian.Packets.IPacket_interface">IPacket</a> interface.<br>

<br>

<a name="TVA.Historian.Packets.PacketParser_class"></a><strong>PacketParser</strong><br>

Represents a data parser that can parse binary data in to <a href="#TVA.Historian.Packets.IPacket_interface">

IPacket</a>s.<br>

<br>

<a name="TVA.Historian.Packets.PacketType1_class"></a><strong>PacketType1</strong><br>

Represents a packet to be used for sending single time series data point to a historian for archival.<br>

<br>

<a name="TVA.Historian.Packets.PacketType101_class"></a><strong>PacketType101</strong><br>

Represents a packet that can be used to send multiple time series data points to a historian for archival.<br>

<br>

<a name="TVA.Historian.Packets.PacketType101Data_class"></a><strong>PacketType101Data</strong><br>

Represents time series data transmitted in <a href="#TVA.Historian.Packets.PacketType101_class">

PacketType101</a>.<br>

<br>

<a name="TVA.Historian.Packets.PacketType11_class"></a><strong>PacketType11</strong><br>

Represents a packet to be used for requesting Summary for the RequestIDs.<br>

<br>

<a name="TVA.Historian.Packets.PacketType2_class"></a><strong>PacketType2</strong><br>

Represents a packet to be used for sending single time (expanded format) series data point to a historian for archival.<br>

<br>

<a name="TVA.Historian.Packets.PacketType3_class"></a><strong>PacketType3</strong><br>

Represents a packet to be used for requesting Summary for the RequestIDs.<br>

<br>

<a name="TVA.Historian.Packets.PacketType4_class"></a><strong>PacketType4</strong><br>

Represents a packet to be used for requesting Summary for the RequestIDs only if the

<a href="#TVA.Historian.Files.MetadataRecord_class">MetadataRecord</a> has changed.<br>

<br>

<a name="TVA.Historian.Packets.PacketType5_class"></a><strong>PacketType5</strong><br>

Represents a packet that can be used to query the status of a historian.<br>

<br>

<a name="TVA.Historian.Packets.QueryPacketBase_class"></a><strong>QueryPacketBase</strong><br>

A base class for a packet to be used for requesting information from a historian.</p>

<hr>

<h4><a name="TVA.Historian.Services_namespace"></a>TVA.Historian.Services</h4>

<p>Contains classes that define the fundamental web services for a historian.<br>

<br>

<a name="TVA.Historian.Services.DataFlowDirection_enumeration"></a><strong>DataFlowDirection</strong><br>

Indicates the direction in which data will be flowing from a web service.<br>

<br>

<a name="TVA.Historian.Services.IMetadataService_interface"></a><strong>IMetadataService</strong><br>

Defines a REST web service for historian metadata.<br>

<br>

<a name="TVA.Historian.Services.IService_interface"></a><strong>IService</strong><br>

Defines a web service that can send and receive data over REST (Representational State Transfer) interface.<br>

<br>

<a name="TVA.Historian.Services.ITimeSeriesDataService_interface"></a><strong>ITimeSeriesDataService</strong><br>

Defines a REST web service for time-series data.<br>

<br>

<a name="TVA.Historian.Services.MetadataService_class"></a><strong>MetadataService</strong><br>

Represents a REST web service for historian metadata.<br>

<br>

<a name="TVA.Historian.Services.SerializableMetadata_class"></a><strong>SerializableMetadata</strong><br>

Represents a container for <a href="#TVA.Historian.Services.SerializableMetadataRecord_class">

SerializableMetadataRecord</a>s that can be serialized using XmlSerializer or DataContractJsonSerializer.<br>

<br>

<a name="TVA.Historian.Services.SerializableMetadataRecord_class"></a><strong>SerializableMetadataRecord</strong><br>

Represents a flattened <a href="#TVA.Historian.Files.MetadataRecord_class">MetadataRecord</a> that can be serialized using XmlSerializer, DataContractSerializer or DataContractJsonSerializer.<br>

<br>

<a name="TVA.Historian.Services.SerializableTimeSeriesData_class"></a><strong>SerializableTimeSeriesData</strong><br>

Represents a container for <a href="#TVA.Historian.Services.SerializableTimeSeriesDataPoint_class">

SerializableTimeSeriesDataPoint</a>s that can be serialized using XmlSerializer or DataContractJsonSerializer.<br>

<br>

<a name="TVA.Historian.Services.SerializableTimeSeriesDataPoint_class"></a><strong>SerializableTimeSeriesDataPoint</strong><br>

Represents a time-series data-point that can be serialized using XmlSerializer, DataContractSerializer or DataContractJsonSerializer.<br>

<br>

<a name="TVA.Historian.Services.Serialization_class"></a><strong>Serialization</strong><br>

Helper class to serialize and deserialize Objects to web service compatible <a href="#TVA.Historian.Services.SerializationFormat_enumeration">

SerializationFormats</a>.<br>

<br>

<a name="TVA.Historian.Services.SerializationFormat_enumeration"></a><strong>SerializationFormat</strong><br>

Indicates the format of Object serialization or deserialization.<br>

<br>

<a name="TVA.Historian.Services.Service_class"></a><strong>Service</strong><br>

A base class for web service that can send and receive data over REST (Representational State Transfer) interface.<br>

<br>

<a name="TVA.Historian.Services.Services_class"></a><strong>Services</strong><br>

A class that loads all of the web services.<br>

<br>

<a name="TVA.Historian.Services.TimeSeriesDataService_class"></a><strong>TimeSeriesDataService</strong><br>

Represents a REST web service for time-series data.</p>

<hr>

<h2><a name="Synchrophasor_solution"></a>Synchrophasor</h2>

<p>The synchrophasor solution contains all code related to the primary system executables of the openPDC as well as the phasor protocol parsing and generating library.</p>

<h3><a name="TVA.PhasorProtocols_project"></a>TVA.PhasorProtocols</h3>

<p>This assembly contains fundamental classes and interfaces used by all phasor protocol parsing and generating code.</p>

<h4><a name="TVA.PhasorProtocols_namespace"></a>TVA.PhasorProtocols</h4>

<p>Contains fundamental classes and interfaces used by all phasor protocol parsing and generating code.<br>

<br>

<a name="TVA.PhasorProtocols.AnalogDefinitionBase_class"></a><strong>AnalogDefinitionBase</strong><br>

Represents the common implementation of the protocol independent definition of an

<a href="#TVA.PhasorProtocols.IAnalogValue_interface">IAnalogValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.AnalogDefinitionCollection_class"></a><strong>AnalogDefinitionCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IAnalogDefinition_interface">

IAnalogDefinition</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.AnalogType_enumeration"></a><strong>AnalogType</strong><br>

Analog types enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.AnalogValueBase_class"></a><strong>AnalogValueBase</strong><br>

Represents the common implementation of the protocol independent representation of an analog value.<br>

<br>

<a name="TVA.PhasorProtocols.AnalogValueCollection_class"></a><strong>AnalogValueCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IAnalogValue_interface">

IAnalogValue</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelBase_class"></a><strong>ChannelBase</strong><br>

Represents the common implementation of the protocol independent definition of any kind of data that can be parsed or generated.<br>

This is the base class of all parsing/generating classes in the phasor protocols library; it is the root of the parsing/generating class hierarchy.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelCellBase_class"></a><strong>ChannelCellBase</strong><br>

Represents the common implementation of the protocol independent representation of any kind of data cell.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelCellCollectionBase_class"></a><strong>ChannelCellCollectionBase</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IChannelCell_interface">

IChannelCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelCellParsingStateBase_class"></a><strong>ChannelCellParsingStateBase</strong><br>

Represents the protocol independent common implementation of the parsing state used by any

<a href="#TVA.PhasorProtocols.IChannelCell_interface">IChannelCell</a>.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelCollectionBase_class"></a><strong>ChannelCollectionBase</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IChannel_interface">

IChannel</a> objects.<br>

This is the base class of all collection classes in the phasor protocols library; it is the root of the collection class hierarchy.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelDefinitionBase_class"></a><strong>ChannelDefinitionBase</strong><br>

Represents the common implementation of the protocol independent definition of any kind of

<a href="#TVA.PhasorProtocols.IChannel_interface">IChannel</a> data.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelDefinitionCollectionBase_class"></a><strong>ChannelDefinitionCollectionBase</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IChannelDefinition_interface">

IChannelDefinition</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelFrameBase_class"></a><strong>ChannelFrameBase</strong><br>

Represents the protocol independent common implementation of any frame of data that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelFrameCollectionBase_class"></a><strong>ChannelFrameCollectionBase</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IChannelFrame_interface">

IChannelFrame</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelFrameParsingStateBase_class"></a><strong>ChannelFrameParsingStateBase</strong><br>

Represents the protocol independent common implementation of the parsing state used by any

<a href="#TVA.PhasorProtocols.IChannelFrame_interface">IChannelFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelParsingStateBase_class"></a><strong>ChannelParsingStateBase</strong><br>

Represents the common implementation of the protocol independent parsing state class used by any kind of data.<br>

This is the base class of all parsing state classes in the phasor protocols library; it is the root of the parsing state class hierarchy.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelValueBase_class"></a><strong>ChannelValueBase</strong><br>

Represents the common implementation of the protocol independent representation of any kind of data value.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelValueCollectionBase_class"></a><strong>ChannelValueCollectionBase</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IChannelValue_interface">

IChannelValue</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.ChannelValueMeasurement_class"></a><strong>ChannelValueMeasurement</strong><br>

Represents a IMeasurement implementation for composite values of a given <a href="#TVA.PhasorProtocols.IChannelValue_interface">

IChannelValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.CommandCell_class"></a><strong>CommandCell</strong><br>

Represents the protocol independent common implementation of an element of extended data for cells in a

<a href="#TVA.PhasorProtocols.ICommandFrame_interface">ICommandFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.CommandCellCollection_class"></a><strong>CommandCellCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.ICommandCell_interface">

ICommandCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.CommandFrameBase_class"></a><strong>CommandFrameBase</strong><br>

Represents the protocol independent common implementation of any <a href="#TVA.PhasorProtocols.ICommandFrame_interface">

ICommandFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.CommandFrameParsingState_class"></a><strong>CommandFrameParsingState</strong><br>

Represents the protocol independent common implementation of the parsing state used by any

<a href="#TVA.PhasorProtocols.ICommandFrame_interface">ICommandFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Common_class"></a><strong>Common</strong><br>

Common constants, functions and extensions for phasor classes.<br>

<br>

<a name="TVA.PhasorProtocols.CommonStatusFlags_enumeration"></a><strong>CommonStatusFlags</strong><br>

Protocol independent common status flags enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.CompositeFrequencyValue_enumeration"></a><strong>CompositeFrequencyValue</strong><br>

Composite frequency value indicies enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.CompositePhasorValue_enumeration"></a><strong>CompositePhasorValue</strong><br>

Composite polar value indicies enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.ConfigurationCellBase_class"></a><strong>ConfigurationCellBase</strong><br>

Represents the protocol independent common implementation of all configuration elements for cells in a

<a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">IConfigurationFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.ConfigurationCellCollection_class"></a><strong>ConfigurationCellCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.ConfigurationCellParsingState_class"></a><strong>ConfigurationCellParsingState</strong><br>

Represents the protocol independent common implementation of the parsing state used by any

<a href="#TVA.PhasorProtocols.IConfigurationCell_interface">IConfigurationCell</a>.<br>

<br>

<a name="TVA.PhasorProtocols.ConfigurationFrameBase_class"></a><strong>ConfigurationFrameBase</strong><br>

Represents the protocol independent common implementation of any <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.ConfigurationFrameCollection_class"></a><strong>ConfigurationFrameCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.ConfigurationFrameParsingState_class"></a><strong>ConfigurationFrameParsingState</strong><br>

Represents the protocol independent common implementation of the parsing state used by any

<a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">IConfigurationFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.ConnectionParametersBase_class"></a><strong>ConnectionParametersBase</strong><br>

Represents the common implementation of the protocol independent set of extra connection parameters.<br>

<br>

<a name="TVA.PhasorProtocols.CoordinateFormat_enumeration"></a><strong>CoordinateFormat</strong><br>

Phasor coordinate formats enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.DataCellBase_class"></a><strong>DataCellBase</strong><br>

Represents the protocol independent common implementation of all elements for cells in a

<a href="#TVA.PhasorProtocols.IDataFrame_interface">IDataFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.DataCellCollection_class"></a><strong>DataCellCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.DataCellParsingState_class"></a><strong>DataCellParsingState</strong><br>

Represents the protocol independent common implementation of the parsing state used by any

<a href="#TVA.PhasorProtocols.IDataCell_interface">IDataCell</a>.<br>

<br>

<a name="TVA.PhasorProtocols.DataFormat_enumeration"></a><strong>DataFormat</strong><br>

Data transmission formats enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.DataFrameBase_class"></a><strong>DataFrameBase</strong><br>

Represents the protocol independent common implementation of any <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.DataFrameCollection_class"></a><strong>DataFrameCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.DataFrameParsingState_class"></a><strong>DataFrameParsingState</strong><br>

Represents the protocol independent common implementation of the parsing state used by any

<a href="#TVA.PhasorProtocols.IDataFrame_interface">IDataFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.DataSortingType_enumeration"></a><strong>DataSortingType</strong><br>

Data sorting types enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.DeviceCommand_enumeration"></a><strong>DeviceCommand</strong><br>

Phasor enabled device commands enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.DigitalDefinitionBase_class"></a><strong>DigitalDefinitionBase</strong><br>

Represents the common implementation of the protocol independent definition of a <a href="#TVA.PhasorProtocols.IDigitalValue_interface">

IDigitalValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.DigitalDefinitionCollection_class"></a><strong>DigitalDefinitionCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IDigitalDefinition_interface">

IDigitalDefinition</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.DigitalValueBase_class"></a><strong>DigitalValueBase</strong><br>

Represents the common implementation of the protocol independent representation of a digital value.<br>

<br>

<a name="TVA.PhasorProtocols.DigitalValueCollection_class"></a><strong>DigitalValueCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IDigitalValue_interface">

IDigitalValue</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.FrameParserBase_class"></a><strong>FrameParserBase</strong><br>

Represents a frame parser that defines the basic functionality for a protocol to parse a binary data stream and return the parsed data via events.<br>

<br>

<a name="TVA.PhasorProtocols.FrequencyDefinitionBase_class"></a><strong>FrequencyDefinitionBase</strong><br>

Represents the common implementation of the protocol independent definition of a <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.FrequencyDefinitionCollection_class"></a><strong>FrequencyDefinitionCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">

IFrequencyDefinition</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.FrequencyValueBase_class"></a><strong>FrequencyValueBase</strong><br>

Represents the common implementation of the protocol independent representation of a frequency and df/dt value.<br>

<br>

<a name="TVA.PhasorProtocols.FrequencyValueCollection_class"></a><strong>FrequencyValueCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.FundamentalFrameType_enumeration"></a><strong>FundamentalFrameType</strong><br>

Fundamental frame types enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.HeaderCell_class"></a><strong>HeaderCell</strong><br>

Represents the protocol independent common implementation of an element of header data for cells in a

<a href="#TVA.PhasorProtocols.IHeaderFrame_interface">IHeaderFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.HeaderCellCollection_class"></a><strong>HeaderCellCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IHeaderCell_interface">

IHeaderCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.HeaderFrameBase_class"></a><strong>HeaderFrameBase</strong><br>

Represents the protocol independent common implementation of any <a href="#TVA.PhasorProtocols.IHeaderFrame_interface">

IHeaderFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.HeaderFrameParsingState_class"></a><strong>HeaderFrameParsingState</strong><br>

Represents the protocol independent common implementation of the parsing state used by any

<a href="#TVA.PhasorProtocols.IHeaderFrame_interface">IHeaderFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IAnalogDefinition_interface"></a><strong>IAnalogDefinition</strong><br>

Represents a protocol independent interface representation of a definition of an <a href="#TVA.PhasorProtocols.IAnalogValue_interface">

IAnalogValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IAnalogValue_interface"></a><strong>IAnalogValue</strong><br>

Represents a protocol independent interface representation of an analog value.<br>

<br>

<a name="TVA.PhasorProtocols.IChannel_interface"></a><strong>IChannel</strong><br>

Represents a protocol independent interface representation of any data type that can be parsed or generated.<br>

This is the base interface implemented by all parsing/generating classes in the phasor protocols library; it is the root of the parsing/generating interface hierarchy.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelCell_interface"></a><strong>IChannelCell</strong><br>

Represents a protocol independent interface representation of any kind of <a href="#TVA.PhasorProtocols.IChannelFrame_interface">

IChannelFrame</a> cell.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelCellCollection_interface"></a><strong>IChannelCellCollection</strong><br>

Represents a protocol independent interface representation of a collection of <a href="#TVA.PhasorProtocols.IChannelCell_interface">

IChannelCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelCellParsingState_interface"></a><strong>IChannelCellParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state of any kind of

<a href="#TVA.PhasorProtocols.IChannelCell_interface">IChannelCell</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelCollection_interface"></a><strong>IChannelCollection</strong><br>

Represents a protocol independent interface representation of a collection of any

<a href="#TVA.PhasorProtocols.IChannel_interface">IChannel</a> objects.<br>

This is the base interface implemented by all collections classes in the phasor protocols library; it is the root of the collection interface hierarchy.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelDefinition_interface"></a><strong>IChannelDefinition</strong><br>

Represents a protocol independent interface representation of a definition of any kind of

<a href="#TVA.PhasorProtocols.IChannel_interface">IChannel</a> data.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelFrame_interface"></a><strong>IChannelFrame</strong><br>

Represents a protocol independent interface representation of any kind of frame of data that contains a collection of

<a href="#TVA.PhasorProtocols.IChannelCell_interface">IChannelCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelFrameParsingState_interface"></a><strong>IChannelFrameParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state of any kind of

<a href="#TVA.PhasorProtocols.IChannelFrame_interface">IChannelFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelParsingState_interface"></a><strong>IChannelParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state used by any kind of

<a href="#TVA.PhasorProtocols.IChannel_interface">IChannel</a> data.<br>

This is the base interface implemented by all parsing state classes in the phasor protocols library; it is the root of the parsing state interface hierarchy.<br>

<br>

<a name="TVA.PhasorProtocols.IChannelValue_interface"></a><strong>IChannelValue</strong><br>

Represents a protocol independent interface representation any kind of <a href="#TVA.PhasorProtocols.IChannel_interface">

IChannel</a> data value.<br>

<br>

<a name="TVA.PhasorProtocols.ICommandCell_interface"></a><strong>ICommandCell</strong><br>

Represents a protocol independent interface representation of any kind of <a href="#TVA.PhasorProtocols.ICommandFrame_interface">

ICommandFrame</a> cell.<br>

<br>

<a name="TVA.PhasorProtocols.ICommandFrame_interface"></a><strong>ICommandFrame</strong><br>

Represents a protocol independent interface representation of any kind of command frame that contains a collection of

<a href="#TVA.PhasorProtocols.ICommandCell_interface">ICommandCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.ICommandFrameParsingState_interface"></a><strong>ICommandFrameParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state of a

<a href="#TVA.PhasorProtocols.ICommandFrame_interface">ICommandFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IConfigurationCell_interface"></a><strong>IConfigurationCell</strong><br>

Represents a protocol independent interface representation of any kind of <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a> cell.<br>

<br>

<a name="TVA.PhasorProtocols.IConfigurationCellParsingState_interface"></a><strong>IConfigurationCellParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state of any kind of

<a href="#TVA.PhasorProtocols.IConfigurationCell_interface">IConfigurationCell</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IConfigurationFrame_interface"></a><strong>IConfigurationFrame</strong><br>

Represents a protocol independent interface representation of any kind of configuration frame that contains a collection of

<a href="#TVA.PhasorProtocols.IConfigurationCell_interface">IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.IConfigurationFrameParsingState_interface"></a><strong>IConfigurationFrameParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state of a

<a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">IConfigurationFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IConnectionParameters_interface"></a><strong>IConnectionParameters</strong><br>

Represents a protocol independent interface representation of custom connection parameters.<br>

<br>

<a name="TVA.PhasorProtocols.IDataCell_interface"></a><strong>IDataCell</strong><br>

Represents a protocol independent interface representation of any kind of <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> cell.<br>

<br>

<a name="TVA.PhasorProtocols.IDataCellParsingState_interface"></a><strong>IDataCellParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state of any kind of

<a href="#TVA.PhasorProtocols.IDataCell_interface">IDataCell</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IDataFrame_interface"></a><strong>IDataFrame</strong><br>

Represents a protocol independent interface representation of any kind of data frame that contains a collection of

<a href="#TVA.PhasorProtocols.IDataCell_interface">IDataCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.IDataFrameParsingState_interface"></a><strong>IDataFrameParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state of a

<a href="#TVA.PhasorProtocols.IDataFrame_interface">IDataFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IDigitalDefinition_interface"></a><strong>IDigitalDefinition</strong><br>

Represents a protocol independent interface representation of a definition of a <a href="#TVA.PhasorProtocols.IDigitalValue_interface">

IDigitalValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IDigitalValue_interface"></a><strong>IDigitalValue</strong><br>

Represents a protocol independent interface representation of a digital value.<br>

<br>

<a name="TVA.PhasorProtocols.IFrameParser_interface"></a><strong>IFrameParser</strong><br>

Represents a protocol independent representation of a frame parser.<br>

<br>

<a name="TVA.PhasorProtocols.IFrequencyDefinition_interface"></a><strong>IFrequencyDefinition</strong><br>

Represents a protocol independent interface representation of a definition of a <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IFrequencyValue_interface"></a><strong>IFrequencyValue</strong><br>

Represents a protocol independent interface of a frequency value.<br>

<br>

<a name="TVA.PhasorProtocols.IHeaderCell_interface"></a><strong>IHeaderCell</strong><br>

Represents a protocol independent interface representation of any kind of <a href="#TVA.PhasorProtocols.IHeaderFrame_interface">

IHeaderFrame</a> cell.<br>

<br>

<a name="TVA.PhasorProtocols.IHeaderFrame_interface"></a><strong>IHeaderFrame</strong><br>

Represents a protocol independent interface representation of any kind of header frame that contains a collection of

<a href="#TVA.PhasorProtocols.IHeaderCell_interface">IHeaderCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.IHeaderFrameParsingState_interface"></a><strong>IHeaderFrameParsingState</strong><br>

Represents a protocol independent interface representation of the parsing state of a

<a href="#TVA.PhasorProtocols.IHeaderFrame_interface">IHeaderFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IPhasorDefinition_interface"></a><strong>IPhasorDefinition</strong><br>

Represents a protocol independent interface representation of a definition of a <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IPhasorValue_interface"></a><strong>IPhasorValue</strong><br>

Represents a protocol independent interface representation of a phasor value.<br>

<br>

<a name="TVA.PhasorProtocols.LineFrequency_enumeration"></a><strong>LineFrequency</strong><br>

Nominal line frequencies enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.MultiProtocolFrameParser_class"></a><strong>MultiProtocolFrameParser</strong><br>

Protocol independent frame parser.<br>

<br>

<a name="TVA.PhasorProtocols.PhasorDataConcentratorBase_class"></a><strong>PhasorDataConcentratorBase</strong><br>

Represents an <a href="#TVA.Measurements.Routing.IActionAdapter_interface">IActionAdapter</a> used to generate and transmit concentrated stream of phasor measurements in a specific phasor protocol.<br>

<br>

<a name="TVA.PhasorProtocols.PhasorDefinitionBase_class"></a><strong>PhasorDefinitionBase</strong><br>

Represents the common implementation of the protocol independent definition of a <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.PhasorDefinitionCollection_class"></a><strong>PhasorDefinitionCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IPhasorDefinition_interface">

IPhasorDefinition</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.PhasorMeasurementMapper_class"></a><strong>PhasorMeasurementMapper</strong><br>

Represents an <a href="#TVA.Measurements.Routing.IInputAdapter_interface">IInputAdapter</a> used to map measured values from a connection to a phasor measurement device to new

<a href="#TVA.Measurements.IMeasurement_interface">IMeasurement</a> values.<br>

<br>

<a name="TVA.PhasorProtocols.PhasorProtocol_enumeration"></a><strong>PhasorProtocol</strong><br>

Phasor data protocols enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.PhasorType_enumeration"></a><strong>PhasorType</strong><br>

Phasor types enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.PhasorValueBase_class"></a><strong>PhasorValueBase</strong><br>

Represents the common implementation of the protocol independent representation of a phasor value.<br>

<br>

<a name="TVA.PhasorProtocols.PhasorValueCollection_class"></a><strong>PhasorValueCollection</strong><br>

Represents a protocol independent collection of <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.SignalReference_structure"></a><strong>SignalReference</strong><br>

Represents a signal that can be referenced by its constituent components.<br>

<br>

<a name="TVA.PhasorProtocols.SignalReferenceMeasurement_class"></a><strong>SignalReferenceMeasurement</strong><br>

Represents a basic <a href="#TVA.Measurements.IMeasurement_interface">IMeasurement</a> value that is associated with a given

<a href="#TVA.PhasorProtocols.SignalReference_structure">SignalReference</a>.<br>

<br>

<a name="TVA.PhasorProtocols.SignalType_enumeration"></a><strong>SignalType</strong><br>

Signal type enumeration.</p>

<hr>

<h4><a name="TVA.PhasorProtocols.Anonymous_namespace"></a>TVA.PhasorProtocols.Anonymous</h4>

<p>Contains a generic implementation of phasor classes used to represent phasor data that is not associated with any particular protocol.<br>

<br>

<a name="TVA.PhasorProtocols.Anonymous.AnalogDefinition_class"></a><strong>AnalogDefinition</strong><br>

Represents a protocol independent implementation of an <a href="#TVA.PhasorProtocols.IAnalogDefinition_interface">

IAnalogDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Anonymous.ConfigurationCell_class"></a><strong>ConfigurationCell</strong><br>

Represents a protocol independent implementation of a <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Anonymous.ConfigurationCellCollection_class"></a><strong>ConfigurationCellCollection</strong><br>

Represents a protocol independent implementation of a collection of <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.Anonymous.ConfigurationFrame_class"></a><strong>ConfigurationFrame</strong><br>

Represents a protocol independent implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Anonymous.DigitalDefinition_class"></a><strong>DigitalDefinition</strong><br>

Represents a protocol independent implementation of an <a href="#TVA.PhasorProtocols.IDigitalDefinition_interface">

IDigitalDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Anonymous.FrequencyDefinition_class"></a><strong>FrequencyDefinition</strong><br>

Represents a protocol independent implementation of a <a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">

IFrequencyDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Anonymous.PhasorDefinition_class"></a><strong>PhasorDefinition</strong><br>

Represents a protocol independent implementation of a <a href="#TVA.PhasorProtocols.IPhasorDefinition_interface">

IPhasorDefinition</a>.</p>

<hr>

<h4><a name="TVA.PhasorProtocols.BpaPdcStream_namespace"></a>BpaPdcStream</h4>

<p>Contains an implementation of the phasor classes used to parse or generate a stream of data in the BPA PDCstream format.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.AnalogDefinition_class"></a><strong>AnalogDefinition</strong><br>

Represents the BPA PDCstream implementation of an <a href="#TVA.PhasorProtocols.IAnalogDefinition_interface">

IAnalogDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.AnalogValue_class"></a><strong>AnalogValue</strong><br>

Represents the BPA PDCstream implementation of an <a href="#TVA.PhasorProtocols.IAnalogValue_interface">

IAnalogValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.ChannelFlags_enumeration"></a><strong>ChannelFlags</strong><br>

Channel flags enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.Common_class"></a><strong>Common</strong><br>

Common BPA PDCstream declarations and functions.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.CommonFrameHeader_class"></a><strong>CommonFrameHeader</strong><br>

Represents the common header for all BPA PDCstream frames of data.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.ConfigurationCell_class"></a><strong>ConfigurationCell</strong><br>

Represents the BPA PDCstream implementation of a <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.ConfigurationCellCollection_class"></a><strong>ConfigurationCellCollection</strong><br>

Represents a BPA PDCstream implementation of a collection of <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.ConfigurationFrame_class"></a><strong>ConfigurationFrame</strong><br>

Represents the BPA PDCstream implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.ConfigurationFrameParsingState_class"></a><strong>ConfigurationFrameParsingState</strong><br>

Represents the BPA PDCstream implementation of the parsing state used by a <a href="#TVA.PhasorProtocols.BpaPdcStream.ConfigurationFrame_class">

ConfigurationFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.ConnectionParameters_class"></a><strong>ConnectionParameters</strong><br>

Represents the extra connection parameters required for a connection to a BPA PDCstream.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.DataCell_class"></a><strong>DataCell</strong><br>

Represents the BPA PDCstream implementation of a <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.DataCellCollection_class"></a><strong>DataCellCollection</strong><br>

Represents a BPA PDCstream implementation of a collection of <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.DataFrame_class"></a><strong>DataFrame</strong><br>

Represents the BPA PDCstream implementation of a <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.DataFrameParsingState_class"></a><strong>DataFrameParsingState</strong><br>

Represents the BPA PDCstream protocol implementation of the parsing state used by a

<a href="#TVA.PhasorProtocols.BpaPdcStream.DataFrame_class">DataFrame</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.DigitalDefinition_class"></a><strong>DigitalDefinition</strong><br>

Represents the BPA PDCstream implementation of an <a href="#TVA.PhasorProtocols.IDigitalDefinition_interface">

IDigitalDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.DigitalValue_class"></a><strong>DigitalValue</strong><br>

Represents the BPA PDCstream implementation of an <a href="#TVA.PhasorProtocols.IDigitalValue_interface">

IDigitalValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.FormatFlags_enumeration"></a><strong>FormatFlags</strong><br>

Format flags enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.FrameParser_class"></a><strong>FrameParser</strong><br>

Represents a frame parser for a BPA PDCstream binary data stream and returns parsed data via events.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.FrameType_enumeration"></a><strong>FrameType</strong><br>

Frame type enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.FrequencyDefinition_class"></a><strong>FrequencyDefinition</strong><br>

Represents the BPA PDCstream implementation of a <a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">

IFrequencyDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.FrequencyValue_class"></a><strong>FrequencyValue</strong><br>

Represents the BPA PDCstream implementation of a <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.IniFileNameEditor_class"></a><strong>IniFileNameEditor</strong><br>

INI file name browser used with BPA PDCstream <a href="#TVA.PhasorProtocols.BpaPdcStream.ConnectionParameters_class">

ConnectionParameters</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.PhasorDefinition_class"></a><strong>PhasorDefinition</strong><br>

Represents the BPA PDCstream implementation of a <a href="#TVA.PhasorProtocols.IPhasorDefinition_interface">

IPhasorDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.PhasorValue_class"></a><strong>PhasorValue</strong><br>

Represents the BPA PDCstream implementation of a <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.PMUStatusFlags_enumeration"></a><strong>PMUStatusFlags</strong><br>

PMU status flags enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.ReservedFlags_enumeration"></a><strong>ReservedFlags</strong><br>

Reserved flags enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.RevisionNumber_enumeration"></a><strong>RevisionNumber</strong><br>

Stream revision number enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.BpaPdcStream.StreamType_enumeration"></a><strong>StreamType</strong><br>

Stream type enueration.</p>

<hr>

<h4><a name="TVA.PhasorProtocols.FNet_namespace"></a>TVA.PhasorProtocols.FNet</h4>

<p>Contains an implementation of the phasor classes used to parse or generate a stream of data in the F-NET device format.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.Common_class"></a><strong>Common</strong><br>

Common F-NET declarations and functions.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.CommonFrameHeader_class"></a><strong>CommonFrameHeader</strong><br>

Represents the common header for a F-NET frame of data.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.ConfigurationCell_class"></a><strong>ConfigurationCell</strong><br>

Represents the F-NET implementation of a <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.ConfigurationCellCollection_class"></a><strong>ConfigurationCellCollection</strong><br>

Represents a F-NET implementation of a collection of <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.ConfigurationFrame_class"></a><strong>ConfigurationFrame</strong><br>

Represents the F-NET implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.ConnectionParameters_class"></a><strong>ConnectionParameters</strong><br>

Represents the extra connection parameters required for a connection to a F-NET device.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.DataCell_class"></a><strong>DataCell</strong><br>

Represents the F-NET implementation of a <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.DataCellCollection_class"></a><strong>DataCellCollection</strong><br>

Represents a F-NET implementation of a collection of <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.DataFrame_class"></a><strong>DataFrame</strong><br>

Represents the F-NET implementation of a <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.FrameParser_class"></a><strong>FrameParser</strong><br>

Represents a frame parser for a F-NET text based data stream that returns parsed data via events.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.FrequencyDefinition_class"></a><strong>FrequencyDefinition</strong><br>

Represents the F-NET implementation of a <a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">

IFrequencyDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.FrequencyValue_class"></a><strong>FrequencyValue</strong><br>

Represents the F-NET implementation of a <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.PhasorDefinition_class"></a><strong>PhasorDefinition</strong><br>

Represents the F-NET implementation of a <a href="#TVA.PhasorProtocols.IPhasorDefinition_interface">

IPhasorDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.FNet.PhasorValue_class"></a><strong>PhasorValue</strong><br>

Represents the F-NET implementation of a <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a>.</p>

<hr>

<h4><a name="TVA.PhasorProtocols.Ieee1344_namespace"></a>Ieee1344</h4>

<p>Contains an implementation of the phasor classes used to parse or generate a stream of data in the IEEE 1344-1995 standard format.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.CommandFrame_class"></a><strong>CommandFrame</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.ICommandFrame_interface">

ICommandFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.Common_class"></a><strong>Common</strong><br>

Common IEEE 1344 declarations and functions.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.CommonFrameHeader_class"></a><strong>CommonFrameHeader</strong><br>

Represents the common header for all IEEE 1344 frames of data.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.ConfigurationCell_class"></a><strong>ConfigurationCell</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.ConfigurationCellCollection_class"></a><strong>ConfigurationCellCollection</strong><br>

Represents a IEEE 1344 implementation of a collection of <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.ConfigurationFrame_class"></a><strong>ConfigurationFrame</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.DataCell_class"></a><strong>DataCell</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.DataCellCollection_class"></a><strong>DataCellCollection</strong><br>

Represents a IEEE 1344 implementation of a collection of <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.DataFrame_class"></a><strong>DataFrame</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.DigitalDefinition_class"></a><strong>DigitalDefinition</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IDigitalDefinition_interface">

IDigitalDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.DigitalValue_class"></a><strong>DigitalValue</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IDigitalValue_interface">

IDigitalValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.FrameImageCollector_class"></a><strong>FrameImageCollector</strong><br>

Collects frame images until a full IEEE 1344 frame has been received.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.FrameParser_class"></a><strong>FrameParser</strong><br>

Represents a frame parser for an IEEE 1344 binary data stream that returns parsed data via events.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.FrameType_enumeration"></a><strong>FrameType</strong><br>

IEEE 1344 frame types enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.FrequencyDefinition_class"></a><strong>FrequencyDefinition</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">

IFrequencyDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.FrequencyValue_class"></a><strong>FrequencyValue</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.HeaderFrame_class"></a><strong>HeaderFrame</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IHeaderFrame_interface">

IHeaderFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.PhasorDefinition_class"></a><strong>PhasorDefinition</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IPhasorDefinition_interface">

IPhasorDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.PhasorValue_class"></a><strong>PhasorValue</strong><br>

Represents the IEEE 1344 implementation of a <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Ieee1344.TriggerStatus_enumeration"></a><strong>TriggerStatus</strong><br>

IEEE 1344 trigger status enumeration.</p>

<hr>

<h4><a name="TVA.PhasorProtocols.IeeeC37_118_namespace"></a>TVA.PhasorProtocols.IeeeC37_118</h4>

<p>Contains an implementation of the phasor classes used to parse or generate a stream of data in the IEEE C37.118-2005 standard format.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.AnalogDefinition_class"></a><strong>AnalogDefinition</strong><br>

Represents the IEEE C37.118 implementation of an <a href="#TVA.PhasorProtocols.IAnalogDefinition_interface">

IAnalogDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.AnalogValue_class"></a><strong>AnalogValue</strong><br>

Represents the IEEE C37.118 implementation of an <a href="#TVA.PhasorProtocols.IAnalogValue_interface">

IAnalogValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.CommandFrame_class"></a><strong>CommandFrame</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.ICommandFrame_interface">

ICommandFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.Common_class"></a><strong>Common</strong><br>

Common IEEE C37.118 declarations and functions.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.CommonFrameHeader_class"></a><strong>CommonFrameHeader</strong><br>

Represents the common header for all IEEE C37.118 frames of data.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.Concentrator_class"></a><strong>Concentrator</strong><br>

Represents an IEEE C37.118 phasor data concentrator.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.ConfigurationCell_class"></a><strong>ConfigurationCell</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.ConfigurationCellCollection_class"></a><strong>ConfigurationCellCollection</strong><br>

Represents a IEEE C37.118 implementation of a collection of <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.ConfigurationFrame1_class"></a><strong>ConfigurationFrame1</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a>, type 1, that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.ConfigurationFrame1Draft6_class"></a><strong>ConfigurationFrame1Draft6</strong><br>

Represents the IEEE C37.118 draft 6 implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a>, type 1, that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.ConfigurationFrame2_class"></a><strong>ConfigurationFrame2</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a>, type 2, that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.ConfigurationFrame2Draft6_class"></a><strong>ConfigurationFrame2Draft6</strong><br>

Represents the IEEE C37.118 draft 6 implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a>, type 2, that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.DataCell_class"></a><strong>DataCell</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.DataCellCollection_class"></a><strong>DataCellCollection</strong><br>

Represents a IEEE C37.118 implementation of a collection of <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.DataFrame_class"></a><strong>DataFrame</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.DigitalDefinition_class"></a><strong>DigitalDefinition</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IDigitalDefinition_interface">

IDigitalDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.DigitalValue_class"></a><strong>DigitalValue</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IDigitalValue_interface">

IDigitalValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.DraftRevision_enumeration"></a><strong>DraftRevision</strong><br>

Protocol draft revision numbers enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.FormatFlags_enumeration"></a><strong>FormatFlags</strong><br>

Data format flags enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.FrameParser_class"></a><strong>FrameParser</strong><br>

Represents a frame parser for an IEEE C37.118 binary data stream and returns parsed data via events.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.FrameType_enumeration"></a><strong>FrameType</strong><br>

IEEE C37.118 frame types enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.FrequencyDefinition_class"></a><strong>FrequencyDefinition</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">

IFrequencyDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.FrequencyValue_class"></a><strong>FrequencyValue</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.HeaderFrame_class"></a><strong>HeaderFrame</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IHeaderFrame_interface">

IHeaderFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.PhasorDefinition_class"></a><strong>PhasorDefinition</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IPhasorDefinition_interface">

IPhasorDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.PhasorValue_class"></a><strong>PhasorValue</strong><br>

Represents the IEEE C37.118 implementation of a <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.StatusFlags_enumeration"></a><strong>StatusFlags</strong><br>

Status flags enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.TimeQualityFlags_enumeration"></a><strong>TimeQualityFlags</strong><br>

Time quality flags enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.TimeQualityIndicatorCode_enumeration"></a><strong>TimeQualityIndicatorCode</strong><br>

Time quality indicator code enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.TriggerReason_enumeration"></a><strong>TriggerReason</strong><br>

Trigger reason enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.IeeeC37_118.UnlockedTime_enumeration"></a><strong>UnlockedTime</strong><br>

Unlocked time enumeration.</p>

<hr>

<h4><a name="TVA.PhasorProtocols.Macrodyne_namespace"></a><strong>Macrodyne</strong></h4>

<p>Contains an implementation of the phasor classes used to parse or generate a stream of data in the Macrodyne PMU device format.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.ClockStatusFlags_enumeration"></a><strong>ClockStatusFlags</strong><br>

Macrodyne clock status flags enumeration (from byte 1 in time string).<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.CommandFrame_class"></a><strong>CommandFrame</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.ICommandFrame_interface">

ICommandFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.Common_class"></a><strong>Common</strong><br>

Common Macrodyne declarations and functions.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.CommonFrameHeader_class"></a><strong>CommonFrameHeader</strong><br>

Represents the common header for all Macrodyne frames of data.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.ConfigurationCell_class"></a><strong>ConfigurationCell</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.ConfigurationCellCollection_class"></a><strong>ConfigurationCellCollection</strong><br>

Represents a Macrodyne implementation of a collection of <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.ConfigurationFrame_class"></a><strong>ConfigurationFrame</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.DataCell_class"></a><strong>DataCell</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.DataCellCollection_class"></a><strong>DataCellCollection</strong><br>

Represents a Macrodyne implementation of a collection of <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.DataFrame_class"></a><strong>DataFrame</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.DataInputCommand_enumeration"></a><strong>DataInputCommand</strong><br>

Macrodyne data input commands enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.DeviceCommand_enumeration"></a><strong>DeviceCommand</strong><br>

Macrodyne set and request commands enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.DevicePort_enumeration"></a><strong>DevicePort</strong><br>

Macrodyne device ports enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.DigitalDefinition_class"></a><strong>DigitalDefinition</strong><br>

Represents the Macrodyne implementation of an <a href="#TVA.PhasorProtocols.IDigitalDefinition_interface">

IDigitalDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.DigitalValue_class"></a><strong>DigitalValue</strong><br>

Represents the Macrodyne implementation of an <a href="#TVA.PhasorProtocols.IDigitalValue_interface">

IDigitalValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.FrameParser_class"></a><strong>FrameParser</strong><br>

Represents a frame parser for a Macrodyne binary data stream that returns parsed data via events.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.FrequencyDefinition_class"></a><strong>FrequencyDefintion</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">

IFrequencyDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.FrequencyValue_class"></a><strong>FrequencyValue</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.GpsStatus_enumeration"></a><strong>GpsStatus</strong><br>

Macrodyne GPS status enumeration (from Status 2 byte, bits 3-4).<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.OnlineDataFormatFlags_enumeration"></a><strong>OnlineDataFormatFlags</strong><br>

Macrodyne ON-LINE data format flags enumeration (from RequestOnlineDataFormat 2 byte response).<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.OperationalLimitFlags_enumeration"></a><strong>OperationalLimitFlags</strong><br>

Macrodyne operational limit reached flags enumeration (from RequestOperationalLimitFlags first byte of 3 byte response).<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.PhasorDefinition_class"></a><strong>PhasorDefinition</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.IPhasorDefinition_interface">

IPhasorDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.PhasorValue_class"></a><strong>PhasorValue</strong><br>

Represents the Macrodyne implementation of a <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.StatusFlags_enumeration"></a><strong>StatusFlags</strong><br>

Macrodyne status flags enumeration (from Status 1 byte).<br>

<br>

<a name="TVA.PhasorProtocols.Macrodyne.TriggerReason_enumeration"></a><strong>TriggerReason</strong><br>

Macrodyne trigger reason enumeration (from Status 2 byte, bits 0-2).</p>

<hr>

<h4><a name="TVA.PhasorProtocols.SelFastMessage_namespace"></a><strong>SelFastMessage</strong></h4>

<p>Contains an implementation of the phasor classes used to parse or generate a stream of data in the SEL Fast Message format used by a variety of SEL devices.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.CommandFrame_class"></a><strong>CommandFrame</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.ICommandFrame_interface">

ICommandFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.Common_class"></a><strong>Common</strong><br>

Common SEL Fast Message declarations and functions.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.CommonFrameHeader_class"></a><strong>CommonFrameHeader</strong><br>

Represents the common header for all SEL Fast Message frames of data.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.ConfigurationCell_class"></a><strong>ConfigurationCell</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.ConfigurationCellCollection_class"></a><strong>ConfigurationCellCollection</strong><br>

Represents a SEL Fast Message implementation of a collection of <a href="#TVA.PhasorProtocols.IConfigurationCell_interface">

IConfigurationCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.ConfigurationFrame_class"></a><strong>ConfigurationFrame</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.IConfigurationFrame_interface">

IConfigurationFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.ConnectionParameters_class"></a><strong>ConnectionParameters</strong><br>

Represents the extra connection parameters required for a connection to a SEL device.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.DataCell_class"></a><strong>DataCell</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.DataCellCollection_class"></a><strong>DataCellCollection</strong><br>

Represents a SEL Fast Message implementation of a collection of <a href="#TVA.PhasorProtocols.IDataCell_interface">

IDataCell</a> objects.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.DataFrame_class"></a><strong>DataFrame</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.IDataFrame_interface">

IDataFrame</a> that can be sent or received.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.DeviceCommand_enumeration"></a><strong>DeviceCommand</strong><br>

SEL Fast Message device commands enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.FrameParser_class"></a><strong>FrameParser</strong><br>

Represents a frame parser for a SEL Fast Message binary data stream that returns parsed data via events.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.FrameSize_enumeration"></a><strong>FrameSize</strong><br>

SEL Fast Message PMDATA setting frame size enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.FrequencyDefinition_class"></a><strong>FrequencyDefinition</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.IFrequencyDefinition_interface">

IFrequencyDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.FrequencyValue_class"></a><strong>FrequencyValue</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.IFrequencyValue_interface">

IFrequencyValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.MessagePeriod_enumeration"></a><strong>MessagePeriod</strong><br>

SEL Fast Message frame rate enumeration.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.PhasorDefinition_class"></a><strong>PhasorDefinition</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.ICommandFrame_interface">

IPhasorDefinition</a>.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.PhasorValue_class"></a><strong>PhasorValue</strong><br>

Represents the SEL Fast Message implementation of a <a href="#TVA.PhasorProtocols.IPhasorValue_interface">

IPhasorValue</a>.<br>

<br>

<a name="TVA.PhasorProtocols.SelFastMessage.StatusFlags_enumeration"></a><strong>StatusFlags</strong><br>

SEL Fast Message status word flags enumeration.</p>

<hr>

<h2><a name="phasor_protocol_relationship_diagrams"></a>Phasor Protocol Relationship Diagrams</h2>

<h3><a name="analog_definition_relationships"></a>Analog Definition Relationships</h3>

<p><img title="Analog Definition Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Analog_Definition_Relationships_Small.jpg" alt="Analog Definition Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Analog_Definition_Relationships.jpg">Click for larger image</a></p>

<h3><a name="analog_value_relationships"></a>Analog Value Relationships</h3>

<p><img title="Analog Value Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Analog_Value_Relationships_Small.jpg" alt="Analog Value Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Analog_Value_Relationships.jpg">Click for larger image</a></p>

<h3><a name="command_cell_collection_relationships"></a>CommandCell Collection Relationships</h3>

<p><img title="CommandCell Collection Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/CommandCell_Collection_Relationships_Small.jpg" alt="CommandCell Collection Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/CommandCell_Collection_Relationships.jpg">Click for larger image</a></p>

<h3><a name="command_cell_relationships"></a>CommandCell Relationships</h3>

<p><img title="CommandCell Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/CommandCell_Relationships_Small.jpg" alt="CommandCell Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/CommandCell_Relationships.jpg">Click for larger image</a></p>

<h3><a name="command_frame_relationships"></a>CommandFrame Relationships</h3>

<p><img title="CommandFrame Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/CommandFrame_Relationships_Small.jpg" alt="CommandFrame Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/CommandFrame_Relationships.jpg">Click for larger image</a></p>

<h3><a name="configuration_cell_collection_relationships"></a>ConfigurationCell Collection Relationships</h3>

<p><img title="ConfigurationCell Collection Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/ConfigurationCell_Collection_Relationships_Small.jpg" alt="ConfigurationCell Collection Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/ConfigurationCell_Collection_Relationships.jpg">Click for larger image</a></p>

<h3><a name="configuration_cell_relationships"></a>ConfigurationCell Relationships</h3>

<p><img title="ConfigurationCell Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/ConfigurationCell_Relationships_Small.jpg" alt="ConfigurationCell Relationships Small.jpg" width="768" height="479"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/ConfigurationCell_Relationships.jpg">Click for larger image</a></p>

<h3><a name="configuration_frame_relationships"></a>ConfigurationFrame Relationships</h3>

<p><img title="ConfigurationFrame Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/ConfigurationFrame_Relationships_Small.jpg" alt="ConfigurationFrame Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/ConfigurationFrame_Relationships.jpg">Click for larger image</a></p>

<h3><a name="data_cell_collection_relationships"></a>DataCell Collection Relationships</h3>

<p><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/DataCell_Collection_Relationships_Small.jpg" alt=""><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/DataCell_Collection_Relationships.jpg">Click for larger image</a></p>

<h3><a name="data_cell_relationships"></a>DataCell Relationships</h3>

<p><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/DataCell_Relationships_Small.jpg" alt=""><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/DataCell_Relationships.jpg">Click for larger image</a></p>

<h3><a name="data_frame_relationships"></a>DataFrame Relationships</h3>

<p><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/DataFrame_Relationships_Small.jpg" alt=""><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/DataFrame_Relationships.jpg">Click for larger image</a></p>

<h3><a name="digital_definition_relationships"></a>Digital Definition Relationships</h3>

<p><img title="Digital Definition Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Digital_Definition_Relationships_Small.jpg" alt="Digital Definition Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Digital_Definition_Relationships.jpg">Click for larger image</a></p>

<h3><a name="digital_value_relationships"></a>Digital Value Relationships</h3>

<p><img title="Digital Value Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Digital_Value_Relationships_Small.jpg" alt="Digital Value Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Digital_Value_Relationships.jpg">Click for larger image</a></p>

<h3><a name="frame_parser_relationships"></a>FrameParser Relationships</h3>

<p><img title="FrameParser Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/FrameParser_Relationships_Small.jpg" alt="FrameParser Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/FrameParser_Relationships.jpg">Click for larger image</a></p>

<h3><a name="frequency_definition_relationships"></a>Frequency Definition Relationships</h3>

<p><img title="Frequency Definition Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Frequency_Definition_Relationships_Small.jpg" alt="Frequency Definition Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Frequency_Definition_Relationships.jpg">Click for larger image</a></p>

<h3><a name="frequency_value_relationships"></a>Frequency Value Relationships</h3>

<p><img title="Frequency Value Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Frequency_Value_Relationships_Small.jpg" alt="Frequency Value Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Frequency_Value_Relationships.jpg">Click for larger image</a></p>

<h3><a name="header_cell_collection_relationship"></a>HeaderCell Collection Relationships</h3>

<p><img title="HeaderCell Collection Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/HeaderCell_Collection_Relationships_Small.jpg" alt="HeaderCell Collection Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/HeaderCell_Collection_Relationships.jpg">Click for larger image</a></p>

<h3><a name="header_cell_relationships"></a>HeaderCell Relationships</h3>

<p><img title="HeaderCell Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/HeaderCell_Relationships_Small.jpg" alt="HeaderCell Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/HeaderCell_Relationships.jpg">Click for larger image</a></p>

<h3><a name="header_frame_relationships"></a>HeaderFrame Relationships</h3>

<p><img title="HeaderFrame Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/HeaderFrame_Relationships_Small.jpg" alt="HeaderFrame Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/HeaderFrame_Relationships.jpg">Click for larger image</a></p>

<h3><a name="phasor_definition_relationships"></a>Phasor Definition Relationships</h3>

<p><img title="Phasor Definition Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Phasor_Definition_Relationships_Small.jpg" alt="Phasor Definition Relationships Small.jpg" width="768" height="490"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Phasor_Definition_Relationships.jpg">Click for larger image</a></p>

<h3><a name="phasor_value_relationships"></a>Phasor Value Relationships</h3>

<p><img title="Phasor Value Relationships Small.jpg" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Phasor_Value_Relationships_Small.jpg" alt="Phasor Value Relationships Small.jpg"><br>

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_About_the_Code.files/Phasor_Value_Relationships.jpg">Click for larger image</a></p>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="6/22/2012 1:52:42 PM" LocalTimeTicks="1340398362">Jun 22, 2012 at 1:52 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/alexfoglia.md">alexfoglia</a>, version 5<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=About%20the%20Code%20%28Developers%29">CodePlex</a> Oct 5, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


