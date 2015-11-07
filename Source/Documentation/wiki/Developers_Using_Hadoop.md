<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8" />
</head>
<body>
<!--HtmlToGmd.Body-->
<h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>
<hr />
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
<div class="WikiContent">
<div class="wikidoc">
<h1>Processing openPDC data with Hadoop</h1>
<h2>Introduction</h2>
<p>The openPDC is a complete set of applications for processing streaming time-series data in real-time. Measured data is gathered with GPS-time from multiple input sources, time-sorted and provided to user defined actions, then dispersed to custom output destinations
 for archival. Hadoop is an ideal architecture for processing the native binary format of the openPDC.<br>
<br>
Hadoop is a framework for running applications on large clusters built of commodity hardware. Hadoop includes the Hadoop Distributed File System (HDFS) and the Map Reduce programming model. The openPDC project includes the necessary Hadoop components (InputFormat
 and RecordReader) to allow Hadoop to work directly with openPDC data points via Map Reduce. In this document we will describe how to get openPDC data into HDFS and then run sample Map Reduce jobs against this data.
<em>(note: the current Map Reduce code is based on the Hadoop 0.19 API)</em></p>
<hr>
<h2>Getting Started</h2>
<p>The focus of this document is data processing once phasor measurement unit (PMU) data has been collected (i.e., offline analysis of large volumes of archived time-series data). We&rsquo;ll assume that the openPDC has been setup and that the user is ready
 to move data into HDFS and begin running Map Reduce jobs against the PMU data. The user will either need to already have a Hadoop cluster setup or setup a new Hadoop cluster (there are multiple options for this). We&rsquo;ll divide this process into four steps:</p>
<ol>
<li><a href="#locate_data_files">Locate the openPDC data files (PMU data)</a> </li><li><a href="#copy_data_into_hadoop">Copy the data files into Hadoop (more specifically HDFS)</a>
</li><li><a href="#build_mapreduce_job">Build a basic Map Reduce Job</a> </li><li><a href="#execute_job_on_cluster">Execute the Map Reduce Job on the Hadoop cluster</a>
</li></ol>
<p><br>
Also included on this page is an extra appendix designed to aid the user in setting up FTP access for HDFS:</p>
<ul>
<li><a href="#setup_ftp_for_hdfs">Appendix A: Setting up FTP Access for HDFS</a>
</li></ul>
<hr>
<h2><a name="locate_data_files"></a>Locating the openPDC data files (PMU Data)</h2>
<p>The default directory for the openPDC data files in development mode is one of the following (depending on whether you are compiling in Release mode or Debug mode):</p>
<ul>
<li><span class="codeInline">{SOURCEDIR}\Syncrhophasor\Current Version\Build\Output\Release\Applications\openPDC\Archive</span>
</li><li><span class="codeInline">{SOURCEDIR}\Synchrophasor\Current Version\Build\Output\Debug\Applications\openPDC\Archive</span>
</li></ul>
<p><br>
Where {SOURCEDIR} is the directory where you extracted the openPDC source code.<br>
<br>
When the openPDC is installed as a Windows service the default directory for the data files is the directory where you installed the openPDC system, typically:<br>
<br>
<span class="codeInline">C:\Program Files\openPDC\Archive</span><br>
<br>
You can always change the destination of the data files by modifying the configuration file
<em>openPDC.config</em>.<br>
<br>
The default file format uses the &lsquo;.d&rsquo; file extension and has multiple configurable options in terms of file size.</p>
<hr>
<h2><a name="copy_data_into_hadoop"></a>Copy the data files into Hadoop</h2>
<p>Hadoop&rsquo;s distributed file system (HDFS) has multiple ways to copy data into it. They include:</p>
<ul>
<li>Using the included bash scripts (for linux) to copy files into HDFS </li><li>An FTP server that allows basic FTP clients to transfer files into HDFS (see:
<a href="#setup_ftp_for_hdfs">Appendix A</a>) </li><li>FUSE bindings (not currently recommended from windows) </li></ul>
<p><br>
If you are moving files from a win32-based machine, its recommended that you setup the FTP interface (see:
<a href="#setup_ftp_for_hdfs">Appendix A</a>) available at:<br>
<br>
<a href="https://web.archive.org/web/20120422084854/http://www.hadoop.iponweb.net/Home/hdfs-over-ftp">http://www.hadoop.iponweb.net/Home/hdfs-over-ftp</a><br>
<br>
<br>
If you are moving files from a linux based machine, you can simply use the Hadoop bash scripts included. An example command would take the form:<br>
<br>
<span class="codeInline">hadoop fs &ndash;copyFromLocal file://mydir/foo.d hdfs://user/hadoop/dest
</span></p>
<hr>
<h2><a name="build_mapreduce_job"></a>Build a Basic Map Reduce Job</h2>
<p><em>Note: This code assumes you are running the Hadoop 0.19 API</em><br>
<br>
If you are not yet familiar with programming for Hadoop and the Map Reduce programming model, it is suggested that you review the information at:<br>
<br>
<a href="https://web.archive.org/web/20130201075045/http://hadoop.apache.org/docs/r0.20.2/mapred_tutorial.html">http://hadoop.apache.org/common/docs/r0.20.2/mapred_tutorial.html</a><br>
<br>
<br>
Familiarity with Map Reduce in general will provide the necessary context for processing openPDC data with Hadoop. The java code in the openPDC project represents the necessary pieces to allow a Hadoop Map Reduce job to work directly with the openPDC binary
 file format. An included example of how this can be done is in the file:<br>
<br>
<span class="codeInline">TVA.Hadoop.Samples.TestRecordReader.java </span><br>
<br>
This file has a main class &ldquo;TestRecordReader&rdquo; that has two inner classes:</p>
<ul>
<li>TestRecordReader.MapClass </li><li>TestRecordReader.Reduce </li></ul>
<p><br>
The MapClass has a single function called &ldquo;map( &hellip; )&rdquo; defined as:<br>
<br>
<span class="codeInline">public void map(LongWritable key, StandardPointFile value, OutputCollector&lt;IntWritable, StandardPointFile&gt; output, Reporter reporter)
</span><br>
<br>
This function defines the K1, V1 key-value pair that is fed to the map class as well as defines the K2, V2 key-value pair that is output as an intermediate value. These K2, V2 key-value pairs are then grouped by key to be fed to a reduce task.<br>
<br>
From a practical standpoint this means that the example code takes in time series data points (not guaranteed to be in temporal order) and &ldquo;maps&rdquo; each one to a group to be processed by a reducer. Depending on the job function, typically with time
 series data we want to map data points to a logical group such as a range of time.
<br>
<br>
In the TestRecordReader class the time series points (StandardPointFile) are mapped to a group by their point ID (StandardPointFile.iPointID) so that they can be counted in the reducer (we&rsquo;d like to note that this is a very inefficient way to count points,
 but this verbose example is meant to illustrate simple concepts). <br>
<br>
We can alternatively map blocks of time series data into logical groups based on time and allow the reduce phase to do the analysis. A very simple grouping function would be:<br>
<br>
<span class="codeInline">long key = (point_time_stamp_ms / 3600000) * 3600000; </span>
<br>
<br>
where we send each hours worth of data to a separate reducer for analysis. In this case we are rounding timestamps to the nearest hour by dividing and then multiplying by the number of milliseconds in a single hour. This provides a key by which to route the
 point to the reducer responsible for that region of time. The reducer then takes this region of time and executes the appropriate analysis technique, emitting the results (if any) back to HDFS.<br>
<br>
The reduce phase is primarily used in this setup as the &ldquo;analysis phase&rdquo;. The reduce phase is responsible for analyzing its region of time series data and is guaranteed to be able to &ldquo;see&rdquo; all of the data, regardless of the physical
 file location, for a given time region. For simple jobs such as time series window scans, this works very well. Depending on the job, however, the interplay between map and reduce phase responsibilities may change.<br>
<br>
In review, for time series data, we suggest that the user &ldquo;maps&rdquo; the data into a set of logical timeline blocks; This allows multiple reduce tasks to then work on each logical block of time and focus on analysis.</p>
<hr>
<h2><a name="execute_job_on_cluster"></a>Execute the Map Reduce Job on the Hadoop Cluster</h2>
<p>In order to execute a basic Hadoop job, the user needs access to a linux machine that is configured to launch Hadoop jobs. Once you have compiled your Map Reduce job into a jar file, move the jar file to the same directory that contains hadoop-0.X.0-core.jar
 (or other location with access to proper files). With the job jar file in the directory, execute the job with the command:<br>
<br>
<span class="codeInline">bin/hadoop jar {jar_filename} {java_class_name_with_namespace} {data_input_dir} {data_output_dir}
</span></p>
<hr>
<h2><a name="setup_ftp_for_hdfs"></a>Appendix A: Setting up FTP Access for HDFS</h2>
<ol>
<li>Download the <a href="/openPDC/Documentation">hadoopftp</a> package.
</li><li>Copy tar.gz file to server and unzip </li><li>Edit hdfs-over-ftp.conf : (See <a href="#figure_a1">Figure A.1</a> below) </li><li>Add users to the users.conf (Password is in standard md5 hash, must be hashed manually) (See
<a href="#figure_a2">Figure A.2</a> below) </li><li>Then execute the FTP Server by using the startup script &ldquo;./hdfs-over-ftp.sh start&rdquo;
</li></ol>
<p><br>
<a name="figure_a1"></a><em>Figure A.1: editing hdfs-over-ftp.conf</em><br>
<img title="HadoopFTP.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Using_Hadoop.files/HadoopFTP.png" alt="HadoopFTP.png"><br>
<br>
<a name="figure_a2"></a><em>Figure A.2: editing users.conf</em><br>
<img title="HadoopFTPusers.png" src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Using_Hadoop.files/HadoopFTPusers.png" alt="HadoopFTPusers.png"></p>
</div>
</div>
<div id="footer">
<hr />
Last edited <span class="smartDate" title="3/6/2015 9:21:41 PM" LocalTimeTicks="1425705701">Mar 6, 2015 at 9:21 PM</span> by <a id="wikiEditByLink" href="https://github.com/ritchiecarroll">ritchiecarroll</a>, version 4<br />
Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Using%20Hadoop%20%28Developers%29">CodePlex</a> Oct 5, 2015 by <a id="wikiEditByLink" href="https://github.com/ajstadlin">ajs</a>
</div>
<!--HtmlToGmd.Foot-->
<div id="copyright">
<hr />
Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>
</div>
<!--/HtmlToGmd.Foot-->
</body>
</html>
