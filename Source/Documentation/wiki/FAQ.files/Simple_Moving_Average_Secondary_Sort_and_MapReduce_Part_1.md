<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="en-US">

<head>


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


<title>Simple Moving Average, Secondary Sort, and MapReduce (Part 1) | Cloudera Engineering Blog</title>



<meta name="keywords" content="hadoop, hadoop training, cloudera, hadoop tutorial, hadoop certification, apache hadoop, hadoop download, big data, open source" />

<meta name="description" content="" />

<meta http-equiv="content-type" content="text/html; charset=utf-8" />

<meta name="msvalidate.01" content="8857B9071A02F989DE3F8BEE557BB584" />



<link rel="search" type="application/opensearchdescription+xml" href="/assets/opensearch.xml" title="Cloudera" />



<meta property="og:title" content="Simple Moving Average, Secondary Sort, and MapReduce (Part 1)"/>

<meta property="og:type" content="article"/>

<meta property="og:url" content="http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/"/>

<meta property="og:site_name" content="Cloudera Developer Blog"/>





<link rel="icon" href="/wp-content/themes/solutionset/assets/favicon.ico" type="image/x-icon" /> 

<link rel="stylesheet" media="all" type="text/css" href="/wp-content/themes/solutionset/assets/css/960.css?070910" />

<link rel="stylesheet" media="all" type="text/css" href="/wp-content/themes/solutionset/assets/css/reset.css?070910" />

<link rel="stylesheet" media="all" type="text/css" href="/wp-content/themes/solutionset/assets/css/all.css?20120620" />

<link rel="stylesheet" media="all" type="text/css" href="/wp-content/themes/solutionset/assets/css/wp.css?20120620" /> 



<!--[if lt IE 7]><link rel="stylesheet" type="text/css" href="http://blog.cloudera.com/wp-content/themes/solutionset/assets/css/ie6.css?20120605" media="screen"/><![endif]-->

<!--[if lt IE 8]><link rel="stylesheet" type="text/css" href="http://blog.cloudera.com/wp-content/themes/solutionset/assets/css/ie6-7.css?20120605" media="screen"/><![endif]-->

<!--[if lt IE 9]><link rel="stylesheet" type="text/css" href="http://blog.cloudera.com/wp-content/themes/solutionset/assets/css/ie.css?20120605" media="screen"/><![endif]-->



<script type="text/javascript" src="/wp-content/themes/solutionset/assets/js/modernizr-2.6.1.min.js"></script>

<script type="text/javascript" src="/wp-content/themes/solutionset/assets/js/mootools-1.2.4-yui.js"></script>

<script type="text/javascript" src="/wp-content/themes/solutionset/assets/js/mootools-1.2.4.4-more-yui.js"></script>

<script type="text/javascript" src="/wp-content/themes/solutionset/assets/js/jquery-1.6.2.min.js"></script>

<script type="text/javascript"> jQuery.noConflict(); </script>

<script type="text/javascript" src="/wp-content/themes/solutionset/assets/js/jquery.colorbox-min.js"></script>

<script type="text/javascript" src="/wp-content/themes/solutionset/assets/js/global.js?20120605"></script>

<script type="text/javascript">var switchTo5x=true;</script>

<script type="text/javascript" src="http://w.sharethis.com/button/buttons.js"></script>

<script type="text/javascript">stLight.options({publisher: "ur-aa86c136-1042-b30d-950-dd905bb179a0", doNotHash: true, doNotCopy: true, hashAddressBar: false});</script>





<link rel="pingback" href="http://blog.cloudera.com/xmlrpc.php" />

<link rel="alternate" type="application/rss+xml" title="Cloudera Engineering Blog &raquo; Feed" href="http://blog.cloudera.com/feed/" />
<link rel="alternate" type="application/rss+xml" title="Cloudera Engineering Blog &raquo; Comments Feed" href="http://blog.cloudera.com/comments/feed/" />
<link rel="alternate" type="application/rss+xml" title="Cloudera Engineering Blog &raquo; Simple Moving Average, Secondary Sort, and MapReduce (Part 1) Comments Feed" href="http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/feed/" />
<link rel='stylesheet' id='crayon-css'  href='http://blog.cloudera.com/wp-content/plugins/crayon-syntax-highlighter/css/min/crayon.min.css?ver=2.6.6' type='text/css' media='all' />
<link rel='stylesheet' id='cptchStylesheet-css'  href='http://blog.cloudera.com/wp-content/plugins/captcha/css/style_wp_before_3.8.css?ver=3.3.2' type='text/css' media='all' />
<script type='text/javascript' src='http://blog.cloudera.com/wp-includes/js/jquery/jquery.js?ver=1.7.1'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var CrayonSyntaxSettings = {"version":"2.6.6","is_admin":"0","ajaxurl":"https:\/\/blog.cloudera.com\/wp-admin\/admin-ajax.php","prefix":"crayon-","setting":"crayon-setting","selected":"crayon-setting-selected","changed":"crayon-setting-changed","special":"crayon-setting-special","orig_value":"data-orig-value","debug":""};;
var CrayonSyntaxStrings = {"copy":"Press %s to Copy, %s to Paste","minimize":"Click To Expand Code"};
/* ]]> */
</script>
<script type='text/javascript' src='http://blog.cloudera.com/wp-content/plugins/crayon-syntax-highlighter/js/min/crayon.min.js?ver=2.6.6'></script>
<link rel="EditURI" type="application/rsd+xml" title="RSD" href="http://blog.cloudera.com/xmlrpc.php?rsd" />
<link rel="wlwmanifest" type="application/wlwmanifest+xml" href="http://blog.cloudera.com/wp-includes/wlwmanifest.xml" /> 
<link rel='prev' title='Avoiding Full GCs in Apache HBase with MemStore-Local Allocation Buffers: Part 3' href='http://blog.cloudera.com/blog/2011/03/avoiding-full-gcs-in-hbase-with-memstore-local-allocation-buffers-part-3/' />
<link rel='next' title='Simple Moving Average, Secondary Sort, and MapReduce (Part 2)' href='http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2/' />
<meta name="generator" content="WordPress 3.3.2" />
<link rel='canonical' href='http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/' />
<link rel='shortlink' href='http://blog.cloudera.com/?p=6955' />




<script type="text/javascript">

 var _gaq = _gaq || [];

 _gaq.push(['_setAccount', 'UA-2275969-16']);

 _gaq.push(['_trackPageview']);



 (function() {

   var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;

   ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';

   var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);

 })();

</script>





<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body class="single single-post postid-6955 single-format-standard devcenter">

			

		

			

	<header id="site-head">
<nav class="properties">
            <div class="container">
                <ul>
                    <!--<li><a href="http://www.cloudera.com">Cloudera.com</a></li>-->
                     <!--<li><a href="http://university.cloudera.com">Cloudera University</a></li>
                   <li><a href="${config.LINK_CCP}/display/DOC/Documentation">Documentation</a></li>-->
                    <li><a id="support_home_page" href="http://cloudera.com/content/support/en/home.html" class="active">Support</a></li>
                    <li><a href="http://cloudera.com/content/dev-center/en/home.html">Developers</a></li>
                  <!--<li><a href="http://cloudera.com/content/cloudera/en/partners.html">PARTNERS</a></li>-->
                   
                </ul>
                <ul class="user">
                    <li>
                       <!--<a id="signinLink" class="hidden" href="https://clouderapkb.echolane.cs3.force.com/idp/login?app=0spQ00000004CD5">Sign In</a>-->
<a id="signinLink" class="hidden" href="https://cloudera.secure.force.com">Sign In</a>
                    </li>
                    <li><a id="registerLink" class="hidden" href="http://cloudera.com/content/support/en/user-registration.html">Register</a></li>
                    <li><a href="http://cloudera.com/content/cloudera/en/about/contact-us.html">Contact Us</a></li>
                    <li><a href="http://cloudera.com/content/support/en/downloads.html">Downloads</a></li>
                    <li>
                        <div id="dropdownAction" class="dropdown" style="display:none">
                            <a id="lnkDropdowntoogle" data-toggle="dropdown" class="dropdown-toggle" href="#">

                            </a>
                            <ul aria-labelledby="dropdownMenu" tole="menu" class="dropdown-menu">
                                <li><a href="http://cloudera.com/content/support/en/edit-user-profile.html" id="editProfileLink" tabindex="-1">Edit Profile</a></li>
                                <li class="divider"></li>
                                <li>
                                <a id="logoutLink" tabindex="-1" href="#">Logout</a>
                                </script>
                                </li>
                            </ul>
</div>
                    </li>
                </ul>
</div>
            <div class="bg-fix"></div>
        </nav>
<!--</div>-->

<div class="wrapper">
    <div class="bg-fix"></div>
    <h1 class="logo">
        <a href="http://cloudera.com/content/cloudera/en/home.html">Cloudera</a>
    </h1>

<nav class="site">
        <ul>
    <li class="">
 <a href="http://community.cloudera.com" data-link="external">Community</a>
</li>
<li class="">
 <a href="http://cloudera.com/content/support/en/documentation.html" data-link="external">Documentation</a>
</li>
 <li class="">
                    <a href="http://cloudera.com/content/support/en/downloads.html" data-link="external">Downloads</a>
   </li>
     <li class="">
                    <a href="http://university.cloudera.com" data-link="external">Training</a>
     </li>
<li class="">
                    <a href="http://blog.cloudera.com" data-link="external" class="active">Blogs</a>
                    <nav class="subnav menu"> <nav><ul>
<li><a href="http://vision.cloudera.com">Cloudera Vision</a></li>
<!--<li><a href="http://blog.cloudera.com/blog">Developer Blog</a></li>-->
</ul>
</nav> </nav>
</li>
            
        </ul>
    </nav>


    <div class="form-holder">
		
	    <form action="http://cloudera.com/content/cloudera/en/search.html" id="site-search" method="get" novalidate> 
	        <label for="q" class="visuallyhidden">Search</label> 
	        <input type="search" name="q" id="q" placeholder="Search"><i class="icon-search"></i> 
	    </form>
</div>
</div><!--</div>-->
        </header>
				

	<div role="main" class="main">

		<div class="wrapper">

			<section class="two-col">



	

<aside class="left-col">

				<nav>
			<ul class=" ">
			
								
							<li class="">
				<a
					href="http://www.cloudera.com/content/cloudera/en/why-cloudera/hadoop-and-big-data.html"
					title="Hadoop &amp; Big Data"
					class=""
					target="_blank"				>
					Hadoop &amp; Big Data				</a>

							</li>
			
					<li class="">
				<a
					href="http://www.cloudera.com/content/cloudera/en/why-cloudera/our-customers.html"
					title="Our Customers"
					class=""
					target="_blank"				>
					Our Customers				</a>

							</li>
			
					<li class="">
				<a
					href="http://www.cloudera.com/content/cloudera/en/why-cloudera/faqs.html"
					title="FAQs"
					class=""
					target="_blank"				>
					FAQs				</a>

							</li>
			
					<li class="current">
				<a
					href="/blog/"
					title="Blog"
					class="blog"
									>
					Blog				</a>

									<ul>
									<li class="">
				<a
					href="/blog/category/accumulo/"
					title="Accumulo (1)"
					class=""
									>
					Accumulo (1)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/avro/"
					title="Avro (17)"
					class=""
									>
					Avro (17)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/bigtop/"
					title="Bigtop (6)"
					class=""
									>
					Bigtop (6)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/books/"
					title="Books (12)"
					class=""
									>
					Books (12)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/careers/"
					title="Careers (15)"
					class=""
									>
					Careers (15)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/cdh/"
					title="CDH (157)"
					class=""
									>
					CDH (157)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/cloud-2/"
					title="Cloud (25)"
					class=""
									>
					Cloud (25)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/cloudera-labs/"
					title="Cloudera Labs (10)"
					class=""
									>
					Cloudera Labs (10)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/cloudera-life/"
					title="Cloudera Life (7)"
					class=""
									>
					Cloudera Life (7)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/cloudera-manager/"
					title="Cloudera Manager (77)"
					class=""
									>
					Cloudera Manager (77)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/community/"
					title="Community (221)"
					class=""
									>
					Community (221)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/data-ingestion/"
					title="Data Ingestion (22)"
					class=""
									>
					Data Ingestion (22)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/data-science/"
					title="Data Science (37)"
					class=""
									>
					Data Science (37)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/events/"
					title="Events (55)"
					class=""
									>
					Events (55)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/flume/"
					title="Flume (25)"
					class=""
									>
					Flume (25)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/general/"
					title="General (339)"
					class=""
									>
					General (339)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/graph-processing/"
					title="Graph Processing (3)"
					class=""
									>
					Graph Processing (3)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/guest/"
					title="Guest (114)"
					class=""
									>
					Guest (114)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/hadoop/"
					title="Hadoop (344)"
					class=""
									>
					Hadoop (344)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/hardware/"
					title="Hardware (6)"
					class=""
									>
					Hardware (6)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/hbase/"
					title="HBase (151)"
					class=""
									>
					HBase (151)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/hdfs/"
					title="HDFS (55)"
					class=""
									>
					HDFS (55)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/hive/"
					title="Hive (74)"
					class=""
									>
					Hive (74)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/how-to/"
					title="How-to (92)"
					class=""
									>
					How-to (92)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/hue/"
					title="Hue (35)"
					class=""
									>
					Hue (35)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/impala/"
					title="Impala (94)"
					class=""
									>
					Impala (94)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/kafka/"
					title="Kafka (12)"
					class=""
									>
					Kafka (12)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/kite-sdk/"
					title="Kite SDK (17)"
					class=""
									>
					Kite SDK (17)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/mahout-2/"
					title="Mahout (5)"
					class=""
									>
					Mahout (5)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/mapreduce/"
					title="MapReduce (75)"
					class=""
									>
					MapReduce (75)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/meet-the-engineer/"
					title="Meet The Engineer (23)"
					class=""
									>
					Meet The Engineer (23)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/metadata-and-lineage/"
					title="Metadata And Lineage (1)"
					class=""
									>
					Metadata And Lineage (1)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/oozie/"
					title="Oozie (26)"
					class=""
									>
					Oozie (26)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/ops/"
					title="Ops And DevOps (24)"
					class=""
									>
					Ops And DevOps (24)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/parquet-2/"
					title="Parquet (15)"
					class=""
									>
					Parquet (15)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/performance/"
					title="Performance (16)"
					class=""
									>
					Performance (16)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/pig/"
					title="Pig (37)"
					class=""
									>
					Pig (37)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/project-rhino/"
					title="Project Rhino (5)"
					class=""
									>
					Project Rhino (5)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/quickstart-vm/"
					title="QuickStart VM (6)"
					class=""
									>
					QuickStart VM (6)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/search/"
					title="Search (26)"
					class=""
									>
					Search (26)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/security-2/"
					title="Security (35)"
					class=""
									>
					Security (35)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/sentry/"
					title="Sentry (3)"
					class=""
									>
					Sentry (3)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/spark/"
					title="Spark (54)"
					class=""
									>
					Spark (54)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/sqoop/"
					title="Sqoop (24)"
					class=""
									>
					Sqoop (24)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/support/"
					title="Support (5)"
					class=""
									>
					Support (5)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/testing/"
					title="Testing (9)"
					class=""
									>
					Testing (9)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/tools/"
					title="Tools (9)"
					class=""
									>
					Tools (9)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/training-2/"
					title="Training (46)"
					class=""
									>
					Training (46)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/use-case/"
					title="Use Case (72)"
					class=""
									>
					Use Case (72)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/yarn/"
					title="YARN (17)"
					class=""
									>
					YARN (17)				</a>

							</li>
			
					<li class="">
				<a
					href="/blog/category/zookeeper/"
					title="ZooKeeper (24)"
					class=""
									>
					ZooKeeper (24)				</a>

							</li>
			
					<li class="">
				<a
					href="/archive/"
					title="Archives by Month"
					class=""
									>
					Archives by Month				</a>

							</li>
			
							</ul>
							</li>
			
						
			    
			
				<div style="clear:both"></div>
			</ul>
			</nav>
			<div class="menu-special">
				<ul>
							
				
				
		
				
		
				
				
				
				

		
					</ul>
</div>
			
</aside>



<section>

			<h1 class="heading ">Simple Moving Average, Secondary Sort, and MapReduce (Part 1)</h1>

			

			<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>

			

			<ul class="post-info">

				<li>by <a href="http://blog.cloudera.com/blog/author/josh-patterson/" title="Posts by Josh Patterson" rel="author">Josh Patterson</a></li>

				<li>March 14, 2011</li>

				<li class="comment"><a href="#comments">3 comments</a></li>

				

			</ul>

			

			<div class="text-block">

				<h2>Intro</h2>
<p>In this three part blog series I want to take a look at how we would do a Simple Moving Average with MapReduce and Apache Hadoop. This series is meant to show how to translate a common Excel or R function into MapReduce java code with accompanying working code and data to play with. Most analysts can take a few months of stock data and produce an excel spreadsheet that shows a moving average, but doing this in Hadoop might be a more daunting task. Although time series as a topic is relatively well understood, I wanted to take the approach of using a simple topic to show how it translated into a powerful parallel application that can calculate the simple moving average for a lot of stocks simultaneously with MapReduce and Hadoop. I also want to demonstrate the underlying mechanic of using the &#8220;secondary sort&#8221; technique with Hadoop&#8217;s MapReduce shuffle phase, which we&#8217;ll see is applicable to a lot of different application domains such as finance, sensor, and genomic data.</p>
<p>This article should be approachable to the beginner Hadoop programmer who has done a little bit of MapReduce in java and is looking for a slightly more challenging MapReduce application to hack on.  In case you&#8217;re not very familiar with Hadoop, <a title="CDH" href="https://wiki.cloudera.com/display/DOC/Cloudera+Documentation+Home+Page">here&#8217;s some background information and CDH</a>. The code in this example is hosted on github and is documented to illustrate how the various components work together to achieve the secondary sort effect. One of the goals of this article is to have this code be relatively basic and approachable by most programmers.</p>
<p>So let&#8217;s take a quick look at what time series data is and where it is employed in the quickly emerging world of large-scale data.</p>
<p><br class="spacer_" /></p>
<h2>What is Time Series Data?</h2>
<p><a title="Wikipedia - Time series" href="http://en.wikipedia.org/wiki/Time_series"> Time series</a> data is defined as a sequence of data points measured typically at successive times spaced at uniform time intervals. Time series data is typically seen in statistics, signal processing, and finance along with other fields. Examples of time series data are the daily adjusted close price of a stock at the NYSE or sensor readings on a power grid occuring 30 times a second.</p>
<p>Time series as a general class of problems has typically resided in the scientific and financial domains.  However, due to the ongoing explosion of available data, time series data is becoming more prevalent across a wider swath of industries. Time Series sensors are being ubiquitously integrated in places like:</p>
<div style="margin-left:20px">
<ul >
<li>The <a title="openPDC" href="http://openpdc.codeplex.com/">power grid</a>, aka &#8220;the <a title="The Smart Grid: Hadoop at the Tennessee Valley Authority (TVA)" href="http://blog.cloudera.com/blog/2009/06/smart-grid-hadoop-tennessee-valley-authority-tva/">smart grid</a>&#8221;</li>
<li>Cellular Services</li>
<li>As well as, military and environmental uses (ex: <a title="TinyOS Homepage" href="http://www.tinyos.net/">tinyOS</a>)</li>
</ul>
</div>
<p>It&#8217;s also been shown that <a title="Keogh SAX Presentation " href="http://www.youtube.com/watch?v=yzI0Fj_nvPM">shapes in images can be decomposed into time series data</a> which allows the shapes to achieve rotation and scale invariance allowing for easier comparison. Another sector showing explosive growth in the amount of time series data produced is the <a title="Full Genome Sequencing" href="http://en.wikipedia.org/wiki/Full_genome_sequencing">genomic and bioinformatic</a> realm. We&#8217;re seeing the <a title="Costs of DNA Sequencing Falling Fast " href="http://singularityhub.com/2011/03/05/costs-of-dna-sequencing-falling-fast-look-at-these-graphs/">cost to sequence the human genome continue to decrease rapidly</a>, shifting pressure to the storage and processing technologies for these genomes.  Genome data in its text representation (GATC) can be represented as time series and thus these problems are approachable by all <a title="iSAX Paper" href="http://www.cs.ucr.edu/~eamonn/iSAX.pdf">techniques relevant to time series processing</a>. Time series processing underlies some techniques used in the genomics domain such as &#8220;<a title="Motif Finding" href="http://alfa.di.uminho.pt/~castro/mrmotif/MrMotif-CastroAzevedo.pdf">motif finding</a>&#8221; which can be approached in the same way as the &#8220;<a title="Median String" href="http://www.cs.ucr.edu/~stelo/cpm/cpm03/Nicolas.pdf">median string</a>&#8221; problem. The understanding of how we can refactor traditional approaches to these time series problems when inputting into MapReduce can potentially allow us to improve processing and analysis techniques in a timely fashion.</p>
<p>The financial industry has long been interested in time series data and have employed programming languages such as R to help deal with this problem. The R programming language was created specifically for this class of data&#8211;as shown in the R example below. So, why would a sector create a programming language specifically for one class of data when technologies like RDBMS have existed for decades? In reality, current RDBMs technology has limitations when dealing with high-resolution time series data. These limiting factors include:</p>
<div style="margin-left:20px">
<ul>
<li>High-frequency time series data coming from a variety of sources can create huge amounts of data in very little time</li>
<li>RDBMS&#8217;s tend to not like storing and indexing billions of rows.</li>
<li>Non-distributed RDBMS&#8217;s tend to not like scaling up into the hundreds of GB&#8217;s, let alone TB&#8217;s or PB&#8217;s.</li>
<li>RDBMS&#8217;s that can scale into those arenas tend to be very expensive, or require large amounts of specialized hardware</li>
</ul>
</div>
<p>Problems with RDBMS&#8217;s queries on high resolution time series data:</p>
<div style="margin-left:20px">
<ul>
<li>To process high resolution time series data with a RDBMS we&#8217;d need to use an analytic aggregate function in tandem with moving window predicates (ex: the &#8220;OVER&#8221; clause)  which results in rapidly increasing amounts of work to do as the granularity of time series data gets finer.</li>
<li>Query results are not perfectly commutable and cannot do variable step sliding windows (ex: step 5 seconds per window move) without significant unnecessary intermediate work or non-standard SQL functions.</li>
<li>Queries on RDBMS for time series for certain techniques can be awkward and tend to require premature 	subdividing of the data and costly reconstruction during processing (example: Data mining, iSAX decompositions)</li>
<li>Due to the above factors, with large amounts of time series data RDBMS performance 	degrades while scaling.</li>
</ul>
</div>
<p>Most simple time series calculations are performed with everyone&#8217;s favorite analysis tool: the spreadsheet. However, when we need to look at data that is beyond the 65k row limit of Excel how does our approach evolve as we scale our data up? In this article we&#8217;ll stop to take a look at the issues involved when scaling data before we jump into MapReduce and how Hadoop approaches things. Let&#8217;s start with a simple moving average on a small sample of data in Excel. We&#8217;ll progress onto the same example in R and then we&#8217;ll work our way toward a full blown MapReduce application in java (code included). Once we have our sample data working well with MapReduce, we&#8217;ll calculate the simple moving average of all stocks on the NYSE from 1970 to the present in one pass without changing any code.</p>
<h2>Simple Moving Average</h2>
<p>A simple <a title="Wikipedia - Moving Average" href="http://en.wikipedia.org/wiki/Moving_average">moving average</a> is the series of unweighted averages in a subset of time series data points as a sliding window progresses over the time series data set. Each time the window is moved we recalculate the average of the points in the window. This produces a set of numbers representing the final moving average. Typically the moving average technique is used with time series to highlight longer term trends or smooth out short-term noise. Moving averages are similar to low pass filters in signal processing, and mathematically are considered a type of convolution.</p>
<p>In other terms, we take a window and fill it in a First In First Out (FIFO) manner with time series data points until we have N points in it. We then take the average of these points and add this to our answer list. We slide our window forward by M data points and again take the average of the data points in the window. This process is repeated until the window can no longer be filled at which point the calculation is complete. Now that we have a general idea of what we are looking at, let&#8217;s take a look at a few ways to do a simple moving average.</p>
<h2>Coming Up</h2>
<p>In parts 2 and 3 of this blog series we&#8217;ll take the reader from simple moving average in Excel, through R, and then into a real example with code of simple moving average in MapReduce.</p>


				<div class="social-buttons">

<span class='st_facebook_large' displayText='Facebook'></span>

<span class='st_twitter_large' displayText='Tweet'></span>

<span class='st_linkedin_large' displayText='LinkedIn'></span>

<span class='st_googleplus_large' displayText='Google +'></span>

<span class='st_email_large' displayText='Email'></span>

</div>

</div>



			<div class="grid_2" style="margin:0">

  <div class="comments comments-2">

    <div class="field-under">

      <h4>Filed under:</h4>

      <ul class="post-categories">
	<li><a href="http://blog.cloudera.com/blog/category/general/" title="View all posts in General" rel="category tag">General</a></li>
	<li><a href="http://blog.cloudera.com/blog/category/hadoop/" title="View all posts in Hadoop" rel="category tag">Hadoop</a></li>
	<li><a href="http://blog.cloudera.com/blog/category/mapreduce/" title="View all posts in MapReduce" rel="category tag">MapReduce</a></li></ul>  	</div>

  	

  <a name="comments"></a>

  <div class="comments-head">

    <strong>3 Responses</strong>

   

</div>

  <ul class="comments-list">

  	<li>
		<em class="comment-date">
			<a rel="nofollow" href="">Evan Sparks</a> /
			March 14, 2011 / 8:12 AM		</em>
<p>Have to nitpick a little here &#8211; R was NOT created specifically to handle time-series data in the financial services industry. It is the open source implementation of the &#8220;S&#8221; programming language, which was created as a general purpose statistical programming language. Personally, I find R&#8217;s handling of time series data fairly weak compared to other analytic systems I&#8217;ve used. (Don&#8217;t get me wrong, I&#8217;m a big-time R fan and user.)</p>
<p>Second &#8211; after years of working with and studying this stuff, my belief is that fundamentally RDBMS&#8217;s are crippled when it comes to looking at time-series data because they rely on set theory. Sets are naturally unordered, while time dimensions have a very clear natural order. The unordered nature of sets makes the math work out nicely in favor of RDBMS for transactional processing, but less so for analytical processing. </p>
<p>All that said, I&#8217;m really looking forward to seeing time-series analysis in Hadoop!</p>
	</li>
</li>
	<li>
		<em class="comment-date">
			<a rel="nofollow" href="">Jay</a> /
			December 03, 2011 / 11:07 AM		</em>
<p>Evan<br />
When you state that you find other analytics more powerful than R for time series, can you share which ones.  It would be good to compare notes.<br />
Jay</p>
	</li>
</li>
	<li>
		<em class="comment-date">
			<a rel="nofollow" href="">Markus Brechbühler</a> /
			March 05, 2013 / 12:54 AM		</em>
<p>Do you mind adding the links to part 2 and 3? I saw an example where the mapper gathered all the data and during the reduce phase the values were calculated.</p>
<p>If you have a simple moving average (SMA) this is a good solution. It starts to suffer if you implement a backtesting on a GARCH (1, 1) over 3000++ datapoints.</p>
<p>Regards,<br />
Markus</p>
	</li>
</li>
  </ul>

  <a name="leave-comment"></a>

  <form action="/wp-comments-post.php" method="POST">

  	<div class="comment-form">

  		<h4>Leave a comment</h4>

  		<div class="row">

  			<input type="text" value="" class="txt" name="author"/>

  			<label>Name <span>required</span></label>

</div>

  		<div class="row">

  			<input type="text" value="" class="txt" name="email"/>

  			<label class="published">Email <span>required</span> <em>(will not be published)</em></label>

</div>

  		<div class="row">

  			<input type="text" value="" class="txt" name="url"/>

  			<label>Website</label>

</div>

  		<div class="row">

  			<textarea rows="10" cols="30" class="area" name="comment"></textarea>

  			<label>Comment</label>

</div>

  		<fieldset>

  			<input type="button" value="Leave Comment" class="btn cta"/>

  		</fieldset>

</div>

  	<input type='hidden' name='comment_post_ID' value='6955' id='comment_post_ID' />
<input type='hidden' name='comment_parent' id='comment_parent' value='0' />
  	<p class="cptch_block"><label>Prove you're human!<span class="required"> *</span></label><br />		<input type="hidden" name="cptch_result" value="+PeX" />
		<input type="hidden" name="cptch_time" value="1443848670" />
		<input type="hidden" value="Version: 2.4" />
		&#102;&#111;ur &times; 7 =  <input id="cptch_input" type="text" autocomplete="off" name="cptch_number" value="" maxlength="2" size="2" aria-required="true" required="required" style="margin-bottom:0;display:inline;font-size: 12px;width: 40px;" />	</p>  </form>

</div></section>









<!-- Google Code for New Remarketing Pixel -->

<!-- Remarketing tags may not be associated with personally identifiable information or placed on pages related to sensitive categories. For instructions on adding this tag and more information on the above requirements, read the setup guide: google.com/ads/remarketingsetup -->

<script type="text/javascript">

/* <![CDATA[ */

var google_conversion_id = 1035979479;

var google_conversion_label = "xel9CJ-P0QMQ15X_7QM";

var google_custom_params = window.google_tag_params;

var google_remarketing_only = true;

/* ]]> */

</script>

<script type="text/javascript" src="//www.googleadservices.com/pagead/conversion.js">

</script>



<noscript>

<div style="display:inline;"> <img height="1" width="1" style="border-style:none;" alt="" src="//googleads.g.doubleclick.net/pagead/viewthroughconversion/1035979479/?value=0&label=xel9CJ-P0QMQ15X_7QM&guid=ON&script=0"/> </div>

</noscript>

</section>

<span class="bg-fix"></span>

</div>

</div>

<footer id="global-footer">

<div class="footerContent parbase">

<footer>

  <div class="wrapper">

    <div class="bg-fix"></div>

    <nav>

      <ul>

        <li class="section"><a href="http://www.cloudera.com/content/cloudera/en/products-and-services.html">Products</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/products/cloudera-enterprise.html">Cloudera Enterprise</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/products-and-services/cloudera-express.html">Cloudera Express</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/products-and-services/cloudera-enterprise/cloudera-manager.html">Cloudera Manager</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/products-and-services/cdh.html">CDH</a></li>

        <li><a href="http://www.cloudera.com/content/support/en/downloads.html">All Downloads</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/products-and-services/professional-services.html">Professional Services</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/training.html">Training</a></li>

      </ul>

      <ul>

        <li class="section"><a href="http://www.cloudera.com/content/cloudera/en/solutions.html">Solutions</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/solutions/enterprise-solutions.html">Enterprise Solutions</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/solutions/partner.html">Partner Solutions</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/solutions/industries.html">Industry Solutions</a></li>

      </ul>

      <ul>

        <li class="section"><a href="http://www.cloudera.com/content/cloudera/en/partners.html">Partners</a></li>

        <li class="section"><a href="http://www.cloudera.com/content/cloudera/en/resources/library.html">Resource Library</a></li>

        <li class="section"><a href="https://ccp.cloudera.com/display/SUPPORT/Get+Support">Support</a></li>

      </ul>

      <ul>

        <li class="section"><a href="http://www.cloudera.com/content/cloudera/en/about.html">About</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/about/hadoop-and-big-data.html">Hadoop &amp; Big Data</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/about/management.html">Management Team</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/about/board.html">Board</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/about/events.html">Events</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/about/press-center.html">Press Center</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/about/careers.html">Careers</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/about/contact-form.html">Contact Us</a></li>

        <li><a href="http://www.cloudera.com/content/cloudera/en/subscription-center.html">Subscription Center</a></li>

      </ul>

      <div class="locale-and-social" style="float:right">

<div>

          <div class="locale-and-social">

            <div class="locale">

              <select onchange="this.options[this.selectedIndex].value &amp;&amp; (window.location = this.options[this.selectedIndex].value);" class="site-language">

                <option value="http://www.cloudera.com" name="English">English</option>

                <option value="http://www.cloudera.co.jp/">Japanese</option>

              </select>

</div>

            <div class="social"><span class="follow">Follow us:</span><span class="share">Share:<i class="icon-share"></i></span>

              <ul>

                <li><a class="linkedIn" target="_blank" href="http://www.linkedin.com/company/cloudera">LinkedIn</a></li>

                <li><a class="twitter" target="_blank" href="http://twitter.com/cloudera">Twitter</a></li>

                <li><a class="facebook" target="_blank" href="http://www.facebook.com/cloudera">Facebook</a></li>

                <li><a class="youtube" target="_blank" href="http://www.youtube.com/user/clouderahadoop">YouTube</a></li>

              </ul>

</div>

</div>

</div>

</div>

    </nav>

    <nav class="global-footer"><span class="logo"><a>Cloudera</a></span>

      <address>

      <span>Cloudera, Inc.</span> <span><a target="_blank" href="http://www.google.com/maps?q=1001+Page+Mill+Rd,+Palo+Alto,+CA+94306">1001 Page Mill Road Bldg 2</a></span> <span>Palo Alto, CA 94304</span>

      </address>

      <address>

      <span><a href="http://www.cloudera.com">www.cloudera.com</a></span> <span>US: 1-888-789-1488</span> <span>Intl: 1-650-362-0488</span>

      </address>

      <div class="copyright"><span><span class="piped">©2014 Cloudera, Inc. All rights reserved</span><span class="piped"><a href="http://www.cloudera.com/content/cloudera/en/terms-of-service.html">Terms &amp; Conditions</a></span><a href="http://www.cloudera.com/content/cloudera/en/privacy-policy.html">Privacy Policy</a></span> <span>Hadoop and the Hadoop elephant logo are trademarks of the <a target="_blank" href="http://www.apache.org/">Apache Software Foundation</a>.</span></div>

    </nav>

</div>

</footer>

<div class="modal" style="display:none">

  <div id="password-required">

    <div class="inner"> </div>

</div>

</div>

<div class="tooltip" class="tooltip" style="display:none">

</div>

<script type="text/javascript" src="http://dnn506yrbagrg.cloudfront.net/pages/scripts/0011/2160.js"></script>

<script type="text/javascript">var _kiq = _kiq || [];</script> 

<script type="text/javascript" src="http://s3.amazonaws.com/ki.js/14646/2Sr.js" async></script>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body></html>
