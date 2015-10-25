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


<title>Simple Moving Average, Secondary Sort, and MapReduce (Part 2) | Cloudera Engineering Blog</title>



<meta name="keywords" content="hadoop, hadoop training, cloudera, hadoop tutorial, hadoop certification, apache hadoop, hadoop download, big data, open source" />

<meta name="description" content="" />

<meta http-equiv="content-type" content="text/html; charset=utf-8" />

<meta name="msvalidate.01" content="8857B9071A02F989DE3F8BEE557BB584" />



<link rel="search" type="application/opensearchdescription+xml" href="/assets/opensearch.xml" title="Cloudera" />



<meta property="og:title" content="Simple Moving Average, Secondary Sort, and MapReduce (Part 2)"/>

<meta property="og:type" content="article"/>

<meta property="og:url" content="http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2/"/>

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
<link rel="alternate" type="application/rss+xml" title="Cloudera Engineering Blog &raquo; Simple Moving Average, Secondary Sort, and MapReduce (Part 2) Comments Feed" href="http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2/feed/" />
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
<link rel='prev' title='Simple Moving Average, Secondary Sort, and MapReduce (Part 1)' href='http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/' />
<link rel='next' title='Rapleaf Uses Hadoop to Efficiently Scale with Terabytes of Data' href='http://blog.cloudera.com/blog/2011/03/rapleaf-uses-hadoop-to-efficiently-scale-with-teabytes-of-data/' />
<meta name="generator" content="WordPress 3.3.2" />
<link rel='canonical' href='http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2/' />
<link rel='shortlink' href='http://blog.cloudera.com/?p=7110' />




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

<body class="single single-post postid-7110 single-format-standard devcenter">

			

		

			

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

			<h1 class="heading ">Simple Moving Average, Secondary Sort, and MapReduce (Part 2)</h1>

			

			<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>

			

			<ul class="post-info">

				<li>by <a href="http://blog.cloudera.com/blog/author/josh-patterson/" title="Posts by Josh Patterson" rel="author">Josh Patterson</a></li>

				<li>March 16, 2011</li>

				<li class="comment"><a href="#comments">2 comments</a></li>

				

			</ul>

			

			<div class="text-block">

<p><em>This is the second post of a three part blog series. If you would like to read &#8220;<a href="http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/">Part 1</a>,&#8221; please follow <a href="http://blog.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1/">this link</a>. In this post we will be reviewing a simple moving average in contexts that should be familiar to the analyst not well versed in Hadoop as to establish a common ground with the reader from which we can move forward.</em></p>
<h2>A Quick Primer on Simple Moving Average in Excel</h2>
<p>Let&#8217;s take a second to do a quick review of how we define simple moving average in an Excel spreadsheet. We&#8217;ll need to start with some simple source data, so let&#8217;s download a source&#160;<a href="https://github.com/jpatanooga/Caduceus/tree/master/data/movingaverage">csv</a> <a href="https://github.com/jpatanooga/Caduceus/tree/master/data/movingaverage">file</a> from github and save it locally. This file contains a synthetic 33 row sample of Yahoo NYSE stock data that we&#8217;ll use for the series of examples. Import the csv data into Excel. From there, scan to the date &#8220;3/5/2008&#8221; and move to the cell to the right of the &#8220;ad close&#8221; column. Enter the formula</p>
<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61dfc3b12760090856" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">
=AVERAGE( [column-range] )</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61dfc3b12760090856-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61dfc3b12760090856-1"><span class="crayon-o">=</span><span class="crayon-e">AVERAGE</span><span class="crayon-sy">(</span><span class="crayon-h"> </span><span class="crayon-sy">[</span><span class="crayon-v">column</span><span class="crayon-o">-</span><span class="crayon-v">range</span><span class="crayon-sy">]</span><span class="crayon-h"> </span><span class="crayon-sy">)</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0007 seconds] -->

<p></p>
<p><br class="spacer_" /></p>
<p>where [column-range] is all of the columns from that date to 29 days prior. Now copy this formula for the next two rows, dates &#8220;3/4/2008&#8221; and &#8220;3/3/2008&#8221;.</p>
<p><img src="https://www.cloudera.com/wp-content/uploads/2011/03/Excel_SMA.png" alt="SMA in Excel" width="769" height="572" /></p>
<p>You should have the values &#8220;35.396&#8221;, &#8220;34.5293&#8221;, and &#8220;33.5293&#8221; which represent the 30 day moving averages for this synthetic yahoo stock data.</p>
<p>Now that we&#8217;ve established a basic example in Excel let&#8217;s take a look at how we do Simple Moving Average in R.</p>
<h2>A Quick Primer on Simple Moving Average in R</h2>
<p>Another common tool in the time series domain, especially the financial sector, is the <a href="http://en.wikipedia.org/wiki/R_(programming_language)">R programming language</a>. R is:</p>
<div style="margin-left: 20px;">
<ul>
<li>A programming language and software environment for statistical computing and graphics. </li>
<li>A de facto standard among statisticians for statistical software development and data analysis.</li>
<li>An implementation of the <a href="http://en.wikipedia.org/wiki/S_(programming_language)">S programming language</a> combined with <a href="http://en.wikipedia.org/wiki/Lexical_scoping">lexical scoping</a> semantics inspired by <a href="http://en.wikipedia.org/wiki/Scheme_(programming_language)">Scheme</a>. </li>
<li>Currently developed by the R Development Core Team, but was originally developed by <a href="http://en.wikipedia.org/wiki/Ross_Ihaka">Ross Ihaka</a> and <a href="http://en.wikipedia.org/wiki/Robert_Gentleman_(statistician)">Robert Gentleman</a> at the University of Auckland, <a href="http://en.wikipedia.org/wiki/New_Zealand">New Zealand</a>.</li>
</ul>
</div>
<p>Download the R binary from [<a href="http://cran.r-project.org/mirrors.html">here</a>] and install it locally (they support both linux and win32). Once installed, launch the R console and drop the &#8220;Packages&#8221; menu down, which is where we need to install the <strong>TTR</strong> package. Select a mirror and download this package. Now load this package by clicking on the &#8220;Packages&#8221; drop down and selecting &#8220;Load Package&#8221;. Find the TTR package that was just installed and select it. Next, <a href="https://github.com/jpatanooga/Caduceus/tree/master/data/movingaverage">download the synthetic stock data</a> from my project on github which contains 33 lines of synthetic stock data to process. In order to load this CSV data in R we need to set our working directory by clicking on the menu item &#8220;File&#8221; and then &#8220;Change directory&#8221;.</p>
<p>Quick tip: at any time the user can type the name of the variable and hit Enter to display the contents of the variable. Now that we have all the prep out of the way, let&#8217;s write the simple moving average in R:</p>
<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61dfc3b2e154365715" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">
stock_data &lt;- read.csv(file="&lt;a href="https://github.com/jpatanooga/Caduceus/blob/master/data/movingaverage/yahoo_stock_AA_32_mini.csv"&gt;&lt;span style="color: #000000;"&gt;yahoo_stock_AA_32_mini.csv&lt;/span&gt;&lt;/a&gt;",head=TRUE,sep=",")</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61dfc3b2e154365715-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61dfc3b2e154365715-1"><span class="crayon-v">stock_data</span><span class="crayon-h"> </span><span class="crayon-o">&lt;</span><span class="crayon-o">-</span><span class="crayon-h"> </span><span class="crayon-v">read</span><span class="crayon-sy">.</span><span class="crayon-e">csv</span><span class="crayon-sy">(</span><span class="crayon-v">file</span><span class="crayon-o">=</span><span class="crayon-s">"&lt;a href="</span><span class="crayon-v">https</span><span class="crayon-o">:</span><span class="crayon-c">//github.com/jpatanooga/Caduceus/blob/master/data/movingaverage/yahoo_stock_AA_32_mini.csv"&gt;&lt;span style="color: #000000;"&gt;yahoo_stock_AA_32_mini.csv&lt;/span&gt;&lt;/a&gt;",head=TRUE,sep=",")</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0009 seconds] -->

<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61dfc3b39673159554" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">
sorted_stock_data &lt;- stock_data[order(stock_data$date) , ]</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61dfc3b39673159554-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61dfc3b39673159554-1"><span class="crayon-v">sorted_stock_data</span><span class="crayon-h"> </span><span class="crayon-o">&lt;</span><span class="crayon-o">-</span><span class="crayon-h"> </span><span class="crayon-v">stock_data</span><span class="crayon-sy">[</span><span class="crayon-e">order</span><span class="crayon-sy">(</span><span class="crayon-v">stock_data</span><span class="crayon-sy">$</span><span class="crayon-v">date</span><span class="crayon-sy">)</span><span class="crayon-h"> </span><span class="crayon-sy">,</span><span class="crayon-h"> </span><span class="crayon-sy">]</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0009 seconds] -->

<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61dfc3b43320052317" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">
sma &lt;-&amp;#160;&amp;#160; SMA(sorted_stock_data[,"adj.close"], 30)</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61dfc3b43320052317-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61dfc3b43320052317-1"><span class="crayon-v">sma</span><span class="crayon-h"> </span><span class="crayon-o">&lt;</span><span class="crayon-o">-</span><span class="crayon-o">&amp;</span><span class="crayon-p">#160;&amp;#160; SMA(sorted_stock_data[,"adj.close"], 30)</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0005 seconds] -->

<p></p>
<p><br class="spacer_" /></p>
<p>To check that our stock data is indeed loaded, we can type the name of the variable, here &#8220;sorted_stock_data&#8221;, and hit enter which will produce:</p>
<p></p><!-- Crayon Syntax Highlighter v2.6.6 -->



		<div id="crayon-560f61dfc3b4c744646667" class="crayon-syntax crayon-theme-classic crayon-font-monaco crayon-os-pc print-yes notranslate" data-settings=" no-popup minimize scroll-mouseover" style=" max-width: 620px; margin-top: 12px; margin-bottom: 12px; font-size: 12px !important; line-height: 15px !important;">

		

			<div class="crayon-toolbar" data-settings=" show" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><span class="crayon-title"></span>

			<div class="crayon-tools" style="font-size: 12px !important;height: 18px !important; line-height: 18px !important;"><div class="crayon-button crayon-nums-button" title="Toggle Line Numbers"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-plain-button" title="Toggle Plain Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-wrap-button" title="Toggle Line Wrap"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-expand-button" title="Expand Code"><div class="crayon-button-icon"></div></div><div class="crayon-button crayon-copy-button" title="Copy"><div class="crayon-button-icon"></div></div></div></div>

			<div class="crayon-info" style="min-height: 16.8px !important; line-height: 16.8px !important;"></div>

			<div class="crayon-plain-wrap"><textarea wrap="soft" class="crayon-plain print-no" data-settings="dblclick" readonly style="-moz-tab-size:4; -o-tab-size:4; -webkit-tab-size:4; tab-size:4; font-size: 12px !important; line-height: 15px !important;">
&gt; sorted_stock_data</textarea></div>

			<div class="crayon-main" style=" max-height: 500px; max-width: 620px;">

				<table class="crayon-table">

					<tr class="crayon-row">

				<td class="crayon-nums " data-settings="hide">

					<div class="crayon-nums-content" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-num" data-line="crayon-560f61dfc3b4c744646667-1">1</div></div>

				</td>

						<td class="crayon-code"><div class="crayon-pre" style="font-size: 12px !important; line-height: 15px !important;"><div class="crayon-line" id="crayon-560f61dfc3b4c744646667-1"><span class="crayon-o">&gt;</span><span class="crayon-h"> </span><span class="crayon-v">sorted_stock_data</span></div></div></td>

					</tr>

				</table>

</div>

</div>

<!-- [Format Time: 0.0004 seconds] -->

<p></p>
<p><br class="spacer_" /></p>
<p>>exchange stock_symbol &#160;&#160;&#160;&#160;&#160;&#160;date&#160; open&#160; high&#160;&#160; low close&#160;&#160; volume adj.close<br />
 32&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-03 38.85 39.28 38.26 38.37 11279900&#160;&#160;&#160;&#160;&#160; 8.37<br />
 31&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-04 37.01 37.90 36.13 36.60 17752400&#160;&#160;&#160;&#160; 10.60<br />
 30&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-05 31.16 31.89 30.55 30.69 17567800&#160;&#160;&#160;&#160; 30.53<br />
 29&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-06 30.27 31.52 30.06 31.47&#160; 8445100&#160;&#160;&#160;&#160; 31.31<br />
 28&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-07 31.73 33.13 31.57 32.66 14338500&#160;&#160;&#160;&#160; 32.49<br />
 27&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-08 32.58 33.42 32.11 32.70 10241400&#160;&#160;&#160;&#160; 32.53<br />
 26&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-09 32.13 33.34 31.95 33.09&#160; 9200400&#160;&#160;&#160;&#160; 32.92<br />
 25&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-10 33.67 34.45 33.07 34.28 15186100&#160;&#160;&#160;&#160; 34.10<br />
 24&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-11 34.57 34.85 33.98 34.08&#160; 9528000&#160;&#160;&#160;&#160; 33.90<br />
 23&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-12 33.30 33.64 32.52 32.67 11338000&#160;&#160;&#160;&#160; 32.50<br />
 22&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-13 32.95 33.37 32.26 32.41&#160; 7230300&#160;&#160;&#160;&#160; 32.41<br />
 21&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-14 32.24 33.25 31.90 32.78&#160; 9058900&#160;&#160;&#160;&#160; 32.78<br />
 20&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; &#160;&#160;AA 2008-02-15 32.67 33.81 32.37 33.76 10731400&#160;&#160;&#160;&#160; 33.76<br />
 19&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-16 33.82 34.25 33.29 34.06 11249800&#160;&#160;&#160;&#160; 34.06<br />
 18&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-17 34.33 34.64 33.26 33.49 12418900&#160;&#160;&#160;&#160; 33.49<br />
 17&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-18 33.75 35.52 33.63 35.51 21082100&#160;&#160;&#160;&#160; 35.51<br />
 16&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-19 36.01 36.43 35.05 35.36 18238800&#160;&#160;&#160;&#160; 35.36<br />
 15&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-20 35.16 35.94 35.12 35.72 14082200&#160;&#160;&#160;&#160; 35.72<br />
 14&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-21 36.19 36.73 35.84 36.20 12825300&#160;&#160;&#160;&#160; 36.20<br />
 13&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-22 35.96 36.85 35.51 36.83 10906600&#160;&#160;&#160;&#160; 36.83<br />
 12&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-23 36.88 37.41 36.25 36.30 13078200&#160;&#160;&#160;&#160; 36.30<br />
 11&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-24 36.38 36.64 35.58 36.55 12834300&#160;&#160;&#160;&#160; 36.55<br />
 10&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-25 36.64 38.95 36.48 38.85 22500100&#160;&#160;&#160;&#160; 38.85<br />
 9&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-26 38.59 39.25 38.08 38.50 14417700&#160;&#160;&#160;&#160; 38.50<br />
 8&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-27 38.19 39.62 37.75 39.02 14296300&#160;&#160;&#160;&#160; 39.02<br />
 7&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160; &#160;&#160;&#160;&#160;&#160;AA 2008-02-28 38.61 39.29 38.19 39.12 11421700&#160;&#160;&#160;&#160; 39.12<br />
 6&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-02-29 38.77 38.82 36.94 37.14 22611400&#160;&#160;&#160;&#160; 37.14<br />
 5&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-03-01 37.17 38.46 37.13 38.32 13964700&#160;&#160;&#160;&#160; 38.32<br />
 4&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-03-02 37.90 38.94 37.10 38.00 15715600&#160;&#160;&#160;&#160; 38.00<br />
 3&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-03-03 38.25 39.15 38.10 38.71 11754600&#160;&#160;&#160;&#160; 38.71<br />
 2&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-03-04 38.85 39.28 38.26 38.37 11279900&#160;&#160;&#160;&#160; 38.37<br />
 1&#160;&#160;&#160;&#160;&#160; NYSE&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; AA 2008-03-05 37.01 37.90 36.13 36.60 17752400&#160;&#160;&#160;&#160; 36.60</p>
<p>The above code should produce our simple moving average, which we can view by typing the name of the variable &#8220;sma&#8221; to produce the following result:</p>
<p>> sma</p>
<p>[1]&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA</p>
<p>[21]&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA&#160;&#160;&#160;&#160;&#160;&#160; NA 33.52933 34.52933 35.39600</p>
<p>Given that before the 30th day there is not enough data to produce a simple moving average based on our set parameter, the &#8220;NA&#8221; entries are produced. These values also match the values in our Excel spreadsheet.</p>
<p>R also has an interesting project, called RHIPE, which runs R code on Hadoop clusters. To take a look at RHIPE please visit <a href="http://www.stat.purdue.edu/~sguha/rhipe/">their site</a>.</p>
<p>So we&#8217;ve taken a look at what a simple moving average is and how we&#8217;d produce it in Excel and R. Both of these examples involved a token amount of data that is interesting but not terribly useful in today&#8217;s high-density time series problem domains. As your data set begins to scale up beyond a single disk worth of space, Hadoop becomes more practical.</p>
<p>The final portion of this three part blog series will explain how to use Hadoop&#8217;s MapReduce to calculate a Simple Moving Average. Then once you have applied the sample code to find a Simple Moving Average of the small example data set, we will move on to use this same code to parse over thirty years worth of all daily stock closing prices.</p>


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

    <strong>2 Responses</strong>

   

</div>

  <ul class="comments-list">

  	<li>
		<em class="comment-date">
			<a rel="nofollow" href="">Chris</a> /
			July 12, 2011 / 1:05 PM		</em>
<p>Great tutorial, when are you going to publish part three?</p>
	</li>
</li>
	<li>
		<em class="comment-date">
			<a rel="nofollow" href="">Jon Zuanich</a> /
			July 12, 2011 / 1:34 PM		</em>
<p>It is out my friend: <a href="http://blog.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3/" rel="nofollow">http://blog.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3/</a></p>
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

  	<input type='hidden' name='comment_post_ID' value='7110' id='comment_post_ID' />
<input type='hidden' name='comment_parent' id='comment_parent' value='0' />
  	<p class="cptch_block"><label>Prove you're human!<span class="required"> *</span></label><br />		<input type="hidden" name="cptch_result" value="+mI=" />
		<input type="hidden" name="cptch_time" value="1443848671" />
		<input type="hidden" value="Version: 2.4" />
		<input id="cptch_input" type="text" autocomplete="off" name="cptch_number" value="" maxlength="2" size="2" aria-required="true" required="required" style="margin-bottom:0;display:inline;font-size: 12px;width: 40px;" /> &times; 6 =  e&#105;g&#104;&#116;een	</p>  </form>

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
