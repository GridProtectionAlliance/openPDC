[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](https://github.com/GridProtectionAlliance/openPDC/wiki)** | **[Documentation](https://github.com/GridProtectionAlliance/openPDC/wiki/Documentation)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Remote Console Security

*As of version 2.0.131, the permissions for commands has changed. To see the original list, see [version 3](Remote_Console_Security.files/Remote_Console_Security_Version_3.md) of this page.*

As of version 1.5.190 of the openPDC, remote console security has been enabled by default. These security features will be available in the final release of v1.5 SP1. This page details the changes that have been made to the security features in this version of the openPDC.

## Config file settings
The following settings were modified to enable security. These are the new defaults, but if you are upgrading from a previous version, they will not override your security settings. Apply these changes manually to enable the new security features.

## openPDC.exe.config settings

- The `categorizedSettings/serviceHelper/SecureRemoteInteractions` value has been set to `True`.
- The `categorizedSettings/remotingServer/IntegratedSecurity` value been set to `True`.
- The `categorizedSettings/securityProvider` section has been copied from `openPDCManager.exe.config` with the following changes.
    - The `ApplicationName` value has been set to `openPDC`.
    - The `IncludedResources` value has been set to `UpdateSettings,UpdateConfigFile=Special;Settings,Schedules,Help,Status,Version,Time,Health,List,Invoke,ListCommands,ListReports,GetReport=*;Processes,Start,ReloadCryptoCache,ReloadSettings,Reschedule,Unschedule,SaveSchedules,LoadSchedules,ResetHealthMonitor,Connect,Disconnect,Initialize,ReloadConfig,Authenticate,RefreshRoutes,TemporalSupport,LogEvent,GenerateReport,ReportingConfig=Administrator,Editor; *=Administrator`. (More on this below.)

## openPDCConsole.exe.config settings

- The `categorizedSettings/remotingClient/IntegratedSecurity` value has been set to `True`.

## Database settings

Database scripts have been updated to allow the openPDC Manager to properly connect to the service as well. Again, if you are upgrading from a previous version, apply this change manually.

- In the Node table of the database (Manage > Nodes in the openPDC Manager):
    - The `Settings` field, `RemoteStatusServerConnectionString={server=localhost:8500}` has been changed to `RemoteStatusServerConnectionString={server=localhost:8500;integratedSecurity=true}`.

## Console permissions

In much the same way that the Manager handles permissions based on roles defined in the database, now the openPDC does as well. Certain commands are restricted such that editors or viewers will not be able to enter them into the console. This is handled by the `IncludedResources` setting in openPDC.exe.config (mentioned above). The following gives a breakdown of all possible commands in the system and the permissions associated with them.

```
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
Invoke
ListCommands
ListReports
GetReport
ADMINISTRATOR, EDITOR
---------------------
Processes
Start
ReloadCrytpoCache
ReloadSettings
Reschedule
Unschedule
SaveSchedules
LoadSchedules
ResetHealthMonitor
Connect
Disconnect
Initialize
ReloadConfig
Authenticate
RefreshRoutes
TemporalSupport
LogEvent
GenerateReport
ReportingConfig
ADMINISTRATOR
-------------
Clients
History
Abort
Restart
```

The `IncludedResources` setting can be used to modify these permissions. It is defined as a semicolon-separated list of permissions. Each permission record in the semicolon-separated list consists of two comma-separated lists, one on each side of an equals sign. The list on the left-hand side of the equals sign defines the list of commands. The list on the right-hand side of the equals sign defines the roles which are allowed to use those commands. An asterisk can be placed on either side of the equals sign to indicate "all commands" or "all roles". The breakdown below should help in understanding it.

`UpdateSettings,UpdateConfigFile=Special;`

> The UpdateSettings and UpdateConfigFile commands are not available to any roles.

`Settings,Schedules,Help,Status,Version,Time,Health,List,Invoke,ListCommands,ListReports,GetReport=*;`

> The Settings, Schedules, Help, Status, Version, Time, Health, and List commands are available to all roles (Administrator, Editor, Viewer).

`Processes,Start,ReloadCryptoCache,ReloadSettings,Reschedule,Unschedule,SaveSchedules,LoadSchedules,ResetHealthMonitor,Connect,Disconnect,Initialize,ReloadConfig,Authenticate,RefreshRoutes,TemporalSupport,LogEvent,GenerateReport,ReportingConfig=Administrator,Editor;`

> The long list of commands on the left are available only to Administrators and Editors.

`*=Administrator`

> All commands are available to Administrators.

Also note that the semicolon-separated list is traversed only until a rule is matched, and that one rule will be used to determine whether a role has permission to use that command. For instance, the following ruleset would actually restrict the List command so that Administrators and Editors would not be able to use it.

`List=Viewer; *=Administrator,Editor` 

Likewise, the following ruleset would restrict the system so that only Administrators could use commands.

`*=Administrator; List=Editor,Viewer`

---

Mar 27, 2014 7:21 PM - Last edited by [staphen](http://www.codeplex.com/site/users/view/staphen), version 4  
Oct 4, 2015 - Migrated from [CodePlex] (http://openpdc.codeplex.com/wikipage?title=Remote%20Console%20Security) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)