[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](https://github.com/GridProtectionAlliance/openPDC/wiki)** | **[Documentation](https://github.com/GridProtectionAlliance/openPDC/wiki/Documentation)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# openPDC Frequently Asked Questions

- [I am having trouble building the solution, what I am doing wrong?](#i-am-having-trouble-building-the-solution-what-i-am-doing-wrong)
- [Synchrophasor Questions](#synchrophasor-questions)
    - [openPDC Questions](#openpdc-questions)
        - [When I open the Synchrophasor solution, I get the following message: "The project '...' cannot be opened. The project type is not supported by this installation". What is this?](#when-i-open-the-synchrophasor-solution-i-get-the-following-message-the-project-cannot-be-opened-the-project-type-is-not-supported-by-this-installation-what-is-this)
        - [After I have rebuilt the Framework solution while the Synchrophasor solution is open, then try to rebuild Synchrophasor, the PMU Connection Tester shows a million errors, what is that?](#after-i-have-rebuilt-the-framework-solution-while-the-synchrophasor-solution-is-open-then-try-to-rebuild-synchrophasor-the-pmu-connection-tester-shows-a-million-errors-what-is-that)
        - [I'd like to create my own custom adapter. What are the various types of adapters used for?](#id-like-to-create-my-own-custom-adapter-what-are-the-various-types-of-adapters-used-for)
- [Historian Questions](#historian-questions)
    - [Is the binary format of the history file documented?](#is-the-binary-format-of-the-history-file-documented)

---

#### I am having trouble building the solution, what I am doing wrong?

*Answer:* The solutions have the following dependencies: Synchrophasor depends on Historian and Framework. Historian depends on Framework. So, make sure you rebuild all projects in the solutions in this order: Framework, Historian, Synchrophasor.

---

## Synchrophasor Questions

### openPDC Questions

#### When I open the Synchrophasor solution, I get the following message: "The project '...' cannot be opened. The project type is not supported by this installation". What is this?

*Answer:* The Synchrophasor solution includes a Silverlight application, as well as a Visual Basic application. This error can be safely ignored if you do not wish to view and/or modify the openPDCManager (based on Silverlight) or the PMU Connection Tester (based on VB.NET). To load the Silverlight application, install the following:

1. Silverlight3 Tools for Visual Studio 2008 SP1: [http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&amp;displaylang=en](http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en)
2. Silverlight3 Toolkit July 2009: [http://silverlight.codeplex.com/Release/ProjectReleases.aspx?ReleaseId=24246](http://silverlight.codeplex.com/Release/ProjectReleases.aspx?ReleaseId=24246) 

To load the Visual Basic application, you will need to reinstall Visual Studio, making sure to include "Visual Basic" as an installed programming language.

#### After I have rebuilt the Framework solution while the Synchrophasor solution is open, then try to rebuild Synchrophasor, the PMU Connection Tester shows a million errors, what is that?

*Answer:* This is some kind of Visual Basic project bug related to dynamically updating its references. Right-click on the PMU Connection tester, and select "Unload Project". If you are not dealing with the connection tester, you can leave it unloaded; otherwise, right-click the project again, and select "Reload Project" and the errors will be gone.

#### I'd like to create my own custom adapter. What are the various types of adapters used for?

*Answer:* You can do anything you like with any adapter. Basically all adapters are similar in nature but perform the following specific abstract tasks.

**InputAdapters**: Typically "maps" measurements from a data source (i.e., assigns a timestamp and an ID to measured values parsed from a stream of data), new measurements are presented to openPDC by calling `void OnNewMeasurements(ICollection<IMeasurement> measurements)` method. Interface: `IInputAdapter`, base class: `InputAdapterBase`

**ActionAdapters**: Typically filters and sorts measurements by time allowing adapter to take action on a synchronized set of data provided in the `abstract void PublishFrame(IFrame frame, int index)` method which adapter overrides (note that frame contains a collection of measurements all collected into the same time-indexed frame bucket). If the action causes the creation of new measurements (e.g., phase angle and magnitude used to calculate power), new measurements are presented to openPDC by calling `void OnNewMeasurements(ICollection<IMeasurement> measurements)` method. Interface: `IActionAdapter`, base class: `ActionAdapterBase`

**OutputAdapters**: Typically queues all measurements (no sorting) for processing. Queued measurements are presented to the adapter for processing in the `void ProcessMeasurements(IMeasurement[] measurements)` method - if measurements continue to build up in memory and are not processed in a timely manner they will be removed from the queue as protective measure to prevent catastrophic out-of-memory failures. Since output adapters are used to archive data this is often the slowest part in the system (disks tend to be a bottleneck), outputs can optionally be set to filter based on a measurement's defined `Source` property - this allows multiple outputs to be targeted to several different distributed outputs which allows large systems to stay ahead of the incoming data stream. Interface: `IOutputAdapter`, base class: `OutputAdapterBase`

You can read more about creating custom adapters on the [how-to page for custom adapters](Developers_Custom_Adapters.md)

---

## Historian Questions

#### Is the binary format of the history file documented?

*Answer:* Yes. Click [here](Developers_Frequently_Asked_Questions.files/openPDC_D_Historical_File_Format.docx) for a document that describes the high level format. Also, the binary format for all the data stored in the archive is documented in the individual class files in `TVA.Historian` class library. A good place to start would be the class files under `TVA.Historian.Files` namespace of TVA.Historian class library project.

---

Jun 25, 2012 8:27 PM - Last edited by [alexfoglia](http://www.codeplex.com/site/users/view/alexfoglia), version 4  
Oct 4, 2016 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Frequently%20Asked%20Questions%20%28Developers%29) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance]http://www.gridprotectionalliance.org)