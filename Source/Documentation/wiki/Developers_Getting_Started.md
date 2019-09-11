[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](https://github.com/GridProtectionAlliance/openPDC/wiki)** | **[Documentation](https://github.com/GridProtectionAlliance/openPDC/wiki/Documentation)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Getting Started with openPDC for Developers

This guide is intended to aid in building the openPDC software. If you're already familiar with the guide, feel free to use this navigation tool to jump around. If you need to see how to configure the openPDC, please refer to the [Getting Started](Getting_Started.md) page, under the User's Documentation.

- [Build openPDC from source code](#build-openpdc-from-source-code)
    - [Get the development tools](#get-the-development-tools)
    - [Get the source code](#get-the-source-code)
    - [Build the software](#build-the-software)
        - [Build the TVA Code Library](#build-the-tva-code-library)
        - [Build the Time Series Framework](#build-the-time-series-framework)
        - [Build the openPDC Historian](#build-the-openpdc-historian)
        - [Build the openPDC Synchrophasor](#build-the-openpdc-synchrophasor)

---

## Build openPDC from source code

OpenPDC is an orchestration of multiple sub projects. The following describes the requirements for configuring a typical development system.

### Get the development tools

You will need to have Microsoft Visual Studio 2010 in order to build and run the openPDC. You can download the trial or purchase the software from Microsoft's website at [Microsoft MSDN](http://msdn.microsoft.com).

The openPDC system uses the Microsoft .NET 4.0 Framework. The .NET 4.0 redistributables may be downloaded from: [.NET 4.0 Framework Stand Alone and Web Installation Instructions](http://msdn.microsoft.com/en-us/library/5a4x27ek.aspx).

Optionally, you can install Microsoft SQL Server Express during the Visual Studio installation if you plan on using a SQL Server database with openPDC.

Additionally, if you don't have the Team version of Microsoft Visual Studio 2010, you will need to install FxCop. You can download that for free from Microsoft's website at [
FxCop 10.0](http://www.microsoft.com/downloads/en/details.aspx?FamilyID=917023f6-d5b7-41bb-bbc0-411a7d66cf3c&displaylang=en).

### Get the source code

To download the source code:

1. Browse to each project site home page listed below
2. Click the Source Code tab at the top of the page
3. On the right side of the page, under the heading "Latest Version", click the "Download" link.
4. Click "I Agree" to accept the license agreement.
5. Select "Save" and select a destination for the compressed source code files.
6. Navigate to the location where you downloaded the compressed source code files, and extract the source code from the zip archive.

Source code project site home pages

- [TVA Code Library](http://tvacodelibrary.codeplex.com)
- [Time Series Framework](http://timeseriesframework.codeplex.com)
- [openHistorian](https://github.com/GridProtectionAlliance/openHistorian)
- [openPDC Synchrophasor](https://github.com/GridProtectionAlliance/openPDC)
- [PMU Connection Tester](https://github.com/GridProtectionAlliance/PMUConnectionTester)
- [PMU Registry](http://pmuregistry.codeplex.com)

### Build the software

The following subsections describes the requirements for building the openPDC software from the source code using Microsoft Visual Studio.

**Note 1**: If you're having trouble, you may find that you need to build the solutions in the following order:

1. [Build the TVA Code Library](#build-the-tva-code-library)
2. [Build the Time Series Framework](#build-the-time-series-framework)
3. [Build the openPDC Historian](#build-the-openpdc-historian)
4. [Build the openPDC Synchrophasor](build-the-openpdc-synchrophasor)

**Note 2**: When loading the solutions or projects you may be prompted to use source code control.

#### Build the TVA Code Library

After extracting the TVA Code Library source code, the Visual Studio solution is located in the `SOURCEDIR\Main\Source` folder. `SOURCEDIR` is the directory you extracted the source code files to.

1. Open Microsoft Visual Studio
2. In the toolbar, go to "File > Open > Project/Solution..."
3. Navigate to `SOURCEDIR\Main\Source`, select "TVACodeLibrary.sln", and click "Open"
4. In the toolbar, go to "Build > Build Solution"

#### Build the Time Series Framework

After extracting the Time Series Framework source code, the Visual Studio solution is located in the `SOURCEDIR\Main\Source` folder. `SOURCEDIR` is the directory you extracted the source code files to.

##### Dependencies

- [TVA Code Library](http://tvacodelibrary.codeplex.com)

##### Typical Build Procedure

1. Open Microsoft Visual Studio
2. In the toolbar, go to "File > Open > Project/Solution..."
3. Navigate to `SOURCEDIR\Main\Source`, select "TimeSeriesFramework.sln", and click "Open"
4. If you made changes to the TVA Code Library, then be sure to replace the Project References for the dependency.
5. In the toolbar, go to "Build > Build Solution"

#### Build the openPDC Historian

After extracting the openPDC source code, the Visual Studio solution is located in the `SOURCEDIR\Historian\Current Version\Source` folder. `SOURCEDIR` is the directory you extracted the source code files to.

##### Dependencies

- [TVA Code Library](http://tvacodelibrary.codeplex.com)
- [Time Series Framework](http://timeseriesframework.codeplex.com)

##### Typical Build Procedure

1. Open Microsoft Visual Studio
2. In the toolbar, go to &quot;File &gt; Open &gt; Project/Solution..."
3. Navigate to `SOURCEDIR\Historian\Current Version\Source`, select "Historian.sln", and click "Open"
4. If you made changes to the TVA Code Library or Time Series Framework, then be sure to replace the Project References for those dependencies.
5. In the toolbar, go to "Build > Build Solution" 

#### Build the openPDC Synchrophasor

After extracting the openPDC source code, the Visual Studio solution is located in the `SOURCEDIR\Current Version\Source` folder. `SOURCEDIR` is the directory you extracted the source code files to.

##### Dependencies

- [TVA Code Library](http://tvacodelibrary.codeplex.com)
- [Time Series Framework](http://timeseriesframework.codeplex.com)
- [Historian](https://github.com/GridProtectionAlliance/openHistorian)

##### Typical Build Procedure

1. Open Microsoft Visual Studio
2. In the toolbar, go to ""File > Open > Project/Solution..."
3. Navigate to `SOURCEDIR\Synchrophasor\Current Version\Source`, select "Synchrophasor.sln", and click "Open"
4. If you made changes to the TVA Code Library, Time Series Framework, or TVA.Historian, then be sure to replace the Project References for those dependencies.
5. In the toolbar, go to "Build > Build Solution"

---

Jun 25, 2012 8:25 PM - Last edited by [alexfoglia](http://www.codeplex.com/site/users/view/alexfoglia), version 3  
Oct 4, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Getting%20Started%20%28Developers%29) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)