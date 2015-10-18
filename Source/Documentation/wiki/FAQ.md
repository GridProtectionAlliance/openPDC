

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>FAQ</title>



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

<h1>openPDC Frequently Asked Questions</h1>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#pmu_connection_tester">Where can I find the installer for the PMU Connection Tester?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#openpdc_build_scripts">Does the openPDC provide build scripts?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#openpdc_on_64bit">Can I run the openPDC on a 64-bit OS?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#openpdc_x86_targets">Why does the openPDC include x86 platform targets?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#openpdc_on_low_performance_machines">Can I run the openPDC on low-performance machines?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor">Synchrophasor Questions</a>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_openpdc">openPDC Questions</a>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_connection_is_to_concentrator">What happens to a device when you set a device&rsquo;s &ldquo;Connection is to Concentrator&rdquo; property to true?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#initial_vs_sample_database">What is the difference between the initial data set and the sample data set?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_sql_server_cannot_see_changes">I set up the SQL Server Management Studio and executed the SQL files, but how do I see the changes I made?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_device_acronym_unique">Does the Device ACRONYM need to be unique? The modeling instructions don't say so, but they do say that it is how the device is referenced by the program.</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#what_are_status_flags">What are the status flags measurements that are defined for each device?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_measurement_signalreference_unique">Does the SignalReference field in the Measurement table need to be unique?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#invalid_pointer_address">I receive an error like the following... (Invalid pointer address)</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_device_substation_association">Would data from a single PMU Device typically be used at more than one Substation? Or is a particular PMU strongly associated with a single Substation?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_concentrator_measurement_association">When the openPDC is collecting data from other PDCs, is the the parent (concentrator) device or the child device associated with a measurement?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_resynchronization_buffer">Is it possible to configure the minimum and maximum time delays that the openPDC waits for the data of the PMUs in the system arrive (also known as the &quot;resynchronization

 buffer&quot;)?</a> </li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#syncrophasor_configuration_file_will_not_save">I cannot get a setting I entered into the configuration file to save. When the application runs it keeps coming up blank and getting removed from the

 file. What&rsquo;s wrong?</a> </li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#support_redundant_configurations">Does the openPDC support redundant configurations?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#different_connections_under_connetion_type">What is the difference between Active, Passive or Hybrid connections as it appears in device status under Connection Type?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#sql_server_authentication_mode">I receive an error like the following... (SQL Server authentication mode)</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#sqlite_could_not_load_assembly">When setting up a SQLite database, I receive a message like the following, &quot;Could not load file or assembly 'System.Data.SQLite' or one of its dependencies.&quot;</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#reset_database">I need to reset my database. What should I do?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#access_database">I receive an error like the following when using an Access Database... (openPDC Manager::Access Denied)</a>

</li></ul>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#synchrophasor_openpdcmanager">openPDCManager Questions</a>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#sha2_not_supported">When I run the openPDC Manager, I receive an error that states my operating system does not support SHA-2 algorithms. How can I fix this?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#trouble_installing_silverlight">I am having trouble installing Silverlight Tools on my system. What does &quot;The hash value is not correct&quot; mean?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#trouble_installing_manager">I receive an error saying &quot;The installer was interrupted before openPDC Manager could be installed. You need to restart the installer to try again.&quot; But when I

 restart, it simply tells me the same thing. What should I do?</a> </li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#trouble_installing_missing_files">When I try to install openPDC, I recieve an error &quot;Cannot delete the existing openPDC.&quot;</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#openpdcmanager_installer">I just installed the openPDCManager. Why isn't it working properly?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#mime_types">When I go to the webpage, I just get a white screen with an &quot;error on page&quot; icon on the statusbar.</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#not_connecting_to_database">The openPDCManager doesn't appear to be connecting to my database.</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#cross_domain_error">Why am I receiving a CrossDomainError?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#local_historian_checkbox">What is the purpose of the local checkbox on the Manage Historians? Are there cases where they would not on the local network? What does this change when active?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#local_installed_service">The specified service does not exist as a installed service</a>

</li></ul>

</li></ul>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#historian">Historian Questions</a>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#windows_7_network_permissions">I receive an error like the following... (Windows 7 network permissions)</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#how_much_history_stored">I noticed that my history file seems to stay the same size all of the time. Does it only store a certain amount of history?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#historian_not_responding">How does the openPDC handle situations where a historian is not responding?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#locally_cached_measurements">How does the openPDC handle the locally cached measurements?</a>

</li></ul>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#hadoop">Hadoop Questions</a>

<ul>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#what_is_hadoop">What is Hadoop?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#how_does_hadoop_relate_to_openpdc">How does Hadoop relate to the openPDC?</a>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#how_are_openpdc_and_hadoop_used">How are Hadoop and openPDC used in production?</a>

</li></ul>

</li></ul>

<h3><a name="pmu_connection_tester"></a><span style="text-decoration:underline">Question</span>: Where can I find the installer for the PMU Connection Tester?</h3>

<p><span style="text-decoration:underline">Answer</span>: The latest installer for the PMU Connection Tester can be found in the

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Nightly_Builds.md">Nightly Builds</a>. See the

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/PMU_Connection_Tester.md">PMU Connection Tester</a> documentation page for more information.</p>

<h4><a name="openpdc_build_scripts"></a><span style="text-decoration:underline">Question</span>: Does the openPDC provide build scripts?</h4>

<p><span style="text-decoration:underline">Answer</span>: Yes, the entire build process is command line driven and currently the only files that are checked-out and checked-in are the version files (AssemblyInfo.*); we do not archive the build binaries in source

 control because the build script allows for building a specific version by passing in the version specs to the build script from the command line. The Build.bat file is just a simple wrapper that calls the MSBuild script and proxies the command line parameter

 for the BuildInteractive property that can be used for the build to take place in &ldquo;unattended&rdquo; mode (nice for automated nightly builds).<br>

<br>

The one trick to getting the build script to work correctly apart from having the required tools (mentioned in openPDC\Contributor Resources\Tools\Build Tools\Readme.txt) installed is to make sure that the build machine has an entry for the CodePlex TFS login

 credentials in Control Panel &gt; User Accounts &gt; Advanced tab &gt; Manage Passwords or else the build script might fail if the credentials have not been entered prior to the build by accessing CodePlex TFS from inside Visual Studio (see:

<a href="http://codeplex.codeplex.com/Wiki/View.aspx?title=Using%20TFS%20and%20Team%20Explorer%20with%20CodePlex&referringTitle=Home#Password">

Saving Password in Team Explorer</a>).<br>

<br>

Almost all the properties used by the build script can be overridden from the command line and the way this can be done is to run the build script from command line and overriding the default property values using the /p switch like:<br>

C:\WINDOWS\Microsoft.NET\Framework\v3.5\msbuild.exe Synchrophasor.buildproj /p:SkipHelpFiles=Yes;BuildDeployFolder=&quot;C:\Build&rdquo;<br>

A full list of overridable properties can be seen in the Master.buildproj file, but here are some handy ones:</p>

<ul>

<li>SkipHelpFiles &ndash; Yes or any other text to skip building the help docs. </li><li>BuildDeployFolder &ndash; Final destination of the build output; build output is always available where the build takes place (by default this is c:\windows\temp\msbuild\openpdc).

</li><li>BuildFlavor &ndash; Debug or Release. </li><li>SourceVersion &ndash; Specific version of the source code to be built. For example: C31221 to build committed changes up to changeset #31221.

</li><li>ForceBuild &ndash; true to force a build even if there are no new changes since the last successful build (By default the build process will be skipped if no new changes have been committed since the last successful build).

</li></ul>

<p>&nbsp;</p>

<h4><a name="openpdc_on_64bit"></a><span style="text-decoration:underline">Question</span>: Can I run the openPDC on a 64-bit OS?</h4>

<p><span style="text-decoration:underline">Answer</span>: Yes, but if you are using Access for your system configuration database you must run openPDC as a 32-bit application. We recommend using SQL Server, MySQL or other database in production so that you

 can run as a 64-bit application.</p>

<p>Note that later versions of the openPDC, starting at 2.0, only support 64-bit installations on Windows platforms. SQLite is the recommended &quot;no installation required&quot; database for new versions of openPDC.</p>

<h4><a name="openpdc_x86_targets"></a><span style="text-decoration:underline">Question</span>: Why does the openPDC include x86 platform targets?</h4>

<p><span style="text-decoration:underline">Answer</span>: This is to force the build outputs to run as a 32-bit app on a 64-bit system so that it will also work with Access if needed. AnyCPU targets cause applications to run as 64-bit on 64-bit systems and

 32-bit on 32-bit systems - x86 forces 32-bit operation on 32-bit or 64-bit systems.<br>

<br>

The automated nightly build forces a complete x86 build of the entire system (available as openPDCSetup.msi (x86) - opposed to openPDCSetup64.msi (AnyCPU)) so that when you install the 32-bit version of the openPDC on a 64-bit system, it will run as a 32-bit

 system that will work with Access, even though you are on a 64-bit server.<br>

<br>

Also, you change the target output for the entire solution in Visual Studio to x86 (this is a local user setting) and run with an Access database for your configuration.</p>

<h4><a name="openpdc_on_low_performance_machines"></a><span style="text-decoration:underline">Question</span>: Can I run the openPDC on low-performance machines?</h4>

<p><span style="text-decoration:underline">Answer</span>: Yes, but you may need to lower the process priority of the openPDC to High instead of RealTime in order to prevent locking of the system on single-core machines, particularly if you've chosen to use

 a MySQL database for your openPDC configuration. There is a setting in the configuration file (openPDC.exe.config, found in the

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#install_directory">

installation directory</a>) that you can use to change the process priority of the openPDC.<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">&lt;</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>

  <span style="color:blue">&lt;</span><span style="color:#a31515">categorizedSettings</span><span style="color:blue">&gt;</span>

    <span style="color:blue">&lt;</span><span style="color:#a31515">systemSettings</span><span style="color:blue">&gt;</span>

      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">ProcessPriority</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">High</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>

    <span style="color:blue">&lt;/</span><span style="color:#a31515">systemSettings</span><span style="color:blue">&gt;</span>

  <span style="color:blue">&lt;/</span><span style="color:#a31515">categorizedSettings</span><span style="color:blue">&gt;</span>

<span style="color:blue">&lt;/</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>

</pre>

</div>

<p>Starting with version 2.1 of the openPDC, you can now <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_on_a_Raspberry_Pi.md" target="_blank">

run the openPDC on a Raspberry Pi</a>.<br>

</p>

<hr>

<h2><a name="synchrophasor"></a>Synchrophasor Questions</h2>

<h3><a name="synchrophasor_openpdc"></a>openPDC Questions</h3>

<h3><a name="synchrophasor_connection_is_to_concentrator"></a>What happens to a device when you set a device&rsquo;s &ldquo;Connection is to Concentrator&rdquo; property to true?</h3>

<p><span style="text-decoration:underline">Answer</span>: The &quot;Connection is to Concentrator&quot; property designates the device connection as having more than one device in a frame since a connection to multiple devices for a single connection has to

 be handled a little differently than a connection that contains a connection to a single device. Think of it this way: the openPDC models every device (i.e., PMU) regardless of its source - that is, whether the device came by proxy through a concentrator or

 directly it has its own definition. The connection information can then either be associated with device itself (direct connection) or its parent concentrator (which is also technically a &quot;device&quot;) - so the flag simply defines if the connection has

 data or if the connection contains devices which have data. If you check this box the system will expect to have some children devices defined for it (even if only one).</p>

<h4><a name="initial_vs_sample_database"></a><span style="text-decoration:underline">Question</span>: What is the difference between the initial data set and the sample data set?</h4>

<p><span style="text-decoration:underline">Answer</span>: Please note the following table.<br>

</p>

<table>

<tbody>

<tr>

<th>Database Type</th>

<th>Structural Definition</th>

<th>Initial Data Set</th>

<th>Sample Data Set</th>

</tr>

<tr>

<td>SQL Server</td>

<td>openPDC.sql</td>

<td>InitialDataSet.sql</td>

<td>SampleDataSet.sql</td>

</tr>

<tr>

<td>MySQL</td>

<td>openPDC.sql</td>

<td>InitialDataSet.sql</td>

<td>SampleDataSet.sql</td>

</tr>

<tr>

<td>SQLite</td>

<td>openPDC.db</td>

<td>openPDC-InitialDataSet.db</td>

<td>openPDC-SampleDataSet.db</td>

</tr>

<tr>

<td>MS Access</td>

<td>openPDC.mdb</td>

<td>openPDC-InitialDataSet.mdb</td>

<td>openPDC-SampleDataSet.mdb</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<ul>

<li>The structural definition is just the database structure with absolutely no data.

</li><li>The initial data set is the recommended initial data set for the openPDC with no nodes, devices, or output streams.

</li><li>The sample data set is the initial data set plus one defined node, sample input and output stream for &quot;out-of-the-box&quot; testing.

</li></ul>

<p>&nbsp;</p>

<h4><a name="synchrophasor_sql_server_cannot_see_changes"></a><span style="text-decoration:underline">Question</span>: I set up the SQL Server Management Studio and executed the SQL files, but how do I see the changes I made?</h4>

<p><span style="text-decoration:underline">Answer</span>: In the Object Explorer view on the left, right-click on &quot;Databases&quot; and select &quot;Refresh&quot;. The openPDC database will now show up in the list of Databases.<br>

</p>

<h4><a name="synchrophasor_device_acronym_unique"></a><span style="text-decoration:underline">Question</span>: Does the Device ACRONYM need to be unique? The modeling instructions don't say so, but they do say that it is how the device is referenced by the

 program.</h4>

<p><span style="text-decoration:underline">Answer</span>: Yes, this acronym must be unique. It becomes a key part of the signal reference used to identify and associate measurements to their PMU values.<br>

</p>

<h4><a name="what_are_status_flags"></a><span style="text-decoration:underline">Question</span>: What are the status flags measurements that are defined for each device?</h4>

<p><span style="text-decoration:underline">Answer</span>: The status flags measurement is a double-word bitmapped flag contained in each frame that holds data about the device and its measurements.<br>

<br>

<strong>Upper Word</strong> - This is an &lsquo;Abstracted&rsquo; set of flags that are consistent across all devices regardless of their protocol for reporting to the openPDC:</p>

<ul>

<li>Bits 31&ndash;21: Reserved </li><li>Bit 20: Data discarded : 0 when data is discarded from the real-time stream due to late arrival.

</li><li>Bit 19: Data valid : 0 when PMU data is valid, 1 when invalid or PMU is in test mode.

</li><li>Bit 18: Synchronization valid : 0 when in device is in sync, 1 when it is not.

</li><li>Bit 17: Data sorting : 0 by time stamp, 1 by arrival. </li><li>Bit 16: Device error (including configuration error) : 0 when in error. </li></ul>

<p><br>

<strong>Lower Word</strong> - These are the 'Original' set of status flags reported by device itself and would therefore be protocol specific.<br>

For the IEEE C37.118 protocol, this lower byte has the following mapping:</p>

<ul>

<li>Bit 15: Data valid - 0 when PMU data is valid, 1 when invalid or PMU is in test mode.

</li><li>Bit 14: PMU error including configuration error - 0 when no error. </li><li>Bit 13: PMU sync - 0 when in sync. </li><li>Bit 12: Data sorting - 0 by time stamp, 1 by arrival. </li><li>Bit 11: PMU trigger detected - 0 when no trigger. </li><li>Bit 10: Reserved for future common flags - presently set to 0. </li><li>Bits 09-06: Reserved for security - presently set to 0. </li><li>Bits 05-04: Unlocked time:

<ul>

<li>00 = sync locked, best quality </li><li>01 = Unlocked for 10 s </li><li>10 = Unlocked for 100 s </li><li>11 = Unlocked over 1000 s </li></ul>

</li><li>Bits 03-00: Trigger reason:

<ul>

<li>1111-1000 = Available for user definition </li><li>0111 = Digital </li><li>0110 = Reserved </li><li>0101 = df/dt high </li><li>0100 = Frequency high/low </li><li>0011 = Phase-angle diff </li><li>0010 = Magnitude </li></ul>

</li></ul>

<p>&nbsp;</p>

<h4><a name="synchrophasor_measurement_signalreference_unique"></a><span style="text-decoration:underline">Question</span>: Does the SignalReference field in the Measurement table need to be unique?</h4>

<p><span style="text-decoration:underline">Answer</span>: Like device acronyms, signal reference values must be unique (the database definitions should enforce this constraint). The signal reference creates an association between a unique individual signal

 (i.e., a measurement) and a channel value within a parsed frame of phasor data from a specific PMU.<br>

</p>

<h4><a name="invalid_pointer_address"></a><span style="text-decoration:underline">Question</span>: I receive an error like the following:</h4>

<p><br>

<strong>The system detected an invalid pointer address in attempting to use a pointer argument in a call.</strong><br>

<br>

<span style="text-decoration:underline">Answer</span>: Recent Windows versions default to IPv6 addressing. You will need to either supply DNS or IPv6 addresses (e.g., ::1 which is the IPv6 equivalent of 127.0.0.1) or force IPv4 addressing. In order to force

 IPv4 addressing, either add interface=0.0.0.0 to the connection string or, if you are using the PMU Connection Tester, change ForceIPv4 to true in the PMU Connection Tester configuration.<br>

</p>

<h4><a name="synchrophasor_device_substation_association"></a><span style="text-decoration:underline">Question</span>: Would data from a single PMU Device typically be used at more than one Substation? Or is a particular PMU strongly associated with a single

 Substation?</h4>

<p><span style="text-decoration:underline">Answer</span>: PMU definitions in the system normally refer directly to a piece of field hardware which is typically located at a substation. The important concept is one definition for one physical device regardless

 of delivery mechanism (direct connection, within a concentration stream from a PDC, etc.) If the same device data comes in from multiple streams and it is desirable to capture all instances of the data - the device will have to be modeled and named separately

 for each stream (e.g., MYPMU-1, MYPMU-2). This may be useful for critical devices that have a primary and backup data flow.<br>

</p>

<h4><a name="synchrophasor_concentrator_measurement_association"></a><span style="text-decoration:underline">Question</span>: When the openPDC is collecting data from other PDCs, is the the parent (concentrator) device or the child device associated with

 a measurement?</h4>

<p><span style="text-decoration:underline">Answer</span>: Measurements are always associated with a PMU. The PDC record exists only to define the &quot;connection&quot; and which PMU's will arrive through this connection. After this it has no further purpose.<br>

</p>

<h4><a name="synchrophasor_resynchronization_buffer"></a><span style="text-decoration:underline">Question</span>: Is it possible to configure the minimum and maximum time delays that the openPDC waits for the data of the PMUs in the system arrive (also known

 as the &quot;resynchronization buffer&quot;)?</h4>

<p><span style="text-decoration:underline">Answer</span>: Yes, the <strong>LagTime</strong> and

<strong>LeadTime</strong> columns in the OutputStream table are the &quot;resynchronization&quot; parameters. They operate is as follows:<br>

<br>

LagTime is a double precision number that defines the allowed past time deviation tolerance, in seconds (can be subsecond). It defines the time sensitivity to past measurement timestamps and is the number of seconds allowed before assuming a measurement timestamp

 is too old. This becomes the maximum amount of delay that can be introduced by the concentrator to allow time for data to flow into the system.<br>

<br>

LeadTime is a double precision number that defines the allowed future time deviation tolerance, in seconds (can be subsecond). It defines the time sensitivity to future measurement timestamps and is the number of seconds allowed before assuming a measurement

 timestamp is too advanced. This becomes the tolerated &#43;/- accuracy of the local clock to real-time.<br>

<br>

Because the measurements being received by remote phasor devices are usually measured relative to GPS time, these timestamps are typically more accurate than the local system clock. As a result, we can use the latest received timestamp as the best local time

 measurement we have (ignoring transmission delays); but, even these times can be incorrect so we still have to apply reasonability checks to these times. To do this, we use the local system time and the LeadTime value to validate the latest measured timestamp.

 If the newest received measurement timestamp gets too old or creeps too far into the future (both validated &#43; and - against defined lead time property value), we will fall back on local system time. Note that this creates a dependency on a fairly accurate

 local clock - the smaller the lead time deviation tolerance, the better the needed local clock accuracy. For example, a lead time deviation tolerance of a few seconds might only require keeping the local clock synchronized to an NTP time source; but, a sub-second

 tolerance would require that the local clock be very close to GPS time.<br>

<br>

Note that your lag time should be defined as it relates to the rate at which data is coming into the concentrator. Make sure you allow enough time for transmission of data over the network allowing any needed time for possible network congestion. Lead time

 should be defined as your confidence in the accuracy of your local clock (e.g., if you set lead time to 2, this means you trust that your local clock is within plus or minus 2 seconds of real-time.)<br>

<br>

The other important property is UseLocalClockAsRealTime which defines a flag that determines whether or not to use the local clock time as real time. You should only use your local system clock as real time if the time is locally GPS hardware-synchronized or

 if the incoming measurement values being sorted were not measured relative to a GPS-synchronized clock (e.g., non PMU device).<br>

</p>

<h4><a name="syncrophasor_configuration_file_will_not_save"></a><span style="text-decoration:underline">Question</span>: I cannot get a setting I entered into the configuration file to save. When the application runs it keeps coming up blank and getting removed

 from the file. What&rsquo;s wrong?</h4>

<p><span style="text-decoration:underline">Answer</span>: This setting may be set up for encryption. Check the &ldquo;encrypted&rdquo; attribute, and make sure it is set to encrypted=&quot;false&quot;.<br>

</p>

<h4><a name="support_redundant_configurations"></a><span style="text-decoration:underline">Question</span>: Does the openPDC support redundant configurations?</h4>

<p><span style="text-decoration:underline">Answer</span>: There are two primary options for configuring the openPDC to support system redundancy using typical clustering technologies. When deployed as a Windows service, the openPDC supports both &ldquo;fail

 over&rdquo; and &ldquo;load balanced&rdquo; configurations:</p>

<ol>

<li>The most common, and easiest to configure, redundancy deployment option will be the &ldquo;fail over&rdquo; cluster. In this mode, the openPDC is deployed on two systems: a primary and a hot stand-by. Both the primary and hot stand-by nodes will both share

 the same configuration and archive data to the same location, as only one of the systems will be active at one time. When one system fails or needs to go offline for maintenance, the other system is activated.

</li><li>Although more involved to set up and configure, the openPDC can be deployed in a load-balanced environment. In this mode, multiple openPDC instances are up and running simultaneously. Additionally, each open PDC would be set up in server mode, listening

 for incoming connections and/or streaming data. All incoming data would be passed to an openPDC via a data proxy. The data proxy could be set up as an adapter in a &ldquo;substation&rdquo; openPDC, then sent to the control center load-balanced openPDC cluster.

 The load balanced option also allows for all the openPDC data services to be &ldquo;distributed&rdquo; to clients based on load.

</li></ol>

<h4><a name="different_connections_under_connetion_type"></a><span style="text-decoration:underline">Question</span>: What is the difference between Active, Passive or Hybrid connections, as it appears in device status under Connection Type?</h4>

<p><span style="text-decoration:underline">Answer</span>: Connections to devices can be direct &ldquo;active&rdquo; (such as TCP or serial) or unattended &ldquo;passive&rdquo; (such as UDP). Both transports styles have their pros and cons. Active traffic is

 typically sent with a transport level CRC and will &ldquo;resend&rdquo; if a packet failed to transport; since this is data is time-sensitive in nature, this can cause live data streams to fall further and further behind over time. Because of this issue, active

 style connections are only recommended for smaller data payloads, like those delivered from a connection to a single device. Passive traffic is broadcast without concern about whether or not the intended recipient received the data. This has been described

 effectively as &ldquo;turning on the fire-hose&rdquo;. The good thing about a passive connection is that data stream will not fall behind; it doesn&rsquo;t care if you missed a packet. But, therein lies the primary issue with passive transports. More recent

 devices are supporting an active &ldquo;command&rdquo; channel and a passive &ldquo;data&rdquo; channel, a &ldquo;hybrid&rdquo; connection type which is ideal for protocols requiring control commands to request a configuration and/or start a data stream. Future

 protocol versions supporting this kind of dual connectivity should be able to solve all aforementioned transport issues with passive channel packet loss by allowing the command channel to re-request missed packets from a local short term archive. This would

 not necessarily be useful from a real-time perspective but would be valuable in making sure your archive was complete.<br>

</p>

<h4><a name="sql_server_authentication_mode"></a><span style="text-decoration:underline">Question</span>: I receive an error like the following:</h4>

<p><br>

<strong>WARNING: Failed to load database configuration due to exception: Login failed for user 'openPDCUser'. The user is not associated with a trusted SQL Server connection. Attempting to use last known good configuration.</strong><br>

<br>

<span style="text-decoration:underline">Answer</span>: This error can be caused by setting up the wrong authentication mode for your SQL Server (for example, you set up your SQL server for Windows Authentication mode only). Follow these steps to fix it:</p>

<ol>

<li>Launch SQL Server Management Studio Express. </li><li>Connect to your server. </li><li>In the Object Explorer on the left, right-click the server and select &quot;Properties&quot;.

</li><li>On the left under &quot;Select a page&quot;, select &quot;Security&quot;. </li><li>Under &quot;Server authentication&quot;, select &quot;SQL Server and Windows Authentication mode&quot;.

</li><li>Select &quot;OK&quot;. </li><li>In the Object Explorer, right-click on the server again, and select &quot;Restart&quot;. (<strong>NOTE</strong>: You may need to run SQL Server Management Studio Express as an administrator in order to restart the server.)

</li><li>Once the server has restarted, try running openPDC again. </li></ol>

<p>&nbsp;</p>

<h4><a name="sqlite_could_not_load_assembly"></a>Question: When setting up a SQLite database, I receive a message like the following, &quot;Could not load file or assembly 'System.Data.SQLite' or one of its dependencies.&quot;</h4>

<p><span style="text-decoration:underline">Answer</span>: You may need to install the Microsoft Visual C&#43;&#43; 2010 Redistributable Package. They can be found at the following locations.</p>

<p><a href="http://www.microsoft.com/download/en/details.aspx?id=14632">Microsoft Visual C&#43;&#43; 2010 Redistributable Package (x64)</a><br>

<a href="http://www.microsoft.com/download/en/details.aspx?id=5555">Microsoft Visual C&#43;&#43; 2010 Redistributable Package (x86)</a>&nbsp;</p>

<p>Also make sure the SQLite assemblies can be found in the openPDC installation folder.</p>

<h4><a name="reset_database"></a><span style="text-decoration:underline">Question</span>: I need to reset my database. What should I do?</h4>

<p><span style="text-decoration:underline">Answer</span>: Use the Configuration Setup Utility to create a new database - this is the simplest and preferred way to create a new configuration.</p>

<p>If you need to do this manually, follow these steps corresponding to your database:

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#reset_access">SQLite/Access</a>,

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#reset_sql_server">SQL Server</a>, or

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.md#reset_mysql">MySQL</a>.</p>

<p><strong>IMPORTANT</strong>: The following steps will reset the database back to the state when you first created it. Any information you entered into the database will be lost.<br>

<br>

<a name="reset_access"></a><strong>Resetting your SQLite / Access database</strong></p>

<ol>

<li>Navigate to &quot;SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\openPDC&quot; and delete the file &quot;openPDC.db&quot; for SQLite or &quot;openPDC.mdb&quot; for Access (SOURCEDIR is the directory where you extracted the openPDC source code

 files). <em>Note that the database may be installed in another folder if not runing from source code.</em>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#access_database">Set up your Access database</a>.

</li></ol>

<p><br>

<a name="reset_sql_server"></a><strong>Resetting your SQL Server database</strong></p>

<ol>

<li>Launch SQL Server Management Studio Express and connect to your database server.

</li><li>In the Object Explorer on the left, expand &quot;Databases&quot;. </li><li>Right-click &quot;openPDC&quot; and select &quot;Delete&quot;. </li><li>Select the check box labeled &quot;Close existing connections&quot;, and select &quot;OK&quot;.

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#sql_server_database">Set up your SQL Server database</a>.

</li></ol>

<p><br>

<a name="reset_mysql"></a><strong>Resetting your MySQL database</strong></p>

<ol>

<li>Open your native command terminal and run the following command: &quot;mysql -uroot -p&quot;.

</li><li>Enter your root password and press &quot;Enter&quot;. </li><li>Once you've entered the MySQL prompt, enter the following commands:

<ol>

<li>DROP DATABASE openPDC; </li><li>exit </li></ol>

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Getting_Started.md#mysql_database">Set up your MySQL database</a>.

</li></ol>

<h4><a name="access_database"></a><span style="text-decoration:underline">Question</span>: I receive an error like the following when using an Access Database:</h4>

<p>*openPDC Manager::Access Denied: Error Loading security provider: Operation must use an updatable query<br>

<br>

<span style="text-decoration:underline">Answer</span>: This error usually occurs when the Access database is saved to a folder that you do not have permission to. Try one of the following to fix this error:</p>

<ul>

<li>Navigate to C:\Program Data\openPDC and right-click on the openPDC Access file. Uncheck the box that says &quot;read-only&quot;, then click 'OK'.

</li><li>When setting up the Access database with the configuration utility, browse to a different location on the &quot;Set up an Access database&quot; screen and proceed with the configuration.

</li></ul>

<h3><a name="synchrophasor_openpdcmanager"></a>openPDCManager Questions</h3>

<h4><a name="sha2_not_supported"></a><strong><span style="text-decoration:underline">Question</span>: When I run the openPDC Manager, I receive an error that states my operating system does not support SHA-2 algorithms. How can I fix this?</strong></h4>

<p><span style="text-decoration:underline">Answer</span>:&nbsp;Go to registry key&nbsp;<strong>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Cryptography\Defaults\Provider</strong>, find its subkey named &quot;Microsoft Enhanced RSA and AES Cryptographic Provider (Prototype)&quot;,

 export it to .reg, edit this .reg and delete &quot; (Prototype)&quot; from its name. When you import it back, the original key will be duplicated to the new key without (Prototype), with the same contents. From now on, SHA256CryptoServiceProvider will work

 on this XPSP3 machine.</p>

<p>&nbsp;</p>

<h4><a name="trouble_installing_silverlight"></a><span style="text-decoration:underline">Question</span>: I am having trouble installing Silverlight Tools on my system. What does &quot;The hash value is not correct&quot; mean?</h4>

<p><span style="text-decoration:underline">Answer</span>: This happens because the Silverlight installation tries to download the Silverlight Developer Runtime and cannot access the server. Try following these steps in order to perform the installation:</p>

<ol>

<li>Download and save the <a href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">

Microsoft Silverlight 3 Tools for VS 2008 SP1</a> to your workstation. </li><li>Create a new directory on your workstation. </li><li>From the command prompt, run the following command: &quot;silverlight3_tools.exe /x&quot;.

</li><li>Specify the directory you created in step 2. </li><li>Download and save the <a href="http://silverlight.dlservice.microsoft.com/download/C/5/B/C5BB5CD8-E871-49AC-8A40-61010E1FD1CF/Silverlight_Developer.exe">

Silverlight Developer Runtime</a> to the directory you created in step 2. </li><li>Run SPInstaller.exe which is currently in the directory that you created in step 2.

</li><li>Once the installation is finished, you may delete the directory you created in step 2.

</li></ol>

<p>&nbsp;</p>

<h4><a name="trouble_installing_manager"></a><span style="text-decoration:underline">Question</span>: I receive an error saying &quot;The installer was interrupted before openPDC Manager could be installed. You need to restart the installer to try again.&quot;

 But when I restart, it simply tells me the same thing. What should I do?</h4>

<p><span style="text-decoration:underline">Answer</span>: This could be that you simply need to run the installer as an administrator, if this is not the issue then the first thing to check is to make sure you have .NET 3.5 and IIS 4.0 or later installed on

 your system. Additionally, if you are using IIS 7, you need to install IIS 6 Management Compatibility by going to &quot;Programs and Features &gt; Turn Windows Features on or off &gt; Internet Information Service &gt; Web Management Tools &gt; IIS6 Management

 Compatibility&quot;.<br>

<br>

If you are still receiving this problem, you may need to register ASP.NET with IIS.</p>

<ol>

<li>Locate aspnet_regiis.exe in the &ldquo;C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727&rdquo; directory.

</li><li>Open the command prompt and navigate to that directory. </li><li>Type the command: aspnet_regiis -i </li><li>Try to install the openPDCManager again. </li></ol>

<p>&nbsp;</p>

<h4><a name="trouble_installing_missing_files"></a><span style="text-decoration:underline">Question</span>: When I try to install openPDC, I recieve an error &quot;Cannot delete the existing openPDC.&quot;</h4>

<p><span style="text-decoration:underline">Answer</span>: This can happen if files in the openPDC programs folder are moved or removed without uninstalling and perhaps other things could cause this as well.</p>

<p>Try removing the following registry key (run RegEdit.exe to remove / find registry keys):</p>

<p>&nbsp;</p>

<pre>HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Installer\Products\DEC6D3946C055FC4393A03C663F4013A</pre>

<p>&nbsp;</p>

<p>If you don't find this key, search for openPDC within</p>

<pre>HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Installer\Products\</pre>

<p>and delete this key. Once deleted, try reinstalling the application.</p>

<p>&nbsp;</p>

<h4><a name="openpdcmanager_installer"></a>I just installed the openPDCManager. Why isn't it working properly?</h4>

<p>If you used the installers, you will need to modify the &quot;web.config&quot; file in the openPDCManager to point to the correct services URL.<br>

<br>

Change these settings.</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">&lt;</span><span style="color:#a31515">appSettings</span><span style="color:blue">&gt;</span>

        <span style="color:green">&lt;!-- &lt;add key=&quot;BaseServiceUrl&quot; value=&quot;http://localhost/openPDCManagerServices/&quot; /&gt; --&gt;</span>

        <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">key</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">BaseServiceUrl</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">http://localhost:1068/</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>

<span style="color:blue">&lt;/</span><span style="color:#a31515">appSettings</span><span style="color:blue">&gt;</span>

</pre>

</div>

<p><br>

This is what you should change it to.</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">&lt;</span><span style="color:#a31515">appSettings</span><span style="color:blue">&gt;</span>

        <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">key</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">BaseServiceUrl</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">http://localhost/openPDCManagerServices/</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>

        <span style="color:green">&lt;!-- &lt;add key=&quot;BaseServiceUrl&quot; value=&quot;http://localhost:1068/&quot; /&gt; --&gt;</span>

<span style="color:blue">&lt;/</span><span style="color:#a31515">appSettings</span><span style="color:blue">&gt;</span>

</pre>

</div>

<h4><a name="mime_types"></a>When I go to the webpage, I just get a white screen with an &quot;error on page&quot; icon on the statusbar.</h4>

<p>Check if the following MIME types are registered on your machine.</p>

<ul>

<li>.xaml --&gt; application/xaml&#43;xml </li><li>.xap --&gt; application/x-silverlight-app </li></ul>

<h4><a name="not_connecting_to_database"></a>The openPDCManager doesn't appear to be connecting to my database.</h4>

<p>You need to modify the &quot;web.config&quot; file in the openPDCManagerServices (note this is not the same file as the &quot;web.config&quot; file in the openPDCManager). The process is described on the

<a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Manager_Configuration.md#configure_database_connection">

openPDCManager configuration page</a>.<br>

<br>

Additionally, if you are using IIS 7, you may need to register the MIME type for .svc files. Open the command prompt and type

<span class="codeInline">&quot;%windir%\Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ServiceModelReg.exe&quot; -r -y

</span></p>

<h4><a name="cross_domain_error"></a>Why am I receiving a CrossDomainError?</h4>

<p>It's possible that you will need to move the &quot;clientaccesspolicy.xml&quot; file up one level in the directory structure. The file should be located in the installation directory for openPDCManagerServices (&quot;C:\Inetpub\wwwroot\openPDCManagerServices&quot;

 by default).</p>

<h4><a name="local_historian_checkbox"></a><span style="text-decoration:underline">Question</span>: What is the purpose of the local checkbox on the Manage Historians? Are there cases where they would not on the local network? What does this change when active?</h4>

<p><span style="text-decoration:underline">Answer</span>: Basically the checkbox on local network is used for &ldquo;auto-assignment&rdquo; of default values for LocalOutputAdapter vs. RemoteOutputAdapter if type name is null. This way assignment of AssemblyName

 and TypeName fields is completely optional if you are using the built-in archiving code (for instance, binary file format used with Hadoop). However, you will need to enter these fields for commercial historians or other custom archive destinations.<br>

<br>

</p>

<h4><a name="local_installed_service"></a><span style="text-decoration:underline">Question</span>: The Specified service does not exist as installed service</h4>

<p><span style="text-decoration:underline">Answer</span>: We have encountered this error, when we have installed different versions of openPDC manager and when it says application may not be fully unistalled after the unistall is complete. Step 1: Please go

 to the control panel and try to uninstall the version that already exists. Step2: Once it is uninstalled pull up the command prompt and execute the below. &ldquo; sc create openPDC binPath= &quot;C:\Program Files\openPDC\openPDC.exe&rdquo; &rdquo;. Step3:

 If you have not got success in getting rid of the error then, Please go back to the file location and find the INSTALLERS folder and try to uninstall from that folder. (If you still have a problem, please go back to the previous version INSTALLERS folder find

 openPDCSetup64.msi copy that in the present folder and try to uninstall). This should finally help you.&nbsp;</p>

<p><br>

</p>

<hr>

<h2><a name="historian"></a>Historian Questions</h2>

<h4><a name="windows_7_network_permissions"></a><span style="text-decoration:underline">Question</span>: I receive an error like the following:</h4>

<p><br>

<strong>[LocalDevArchive] MetadataService could not be loaded - HTTP could not register URL http://&#43;:6151/historian/. Your process does not have access rights to this namespace (see http://go.microsoft.com/fwlink/?LinkId=70353 for details).</strong><br>

<br>

<strong>[LocalDevArchive] TimeSeriesDataService could not be loaded - HTTP could not register URL http://&#43;:6152/historian/. Your process does not have access rights to this namespace (see http://go.microsoft.com/fwlink/?LinkId=70353 for details).</strong><br>

<br>

<span style="text-decoration:underline">Answer</span>: Windows 7 defines user access control lists to manage permissions to HTTP web services. Open the command prompt as an administrator, and run the following commands using your user account ID and domain

 (<strong>NOTE</strong>: If you are not logged into a domain, use your computer name as the domain name).<br>

</p>

<pre>netsh http add urlacl url=http://&#43;:6151/historian user=DOMAIN\user

netsh http add urlacl url=http://&#43;:6152/historian user=DOMAIN\user

</pre>

<p><br>

<br>

A GUI is available which can perform a similar task: http://www.stevestechspot.com/downloads/httpconfig.zip<br>

</p>

<h4><a name="how_much_history_stored"></a><span style="text-decoration:underline">Question</span>: I noticed that my history file seemed to stay the same size all of the time. Does it only store a certain amount of history?</h4>

<p><span style="text-decoration:underline">Answer</span>: The historian pre-allocates the data files it uses for writing time-series data and &ldquo;rolls over&rdquo; to a new file once the current file is full. The size along with other parameters of the historian

 data file can be configured in the openPDC config file under the &lt;archiveFile/&gt; section.<br>

</p>

<h4><a name="historian_not_responding"></a><span style="text-decoration:underline">Question</span>: How does the openPDC handle situations where a historian is not responding?</h4>

<p><span style="text-decoration:underline">Answer</span>: In the event that a historian stops responding to the openPDC's attempts to send it data, the openPDC will buffer the data meant for that historian. The openPDC will attempt to re-establish communication

 to the historian with rolling connection attempts. When the connection to the historian is established the data will then be sent to the historian for archival.<br>

</p>

<h4><a name="locally_cached_measurements"></a><span style="text-decoration:underline">Question</span>: How does the openPDC handle the locally cached measurements?</h4>

<p><span style="text-decoration:underline">Answer</span>: If the openPDC has cached measurements for a historian that does respond, the openPDC will push the entire cache of data to the historian as soon as the historian is reconnected &ndash; this data will

 be pushed to the historian as quickly as possible to relieve memory pressure. If the historian continues to not respond, the openPDC will start dropping the oldest data in order not to exceed a user configurable number of points in memory (this to avoid possible

 out-of-memory errors). The settings to control the number of points maintained in memory can be found in the openPDC configuration file (SOURCEDIR\Build\Output\Debug\Applications\openPDC\openPDC.exe.config where SOURCEDIR is the root directory of the source

 code). These numbers can be adjusted to a much higher levels on 64-bit machines with large amounts of available memory.<br>

<br>

<strong>IMPORTANT</strong>: The openPDC will send the entire cached measurement queue to the archiver therefore it is imperative that the space taken by cached points on the openPDC server cannot exceed the space available on the archive server.<br>

<strong>Note</strong>: These settings will not appear in your configuration file until you run openPDC.exe for the first time.<br>

</p>

<div style="color:black; background-color:white">

<pre><span style="color:blue">&lt;</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>

  <span style="color:blue">&lt;</span><span style="color:#a31515">categorizedSettings</span><span style="color:blue">&gt;</span>

    <span style="color:blue">&lt;</span><span style="color:#a31515">thresholdSettings</span><span style="color:blue">&gt;</span>

      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">MeasurementWarningThreshold</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">100000</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>

      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">MeasurementDumpingThreshold</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">500000</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>

      <span style="color:blue">&lt;</span><span style="color:#a31515">add</span> <span style="color:red">name</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">DefaultSampleSizeWarningThreshold</span><span style="color:black">&quot;</span> <span style="color:red">value</span><span style="color:blue">=</span><span style="color:black">&quot;</span><span style="color:blue">10</span><span style="color:black">&quot;</span> <span style="color:blue">/&gt;</span>

    <span style="color:blue">&lt;/</span><span style="color:#a31515">thresholdSettings</span><span style="color:blue">&gt;</span>

  <span style="color:blue">&lt;/</span><span style="color:#a31515">categorizedSettings</span><span style="color:blue">&gt;</span>

<span style="color:blue">&lt;/</span><span style="color:#a31515">configuration</span><span style="color:blue">&gt;</span>

</pre>

</div>

<p>&nbsp;</p>

<table>

<tbody>

<tr>

<th>Setting Name</th>

<th>Description</th>

</tr>

<tr>

<td>MeasurementWarningThreshold</td>

<td>Number of unarchived measurements allowed in any output adapter queue before displaying a warning message</td>

</tr>

<tr>

<td>MeasurementDumpingThreshold</td>

<td>Number of unarchived measurements allowed in any output adapter queue before taking evasive action and dumping data</td>

</tr>

<tr>

<td>DefaultSampleSizeWarningThreshold</td>

<td>Default number of unpublished samples (in seconds) allowed in any action adapter queue before displaying a warning message</td>

</tr>

</tbody>

</table>

<p>&nbsp;</p>

<hr>

<h2><a name="hadoop"></a>Hadoop Questions</h2>

<h4><a name="what_is_hadoop"></a><span style="text-decoration:underline">Question</span>: What is Hadoop?</h4>

<p><span style="text-decoration:underline">Answer</span>: Hadoop is a framework for running applications on large clusters built from commodity hardware.<br>

</p>

<h4><a name="how_does_hadoop_relate_to_openpdc"></a><span style="text-decoration:underline">Question</span>: How does Hadoop relate to the openPDC?</h4>

<p><span style="text-decoration:underline">Answer</span>: The openPDC is capable of collecting petabytes of synchrophasor data. On a standard desktop system, processing that data linearly can take hundreds of days. Hadoop will be utilized to process that data

 on many machines in parallel, greatly reducing the time needed by dividing the work among the nodes.</p>

<h4><a name="how_are_openpdc_and_hadoop_used"></a><span style="text-decoration:underline">Question</span>: How are Hadoop and openPDC used in production?</h4>

<p><span style="text-decoration:underline">Answer</span>: The following are references to using openPDC and Hadoop in production with both HDFS for cheap scalable storage and MapReduce for processing large amounts of time series data.</p>

<p><em>Original Whitepapers</em></p>

<ul>

<li>http://www.cloudera.com/resource/hadoop-platform-smartgrid-tva-josh-patterson &nbsp;

    ++ <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/FAQ.files/chadnug03102011v1-111004121455-phpapp01.pdf">Archived PDF</a>

</li><li><a href="http://www.cloudera.com/blog/2009/06/smart-grid-hadoop-tennessee-valley-authority-tva">http://www.cloudera.com/blog/2009/06/smart-grid-hadoop-tennessee-valley-authority-tva</a>&nbsp;</li></ul>

<p><em>OSCON-data presentation (good TVA story here)</em></p>

<ul>

<li><a href="http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard">http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard</a>&nbsp;

    ++ <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/FAQ.files/osconlumberyard20110518v8-110929133838-phpapp02.pdf">Archived PDF</a>

</li></ul>

<p><em>High Level articles/coverage of project</em></p>

<ul>

<li><a href="http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva">http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva</a>&nbsp;

    ++ <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/FAQ.files/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02.pdf">Archived PDF</a>

</li>

<li>http://www.tva.gov/news/releases/octdec09/data_collection_software.htm &nbsp;

    ++ Archive Not Available

</li>

<li>http://jpatterson.floe.tv/index.php/2009/10/29/the-smartgrid-goes-open-source &nbsp;

    ++ <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/FAQ.files/JPatterson_floe_tv_2009-10-29_the-smartgrid-goes-open-source.md">Archived WayBack</a>

</li>

    <li><a href="http://gigaom.com/cleantech/the-google-android-of-the-smart-grid-openpdc">http://gigaom.com/cleantech/the-google-android-of-the-smart-grid-openpdc</a>&nbsp;</li>

<li><a href="http://news.cnet.com/8301-13846_3-10393259-62.html">http://news.cnet.com/8301-13846_3-10393259-62.html</a>&nbsp;

</li>

<li><a href="http://gigaom.com/cleantech/how-to-use-open-source-hadoop-for-the-smart-grid">http://gigaom.com/cleantech/how-to-use-open-source-hadoop-for-the-smart-grid</a>&nbsp;</li></ul>

<p><em>Engineering Literature</em></p>

<ul>

<li><a href="https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version">https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version</a>

</li>

<li><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/FAQ.files/openPDC_Datamining_Tools_Guide.pdf">Hadoop openPDC Dataminning Tools Guide</a>

</li></ul>

<p><em>General time series processing with Hadoop (along with another source code example)</em></p>

<ul>

<li><a href="http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1">http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1</a>

</li><li><a href="http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2">http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2</a>

</li><li><a href="http://www.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3">http://www.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3</a>

</li></ul>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="3/25/2015 9:12:03 PM" LocalTimeTicks="1427343123">Mar 25, 2015 at 9:12 PM</span> by <a id="wikiEditByLink" href="http://www.codeplex.com/site/users/view/ritchiecarroll">ritchiecarroll</a>, version 90<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=FAQ">CodePlex</a> Oct 3, 2015 by <a href="http://www.codeplex.com/site/users/view/ajstadlin">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


