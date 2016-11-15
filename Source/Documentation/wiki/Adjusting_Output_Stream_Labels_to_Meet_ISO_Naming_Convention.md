[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md)

|   |   |   |   |
|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC)** | **[openPDC Wiki Home](openPDC_Home.md)** | **[Documentation](openPDC_Documentation_Home.md)** |

# Adjusting Output Stream Labels to Meet ISO Naming Convention

Since phasor labels have traditionally been defined so poorly in synchrophasor devices the openPDC will auto-suffix labels with the phase information. This can at least *hint* to the data type in the phasor when the labeling is not well defined. However, the *ISO Standard Synchrophasor Naming Convention* now defines these labels so this feature needs to be disabled. To accommodate the naming standard, the following connection string parameters are used for ISO level output streams:

- `addPhaseLabelSuffix` - a boolean value that will allow the default phase label suffix to be enabled / disabled
- `replaceWithSpaceChar` - a character designation that will be replaced by &quot;space&quot; in the output stream

The following is an example connection string addition that complies with the standard:

`addPhaseLabelSuffix=false; replaceWithSpaceChar=_`

In this example, a label in the output stream where an underscore was encountered would be replaced with a space. Note that you can use another character if underscores are reserved and or used in the naming standard.

With this notion you can change the original device acronym to include the desired replacement characters before adding the device to the output stream so it is consistently named throughout the system.

---

Jul 6, 2012 at 6:54 PM Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 3  
Oct 4, 2015 Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Adjusting%20Output%20Stream%20Labels%20to%20Meet%20ISO%20Naming%20Convention) by [aj](https://github.com/ajstadlin)

---
Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
