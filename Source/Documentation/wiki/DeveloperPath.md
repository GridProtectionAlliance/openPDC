[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](https://github.com/GridProtectionAlliance/openPDC/wiki)** | **[Documentation](https://github.com/GridProtectionAlliance/openPDC/wiki/Documentation)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# The Path to Becoming an openPDC Developer

The easiest wasy to become a developer for the openPDC project is to start providing *patches of value*. Anyone can upload code for us to review by creating a [**Pull Request**](https://github.com/GridProtectionAlliance/openPDC/pulls). If your patch is accepted (i.e., it is a useful new feature or bug fix) the code will be merged into the current code set - any added attributions and copyrights will remain. You can use other open-source code in your patches but it must be compatible with the [TVA Open Source License](license.md). Providing patches that add true value set you on the path to becoming a *trusted* developer on the openPDC project. Trusted developers have *check-out* rights to the source code and can directly upload changes to the current code set.

Looking forward to your patches!

## Code Rules

### Formatting

#### Code Regions

All of the code used by the openPDC must be formatted using *Regions* snippet. If you expect to have your patch or code update included within the project it must follow this convention. All the snippets used by the project can be found in the Contributor  Resources in the Snippets folder.

To install the snippets copy the `*.snippet` files to the file location that is defined for your code snippets. The file location can be found by selecting *Tools / Code Snippet Manager* from within Visual Studio then choosing Visual C# in the Language dropdown and selecting My Code Snippets. The folder is typically `...\My Documents\Visual Studio 2008\Code Snippets\Visual C#\My Code Snippets`.

#### Headers

Additionally all code must have a consistent header. We have developed a macro to include the standard code header that can be found in the Contributor Resources in the Macros folder. The following instructions will create this Visual Studio macro. Once defined you can insert the common header from within Visual Studio into any file by pressing `Ctrl+Alt+H`. Installation steps follow:

First, install the project macro:

1. Go to *Tools / Macros / Macros IDE*
2. Right click *MyMacros* and select *Add / Add Module*
3. Enter name "ProjectMacros", then select the *Add* button
4. Select all default code by pressing `Ctrl+A`
5. Press the *Delete* key to remove all existing code
6. Paste in code from the `ProjectMacros.vb` found in this folder
7. Right click *References* in the Project Explorer and select *Add Reference*
8. Select `System.DirectoryServices.dll`
9. Select the *Add* button, then select the *OK* button
10. Select *File / Save MyMacros*
11. Close *Macros IDE*

Second, assign a shortcut key to the macro:

1. Go to *View / Toolbars / Customize...*
2. Click *Keyboard...* button in the bottom left corner 
3. Type "MyMacros" into *Show commands containing:* text box
4. Select `Macros.MyMacros.ProjectMacros.InsertHeader`
5. Select *Text Editor* from the *Use new shortcut in:* list
6. Click in the *Press shortcut keys:* text box
7. Press the *Ctrl*, *Alt*, and *H* keys (text box should say `Ctrl+Alt+H`)
8. Click the *Assign* button, then click *OK*
9. Click the *Close* button on the *Customize* window
10. Open a C# code window, click anywhere in the file
11. Press `Ctrl+Alt+H`, header will be inserted at top of document

Note all steps are executed from within Visual Studio. These instructions have only been tested with Visual Studio 2008.

### Check-in Rules

If you have been granted developer access, please adhere to the following rules:

1. Do not check in code that will not build.
2. All code should be formatted using the *Regions* snippet.
3. All public and/or protected members should have a fully populated XML comment.
4. All check-in's must have a comment - please make it relevant.
5. Check-in comment should have a project prefix. For example, prefix check-in descriptions for the Synchrophasor project with "Synchrophasor: ".
6. Do not leave debug code in the system unless it is properly regioned (`#if DEBUG`).
7. Do not check-out all files in a solution and/or project.
8. Keep total number of files checked-out to the absolute minimum needed.
9. If possible, keep files checked-out within the same solution.
10. Don't keep files checked-out for an excessive period of time. Shelve changes before you go on vacation or change projects and uncheck *Preserve pending changes locally*.
11. Do not check-in unfinished work - shelve the changes instead remembering to uncheck *Preserve pending changes locally*.
12. If multiple developers will be working on a large portion of code that will need to be checked-out for a long time, please contact the coordinators to create a branch for the project.
13. Please contact one of the project coordinators before adding a new project to any of the solutions so they will have an idea of what's being added and why.
14. Without prior coordination large contributions should be posted as a *patch* so it can be properly reviewed.

Note that some of the rules could be enforced by TFS but the codeplex TFS is a shared system, so for now we are simply using the honor system.

---

Nov 25, 2016 22:00 - Updated by [aj](https://github.com/ajstadlin), version 5  
Oct 4, 2009 11:17 - Edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 4  
Oct 4, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=DeveloperPath) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
