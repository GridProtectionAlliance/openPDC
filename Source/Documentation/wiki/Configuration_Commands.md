[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# openPDC Console Commands to Adjust Configuration Settings

A number of console commands have been added to the openPDC that allow the user to reconfigure the openPDC without stopping and restarting the service entirely. The following information describes how to use these commands in order to perform common configuration of the openPDC without interrupting the openPDC's operations.

*Note: You can obtain help on the usage of any openPDC Console command by typing* `-?` *into the console after the name of the command. For example:* `Initialize -?`

- [Database configuration settings](#database-configuration-settings)
    - [Add or remove adapters](#add-or-remove-adapters)
    - [Modify existing adapters](#modify-existing-adapters)
- [Configuration file settings](#configuration-file-settings)
    - [Service component settings](#service-component-settings)
    - [Adapter configuration file settings](#adapter-configuration-file-settings)

---

## Database configuration settings

While the openPDC has no commands that will modify database settings from the console, it does have a number of commands that can be used to reload database configuration settings in order to recognize changes made to adapter configuration settings in the database.

### Add or remove adapters

The `ReloadConfig` console command is the principle command used to recognize adapters that have been added or removed from the database configuration. This command will reload the database configuration, add adapters that were previously not present in the database configuration, and remove adapters that are no longer present in the database configuration without modifying or interrupting adapters that were previously defined and are still defined in the database. Unfortunately, this means changes made to existing adapters will not be recognized. Adapters that have been added to the configuration must be started manually using the `Connect` command.

The `Initialize [-I|-A|-O]` command can be used to reinitialize a collection (input, action, output) of adapters. Doing so will also cause the system to add and remove adapters in the reinitialized collection. Changes made to existing adapters in that collection will be recognized, but the operation of unmodified adapters will also be interrupted when using this command. Adapters that have been reinitialized must also be started manually using the `Connect` command.

The `Initialize -System` command can be used to reinitialize the entire system, causing the system to add and remove adapters in all adapter collections as well as recognize all changes made to existing adapters. All adapters will be automatically started when this command is used including newly defined adapters. This will cause all adapters in all collections to be interrupted regardless of whether changes have been made to them.

##### Review of commands described in this section

- `ReloadConfig`
- `Initialize -I`
- `Initialize -A`
- `Initialize -O`
- `Initialize -System`
- `Connect`

### Modify existing adapters

The `Initialize ACRONYM [-I|-A|-O]` and `Initialize ID#` commands can be used to reinitialize individual adapters. These commands can only be used to initialize existing adapters and therefore cannot be used to recognize adapters that have been added to the database configuration. Operation of the adapters will be interrupted, but will be automatically restarted when using these commands.

The `Initialize [-I|-A|-O]` command can be used to reinitialize a collection (input, action, output) of adapters. Doing so will also cause the system to add and remove adapters in the reinitialized collection. Changes made to existing adapters in that collection will be recognized, but the operation of unmodified adapters will also be interrupted when using this command. Adapters that have been reinitialized must also be started manually using the `Connect` command.

The `Initialize -System` command can be used to reinitialize the entire system, causing the system to add and remove adapters in all adapter collections as well as recognize all changes made to existing adapters. All adapters will be automatically started when this command is used including newly defined adapters. This will cause all adapters in all collections to be interrupted regardless of whether changes have been made to them.

##### Review of commands described in this section

- `Initialize ID#`
- `Initialize ACRONYM -I`
- `Initialize ACRONYM -A`
- `Initialize ACRONYM -O`
- `Initialize -I`
- `Initialize -A`
- `Initialize -O`
- `Initialize -System`
- `Connect`

***

## Configuration file settings

The openPDC is capable of updating configuration file settings for service components and adapters as described below. All other settings must be modified after having stopped and before restarting the openPDC service.

### Service component settings

Certain configuration file settings, referred to as "service component settings", can be modified through the use of console commands without the need to restart the openPDC service or any of its adapters.

The `Settings` command displays a list of configuration file settings that can be modified by the `UpdateSettings` and `ReloadSettings` commands.

The `UpdateSettings` command adds, removes, or modifies the value of a specific service component setting.

The `UpdateConfigFile` command is capable of adding, removing, or modifying any setting in the configuration file. If you've used this command to update a service component setting, `ReloadConfig` can be used to load the updated settings for a given service component.

##### Review of commands described in this section

- `Settings`
- `UpdateSettings`
- `UpdateConfigFile`
- `ReloadSettings`

### Adapter configuration file settings

The `UpdateConfigFile` command is capable of adding, removing, or modifying any setting in the configuration file. Before using this command, however, the adapter whose settings you are trying to change must be disabled and not running. This can be done by disabling the adapter in the database and using the `ReloadConfig` command. Once the settings for that adapter have been updated using the `UpdateConfigFile` command, reenable the adapter and use the `ReloadConfig` command again to reinitialize the adapter with the new configuration file settings. Only the adapter whose settings are to be updated will be interrupted by this process.

##### Review of commands described in this section

- `UpdateConfigFile`
- `ReloadConfig`

---

Jun 3, 2010 08:48:55 PM Last edited by [staphen](http://www.codeplex.com/site/users/view/staphen), version 4  
Oct 4, 2015 Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Configuration%20Commands) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)