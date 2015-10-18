

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Configuration Commands</title>



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

<h1>openPDC Console Commands to Adjust Configuration Settings</h1>

A number of console commands have been added to the openPDC that allow the user to reconfigure the openPDC without stopping and restarting the service entirely. The following information describes how to use these commands in order to perform common configuration

 of the openPDC without interrupting the openPDC&#39;s operations.<br>

<br>

<i>Note: You can obtain help on the usage of any openPDC Console command by typing</i>

<span class="codeInline">-?</span> <i>into the console after the name of the command (for example,</i>

<span class="codeInline">Initialize -?</span><i>).</i><br>

<ul>

<li><a href="#database_config">Database configuration settings</a>

<ul>

<li><a href="#add_remove_adapter">Add or remove adapters</a> </li><li><a href="#modify_adapter">Modify existing adapters</a></li></ul>

</li><li><a href="#config_file">Configuration file settings</a>

<ul>

<li><a href="#service_component">Service component settings</a> </li><li><a href="#adapter_config_file_settings">Adapter configuration file settings</a></li></ul>

</li></ul>

<hr>

<h2><a name="database_config"></a>Database configuration settings</h2>

While the openPDC has no commands that will modify database settings from the console, it does have a number of commands that can be used to reload database configuration settings in order to recognize changes made to adapter configuration settings in the database.<br>

<h3><a name="add_remove_adapter"></a>Add or remove adapters</h3>

The <span class="codeInline">ReloadConfig</span> console command is the principle command used to recognize adapters that have been added or removed from the database configuration. This command will reload the database configuration, add adapters that were

 previously not present in the database configuration, and remove adapters that are no longer present in the database configuration without modifying or interrupting adapters that were previously defined and are still defined in the database. Unfortunately,

 this means changes made to existing adapters will not be recognized. Adapters that have been added to the configuration must be started manually using the

<span class="codeInline">Connect</span> command.<br>

<br>

The <span class="codeInline">Initialize [-I|-A|-O]</span> command can be used to reinitialize a collection (input, action, output) of adapters. Doing so will also cause the system to add and remove adapters in the reinitialized collection. Changes made to

 existing adapters in that collection will be recognized, but the operation of unmodified adapters will also be interrupted when using this command. Adapters that have been reinitialized must also be started manually using the

<span class="codeInline">Connect</span> command.<br>

<br>

The <span class="codeInline">Initialize -System</span> command can be used to reinitialize the entire system, causing the system to add and remove adapters in all adapter collections as well as recognize all changes made to existing adapters. All adapters

 will be automatically started when this command is used including newly defined adapters. This will cause all adapters in all collections to be interrupted regardless of whether changes have been made to them.<br>

<h5>Review of commands described in this section</h5>

<ul>

<li><span class="codeInline">ReloadConfig</span> </li><li><span class="codeInline">Initialize -I</span> </li><li><span class="codeInline">Initialize -A</span> </li><li><span class="codeInline">Initialize -O</span> </li><li><span class="codeInline">Initialize -System</span> </li><li><span class="codeInline">Connect</span></li></ul>

<br>

<h3><a name="modify_adapter"></a>Modify existing adapters</h3>

The <span class="codeInline">Initialize ACRONYM [-I|-A|-O]</span> and <span class="codeInline">

Initialize ID#</span> commands can be used to reinitialize individual adapters. These commands can only be used to initialize existing adapters and therefore cannot be used to recognize adapters that have been added to the database configuration. Operation

 of the adapters will be interrupted, but will be automatically restarted when using these commands.<br>

<br>

The <span class="codeInline">Initialize [-I|-A|-O]</span> command can be used to reinitialize a collection (input, action, output) of adapters. Doing so will also cause the system to add and remove adapters in the reinitialized collection. Changes made to

 existing adapters in that collection will be recognized, but the operation of unmodified adapters will also be interrupted when using this command. Adapters that have been reinitialized must also be started manually using the

<span class="codeInline">Connect</span> command.<br>

<br>

The <span class="codeInline">Initialize -System</span> command can be used to reinitialize the entire system, causing the system to add and remove adapters in all adapter collections as well as recognize all changes made to existing adapters. All adapters

 will be automatically started when this command is used including newly defined adapters. This will cause all adapters in all collections to be interrupted regardless of whether changes have been made to them.<br>

<h5>Review of commands described in this section</h5>

<ul>

<li><span class="codeInline">Initialize ID#</span> </li><li><span class="codeInline">Initialize ACRONYM -I</span> </li><li><span class="codeInline">Initialize ACRONYM -A</span> </li><li><span class="codeInline">Initialize ACRONYM -O</span> </li><li><span class="codeInline">Initialize -I</span> </li><li><span class="codeInline">Initialize -A</span> </li><li><span class="codeInline">Initialize -O</span> </li><li><span class="codeInline">Initialize -System</span> </li><li><span class="codeInline">Connect</span></li></ul>

<hr>

<h2><a name="config_file"></a>Configuration file settings</h2>

The openPDC is capable of updating configuration file settings for service components and adapters as described below. All other settings must be modified after having stopped and before restarting the openPDC service.<br>

<h3><a name="service_component"></a>Service component settings</h3>

Certain configuration file settings, referred to as &quot;service component settings&quot;, can be modified through the use of console commands without the need to restart the openPDC service or any of its adapters.<br>

<br>

The <span class="codeInline">Settings</span> command displays a list of configuration file settings that can be modified by the

<span class="codeInline">UpdateSettings</span> and <span class="codeInline">ReloadSettings</span> commands.<br>

<br>

The <span class="codeInline">UpdateSettings</span> command adds, removes, or modifies the value of a specific service component setting.<br>

<br>

The <span class="codeInline">UpdateConfigFile</span> command is capable of adding, removing, or modifying any setting in the configuration file. If you&#39;ve used this command to update a service component setting,

<span class="codeInline">ReloadConfig</span> can be used to load the updated settings for a given service component.<br>

<h5>Review of commands described in this section</h5>

<ul>

<li><span class="codeInline">Settings</span> </li><li><span class="codeInline">UpdateSettings</span> </li><li><span class="codeInline">UpdateConfigFile</span> </li><li><span class="codeInline">ReloadSettings</span></li></ul>

<h3><a name="adapter_config_file_settings"></a>Adapter configuration file settings</h3>

The <span class="codeInline">UpdateConfigFile</span> command is capable of adding, removing, or modifying any setting in the configuration file. Before using this command, however, the adapter whose settings you are trying to change must be disabled and not

 running. This can be done by disabling the adapter in the database and using the

<span class="codeInline">ReloadConfig</span> command. Once the settings for that adapter have been updated using the

<span class="codeInline">UpdateConfigFile</span> command, reenable the adapter and use the

<span class="codeInline">ReloadConfig</span> command again to reinitialize the adapter with the new configuration file settings. Only the adapter whose settings are to be updated will be interrupted by this process.<br>

<h5>Review of commands described in this section</h5>

<ul>

<li><span class="codeInline">UpdateConfigFile</span> </li><li><span class="codeInline">ReloadConfig</span></li></ul>

</div>

<div></div>

</div>



<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br><br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="6/3/2010 8:48:55 PM" LocalTimeTicks="1275623335">Jun 3, 2010 at 8:48 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/staphen.md">staphen</a>, version 4<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Configuration%20Commands">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


