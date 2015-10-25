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
<h1>How to Manually Configure the openPDC</h1>
This guide is designed to assist you in configuring the openPDC to gather data from your devices and transmit that data to other devices or applications. The following sections will go over which tables you will need to edit and explain the relevant column
 values. Any columns that are not specified are not necessary for simple configurations and can be left with their default values.<br>
<br>
Before you begin your configuration, please note that this guide assumes you are using only the InitialDataSet in your database; not the SampleDataSet. In the case of SQLite, this means using the &quot;openPDC-InitialDataSet.db&quot; file instead of the &quot;openPDC-SampleDataSet.db&quot;
 file. In the case of SQL Server and MySQL, it means running only the &quot;openPDC.sql&quot; and &quot;InitialDataSet.sql&quot; files when you set up your database.<br>
<br>
If you need to reset your database in order to do this, please read the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md#reset_database">
FAQ</a>. However, you are strongly encouraged to use the SampleDataSet as an example to help you understand how to configure your database.<br>
<ul>
<li><a href="#configure_input">Configuring inputs</a>
<ul>
<li><a href="#Node_table">The Node table</a>
<ul>
<li><a href="#Node.ID_column">The ID column</a> </li><li><a href="#Node.Name_column">The Name column</a> </li><li><a href="#Node.CompanyID_column">The CompanyID column</a> </li><li><a href="#Node.Description_column">The Description column</a> </li><li><a href="#Node.Master_column">The Master column</a> </li><li><a href="#Node.Enabled_column">The Enabled column</a></li></ul>
</li><li><a href="#Historian_table">The Historian table</a>
<ul>
<li><a href="#Historian.NodeID_column">The NodeID column</a> </li><li><a href="#Historian.ID_column">The ID column</a> </li><li><a href="#Historian.Acronym_column">The Acronym column</a> </li><li><a href="#Historian.Name_column">The Name column</a> </li><li><a href="#Historian.AssemblyName_column">The AssemblyName column</a> </li><li><a href="#Historian.TypeName_column">The TypeName column</a> </li><li><a href="#Historian.IsLocal_column">The IsLocal column</a> </li><li><a href="#Historian.Enabled_column">The Enabled column</a></li></ul>
</li><li><a href="#Device_table">The Device table</a>
<ul>
<li><a href="#Device.NodeID_column">The NodeID column</a> </li><li><a href="#Device.ID_column">The ID column</a> </li><li><a href="#Device.ParentID_column">The ParentID column</a> </li><li><a href="#Device.Acronym_column">The Acronym column</a> </li><li><a href="#Device.Name_column">The Name column</a> </li><li><a href="#Device.IsConcentrator_column">The IsConcentrator column</a> </li><li><a href="#Device.CompanyID_column">The CompanyID column</a> </li><li><a href="#Device.HistorianID_column">The HistorianID column</a> </li><li><a href="#Device.AccessID_column">The AccessID column</a> </li><li><a href="#Device.ProtocolID_column">The ProtocolID column</a> </li><li><a href="#Device.ConnectionString_column">The ConnectionString column</a> </li><li><a href="#Device.Enabled_column">The Enabled column</a></li></ul>
</li><li><a href="#Phasor_table">The Phasor table</a>
<ul>
<li><a href="#Phasor.ID_column">The ID column</a> </li><li><a href="#Phasor.DeviceID_column">The DeviceID column</a> </li><li><a href="#Phasor.Label_column">The Label column</a> </li><li><a href="#Phasor.Type_column">The Type column</a> </li><li><a href="#Phasor.Phase_column">The Phase column</a> </li><li><a href="#Phasor.SourceIndex_column">The SourceIndex column</a></li></ul>
</li><li><a href="#Measurement_table">The Measurement table</a>
<ul>
<li><a href="#Measurement.SignalID_column">The SignalID column</a> </li><li><a href="#Measurement.HistorianID_column">The HistorianID column</a> </li><li><a href="#Measurement.PointID_column">The PointID column</a> </li><li><a href="#Measurement.DeviceID_column">The DeviceID column</a> </li><li><a href="#Measurement.PointTag_column">The PointTag column</a> </li><li><a href="#Measurement.SignalTypeID_column">The SignalTypeID column</a> </li><li><a href="#Measurement.PhasorSourceIndex_column">The PhasorSourceIndex column</a>
</li><li><a href="#Measurement.SignalReference_column">The SignalReference column</a>
</li><li><a href="#Measurement.Description_column">The Description column</a> </li><li><a href="#Measurement.Enabled_column">The Enabled column</a></li></ul>
</li></ul>
</li><li><a href="#configure_output">Configuring outputs</a>
<ul>
<li><a href="#OutputStream_table">The OutputStream table</a>
<ul>
<li><a href="#OutputStream.NodeID_column">The NodeID column</a> </li><li><a href="#OutputStream.ID_column">The ID column</a> </li><li><a href="#OutputStream.Acronym_column">The Acronym column</a> </li><li><a href="#OutputStream.Name_column">The Name column</a> </li><li><a href="#OutputStream.Type_column">The Type column</a> </li><li><a href="#OutputStream.ConnectionString_column">The ConnectionString column</a>
</li><li><a href="#OutputStream.DataChannel_column">The DataChannel column</a> </li><li><a href="#OutputStream.CommandChannel_column">The CommandChannel column</a>
</li><li><a href="#OutputStream.IDCode_column">The IDCode column</a> </li><li><a href="#OutputStream.UseLocalClockAsRealTime_column">The UseLocalClockAsRealTime column</a>
</li><li><a href="#OutputStream.Enabled_column">The Enabled column</a></li></ul>
</li><li><a href="#OutputStreamDevice_table">The OutputStreamDevice table</a>
<ul>
<li><a href="#OutputStreamDevice.NodeID_column">The NodeID column</a> </li><li><a href="#OutputStreamDevice.AdapterID_column">The AdapterID column</a> </li><li><a href="#OutputStreamDevice.ID_column">The ID column</a> </li><li><a href="#OutputStreamDevice.Acronym_column">The Acronym column</a> </li><li><a href="#OutputStreamDevice.BpaAcronym_column">The BpaAcronym column</a> </li><li><a href="#OutputStreamDevice.Name_column">The Name column</a> </li><li><a href="#OutputStreamDevice.Enabled_column">The Enabled column</a></li></ul>
</li><li><a href="#OutputStreamDeviceAnalog_table">The OutputStreamDeviceAnalog table</a>
<ul>
<li><a href="#OutputStreamDeviceAnalog.NodeID_column">The NodeID column</a> </li><li><a href="#OutputStreamDeviceAnalog.OutputStreamDeviceID_column">The OutputStreamDeviceID column</a>
</li><li><a href="#OutputStreamDeviceAnalog.ID_column">The ID column</a> </li><li><a href="#OutputStreamDeviceAnalog.Label_column">The Label column</a> </li><li><a href="#OutputStreamDeviceAnalog.Type_column">The Type column</a></li></ul>
</li><li><a href="#OutputStreamDeviceDigital_table">The OutputStreamDeviceDigital table</a>
<ul>
<li><a href="#OutputStreamDeviceDigital.NodeID_column">The NodeID column</a> </li><li><a href="#OutputStreamDeviceDigital.OutputStreamDeviceID_column">The OutputStreamDeviceID column</a>
</li><li><a href="#OutputStreamDeviceDigital.ID_column">The ID column</a> </li><li><a href="#OutputStreamDeviceDigital.Label_column">The Label column</a></li></ul>
</li><li><a href="#OutputStreamDevicePhasor_table">The OutputStreamDevicePhasor table</a>
<ul>
<li><a href="#OutputStreamDevicePhasor.NodeID_column">The NodeID column</a> </li><li><a href="#OutputStreamDevicePhasor.OutputStreamDeviceID_column">The OutputStreamDeviceID column</a>
</li><li><a href="#OutputStreamDevicePhasor.ID_column">The ID column</a> </li><li><a href="#OutputStreamDevicePhasor.Label_column">The Label column</a> </li><li><a href="#OutputStreamDevicePhasor.Type_column">The Type column</a> </li><li><a href="#OutputStreamDevicePhasor.Phase_column">The Phase column</a></li></ul>
</li><li><a href="#OutputStreamMeasurement_table">The OutputStreamMeasurement table</a>
<ul>
<li><a href="#OutputStreamMeasurement.NodeID_column">The NodeID column</a> </li><li><a href="#OutputStreamMeasurement.AdapterID_column">The AdapterID column</a>
</li><li><a href="#OutputStreamMeasurement.ID_column">The ID column</a> </li><li><a href="#OutputStreamMeasurement.HistorianID_column">The HistorianID column</a>
</li><li><a href="#OutputStreamMeasurement.PointID_column">The PointID column</a> </li><li><a href="#OutputStreamMeasurement.SignalReference_column">The SignalReference column</a></li></ul>
</li></ul>
</li><li><a href="#trouble">Troubleshooting</a></li></ul>
<hr>
<h2><a name="configure_input"></a>Configuring inputs</h2>
This section will go over all the tables you will need to modify in your openPDC database in order to receive data from your devices.<br>
<h3><a name="Node_table"></a>The Node table</h3>
This table contains information about the openPDC instances using the database. You will most likely only need to enter one record into this table. If you have multiple instances of the openPDC using your openPDC database, you will need to add a record for
 each of them.<br>
<h4><a name="Node.ID_column"></a>The ID column</h4>
The ID column is a GUID used to identify each of the nodes. The values in this column are generated automatically. Once the value has been generated, you will need to copy it to your openPDC configuration file. The file is located in the &quot;SOURCEDIR\Synchrophasor\Current
 Version\Build\Output\Debug\Applications\openPDC&quot; folder. The file is called openPDC.exe.config.<br>
<b>Note</b>: Aside from the configuration file, there are several other places in the database where you will need to specify the ID of your node so you may want to keep it in a place that is easily accessible as you configure the system.<br>
<br>
Enter the node ID in the value attribute of the following tag.<br>
<b>Note</b>: Access places brackets around the GUID. These are necessary in the database, but you should not include them in the configuration file.<br>
<div style="color:Black; background-color:White">
<pre>
<span style="color:Blue">&lt;</span><span style="color:#A31515">configuration</span><span style="color:Blue">&gt;</span>
  <span style="color:Blue">&lt;</span><span style="color:#A31515">categorizedSettings</span><span style="color:Blue">&gt;</span>
    <span style="color:Blue">&lt;</span><span style="color:#A31515">systemSettings</span><span style="color:Blue">&gt;</span>
      <span style="color:Blue">&lt;</span><span style="color:#A31515">add</span> <span style="color:Red">name</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">NodeID</span><span style="color:Black">&quot;</span> <span style="color:Red">value</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">[NodeID]</span><span style="color:Black">&quot;</span>
        <span style="color:Red">description</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">Unique Node ID</span><span style="color:Black">&quot;</span> <span style="color:Red">encrypted</span><span style="color:Blue">=</span><span style="color:Black">&quot;</span><span style="color:Blue">false</span><span style="color:Black">&quot;</span> <span style="color:Blue">/&gt;</span>
    <span style="color:Blue">&lt;/</span><span style="color:#A31515">systemSettings</span><span style="color:Blue">&gt;</span>
  <span style="color:Blue">&lt;/</span><span style="color:#A31515">categorizedSettings</span><span style="color:Blue">&gt;</span>
<span style="color:Blue">&lt;/</span><span style="color:#A31515">configuration</span><span style="color:Blue">&gt;</span>
</pre>
</div>
<h4><a name="Node.Name_column"></a>The Name column</h4>
Enter a name by which you can identify the openPDC instance.<br>
<h4><a name="Node.CompanyID_column"></a>The CompanyID column</h4>
The values in this column should come from the <u>ID</u> column of the <u>Company</u> table.<br>
<h4><a name="Node.Description_column"></a>The Description column</h4>
Enter a short description of the node.<br>
<h4><a name="Node.Master_column"></a>The Master column</h4>
This should be true for one of your nodes. The rest of the nodes should be false. It will determine which node to access by default when using the openPDCManager.<br>
<h4><a name="Node.Enabled_column"></a>The Enabled column</h4>
This column enables or disables the node in the openPDCManager. You will typically want to set this value to true.<br>
<hr>
<h3><a name="Historian_table"></a>The Historian table</h3>
All measurements that enter the openPDC are archived by a historian. This section will guide you in setting up the default local historian.<br>
<h4><a name="Historian.NodeID_column"></a>The NodeID column</h4>
Enter the ID of your node into this column. The values in this column should come from the
<a href="#Node.ID_column">ID</a> column in the <a href="#Node_table">Node</a> table.<br>
<h4><a name="Historian.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="Historian.Acronym_column"></a>The Acronym column</h4>
Enter the Acronym to be used to identify the historian within the program. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore (_) is the only special character allowed. You can enter a maximum of 16
 characters.<br>
<h4><a name="Historian.Name_column"></a>The Name column</h4>
Enter a name by which you can identify the historian.<br>
<h4><a name="Historian.AssemblyName_column"></a>The AssemblyName column</h4>
Enter the name of the dll for the historian. The dll should be located in the openPDC output folder (&quot;SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\Applications\openPDC&quot; where SOURCEDIR is the root directory of the openPDC source). The
 assembly name of the default local historian is &quot;HistorianAdapters.dll&quot;.<br>
<h4><a name="Historian.TypeName_column"></a>The TypeName column</h4>
This specifies the type of the historian. The default local historian is of type &quot;HistorianAdapters.LocalOutputAdapter&quot;.<br>
<h4><a name="Historian.IsLocal_column"></a>The IsLocal column</h4>
Should be self-explanatory. Set this to true for the default local historian.<br>
<h4><a name="Historian.Description_column"></a>The Description column</h4>
Enter a short description of the historian.<br>
<h4><a name="Historian.Enabled_column"></a>The Enabled column</h4>
If you are going to attempt to connect to your historian through the openPDC, you need to have it enabled. Set this column to true.<br>
<hr>
<h3><a name="Device_table"></a>The Device table</h3>
This table contains information about the devices sending data to an instance of the openPDC. Devices can be PMUs or PDCs. PMUs that are connected through an intermediary PDC should also be present in this table.<br>
<h4><a name="Device.NodeID_column"></a>The NodeID column</h4>
Enter the ID of your node into this column. The values in this column should come from the
<a href="#Node.ID_column">ID</a> column in the <a href="#Node_table">Node</a> table.<br>
<h4><a name="Device.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="Device.ParentID_column"></a>The ParentID column</h4>
For PMUs that are connected through an intermediary PDC, enter the ID of the intermediary PDC into this column. Leave it blank for all other devices.<br>
<h4><a name="Device.Acronym_column"></a>The Acronym column</h4>
Enter the Acronym to be used to identify the device within the program. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore (_) is the only special character allowed. You can enter a maximum of 16 characters.<br>
<h4><a name="Device.Name_column"></a>The Name column</h4>
Enter a name by which you can identify the device.<br>
<h4><a name="Device.IsConcentrator_column"></a>The IsConcentrator column</h4>
Should be self-explanatory. If your device is a concentrator, this should be true. Otherwise, it should be false.<br>
<h4><a name="Device.CompanyID_column"></a>The CompanyID column</h4>
The values in this column should come from the <u>ID</u> column of the <u>Company</u> table.<br>
<h4><a name="Device.HistorianID_column"></a>The HistorianID column</h4>
Enter the ID of the historian that will archive the data coming from this device. The values in this column should come from the
<a href="#Historian.ID_column">ID</a> column in the <a href="#Historian_table">
Historian</a> table.<br>
<h4><a name="Device.AccessID_column"></a>The AccessID column</h4>
Every device has an Access ID (also known as Device ID). The value of this column needs to match the Access ID of the device.<br>
<h4><a name="Device.ProtocolID_column"></a>The ProtocolID column</h4>
The value of this column should come from the <u>ID</u> column in the <u>Protocol</u> table. It determines the protocol used by the device. For your reference, the possible values are in the following table.<br>
<br>
<table>
<tbody>
<tr>
<th>Value </th>
<th>Protocol </th>
</tr>
<tr>
<td>1 </td>
<td>BPA PDCstream </td>
</tr>
<tr>
<td>2 </td>
<td>OPC </td>
</tr>
<tr>
<td>3 </td>
<td>IEEE 1344-1995 </td>
</tr>
<tr>
<td>4 </td>
<td>IEEE C37.118 Draft 6 </td>
</tr>
<tr>
<td>5 </td>
<td>IEEE C37.118-2005 </td>
</tr>
<tr>
<td>6 </td>
<td>FNet </td>
</tr>
<tr>
<td>7 </td>
<td>SEL Fast Message </td>
</tr>
<tr>
<td>8 </td>
<td>Macrodyne </td>
</tr>
</tbody>
</table>
<br>
<h4><a name="Device.ConnectionString_column"></a>The ConnectionString column</h4>
The connection string is used to define how to connect to the device. A quick guide to configuring your connection string can be found on the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#configure_connection_string">
Getting Started</a> page.<br>
<b>Note</b>: The sample connection strings on the Getting Started page include the phasorProtocol and accessID keys. Leave these out as they have been defined in the other columns of your Device table.<br>
<h4><a name="Device.Enabled_column"></a>The Enabled column</h4>
Disabled devices will not be recognized by the openPDC. You will typically want to set this value to true.<br>
<hr>
<h3><a name="Phasor_table"></a>The Phasor table</h3>
This table defines the phasors that are being sent from your devices.<br>
<h4><a name="Phasor.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="Phasor.DeviceID_column"></a>The DeviceID column</h4>
The values in this column should come from the <a href="#Device.ID_column">ID</a> column of the
<a href="#Device_table">Device</a> table. This defines which device the phasor is coming from.<br>
<h4><a name="Phasor.Label_column"></a>The Label column</h4>
Enter some text with which to identify the phasor.<br>
<h4><a name="Phasor.Type_column"></a>The Type column</h4>
A single letter that defines whether the phasor is a voltage or a current. The possible values are &#39;V&#39; for voltage and &#39;I&#39; for current.<br>
<h4><a name="Phasor.Phase_column"></a>The Phase column</h4>
The possible values for this column are in the following table.<br>
<br>
<table>
<tbody>
<tr>
<th>Value </th>
<th>Description </th>
</tr>
<tr>
<td>&#43; </td>
<td>Positive Sequence </td>
</tr>
<tr>
<td>- </td>
<td>Negative Sequence </td>
</tr>
<tr>
<td>0 </td>
<td>Zero Sequence </td>
</tr>
<tr>
<td>A </td>
<td>A-Phase </td>
</tr>
<tr>
<td>B </td>
<td>B-Phase </td>
</tr>
<tr>
<td>C </td>
<td>C-Phase </td>
</tr>
</tbody>
</table>
<br>
<h4><a name="Phasor.SourceIndex_column"></a>The SourceIndex column</h4>
Defines the position of the phasor in the measurement stream starting at 1. In other words, the first phasor in the stream should have source index 1, the second should have source index 2, and so on. This number must be accurate in order to interpret the phasor
 data stream.<br>
<hr>
<h3><a name="Measurement_table"></a>The Measurement table</h3>
This table defines every single measurement that is sent to the openPDC. Each device will have at least three measurements associated with it: Status Flags, Frequency, and Frequency Delta (dF/dt). Each phasor will have exactly two measurements associated with
 it: Phase Magnitude and Phase Angle. Additional measurements include Analog Values, Digital Values, and Calculated Values. Information about the types of measurements can be found in the
<u>SignalType</u> table.<br>
<h4><a name="Measurement.SignalID_column"></a>The SignalID column</h4>
The ID column is a GUID used to identify each of the measurements. The values in this column are generated automatically.<br>
<h4><a name="Measurement.HistorianID_column"></a>The HistorianID column</h4>
This column specifies which historian is going to archive the measurement. The values in this column should come from the
<a href="#Historian.ID_column">ID</a> column in the <a href="#Historian_table">
Historian</a> table.<br>
<h4><a name="Measurement.PointID_column"></a>The PointID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="Measurement.DeviceID_column"></a>The DeviceID column</h4>
This column specifies which device the measurement is coming from. The values in this column should come from the
<a href="#Device.ID_column">ID</a> column in the <a href="#Device_table">Device</a> table.<br>
<h4><a name="Measurement.PointTag_column"></a>The PointTag column</h4>
The values in this column are not necessary for the openPDC to operate; they simply describe the measurement. The following convention is suggested for consistency.<br>
<br>
CCC_PPPP-DDDD:IIIH<br>
<ul>
<li>CCC is a three character company identifier. </li><li>PPPP is a four character identification of the device. </li><li>DDDD is a destination identifier. If there is no destination identifier, leave it out (and remove the dash, not the colon).
</li><li>III is a device manufacturer identifier. </li><li>H identifies the signal type (from the <u>Abbreviation</u> column in the <u>SignalType</u> table).</li></ul>
<b>Examples:</b><br>
<u>TVA_SHEL:ABBS</u><br>
Company: TVA<br>
Device: SHELBY<br>
Device Manufacturer: ABB<br>
Signal Type: Status Flags<br>
<br>
<u>TVA_SHEL-LAGO:ABBIH</u><br>
Company: TVA<br>
Device: SHELBY<br>
Destination: LAGO Phasor Degrees<br>
Device Manufacturer: ABB<br>
Signal Type: Current Phase Angle<br>
<h4><a name="Measurement.SignalTypeID_column"></a>The SignalTypeID column</h4>
This defines the signal type of the measurement. The values for this column should come from the
<u>ID</u> column of the <u>SignalType</u> table.<br>
<h4><a name="Measurement.PhasorSourceIndex_column"></a>The PhasorSourceIndex column</h4>
This column should be defined for all measurements that are components of a phasor. The values in this column should come from the
<a href="#Phasor.SourceIndex_column">SourceIndex</a> column in the <a href="#Phasor_table">
Phasor</a> table.<br>
<h4><a name="Measurement.SignalReference_column"></a>The SignalReference column</h4>
This column defines the link between a device and its measurements. It is vitally important for the openPDC to collect data properly. The following lists the information you will need in order to enter the values correctly.<br>
<ul>
<li>Device acronym (from the <a href="#Device.Acronym_column">Acronym</a> column in the
<a href="#Device_table">Device</a> table) </li><li>Suffix of the signal type (from the <u>Suffix</u> column in the <u>SignalType</u> table)
</li><li>Phasor source index (from the <a href="#Measurement.PhasorSourceIndex_column">
PhasorSourceIndex</a> column)</li></ul>
<br>
The following defines the syntax for the SignalReference values.<br>
<br>
<b>ACRONYM-SX#</b><br>
ACRONYM is the device acronym<br>
SX is the suffix of the signal type<br>
# is a trailing number defined in cases where there may or may not be another measurement with the same SignalReference value<br>
<br>
Rules for the trailing number:
<ul>
<li>If the measurement is a phasor, the trailing number is the phasor source index.
</li><li>If the measurement is a digital value or an analog value, the trailing number should be unique and incremental (starting at 1).
</li><li>If the measurement is anything else, it does not have a trailing number.</li></ul>
<br>
SignalReference example:<br>
If SHELBY has 3 digital values, 2 analog values, and 2 phasors, the SignalReference values for those measurements would look like they do in the following table.<br>
<table>
<tbody>
<tr>
<th>PhasorSourceIndex </th>
<th>SignalReference </th>
<th>Description </th>
</tr>
<tr>
<td></td>
<td>SHELBY-SF </td>
<td>Shelby Status Flags </td>
</tr>
<tr>
<td></td>
<td>SHELBY-FQ </td>
<td>Shelby Frequency </td>
</tr>
<tr>
<td></td>
<td>SHELBY-DF </td>
<td>Shelby Frequency Delta (dF/dt) </td>
</tr>
<tr>
<td></td>
<td>SHELBY-DV1 </td>
<td>Shelby Digital Value 1 </td>
</tr>
<tr>
<td></td>
<td>SHELBY-DV2 </td>
<td>Shelby Digital Value 2 </td>
</tr>
<tr>
<td></td>
<td>SHELBY-DV3 </td>
<td>Shelby Digital Value 3 </td>
</tr>
<tr>
<td></td>
<td>SHELBY-AV1 </td>
<td>Shelby Analog Value 1 </td>
</tr>
<tr>
<td></td>
<td>SHELBY-AV2 </td>
<td>Shelby Analog Value 2 </td>
</tr>
<tr>
<td>1 </td>
<td>SHELBY-PM1 </td>
<td>Shelby Phasor 1 Magnitude </td>
</tr>
<tr>
<td>1 </td>
<td>SHELBY-PA1 </td>
<td>Shelby Phasor 1 Angle </td>
</tr>
<tr>
<td>2 </td>
<td>SHELBY-PM2 </td>
<td>Shelby Phasor 2 Magnitude </td>
</tr>
<tr>
<td>2 </td>
<td>SHELBY-PA2 </td>
<td>Shelby Phasor 2 Angle </td>
</tr>
</tbody>
</table>
<br>
<h4><a name="Measurement.Description_column"></a>The Description column</h4>
Enter a description of the measurement.<br>
<h4><a name="Measurement.Enabled_column"></a>The Enabled column</h4>
True if the measurement is enabled for processing. False if it is to be ignored. You typically want to set this value to true.<br>
<hr>
<h2><a name="configure_output"></a>Configuring outputs</h2>
This section will go over all the tables you will need to modify in your openPDC database in order to send data to other devices or applications. The important thing to remember when you&#39;re defining your output devices is that they can be
<i>virtual</i> devices. This means that they may or may not be real devices reporting to the openPDC. This allows you to create output devices that send out only the information you want to send rather than all the information that is received. However, if
 you simply want to gather all the data and send it out in one stream, then you can define all your output devices exactly like your input devices.<br>
<h3><a name="OutputStream_table"></a>The OutputStream table</h3>
This defines the streams through which the openPDC will be sending data.<br>
<h4><a name="OutputStream.NodeID_column"></a>The NodeID column</h4>
Enter the ID of your node into this column. The values in this column should come from the
<a href="#Node.ID_column">ID</a> column in the <a href="#Node_table">Node</a> table.<br>
<h4><a name="OutputStream.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="OutputStream.Acronym_column"></a>The Acronym column</h4>
Enter the Acronym to be used to identify the stream within the program. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore (_) is the only special character allowed. You can enter a maximum of 16 characters.<br>
<h4><a name="OutputStream.Name_column"></a>The Name column</h4>
Enter a name by which you can identify the stream.<br>
<h4><a name="OutputStream.Type_column"></a>The Type column</h4>
This column defines the type of the output protocol. Enter &#39;0&#39; for IEEE C37.118 or &#39;1&#39; for BPA PDCstream.<br>
<h4><a name="OutputStream.ConnectionString_column"></a>The ConnectionString column</h4>
If you are using the IEEE C37.118 protocol, leave this column blank. If you are using the BPA PDCstream protocol, you will need to specify the INI configuration file. In the example on the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#create_and_verify_ieee_c37_118_2005_data_stream">
Getting Started</a> page, the value entered into this column is &quot;iniFileName=TESTSTREAM.ini&quot;. Simply replace &quot;TESTSTREAM.ini&quot; with the name of your INI configuration file and place the file in the &quot;SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\Applications\openPDC&quot;
 directory (SOURCEDIR is the root directory of the openPDC source code).<br>
<h4><a name="OutputStream.DataChannel_column"></a>The DataChannel column</h4>
This defines the connection information for the channel through which the openPDC is sending data. The value of this column is entered in connection string format. Example: &quot;Port=0; Clients=localhost:8800&quot;. For the &quot;Port&quot; key, a value of
 &#39;0&#39; means that any local port can be used. A value of &#39;-1&#39; means that it won&#39;t bind to a local port. Multiple clients may be defined using a comma-separated list.<br>
<h4><a name="OutputStream.CommandChannel_column"></a>The CommandChannel column</h4>
This defines the connection information for the command channel. The value of this column is entered in connection string format. Example: &quot;Port=8900&quot;.<br>
<h4><a name="OutputStream.IDCode_column"></a>The IDCode column</h4>
Enter an identification number. This number is used (much like a station address) in some protocols to identify the sender. In other cases, it is ignored.<br>
<h4><a name="OutputStream.UseLocalClockAsRealTime_column"></a>The UseLocalClockAsRealTime column</h4>
Defines whether or not to use the local clock as real time. If this is set to false, the system will use the timestamp of the most recent measurement as real local time.<br>
<h4><a name="OutputStream.Enabled_column"></a>The Enabled column</h4>
Used to enable or disable the OutputStream. You will typically want to set this value to true.<br>
<hr>
<h3><a name="OutputStreamDevice_table"></a>The OutputStreamDevice table</h3>
This table is used to define your virtual output devices.<br>
<h4><a name="OutputStreamDevice.NodeID_column"></a>The NodeID column</h4>
Enter the ID of your node into this column. The values in this column should come from the
<a href="#Node.ID_column">ID</a> column in the <a href="#Node_table">Node</a> table.<br>
<h4><a name="OutputStreamDevice.AdapterID_column"></a>The AdapterID column</h4>
Specify the output stream ID the device is associated with. The values in this column should come from the
<a href="#OutputStream.ID_column">ID</a> column in the <a href="#OutputStream_table">
OutputStream</a> table.<br>
<h4><a name="OutputStreamDevice.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="OutputStreamDevice.Acronym_column"></a>The Acronym column</h4>
Enter the Acronym to be used to identify the device within the program. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore (_) is the only special character allowed. You can enter a maximum of 16 characters.<br>
<h4><a name="OutputStreamDevice.BpaAcronym_column"></a>The BpaAcronym column</h4>
Like the <a href="#OutputStreamDevice.Acronym_column">Acronym</a> column, but with a maximum of only four characters.<br>
<h4><a name="OutputStreamDevice.Name_column"></a>The Name column</h4>
Enter a name by which you can identify the device.<br>
<h4><a name="OutputStreamDevice.Enabled_column"></a>The Enabled column</h4>
Disabled devices will not be recognized by the openPDC. You will typically want to set this value to true.<br>
<hr>
<h3><a name="OutputStreamDeviceAnalog_table"></a>The OutputStreamDeviceAnalog table</h3>
This table is used to define the analog values associated with your virtual output devices. If you have no analog values to define, feel free to
<a href="#OutputStreamDeviceDigital_table">skip ahead</a>.<br>
<h4><a name="OutputStreamDeviceAnalog.NodeID_column"></a>The NodeID column</h4>
Enter the ID of your node into this column. The values in this column should come from the
<a href="#Node.ID_column">ID</a> column in the <a href="#Node_table">Node</a> table.<br>
<h4><a name="OutputStreamDeviceAnalog.OutputStreamDeviceID_column"></a>The OutputStreamDeviceID column</h4>
Enter the ID of the virtual output device that the analog value is associated with. The values in this column should come from the
<a href="#OutputStreamDevice.ID_column">ID</a> column in the <a href="#OutputStreamDevice_table">
OutputStreamDevice</a> table.<br>
<h4><a name="OutputStreamDeviceAnalog.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="OutputStreamDeviceAnalog.Label_column"></a>The Label column</h4>
Enter a label by which to identify the analog value.<br>
<h4><a name="OutputStreamDeviceAnalog.Type_column"></a>The Type column</h4>
Specify the type of the analog value. The following table lists the possible values in this column.<br>
<br>
<table>
<tbody>
<tr>
<th>Value </th>
<th>Description </th>
</tr>
<tr>
<td>0 </td>
<td>Single point-on-wave </td>
</tr>
<tr>
<td>1 </td>
<td>RMS of analog input </td>
</tr>
<tr>
<td>2 </td>
<td>Peak of analog input </td>
</tr>
</tbody>
</table>
<br>
<hr>
<h3><a name="OutputStreamDeviceDigital_table"></a>The OutputStreamDeviceDigital table</h3>
This table is used to define the digital values associated with your virtual output devices. If you have no digital values to define, feel free to
<a href="#OutputStreamDevicePhasor_table">skip ahead</a>.<br>
<h4><a name="OutputStreamDeviceDigital.NodeID_column"></a>The NodeID column</h4>
Enter the ID of your node into this column. The values in this column should come from the
<a href="#Node.ID_column">ID</a> column in the <a href="#Node_table">Node</a> table.<br>
<h4><a name="OutputStreamDeviceDigital.OutputStreamDeviceID_column"></a>The OutputStreamDeviceID column</h4>
Enter the ID of the virtual output device that the digital value is associated with. The values in this column should come from the
<a href="#OutputStreamDevice.ID_column">ID</a> column in the <a href="#OutputStreamDevice_table">
OutputStreamDevice</a> table.<br>
<h4><a name="OutputStreamDeviceDigital.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="OutputStreamDeviceDigital.Label_column"></a>The Label column</h4>
Enter a label by which to identify the digital value.<br>
<hr>
<h3><a name="OutputStreamDevicePhasor_table"></a>The OutputStreamDevicePhasor table</h3>
This table is used to define the phasors associated with your virtual output devices.<br>
<h4><a name="OutputStreamDevicePhasor.NodeID_column"></a>The NodeID column</h4>
Enter the ID of your node into this column. The values in this column should come from the
<a href="#Node.ID_column">ID</a> column in the <a href="#Node_table">Node</a> table.<br>
<h4><a name="OutputStreamDevicePhasor.OutputStreamDeviceID_column"></a>The OutputStreamDeviceID column</h4>
Enter the ID of the virtual output device that the phasor is associated with. The values in this column should come from the
<a href="#OutputStreamDevice.ID_column">ID</a> column in the <a href="#OutputStreamDevice_table">
OutputStreamDevice</a> table.<br>
<h4><a name="OutputStreamDevicePhasor.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="OutputStreamDevicePhasor.Label_column"></a>The Label column</h4>
Enter a label by which to identify the phasor.<br>
<h4><a name="OutputStreamDevicePhasor.Type_column"></a>The Type column</h4>
Specify whether the phasor is a voltage or a current. Enter &#39;V&#39; for voltage or &#39;I&#39; for current.<br>
<h4><a name="OutputStreamDevicePhasor.Phase_column"></a>The Phase column</h4>
The possible values for this column are in the following table.<br>
<br>
<table>
<tbody>
<tr>
<th>Value </th>
<th>Description </th>
</tr>
<tr>
<td>&#43; </td>
<td>Positive Sequence </td>
</tr>
<tr>
<td>- </td>
<td>Negative Sequence </td>
</tr>
<tr>
<td>0 </td>
<td>Zero Sequence </td>
</tr>
<tr>
<td>A </td>
<td>A-Phase </td>
</tr>
<tr>
<td>B </td>
<td>B-Phase </td>
</tr>
<tr>
<td>C </td>
<td>C-Phase </td>
</tr>
</tbody>
</table>
<br>
<hr>
<h3><a name="OutputStreamMeasurement_table"></a>The OutputStreamMeasurement table</h3>
This table defines every single measurement that is sent from the openPDC. This table provides a link between the input measurements and the virtual output devices that you just defined. Each virtual output device will have at least three measurements associated
 with it: Status Flags, Frequency, and Frequency Delta (dF/dt). Each output analog value will have one measurement associated with it. Each output digital value will also have one measurement associated with it. Each output phasor will have exactly two measurements
 associated with it: Phase Magnitude and Phase Angle. Information about the types of measurements can be found in the
<u>SignalType</u> table.<br>
<h4><a name="OutputStreamMeasurement.NodeID_column"></a>The NodeID column</h4>
Enter the ID of your node into this column. The values in this column should come from the
<a href="#Node.ID_column">ID</a> column in the <a href="#Node_table">Node</a> table.<br>
<h4><a name="OutputStreamMeasurement.AdapterID_column"></a>The AdapterID column</h4>
Specify the output stream ID the measurement is associated with. The values in this column should come from the
<a href="#OutputStream.ID_column">ID</a> column in the <a href="#OutputStream_table">
OutputStream</a> table.<br>
<h4><a name="OutputStreamMeasurement.ID_column"></a>The ID column</h4>
The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.<br>
<h4><a name="OutputStreamMeasurement.HistorianID_column"></a>The HistorianID column</h4>
The value in this column must match the value in the <a href="#Measurement.HistorianID_column">
HistorianID</a> column for the corresponding measurement in the <a href="#Measurement_table">
Measurement</a> table.<br>
<h4><a name="OutputStreamMeasurement.PointID_column"></a>The PointID column</h4>
The value in this column must match the value in the <a href="#Measurement.PointID_column">
PointID</a> column for the corresponding measurement in the <a href="#Measurement_table">
Measurement</a> table.<br>
<h4><a name="OutputStreamMeasurement.SignalReference_column"></a>The SignalReference column</h4>
<b>Note</b>: This description is essentially the same as the <a href="#Measurement.SignalReference_column">
SignalReference</a> description for the <a href="#Measurement_table">Measurement</a> table. The only difference is you are now linking output measurements to virtual output devices. Use the values from the output tables to create the signal reference values.<br>
<br>
This column defines the link between a virtual device and its output measurements. It is vitally important for the openPDC to send the data properly. The following lists the information you will need in order to enter the values correctly.<br>
<ul>
<li>Virtual device acronym (from the <a href="#OutputStreamDevice.Acronym_column">
Acronym</a> column in the <a href="#OutputStreamDevice_table">OutputStreamDevice</a> table)
</li><li>Suffix of the signal type (from the <u>Suffix</u> column in the <u>SignalType</u> table)
</li><li>Phasor source index (from the <a href="#OutputStreamMeasurement.PhasorSourceIndex_column">
PhasorSourceIndex</a> column)</li></ul>
<br>
The following defines the syntax for the SignalReference values.<br>
<br>
<b>ACRONYM-SX#</b><br>
ACRONYM is the virtual device acronym<br>
SX is the suffix of the signal type<br>
# is a trailing number defined in cases where there may or may not be another output measurement with the same SignalReference value<br>
<br>
Rules for the trailing number:
<ul>
<li>If the output measurement is a phasor, the trailing number is the phasor source index.
</li><li>If the output measurement is a digital value or an analog value, the trailing number should be unique and incremental (starting at 1).
</li><li>If the output measurement is anything else, it does not have a trailing number.</li></ul>
<br>
SignalReference example:<br>
If SHELBY has 3 digital values, 2 analog values, and 2 phasors, the SignalReference values for those output measurements would look like they do in the following table.<br>
<table>
<tbody>
<tr>
<th>PhasorSourceIndex </th>
<th>SignalReference </th>
<th>Description </th>
</tr>
<tr>
<td></td>
<td>SHELBY-SF </td>
<td>Shelby Status Flags </td>
</tr>
<tr>
<td></td>
<td>SHELBY-FQ </td>
<td>Shelby Frequency </td>
</tr>
<tr>
<td></td>
<td>SHELBY-DF </td>
<td>Shelby Frequency Delta (dF/dt) </td>
</tr>
<tr>
<td></td>
<td>SHELBY-DV1 </td>
<td>Shelby Digital Value 1 </td>
</tr>
<tr>
<td></td>
<td>SHELBY-DV2 </td>
<td>Shelby Digital Value 2 </td>
</tr>
<tr>
<td></td>
<td>SHELBY-DV3 </td>
<td>Shelby Digital Value 3 </td>
</tr>
<tr>
<td></td>
<td>SHELBY-AV1 </td>
<td>Shelby Analog Value 1 </td>
</tr>
<tr>
<td></td>
<td>SHELBY-AV2 </td>
<td>Shelby Analog Value 2 </td>
</tr>
<tr>
<td>1 </td>
<td>SHELBY-PM1 </td>
<td>Shelby Phasor 1 Magnitude </td>
</tr>
<tr>
<td>1 </td>
<td>SHELBY-PA1 </td>
<td>Shelby Phasor 1 Angle </td>
</tr>
<tr>
<td>2 </td>
<td>SHELBY-PM2 </td>
<td>Shelby Phasor 2 Magnitude </td>
</tr>
<tr>
<td>2 </td>
<td>SHELBY-PA2 </td>
<td>Shelby Phasor 2 Angle </td>
</tr>
</tbody>
</table>
<br>
<hr>
<h3><a name="trouble"></a>Troubleshooting</h3>
If you are still having trouble after using this guide, please make sure that you have followed the instructions for changing your configuration file outlined in the
<a href="#Node.ID_column">Node.ID</a> section.<br>
<br>
Another thing to check is to make sure that you have defined your <a href="#OutputStreamMeasurement_table">
OutputStreamMeasurement</a> table based on your output devices rather than the input measurements (the number of output measurements you should define is explained in the description of the
<a href="#OutputStreamMeasurement_table">OutputStreamMeasurement</a> table). <a href="#OutputStreamMeasurement.PointID_column">
PointID</a> values do not need to be unique in this table (you can associate two output measurements with the same input measurement if, for instance, you need to send the same measurement over two different output streams).<br>
<br>
Everything else is fairly straightforward, but there is a lot of configuration involved so it may be worthwhile to double-check your tables to make sure you haven&#39;t made any mistakes. It is also possible that your configuration is more complicated than
 the configurations covered by this guide in which case you can take a look at the database documentation (coming soon) for a more detailed description of the tables and fields. Finally, if you think you may have found a bug, you are encouraged to create an
 item on the issue tracker in order to bring it to our attention.</div>
</div>
<hr />
<div class="WikiComments">
<div id="wikiCommentsEmpty">No comments yet.<br></div>
</div>
<div id="footer">
<hr />
</div>
Last edited <span class="smartDate" title="3/25/2015 9:01:10 PM" LocalTimeTicks="1427342470">Mar 25, 2015 at 9:01 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 12<br />
Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=Manual%20Configurations">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
