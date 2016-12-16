[![The Open Source Phasor Data Concentrator](../openPDC_Logo.png)](../openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](../openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](../openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

***This is an archival document and its contents are no longer maintained or updated.***

# Simple Moving Average, Secondary Sort, and MapReduce

by Josh Patterson, March 14, 2011

- [Part 1](http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/)
- [Part 2](http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2/)
- [Part 2](http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2/)

### Intro

> In this three part blog series I want to take a look at how we would do a Simple Moving Average with MapReduce and Apache Hadoop. This series is meant to show how to translate a common Excel or R function into MapReduce java code with accompanying working code and data to play with. Most analysts can take a few months of stock data and produce an excel spreadsheet that shows a moving average, but doing this in Hadoop might be a more daunting task. Although time series as a topic is relatively well understood, I wanted to take the approach of using a simple topic to show how it translated into a powerful parallel application that can calculate the simple moving average for a lot of stocks simultaneously with MapReduce and Hadoop. I also want to demonstrate the underlying mechanic of using the “secondary sort” technique with Hadoop’s MapReduce shuffle phase, which we’ll see is applicable to a lot of different application domains such as finance, sensor, and genomic data.

> This article should be approachable to the beginner Hadoop programmer who has done a little bit of MapReduce in java and is looking for a slightly more challenging MapReduce application to hack on. In case you’re not very familiar with Hadoop, here’s some background information and CDH. The code in this example is hosted on github and is documented to illustrate how the various components work together to achieve the secondary sort effect. One of the goals of this article is to have this code be relatively basic and approachable by most programmers.

> So let’s take a quick look at what time series data is and where it is employed in the quickly emerging world of large-scale data.

---

Mar 14, 2011 - Originally posted on Blog.Cloudera.com by [jpatanooga](https://github.com/jpatanooga)  
Dec 15, 2016 - Referenced by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)