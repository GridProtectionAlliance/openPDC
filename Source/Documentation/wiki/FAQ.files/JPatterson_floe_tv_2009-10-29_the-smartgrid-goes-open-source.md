[![The Open Source Phasor Data Concentrator](../openPDC_Logo.png)](../openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](../openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](../openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated.***

# The Smartgrid Goes Open Source

[The Smartgrid Goes Open Source](http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/10/29/the-smartgrid-goes-open-source "Internet Archive WayBack Machine")

### Document by JPatterson, Oct 29, 2009

I love it when a plan comes together — Hannibal, The A-Team

*Disclaimer: I’m a contributor on the openPDC and I work for TVA/NERC. These are my personal views and in no way espouse the opinion or position of my employer or the Federal government. These are simply my thoughts from an outside viewpoint on where I could see this open source project going and not necessarily any real roadmaps or internal plans.*

Recently TVA and the NERC open sourced a key part of the “smartgrid” that deals with concentration, storage, and processing of transmission and generation phasor measurement unit (PMU) data. This project is referred to as the Open Phasor Data Concentrator (openPDC) and is housed at http://openpdc.codeplex.com where members of the power community (and interested enthusiasts) can examine or contribute to the project. From the website the project is described as:

The openPDC is a complete set of applications for processing streaming time-series data in real-time. Measured data is gathered with GPS-time from multiple input sources, time-sorted and provided to user defined actions, then dispersed to custom output destinations for archival.

The website goes on further to describe the project in more detail:

The open source phasor data concentrator (openPDC) is a system that can be used to process complex events and respond to dynamic changes in fast moving data. More specifically, the openPDC can process complex events that can be described as “time-stamped measured values”. These measured values are simply numeric quantities that have been acquired at a source device and are typically called points, signals, events, time-series values or measurements. Examples of measurements include temperature, voltage, vibration, location, luminosity and, of course, phasors. When a value gets measured, an exact timestamp is taken, typically using a GPS-clock for accuracy – the value, along with its timestamp, is then streamed to the openPDC where it can be “time-aligned” with other incoming measurements so that an action can then be taken on a complete slice of data that was all measured at the exact same moment in time.

The U.S. power grid is run by multiple private and government run power companies which must all work together in order to keep power flowing and downtime to a minimum. The openPDC allows a regional grid operator to collect PMU data from multiple sources and either archive it or forward it on to a larger concentration point. The NERC designated TVA as the official repository for the collection and archival of U.S. power grid PMU data (although currently only the eastern half is online). Given that large scale data warehousing and analysis is no mean feat, Hadoop was chosen as the architecture for the PMU data repository.

Hadoop is a framework for running applications on large clusters built of commodity hardware. Hadoop includes the Hadoop Distributed File System (HDFS) and the Map Reduce programming model. The openPDC project includes the necessary Hadoop components (InputFormat and RecordReader) to allow Hadoop to work directly with openPDC data points.

The openPDC collects data from around the US power grid for archival and analysis. The openPDC is designed to talk directly to PMU sensor devices and transmit it back to collection nodes. At collection nodes the data is archived in a binary format by the Historian (also included in the openPDC project). This archival format can then be used directly with Hadoop via the classes included in the openPDC project (Inputformat / RecordReader).

Hadoop works well for a project such as the openPDC in that:

- Its based on commodity hardware
- Its performance generally scales linearly with the size of the input data
- Its programming model Map Reduce is simple and robust
- It doesn’t lock a project into a proprietary system

The openPDC is really interesting from an engineering perspective in that it provides an open source “building block” for smart grid participants and researchers to work with to develop more layers of the smart grid. I look at the openPDC in the same role as Google’s Android platform in that it:

- Allows researchers to focus on research and not on implementing protocols
- Allows vendors to focus on a common building block
- Gives companies with less resources an opportunity to compete without having to “re-invent the wheel”
- Gives companies a way to collaborate on a common building block to drive improvement of their market

In addition to the obvious use cases within the smart grid, the openPDC is well suited to collect time-series data from just about any type of sensors. Once the proper adapters for the specific sensor is written, time series data could then be easily collected, concentrated, and archived for easy analysis in a Hadoop cluster. To me this seems like a very good collection and analysis framework to use with a system like a TinyOS mesh network. Complex distributed systems can be difficult to build from scratch and using building block components such as openPDC greatly lowers the overall cost of development.

Development overhead is greatly reduced with the openPDC just like Android can cut down development costs significantly for cell phone companies. In a similar way, Hadoop cuts down costs in that Hadoop is open source and an open platform. From a tax payer’s standpoint, Hadoop is really nice in that our Federal Government is using an open source alternative and saving your tax dollars. On top of that, a government entity is open sourcing a key piece of smart grid technology — the openPDC. I believe this is a unique situation where a government entity made extremely effective and intelligent use of resources that benefited society. Hopefully we’ll continue to see these type initiatives spring up in the future.

openPDC Coverage:

- http://www.chattanoogan.com/articles/article_160601.asp
- http://www.tva.gov/news/releases/octdec09/data_collection_software.htm
- http://forum.complexevents.com/viewtopic.php?f=17&t=217
- http://news.cnet.com/8301-13846_3-10393259-62.html?tag=mncol;title
- http://earth2tech.com/2009/11/10/the-google-android-of-the-smart-grid-openpdc/
- http://agilecat.wordpress.com/2009/11/17/overview-of-hadoop-conference-2009-in-japan-english-edition/
- http://econgreen.blogspot.com/2009/11/set-phasors-to-smart.html

```
FILE ARCHIVED ON 3:05:39 Dec 20, 2010 AND RETRIEVED FROM THE
INTERNET ARCHIVE ON 4:06:05 Oct 4, 2015.
BY WAYBACK MACHINE, COPYRIGHT INTERNET ARCHIVE.
ALL OTHER CONTENT MAY ALSO BE PROTECTED BY COPYRIGHT (17 U.S.C. SECTION 108(a)(3)).
```

---

Oct 29, 2009 - [Internet Archive WayBack Machine Document](http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/10/29/the-smartgrid-goes-open-source "Internet Archive WayBack Machine") by [jpatanooga](https://github.com/jpatanooga)  
Dec 12, 2016 - reference submitted by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)