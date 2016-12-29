[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated.***

---

# Open-source Hadoop powers Tennessee smart grid

[Open-source Hadoop powers Tennessee smart grid](https://www.cnet.com/news/open-source-hadoop-powers-tennessee-smart-grid/)

##### Open-source data processing software is monitoring and managing massive amounts of data for the Tennessee Valley Authority.

The Tennessee Valley Authority is the nation's largest public power provider serving approximately 9 million consumers in seven southeastern states. The organization also happens to be a big supporter of open-source projects, including Hadoop, a tool designed for deep analysis and transformation of very large data sets. 

Earlier this year, the Tennessee Valley Authority (TVA) announced that it open sourced its data system used to collect data from smart grid devices called Phasor measurement units (PMUs). The data collection system is known in the industry as a Super Phasor Data Concentrator (SuperPDC), which can be used to determine the health of a power grid. 

The open-source version of the SuperPDC is now called the "OpenPDC." I spoke to both Ritchie Carroll (**RC**), the project's creator, and Josh Patterson (**JP**), the person responsible for introducing Hadoop to the project, to discuss what the OpenPDC is and why TVA turned to Hadoop in building the system. 

##### What sort of data volumes are you working with? 

**RC**: Currently there is around 20 TB of archived data, we expect this to grow quickly as a result of the SmartGrid stimulus funding which includes the addition of 850 phasor measurement devices. This may well grow the archive to half a Petabyte within the next few years. 

##### How is this data currently captured and managed? Is any data discarded? 

**JP**: Data is collected directly from field devices at 30 times per second. This data is then time-aligned and processed in real-time--all data gets captured into a binary data file as time-series data for mass processing by Hadoop. 

**RC**: No data is currently discarded, if we get to the point of needing to discard data because of cost--this will be a decision based on weighed importance of collected data. It is likely the data around major events will never be deleted because it will always be valuable for future student researchers. There is also value in being able to go back in time and look for newly discovered event signatures to see how long they might have been occurring. 
 
##### What other types of systems did you consider? Why did you settle on Hadoop? 

**JP**: We considered several technologies including SAN, NAS devices, and RDBM systems. Hadoop gave us a commodity based hardware solution that offered superior reliability at a minimal cost using HDFS, but it also had the added processing benefit using Map Reduce over large scale data for fast analysis. 

##### Are there additional types of data you might be able to capture and analyze now that were simply impossible before? How might this new data be valuable? 

**RC**: We expect that the utility industry will start collecting more kinds of operational and nonoperational data so that in-depth analysis can be performed. Analysis of previously unaggregated data provided from various types of high-dollar, high-volume capital equipment may help to ascertain their performance and possibly even provide better estimates on time to failure. Additionally, the OpenPDC as a whole is a very generalized platform for processing any kind of streaming time-series data and as such we expect other scientific genres with similar data problems to find this open source software useful. 

##### What are you hoping to accomplish by open sourcing the PDC system? Have you had interest from other energy organizations? 

**RC**: It is our hope that this code will be used to support the development of the smart grid and facilitate the Department of Energy plans to accelerate the use of synchrophasors in the U.S. as part of the federal economic stimulus programs. We believe that this software will be an enabling technology for both vendors and the electric power system industry as a whole and we have had a large interest from industry, especially those that have been awarded stimulus grants. The other exciting things is that vendor community has quickly adopted the open source software and we expect commercial support for the OpenPDC to be announced very soon. 

##### What new types of analyses does Hadoop enable? Why were these impossible before? 

**JP**: Pretty much any type of data analysis that you want. Data mining is very difficult to do when dealing with slow disks and big data. Our time is very valuable. Hadoop just made sense from that perspective. Previously even simple data scans were very slow. Now doing even simple event detection on terabytes of data is relatively simple with Hadoop. 

##### What sort of feedback have you received from the energy community so far? 

**RC**: The response from the energy community has been extremely positive. By exposing this key technology to the public as open source, researchers, vendors and developers now have an opportunity to engage in the development of new synchrophasor technologies without having to spend the majority of their time dealing with protocol parsing and data management. 

TVA is under contract with the North American Electric Reliability Corporation NERC to deliver a next generation version of the OpenPDC. This second generation system will be completely based on the OpenPDC but be extended to allow multiple deployed systems to work cooperatively as a distributed system of regional data collectors. Several other large electric industry ISO and utilities are being targeted to host this distributed concentration system known as the "NERC Phasor Concentration System." The goal is to have all the archived data flow back to a central archive based on Hadoop for permanent storage and off-line analysis. 

---

Nov 9, 2009 7:25 PM PST - Posted by [Dave Rosenberg](https://www.cnet.com/profiles/dave+rosenberg/)  
Dec 15, 2016 - Migrated from [cnet.com](https://www.cnet.com/news/open-source-hadoop-powers-tennessee-smart-grid/) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)