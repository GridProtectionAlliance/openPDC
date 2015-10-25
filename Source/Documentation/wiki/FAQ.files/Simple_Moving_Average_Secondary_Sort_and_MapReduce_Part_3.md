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


<title>Simple Moving Average, Secondary Sort, and MapReduce (Part 3) | Cloudera Engineering Blog</title>



<meta name="keywords" content="hadoop, hadoop training, cloudera, hadoop tutorial, hadoop certification, apache hadoop, hadoop download, big data, open source" />

<meta name="description" content="" />

<meta http-equiv="content-type" content="text/html; charset=utf-8" />

<meta name="msvalidate.01" content="8857B9071A02F989DE3F8BEE557BB584" />



<link rel="search" type="application/opensearchdescription+xml" href="/assets/opensearch.xml" title="Cloudera" />



<meta property="og:title" content="Simple Moving Average, Secondary Sort, and MapReduce (Part 3)"/>

<meta property="og:type" content="article"/>

<meta property="og:url" content="http://blog.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3/"/>

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

<link rel="alternate" type="application/rss+xml" title="Cloudera Engineering Blog &raquo; Simple Moving Average, Secondary Sort, and MapReduce (Part 3) Comments Feed" href="http://blog.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3/feed/" />

<link rel='stylesheet' id='crayon-css'  href='http://blog.cloudera.com/wp-content/plugins/crayon-syntax-highlighter/css/min/crayon.min.css?ver=2.6.6' type='text/css' media='all' />

<link rel='stylesheet' id='crayon-theme-classic-css'  href='http://blog.cloudera.com/wp-content/plugins/crayon-syntax-highlighter/themes/classic/classic.css?ver=2.6.6' type='text/css' media='all' />

<link rel='stylesheet' id='crayon-font-monaco-css'  href='http://blog.cloudera.com/wp-content/plugins/crayon-syntax-highlighter/fonts/monaco.css?ver=2.6.6' type='text/css' media='all' />

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

<link rel='prev' title='Adopting Apache Hadoop in the Federal Government' href='http://blog.cloudera.com/blog/2011/04/adopting-apache-hadoop-in-the-federal-government/' />

<link rel='next' title='CDH3 goes GA' href='http://blog.cloudera.com/blog/2011/04/cdh3-goes-ga/' />

<meta name="generator" content="WordPress 3.3.2" />

<link rel='canonical' href='http://blog.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3/' />

<link rel='shortlink' href='http://blog.cloudera.com/?p=7115' />





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

<body class="single single-post postid-7115 single-format-standard devcenter">

			

		

			

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

			<h1 class="heading ">Simple Moving Average, Secondary Sort, and MapReduce (Part 3)</h1>

			

			<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>

			

			<ul class="post-info">

				<li>by <a href="http://blog.cloudera.com/blog/author/josh-patterson/" title="Posts by Josh Patterson" rel="author">Josh Patterson</a></li>

				<li>April 11, 2011</li>

				<li class="comment"><a href="#comments">5 comments</a></li>

				

			</ul>

			

			<div class="text-block">

<p><em>This is the final piece to a three part blog series. If you would like to view the previous parts to this series please use the following link:</em></p>

<p><em><a title="A Simple Moving Average in Excel - part 1" href="http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/">Part 1 &#8211; A Simple Moving Average in Excel</a></em></p>

<p><em><a title="A Simple Moving Average in R - part 2" href="http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2/">Part 2 – A Simple Moving Average in R</a></em></p>

<p>Previously I explained how to use Excel and R as the analysis tools to calculate the Simple Moving Average of a small set of stock closing prices. In this final piece to the three part blog series, I will delve into using MapReduce to find the Simple Moving Average of our small sample data set. Then, I will show you how using the same code, you will be able to calculate the Simple Moving Average of every closing stock price since 1980.</p>

<h2>Down the Rabbit Hole With Hadoop</h2>

<p>In the above examples we took a look at calculating the simple moving average of a relatively small amount of data. For a lot of analysis, excel and R are very effective tools, but as we scale towards gigabyte, terabyte, and petabyte data stores we run into some issues with data locality, disk speeds, and processing speeds.</p>

<p>To illustrate these factors let’s take a mythical machine that had a single 1 petabyte disk, which operated similarly to disk speeds today. For the purposes of this example we’ll use a read speed of 40 MB/s. Let’s say that it’s our job to scan through this data and produce a simple moving average, the processor does not impede the calculation, and we can sustain a moving window calculation through the data at the full 40 MB/s. Let’s also assume that the data was previously sorted and that we only had to perform a sequential scan; this maximizes the data throughput rate from the disk and it could consistently deliver 40MB/s to the processing pipeline. Based on Jeff Dean’s “<a href="http://www.cs.cornell.edu/projects/ladis2009/talks/dean-keynote-ladis2009.pdf">12</a> <a href="http://www.cs.cornell.edu/projects/ladis2009/talks/dean-keynote-ladis2009.pdf">Numbers Every Engineer Should Know</a>” <a href="http://www.cs.cornell.edu/projects/ladis2009/talks/dean-keynote-ladis2009.pdf">slide</a> this is a plausible setup. At this throughput our simple moving average calculation of 1 petabyte of data would take around <em>310 days to complete</em>. For most situations this operational cost, in terms of time, makes it unreasonable to consider. Fortunately, the mechanics of HDFS and MapReduce mitigate these factors such that we can make this problem a linear time and capital function to help us decide the number of machines we want to implement to efficiently undertake this simple moving average scan.</p>

<p>In the above simple moving average example we neglected to consider the constraints of:</p>

<div style="margin-left: 20px;">

<ul>

<li>Storing the petabyte of data on non-mythical hardware.</li>

<li>Sorting the petabyte of data.</li>

<li>Considering hardware failure during the 310 days of processing time.</li>

</ul>

</div>

<p>Typically, time series applications need to scan the data at some point, which creates large mountains to climb, if we wish to approach large tomes of time series data in today’s systems. We’re seeing multi-terabyte and multi-petabyte data sources in the time series domain every day, including</p>

<div style="margin-left: 20px;">

<ul>

<li>Sensor data</li>

<li>Financial data</li>

<li>Genome data</li>

</ul>

</div>

<p>and in each of these domains the above scenario is a very real challenge to tackle.</p>

<p>HDFS solves the storage and failure issues above, but what about the sorting and processing issues? Sorting large amounts of data in itself is a non-trivial problem, yet is approachable with a few tricks in MapReduce. Let’s take a look at real MapReduce code that we can download to compile and produce our own scalable simple moving average, to solve some of these pain points.</p>

<h2><strong>Simple Moving Average in MapReduce</strong></h2>

<p>Typically a MapReduce application is composed of two functions: (you guessed it) a map function and a reduce function. In the world of java programming we create a map class and a reduce class, each with inherit methods useful for their respectful purposes. We use the MapReduce programming model because it is built to mitigate concurrency issues in our algorithms and we get our scalable parallelism relatively painlessly.</p>

<p>The map function can involve code that performs a per-key-value pair operation, but its main logical operation is to group data by keys. A very easy way to think about a map function is to think of it as a logical projection of the data or a group by clause. The reduce function is used to take these groups (individually) and run a process across the values which were grouped together. Common operations in reduce functions include:</p>

<div style="margin-left: 20px;">

<ul>

<li>Avg</li>

<li>Min/Max</li>

<li>Sum</li>

</ul>

</div>

<p>In our simple moving average example, however, we don’t operate on a per value basis specifically, nor do we produce an aggregate across all of the values. Our operation in the aggregate sense involves a sliding window, which performs its operations on a subset of the data at each step. We also have to consider that the points in our time series data are not guaranteed to arrive at the reduce in order and need to be sorted&#8211;mentioned in previous sections. This is because with multiple map functions reading multiple sections of the source</p>

<p>data MapReduce does not impose any order on the key-value pairs that are grouped together in the default partition and sorting schemes. There is the scenario where we have sorted partitioned data, but for the sake of this example we’re going to deal with the more “garden-variety” unsorted time series data.</p>

<p>Let’s take a first pass at how we could design this MapReduce <a href="https://github.com/jpatanooga/Caduceus/blob/master/src/tv/floe/caduceus/hadoop/movingaverage/NoShuffleSort_MovingAverageJob.java">simple moving average job</a>. We want to group all of one stock’s adjusted close values together so we can apply the simple moving average operation over the sorted time series data. We want to <a href="https://github.com/jpatanooga/Caduceus/blob/master/src/tv/floe/caduceus/hadoop/movingaverage/NoShuffleSort_MovingAverageMapper.java">emit each time series key value pair</a> keyed on a stock symbol to group these values together. In the <a href="https://github.com/jpatanooga/Caduceus/blob/master/src/tv/floe/caduceus/hadoop/movingaverage/NoShuffleSort_MovingAverageReducer.java">reduce phase</a> we can run an operation, here the simple moving average, over the data. Since the data more than likely will not arrive at the reducer in sorted order we’ll need to sort the data before we can calculate the simple moving average.</p>

<p>A common way to sort data is to load the data into memory in a data structure such as a heap, much like how this is done in a normal java program. In this case we’ll use Java’s priority queue class to sort our data. We also need to consider the amount of memory used by the incoming time series data during sorting as this is a limiting factor on how much data we can sort. In this design we have to load all of the time series data before we can start processing and if the amount of data to sort exceeds the available heap size we have a problem. An example of</p>

<p>this implementation is hosted at github:</p>

<div style="margin-left: 20px;">

<ul>

<li><a href="https://github.com/jpatanooga/Caduceus/blob/master/src/tv/floe/caduceus/hadoop/movingaverage/NoShuffleSort_MovingAverageJob.java">NoShuffleSort_MovingAverageJob.java</a></li>

<li><a href="https://github.com/jpatanooga/Caduceus/blob/master/src/tv/floe/caduceus/hadoop/movingaverage/NoShuffleSort_MovingAverageMapper.java">NoShuffleSort_MovingAverageMapper.java</a></li>

<li><a href="https://github.com/jpatanooga/Caduceus/blob/master/src/tv/floe/caduceus/hadoop/movingaverage/NoShuffleSort_MovingAverageReducer.java">NoShuffleSort_MovingAverageReducer.java</a></li>

</ul>

</div>

<p>To run this code on your own Hadoop cluster, download CDH from Cloudera and <a href="https://wiki.cloudera.com/display/DOC/CDH3+Quick+Start+Guide">setup a pseudo-distributed cluster</a>&#8211;which is a single node of Hadoop. Pseudo-distributed mode is a great way to try out code with Hadoop. Next download and compile the moving average code into a jar. To download the code directly from github (in the shell in MacOSX, ssh terminal window in linux, or MINGW32 for win32) we&#8217;ll use the command:</p>

<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61e0a631a131889745" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">

git clone git://github.com/jpatanooga/Caduceus</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61e0a631a131889745-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61e0a631a131889745-1"><span class="crayon-e">git </span><span class="crayon-r">clone</span><span class="crayon-h"> </span><span class="crayon-v">git</span><span class="crayon-o">:</span><span class="crayon-c">//github.com/jpatanooga/Caduceus</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0005 seconds] -->

<p></p>

<p>To compile we can either use Ant and simply type:</p>

<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61e0a632f069936016" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">

ant</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61e0a632f069936016-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61e0a632f069936016-1"><span class="crayon-v">ant</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0003 seconds] -->

<p></p>

<p>or we can open the code in our favorite java IDE and compile it into a jar (make sure to add the lib directory into the jar). Then copy this jar to your cluster to run the job. Next we&#8217;ll need to copy the input data from the project&#8217;s local data subdirectory to a place in hdfs. Specifically this file is <a href="https://github.com/jpatanooga/Caduceus/blob/master/data/movingaverage/yahoo_stock_AA_32_mini.csv">yahoo_stock_AA_32_mini.csv</a>, which is downloaded in the git clone command above into the /data/movingaverage subdirectory of the project. We&#8217;ll need to copy this data into HDFS with the command:</p>

<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61e0a633b023080793" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">

hadoop fs -copyFromLocal data/movingaverage/yahoo_stock_AA_32_mini.csv /&amp;lt;somewhere_in_hdfs&amp;gt;</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61e0a633b023080793-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61e0a633b023080793-1"><span class="crayon-e">hadoop </span><span class="crayon-v">fs</span><span class="crayon-h"> </span><span class="crayon-o">-</span><span class="crayon-e">copyFromLocal </span><span class="crayon-v">data</span><span class="crayon-o">/</span><span class="crayon-v">movingaverage</span><span class="crayon-o">/</span><span class="crayon-v">yahoo_stock_AA_32_mini</span><span class="crayon-sy">.</span><span class="crayon-v">csv</span><span class="crayon-h"> </span><span class="crayon-o">/</span><span class="crayon-o">&amp;</span><span class="crayon-v">lt</span><span class="crayon-sy">;</span><span class="crayon-v">somewhere_in_hdfs</span><span class="crayon-o">&amp;</span><span class="crayon-v">gt</span><span class="crayon-sy">;</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0011 seconds] -->

<p></p>

<p>With the jar on the VM (or cluster accessible machine) and our sample data loaded into hdfs we will run the job with the command:</p>

<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61e0a6344786379467" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">

hadoop jar Caduceus-0.1.0.jar

tv.floe.caduceus.hadoop.movingaverage.NoShuffleSort_MovingAverageJob

&amp;lt;input_hdfs_dir_where_we_put_data&amp;gt; &amp;lt;output_hdfs_results_dir&amp;gt; </textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61e0a6344786379467-1">1</div><div class="crayon-num crayon-striped-num" data-line="crayon-560f61e0a6344786379467-2">2</div><div class="crayon-num" data-line="crayon-560f61e0a6344786379467-3">3</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61e0a6344786379467-1"><span class="crayon-e">hadoop </span><span class="crayon-e">jar </span><span class="crayon-v">Caduceus</span><span class="crayon-o">-</span><span class="crayon-cn">0.1.0.jar</span></div><div class="crayon-line crayon-striped-line" id="crayon-560f61e0a6344786379467-2"><span class="crayon-v">tv</span><span class="crayon-sy">.</span><span class="crayon-v">floe</span><span class="crayon-sy">.</span><span class="crayon-v">caduceus</span><span class="crayon-sy">.</span><span class="crayon-v">hadoop</span><span class="crayon-sy">.</span><span class="crayon-v">movingaverage</span><span class="crayon-sy">.</span><span class="crayon-v">NoShuffleSort_MovingAverageJob</span></div><div class="crayon-line" id="crayon-560f61e0a6344786379467-3"><span class="crayon-o">&amp;</span><span class="crayon-v">lt</span><span class="crayon-sy">;</span><span class="crayon-v">input_hdfs_dir_where_we_put_data</span><span class="crayon-o">&amp;</span><span class="crayon-v">gt</span><span class="crayon-sy">;</span><span class="crayon-h"> </span><span class="crayon-o">&amp;</span><span class="crayon-v">lt</span><span class="crayon-sy">;</span><span class="crayon-v">output_hdfs_results_dir</span><span class="crayon-o">&amp;</span><span class="crayon-v">gt</span><span class="crayon-sy">;</span><span class="crayon-h"> </span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0015 seconds] -->

<p></p>

<p>After we run the MapReduce job, we can take a look at the results with the command:</p>

<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61e0a634e590500081" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">

hadoop fs -cat /&amp;lt;output_hdfs_results_dir&amp;gt;/part-00000</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61e0a634e590500081-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61e0a634e590500081-1"><span class="crayon-e">hadoop </span><span class="crayon-v">fs</span><span class="crayon-h"> </span><span class="crayon-o">-</span><span class="crayon-v">cat</span><span class="crayon-h"> </span><span class="crayon-o">/</span><span class="crayon-o">&amp;</span><span class="crayon-v">lt</span><span class="crayon-sy">;</span><span class="crayon-v">output_hdfs_results_dir</span><span class="crayon-o">&amp;</span><span class="crayon-v">gt</span><span class="crayon-sy">;</span><span class="crayon-o">/</span><span class="crayon-v">part</span><span class="crayon-o">-</span><span class="crayon-cn">00000</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0009 seconds] -->

<p></p>

<p>which should show:</p>

<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61e0a6357249361195" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">

Group: AA, Date: 2008-03-03   Moving Average: 33.529335

Group: AA, Date: 2008-03-04   Moving Average: 34.529335

Group: AA, Date: 2008-03-05   Moving Average: 35.396</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61e0a6357249361195-1">1</div><div class="crayon-num crayon-striped-num" data-line="crayon-560f61e0a6357249361195-2">2</div><div class="crayon-num" data-line="crayon-560f61e0a6357249361195-3">3</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61e0a6357249361195-1"><span class="crayon-v">Group</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-v">AA</span><span class="crayon-sy">,</span><span class="crayon-h"> </span><span class="crayon-v">Date</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-cn">2008</span><span class="crayon-o">-</span><span class="crayon-cn">03</span><span class="crayon-o">-</span><span class="crayon-cn">03</span>  <span class="crayon-h"> </span><span class="crayon-e">Moving </span><span class="crayon-v">Average</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-cn">33.529335</span></div><div class="crayon-line crayon-striped-line" id="crayon-560f61e0a6357249361195-2"><span class="crayon-v">Group</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-v">AA</span><span class="crayon-sy">,</span><span class="crayon-h"> </span><span class="crayon-v">Date</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-cn">2008</span><span class="crayon-o">-</span><span class="crayon-cn">03</span><span class="crayon-o">-</span><span class="crayon-cn">04</span>  <span class="crayon-h"> </span><span class="crayon-e">Moving </span><span class="crayon-v">Average</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-cn">34.529335</span></div><div class="crayon-line" id="crayon-560f61e0a6357249361195-3"><span class="crayon-v">Group</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-v">AA</span><span class="crayon-sy">,</span><span class="crayon-h"> </span><span class="crayon-v">Date</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-cn">2008</span><span class="crayon-o">-</span><span class="crayon-cn">03</span><span class="crayon-o">-</span><span class="crayon-cn">05</span>  <span class="crayon-h"> </span><span class="crayon-e">Moving </span><span class="crayon-v">Average</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-cn">35.396</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0025 seconds] -->

<p></p>

<p>Our first pass is a decent solution, but we’re limited by our Java Virtual Machine (JVM) child heap size and we are taking time to manually sort the data ourselves. With a few design changes, we can solve both of these issues taking advantage of some inherent properties of MapReduce. First we want to look at the case of sorting the data in memory on each reducer. Currently we have to make sure we never send more data to a single reducer than can fit in memory. The way we can currently control this is to give each reducer child JVM more heap and/or to further partition our time series data in the map phase. In this case we’d partition further by time, breaking our data into smaller windows of time.</p>

<p>As opposed to further partitioning of the data, another approach to this issue is to allow Hadoop to sort the data for us in what’s called the “shuffle phase” of MapReduce. If the data arrives at a reducer already in sorted order we can lower our memory footprint and reduce the number of loops through the data by only looking at the next N samples for each simple moving average calculation. This brings us to the crucial aspect of this article, which is called the shuffle’s “secondary sort” mechanic. Sorting is something we can let Hadoop do for us and Hadoop has proven to be quite good at sorting large amounts of data, <a href="http://developer.yahoo.com/blogs/hadoop/posts/2008/07/apache_hadoop_wins_terabyte_sort_benchmark/">winning the Gray Sort competition in 2008</a>. In using the secondary sort mechanic we can solve both our heap and sort issues fairly simply and efficiently. To employ secondary sort in our code, we need to make the key a composite of the natural key and the natural value. Below in Figure-1 we see a diagram of how this would look visually.</p>

<p style="text-align: center;"><img src="https://www.cloudera.com/wp-content/uploads/2011/04/secondary_sort_figure_composite_key.png" alt="Composite Key Breakdown" width="659" height="472" /></p>

<p style="text-align: center;">Figure-1: <em>Composite Key Diagram</em></p>

<p>The Composite Key gives Hadoop the needed information during the shuffle to perform a sort not only on the &#8220;stock symbol&#8221;, but on the time stamp as well. The class that sorts these Composite Keys is called the key comparator or here &#8220;CompositeKeyComparator&#8221;. The key comparator should order by the composite key, which is the combination of the natural key and the natural value. We can see below in Figure-2 where an abstract version of secondary sort is being performed on a composite key of 2 integers.</p>

<p style="text-align: center;"><img class="aligncenter" src="https://www.cloudera.com/wp-content/uploads/2011/04/secondary_sort_figure_2_compositekeycomparator_01.png" alt="Sorting by Composite Key" width="722" height="165" /></p>

<p style="text-align: center;">Figure-2: <em>CompositeKeyComparator sorting Composite Keys (keys are integers).</em></p>

<p>In Figure-3 below we see a more realistic example where we&#8217;ve changed the Composite Key to have a stock symbol string (K1) and a timestamp (K2, displayed as a date, but in the code is a long in ms). The diagram has sorted the K/V pairs by both &#8220;K1: stock symbol&#8221; (natural key) and &#8220;K2: time stamp&#8221; (secondary key).</p>

<p style="text-align: center;"><img src="https://www.cloudera.com/wp-content/uploads/2011/04/secondary_sort_figure_2_compositekeycomparator_11.png" alt="Composite Key sort with realistic values" width="741" height="219" /></p>

<p style="text-align: center;">Figure-3: <em>CompositeKeyComparator at work on our composite keys. Composite key now represented with a string stock symbol (K1) and a date (K2).</em></p>

<p>Once we&#8217;ve sorted our data on the composite key, we now need to partition the data for the reduce phase. In Figure-4 below we see how the data from Figure-3 above has been partitioned with the NaturalKeyPartitioner.</p>

<p style="text-align: center;"><img src="https://www.cloudera.com/wp-content/uploads/2011/04/secondary_sort_figure_2_naturalkeypartitioner1.png" alt="Natural Key Partitioner" width="808" height="238" /></p>

<p style="text-align: center;">Figure-4: <em>Partitioning by the natural key with the NaturalKeyPartitioner</em>.</p>

<p>Once we&#8217;ve partitioned our data the reducers can now start downloading the partition files and begin their merge phase. Inf Figure-5 below we see how the grouping comparator, or NaturalKeyGroupingComparator, is used to make sure a reduce() call only sees the logically grouped data meant for that composite key.</p>

<p style="text-align: center;"><img src="https://www.cloudera.com/wp-content/uploads/2011/04/secondary_sort_NaturalKeyGroupingComparator1.png" alt="NaturalKeyGroupingComparator" width="851" height="481" /></p>

<p style="text-align: center;">Figure-5: <em>Grouping Comparator merging partition files</em>.</p>

<p>The partitioner and grouping comparator for the composite key should consider only the natural key for partitioning and grouping.</p>

<p>Below is a short description of the <a href="https://github.com/jpatanooga/Caduceus/tree/master/src/tv/floe/caduceus/hadoop/movingaverage">Simple Moving Average code</a> which is altered to use the secondary sort and is hosted on github. If you’ll notice, the names of the classes closely match the terminology used in the diagrams above and in Tom White’s “Hadoop: The Definitive Guide” (chapter 8 “MapReduce Features”) so as to make the code easier to understand.</p>

<p><strong>NaturalKey</strong> &#8211; what you would normally use as the key or “group by” operator.</p>

<div style="margin-left: 20px;">

<ul>

<li>In this case the Natural Key is the “group” or “stock symbol” as we need to group potentially unsorted stock data before we can sort it and calculate the simple moving average.</li>

</ul>

</div>

<p><strong>Composite Key</strong> &#8211; A Key that is a combination of the natural key and the natural value we want to sort by.</p>

<div class="code" style="margin-left: 20px;">@jpatanooga.</div>



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

	<li><a href="http://blog.cloudera.com/blog/category/hadoop/" title="View all posts in Hadoop" rel="category tag">Hadoop</a></li></ul>  	</div>

  	

  <a name="comments"></a>

  <div class="comments-head">

    <strong>5 Responses</strong>

   

</div>

  <ul class="comments-list">

  	<li>

		<em class="comment-date">

			<a rel="nofollow" href="">Evan Sparks</a> /

			April 15, 2011 / 11:12 AM		</em>

<p>Cool trick with the split sorter/partitioner. As far as I can tell this works great until the series become extremely long (think 30 years of tick-level data) &#8211; seems like partitioning by time might be very tricky. Do you know of anything built into hadoop like an &#8220;overlapping partitioner&#8221; which can spit the same data to multiple partitions? </p>

<p>I have experimented with mappers that duplicate values across multiple keys, but I wonder if there&#8217;s a more conventional way of doing this.</p>

	</li>

</li>

	<li>

		<em class="comment-date">

			<a rel="nofollow" href="http://www.cloudera.com">Josh Patterson</a> /

			April 16, 2011 / 8:55 AM		</em>

<p>Evan,<br />

You are dead on with the size of the data in a single keyspace. I hit this same issue when working on the openPDC project for the NERC:</p>

<p><a href="http://opendpdc.codeplex.com" rel="nofollow">http://opendpdc.codeplex.com</a></p>

<p>One sensor could have literally billions of points in a very short amount of time, so for prototype jobs we keyed things to a single day (3,600,000ms):</p>

<p><a href="https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version/src/TVA/Hadoop/MapReduce/Datamining/SAX/SlidingClassifier_1NN_Euc.java" rel="nofollow">https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version/src/TVA/Hadoop/MapReduce/Datamining/SAX/SlidingClassifier_1NN_Euc.java</a></p>

<p>In a more complex version I would have used overlapping time slots so the mapper would get sufficient data from adjacent keyspaces to cover a single window length. For now I&#8217;d say you are on the right track with the duplicate values.</p>

<p>Josh</p>

	</li>

</li>

	<li>

		<em class="comment-date">

			<a rel="nofollow" href="http://www.ashwinjayaprakash.com/">Ashwin Jayaprakash</a> /

			April 11, 2012 / 4:54 PM		</em>

<p>I know this is not related to moving averages, but how accurate was the SAX time series matching used in PDC?</p>

	</li>

</li>

	<li>

		<em class="comment-date">

			<a rel="nofollow" href="">Jacob</a> /

			April 28, 2013 / 11:59 AM		</em>

<p>Hi,</p>

<p>I implemented something like this (except using the MapReduce API 2), and in the loop of the reduce() function, whenever the .next() method is called on the Iterator, we get a new value, but the _key_ also miraculously changes. Rather, the part of the composite key that was not used as a natural key (the timestamp in this example) changes. This was quite surprising. How does this happen?</p>

<p>Thanks</p>

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

  	<input type='hidden' name='comment_post_ID' value='7115' id='comment_post_ID' />

<input type='hidden' name='comment_parent' id='comment_parent' value='0' />

  	<p class="cptch_block"><label>Prove you're human!<span class="required"> *</span></label><br />		<input type="hidden" name="cptch_result" value="NNw=" />

		<input type="hidden" name="cptch_time" value="1443848672" />

		<input type="hidden" value="Version: 2.4" />

		&#111;ne &#43; <input id="cptch_input" type="text" autocomplete="off" name="cptch_number" value="" maxlength="2" size="2" aria-required="true" required="required" style="margin-bottom:0;display:inline;font-size: 12px;width: 40px;" /> = 9	</p>  </form>

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
