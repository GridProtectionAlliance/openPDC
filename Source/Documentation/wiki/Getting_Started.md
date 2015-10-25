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
<h1>Getting Started with openPDC</h1>
<div class="wikidoc">This guide is intended to aid in building the openPDC software and setting it up to start using it. If you're already familiar with the guide, feel free to use this navigation tool to jump around.</div>
<div class="wikidoc">
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#openpdc_installers">Install openPDC with the installers</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#set_up_database">Manually set up the database</a>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#access_database">Setting up an Access database</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#sql_server_database">Setting up a SQL Server database</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#mysql_database">Setting up a MySQL database</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#modify_configuration">Modifying the configuration file</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#fix_configuration">Fix the configuration settings</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#encrypt_config_settings">Encrypt the configuration settings</a>
</li></ul>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#run_openpdc">Running the openPDC</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#use_openpdc_console">Using the openPDC console</a>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#help_command">See the list of commands (the help command)</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#list_command">See the list of adapters (the list command)</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#health_command">View performance details about the openPDC service (the health command)</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#status_command">View low level data (the status command)</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#connect_and_disconnect_commands">Connect and disconnect a PMU or PDC (the connect and disconnect commands)</a>
</li></ul>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#run_pmu_connection_tester">Running the PMU Connection Tester</a>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#create_and_verify_ieee_c37_118_2005_data_stream">Creating and verifying an IEEE C37.118-2005 data stream</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#create_and_verify_bpa_pdcstream_data_stream">Creating and verifying a BPA PDCstream data stream</a>
</li></ul>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#configure_openpdc_security">Configuring openPDC security</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#in_process_historian">Using the in-process historian adapter</a>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#metadata_web_service">Metadata Web Service</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#time_series_web_service">Time-series Web Service</a>
</li></ul>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#configure_connection_string">Configuring a Connection String</a>
<ul>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#file">File</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#tcp">TCP</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#udp">UDP</a>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#serial">Serial</a>
</li></ul>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">Installation directory</a>
</li></ul>
</div>
<hr>
<h2><a name="openpdc_installers"></a>Install openPDC with the installers</h2>
<p>This section goes over how to setup the openPDC and related components using the installers. The first thing you will need to do is download and extract the installers. For this you have two options:</p>
<ol>
<li>Install from the current release build:
<ol>
<li>Go to the &nbsp;<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Home Page</a> and select The
<strong>Downloads</strong> tab. </li><li>Under &quot;Recommended Download&quot;, click on the link labeled &quot;openPDCSetup.zip&quot;.
</li><li>Click &quot;I Agree&quot;. </li><li>Download and extract the installers to a directory of your choice. </li></ol>
</li><li>An alternative is to install from the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Nightly_Builds.md">
Nightly Builds</a>
<ol>
<li>Go to the&nbsp;<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Nightly_Builds.md">Nightly Builds</a> and&nbsp;click on the&nbsp;<strong>Synchrophasor Installers</strong> link.
</li><li>If prompted, agree to the Terms and Conditions </li><li>Download and extract the installers to a directory of your choice. </li></ol>
<p>&nbsp;Once you have extracted the downloaded file, you can install the following programs by running openPDCSetup.exe.</p>
<table border="1" style="border:1px solid #cccccc">
<tbody>
<tr>
<th style="font-weight:bold; font-size:110%">Program </th>
<th style="font-weight:bold; font-size:110%">Installer </th>
<th style="font-weight:bold; font-size:110%">Description </th>
</tr>
<tr>
<td>openPDC</td>
<td>openPDCSetup.exe&nbsp;&nbsp;&nbsp;</td>
<td>The main application installed as a Windows service.</td>
</tr>
<tr>
<td>openPDC Manager&nbsp;&nbsp;</td>
<td>openPDCSetup.exe</td>
<td>Graphics application used to help configure openPDC&nbsp;&nbsp;&nbsp;</td>
</tr>
</tbody>
</table>
<p><strong><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Nightly_Builds.md">Nightly Builds</a> Installers</strong> - These may vary with each build</p>
<table border="1" style="border:1px solid #cccccc">
<tbody>
<tr>
<th style="font-weight:bold; font-size:110%">Program </th>
<th style="font-weight:bold; font-size:110%">Installer </th>
<th style="font-weight:bold; font-size:110%">Description </th>
</tr>
<tr>
<td>openPDC</td>
<td>openPDCSetup.msi<br>
openPDCSetup64.msi</td>
<td>The main application installed as a Windows service.&nbsp;&nbsp;&nbsp;</td>
</tr>
<tr>
<td>PMU Connection TesterSetup</td>
<td>PMUConnectionTesterSetup.msi<br>
PMUConnectionTesterSetup64.msi</td>
<td>PMU Connection Tester Application</td>
</tr>
<tr>
<td>openPDC Manager (Web)</td>
<td>openPDCManagerWebSetup.msi</td>
<td>Web application used to help configure openPDC</td>
</tr>
<tr>
<td>openPDC Manager Services (Web)&nbsp;&nbsp;&nbsp;</td>
<td>openPDCManagerServicesSetup.msi&nbsp;&nbsp;&nbsp;&nbsp;</td>
<td>Web services used to help configure openPDC</td>
</tr>
</tbody>
</table>
<p>The web based openPDCManager is not included in openPDCSetup v1.2 and later releases.&nbsp;&nbsp;For the web based openPDCManager installers&nbsp;refer to the previous openPDC v1.1 release in the Synchrophasors.zip download.&nbsp; If you are installing the
 web based openPDC Manager, you will need to change the configuration file as described on the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#openpdcmanager_installer">
Frequently Asked Questions</a> page.</p>
<table border="1" style="border:1px solid #cccccc">
<tbody>
<tr>
<th style="font-weight:bold; font-size:110%">Web Program </th>
<th style="font-weight:bold; font-size:110%">Installers </th>
<th style="font-weight:bold; font-size:110%">Description </th>
</tr>
<tr>
<td>openPDC Manager&nbsp;&nbsp;&nbsp;</td>
<td>openPDCManagerWebSetup.msi, <br>
openPDCManagerServicesSetup.msi&nbsp;&nbsp;&nbsp;</td>
<td>Silverlight application used to help configure openPDC. <br>
Needs IIS 4.0 or later to be installed.</td>
</tr>
</tbody>
</table>
<p>The openPDC installer will automatically launch the database setup utility during the installation. Please note that the Access database will only work on 32-bit installations. If the database setup utility fails to install your database, your openPDC installation
 will not fail. You can run the database setup utility again once your installation has finished.</p>
</li></ol>
<p style="padding-left:30px">If the database setup utility has successfully installed your database, you can skip ahead to
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#run_openpdc">
Running the openPDC</a>. Otherwise, you will need to run the database setup utility again or go to
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#set_up_database">
Manually set up the database</a>.</p>
<p style="padding-left:30px">The following screen shots show how to perform a basic installation using the sample data available in the database:</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/1.png" alt=""></p>
<p style="padding-left:30px">Select the installation option. In this case, we are installing openPDC v 1.42 SP2 for Windows 7 x64 bits.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/2.png" alt=""></p>
<p style="padding-left:30px">Select the options you want to install and click next. After the installation is completed, a new window for the configuration of the openPDC will pop-up.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/3.png" alt=""></p>
<p style="padding-left:30px">Click next in this initial configuration window.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/4.png" alt=""></p>
<p style="padding-left:30px">Select the option for a new configuration.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/5.png" alt=""></p>
<p style="padding-left:30px">We recommend to set up a configuration based on a database (MySQL, SQL Server, etc.)</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/11.png" alt=""></p>
<p style="padding-left:30px">Select the database you want to use with the openPDC. In this example, we are using SQL Server. Also, select to run the data script (that will create the database) and run sample data script (that will create the sample data in
 the database for the openPDC to use). This last option is important if we just want to see the functionality of the openPDC with sample data. Click next.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/6.png" alt="" width="458" height="389"></p>
<p style="padding-left:30px">Check the Use integrated security box (in the case of SQL Server) and click on Test Connection button. The connection should be successful, otherwise, there is a problem with the configuration of the database and the openPDC will
 not properly work.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/7.png" alt=""></p>
<p style="padding-left:30px">Write down your windows authentication information (user name and password) and click next.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/8.png" alt=""></p>
<p style="padding-left:30px">Select the components to which you want to apply the configuration changes (by default, all checked). Click next.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/9.png" alt="" width="458" height="391"></p>
<p style="padding-left:30px">Select the primary historian. In this case, since we are using sample data, we do not need to save a history of any stream data. Therefore, we select virtual, which defines a testing output that does not save any measurements in
 the database. Click next two times and wait for the configuration to be completed.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/10.png" alt=""></p>
<p style="padding-left:30px">Click next after the configuration is completed and the PMU Connection Tester setup will pop-up immediately.</p>
<p style="padding-left:30px"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/PMU-1.png" alt=""></p>
<p style="padding-left:30px">Click next to install the PMU Connection Tester. Follow the directions and select the directory where to install this program.</p>
<p style="padding-left:30px"><strong>Note:</strong> The installation of the PMU Connection Tester is optional and the openPDC can perfectly run independently if this program is installed or not.</p>
<hr>
<h2><a name="set_up_database"></a>Manually set up the database</h2>
<ol>
<li>The following subsections will instruct you on setting up <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#access_database">
Access</a>, <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#sql_server_database">
SQL Server</a>, and <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#mysql_database">
MySQL</a> databases. You only need to set up one of these in order to run the openPDC.
<h3><a name="access_database"></a>Setting up an Access database</h3>
<p><strong>Note</strong>: Access is not recommended for use in production, but is considered to be a good option for development purposes.</p>
<ol>
<li>If you used the installers, navigate to the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
installation directory</a> and go to &quot;Database Scripts\Access&quot;. Otherwise, navigate to &quot;SOURCEDIR\Synchrophasor\Current Version\Source\Data\Access&quot; (SOURCEDIR is the directory where you extracted the openPDC source code files).
</li><li>Copy the file &quot;openPDC-SampleDataSet.mdb&quot; to your <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
installation directory</a>. </li><li>Rename the copy to &quot;openPDC.mdb&quot;. </li></ol>
<p>If you haven't configured the openPDC to use another type of database since you built it, you can skip ahead to
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#run_openpdc">
Run openPDC</a>. Otherwise, you will need to skip ahead to <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#modify_configuration">
modify the configuration file</a>.</p>
<h3><a name="sql_server_database"></a>Setting up a SQL Server database</h3>
<p>Microsoft SQL Server Express database engine and Management Studio are available for free from the Microsoft Download Center.&nbsp; If Visual Studio is installed, SQL Server Express may have been installed during the Visual Studio installation.&nbsp; You
 can also download and install SQL Server Express and Management Studio together. &nbsp;Below are links to the current SQL Server 2008 R2 Express downloads.</p>
<ul>
<li><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=8B3695D9-415E-41F0-A079-25AB0412424B&displayLang=en">Microsoft SQL Server 2008 R2 RTM - Express</a>
</li><li><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=56ad557c-03e6-4369-9c1d-e81b33d8026b&displayLang=en">Microsoft SQL Server 2008 R2 RTM - Management Studio Express</a>
</li><li><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=967225EB-207B-4950-91DF-EEB5F35A80EE&displayLang=en">Microsoft SQL Server 2008 R2 RTM - Express with Management Tools</a>
</li></ul>
<p><strong>Note</strong>:&nbsp; Before you execute openPDC.sql, you may want to make note that beginning on line 67 are instructions on how to modify the script to create a new user with access to the openPDC database.</p>
<ol>
<li>Launch SQL Server Management Studio Express, and connect to your database server.
</li><li>In the toolbar, go to &quot;File &gt; Open &gt; File...&quot; </li><li>If you used the installers, navigate to the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
installation directory</a> and go to &quot;Database Scripts\SQL Server&quot;. Otherwise, navigate to &quot;SOURCEDIR\Synchrophasor\Current Version\Source\Data\SQL Server&quot;, select &quot;openPDC.sql&quot;, and select &quot;Open&quot; (SOURCEDIR is the directory
 where you extracted the openPDC source code files). </li><li>In the toolbar, go to &quot;Query &gt; Execute&quot;. </li><li>Repeat steps 2-4 with the files &quot;InitialDataSet.sql&quot; and &quot;SampleDataSet.sql&quot; in the same directory.
</li></ol>
<p>Now skip ahead to <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#modify_configuration">
modifying the configuration file</a>.</p>
<h3><a name="mysql_database"></a>Setting up a MySQL database</h3>
<p>You will need to install MySQL 5.1 which is available at <a href="http://dev.mysql.com/downloads/mysql/5.1.html#downloads">
http://dev.mysql.com/downloads/mysql/5.1.html#downloads</a>. Simply choose your operating system and follow the instructions. Additionally, Windows users who will be connecting to the database through openPDC will need to install MySQL Connector Net 6.2 which
 is available at <a href="http://dev.mysql.com/downloads/connector/net/6.2.html">
http://dev.mysql.com/downloads/connector/net/6.2.html</a>.<br>
<br>
<strong>Note</strong>: Before you execute openPDC.sql, you may want to make note that beginning on line 17 are instructions on how to modify the script to create a new user with access to the openPDC database.</p>
<ol>
<li>Open your native command terminal. </li><li>If you used the installers, navigate to the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
installation directory</a> and go to &quot;Database Scripts\MySQL&quot; in the command terminal. Otherwise, navigate to &quot;SOURCEDIR\Synchrophasor\Current Version\Source\Data\MySQL&quot; (SOURCEDIR is the directory where you extracted the openPDC source
 code files). </li><li>Run the following command: &quot;mysql -uroot -p &lt; openPDC.sql&quot;. </li><li>Enter your root password and press &quot;Enter&quot;. </li><li>Repeat steps 3-4 with the files &quot;InitialDataSet.sql&quot; and &quot;SampleDataSet.sql&quot;.
</li></ol>
<h3><a name="modify_configuration"></a>Modifying the configuration file</h3>
<p>The configuration file, &quot;openPDC.exe.config&quot; or &quot;openPDC.config&quot; (found in your
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
installation directory</a>), is written in XML and can be opened with any text editor or with Microsoft Visual Studio 2008.<br>
<strong>Note</strong>: The configuration file is set up to work with Access out-of-the-box, so you can
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#run_openpdc">
skip this part</a> if you are using Access and haven't modified it since you built the openPDC. Also, you may skip this part since the latest version of the openPDC provides with a database connection auto-configuration that occurs during the installation process.<br>
<br>
This table contains the values for the settings in the configuration file that you need to modify. Refer to the code block below to find the settings that you need to modify.</p>
<table border="1" style="border:1px solid #cccccc">
<tbody>
<tr>
<th style="font-weight:bold; font-size:110%">Database </th>
<th style="font-weight:bold; font-size:110%">[ConnectionString] </th>
<th style="font-weight:bold; font-size:110%">[DataProviderString] </th>
<th style="font-weight:bold; font-size:110%">Notes </th>
</tr>
<tr>
<td>Access</td>
<td>Provider=Microsoft.Jet.OLEDB.4.0; Data Source=openPDC.mdb</td>
<td>AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.OleDb.OleDbConnection; AdapterType=System.Data.OleDb.OleDbDataAdapter</td>
<td>none</td>
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
install MySQL Connector Net</a>&nbsp;if you haven't already. You may also need to modify the Version key in the data provider string depending on your version of MySQL Connector Net.</td>
</tr>
</tbody>
</table>
<p><br>
<br>
You will need to modify the value property of the following settings using the values from the table above. Simply copy and paste the [ConnectionString] and [DataProviderString] corresponding to your database from the table.</p>
<div style="color:black; background-color:white">
<pre style="font-size:14px"><span style="color:blue">&lt;</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
  <span style="color:blue">&lt;</span><span style="color:#a31515">categorizedSettings</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;</span><span style="color:#a31515">systemSettings</span><span style="color:blue">&gt;</span>
      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">ConnectionString</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[Connection String]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">DataProviderString</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[DataProviderString]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
    <span style="color:blue">&lt;/</span><span style="color:#a31515">systemSettings</span><span style="color:blue">&gt;</span>
    <span style="color:blue">&lt;</span><span style="color:#a31515">historianAdoMetadataProvider</span><span style="color:blue">&gt;</span>
      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">ConnectionString</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[ConnectionString]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">DataProviderString</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">[DataProviderString]</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
    <span style="color:blue">&lt;/</span><span style="color:#a31515">historianAdoMetadataProvider</span><span style="color:blue">&gt;</span>
  <span style="color:blue">&lt;/</span><span style="color:#a31515">categorizedSettings</span><span style="color:blue">&gt;</span>
<span style="color:blue">&lt;/</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>
</pre>
</div>
<p><br>
<em>Note: &quot;historian&quot; in historianAdoMetadataProvider above will be replaced by the acronym of your local historian. If that section is not present in your configuration file, these settings will be copied from the systemSettings section the first
 time you run the openPDC.</em><br>
<br>
</p>
<h3><a name="fix_configuration"></a>Fix the configuration settings</h3>
<p>If you installed the openPDC using <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#openpdc_installers">
the openPDC installers</a>, you may need to fix some configuration settings.</p>
<ul>
<li>If you are using the built-in Access database, you may need to change the connection strings in the configuration file to
<span class="codeInline">Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Program Files\openPDC\openPDC.mdb
</span>(changing Data Source to an absolute path). </li></ul>
<p>&nbsp;</p>
<h3><a name="encrypt_config_settings"></a>Encrypt the configuration settings</h3>
<p>You may have noticed that you stored your password directly in the configuration file. The openPDC allows you to encrypt configuration file settings using a tool called the ConfigCrypter which is located in the Framework solution. The following details the
 steps needed to encrypt configuration file settings.</p>
<ol>
<li>Build the ConfigCrypter project which is located in the Framework solution. </li><li>Copy the ConfigCrypter executable (ConfigCrypter.exe) to the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
openPDC installation directory</a>. </li><li>Run the ConfigCrypter executable in the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
openPDC installation directory</a>. </li><li>Enter the connection string value into the text box labeled &quot;Input&quot;.
</li><li>Click the link labeled &quot;Copy to Clipboard&quot;. </li><li>Open the configuration file and paste the ConfigCrypter output as the value of the ConnectionString setting.
</li><li>Change the &quot;encrypted&quot; attribute for the ConnectionString setting to
<span class="codeInline">true</span>. </li></ol>
<p><br>
The following is an example of an encrypted ConnectionString setting.</p>
<div style="color:black; background-color:white">
<pre style="font-size:14px"><span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">ConnectionString</span><span style="color:black">&quot;</span>
  <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">Bb/ijHHcpbQi6ln/6w6SvmCtr4H2Ad51Ln26oiSo4YQpJbfxzlb8sNojupV8bK9qgIIoPP5CMjnq6CcrMFLd3k6BA1kSYC/1dWQKg499CsY=</span><span style="color:black">&quot;</span>
  <span style="color:red">description</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">Configuration database connection string</span><span style="color:black">&quot;</span> <span style="color:red">encrypted</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">true</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>
</pre>
</div>
<p><br>
<em>Note: If the historianAdoMetadataProvider section is not present in your configuration file, the ConnectionString setting will be decrypted and copied from systemSettings the first time you run the openPDC. You will need to stop the openPDC, encrypt the
 metadata provider setting, and then restart the openPDC to ensure that your ConnectionString setting remains encrypted.</em><br>
<br>
</p>
<hr>
<h2><a name="run_openpdc"></a>Running the openPDC</h2>
<p>If you installed the openPDC using <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#openpdc_installers">
the openPDC installers</a>, follow these steps.</p>
<ol>
<li>Go to &quot;Start &gt; Run...&quot;. </li><li>Type &quot;services.msc&quot; into the text box and click &quot;OK&quot;. </li><li>Find &quot;openPDC&quot; in the list, right-click it, and click &quot;Start&quot;.
</li></ol>
</li></ol>
<p style="padding-left:60px"><strong>Note</strong>: Once the openPDC is installed, its service should be running. Therefore, this step can be skipped.</p>
<ol>
<li>
<p><br>
If you built the project in Debug mode and want to run it using the debugger, follow these steps.</p>
<ol>
<li>Open Microsoft Visual Studio 2008. </li><li>In the toolbar, go to &quot;File &gt; Open &gt; Project/Solution...&quot; </li><li>Navigate to &quot;SOURCEDIR\Synchrophasor\Current Version\Source&quot;, select &quot;Synchrophasor.sln&quot;, and select &quot;Open&quot; (SOURCEDIR is the directory where you extracted the openPDC source code files).
</li><li>In the toolbar, go to &quot;Debug &gt; Start Debugging&quot;. </li></ol>
<p><br>
If you built the openPDC from source, you can run it as an application by navigating to your
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
installation directory</a> and double-clicking &quot;openPDC.exe&quot;.<br>
<br>
<br>
</p>
<hr>
<h2><a name="use_openpdc_console"></a>Using the openPDC console</h2>
<p>You can use the openPDC console to monitor the status of connections, configurations, errors, general statistics, and many other things.<br>
<br>
If you installed the openPDC using <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#openpdc_installers">
the openPDC installers</a>, you can run the console using the executable found in your
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">
installation directory</a> (and there should also be a shortcut in your Start menu). If you built it from source, the console should appear as soon as you begin running the openPDC application. Once the openPDC is ready, you can begin issuing commands through
 the console.<br>
<br>
The openPDC console commands typically have three options and are entered as follows:<br>
<br>
</p>
<table border="1" style="border:1px solid #cccccc">
<tbody>
<tr>
<th style="font-weight:bold; font-size:110%">Command </th>
<th style="font-weight:bold; font-size:110%">Description </th>
</tr>
<tr>
<td><em>command</em> /a</td>
<td>Executes the command on the Action Adapter Collection.</td>
</tr>
<tr>
<td><em>command</em> /i</td>
<td>Executes the command on the Input Adapter Collection.</td>
</tr>
<tr>
<td><em>command</em> /o</td>
<td>Executes the command on the Output Adapter Collection.</td>
</tr>
</tbody>
</table>
<p><br>
<br>
If you enter a command without any of the three options, it will default to the /i option. The following subsections will go over a few common uses of the system and their commands.<br>
<strong>Note</strong>: Since input and output are taken care of in the same console, an output statement may appear while you're in the middle of typing a command. Please ignore this occurrence and simply continue typing the command; the program will still
 handle the command properly.</p>
<h3><a name="help_command"></a>See the list of commands (the help command)</h3>
<p>The <strong>help</strong> command can be used to see a list of all commands that can be entered into the console.</p>
<h3><a name="list_command"></a>See the list of adapters (the list command)</h3>
<p>Used by itself, the <strong>list</strong> command will simply list the adapters in the specified adapter collection. Additionally, list can display detailed information about a specific adapter specified as an argument to the command. The argument can be
 either the name or the ID of the adapter. The following images show examples of this usage and its output.<br>
<br>
<img title="list_command_input_adapter.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/list_command_2.PNG" alt="list_command_2.png" width="676" height="1036"><br>
<br>
<img title="list_command_output_adapter.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/list_o_command.PNG" alt="list_command_output_adapter.png" width="674" height="963"></p>
<h3><a name="health_command"></a>View performance details about the openPDC service (the health command)</h3>
<p>The <strong>health</strong> command lists performance details about the openPDC service allowing the viewer to see the system state and performance statistics.</p>
<h3><a name="status_command"></a>View low level data (the status command)</h3>
<p>The <strong>status</strong> command outputs a significant amount of low level data about each connection. Due to the voluminous nature of this data, it is recommended that you look back to the &quot;StatusLog.txt&quot; file (located in the output directory
 &quot;SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\openPDC&quot;) which saves each output seen on the screen. If you only want detailed information on a specific adapter,
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#list_command">
the list command</a> can be used to display only that information.</p>
<h3><a name="connect_and_disconnect_commands"></a>Connect and disconnect a PMU or PDC (the connect and disconnect commands)</h3>
<p>The <strong>connect</strong> and <strong>disconnect</strong> commands are somewhat self-explanatory. These commands are used to connect and disconnect a PMU or PDC which is available as seen in the output of the list command. The adapter can be specified
 by entering its name or ID as an argument to the command. The following image shows an example of the usage of these commands.<br>
<br>
<img title="connect_and_disconnect_commands.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/connect_disconnect_command.PNG" alt="connect_and_disconnect_commands.png"><br>
<br>
<br>
</p>
<hr>
<h2><a name="run_pmu_connection_tester"></a>Running the PMU Connection Tester</h2>
<p>The PMU Connection Tester can be used to verify that the data stream from any known phasor measurement device is being received.<br>
<br>
If you are running the openPDC in Debug mode, you can run this application by right-clicking &quot;PMU Connection Tester&quot; in the Solution Explorer view and going to &quot;Debug &gt; Start new instance&quot;. You may need to redisplay the Solution Explorer
 view by going to &quot;View &gt; Solution Explorer&quot; in the toolbar.<br>
<br>
If you built the system from source and do not wish to run the PMU Connection Tester in the Visual Studio debugger, the executable can be found in one of the following directories (depending on whether you built the openPDC in Release mode or Debug mode respectively).</p>
<ul>
<li><span class="codeInline">SOURCEDIR\Synchrophasor\Current Version\Build\Output\Release\Tools\PMUConnectionTester
</span></li><li><span class="codeInline">SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\Tools\PMUConnectionTester
</span></li></ul>
<p>Where SOURCEDIR is the directory where you extracted the openPDC source code.<br>
<br>
The following subsections will instruct you on creating a data stream and verifying that it is being received.</p>
<h3><a name="create_and_verify_ieee_c37_118_2005_data_stream"></a>Creating and verifying an IEEE C37.118-2005 data stream</h3>
<ol>
<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#run_openpdc">Run openPDC</a>.
</li><li>Go to the PMU Connection Tester window and select the &quot;Udp&quot; tab toward the top of the window.
</li><li>In the text box labeled &quot;Local Port&quot;, enter &quot;8800&quot;. </li><li>In the drop-down list under the &quot;Protocol&quot; tab, select &quot;IEEE C37.118-2005&quot;.
</li><li>Still under the &quot;Protocol&quot; tab, click &quot;Configure alternate command channel&quot;.
</li><li>Clear the check box labeled &quot;Not defined&quot;. </li><li>In the text box labeled &quot;Port&quot;, enter &quot;8900&quot;. </li><li>Click &quot;Save&quot;. </li><li>Still under the &quot;Protocol&quot; tab, click &quot;Connect&quot;. </li></ol>
<p>The following images show the PMU Connection Tester windows populated with the correct settings and marked with numbers corresponding to those in the steps listed above.<br>
<br>
<img title="pmu_connection_tester_main_window.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/pmu_connection_tester_main_window.png" alt="pmu_connection_tester_main_window.png"><br>
<br>
<img title="pmu_connection_tester_command_channel.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/pmu_connection_tester_command_channel.png" alt="pmu_connection_tester_command_channel.png"><br>
<br>
</p>
<h3><a name="create_and_verify_bpa_pdcstream_data_stream"></a>Creating and verifying a BPA PDCstream data stream</h3>
<ol>
<li>In your openPDC database, modify the &quot;OutputStream&quot; table.
<ol>
<li>Change the value of the &quot;Type&quot; column to &quot;1&quot;. </li><li>Change the value of the &quot;ConnectionString&quot; column to &quot;iniFileName=TESTSTREAM.ini&quot;.
</li></ol>
</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#run_openpdc">Run openPDC</a>
</li><li>Go to the PMU Connection Tester window and select the &quot;Udp&quot; tab toward the top of the window.
</li><li>In the text box labeled &quot;Local Port&quot;, enter &quot;8800&quot;. </li><li>In the drop-down list under the &quot;Protocol&quot; tab, select &quot;BPA PDCstream&quot;.
</li><li>Select the &quot;Extra Parameters&quot; tab. </li><li>Select the &quot;ConfigurationFileName&quot; property and click &quot;...&quot;
</li><li>Navigate to &quot;SOURCEDIR\openPDC\Synchrophasor\Current Version\Build\Output\Debug\Applications\openPDC&quot;, select TESTSTREAM.ini, and select &quot;Open&quot; (SOURCEDIR is the directory where you extracted the openPDC source code files).
</li><li>Select the &quot;Protocol&quot; tab. </li><li>Click on &quot;Configure alternate command channel&quot;. </li><li>Ensure that the check box labeled &quot;Not defined&quot; is selected. </li><li>Select &quot;Save&quot;. </li><li>Still under the &quot;Protocol&quot; tab, click &quot;Connect&quot;. </li></ol>
<p>The following images show the PMU Connection Tester windows populated with the correct settings and marked with numbers corresponding to those in the steps listed above.<br>
<br>
<img title="bpa_pdcstream_pmu_connection_tester_main_window.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/bpa_pdcstream_pmu_connection_tester_main_window.png" alt="bpa_pdcstream_pmu_connection_tester_main_window.png"><br>
<br>
<img title="bpa_pdcstream_extra_parameters.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/bpa_pdcstream_extra_parameters.png" alt="bpa_pdcstream_extra_parameters.png"><br>
<br>
<img title="bpa_pdcstream_pmu_connection_tester_command_channel.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.files/bpa_pdcstream_pmu_connection_tester_command_channel.png" alt="bpa_pdcstream_pmu_connection_tester_command_channel.png"><br>
<br>
</p>
<hr>
<h2><a name="configure_openpdc_security"></a>Configuring openPDC security</h2>
<p>In the latest version, security is enabled by default. See&nbsp;<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Remote_Console_Security.md">Remote Console Security</a>&nbsp;for more information.</p>
<hr>
<h2><a name="in_process_historian"></a>Using the in-process historian adapter</h2>
<p>The in-process historian adapter optionally allows for the metadata and the time-series data stored in the local archive to be accessed via REST web services. The openPDC by default has both the metadata and time-series web services enabled, and they can
 be accessed at http://localhost:6151/historian and http://localhost:6152/historian URLs respectively. See below for a brief description of the REST API for these web services:<br>
<br>
<strong>Note</strong>: The format in which data is returned by these web services depend on the format specified at the end of all the URLs below. The formats currently supported by these web services are XML and JSON.</p>
<h3><a name="metadata_web_service"></a>Metadata Web Service</h3>
<p>- http://localhost:6151/historian/metadata/read/[xml|json]<br>
Returns metadata for all of the measurements defined in the archive.<br>
<br>
- http://localhost:6151/historian/metadata/read/&lt;one or more ID delimited by comma&gt;/[xml|json]<br>
Returns metadata for the measurement IDs specified in the comma-delimited list.<br>
<br>
- http://localhost:6151/historian/metadata/read/&lt;starting ID in the range&gt;-&lt;ending ID in the range&gt;/[xml|json]<br>
Returns metadata for all the measurement IDs specified in the range.<br>
<br>
</p>
<h3><a name="time_series_web_service"></a>Time-series Web Service</h3>
<p>- http://localhost:6152/historian/timeseriesdata/read/current/&lt;one or more ID delimited by comma&gt;/[xml|json]<br>
Returns the latest time-series data for the measurement IDs specified in the comma-delimited list.<br>
<br>
- http://localhost:6152/historian/timeseriesdata/read/current/&lt;starting ID in the range&gt;-&lt;ending ID in the range&gt;/[xml|json]<br>
Returns the latest time-series data for the measurement IDs specified in the range.<br>
<br>
- http://localhost:6152/historian/timeseriesdata/read/historic/&lt;one or more ID delimited by comma&gt;/&lt;start time&gt;/&lt;end time&gt;/[xml|json]<br>
Returns historic time series data for the measurement IDs specified in the comma-delimited list for the specified GMT time span. The time can be absolute time (Example: 09-21-09 23:00:01 for Sep 21, 09 11:00:01 pm) or relative to the current time (Example:
 * for now or *-1m for 1 minute ago where s = seconds, m = minutes, h = hours and d = days).<br>
<br>
- http://localhost:6152/historian/timeseriesdata/read/historic/&lt;starting ID in the range&gt;-&lt;ending ID in the range&gt;/&lt;start time&gt;/&lt;end time&gt;/[xml|json]<br>
Returns historic time series data for the measurement IDs specified in the range for the specified GMT time span (time format is same as above).<br>
<br>
</p>
<hr>
<h2><a name="configure_connection_string"></a>Configuring a Connection String</h2>
<p>This section contains information about how to configure the connection string for the MultiProtocolFrameParser. The connection string can be found on lines 29-31 of the code snippet from the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Device_to_Data.md">
Device to Data in 5 easy steps</a> page and also in the Device table of the openPDC database. The first step to configuring your connection string is to determine which transport protocol you're using and change the value of the transportProtocol key accordingly.
 The following subsections detail the keys that are specific to each transport protocol. The possible values for the transportProtocol key are
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#file">file</a>,
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#tcp">tcp</a>,
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#udp">udp</a>, and
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#serial">serial</a>.</p>
<h3><a name="file"></a>File</h3>
<p><strong>Note</strong>: The connection string is already configured for the file transport protocol in the
<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Developers_Device_to_Data.md#step3">
example code snippet</a>.<br>
<br>
The <strong>file</strong> key specifies the name of the file from which phasor measurements are read.<br>
<br>
The following is an example connection string using the file transport protocol:<br>
<br>
<span class="codeInline">phasorProtocol=Ieee1344; accessID=2; transportProtocol=file; file=Sample1344.PmuCapture
</span></p>
<h3><a name="tcp"></a>TCP</h3>
<p>The <strong>server</strong> key specifies the name or IP address of the device and the port on which it is listening (localhost:8888 or 127.0.0.1:8888 format).<br>
<br>
The <em>interface</em> key is optional and specifies the interface through which the TCP connection is being made.<br>
<br>
The following is an example connection string using the TCP transport protocol:<br>
<br>
<span class="codeInline">phasorProtocol=IeeeC37_118V1; accessID=5; transportProtocol=tcp; server=localhost:8888
</span></p>
<h3><a name="udp"></a>UDP</h3>
<p>The <strong>port</strong> key specifies which UDP port the device is broadcasting to.<br>
<br>
The <em>interface</em> key is optional and specifies the interface through which the UDP connection is being made.<br>
<br>
The <em>server</em> key is optional and is used to broadcast data over a UDP connection.<br>
<br>
The following is an example connection string using the UDP transport protocol:<br>
<br>
<span class="codeInline">phasorProtocol=BpaPdcStream; iniFileName=TestConfig.ini; transportProtocol=udp; port=8500
</span><br>
<br>
</p>
<h3><a name="serial"></a>Serial</h3>
<p>The <strong>port</strong> key can be entered as &quot;COM1&quot;, &quot;COM2&quot;, etc.<br>
<br>
The <strong>baudrate</strong> key is an integer.<br>
<br>
The <strong>parity</strong> key should be entered as one of the following: None, Odd, Even, Mark, Space.<br>
<br>
The <strong>stopbits</strong> key should be entered as one of the following: None, One, Two, OnePointFive.<br>
<br>
The <strong>databits</strong> key is an integer.<br>
<br>
The <em>dtrenable</em> key is is an optional boolean value that enables the Data Terminal Ready (DTR) signal.<br>
<br>
The <em>rtsenable</em> key is an optional boolean value that enables the Request to Send (RTS) signal.<br>
<br>
The following is an example connection string using the serial transport protocol:<br>
<br>
<span class="codeInline">phasorProtocol=SelFastMessage; transportProtocol=serial; port=COM1; baudrate=57600; parity=None; stopbits=One; databits=8
</span><br>
<br>
</p>
<hr>
<h2><a name="install_directory"></a>Installation directory</h2>
<p>If you installed the openPDC using <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#openpdc_installers">
the openPDC installers</a> the default installation directory can be found at the following location.<br>
<br>
<span class="codeInline">C:\Program Files\openPDC </span><br>
<br>
If you built the openPDC from source, the output directory is in one of two places (depending on whether you built the system in Release mode or Debug mode respectively).</p>
<ul>
<li><span class="codeInline">SOURCEDIR\Synchrophasor\Current Version\Build\Output\Release\Applications\openPDC
</span></li><li><span class="codeInline">SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\Applications\openPDC
</span></li></ul>
<p>Where SOURCEDIR is the directory where you extracted the openPDC source code.</p>
</li></ol>
</div>
<hr />
<div class="WikiComments">
<div id="comment31202">
    <div class="SubText">
        <a name="C31202"></a>
        <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/avinash_e.md">avinash_e</a>
        <span class="smartDate" title="1/8/2015 2:48:33 AM" localtimeticks="1420714113">Jan 8, 2015 at 2:48 AM</span>&nbsp;
        
</div>
    Hi Team,<br>when trying to open &#34;Open PDC Manager&#34; for the first time, i am receiving following error<br>An unexpected exception has occurred in openPDCManager. This may be due to an inconsistent system state or a programming error.<br>&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;<wbr>&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;<wbr>&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;<wbr>&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;&#42;<br>Error details&#58; openPDC Manager cannot connect to database&#58; Failed to open ADO data connection, verify &#34;ConnectionString&#34; in configuration file&#58; A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. &#40;provider&#58; SQL Network Interfaces, error&#58; 26 - Error Locating Server&#47;Instance Specified&#41;<p>
</div>
<div id="comment31201">
    <div class="SubText">
        <a name="C31201"></a>
        <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/avinash_e.md">avinash_e</a>
        <span class="smartDate" title="1/8/2015 2:40:36 AM" localtimeticks="1420713636">Jan 8, 2015 at 2:40 AM</span>&nbsp;
        
</div>
    Hello Developers,<br>I am new to this community and trying to setup Mysql database in my PC. In this i have got few basic query &#40;I completely new to software coding&#41; like&#58;<br>1. What does a native command terminal mean, is it the CMD of windows or CMD of Mysql installation&#63;<br>2. How to find &#34;line 17 are instructions on how to modify the script to create a new user&#34;&#63; i have opened the Mysql script using notepad but i am unable to find this <br>Please Help<br>Thank You<p>
</div>
<div id="comment30651">
    <div class="SubText">
        <a name="C30651"></a>
        <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/priyankarjk.md">priyankarjk</a>
        <span class="smartDate" title="8/5/2014 6:38:31 PM" localtimeticks="1407289111">Aug 5, 2014 at 6:38 PM</span>&nbsp;
        
</div>
    thank you Ritchie &#58;&#41;<p>
</div>
<div id="comment18750">
    <div class="SubText">
        <a name="C18750"></a>
        <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/ajstadlin.md">ajstadlin</a>
        <span class="smartDate" title="3/2/2011 4:40:24 PM" localtimeticks="1299112824">Mar 2, 2011 at 4:40 PM</span>&nbsp;
        
</div>
    Updated Microsoft .NET 4.0 Framework Installers URL to&#58;  http&#58;&#47;&#47;msdn.microsoft.com&#47;en-u<wbr>s&#47;library&#47;5a4x27ek.aspx<p>
</div>
<div id="comment15892">
    <div class="SubText">
        <a name="C15892"></a>
        <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/jmartinbeg.md">jmartinbeg</a>
        <span class="smartDate" title="6/1/2010 11:07:24 PM" localtimeticks="1275458844">Jun 1, 2010 at 11:07 PM</span>&nbsp;
        
</div>
    Thank you Ritchie&#33; Thoroughly enjoyed firing up openPDC PMU Connection Tester for the first time and watch it watch a file source connection. Very Good Ritchie, I loved it&#33; -Jeff<p>
</div>
</div>
<div id="footer">
<hr />
Last edited <span class="smartDate" title="2/26/2013 8:10:47 PM" LocalTimeTicks="1361938247">Feb 26, 2013 at 8:10 PM</span> by <a id="wikiEditByLink" href="http://www.codeplex.com/site/users/view/staphen">staphen</a>, version 131<br />
Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Getting%20Started">CodePlex</a> Oct 2, 2015 by <a href="http://www.codeplex.com/site/users/view/ajstadlin">ajs</a>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
