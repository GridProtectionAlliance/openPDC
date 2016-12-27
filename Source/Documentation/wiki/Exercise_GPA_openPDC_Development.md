[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |   |   |
|---|---|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Exercises](Developer_Exercises.md)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This document is an exercise procedure for setting up and testing concepts.***

---

# GPA [openPDC](https://github.com/GridProtectionAlliance/openPDC) Development Exercise

## Building the [openPDC](https://github.com/GridProtectionAlliance/openPDC) using Microsoft Visual Studio 2015 Community Edition

This is a *cookbook recipe* style exercise procedure for setting up the GPA Developer with a Microsoft Visual Studio Community Edition development environment for for developing the openPDC software. This procedure was developed and tested using specified operating systems, software versions, and installation sequence. However, with appropriate modifications, this procedure should be adaptable to work in other hardware and software platforms.

- [Prerequisites](#prerequisites)
- [Download and Install Visual Studio Community Edition](#download-and-install-visual-studio-community-edition)
    - [Running Visual Studio the First Time](#running-visual-studio-the-first-time)
        - [Installing Visual Studio Extensions](#installing-visual-studio-extensions)
            - [Generalized Procedure for Installing Extensions](#generalized-procedure-for-installing-extensions)
            - [Visual Studio Extensions and Related Accessories We Will be Using](#visual-studio-extensions-and-related-accessories-we-will-be-using)
- [openPDC](#openpdc)
    - [Forking the openPDC Project Repository](#forking-the-openpdc-project-repository)
        - [Rename Your `openPDC` Project Fork to `openPDC_fork`](#rename-your-openpdc-project-fork-to-openpdc_fork)
        - [Clone Your `openPDC_fork` Project to Your Local Machine](#clone-your-openpdc_fork-project-to-your-local-machine)
- [Open the openPDC Solution](#open-the-openpdc-solution)
- [Build the openPDC Solution](#build-the-openpdc-solution)
- [Merging the Grid Protection Alliance Changes into Your Forked Project Repository](#merging-the-grid-protection-alliance-changes-into-your-forked-project-repository)
    - [Using Git to Update Your Local Fork's Repository](#using-git-to-update-your-local-forks-repository)
        - [Fork Update Procedure](#fork-update-procedure)
        - [Using Git Example Session](#using-git-example-session)

---

## Prerequisites

- This exercise uses the same prerquisites and procedures used by the [GridSolutionsFramework Exercise](Exercise_GPA_GridSolutionsFramework_Development.md#prerequisites). If you completed the [GridSolutionsFramework Exercise](Exercise_GPA_GridSolutionsFramework_Development.md) and are using the same machine and software, then you can jump ahead to the [openPDC](#openpdc) section of this exercise.

- **Windows 10 Enterprise 2016 LTSB workstation** - This exercise uses the `GPA-DEV` Workstation virtual machine created in the [GPA Developer Workstation Exercise](Exercise_GPA_Developer_Workstation.md).
-  **Visual Studio 2015 Community Edition** - The Microsoft Software used in this exercise is available with from [Microsoft Developer Network (MSDN)](http://msdn.microsoft.com) for free.
    - **Microsoft Account** - You will need a Microsoft recognized account (e.g. Live.com) to use Visual Studio Community Edition. You can register an account during the sign in process.
- **GitHub Account** - You will need a [GitHub.com](https://github.com) account to use the GitHub related workflows in this exercise. 
- **Sandcastle** - You will need the [EWSoftware Sandcastle Help File Builder and Tools (SHFB)](https://github.com/EWSoftware/SHFB/releases) for several Help projects in the solution.
- **OSIsoft Account** - To build the GridSolutionFramework PIAdapters sub-project you need the PI Asset Framework Client SDK software from [OSIsoft](http://www.osisoft.com/)

---

## Download and Install Visual Studio Community Edition

| Software | Package | Home Page | Download Link | Install Location | Installation Notes |
|---|---|---|---|---|---|
| **Visual Studio 2015 Community Edition** | `vs_community_ENU__#########.##########.exe` | [Visual Studio Community](`https://www.visualstudio.com/vs/community/`) | [Download Community 2015](https://go.microsoft.com/fwlink/?LinkId=691978&clcid=0x409) | use default locations | Run installer as *Administrator* |

Run the Visual Studio installation program selecting the *Customer* option and select the following installation options

- Programming Languages / Visual C++ / Common Tools for Visual C++ 2015
- Windows and Web Development / Microsoft SQL Server Data Tools
- Windows and Web Development / Web Developer Tools (selected by default)
- Common Tools / GitHub Extension for Visual Studio
- Common Tools / Visual Studio Extensibility Tools Update 3

When you Run Visual Studio Community Edition for the first time, you will be prompted to sign in or register a Microsoft account.

### Running Visual Studio the First Time

#### Installing Visual Studio Extensions

#### Generalized Procedure for Installing Extensions

1. Drop down the *Tools* menu and click the *Extensions and Updates...* menu item.
2. In the *Extensions and Updates* dialog, click the left side tree view menu *Online* node button
3. In the top right *Search* text box, enter the text like the name of the extension you want
4. In the center list, select the extension you want and click its *Download* button
5. Complete the extension's installation procedure
6. Many extension installation require restarting Visual Studio, so restart it

##### Visual Studio Extensions and Releated Accessories We Will be Using

| Extension | Description | Installation Notes | Screenshots |
|---|---|---|---|
| **GitHub** | Used in the Team Explorer to interface with your projects on GitHub.com | Select `GitHub Extensions` optioon during initial Visual Studio installation or later using the [generalized procedure above](#generalized-procedure-for-installing-extensions) | [GitHub Extensions](Developer_Exercises.files/visualstudio_extensions_github.png) |
| **Markdown Editor** | Used to view and edit Git Flavored Markdown documentation files | Install using the [generalized procedure above](#generalized-procedure-for-installing-extensions) | [Markdown Editor](Developer_Exercises.files/visualstudio_extensions_markdowneditor.png) |
| **OSIsoft.AFSDK** | OSIsoft PI Asset Framework Client SDK | Download and install from [OSIsoft.com](https://techsupport.osisoft.com/Downloads/All-Downloads/PI-Server/PI-AF/All-Categories) | [OSIsoft.com PI-AF Downloads Page](Developer_Exercises.files/osisoft-sdk-downloadpage.png) |
| **Sandcastle** | EWSoftware Sandcastle Help File Builder and Tools | Download and install from [Current Release](https://github.com/EWSoftware/SHFB/releases) | [Install as Administrator](Developer_Exercises.files/visualstudio_extensions_sandcastle-01.png) |
| **Visual Studio C++ Tools** | Visual C++ Tools for Windows Desktop | Select the `Programming Languages / Visual C++ / Common Tools for Visual C++ 2015` option during initial Visual Studio installation | [`Programming Languages / Visual C++ / Common Tools for Visual C++ 2015`](Developer_Exercises.files/visualstudio_community2015_visualctools.png) |
| **Visual Studio Extensibility Tools** | Development Tools and Templates to Extend Visual Studio | Select the `Visual Studio Extensibility Tools` option during initial Visual Studio installation | [Installation Option](Developer_Exercises.files/visualstudio_community2015_initialoptions.png)
| **WiX Toolset** | Tools for creating Windows installations | Download and install the [latest release](http://wixtoolset.org/releases/) | [WiX Extension](Developer_Exercises.files/visualstudio_extensions_wix.png) |

---

## openPDC

Let's try gitting the source code and building the **openPDC** software ourselves!

### Forking the openPDC Project Repository

A *Fork* of a project is *Your* separated snapshot of that project that you can use for development or experimental purposes. The *Fork* is your sandbox that you can safely work with and not disrupt the main project. If you make changes to your fork that you want to contribute back to the original project, the procedure is to create and submit a *Pull Request* in the main project. This workflow enables the project team to review your contribution before merging your code with the main project.

1. Open a web browser and sign in to [GitHub](https://github.com)
2. Navigate to the [openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC) 
3. Click the *Fork* button near the upper right side
4. In the *Where should we fork this repository?* dialog, click on your GitHub profile
5. It may take a few minutes to complete the fork process
6. When the forking process completes, your browser will be redirected to your new **openPDC** project fork. Verify this is really *Your* fork by reviewing the repository path displayed in the upper left corner of the screen. The repository path should read like `{yourname}/openPDC`. Also, your browser's address URL should now look something like `https://github.com/{yourname}/openPDC`

#### Rename Your `openPDC` Project Fork to `openPDC_fork`

1. In your fork's project page, click on the *Settings* tab
2. In the *Settings* tab / *Features* section, set the *Restrict editing to collaborators only* checkbox as `Checked`
3. In the *Repository Name* textbox, change the repository name to `openPDC_fork`
4. Click the *Rename* button to save the *Settings*
5. Click the *Code* tab
6. The repository path should read like `{yourname}/openPDC_fork`. Also, your browser's address URL should now look something like `https://github.com/{yourname}/openPDC_fork`

#### Clone Your `openPDC_fork` Project to Your Local Machine

1. Open Visual Studio and select the *Team Explorer* tab on the right side of the screen
2. In the *GitHub* section, click the *Connect* or *Sign in* hyperlink to sign in to GitHub using your GitHub account
3. After connected to *GitHub*, click the *Clone* hyperlink to launch the *Clone a GitHub Repository* dialog.
4. Select the `openPDC_fork` repository then click the dialog's *Clone* button

---

## Open the openPDC Solution

1. Open Visual Studio
2. Drop down the *File* menu and click on the *Open* submenu
3. Click on the *Project/Solution* submenu item
4. In the *Open Project* dialog, navigate to `C:\GPA\forks\openPDC_fork\Source`
5. Select the solution file: `Synchrophasor.sln`
6. Click the *Open* button

### Resolving Dependency Warnings

When you open the openPDC solution or try to build it, you may get missing dependencies warnings or errors. Please see the [GridSolutionsFramework Exercise's *Resolving Dependency Warnings*](Exercise_GPA_GridSolutionsFramework_Development.md#resolving-dependency-warnings) for resolving missing dependencies.

### Build the openPDC Solution

1. Try to build the `openPDC`.

---

## Merging the Grid Protection Alliance Changes into Your Forked Project Repository

The `openPDC` project is dynamically eveolving. Perodically, you may want to merge changes made to the original project with your forked project.

### Using Git to Update Your Local Fork's Repository

The following tasks use [Git Portable for Windows](Exercise_GPA_Developer_Workstation.md#software-packages-for-this-exercise) available from [git-scm.com](https://git-scm.com)

#### Fork Update Procedure

1. Open a Git Bash console window by running the following command
    - `C:\Apps\Git\git-bash.exe`
2. At the bash `$` prompte, navigate to your fork's folder
    - $ `cd /c/GPA/forks/openPDC_fork`
3. Only do this once: Configure your repository *remote*s 
    - Review your *remote*s
        - $ `git remote -v`
    - Add a remote named *gpa* for connecting to the Grid Protection Alliance upstream repository
        - $ `git remote add gpa https://github.com/GridProtectionAlliance/openPDC.git`
4. Check the status of your local fork. Consider committing any uncommitted changes to avoid merge conflicts.
    - $ `git status`
5. Pull the latest source code from the Grid Protection Alliance master
    - $ `git pull gpa master`
6. Push your local fork's updates up to your fork's repository on GitHub.
    - $ `git push origin master`

#### Using Git Example Session
 
```
tangent@GPA-DEV MINGW64 /
$ # Navigate to the project's repository
$ cd /c/GPA/forks/openPDC_fork

tangent@GPA-DEV MINGW64 /c/GPA/forks/openPDC_fork (master)
$ # Examine the directory listing
$ ls -al
...

tangent@GPA-DEV MINGW64 /c/GPA/forks/openPDC_fork (master)
$ # Check the git status of the repository to see if we have any uncommitted changes
$ git status
On branch master
Your branch is up-to-date with 'origin/master'.
nothing to commit, working tree clean

tangent@GPA-DEV MINGW64 /c/GPA/forks/openPDC_fork (master)
$ # Examine our git remote assignments
$ git remote -v
origin  https://github.com/tangent/openPDC_fork.git (fetch)
origin  https://github.com/tangent/openPDC_fork.git (push)

tangent@GPA-DEV MINGW64 /c/GPA/forks/openPDC_fork (master)
$ # We only need to do this one time
$ # Add a remote assignment for the Grid Protection Alliance upstream repository
$ git remote add gpa https://github.com/GridProtectionAlliance/openPDC.git

tangent@GPA-DEV MINGW64 /c/GPA/forks/openPDC_fork (master)
$ # Examine our git remote assignments and make sure we did it correctly
$ git remote -v
origin  https://github.com/ajstadlin/openPDC_fork.git (fetch)
origin  https://github.com/ajstadlin/openPDC_fork.git (push)
gpa     https://github.com/GridProtectionAlliance/openPDC.git (fetch)
gpa     https://github.com/GridProtectionAlliance/openPDC.git (push)

tangent@GPA-DEV MINGW64 /c/GPA/forks/openPDC_fork (master)
$ # Pull and automatically merge the GPA Upstream changes into our repository
$ git pull gpa master
remote: Counting objects: 293, done.
remote: Compressing objects: 100% (22/22), done.
remote: Total 293 (delta 188), reused 293 (delta 188), pack-reused 0
Receiving objects: 100% (293/293), 31.67 KiB | 0 bytes/s, done.
Resolving deltas: 100% (188/188), completed with 99 local objects.
From https://github.com/GridProtectionAlliance/openPDC
 * branch                  master     -> FETCH_HEAD
 * [new branch]            master     -> gpa/master
Updating 767413ca11..98797cf098
Fast-forward
 . . .
 93 files changed, 309 insertions(+), 309 deletions(-)

$ # if something went wrong, or have a merge conflict you will have to fix it.

tangent@GPA-DEV MINGW64 /c/GPA/forks/openPDC_fork (master)
$ # Update your forked project on GitHub
$ git push origin master

```

---

## Exercise Conclusion

This exercise demonstrated a "first time" approach to setting up a current platform workstation and latest stable release software for developing Grid Protection Alliance software using Microsoft Visual Studio Community Edition. 

- We cloned the openPDC's latest source code to our own project fork on GitHub.
- We used all current stable platform and software versions to build the openPDC from its latest source code.
- We used Git to update our fork with the latest Grid Protection Alliance master source code

---

Dec 26, 2016 - Cloned from [Exercise_GPA_GridSolutionsFramework_Development.md] and edited by [aj](https://github.com/ajstadlin)

---

Copyright 2017 [Grid Protection Alliance](http://www.gridprotectionalliance.org)