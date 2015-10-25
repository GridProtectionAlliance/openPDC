<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head profile="htt

<!--HtmlToGmd.Body-->

<div id="NavigationMenu">

<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">

<tr>

<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->

p://gmpg.org/xfn/11">

<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

<title>The Smartgrid Goes Open Source - JPatterson Oct 29, 2009</title>

<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body>

</div>

	<div id="content">			

		<div class="post" id="post-63">

            

			<h2><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/10/29/the-smartgrid-goes-open-source/" rel="bookmark" title="Permanent Link: The Smartgrid Goes Open Source">The Smartgrid Goes Open Source</a></h2>

			<small>by Josh Patterson ~ October 29th, 2009. Filed under: <a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/distributed-file-systems/" title="View all posts in Distributed File Systems" rel="category tag">Distributed File Systems</a>,  <a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/hadoop/" title="View all posts in hadoop" rel="category tag">hadoop</a>,  <a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/openpdc/" title="View all posts in openPDC" rel="category tag">openPDC</a>,  <a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/smartgrid/" title="View all posts in smartgrid" rel="category tag">smartgrid</a>. </small>

	

			<div class="entry">

				<p class="MsoNormal" style="margin: 0in 0in 0pt;"> </p>

<blockquote>

<p class="MsoNormal" style="text-align: right;"><em>I love it when a plan comes together.</em></p>

<p class="MsoNormal" style="text-align: right;">&#8212; Hannibal, The A-Team</p>

</blockquote>

<p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: right;"><em>Disclaimer: I&#8217;m a contributor on the openPDC and I work for TVA/NERC. These are my personal views and in no way espouse the opinion or position of my employer or the Federal government. These are simply my thoughts from an outside viewpoint on where I could see this open source project going and not necessarily any real roadmaps or internal plans.</em></p>

<p class="MsoNormal" style="margin: 0in 0in 0pt;"> </p>

<p class="MsoNormal" style="margin: 0in 0in 0pt;">Recently <a href="http://web.archive.org/web/20101220030539/http://earth2tech.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/">TVA</a> and the NERC <a href="http://web.archive.org/web/20101220030539/http://www.tva.gov/news/releases/octdec09/data_collection_software.htm">open sourced a key part of the &#8220;smartgrid&#8221;</a> that deals with concentration, storage, and processing of transmission and generation phasor measurement unit (PMU) data. This project is referred to as the Open Phasor Data Concentrator (openPDC) and is housed at <a href="http://web.archive.org/web/20101220030539/http://openpdc.codeplex.com/">http://openpdc.codeplex.com </a>where members of the power community (and interested enthusiasts) can examine or contribute to the project. From the website the project is described as:</p>

<blockquote><p><span style="font-family: ">The openPDC is a complete set of applications for processing streaming time-series data in real-time. Measured data is gathered with GPS-time from multiple input sources, time-sorted and provided to user defined actions, then dispersed to custom output destinations for archival.</span></p></blockquote>

<p><span style="font-family: ">The website goes on further to describe the project in more detail:<br />

</span></p>

<blockquote><p><span style="font-family: ">The open source phasor data concentrator (openPDC) is a system that can be used to <a class="externalLink" href="http://web.archive.org/web/20101220030539/http://en.wikipedia.org/wiki/Complex_event_processing"><span style="color: #3e62a6;">process complex events</span></a><span style="color: #30332d;"> and respond to dynamic changes in fast moving data. More specifically, the openPDC can process complex events that can be described as “time-stamped measured values”. These measured values are simply numeric quantities that have been acquired at a source device and are typically called points, signals, events, time-series values or <em>measurements</em>. Examples of measurements include temperature, voltage, vibration, location, luminosity and, of course, phasors. When a value gets measured, an exact timestamp is taken, typically using a GPS-clock for accuracy – the value, along with its timestamp, is then streamed to the openPDC where it can be “time-aligned” with other incoming measurements so that an action can then be taken on a complete <em>slice</em> of data that was all measured at the exact same moment in time.</span><br />

</span></p></blockquote>

<p>The U.S. power grid is run by multiple private and government run power companies which must all work together in order to keep power flowing and downtime to a minimum. The openPDC allows a regional grid operator to collect PMU data from multiple sources and either archive it or forward it on to a larger concentration point. The NERC designated TVA as the official repository for the collection and archival of U.S. power grid PMU data (although currently only the eastern half is online). Given that large scale data warehousing and analysis is no mean feat, <a href="http://web.archive.org/web/20101220030539/http://hadoop.apache.org/">Hadoop</a> was chosen as the architecture for the PMU data repository.</p>

<p>Hadoop is a framework for running applications on large clusters built of commodity hardware. Hadoop includes the Hadoop Distributed File System (<a href="http://web.archive.org/web/20101220030539/http://hadoop.apache.org/common/docs/current/hdfs_design.html">HDFS</a>) and the <a href="http://web.archive.org/web/20101220030539/http://en.wikipedia.org/wiki/MapReduce">Map Reduce programming model</a>. The openPDC project includes the necessary Hadoop components (InputFormat and RecordReader) to allow Hadoop to work directly with openPDC data points.</p>

<p class="MsoNormal" style="margin: 0in 0in 0pt;"> </p>

<p class="MsoNormal" style="margin: 0in 0in 0pt;">The openPDC collects data from around the US power grid for archival and analysis. The openPDC is designed to talk directly to PMU sensor devices and transmit it back to collection nodes. At collection nodes the data is archived in a binary format by the Historian (also included in the openPDC project). This archival format can then be used directly with Hadoop via the classes included in the openPDC project (Inputformat / RecordReader).</p>

<p class="MsoNormal" style="margin: 0in 0in 0pt;"> </p>

<p class="MsoNormal" style="margin: 0in 0in 0pt;"> </p>

<p class="MsoNormal" style="margin: 0in 0in 0pt;">Hadoop works well for a project such as the openPDC in that:</p>

<ul>

<li>Its based on commodity hardware</li>

<li>Its performance generally scales linearly with the size of the input data</li>

<li>Its programming model Map Reduce is simple and robust</li>

<li>It doesn&#8217;t lock a project into a proprietary system</li>

</ul>

<p>The openPDC is really interesting from an engineering perspective in that it provides an open source &#8220;building block&#8221; for smart grid participants and researchers to work with to develop more layers of the smart grid. I look at the openPDC in the same role as <a href="http://web.archive.org/web/20101220030539/http://www.techcrunch.com/2009/10/15/schmidt-android-adoption-is-about-to-explode/">Google&#8217;s Android platform</a> in that it:</p>

<ul>

<li>Allows researchers to focus on research and not on implementing protocols</li>

<li>Allows vendors to focus on a common building block</li>

<li>Gives companies with less resources an opportunity to compete without having to &#8220;re-invent the wheel&#8221;</li>

<li>Gives companies a way to collaborate on a <a href="http://web.archive.org/web/20101220030539/http://www.thestreet.com/story/10614007/1/exclusive-google-plans-its-own-android-phone.html">common building block</a> to drive improvement of their market</li>

</ul>

<p>In addition to the obvious use cases within the smart grid, the openPDC is well suited to collect time-series data from just about any type of sensors. Once the proper adapters for the specific sensor is written, time series data could then be easily collected, concentrated, and archived for easy analysis in a Hadoop cluster. To me this seems like a very good collection and analysis framework to use with a system like a <a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/07/19/tinyos-and-tinytermite/">TinyOS mesh network</a>. Complex distributed systems can be difficult to build from scratch and using building block components such as openPDC greatly lowers the overall cost of development.</p>

<p>Development overhead is greatly reduced with the openPDC just like Android can cut down development costs significantly for cell phone companies. In a similar way, Hadoop cuts down costs in that Hadoop is open source and an open platform. From a tax payer&#8217;s standpoint, Hadoop is really nice in that our Federal Government is using an open source alternative and saving your tax dollars. <strong><em>On top of that, a government entity is open sourcing a key piece of smart grid technology &#8212; the openPDC.</em></strong> I believe this is a unique situation where a government entity made extremely effective and intelligent use of resources that benefited society. Hopefully we&#8217;ll continue to see these type <a href="http://web.archive.org/web/20101220030539/http://radar.oreilly.com/2009/10/defense-department-releases-op.html">initiatives</a> spring up in the future.</p>

<p>openPDC Coverage:</p>

<ul>

<li><a href="http://web.archive.org/web/20101220030539/http://www.chattanoogan.com/articles/article_160601.asp">http://www.chattanoogan.com/articles/article_160601.asp</a></li>

<li><span style="font-family: "><a href="http://web.archive.org/web/20101220030539/http://www.tva.gov/news/releases/octdec09/data_collection_software.htm">http://www.tva.gov/news/releases/octdec09/data_collection_software.htm</a></span></li>

<li><span style="font-family: "><span style="font-family: "><a href="http://web.archive.org/web/20101220030539/http://forum.complexevents.com/viewtopic.php?f=17&amp;t=217">http://forum.complexevents.com/viewtopic.php?f=17&amp;t=217</a></span></span></li>

<li><span style="font-family: "><span style="font-family: "><a href="http://web.archive.org/web/20101220030539/http://news.cnet.com/8301-13846_3-10393259-62.html?tag=mncol;title">http://news.cnet.com/8301-13846_3-10393259-62.html?tag=mncol;title</a></span></span></li>

<li><span style="font-family: "><span style="font-family: "><a href="http://web.archive.org/web/20101220030539/http://earth2tech.com/2009/11/10/the-google-android-of-the-smart-grid-openpdc/">http://earth2tech.com/2009/11/10/the-google-android-of-the-smart-grid-openpdc/</a></span></span></li>

<li><span style="font-family: "><span style="font-family: "><a href="http://web.archive.org/web/20101220030539/http://agilecat.wordpress.com/2009/11/17/overview-of-hadoop-conference-2009-in-japan-english-edition/">http://agilecat.wordpress.com/2009/11/17/overview-of-hadoop-conference-2009-in-japan-english-edition/</a></span></span></li>

<li><span style="font-family: "><span style="font-family: "><a href="http://web.archive.org/web/20101220030539/http://econgreen.blogspot.com/2009/11/set-phasors-to-smart.html">http://econgreen.blogspot.com/2009/11/set-phasors-to-smart.html</a></span></span></li>

</ul>

<p>�</p>

	<div class="navigation">

		<div class="alignleft">&laquo; <a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/07/20/a-high-level-comparison-of-hadoop-and-dryad/">A High Level Comparison of Hadoop and Dryad</a></div>

		<div class="alignright"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/2010/11/12/a-broad-overview-of-machine-learning/">A Broad Overview of Machine Learning</a> &raquo;<br />

            &amp;nbsp;</div>

</div>

</div>

</div>

</div>

<hr />

<div id="header">

<a href="http://web.archive.org/web/" title="Wayback Machine home page"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/files/wayback-toolbar-logo.png" alt="Wayback Machine" width="110" height="39" border="0" /></a>

<h3><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/">// The Song Remains The Same</a></h3>

</div>

<div id="menu">

	<ul class="fix">

			<li class="selected"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/">Home</a></li>

			<li class="page_item page-item-2"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/about/" title="About">About</a></li>

<li class="page_item page-item-29"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/contact/" title="Contact">Contact</a></li>

<li class="page_item page-item-4"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/current-side-projects/" title="Current Side Projects">Current Side Projects</a></li>

<li class="page_item page-item-12"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/image-gallery/" title="Image Gallery">Image Gallery</a></li>

<li class="page_item page-item-62"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/my-web-links/" title="My Web Links">My Web Links</a></li>

<li class="page_item page-item-5"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/resume/" title="Resume">Resume</a></li>

	</ul>

</div><div id="left">

<ul>

        

<li class="categories"><h2>Categories</h2><ul>	<li class="cat-item cat-item-15"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/brainstorming/" title="View all posts filed under Brainstorming">Brainstorming</a>

</li>

	<li class="cat-item cat-item-11"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/business/" title="View all posts filed under Business">Business</a>

</li>

	<li class="cat-item cat-item-4"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/data-portability/" title="View all posts filed under Data Portability">Data Portability</a>

</li>

	<li class="cat-item cat-item-85"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/datamining/" title="View all posts filed under Datamining">Datamining</a>

</li>

	<li class="cat-item cat-item-71"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/distributed-file-systems/" title="View all posts filed under Distributed File Systems">Distributed File Systems</a>

</li>

	<li class="cat-item cat-item-67"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/hadoop/" title="View all posts filed under hadoop">hadoop</a>

</li>

	<li class="cat-item cat-item-10"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/linked-data/" title="View all posts filed under Linked Data">Linked Data</a>

</li>

	<li class="cat-item cat-item-92"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/machine-learning/" title="View all posts filed under Machine Learning">Machine Learning</a>

</li>

	<li class="cat-item cat-item-80"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/openpdc/" title="View all posts filed under openPDC">openPDC</a>

</li>

	<li class="cat-item cat-item-66"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/parallel-computing/" title="View all posts filed under Parallel Computing">Parallel Computing</a>

</li>

	<li class="cat-item cat-item-57"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/research/" title="View all posts filed under Research">Research</a>

</li>

	<li class="cat-item cat-item-14"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/self-organization/" title="View all posts filed under Self Organization">Self Organization</a>

</li>

	<li class="cat-item cat-item-79"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/smartgrid/" title="View all posts filed under smartgrid">smartgrid</a>

</li>

	<li class="cat-item cat-item-27"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/the-data-ecology/" title="View all posts filed under The Data Ecology">The Data Ecology</a>

</li>

	<li class="cat-item cat-item-56"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/the-evolution-of-computing/" title="View all posts filed under The Evolution of Computing">The Evolution of Computing</a>

</li>

	<li class="cat-item cat-item-30"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/the-internet-os/" title="View all posts filed under The Internet OS">The Internet OS</a>

</li>

	<li class="cat-item cat-item-16"><a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/category/wireless-mesh-networks/" title="View all posts filed under Wireless Mesh Networks">Wireless Mesh Networks</a>

</li>

</ul></li>

<li><h2>Archives</h2>

	<ul>

			<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2010/11/' title='November 2010'>November 2010</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/10/' title='October 2009'>October 2009</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/07/' title='July 2009'>July 2009</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/04/' title='April 2009'>April 2009</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/01/' title='January 2009'>January 2009</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2008/12/' title='December 2008'>December 2008</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2008/11/' title='November 2008'>November 2008</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2008/09/' title='September 2008'>September 2008</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2008/08/' title='August 2008'>August 2008</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2008/06/' title='June 2008'>June 2008</a></li>

	<li><a href='/web/20101220030539/http://jpatterson.floe.tv/index.php/2008/05/' title='May 2008'>May 2008</a></li>

	</ul>

</li>

</ul>

<div id="footer">

<hr />

    Migrated from <a href="http://web.archive.org/web/20101220030539/http://jpatterson.floe.tv/index.php/2009/10/29/the-smartgrid-goes-open-source/">Wayback Machine</a> Oct 3, 2015 by ajs

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>

<!--

     FILE ARCHIVED ON 3:05:39 Dec 20, 2010 AND RETRIEVED FROM THE

     INTERNET ARCHIVE ON 4:06:05 Oct 4, 2015.

     JAVASCRIPT APPENDED BY WAYBACK MACHINE, COPYRIGHT INTERNET ARCHIVE.

     ALL OTHER CONTENT MAY ALSO BE PROTECTED BY COPYRIGHT (17 U.S.C.

     SECTION 108(a)(3)).

-->


