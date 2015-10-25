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
<h1>How to Use the openPDC Manager</h1>
<p>The openPDC Manager is a Silverlight application designed to make configuring the openPDC easier. This guide is designed to assist you in configuring the openPDC using the openPDC Manager. The following sections will explain how to install, configure, and
 run the openPDC Manager as well as how to configure the inputs and outputs of the openPDC.</p>
<ul>
<li><a href="#installation">Installation</a>
<ul>
<li><a href="#using_installers">Using the installers</a> </li></ul>
</li><li><a href="#configuration">Configuration</a>
<ul>
<li><a href="#change_base_url">Changing the Base Service URL</a> </li><li><a href="#configure_database_connection">Configuring the database connection</a>
</li></ul>
</li><li><a href="#run_openpdcmanager">Run the openPDC Manager</a> </li><li><a href="#using_openpdcmanager">Using the openPDC Manager</a>
<ul>
<li><a href="#create_first_node">Creating the first node</a> </li><li><a href="#modify_node">Modifying a node</a> </li><li><a href="#create_additional_nodes">Creating additional nodes</a> </li></ul>
</li><li><a href="#configure_input">Configuring inputs</a>
<ul>
<li><a href="#create_historians">Creating historians</a> </li><li><a href="#configuration_wizard">Creating devices using the Configuration Wizard</a>
<ul>
<li><a href="#configure_connection_settings">Step 1: Configure Connection Settings</a>
</li><li><a href="#select_device_configuration_settings">Step 2: Select Device Configuration Settings</a>
</li><li><a href="#select_devices_to_configure">Step 3: Select Devices to Configure</a>
</li></ul>
</li><li><a href="#create_devices">Creating devices</a> </li><li><a href="#modify_device">Modifying devices</a> </li><li><a href="#create_phasors">Creating phasors</a> </li><li><a href="#create_measurements">Creating measurements</a> </li></ul>
</li><li><a href="#configure_output">Configuring outputs</a>
<ul>
<li><a href="#create_outputstreams">Creating output streams</a> </li><li><a href="#outputdevice_wizard">Using the device wizard</a> </li></ul>
</li><li><a href="#create_outputdevices">Creating virtual output devices</a>
<ul>
<li><a href="#create_outputstream_two">Creating a second output stream</a> </li><li><a href="#create_virtualoutputdevice">Creating a virtual output device</a> </li><li><a href="#create_outputphasors">Creating phasors for your virtual output device</a>
</li><li><a href="#create_outputdigitals">Creating digitals for your virtual output device</a>
</li><li><a href="#create_outputmeasurements">Attaching measurements to the output stream</a>
</li></ul>
</li><li><a href="#view_real_time_data">Viewing real-time data</a>
<ul>
<li><a href="#find_real_time_url">Finding the Time Series Data Service URL</a> </li><li><a href="#real_time_graph">The real-time data graph</a> </li><li><a href="#device_measurements_tree">The device measurements tree</a> </li></ul>
</li><li><a href="#using_console_monitor">Using the console monitor</a>
<ul>
<li><a href="#find_remote_status_url">Finding the Remote Status Service URL</a>
</li><li><a href="#console_monitor">The console monitor</a> </li></ul>
</li><li><a href="#changing_system_settings">Changing system settings</a> </li></ul>
<hr>
<h2><a name="installation"></a>Installation</h2>
<p>The GUI based openPDC Manager application is installed with the openPDC itself. No additional setup is required. If you are using the GUI based openPDC Manager, please skip ahead to
<a href="#run_openpdcmanager">Run the openPDC Manager</a>.</p>
<p>The web based openPDC Manager must be installed separately. The following subsections will explain what you need and how to install it.</p>
<h3><a name="using_installers"></a>Using the installers</h3>
<p>In order to use the installers, you will need to install Internet Information Services 4.0 or later. If IIS is not already installed on your machine, we recommend rebooting your system between the installation of IIS and the installation of the openPDC Manager.<br>
<br>
The openPDC installers can be found on the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_v1.1_Release_48110.md">
Downloads Page</a> Once you have extracted the installers, you will need to run both the &quot;openPDCManagerWebInstaller.exe&quot; and the &quot;openPDCManagerServicesInstaller.exe&quot; files. If you have trouble with the installation, please check the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#trouble_installing_manager"> FAQ</a>.<br>
<br>
After the installations are complete, you need to move &quot;clientaccesspolicy.xml&quot; (located in wwwroot/openPDCManagerServices by default) up one level in the directory structure (into the wwwroot directory).<br>
<br>
Additionally, you will need to register the following MIME types on the server.</p>
<ul>
<li><span class="codeInline">.xaml --&gt; application/xaml&#43;xml </span></li><li><span class="codeInline">.xap --&gt; application/x-silverlight-app </span></li></ul>
<hr>
<h2><a name="configuration"></a>Configuration</h2>
<h3><a name="change_base_url"></a>Changing the Base Service URL</h3>
<p>If you built the web based openPDC Manager from source, you should <a href="#configure_database_connection">
skip this step</a>. If you used the installers, you will need to modify the &quot;web.config&quot; file in the openPDCManager (this is different from &quot;web.config&quot; in the openPDCManagerServices) to point to the correct services URL.<br>
<br>
Change this setting.</p>
<div style="color:black; background-color:white">
<pre><span style="color:blue">&lt;</span><span style="color:#a31515">appSettings</span><span style="color:blue">&gt;</span>
        <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">key</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">BaseServiceUrl</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">http://localhost:1068/</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
<span style="color:blue">&lt;/</span><span style="color:#a31515">appSettings</span><span style="color:blue">&gt;</span>
</pre>
</div>
<p><br>
This is what you need to change it to.</p>
<div style="color:black; background-color:white">
<pre><span style="color:blue">&lt;</span><span style="color:#a31515">appSettings</span><span style="color:blue">&gt;</span>
        <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">key</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">BaseServiceUrl</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">http://localhost/openPDCManagerServices/</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
<span style="color:blue">&lt;/</span><span style="color:#a31515">appSettings</span><span style="color:blue">&gt;</span>
</pre>
</div>
<h3><a name="configure_database_connection"></a>Configuring the database connection</h3>
<p>You need to modify &quot;web.config&quot; in the openPDCManagerServices (this is different from web.config in the openPDCManager). If you built the openPDC Manager from source, you can find this file in the &quot;SOURCEDIR\Synchrophasor\Current Version\Source\Applications\openPDCManager\Services&quot;
 directory (SOURCEDIR is the directory where you extracted the openPDC source code).<br>
<br>
<em>Note: If you installed openPDCManagerServices using the installer, the Configuration Setup Utility provided with the openPDC is also capable of modifying this file to configure your database connection.</em><br>
<br>
This table contains the values for the settings in the configuration file that you need to modify. Refer to the code block below to find the settings that you need to modify.</p>
<table>
<tbody>
<tr>
<th>Database </th>
<th>[ConnectionString] </th>
<th>[DataProviderString] </th>
<th>Notes </th>
</tr>
<tr>
<td>Access</td>
<td>Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Path\to\openPDC.mdb</td>
<td>AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.OleDb.OleDbConnection; AdapterType=System.Data.OleDb.OleDbDataAdapter</td>
<td>In the connection string, you will need to enter the full, absolute path to the .mdb file that you are using to configure the openPDC.</td>
</tr>
<tr>
<td>SQL Server</td>
<td>Data Source=<em>serverName</em>; Initial Catalog=openPDC; User Id=<em>username</em>; Password=<em>password</em></td>
<td>AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.SqlClient.SqlConnection; AdapterType=System.Data.SqlClient.SqlDataAdapter</td>
<td>Replace <em>serverName</em> with the name of your database server, <em>username</em> with your username, and
<em>password</em> with your password.</td>
</tr>
<tr>
<td>MySQL</td>
<td>Server=<em>serverName</em>; Database=openPDC; Uid=<em>username</em>; Pwd=<em>password</em></td>
<td>AssemblyName={MySql.Data, Version=6.2.4.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d}; ConnectionType=MySql.Data.MySqlClient.MySqlConnection; AdapterType=MySql.Data.MySqlClient.MySqlDataAdapter</td>
<td>Replace <em>serverName</em> with the name of your database server, <em>username</em> with your username, and
<em>password</em> with your password. Additionally, <a href="http://dev.mysql.com/downloads/connector/net/6.2.html">
install MySQL Connector Net</a> if you haven't already. You may also need to modify the Version key in the data provider string depending on your version of MySQL Connector Net.</td>
</tr>
</tbody>
</table>
<p><br>
<br>
You will need to modify the value property of the following settings using the values from the table above. Simply copy and paste the [ConnectionString] and [DataProviderString] corresponding to your database from the table.</p>
<div style="color:black; background-color:white">
<pre><span style="color:blue">&lt;</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
  <span style="color:blue">&lt;</span><span style="color:#a31515">categorizedSettings</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;</span><span style="color:#a31515">systemSettings</span><span style="color:blue">&gt;</span>
      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">ConnectionString</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[Connection String]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">DataProviderString</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[DataProviderString]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
    <span style="color:blue">&lt;/</span><span style="color:#a31515">systemSettings</span><span style="color:blue">&gt;</span>
  <span style="color:blue">&lt;/</span><span style="color:#a31515">categorizedSettings</span><span style="color:blue">&gt;</span>
<span style="color:blue">&lt;/</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
</pre>
</div>
<hr>
<h2><a name="run_openpdcmanager"></a>Run the openPDC Manager</h2>
<p>If you are using the GUI based openPDC Manager, the Configuration Setup Utility should give you the option of running the openPDC Manager at the end of the setup. Additionally, you can run &quot;openPDCManager.exe&quot;, located in the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#x_install_directory">installation directory</a> of the openPDC.</p>
<p>Upon launching the executable for the GUI based openPDC Manager, you will see a login screen.<br>
<img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/gui_based_login.png" alt="gui_based_login.png"></p>
<p>Simply enter the credentials you defined during your first run of the Configuration Setup Utility and then click the &quot;Login&quot; button.</p>
<p>If you installed the web based openPDC Manager using the installers, simply open up a web browser and navigate to
 http://localhost/openPDCManager/. If you built it from source, you will need to follow these steps.</p>
<ol>
<li>Open the Synchrophasor solution in Microsoft Visual Studio 2008. </li><li>In the Solution Explorer, right-click on the &quot;Web&quot; project (in Applications\openPDCManager) and select &quot;Set as StartUp Project&quot;.
</li><li>Still in the Solution Explorer, right-click &quot;Default.aspx&quot; (in the Web project) and select &quot;Set As Start Page&quot;.
</li><li>In the toolbar, go to &quot;Debug &gt; Start Debugging&quot;. </li></ol>
<hr>
<h2><a name="using_openpdcmanager"></a>Using the openPDC Manager</h2>
<p>This section will describe the process by which you can configure the openPDC using the openPDC Manager. Since the node table is the first table you will need to configure, we will be using it to demonstrate how to create and modify entries.<br>
<br>
Before you begin your configuration, please note that this guide assumes you have used only the initial data set to set up your database; not the sample data set. In the case of Access, this means copying the &quot;openPDC-InitialDataSet.mdb&quot; file instead
 of the &quot;openPDC-SampleDataSet.mdb&quot; file. In the case of SQL Server and MySQL, it means running only the &quot;openPDC.sql&quot; and &quot;InitialDataSet.sql&quot; files when you set up your database. If you need to reset your database in order to
 do this, please read the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#reset_database">
FAQ</a>. The&nbsp;Configuration Setup Utility will set up the initial data set for you by default.</p>
<h3><a name="create_first_node"></a>Creating the first node</h3>
<p>The first step to configuring the openPDC is to create a node. Each node corresponds to an instance of the openPDC.<br>
<br>
In order to configure your nodes, go to &quot;Manage &gt; Nodes&quot;.<br>
<img title="manage_nodes.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_nodes.png" alt="manage_nodes.png" width="562" height="291"><br>
<br>
The following describes each of the fields and the types of information you can enter.<br>
<br>
<strong>Node ID</strong><br>
Once your node has been saved, its node ID will be automatically generated and will be available in this text box. It can then be copied and pasted into your openPDC configuration file.<br>
<br>
<strong>Name</strong><br>
Enter a name for the node to help you identify the node later on.<br>
<br>
<strong>Company</strong><br>
Select the company who owns the node. The values of this list come from the Companies table.<br>
<br>
<strong>Longitude and Latitude</strong><br>
Optionally enter the physical location of the node.<br>
<br>
<strong>Description</strong><br>
Optionally enter a short description of the node.<br>
<br>
<strong>Image</strong><br>
Optionally enter the path to an image that represents or helps identify the node.<br>
<br>
<strong>Settings</strong><br>
Enter Remote Status Server Connection String and the Data Publisher Port.<br>
<br>
<strong>Load Order</strong><br>
Enter an integer value that represents the order in which this table's records are pulled from the database. The order goes from smallest to largest.<br>
<br>
<strong>Master</strong><br>
Indicates whether the node is a master. Currently, this does not affect how the node operates and is simply there for the user's reference.<br>
<br>
<strong>Enabled</strong><br>
Indicates whether the node is enabled or not. If your node is not enabled, you will not be able to add new devices or measurements to the node using the openPDC Manager.<br>
<br>
Once you have entered all the information, click the &quot;Add&quot; button. The following example setup has one node.<br>
<img title="node_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_nodemenu.png" alt="node_example.png"></p>
<h3><a name="modify_node"></a>Modifying a node</h3>
<p>When you click on a node in the list, the information you entered will appear in the text fields. Select the node you wish to modify, edit the information in the fields, and click the &quot;Update&quot; button.</p>
<h3><a name="create_additional_nodes"></a>Creating additional nodes</h3>
<p>The process for creating additional nodes is essentially the same as creating the first node. The only caveat is if you have a node selected in the list, you will need to click the &quot;Clear&quot; button before entering the new information. The &quot;Update&quot;
 button will change back to the &quot;Add&quot; button, and you will be able to enter the information about your new node. If you do not click the &quot;Clear&quot; button first, then you will end up modifying the node you have selected.</p>
<hr>
<h2><a name="configure_input"></a>Configuring inputs</h2>
<p>This section will go over how to use the openPDC Manager to configure the openPDC to receive data from your devices.</p>
<h3><a name="create_historians"></a>Creating historians</h3>
<p>Before you can create any devices, you have to create a historian that will archive the data received by the openPDC.<br>
<br>
In order to configure your historians, go to &quot;Adapters &gt; Historians&quot;.<br>
<img title="manage_historians.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_createHistorian.png" alt="manage_historians.png"><br>
<br>
The following describes each of the fields and the types of information you can enter.<br>
<br>
<strong>Node</strong><br>
Choose the node that will be using the historian to archive its collected data.<br>
<br>
<strong>Acronym</strong><br>
Enter a character identifier for your historian. By convention, the acronym should be entered using only capital letters and underscores.<br>
<br>
<strong>Name</strong><br>
Enter a name by which you can identify the historian.<br>
<br>
<strong>Type Name</strong><br>
Enter the name, including the namespace, of the .NET class extending from OutputAdapterBase.<br>
<br>
<strong>Assembly Name</strong><br>
Enter the name of the dll containing the .NET class extending from OutputAdapterBase.<br>
<br>
<strong>ConnectionString</strong><br>
Optionally enter a connection string used to connect to the historian.<br>
<br>
<strong>Description</strong><br>
Optionally enter a short description of the historian.<br>
<br>
<strong>Load Order</strong><br>
Enter an integer value that represents the order in which this table's records are pulled from the database. The order goes from smallest to largest.<br>
<br>
<strong>Measurement Reporting<br>
</strong>Optionally enter an integer value that is used to determined how many measurements should be processed before reporting status. Set it to zero to disable status reporting.<br>
<br>
<strong>Runtime ID<br>
</strong>The integer identification number used to send commands to the historian. The link labeled &quot;Initialized&quot; can be used to send the initialization command to the adapter from the historian management screen.<br>
<br>
<strong>Local</strong><br>
Indicates whether the historian runs on the node machine.<br>
<br>
<strong>Enabled</strong><br>
Indicates whether the historian is enabled.<br>
<br>
Common values:</p>
<table>
<tbody>
<tr>
<th>Name </th>
<th>Assembly Name </th>
<th>Type Name </th>
<th>Connection String </th>
</tr>
<tr>
<td>TVA Local Historian</td>
<td>HistorianAdapters.dll</td>
<td>HistorianAdapters.LocalOutputAdapter</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>TVA Remote Historian</td>
<td>HistorianAdapters.dll</td>
<td>HistorianAdapters.RemoteOutputAdapter</td>
<td>Server=localhost; Port=1003; PayloadAware=True; MaximumSamples=100000; ConserveBandwidth=True</td>
</tr>
</tbody>
</table>
<p><br>
<br>
Once you have entered all the information, click the &quot;Save&quot; button. The following example setup has one historian.<br>
<img title="historian_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_HistorianOpts.png" alt="historian_example.png"><br>
<br>
The next section details how to create devices using the <a href="#configuration_wizard">
Configuration Wizard</a>. If you would rather create your devices manually, you may skip ahead to
<a href="#create_devices">Creating devices</a>.</p>
<h3><a name="configuration_wizard"></a>Creating devices using the Configuration Wizard</h3>
<p>Now that you have a historian to archive the measurements, it's time to start creating devices that will be sending the measurements to the openPDC. The easiest way to create devices is to use the Configuration Wizard.<br>
<br>
In order to get to the Configuration Wizard, go to &quot;Devices &gt; Input Wizard&quot;.<br>
<img title="configuration_wizard.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_InputWizarMenu.png" alt="configuration_wizard.png"></p>
<h4><a name="configure_connection_settings"></a>Step 1: Configure Connection Settings</h4>
<p>The following describes each of the fields in this step and the types of information you can enter.<br>
<br>
<strong>Connection File</strong><br>
This is the connection file for your device that was <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/PMU_Connection_Tester.md#use_previous_connection">
generated by the PMU Connection Tester</a>. Using this file will automatically configure your device's connection string and phasor protocol. This file is completely optional.<br>
<br>
<strong>Connection String</strong><br>
Enter the connection string for the device. This will be automatically configured if you specified a Connection File. Descriptions and examples of connection strings can be found on the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#configure_connection_string">
Getting Started</a> page.<br>
<br>
<strong>Alternate Command Channel</strong><br>
Enter the connection string that defines the connection used to send commands to the device. This will be automatically configured if you specified a Connection File. The command channel cannot be a UDP connection. Descriptions and examples of connection strings
 can be found on the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#configure_connection_string">
Getting Started</a> page.<br>
<br>
<strong>Device ID Code<br>
</strong>Enter the ID Code of the device that you are connecting to.<br>
<br>
<strong>Device Protocol</strong><br>
This is the phasor protocol used by the device that you are connecting to.<br>
<br>
Once you've entered all the necessary information, click &quot;Next&quot;. The following shows an examples of this step.<br>
<strong><br>
</strong><img title="configure_connection_settings_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_InputWizar.png" alt="configure_connection_settings_example.png"><br>
<strong><br>
</strong></p>
<h4><a name="select_device_configuration_settings"></a>Step 2: Select Device Configuration Settings</h4>
<p>The following describes each of the fields in this step and the types of information you can enter.<br>
<br>
<strong>Request Configuration From openPDC</strong><br>
The openPDC is capable of retrieving device configuration information upon request from the openPDC Manager. Doing so allows you to easily receive the device configuration without the use of an XML configuration file generated by the PMU Connection Tester.
 In order for configuration retrieval to be successful, the openPDC must be running, the
<a href="#view_real_time_data">Remote Status Service URL</a> must be configured properly, the connection string and command channel for the device must be configured properly in step 1, and the device must be available to communicate with the openPDC.<br>
<br>
<strong>Configuration File</strong><br>
This is the configuration file for your device that was <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/PMU_Connection_Tester.md#save_config_files">
generated by the PMU Connection Tester</a>. If configuration retrieval from the openPDC is unsuccessful and the XML configuration is available, enter the path to the XML configuration file here.<br>
<br>
<strong>Connection is to Concentrator</strong><br>
Check this box if you are connecting to a PDC.<br>
<br>
<strong>PDC Acronym</strong>&nbsp;(only visible if Connection is to Concentrator is checked)<br>
The acronym of the PDC you are connecting to.<br>
<br>
<strong>PDC Name</strong>&nbsp;(only visible if Connection is to Concentrator is checked)<br>
The name of the PDC you are connecting to.<br>
<br>
<strong>PDC Device Vendor</strong>&nbsp;(only visible if Connection is to Concentrator is checked)<br>
The vendor of the PDC you are connecting to.<br>
<br>
<strong>Company</strong><br>
Select the company that owns the device.<br>
<br>
<strong>Historian</strong><br>
Select the historian that will be archiving the measurements being received by the device.<br>
<br>
<strong>Interconnection</strong><br>
Select the interconnection of the device.<br>
<br>
Once you've entered all the necessary information, click &quot;Next&quot;. The following example setup shows the fields populated with valid values with and without a PDC.</p>
<p><strong>No PDC<br>
</strong><img title="select_device_configuration_settings_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_Step2InputWizard.png" alt="select_device_configuration_settings_example.png"></p>
<p><strong>PDC<br>
<img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_Step2InputWizard2.png" alt="select_device_configuration_settings_example_pdc.png" width="768" height="579">&nbsp;</strong></p>
<h4><a name="select_devices_to_configure"></a>Step 3: Select Devices to Configure</h4>
<p>In this step, the checkboxes allow you to choose which devices and phasors you wish to add to your openPDC configuration. The following describes each of the fields in this step and the types of information you can enter.<br>
<br>
<strong>Acronym</strong><br>
The acronym of the device.<br>
<br>
<strong>Name</strong><br>
The name of the device.<strong>&nbsp;</strong><br>
<br>
<strong>Longitude and Latitude</strong><br>
Optionally enter the physical location of the device.<br>
<br>
<strong>Digital and Analogs</strong><br>
Check these boxes to include digital values and/or analog values in the device configuration.<br>
<br>
<strong>Label</strong><br>
The label describing the phasor.<br>
<br>
<strong>Type</strong><br>
Voltage or current.<br>
<br>
<strong>Phase</strong><br>
Positive Sequence = &quot;&#43;&quot;, Negative Sequence = &quot;-&quot;, Phase A = &quot;A&quot;, Phase B = &quot;B&quot;, or Phase C = &quot;C&quot;.<br>
<br>
Once you've entered all the necessary information, click &quot;Finish&quot;. The following example setup shows the fields populated with valid values.<br>
<img title="select_devices_to_configure_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_Step3InputWizard.png" alt="select_devices_to_configure_example.png"><br>
<br>
At this point, you may wish to skip ahead to <a href="#configure_output">Configuring outputs</a>.</p>
<h3><a name="create_devices"></a>Creating devices</h3>
<p>Note that if you have a concentrator that collects data from multiple PMUs and then sends that data to one of your nodes, you will need to add individual records for that concentrator and each of the PMUs sending data to it. If you have any concentrators
 you will be creating records for, you will need to add them before you start adding your PMUs.<br>
<br>
In order to add new devices, go to &quot;Devices &gt; Add New&quot;.<br>
<img title="manage_devices.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_AddNewMenu.png" alt="manage_devices.png"></p>
<p><br>
The following describes each of the fields and the types of information you can enter.<br>
<br>
<strong>Node</strong><br>
Choose the node that will be receiving data from the device.<br>
<br>
<strong>Concentrator (Dropdown)</strong><br>
If you have any devices that send data to another concentrator which then forwards that data to one of your nodes, select that concentrator from this list.<br>
<br>
<strong>Acronym</strong><br>
Enter a character identifier for your device. By convention, the acronym should be entered using only capital letters and underscores. This field can be a maximum of 16 characters.<br>
<br>
<strong>Name</strong><br>
Enter a name by which you can identify the device.<br>
<br>
<strong>Company</strong><br>
Select the company who owns the device.<br>
<br>
<strong>Historian</strong><br>
Select the historian which will be archiving measurements received from this device.<br>
<br>
<strong>ID Code (AccessID)</strong><br>
Every device has an Access ID (also known as Device ID) assigned to it by the owner in its configuration. Enter that value here. It is important that this field matches the ID number assigned by the manufacturer.<br>
<br>
<strong>Interconnection</strong><br>
Select the interconnection that the device is collecting data from.<br>
<br>
<strong>Device Vendor</strong><br>
Select the model of the device.<br>
<br>
<strong>Protocol</strong><br>
Select the protocol used by the device to send the data.<br>
<br>
<strong>Longitude and Latitude</strong><br>
Optionally enter the physical location of the device.<br>
<br>
<strong>Connection String</strong><br>
Enter the connection string used to connect to the device. Descriptions and examples of connection strings can be found on the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#configure_connection_string">
Getting Started</a> page.<br>
<strong>Note</strong>: The example connection strings include two records you do not need to enter. Please remove the &quot;phasorProtocol&quot; and &quot;accessID&quot; records from the connection string when entering the connection string into this field.<br>
<br>
<strong>Alternate Command Channel<br>
</strong>If a device uses an alternate command channel, for instance if the device sends data over a UDP connection and receives commands over a TCP connection, then you can define that command channel here.<strong><br>
<br>
<strong>FramesPerSecond</strong><br>
</strong>Enter the frame rate of the device in frames per second.<br>
<br>
<strong>Time Zone</strong><br>
Enter the timezone of the device.<br>
<br>
<strong>Data Loss Interval</strong><br>
If the device stops reporting measurements, this is the amount of time (in seconds) that the openPDC will wait before attempting to re-establish the connection.<br>
<br>
<strong>Time Adjustment Ticks</strong><br>
Enter a number of ticks that will be added to the time reported by the device. (This allows for adjustment if the device's GPS clock is off.)<br>
<br>
<strong>Allowed Parsing Exceptions<br>
</strong>Enter an integer value that represents the number of exceptions that can occur within the parsing exception window before the device is disconnected.<strong>&nbsp;</strong><br>
<br>
<strong>Delayed Connection Interval<br>
</strong>Enter a numeric value that represents the number of seconds between connection attempts when a connection cannot be established with the device.<strong><br>
<br>
Parsing Exception Window<br>
</strong>Enter a numeric value that represents the number of seconds to wait before resetting the exception count. If the exception count reaches the number of allowed parsing exceptions within this time interval, the device will be disconnected.<strong>&nbsp;</strong><br>
<br>
<strong>Measurement Reporting Interval<br>
</strong>Optionally enter an integer value that is used to determined how many measurements should be processed before reporting status. Set it to zero to disable status reporting.<strong><br>
<br>
Skip Disable Real-Time Data<br>
</strong>Indicates whether to skip automatic disabling of the real-time data stream on startup or shutdown.<strong><br>
<br>
Allow Use Of Cached Configuration<br>
</strong>Indicates whether the&nbsp;use of a cached configuration during initial connection is allowed when a configuration has not been received within the data loss interval.<strong><br>
<br>
Auto Start Data Parsing Sequence<br>
</strong>Indicates whether to begin parsing data from the device automatically or to wait for the user to start it manually.<br>
<br>
<strong>Concentrator</strong><br>
Indicates whether the device is a concentrator.<br>
<br>
<strong>Enabled</strong><br>
Indicates whether the device is enabled.<strong><br>
</strong><br>
<strong>Contact List</strong><br>
Optionally enter contact information for the person associated with the device.<br>
<br>
<strong>Runtime ID<br>
</strong>The integer identification number used to send commands to the device. The link labeled &quot;Initialized&quot; can be used to send the initialization command to the adapter from the device management screen.</p>
<p><strong>Connect On Demand</strong><br>
Indicates whether the adapter will be running or not upon requests from other adapters.<strong>&nbsp;</strong><br>
<br>
Common values:</p>
<table>
<tbody>
<tr>
<th>Protocol </th>
<th>Connection String </th>
</tr>
<tr>
<td>BPA PDCstream</td>
<td>iniFileName=TestConfig.ini; transportProtocol=udp; port=8500</td>
</tr>
<tr>
<td>IEEE 1344-1995</td>
<td>transportProtocol=File; file=Sample1344.PmuCapture</td>
</tr>
<tr>
<td>IEEE C37.118-2005</td>
<td>transportProtocol=tcp; server=localhost:8888</td>
</tr>
<tr>
<td>SEL Fast Message</td>
<td>transportProtocol=serial; port=COM1; baudrate=57600; parity=None; stopbits=One; databits=8</td>
</tr>
</tbody>
</table>
<p><br>
<br>
Once you have entered all the information, click the &quot;Save&quot; button. The following example setup shows the fields populated with valid values.<br>
<img title="add_new_device_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_AddNew.png" alt="add_new_device_example.png"></p>
<p><br>
Once you have successfully added a device, you can go to &quot;Devices &gt; Browse&quot; to see the new device.<br>
<img title="browse_devices.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_DevicesBrowseMenu.png" alt="browse_devices.png" width="416" height="169"></p>
<p><br>
Additionally, the openPDC Manager will automatically create measurements for that device which you can view by going to &quot;Manage &gt; Measurements&quot; or by clicking the &quot;Measurements&quot; link for that device on the devices page.<br>
<img title="manage_measurements.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_ManageMenu.png" alt="manage_measurements.png" width="575" height="234"></p>
<p><strong>OR</strong><br>
<img title="measurements_link.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_BrowseMeasurements.png" alt="measurements_link.png"></p>
<h3><a name="modify_device"></a>Modifying devices</h3>
<p>In order to modify a device, go to the devices page (&quot;Devices &gt; Browse&quot;) and click on the acronym of the device you wish to modify. The &quot;Manage Devices&quot; page will appear with the information for that device filled in. Simply modify
 that information and click the &quot;Save&quot; button.<br>
<br>
<em>Note: When making changes to a device's acronym, it is important to double-check the SignalReference field of all of its associated measurements to make sure they all changed accordingly.</em></p>
<h3><a name="create_phasors"></a>Creating phasors</h3>
<p>On the devices page (&quot;Devices &gt; Browse&quot;), find the device for which you wish to define phasors and click the &quot;Phasors&quot; link.<br>
<br>
The following describes each of the fields and the types of information you can enter in this window.<br>
<br>
<strong>Label</strong><br>
Enter a label by which you can identify the phasor.<br>
<br>
<strong>Type</strong><br>
Select the type of phasor. They can be a voltage or a current.<br>
<br>
<strong>Phase</strong><br>
Select the phase. The choices are &#43; (positive), - (negative), A (phase A), B (phase B), and C (phase C).<strong>&nbsp;</strong><br>
<br>
<strong>Source Index</strong><br>
Enter a number specifying the position of the phasor in the measurement stream. The indexes must start at 1 and be in the correct order so that the openPDC can correctly interpret the phasor data stream.<br>
<br>
The following example has five phasors belonging to the device Shelby.<br>
<img title="phasor_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_ManagePhasors.png" alt="phasor_example.png"><br>
<br>
Whenever a phasor is created, the openPDC Manager automatically creates measurements corresponding with the phasor. You can view those measurements by going to &quot;Manage &gt; Measurements&quot; or by clicking the &quot;Measurements&quot; link for that device
 on the devices page.</p>
<h4><a name="create_measurements"></a>Creating measurements</h4>
<p>By now, the openPDC Manager should have created most of the measurements for you. However, you have to enter any analog values, digital values, and calculated values by hand. You can manage your measurements by going to &quot;Manage &gt; Measurements&quot;.<br>
<br>
The following describes each of the fields and the types of information you can enter.<br>
<br>
<strong>Historian</strong><br>
Select the historian that will be archiving the measurement.<br>
<br>
<strong>Device</strong><br>
Select the device that is sending the measurement to one of your nodes.<br>
<br>
<strong>Measurement Type</strong><br>
Choose the type of measurement, such as Analog Value or Digital Value.<br>
<br>
<strong>Point Tag</strong><br>
The point tag is a short, formatted description of the measurement. The following convention is suggested.<br>
<br>
CCC_PPPP-DDDD:IIIH<br>
CCC is a three character company identifier.<br>
PPPP is a four character identification of the device.<br>
DDDD is an optional destination identifier (if there is no destination, leave this identifier out and remove the dash; not the colon)<br>
III is a manufacturer identifier.<br>
H is an abbreviation for the signal type (A for analog value, D for digital value, C for calculated value).<br>
<br>
<strong>Alternate Tag</strong><br>
An optional tag used to describe the measurement. This could be, for instance, the OSI-PI tag for a point.<br>
<br>
<strong>Signal Reference</strong><br>
The signal reference is vitally important to the system. It defines a link between a measurement and its device. The following describes the syntax for the signal reference.<br>
<br>
ACRONYM-SX#<br>
ACRONYM is the acronym of the device sending the measurement.<br>
SX is a two character suffix for the signal type (AV for analog value, DV for digital value, CV for calculated value).<br>
# is the index of the measurement, starting from 1 and incrementing by 1 for each additional measurement of the same signal type.<br>
<br>
A more detailed description of how to enter the signal reference can be found on the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Manual_Configuration.md#Measurement.SignalReference_column">
Manual Configuration</a> page.<strong>&nbsp;</strong><br>
<br>
<strong>Description</strong><br>
Optionally enter a short description of the measurement.<br>
<br>
<strong>Adder</strong><br>
Enter a value that will be added to the measurement before any processing takes place.<br>
<br>
<strong>Multiplier</strong><br>
Enter a value that will be multiplied with the measurement before any processing takes place.<br>
<br>
<strong>Enabled</strong><br>
Indicates whether the measurement is enabled.</p>
<p><strong>Subscribed</strong><br>
Indicates whether the measurement is subscribed from another openPDC or openPG.</p>
<p><strong>Internal</strong><br>
Indicates whether the measurement is internal to the openPDC or openPG and that can be subscribed by another one of any of these two.<br>
<br>
The following is an example of the result of having added a digital value to a device.<br>
<img title="measurement_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_ManageMeasurements.png" alt="measurement_example.png"></p>
<hr>
<h2><a name="configure_output"></a>Configuring outputs</h2>
<p>Now that you have created some inputs, you can begin configuring your outputs. This section will go over how to configure the openPDC to send the data to other devices or applications.</p>
<h3><a name="create_outputstreams"></a>Creating output streams</h3>
<p>The first step toward sending data out of the system is to create an output stream.<br>
<br>
In order to manage your output streams, go to &quot;Adapters &gt; Concentrator Output Streams&quot;.<br>
<img title="manage_outputs.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_AdaptersMenu.png" alt="manage_outputs.png"><br>
<br>
The following describes each of the fields and the types of information you can enter.<strong>&nbsp;</strong><br>
<br>
<strong>Acronym</strong><br>
Enter a character identifier for your output stream. By convention, the acronym should be entered using only capital letters and underscores.<br>
<br>
<strong>Name</strong><br>
Enter a name by which you can identify the output stream.<br>
<br>
<strong>Type</strong><br>
Select the protocol used to send the data. You can choose between IEEE C37.118 and BPA.<br>
<br>
<strong>ID Code</strong><br>
Enter an identification number. This number is used in some protocols to identify the sender. In other cases it is simply ignored.<br>
<br>
<strong>Connection String</strong><br>
If necessary, enter a string that defines the connection to the stream.<br>
<br>
<strong>TCP Channel</strong><br>
Enter connection settings (in connection string format) for the channel through which to issue commands to the stream.<br>
<br>
<strong>UDP Channel</strong><br>
Enter connection settings (in connection string format) for the channel through which data is being sent from the openPDC.<br>
<br>
<strong>Nominal Frequency</strong><br>
Enter the nominal frequency of the stream as an integer.<br>
<br>
<strong>Frames Per Second</strong><br>
Enter the number of frames per second of the stream as an integer.<br>
<br>
<strong>Lag Time</strong><br>
Enter the lag time in seconds as a floating point number. The lag time defines the amount of time to wait for all the data for a particular time frame to arrive. Any data arriving after the lag time has passed is discarded.<br>
<br>
<strong>Lead Time</strong><br>
Enter the lead time in seconds as a floating point number. The lead time is a measure of the accuracy of the local clock. Any measurements arriving with future timestamps that exceed the local time plus the lead time will be discarded.<br>
<br>
<strong>Auto Publish Config Frame</strong><br>
Indicates whether the system should automatically publish the configuration frame periodically in addition to waiting for requests on the command channel.<br>
<br>
<strong>Auto Start Data Channel</strong><br>
Indicates whether to automatically start the data channel.<br>
<br>
<strong>Use Local Clock As Real Time</strong><br>
Indicates whether the system should use the local clock as real time. If this is unchecked, the timestamp of the most recent measurement is used as real time.<br>
<br>
<strong>Allow Sorts By Arrival</strong><br>
Indicates whether to use the arrival time to sort the measurements instead of the timestamp.<br>
<br>
<strong>Load Order</strong><br>
Enter an integer value that represents the order in which this table's records are pulled from the database. The order goes from smallest to largest.<br>
<br>
<strong>Enabled</strong><br>
Indicates whether the output stream is enabled.<br>
<br>
Common Values:</p>
<table>
<tbody>
<tr>
<th>Type </th>
<th>Connection String </th>
</tr>
<tr>
<td>IEEE C37.118</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>BPA</td>
<td>iniFileName=TESTSTREAM.ini</td>
</tr>
</tbody>
</table>
<p><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_OutputStream1.png" alt="" width="957" height="491"></p>
<p><img title="output_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_OutputStream2.png" alt="output_example.png" width="959" height="491"></p>
<h3><a name="outputdevice_wizard"></a>Using the device wizard</h3>
<p>The simplest way to attach input devices to your output streams is to use the device wizard.<br>
<br>
In order to launch the wizard, pick the stream you wish to add devices to and click the &quot;Launch Device Wizard&quot; link.<br>
<img title="outputdevice_wizard.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_OutputStream3.png" alt="outputdevice_wizard.png"><br>
<br>
A small window titled &quot;Current Devices for TESTSTREAM&quot; should appear in a new page. At the bottom of the window, select the &quot;Add More Devices&quot; button.<br>
<img title="manage_outputdevices_wizard.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_CurrentDevicesOutputStream.png" alt="manage_outputdevices_wizard.png"><br>
<br>
Another window should then appear listing the input devices defined for the system. Select the devices you wish to add, don't forget to mark &quot;Add Analogs&quot; or &quot;Add Digitals&quot; if you so desire, and click the &quot;Add Selected&quot; button.<br>
<img title="add_new_outputdevice_wizard.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_CurrentDevicesNewDevice.png" alt="add_new_outputdevice_wizard.png" width="542" height="584"><br>
<br>
Any devices you added to the output stream will then disappear from this list and will be added to the &quot;Current Devices&quot; list. Once you are finished, close both windows and you will return to the output stream page. You can view any changes by clicking
 the &quot;Devices&quot; and &quot;Measurements&quot; links.</p>
<hr>
<h2><a name="create_outputdevices"></a>Creating virtual output devices</h2>
<p>The openPDC also allows you to create virtual output devices. A virtual output device is a device that does not physically exist, but devices and applications receiving the data will believe it exists. These devices are useful if you want to pick and choose
 which measurements should be sent to a certain device or application. In order to demonstrate the concept, we will go over an example of creating an output stream that sends all measurements from Shelby except for current magnitudes and current phase angles.
 We will be creating a virtual output device named Lupi to illustrate that the device does not physically exist.<br>
<br>
This section assumes you've gone through the previous sections and will not be describing the fields and types of information that can be entered in each window. Additionally, the examples in the previous section showed how to create the sample data set using
 the openPDC Manager (there are minor differences between the example and the sample data set, but for the purposes of this document they might as well be the same). This section will be building on those examples so if you wish to follow along, feel free to
 either use the examples or simply start with the sample data set.</p>
<h3><a name="create_outputstream_two"></a>Creating a second output stream</h3>
<p>The first thing we need to do is create a brand new output stream. Test Stream was designed to take all the measurements from Shelby and send them out to other applications or devices. This new output stream will be used to send all measurements except for
 current magnitudes and current phasors. The following image shows the screen with our Example Stream. The data entered into the fields is listed beneath the image.<br>
<br>
<img title="output_example_two.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_OutputStream4.png" alt="output_example_two.png"><br>
<br>
</p>
<table>
<tbody>
<tr>
<th>Field </th>
<th>Value </th>
</tr>
<tr>
<td>Node</td>
<td>Development</td>
</tr>
<tr>
<td>Acronym</td>
<td>EXAMSTREAM</td>
</tr>
<tr>
<td>Name</td>
<td>Example Stream</td>
</tr>
<tr>
<td>Type</td>
<td>IEEE C37.118</td>
</tr>
<tr>
<td>ID Code</td>
<td>240</td>
</tr>
<tr>
<td>Connection String</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>Command Channel</td>
<td>port=8950; transportprotocol=tcp; interface=0.0.0.0</td>
</tr>
<tr>
<td>Data Channel</td>
<td>port=-1; clients=localhost:8850; interface=0.0.0.0</td>
</tr>
<tr>
<td>Nominal Frequency</td>
<td>60</td>
</tr>
<tr>
<td>Frames Per Second</td>
<td>30</td>
</tr>
<tr>
<td>Lag Time</td>
<td>3</td>
</tr>
<tr>
<td>Lead Time</td>
<td>1</td>
</tr>
<tr>
<td>Auto Publish Config Frame</td>
<td>unchecked</td>
</tr>
<tr>
<td>Auto Start Data Channel</td>
<td>checked</td>
</tr>
<tr>
<td>Use Local Clock As Real Time</td>
<td>checked</td>
</tr>
<tr>
<td>Allow Sorts By Arrival</td>
<td>checked</td>
</tr>
<tr>
<td>Load Order</td>
<td>1</td>
</tr>
<tr>
<td>Enabled</td>
<td>checked</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<h3><a name="create_virtualoutputdevice"></a>Creating a virtual output device</h3>
<p>Click the &quot;Devices&quot; link on the new output stream and a window should appear titled &quot;Manage Devices For Output Stream&quot;. This is where we will be creating our virtual output device. Below is an image of the example as well as a list of
 the data entered into the fields.<br>
<br>
<img title="outputdevice_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_ManageDevices.png" alt="outputdevice_example.png"><br>
<br>
</p>
<table>
<tbody>
<tr>
<th>Field </th>
<th>Value </th>
</tr>
<tr>
<td>Acronym</td>
<td>LUPI</td>
</tr>
<tr>
<td>Name</td>
<td>Lupi</td>
</tr>
<tr>
<td>BPA Acronym</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>ID Code</td>
<td>240</td>
</tr>
<tr>
<td>Load Order</td>
<td>1</td>
</tr>
<tr>
<td>Enabled</td>
<td>checked</td>
</tr>
</tbody>
</table>
<p><br>
<br>
<strong>Note</strong>: BPA Acronym must be set for devices attached to a stream using the BPA protocol. The BPA Acronym can be a maximum of four characters.</p>
<h3><a name="create_outputphasors"></a>Creating phasors for your virtual output device</h3>
<p>Click the &quot;Phasors&quot; link on your virtual output device to start defining phasors. Since we are discarding all the measurements that are currents, we only need to define voltages in this table. Shelby has two voltages so we create two phasors in
 this table. The following image shows the two phasors and the table beneath it lists the values for each of them.<br>
<br>
<img title="outputphasor_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_Phasors.png" alt="outputphasor_example.png"><br>
<br>
</p>
<table>
<tbody>
<tr>
<th>Field </th>
<th>Value </th>
</tr>
<tr>
<td>Label</td>
<td>Shelby V1</td>
</tr>
<tr>
<td>Type</td>
<td>Voltage</td>
</tr>
<tr>
<td>Phase</td>
<td>Positive</td>
</tr>
<tr>
<td>Load Order</td>
<td>6</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<h3><a name="create_outputdigitals"></a>Creating digitals for your virtual output device</h3>
<p>When you create virtual output devices, you have to define the analog values and digital values just like how you define your phasors. In this example, Shelby has one digital value so we will only be defining one digital value for our virtual output device.
 Click the &quot;Digitals&quot; link for your virtual output device to start defining digital values. The following image shows the digital value and the table beneath it lists the values for the fields.<br>
<br>
<img title="outputdigital_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_ManageDevices.png" alt="outputdigital_example.png"><br>
<br>
</p>
<table>
<tbody>
<tr>
<th>Field </th>
<th>Value </th>
</tr>
<tr>
<td>Label</td>
<td>Shelby D1</td>
</tr>
<tr>
<td>Load Order</td>
<td>2</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<h3><a name="create_outputmeasurements"></a>Attaching measurements to the output stream</h3>
<p>This is the point where we pick and choose which input measurements will be associated with our virtual output device. Click the &quot;Measurements&quot; link on the output stream. A window will appear titled &quot;Manage Measurements For Output Stream&quot;.<br>
<br>
Click the button labeled &quot;...&quot; next to &quot;Source Measurement&quot;. Another window will appear containing a list of the measurements that were defined by your inputs. The measurements are identified by their point tag. The abbreviation for current
 magnitude is &quot;I&quot; and current angle is &quot;IH&quot; so we will choose all the measurements that do not end in either &quot;I&quot; or &quot;IH&quot;.<br>
<br>
<img title="add_outputmeasurements.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_SourceMeas.png" alt="add_outputmeasurements.png" width="595" height="452"><br>
<br>
Once you have selected all the measurements you want to associate with your virtual output device, click the &quot;Add Selected&quot; button. They will disappear from the list. Close that window and the measurements you selected will now appear in the &quot;Manage
 Measurements For EXAMPLESTREAM&quot; window. You will then need to modify the Signal Reference of the measurements you added in order to associate the measurements with your virtual output device.<br>
<br>
<img title="outputmeasurement_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_SourceMeas2.png" alt="outputmeasurement_example.png"></p>
<hr>
<h2><a name="view_real_time_data"></a>Viewing real-time data</h2>
<p>The node management page has a text field you can use to define a Time Series Data Service URL. It allows you to view openPDC data in real-time from an openPDC instance that is archiving the data locally. The following subsections will guide you in setting
 up and using this feature.</p>
<h3><a name="find_real_time_url"></a>Finding the Time Series Data Service URL</h3>
<p>The Time Series Data Service URL can be found in the openPDC configuration file named openPDC.exe.config. The value is found in the following location.<br>
<br>
</p>
<div style="color:black; background-color:white">
<pre><span style="color:blue">&lt;</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;</span><span style="color:#a31515">catgorizedSettings</span><span style="color:blue">&gt;</span>
        <span style="color:blue">&lt;</span><span style="color:#a31515">historianTimeSeriesDataService</span><span style="color:blue">&gt;</span>
            <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">ServiceURI</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[Time Series Data Service URL]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
        <span style="color:blue">&lt;/</span><span style="color:#a31515">historianTimeSeriesDataService</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;/</span><span style="color:#a31515">catgorizedSettings</span><span style="color:blue">&gt;</span>
<span style="color:blue">&lt;/</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
</pre>
</div>
<p><br>
<em>Note: The &lt;historianTimeSeriesDataService&gt; tag will vary based on the acronym of your local historian. The word &quot;historian&quot; will be replaced by the acronym.</em><br>
<br>
Enter this value into the Time Series Data Service URL field on the node management page and click the &quot;Save&quot; button to save your changes.</p>
<h3><a name="find_real_time_statistic_url"></a>Finding the Real-Time Statistic Service URL</h3>
<p>The Real-Time Statistic Service URL can be found in the openPDC configuration file named openPDC.exe.config. The value is found in the following location.<br>
<br>
</p>
<div style="color:black; background-color:white">
<pre><span style="color:blue">&lt;</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;</span><span style="color:#a31515">catgorizedSettings</span><span style="color:blue">&gt;</span>
        <span style="color:blue">&lt;</span><span style="color:#a31515">statTimeSeriesDataService</span><span style="color:blue">&gt;</span>
            <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">ServiceURI</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[Real-Time Statistic Service URL]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
        <span style="color:blue">&lt;/</span><span style="color:#a31515">statTimeSeriesDataService</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;/</span><span style="color:#a31515">catgorizedSettings</span><span style="color:blue">&gt;</span>
<span style="color:blue">&lt;/</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
</pre>
</div>
<p><br>
Enter this value into the Real-Time Statistic Service URL field on the node management page and click the &quot;Save&quot; button to save your changes.</p>
<h3><a name="real_time_graph"></a>The real-time data graph</h3>
<p>The real-time data graph can be found in the upper-right corner of the openPDC Manager home page. This graph can be used to see the value of a specific measurement in real-time. The drop-down list on the left allows you to select the device from which to
 select a measurement. The drop-down list on the right contains a list of the measurements associated with that device. The measurements are identified by their PointTag.
<br>
<br>
<img title="real_time_data_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_home.png" alt="real_time_data_example.png"></p>
<h3><a name="device_measurements_tree"></a>The device measurements tree</h3>
<p>The device measurements tree can be reached by going to &quot;Monitoring &gt;Device Measurements&quot;.<br>
<br>
<img title="view_real_time_measurements.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_deviceMeasu.png" alt="view_real_time_measurements.png"><br>
<br>
This tree shows information about all devices defined for the currently active node. Beneath each device is a list of all of the device's measurements as well as recent values and the timestamp for those values. These values are refreshed every 10 seconds.
 The lists can be collapsed or expanded at the user's will.<br>
<br>
<img title="real_time_measurements_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_Real-timeDeviceMEasu.png" alt="real_time_measurements_example.png"></p>
<hr>
<h2><a name="using_console_monitor"></a>Using the console monitor</h2>
<p>The node management page has a text field you can use to define a Remote Status Service URL. It allows you to view the openPDC Console output from within the openPDC Manager and also to send commands to the openPDC. The following subsections will guide you
 in setting up and using this feature.</p>
<h3><a name="find_remote_status_url"></a>Finding the Remote Status Service URL</h3>
<p>The Remote Status Service URL can be found in the openPDC Console configuration file named openPDCConsole.exe.config. The value is found in the following location.<br>
<br>
</p>
<div style="color:black; background-color:white">
<pre><span style="color:blue">&lt;</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;</span><span style="color:#a31515">catgorizedSettings</span><span style="color:blue">&gt;</span>
        <span style="color:blue">&lt;</span><span style="color:#a31515">remotingClient</span><span style="color:blue">&gt;</span>
            <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">ConnectionString</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[Remote Status Service URL]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
        <span style="color:blue">&lt;/</span><span style="color:#a31515">remotingClient</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;/</span><span style="color:#a31515">catgorizedSettings</span><span style="color:blue">&gt;</span>
<span style="color:blue">&lt;/</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
</pre>
</div>
<p><br>
<em>Note: The value will not look like a URL. Be sure to use the entire ConnectionString value within the quotes.</em><br>
<br>
Enter this value into the Remote Status Service URL field on the node management page and click the &quot;Save&quot; button to save your changes.</p>
<h3><a name="console_monitor"></a>The console monitor</h3>
<p>The console monitor can be found by going to &quot;Monitoring &gt; Remote Console&quot;.<br>
<br>
<img title="view_remote_console.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_Remote.png" alt="view_remote_console.png"><br>
<br>
On the left of this page is the system monitor which looks similar to the openPDC Console itself. On the right is a service command text box where you can enter the commands you would normally enter into the openPDC Console. Once you've entered a command, press
 Enter or click the &quot;Send&quot; button to send that command to the openPDC. The results will appear in the system monitor just like they would in the openPDC Console window.<br>
<br>
<img title="remote_console_example.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Manager_Configuration.files/openPDC_RemoteConsole.png" alt="remote_console_example.png"><br>
<br>
For more information about the commands you can send to the openPDC, see the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#use_openpdc_console">
Getting Started</a> page.</p>
<div id="_mcePaste" style="left:-10000px; top:11190px; width:1px; height:1px; overflow-x:hidden; overflow-y:hidden">
<pre style="font-family:Consolas; font-size:12; color:black; background:white"><span style="color:green">use&nbsp;of&nbsp;cached&nbsp;configuration&nbsp;during&nbsp;initial&nbsp;connection&nbsp;is&nbsp;allowed&nbsp;when&nbsp;a&nbsp;configuration&nbsp;has&nbsp;not&nbsp;been&nbsp;received&nbsp;within&nbsp;the&nbsp;data&nbsp;loss&nbsp;interval.</span>
</pre>
</div>
</div>
</div>
<div id="footer">
<hr />
Last edited <span class="smartDate" title="6/20/2012 3:00:12 PM" LocalTimeTicks="1340229612">Jun 20, 2012 at 3:00 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/alexfoglia.md">alexfoglia.htm</a>, version 71<br />
Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Manager%20Configuration">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
