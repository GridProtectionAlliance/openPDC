

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Remote Console Security Version 3</title>



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

<h1>Remote Console Security</h1>

As of version 1.5.190 of the openPDC, remote console security has been enabled by default. These security features will be available in the final release of v1.5 SP1. This page details the changes that have been made to the security features in this version

 of the openPDC.<br>

<br>

<h3>Config file settings</h3>

The following settings were modified to enable security. These are the new defaults, but if you are upgrading from a previous version, they will not override your security settings. Apply these changes manually to enable the new security features.<br>

<ul>

<li>In openPDC.exe.config:

<ul>

<li>The value of <span class="codeInline">categorizedSettings/serviceHelper/SecureRemoteInteractions</span> has been set to

<span class="codeInline">True</span>. </li><li>The value of <span class="codeInline">categorizedSettings/remotingServer/IntegratedSecurity</span> has been set to

<span class="codeInline">True</span>. </li><li>The <span class="codeInline">categorizedSettings/securityProvider</span> section has been copied from openPDCManager.exe.config with the following changes.

<ul>

<li>The value of <span class="codeInline">ApplicationName</span> has been set to

<span class="codeInline">openPDC</span>. </li><li>The value of <span class="codeInline">IncludedResources</span> has been set to

<span class="codeInline">Settings,Schedules,Help,Status,Version,Time,Health,List=*; Processes,Start,ReloadCryptoCache,ReloadSettings,ResetHealthMonitor,Connect,Disconnect,Invoke,ListCommands,Initialize,ReloadConfig,Authenticate,RefreshRoutes,TemporalSupport=Administrator,Editor;

 *=Administrator</span>. (More on this below.)</li></ul>

</li></ul>

</li><li>In openPDCConsole.exe.config:

<ul>

<li>The value of <span class="codeInline">categorizedSettings/remotingClient/IntegratedSecurity</span> has been set to

<span class="codeInline">True</span>.</li></ul>

</li></ul>

<br>

<h3>Database settings</h3>

Database scripts have been updated to allow the openPDC Manager to properly connect to the service as well. Again, if you are upgrading from a previous version, apply this change manually.<br>

<ul>

<li>In the Node table of the database (Manage &gt; Nodes in the openPDC Manager):

<ul>

<li>In the <span class="codeInline">Settings</span> field, <span class="codeInline">

RemoteStatusServerConnectionString={server=localhost:8500} </span>has been changed to

<span class="codeInline">RemoteStatusServerConnectionString={server=localhost:8500;integratedSecurity=true}

</span>.</li></ul>

</li></ul>

<br>

<h3>Console permissions</h3>

In much the same way that the Manager handles permissions based on roles defined in the database, now the openPDC does as well. Certain commands are restricted such that editors or viewers will not be able to enter them into the console. This is handled by

 the <span class="codeInline">IncludedResources</span> setting in openPDC.exe.config (mentioned above). The following gives a breakdown of all possible commands in the system and the permissions associated with them.<br>

<br>

<pre>

ADMINISTRATOR, EDITOR, VIEWER

-----------------------------

Settings

Schedules

Help

Status

Version

Time

Health

List



ADMINISTRATOR, EDITOR

---------------------

Processes

Start

ReloadCrytpoCache

ReloadSettings

ResetHealthMonitor

Connect

Disconnect

Invoke

ListCommands

Initialize

ReloadConfig

Authenticate

RefreshRoutes

TemporalSupport



ADMINISTRATOR

-------------

Clients

History

Abort

Reschedule

Unschedule

SaveSchedules

LoadSchedules

Restart

</pre>

<br>

<br>

The <span class="codeInline">IncludedResources</span> setting can be used to modify these permissions. It is defined as a semicolon-separated list of permissions. Each permission record in the semicolon-separated list consists of two comma-separated lists,

 one on each side of an equals sign. The list on the left-hand side of the equals sign defines the list of commands. The list on the right-hand side of the equals sign defines the roles which are allowed to use those commands. An asterisk can be placed on either

 side of the equals sign to indicate &quot;all commands&quot; or &quot;all roles&quot;. The breakdown below should help in understanding it.<br>

<br>

<span class="codeInline">Settings,Schedules,Help,Status,Version,Time,Health,List=*;</span><br>

<blockquote>The Settings, Schedules, Help, Status, Version, Time, Health, and List commands are available to all roles (Administrator, Editor, Viewer).</blockquote>

<span class="codeInline">Processes,Start,ReloadCryptoCache,ReloadSettings,ResetHealthMonitor,Connect,Disconnect,Invoke,ListCommands,Initialize,ReloadConfig,Authenticate,RefreshRoutes,TemporalSupport=Administrator,Editor;</span><br>

<blockquote>The long list of commands on the left are available only to Administrators and Editors.</blockquote>

<span class="codeInline">*=Administrator</span><br>

<blockquote>All commands are available to Administrators.</blockquote>

<br>

Also note that the semicolon-separated list is traversed only until a rule is matched, and that one rule will be used to determine whether a role has permission to use that command. For instance, the following ruleset would actually restrict the List command

 so that Administrators and Editors would not be able to use it.<br>

<br>

<blockquote><span class="codeInline">List=Viewer; *=Administrator,Editor</span></blockquote>

Likewise, the following ruleset would restrict the system so that only Administrators could use commands.<br>

<br>

<blockquote><span class="codeInline">*=Administrator; List=Editor,Viewer</span></blockquote>

</div>

<div></div>

</div>



<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br><br></div>

</div>

<hr />

    Last edited <span class="smartDate" title="2/17/2014 6:58:51 PM" LocalTimeTicks="1392692331">Feb 17, 2014 at 6:58 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/staphen.md">staphen</a>, version 3<br />

    Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=Remote%20Console%20Security&version=3">CodePlex</a> Oct 2, 2015 by <a href="https://github.com/ajstadlin">ajs</a>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>
