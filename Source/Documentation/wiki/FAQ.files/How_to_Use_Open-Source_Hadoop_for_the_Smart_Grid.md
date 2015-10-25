
<!-- paulirish.com/2008/conditional-stylesheets-vs-css-hacks-answer-neither/ -->
<!--[if lt IE 9]> <html class="no-js ie lt-ie9" lang="en-US" prefix="og: http://ogp.me/ns

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

#" xmlns:fb="http://www.facebook.com/2008/fbml"> <![endif]-->
<!--[if IE 9]> <html class="no-js ie ie9" lang="en-US" prefix="og: http://ogp.me/ns#" xmlns:fb="http://www.facebook.com/2008/fbml"> <![endif]-->
<!--[if !IE]><!--> <html class="no-js" lang="en-US" prefix="og: http://ogp.me/ns#" xmlns:fb="http://www.facebook.com/2008/fbml"> <!--<![endif]-->
<head>
	<meta charset="utf-8" />

		<link type="text/css" media="all" href="https://gigaom.com/wp-content/cache/autoptimize/1/css/autoptimize_eac7a9bbbbee4d31d130ed56196a2ca6.css" rel="stylesheet" /><link type="text/css" media="print" href="https://gigaom.com/wp-content/cache/autoptimize/1/css/autoptimize_801bc24b639e1da83a14ac4b36861fc4.css" rel="stylesheet" /><title>    How to Use Open-Source Hadoop for the Smart Grid &#124; Gigaom</title>

	<link rel="pingback" href="https://gigaom.com/xmlrpc.php" />
	<link rel="shortcut icon" type="image/x-icon" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/favicon.ico?v=1.0" sizes="16x16">
	<link rel="icon" type="image/x-icon" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/favicon.ico?v=1.0" sizes="16x16">

	<link rel="icon" type="image/png" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/favicon-96x96.png" sizes="96x96">
	<link rel="icon" type="image/png" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/favicon-32x32.png" sizes="32x32">
	<link rel="icon" type="image/png" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/favicon-16x16.png" sizes="16x16">
	<!-- msapplication-TileColor and msapplication-TileImage are emitted
		by go-metadata, apple-touch-icon links are emitted by
		includes/class-go-theme-child.php -->
		

	<!-- Set the viewport width to device width for mobile -->
	<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=0.45, maximum-scale=10" />
			
		<link rel="alternate" type="application/rss+xml" title="Gigaom &raquo; Feed" href="https://gigaom.com/feed/" />
<link rel="alternate" type="application/rss+xml" title="Gigaom &raquo; Comments Feed" href="https://gigaom.com/comments/feed/" />
<link rel="alternate" type="application/rss+xml" title="Gigaom &raquo; How to Use Open-Source Hadoop for the Smart Grid Comments Feed" href="https://gigaom.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/feed/" />
		<script type="text/javascript">
			window._wpemojiSettings = {"baseUrl":"https:\/\/s.w.org\/images\/core\/emoji\/72x72\/","ext":".png","source":{"concatemoji":"https:\/\/gigaom.com\/wp-includes\/js\/wp-emoji-release.min.js?ver=4.3"}};
			!function(a,b,c){function d(a){var c=b.createElement("canvas"),d=c.getContext&&c.getContext("2d");return d&&d.fillText?(d.textBaseline="top",d.font="600 32px Arial","flag"===a?(d.fillText(String.fromCharCode(55356,56812,55356,56807),0,0),c.toDataURL().length>3e3):(d.fillText(String.fromCharCode(55357,56835),0,0),0!==d.getImageData(16,16,1,1).data[0])):!1}function e(a){var c=b.createElement("script");c.src=a,c.type="text/javascript",b.getElementsByTagName("head")[0].appendChild(c)}var f,g;c.supports={simple:d("simple"),flag:d("flag")},c.DOMReady=!1,c.readyCallback=function(){c.DOMReady=!0},c.supports.simple&&c.supports.flag||(g=function(){c.readyCallback()},b.addEventListener?(b.addEventListener("DOMContentLoaded",g,!1),a.addEventListener("load",g,!1)):(a.attachEvent("onload",g),b.attachEvent("onreadystatechange",function(){"complete"===b.readyState&&c.readyCallback()})),f=c.source||{},f.concatemoji?e(f.concatemoji):f.wpemoji&&f.twemoji&&(e(f.twemoji),e(f.wpemoji)))}(window,document,window._wpemojiSettings);
		</script>
		








<link rel='stylesheet' id='bsocial-comments-css'  href='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/bsocial-comments/components/css/bsocial-comments.css?ver=1436146263123' type='text/css' media='all' />





<script type='text/javascript'>
/* <![CDATA[ */
var scrib_authority_suggest = {"url":"https:\/\/gigaom.com\/scriblio-authority-suggest","threshold":"5"};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-includes/js/jquery/jquery.js?ver=1.11.3'></script>
<script type='text/javascript' src='https://gigaom.com/wp-includes/js/jquery/jquery-migrate.min.js?ver=1.2.1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-local-bcms/../bcms/components//js/waypoints.min.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/external/amplify.min.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/early.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/external/modernizr.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-datamodule//components/external/highcharts/highcharts.js?ver=4.3'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-datamodule//components/js/min/go-datamodule-helpers.js?ver=4.3'></script>
<link rel="EditURI" type="application/rsd+xml" title="RSD" href="https://gigaom.com/xmlrpc.php?rsd" />
<link rel="wlwmanifest" type="application/wlwmanifest+xml" href="https://gigaom.com/wp-includes/wlwmanifest.xml" /> 
<link rel='prev' title='A Tale of Two Parties: Games Get Glitz While TV Tones Down' href='https://gigaom.com/2009/06/02/a-tale-of-two-parties-games-get-glitz-while-tv-tones-down/' />
<link rel='next' title='Canvas Will Explode UK TV, But BBC Must Stand Back' href='https://gigaom.com/2009/06/02/419-canvas-andrew-burke-amino/' />
<link rel='canonical' href='https://gigaom.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/' />
<link rel='shortlink' href='https://gigaom.com/?p=33266' />
		<link rel="apple-touch-icon" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/logo-iphone.gigaom.png" />

		<!-- generated by http://realfavicongenerator.net -->
		<link rel="apple-touch-icon" sizes="57x57" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/apple-touch-icon-57x57.png">
		<link rel="apple-touch-icon" sizes="60x60" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/apple-touch-icon-60x60.png">
		<link rel="apple-touch-icon" sizes="72x72" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/apple-touch-icon-72x72.png">
		<link rel="apple-touch-icon" sizes="76x76" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/apple-touch-icon-76x76.png">
		<link rel="apple-touch-icon" sizes="120x120" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/apple-touch-icon-120x120.png">
		<link rel="apple-touch-icon" sizes="114x114" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/apple-touch-icon-114x114.png">
		<link rel="apple-touch-icon" sizes="144x144" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/apple-touch-icon-144x144.png">
		<link rel="apple-touch-icon" sizes="152x152" href="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/apple-touch-icon-152x152.png">
		<!-- end HTML generated by http://realfavicongenerator.net -->
		<meta name="news_keywords" content="cleantech, data, google, hadoop, science &amp; energy">
<meta name="keywords" content="cleantech, data, google, hadoop, science &amp; energy" />
<meta name="msvalidate.01" content="6AFF4FA8C591A576B80A612AF591A343" /><meta name="google-site-verification" content="0QAgqohqhkW__EGKv9v-VDR1CDFf5J8WJsPPePSTgdU" /><meta name="y_key" content="a09dd3172406080e" /><meta name="google-site-verification" content="qCPIC6UK_23CR6SxLn2bCjE-Ow0OSYoDExoi699IE98" /><meta name='dcterms.publisher' content='Gigaom' /> 
<meta name='dcterms.title' content='How to Use Open-Source Hadoop for the Smart Grid' /> 
<meta name='dcterms.creator' content='Katie Fehrenbacher' /> 
<meta name='dcterms.modified' content='2009-06-02' /> 
<meta name='dcterms.created' content='2009-06-02' /> 
<meta name='dcterms.date' content='2009-06-02' /> 
<meta name='dcterms.subject' content='cleantech; data; google; hadoop; science &amp; energy' /> 
<script type="application/ld+json">{"@context":"http:\/\/schema.org","@type":"NewsArticle","headline":"How to Use Open-Source Hadoop for the Smart Grid","url":"https:\/\/gigaom.com\/2009\/06\/02\/how-to-use-open-source-hadoop-for-the-smart-grid\/","thumbnailUrl":null,"dateCreated":"2009-06-02T21:00:33+0000","articleSection":"Science &amp; Energy","creator":"Katie Fehrenbacher","keywords":["cleantech","data","google","hadoop","science &amp; energy"]}</script><meta name="description" content="At first glance it&#8217;s hard to see how the open-source software framework Hadoop, which was developed for analyzing large data sets generated by web sites," /><meta name="robots" content="NOODP" /><meta name="author" content="Katie Fehrenbacher" />		<meta name="application-name" content="Gigaom"/>
		<meta name="msapplication-TileColor" content="#ffffff"/>
		<meta name="msapplication-TileImage" content="https://gigaom.com/wp-content/themes/vip/gigaom5/img/favicons/mstile-144x144.png"/>
				<!-- Chartbeat -->
		<script type="text/javascript">var _sf_startpt=(new Date()).getTime()</script>
				<!-- Optimizely -->
		<script src="//cdn.optimizely.com/js/1709470138.js"></script>
		<meta property="og:title" content="How to Use Open-Source Hadoop for the Smart Grid" />
<meta property="og:type" content="article" />
<meta property="og:image" content="https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-local-bsocial/components/img/logo.png" />
<meta property="og:url" content="https://gigaom.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/" />
<meta property="og:description" content="At first glance it&#8217;s hard to see how the open-source software framework Hadoop, which was developed for analyzing large data sets generated by web sites, would be useful for the power grid &#8212; open-source tools and utilities don&#8217;t often mix. But that was before the smart grid and its IT tools started to squeeze their&hellip;
" />
<meta property="article:author" content="http://search.gigaom.com/author/katiefehren/" />
<meta property="article:modified_time" content="2009-06-03T04:00:33+00:00" />
<meta property="article:published_time" content="2009-06-03T04:00:33+00:00" />
<meta property="article:publisher" content="https://www.facebook.com/GigaOM" />
<meta property="article:tag" content="katiefehren" />
<meta property="article:tag" content="posted" />
<meta property="article:tag" content="Google" />
<meta property="article:tag" content="Science &amp; Energy" />
<meta property="article:tag" content="Cleantech" />
<meta property="article:tag" content="SYN Feature Enterprise" />
<meta property="article:tag" content="NYT Enterprise" />
<meta property="article:tag" content="Data" />
<meta property="article:tag" content="Energy" />
<meta property="article:tag" content="CNN Green" />
<meta property="article:tag" content="Hadoop" />
<meta property="fb:admins" content="44604788" />
<meta property="fb:app_id" content="180650338636285" />
<meta name="twitter:card" content="summary" />
<meta name="twitter:site" content="Gigaom" />
	<script type="text/javascript">var ezouid = "1494956225";</script><script type="text/javascript">window.google_analytics_uacct = "UA-67278278-46";</script><base href="https://gigaom.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/"><!--[if lt IE 9]>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<![endif]-->
<!--[if (gte IE 9) | (!IE)]><!-->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
<!--<![endif]--><script type='text/javascript'>
var ezoTemplate = 'old_site_gc';
if(typeof ezouid == 'undefined')
{
    var ezouid = 'none';
}
var ezoFormfactor = '1';
var ezo_elements_to_check = Array();
</script>

<script>
var old_jquery = null;
var old_jquery_sign = null;
function open_jquery_wrapper()
{
    if(typeof $ezJQuery != 'undefined')
    {
        old_jquery = jQuery;
        old_jquery_sign = $;
        $ = $ezJQuery;
        jQuery = $ezJQuery;
    }
}
function close_jquery_wrapper()
{
    if(typeof $ezJQuery != 'undefined')
    {
        $ = old_jquery_sign;
        jQuery = old_jquery;
    }
}
</script>

<!-- START EZHEAD -->
<script type='text/javascript'>
var soc_app_id = '0';
var did = 6916;
var ezdomain = 'gigaom.com';
var ezoicSearchable = 1;
</script>
<!---->

<!-- END EZHEAD -->
<script src="//gigaom.com/utilcave_com/templates/js/ezjquery-noconflict.js"></script><!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>
<body class="single single-post postid-33266 single-format-standard go-channel-science-energy gigaom property-gigaom theme-preview" itemscope itemtype="http://schema.org/WebPage" data-logged-in-as="">
			<!-- Google Tag Manager -->
		<noscript><iframe src="//www.googletagmanager.com/ns.html?id=GTM-PWRW58" height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
		<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src='//www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);})(window,document,'script','dataLayer','GTM-PWRW58');</script>
		<!-- End Google Tag Manager -->
		<!--[if lt IE 9]>
	<div class="old-ie">
<p>
			We no longer support IE8. We recommend upgrading your browser to a newer version of Internet Explorer or use another browser when visiting Gigaom sites.
</p>

		<ul>
			<li><a href="http://chrome.com">Chrome</a></li>
			<li><a href="http://firefox.com">Firefox</a></li>
			<li><a href="http://windows.microsoft.com/en-us/internet-explorer/download-ie">Internet Explorer</a></li>
		</ul>
</div>
<![endif]-->
<div id="wrap-allthethings">
	<div id="allthethings">
		<nav id="go-theme-nav" class="clearfix ">
	<section class="header primary">
		<div class="row">
			<a href="#" id="nav-toggle" class="goicon icon-menu control-primary" title="Navigation"></a>
			<h2 title="Gigaom"><a href="https://gigaom.com/" rel="publisher" title="Gigaom"><span class="logo"><span class="logo-svg"><svg role="img" aria-label="Gigaom Logo" xmlns="http://www.w3.org/2000/svg" version="1.1" class="gigaom-logo" x="0" y="0" width="125.49" height="40.52" viewBox="0 0 125.49 40.52" enable-background="new 0 0 125.49 40.523" xml:space="preserve"><title>Gigaom</title><desc>Gigaom Logo</desc><path fill="#FFFFFF" d="M28.51 17.86h-8.41v3.41h3.85c-0.67 1.55-2.07 2.47-3.78 2.47 -2.53 0-4.52-2.01-4.52-4.57 0-2.63 1.87-4.61 4.35-4.61 1.45 0 2.54 0.55 3.55 1.79l0.09 0.1 3.16-2.44 -0.09-0.11c-1.65-2.04-4.13-3.2-6.82-3.2 -4.8 0-8.42 3.63-8.42 8.45 0 4.78 3.64 8.38 8.47 8.38 2.2 0 4.3-0.81 5.92-2.28 1.81-1.64 2.7-3.74 2.7-6.41 0-0.14 0-0.53-0.02-0.85L28.51 17.86z"/><rect x="30.68" y="10.95" fill="#FFFFFF" width="4.2" height="16.28"/><path fill="#FFFFFF" d="M54.07 17.86h-8.41v3.41h3.85c-0.67 1.55-2.07 2.47-3.78 2.47 -2.53 0-4.52-2.01-4.52-4.57 0-2.63 1.87-4.61 4.35-4.61 1.45 0 2.55 0.55 3.55 1.79l0.08 0.1 3.16-2.44 -0.09-0.11c-1.65-2.04-4.13-3.2-6.81-3.2 -4.8 0-8.43 3.63-8.43 8.45 0 4.78 3.65 8.38 8.47 8.38 2.2 0 4.3-0.81 5.92-2.28 1.81-1.64 2.7-3.74 2.7-6.41 0-0.14 0-0.53-0.02-0.85L54.07 17.86z"/><path fill="#FFFFFF" d="M66.84 27.23l-0.81-2.34h-6.42l-0.8 2.34h-4.76l6.13-16.28h5.28l6.15 16.28H66.84zM62.81 15.1l-2.08 6.13h4.15L62.81 15.1z"/><path fill="#009BFF" d="M71.75 19.1c0-5.11 3.85-8.68 8.98-8.68 5.13 0 8.95 3.57 8.95 8.68 0 5.11-3.82 8.68-8.95 8.68C75.59 27.78 71.75 24.21 71.75 19.1M85.27 19.1c0-2.74-1.78-4.85-4.55-4.85 -2.79 0-4.58 2.11-4.58 4.85 0 2.72 1.79 4.86 4.58 4.86C83.49 23.96 85.27 21.82 85.27 19.1"/><path fill="#FFFFFF" d="M103.02 10.95l-3.42 8.84 -3.39-8.84h-6.23v0.47c1.71 2.09 2.73 4.76 2.73 7.67 0 2.91-1.02 5.58-2.73 7.67v0.48h4.59V16.63l4.1 10.6h1.86l4.13-10.6V27.23h4.59V10.95H103.02z"/></svg></span></span></a></h2>
			<ul class="properties">
				<li id="menu-item-599787" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599787"><a title="Research" href="http://research.gigaom.com/">Research</a></li>
			</ul>
			<ul class="icons right">
						<li class="sub-nav nav-subscribe">
			<a href="#" class="control-subscribe" title="Subscribe">Subscribe</a>
			<div class="container">
				<ul>
					<li class="blog">
						<header class="subheader">Gigaom</header>
						<div id="go-subscribe-nav-newsletter" class="newsletter section" data-blockui-overlay-bg="#111C29" data-blockui-opacity="0.8">
							<i class="goicon icon-megaphone"></i>
							<header>Newsletters</header>
									<div id="injected-newsletter-1" class="cta-section cta-section-newsletter clearfix ">
				<form enctype="application/x-www-form-urlencoded" class="go-local-bsocial-newsletter-form go-standard" method="post" action="https://accounts.gigaom.com/newsletters/" target="_blank" data-identity-server="https://accounts.gigaom.com">

				<input type="hidden" name="timestamp" value="1443847433" />
				<input type="hidden" name="hash" value="7133703db551c6fe8bdb6f8bef8075ef"/>
				<input type="hidden" name="newsletterSave" value="save" />
				<input type="hidden" name="merge_existing_subscriptions" value="merge" />
											<input type="hidden" name="lists[daily][]" value="tech" />
														<input type="hidden" name="lists[daily][]" value="cloud" />
														<input type="hidden" name="lists[daily][]" value="data" />
														<input type="hidden" name="lists[daily][]" value="media" />
														<input type="hidden" name="lists[daily][]" value="mobile" />
														<input type="hidden" name="lists[daily][]" value="science-energy" />
														<input type="hidden" name="lists[daily][]" value="social-web" />
														<input type="hidden" name="lists[pro][]" value="weeklyupdate" />
														<input type="hidden" name="lists[offers][]" value="offers" />
														<input type="hidden" name="lists[offers][]" value="events" />
														<input type="hidden" name="lists[offers][]" value="webinars" />
														<input type="hidden" name="lists[offers][]" value="research" />
														<input type="hidden" name="lists[omsays][]" value="omsays" />
							Don't miss out. Sign up to get all the news you need delivered right to your inbox.				<p class="form-elements go-field-button">
					<input type="email" name="email" value="" placeholder="Enter email address"/>
					<button class="button">Get started</button>
</p>
			</form>
			<div class="subscribed">
<p>
					You're subscribed! If you like, you can <a href="https://accounts.gigaom.com/newsletters/">update your settings</a>
</p>
</div>
</div>
		<script>
		// when this is added to the page, publish that that has occurred
			jQuery( function( $ ) {
				amplify.publish('go-local-bsocial-cta-loaded');
			});
		</script>
</div>
					</li>
					<li class="research">
						<header class="subheader">Gigaom Research</header>
						<div id="go-subscribe-nav-subscription" class="subscription section">
							<i class="goicon icon-person"></i>
							<header>Individual subscription</header>
							<div class="prompt">
<p>
									Register for a free 7 day trial.
</p>
<p>
									<a href="https://research.gigaom.com/subscription/sign-up/" class="button">Get started</a>
</p>
</div>
							<div class="subscribed">
<p>
									You're subscribed! Review details <a href="https://accounts.gigaom.com/my-profile/subscription/">here</a>.
</p>
</div>
</div>
						<!-- 
						<div id="go-subscribe-nav-individual" class="individual section hide">
							<i class="goicon icon-person"></i>
							<header>Individual subscription</header>
							<div class="prompt">
<p>
									Register to get unlimited access to Gigaom Research content.
</p>
<p>
									<a href="https://research.gigaom.com/subscription/sign-up/individual/" class="button">Get started</a>
</p>
</div>
							<div class="subscribed">
<p>
									You're subscribed! Review details <a href="https://accounts.gigaom.com/my-profile/subscription/">here</a>.
</p>
</div>
</div>
						-->
						<div id="go-subscribe-nav-advisory" class="advisory section hide">
							<i class="goicon icon-person"></i>
							<header>Advisory subscription</header>
							<div class="subscribed"></div>
							<div class="prompt"></div>
</div>
						<div id="go-subscribe-nav-enterprise" class="enterprise section">
							<i class="goicon icon-people"></i>
							<header>Corporate subscription</header>
							<div class="subscribed"></div>
							<div class="prompt">
<p>
									Company-wide access to Gigaom Research, analyst briefings or inquiries,
									Gigaom Event tickets &amp; much more.
</p>
<p>
									<a href="http://research.gigaom.com/pricing-corporate-research/" data-tracking-campaign="gorcs" data-tracking-medium="sh" data-tracking-source="gigaom" data-tracking-content="getstarted" data-tracking-term="subscription-header" class="button">Get started</a>
</p>
</div>
</div>
					</li>
				</ul>
</div>
		</li>
				<li class="sub-nav nav-plus">
			<a href="#" class="goicon icon-share-alt control-follow" title="Share"><span class="nav-text">Share</span></a>
						<div class="container share">
				<header class="container-header">Share</header>
				<ul class="content with-icons">
					<li><a href="https://twitter.com/intent/tweet?url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;via=gigaom&#038;text=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid"><i class="goicon icon-twitter"></i>Twitter</a></li>
					<li><a href="https://www.facebook.com/dialog/feed?app_id=180650338636285&#038;link=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;name=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid&#038;description=At+first+glance+it%26%238217%3Bs+hard+to+see+how+the+open-source+software+framework+Hadoop%2C+which+was+developed+for+analyzing+large+data+sets+generated+by+web+sites%2C+would+be+useful+for+the+power+grid+%26%238212%3B+open-source+tools+and+utilities+don%26%238217%3Bt+often+mix.+But+that+was+before+the+smart+%5B%26hellip%3B%5D&#038;caption=Gigaom&#038;redirect_uri=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F"><i class="goicon icon-facebook"></i>Facebook</a></li>
					<li><a href="http://www.linkedin.com/shareArticle?mini=true&#038;url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;title=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid&#038;source=https%3A%2F%2Fgigaom.com&#038;summary=At+first+glance+it%26%238217%3Bs+hard+to+see+how+the+open-source+software+framework+Hadoop%2C+which+was+developed+for+analyzing+large+data+sets+generated+by+web+sites%2C+would+be+useful+for+the+power+grid+%26%238212%3B+open-source+tools+and+utilities+don%26%238217%3Bt+often+mix.+But+that+was+before+the+smart+%5B%26hellip%3B%5D"><i class="goicon icon-linkedin"></i>LinkedIn</a></li>
					<li><a href="http://www.reddit.com/submit?url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;title=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid"><i class="goicon icon-reddit"></i>Reddit</a></li>
					<li><a href="https://plus.google.com/share?url=url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F"><i class="goicon icon-googleplus"></i>Google+</a></li>
					<li><a href="mailto:?subject=Check%20out%20%22How%20to%20Use%20Open-Source%20Hadoop%20for%20the%20Smart%20Grid%22&#038;body=Thought%20you%20might%20enjoy%20this%20%22How%20to%20Use%20Open-Source%20Hadoop%20for%20the%20Smart%20Grid%22%20from%20Katie%20Fehrenbacher%3A%0D%0A%0D%0Ahttps%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F"><i class="goicon icon-email"></i>Email</a></li>
				</ul>
</div>
					</li>
						<li class="nav-search" itemscope itemtype="http://schema.org/WebSite">
											<meta itemprop="url" content="https://gigaom.com"/>
											<form action="https://search.gigaom.com/" method="get" class="search"  itemprop="potentialAction" itemscope itemtype="http://schema.org/SearchAction">
											<meta itemprop="target" content="https://search.gigaom.com/property/gigaom/s?q={s}"/>
												<input type="text" placeholder="Search" name="s" required/>
					</form>
					<a href="#" class="goicon icon-search" title="Search"></a>
				</li>
			</ul>
</div>
	</section>
	<div class="header secondary">
		<div class="row">
			<div class="channels left">
				<ul id="menu-topics" class="content"><li id="menu-item-919085" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-919085"><a title="Apple" href="/channel/apple/">Apple</a></li>
<li id="menu-item-599793" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599793"><a title="Cloud" href="/channel/cloud/">Cloud</a></li>
<li id="menu-item-599794" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599794"><a title="Data" href="/channel/data/">Data</a></li>
<li id="menu-item-599797" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599797"><a title="Media" href="/channel/media/">Media</a></li>
<li id="menu-item-599796" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599796"><a title="Mobile" href="/channel/mobile/">Mobile</a></li>
<li id="menu-item-599792" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599792"><a title="Science &amp; Energy" href="/channel/science-energy/">Science &amp; Energy</a></li>
<li id="menu-item-855073" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-855073"><a title="Social &amp; Web" href="/channel/social-web/">Social &amp; Web</a></li>
<li id="menu-item-823141" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-823141"><a href="https://gigaom.com/podcasts/">Podcasts</a></li>
</ul>			</div>
</div>
</div>
	<div class="header tertiary clearfix"></div>
</nav>
		<div id="bump-down">
			<div id="text-5" class="widget clearfix widget_text">			<div class="textwidget"><div id="research-ribbon-cta" class="research-ribbon-cta">

<a href="http://research.gigaom.com/pricing-corporate-research/">

<span class="ribbon-text">

<b>Gigaom Research.</b> Get unlimited market intelligence from over 200 independent analysts. 

</span>

</a>

</div></div>
</div>		</div>
<div id="main" class="row">
			<div id="body" class="small-12 columns">
			<div class="main" role="main">
				<div id="postloop-47" class="post-page widget-post_loop- widget clearfix widget_postloop"><aside id="pre-content"><div id="go-ads-20" class="widget clearfix widget-go-ads">		<div id="ad-a-container" class="ad go-ad ad-300x250">
			<div class="advertisement-notice">Advertisement</div>
			<div class="ad-container" id="ad-a"
				data-ad-dfp="/31971080/science_energy_300x250_a"
				data-ad-slot="science_energy_300x250_a"
				data-ad-width="300"
				data-ad-height="250"
			>
				<!-- DFP AD SLOT: science_energy_300x250_a -->
</div>
</div>
</div></aside>
<nav id="post-navigation"><a href="https://gigaom.com/2009/06/02/a-tale-of-two-parties-games-get-glitz-while-tv-tones-down/" rel="prev"><span>A Tale of Two Parties: Games Get Glitz While TV Tones Down</span><i class="goicon icon-chevron-right"></i></a></nav>
<article id="post-33266" class="Arrayclearfix post-comments-disabled no-thumb clearfix title-starts-with-H post-page-article missing-featured-image post-33266 post type-post status-publish format-standard hentry category-cnn-green category-energy category-nyt-enterprise category-syn-feature-enterprise tag-google tag-hadoop channel-cleantech channel-data channel-science-energy primary_channel-cleantech primary_channel-science-energy go-post-standard legacy-post featured-image-focus-center" itemscope itemtype="http://schema.org/NewsArticle">
			<ul class="inline-list text-scale">
			<li id="go-post-sub-head-text-scale-smaller" class="smaller">
				<a href="" title="Decrease font size">A</a>
			</li>
			<li id="go-post-sub-head-text-scale-larger" class="larger">
				<a href="" title="Increase font size">A</a>
			</li>
		</ul>
				<section id="go-post-header-post-social-1" class="post-social ">
			<ul class="social">
				<li class="twitter">
					<a href="https://twitter.com/intent/tweet?url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;via=gigaom&#038;text=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid" title="Share on Twitter" class="goicon icon-twitter-circled"></a>
				</li>
				<li class="facebook">
					<a href="https://www.facebook.com/dialog/feed?app_id=180650338636285&#038;link=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;name=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid&#038;description=At+first+glance+it%26%238217%3Bs+hard+to+see+how+the+open-source+software+framework+Hadoop%2C+which+was+developed+for+analyzing+large+data+sets+generated+by+web+sites%2C+would+be+useful+for+the+power+grid+%26%238212%3B+open-source+tools+and+utilities+don%26%238217%3Bt+often+mix.+But+that+was+before+the+smart+%5B%26hellip%3B%5D&#038;caption=Gigaom&#038;redirect_uri=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F" title="Share on Facebook" class="goicon icon-facebook-circled"></a>
				</li>
				<li class="linkedin">
					<a href="http://www.linkedin.com/shareArticle?mini=true&#038;url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;title=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid&#038;source=https%3A%2F%2Fgigaom.com&#038;summary=At+first+glance+it%26%238217%3Bs+hard+to+see+how+the+open-source+software+framework+Hadoop%2C+which+was+developed+for+analyzing+large+data+sets+generated+by+web+sites%2C+would+be+useful+for+the+power+grid+%26%238212%3B+open-source+tools+and+utilities+don%26%238217%3Bt+often+mix.+But+that+was+before+the+smart+%5B%26hellip%3B%5D" title="Share on LinkedIn" class="goicon icon-linkedin-circled"></a>
				</li>
				<li class="more">
					<a href="#" title="More" class="goicon icon-follow"></a>
				</li>
				<li class="reddit">
					<a href="http://www.reddit.com/submit?url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;title=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid" title="Share on Reddit" class="goicon icon-reddit-circled"></a>
				</li>
				<li class="googleplus">
					<a href="https://plus.google.com/share?url=url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F" title="Share on Google+" class="goicon icon-googleplus-circled"></a>
				</li>
				<li class="email">
					<a href="mailto:?subject=Check%20out%20%22How%20to%20Use%20Open-Source%20Hadoop%20for%20the%20Smart%20Grid%22&#038;body=Thought%20you%20might%20enjoy%20this%20%22How%20to%20Use%20Open-Source%20Hadoop%20for%20the%20Smart%20Grid%22%20from%20Katie%20Fehrenbacher%3A%09%09https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F" title="Share via Email" class="goicon icon-email-circled"></a>
				</li>
			</ul>
		</section>
			<header class="head entry-header">
		<div class="head-inner">
			<h1 id="go-post-header-entry-title" class="entry-title" itemprop="headline">
				How to Use Open-Source Hadoop for the Smart Grid			</h1>
			<section class="post-meta">
				<div class="meta-row" >
					<div class="by">
						<span class="vcard"><span class="author fn">Katie Fehrenbacher</span></span>					</div>
					<time class="time published" datetime="2009-06-02T21:00:33-07:00" title="2009/06/02 9:00:33 PM" itemprop="datePublished">
						Jun. 2, 2009 - 9:00 PM PDT					</time>
					<time class="time updated" datetime="2009-06-02T21:00:33-07:00" title="2009/06/02 9:00:33 PM" itemprop="dateModified">
						Jun. 2, 2009 - 9:00 PM PDT					</time>
</div>
									<div class="comments-title" id="comment-count" data-comment-count="4">
						<a href="https://gigaom.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/#comments"><span class="comment-bubble">4</span> Comments</a>					</div>
								</section>
</div>
	</header>
		<section class="body entry-content" itemprop="articleBody">
		<div class="container" id="post-content-33266">
<p>At first glance it&#8217;s hard to see how the open-source software framework <a href="http://ostatic.com/hadoop">Hadoop</a>, which was developed for analyzing large data sets generated by web sites, would be useful for the power grid &#8212; open-source tools and utilities don&#8217;t often mix. But that was before the smart grid and its IT tools started to squeeze their way into the energy industry. Hadoop is in fact now being used by the <a href="http://www.tva.gov/abouttva/index.htm">Tennessee Valley Authority (TVA)</a> and the North American Electric Reliability Corp. (NERC) to aggregate and process data about the health of the power grid, <a href="http://www.cloudera.com/blog/2009/06/02/smart-grid-big-data-hadoop-tennessee-valley-authority-tva/">according to this blog post from Cloudera</a>, a startup that&#8217;s commercializing Hadoop.</p>
<p>The TVA is collecting data about the reliability of electricity on the power grid using phasor measurement unit (PMU) devices. NERC has designated the TVA system as the national repository of such electrical data; it subsequently aggregates info from more than 100 PMU devices, including voltage, current, frequency and location, using GPS, several thousand times a second. Talk about information overload.</p>
<p>But TVA says Hadoop is a low-cost way to manage this massive amount of data so that it can be accessed all the time. Why? Because Hadoop has been designed to run on a lot of cheap commodity computers and uses two distributed features that make the system more reliable and easier to use to run processes on large sets of data.<br />
<span id="more-33266"></span></p>
<p>The first important feature is Hadoop&#8217;s Distributed File System. It&#8217;s modeled on Google&#8217;s File System, which distributes file system data across multiple servers and maintains multiple copies of all of it. The idea is that there will often be system failures, so when one server goes down, the information can still be accessed. Further, the system is able to constantly restore outages. <a href="http://www.cloudera.com/blog/2009/06/02/smart-grid-big-data-hadoop-tennessee-valley-authority-tva/">The TVA says it</a> &#8220;liked the idea of being able to lose whole physical machines and still have an operational file system due to Hadoop’s aggressive replication scheme.&#8221;</p>
<p>The other key part of Hadoop&#8217;s software is a Distributed Processing Framework, which uses an algorithm popularized by Google called &#8220;MapReduce&#8221; to partition compute jobs out to hundreds or thousands of nodes. MapReduce divides applications into bite-sized chunks of work across servers, processing the data where it is located. The TVA says it likes this feature because NERC and its researchers can access and run operations on the electrical data across the servers, in parallel, for quick results.</p>
<p><a href="http://www.cloudera.com/blog/2009/06/02/smart-grid-big-data-hadoop-tennessee-valley-authority-tva/">For the TVA, it&#8217;s about performance and price</a>, according to Cloudera&#8217;s blog post:</p>
<blockquote><p>In the end, Hadoop is a good fit for this project in that it allows us to employ commodity hardware and open source software at a fraction of the price of proprietary systems to achieve a much more manageable expenditure curve as our repository grows.</p></blockquote>
<p>Given all the information that will be unearthed via the buildout of new transmission and distribution systems, as well as via the home energy management tools that emerge as part of the smart grid, cheap, powerful tools like Hadoop will inevitably make their way through even more industries, even ones in which terms like open source aren&#8217;t yet commonplace.</p>
</div>
				<aside id="hidden-sidebar"><div id="go-ads-24" class="widget clearfix widget-go-ads">		<div id="ad-b-container" class="ad go-ad ad-300x250">
			<div class="advertisement-notice">Advertisement</div>
			<div class="ad-container" id="ad-b"
				data-ad-dfp="/31971080/science_energy_300x250_b"
				data-ad-slot="science_energy_300x250_b"
				data-ad-width="300"
				data-ad-height="250"
			>
				<!-- DFP AD SLOT: science_energy_300x250_b -->
</div>
</div>
</div><div id="go-ads-25" class="widget clearfix widget-go-ads">		<div id="ad-d-container" class="ad go-ad ad-300x600">
			<div class="advertisement-notice">Advertisement</div>
			<div class="ad-container" id="ad-d"
				data-ad-dfp="/31971080/science_energy_300x600"
				data-ad-slot="science_energy_300x600"
				data-ad-width="300"
				data-ad-height="600"
			>
				<!-- DFP AD SLOT: science_energy_300x600 -->
</div>
</div>
</div><div id="go-ads-26" class="widget clearfix widget-go-ads">		<div id="ad-c-container" class="ad go-ad ad-300x250">
			<div class="advertisement-notice">Advertisement</div>
			<div class="ad-container" id="ad-c"
				data-ad-dfp="/31971080/science_energy_300x250_c"
				data-ad-slot="science_energy_300x250_c"
				data-ad-width="300"
				data-ad-height="250"
			>
				<!-- DFP AD SLOT: science_energy_300x250_c -->
</div>
</div>
</div></aside>
	</section>
</article>
<script>
// called here so we can resize the featured image area as early as possible.
if ( 'undefined' !== typeof gigaom_resize_post_head ) {
	gigaom_resize_post_head();
	gigaom_inline_image_attribution();
}//end if
</script>
</div><div id="go-widget-areas-9" class="row go-related-container"><div data-remove-on-inject-classes="medium-6 columns " class="medium-6 columns  related-left go-custom-widget-area_related-left widget clearfix widget-go-widget-areas widget-area"></div><div data-remove-on-inject-classes="medium-6 columns " class="medium-6 columns  related-right go-custom-widget-area_related-right widget clearfix widget-go-widget-areas widget-area"><div id="postloop-49" class="go-related-with-thumbnail widget-post_loop-related-research widget"><header class="widget-title subheader">Related research</header><div class="widget_subtitle">Subscriber content</div>	<span id='related-research-target' class='goicon icon-question-mark'>?</span>
	<div class='boxed bumpdown' data-trigger='related-research-target'>
<p>
			Subscriber content comes from Gigaom Research, bridging the gap between breaking news and long-tail research. Visit any of our reports to learn more and subscribe.
</p>
</div>
	<ul>
<li class="related-post">
	<a
		class="title"
		href="http://research.gigaom.com/report/outlook-big-data-and-analytics-in-2015/"
		rel="bookmark"
		title="Permanent Link to Data and analytics trends to watch in 2015"
		data-tracking-source="science-energy"
		data-tracking-medium="editorial"
		data-tracking-campaign="auto3"
		data-tracking-term="33266 how-to-use-open-source-hadoop-for-the-smart-grid"
		data-tracking-content="katiefehren"
	>
		<span class="thumbnail">
			<img width="48" height="48" src="https://gigaom.com/wp-content/uploads/sites/1/2014/12/iStock_000020343192_Small-48x48.jpg" class="attachment-small-square-thumbnail wp-post-image" alt="iStock_000020343192_Small" />		</span>
		Data and analytics trends to watch in 2015	</a>
</li>
<li class="related-post">
	<a
		class="title"
		href="http://research.gigaom.com/report/apache-hadoop-is-one-cluster-enough/"
		rel="bookmark"
		title="Permanent Link to What new Hadoop solutions mean for managing data"
		data-tracking-source="science-energy"
		data-tracking-medium="editorial"
		data-tracking-campaign="auto3"
		data-tracking-term="33266 how-to-use-open-source-hadoop-for-the-smart-grid"
		data-tracking-content="katiefehren"
	>
		<span class="thumbnail">
			<img width="48" height="48" src="https://gigaom.com/wp-content/uploads/sites/1/2014/12/iStock_000026682171_Small-48x48.jpg" class="attachment-small-square-thumbnail wp-post-image" alt="iStock_000026682171_Small" />		</span>
		What new Hadoop solutions mean for managing data	</a>
</li>
</ul>
</div></div></div><div id="postloop-50" class="post-page-tags widget-post_loop-post-tags widget clearfix widget_postloop">	<header>Tags:</header>
	<ul class='breadcrumbs sorted_tags' itemprop='keywords'>
	<li><a href="https://search.gigaom.com/tag/google/" title="Google">Google</a></li>
	<li><a href="https://search.gigaom.com/tag/hadoop/" title="Hadoop">Hadoop</a></li>
</ul>
</div><div id="go-local-bsocial-cta-6" class="widget clearfix go-bsocial-cta">		<div id="injected-newsletter-2" class="cta-section cta-section-newsletter clearfix Cleantech">
				<form enctype="application/x-www-form-urlencoded" class="go-local-bsocial-newsletter-form go-standard" method="post" action="https://accounts.gigaom.com/newsletters/" target="_blank" data-identity-server="https://accounts.gigaom.com">

				<input type="hidden" name="timestamp" value="1443847434" />
				<input type="hidden" name="hash" value="1673212d9221411c00f0069a7588c606"/>
				<input type="hidden" name="newsletterSave" value="save" />
				<input type="hidden" name="merge_existing_subscriptions" value="merge" />
										<input type="hidden" name="lists[daily][]" value="apple" />
												<input type="hidden" name="lists[daily][]" value="cloud" />
												<input type="hidden" name="lists[daily][]" value="data" />
												<input type="hidden" name="lists[daily][]" value="europe" />
												<input type="hidden" name="lists[daily][]" value="media" />
												<input type="hidden" name="lists[daily][]" value="mobile" />
												<input type="hidden" name="lists[daily][]" value="science-energy" />
												<input type="hidden" name="lists[daily][]" value="social-web" />
												<input type="hidden" name="lists[daily][]" value="tech" />
												<input type="hidden" name="lists[daily][]" value="video" />
						Get all the news you need about Cleantech with the Gigaom newsletter				<p class="form-elements go-field-button">
					<input type="email" name="email" value="" placeholder="Enter email address"/>
					<button class="button">Subscribe</button>
</p>
			</form>
			<div class="subscribed">
<p>
					You're subscribed! If you like, you can <a href="https://accounts.gigaom.com/newsletters/">update your settings</a>
</p>
</div>
</div>
		<script>
		// when this is added to the page, publish that that has occurred
			jQuery( function( $ ) {
				amplify.publish('go-local-bsocial-cta-loaded');
			});
		</script>
		
<script>
	jQuery( function( $ ) {
		// when this is added to the page, publish that that has occurred
		amplify.publish('go-local-bsocial-cta-loaded');
	});
</script>
</div><div id="go-ads-21" class="widget clearfix widget-go-ads">		<div id="ad-billboard-container" class="ad go-ad ad-970x250">
			<div class="advertisement-notice">Advertisement</div>
			<div class="ad-container" id="ad-billboard"
				data-ad-dfp="/31971080/science_energy_billboard"
				data-ad-slot="science_energy_billboard"
				data-ad-width="970"
				data-ad-height="250"
			>
				<!-- DFP AD SLOT: science_energy_billboard -->
</div>
</div>
</div><div id="go-ads-22" class="widget clearfix widget-go-ads">		<div id="ad-comment1-container" class="ad go-ad ad-300x250">
			<div class="advertisement-notice">Advertisement</div>
			<div class="ad-container" id="ad-comment1"
				data-ad-dfp="/31971080/science_energy_300x250_d"
				data-ad-slot="science_energy_300x250_d"
				data-ad-width="300"
				data-ad-height="250"
			>
				<!-- DFP AD SLOT: science_energy_300x250_d -->
</div>
</div>
</div><div id="go-ads-23" class="widget clearfix widget-go-ads">		<div id="ad-comment2-container" class="ad go-ad ad-300x250">
			<div class="advertisement-notice">Advertisement</div>
			<div class="ad-container" id="ad-comment2"
				data-ad-dfp="/31971080/science_energy_300x250_e"
				data-ad-slot="science_energy_300x250_e"
				data-ad-width="300"
				data-ad-height="250"
			>
				<!-- DFP AD SLOT: science_energy_300x250_e -->
</div>
</div>
</div>			<div id="comments-list">
				<div id="comments" class="comments-area clearfix user-cannot-comment post-comments-disabled">
	<div id="comment-form-top">
</div>
			<div id="comment-list-inner" class="clearfix">
			<div id="go-comments-7" class="widget clearfix widget-go-comments">		<span class="wijax-page-varnames" style="display: none;">
			["wijax_c9028bad6424c648de4d8006b6980981","wijax_8aec5fef8c5f2ff3041b841572dcfb17"]		</span>
		<div
			class="wijax-container"
			data-wijax-source="https://gigaom.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/wijax/3a86a588f2a35f7c9f8e1f69f25b2f6a"
			data-wijax-varname="wijax_a708bac84d42c594388102dfb6f01e23"
			data-wijax-title-element="header"
			data-wijax-title-class="widget-title"
			data-wijax-title-before="%3Cheader%20class%3D%22widget-title%22%3E"
			data-wijax-title-after="%3C%2Fheader%3E"
			data-current-page="1"
			data-total-comments="4"
		>
			<span class="wijax-loading">
				<a href="https://gigaom.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/wijax/3a86a588f2a35f7c9f8e1f69f25b2f6a" class="wijax-source wijax-onload" rel="nofollow"><img src="https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-social-comments/components/images/ajax-loader.gif" alt="loading"></a>
				<span class="wijax-opts" style="display: none;">
					{"source":"https:\/\/gigaom.com\/2009\/06\/02\/how-to-use-open-source-hadoop-for-the-smart-grid\/wijax\/3a86a588f2a35f7c9f8e1f69f25b2f6a","varname":"wijax_a708bac84d42c594388102dfb6f01e23","title_element":"header","title_class":"widget-title","title_before":"%3Cheader%20class%3D%22widget-title%22%3E","title_after":"%3C%2Fheader%3E"}				</span>
			</span>
</div>
</div>		</div>
		<div id="comment-form-bottom"></div>
</div>
	<div class="comments-disabled">
		<i class="goicon huge icon-comments-off"></i>
<p>
			Comments have been disabled for this post
</p>
</div>
</div>
</div>
</div>
</div>
<div id="pre-footer-area">
	<div id="go-ads-12" class="widget clearfix widget-go-ads">		<div id="add-billboard-container" class="ad go-ad ad-970x250">
			<div class="advertisement-notice">Advertisement</div>
			<div class="ad-container" id="add-billboard"
				data-ad-dfp="/31971080/science_energy_billboard"
				data-ad-slot="science_energy_billboard"
				data-ad-width="970"
				data-ad-height="250"
			>
				<!-- DFP AD SLOT: science_energy_billboard -->
</div>
</div>
</div></div>
<footer id="foot">
	<div class="property">
		<div class="row">
						<div class="topics">
				<ul id="menu-topics-1" class="content"><li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-919085"><a title="Apple" href="/channel/apple/">Apple</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599793"><a title="Cloud" href="/channel/cloud/">Cloud</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599794"><a title="Data" href="/channel/data/">Data</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599797"><a title="Media" href="/channel/media/">Media</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599796"><a title="Mobile" href="/channel/mobile/">Mobile</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599792"><a title="Science &amp; Energy" href="/channel/science-energy/">Science &amp; Energy</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-855073"><a title="Social &amp; Web" href="/channel/social-web/">Social &amp; Web</a></li>
<li class="menu-item menu-item-type-post_type menu-item-object-page menu-item-823141"><a href="https://gigaom.com/podcasts/">Podcasts</a></li>
</ul>			</div>
</div>
</div>
	<div class="all">
		<div class="row">
		<div class="small-12 columns">
				<div class="row">
					<div class="small-12 large-5 small-centered columns share">
						<a href="http://gigaom.com" rel="publisher" title="Gigaom">
							<span class="logo"><span class="logo-svg"><svg role="img" aria-label="Gigaom Logo" xmlns="http://www.w3.org/2000/svg" version="1.1" class="gigaom-logo" x="0" y="0" width="125.49" height="40.52" viewBox="0 0 125.49 40.52" enable-background="new 0 0 125.49 40.523" xml:space="preserve"><title>Gigaom</title><desc>Gigaom Logo</desc><path fill="#FFFFFF" d="M28.51 17.86h-8.41v3.41h3.85c-0.67 1.55-2.07 2.47-3.78 2.47 -2.53 0-4.52-2.01-4.52-4.57 0-2.63 1.87-4.61 4.35-4.61 1.45 0 2.54 0.55 3.55 1.79l0.09 0.1 3.16-2.44 -0.09-0.11c-1.65-2.04-4.13-3.2-6.82-3.2 -4.8 0-8.42 3.63-8.42 8.45 0 4.78 3.64 8.38 8.47 8.38 2.2 0 4.3-0.81 5.92-2.28 1.81-1.64 2.7-3.74 2.7-6.41 0-0.14 0-0.53-0.02-0.85L28.51 17.86z"/><rect x="30.68" y="10.95" fill="#FFFFFF" width="4.2" height="16.28"/><path fill="#FFFFFF" d="M54.07 17.86h-8.41v3.41h3.85c-0.67 1.55-2.07 2.47-3.78 2.47 -2.53 0-4.52-2.01-4.52-4.57 0-2.63 1.87-4.61 4.35-4.61 1.45 0 2.55 0.55 3.55 1.79l0.08 0.1 3.16-2.44 -0.09-0.11c-1.65-2.04-4.13-3.2-6.81-3.2 -4.8 0-8.43 3.63-8.43 8.45 0 4.78 3.65 8.38 8.47 8.38 2.2 0 4.3-0.81 5.92-2.28 1.81-1.64 2.7-3.74 2.7-6.41 0-0.14 0-0.53-0.02-0.85L54.07 17.86z"/><path fill="#FFFFFF" d="M66.84 27.23l-0.81-2.34h-6.42l-0.8 2.34h-4.76l6.13-16.28h5.28l6.15 16.28H66.84zM62.81 15.1l-2.08 6.13h4.15L62.81 15.1z"/><path fill="#009BFF" d="M71.75 19.1c0-5.11 3.85-8.68 8.98-8.68 5.13 0 8.95 3.57 8.95 8.68 0 5.11-3.82 8.68-8.95 8.68C75.59 27.78 71.75 24.21 71.75 19.1M85.27 19.1c0-2.74-1.78-4.85-4.55-4.85 -2.79 0-4.58 2.11-4.58 4.85 0 2.72 1.79 4.86 4.58 4.86C83.49 23.96 85.27 21.82 85.27 19.1"/><path fill="#FFFFFF" d="M103.02 10.95l-3.42 8.84 -3.39-8.84h-6.23v0.47c1.71 2.09 2.73 4.76 2.73 7.67 0 2.91-1.02 5.58-2.73 7.67v0.48h4.59V16.63l4.1 10.6h1.86l4.13-10.6V27.23h4.59V10.95H103.02z"/></svg></span></span>						</a>
</div>
</div>
</div>
			<div class="small-12 columns">
				<ul class="properties">
					<li><a href="http://gigaom.com">News</a></li>
					<li><a href="http://research.gigaom.com">Research</a></li>
				</ul>
</div>
			<div class="small-12 columns about">
				<ul id="menu-footer" class="content"><li id="menu-item-601821" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-601821"><a href="/about/">About</a></li>
<li id="menu-item-601825" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-601825"><a href="/about/contact/">Contact</a></li>
<li id="menu-item-601819" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-601819"><a href="/privacy-policy/">Privacy Policy</a></li>
<li id="menu-item-601820" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-601820"><a href="/terms-of-service/">Terms of Service</a></li>
</ul>			</div>
			<div class="small-12 columns">
				<div class="row">
					<div class="small-12 large-4 small-centered columns share">
								<ul class="share-list">
			<li><a href="https://twitter.com/gigaom" class="goicon icon-twitter" title="Share on Twitter"></a></li>
			<li><a href="https://www.facebook.com/Gigaom" class="goicon icon-facebook" title="Share on Facebook"></a></li>
			<li><a href="http://www.linkedin.com/company/gigaom" class="goicon icon-linkedin" title="Share on LinkedIn"></a></li>
		</ul>
</div>
</div>
</div>
			<div class="small-12 columns copyright">
				2015				<a href="https://www.knowingly.com/" title="Knowingly, Inc.">Knowingly, Inc.</a>
				All Rights Reserved.
</div>
</div>
</div>
</footer>
</div>
</div>
<nav id="sidepanel-primary" class="sidepanel primary left">
	<ul class="links">
		<li class="menu-item home"><a href="https://gigaom.com/">Home</a></li>		<li class="topics">
			<ul id="menu-topics-2" class="content"><li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-919085"><a title="Apple" href="/channel/apple/">Apple</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599793"><a title="Cloud" href="/channel/cloud/">Cloud</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599794"><a title="Data" href="/channel/data/">Data</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599797"><a title="Media" href="/channel/media/">Media</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599796"><a title="Mobile" href="/channel/mobile/">Mobile</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599792"><a title="Science &amp; Energy" href="/channel/science-energy/">Science &amp; Energy</a></li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-855073"><a title="Social &amp; Web" href="/channel/social-web/">Social &amp; Web</a></li>
<li class="menu-item menu-item-type-post_type menu-item-object-page menu-item-823141"><a href="https://gigaom.com/podcasts/">Podcasts</a></li>
</ul>		</li>
		<li class="properties">
			<ul>
				<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-599787"><a title="Research" href="http://research.gigaom.com/">Research</a></li>
			</ul>
		</li>
				<li class="sub-nav nav-subscribe">
			<a href="#" class="control-subscribe" title="Subscribe">Subscribe</a>
			<div class="container">
				<ul>
					<li class="blog">
						<header class="subheader">Gigaom</header>
						<div id="go-subscribe-nav-newsletter-sidepanel" class="newsletter section" data-blockui-overlay-bg="#111C29" data-blockui-opacity="0.8">
							<i class="goicon icon-megaphone"></i>
							<header>Newsletters</header>
									<div id="injected-newsletter-3" class="cta-section cta-section-newsletter clearfix ">
				<form enctype="application/x-www-form-urlencoded" class="go-local-bsocial-newsletter-form go-standard" method="post" action="https://accounts.gigaom.com/newsletters/" target="_blank" data-identity-server="https://accounts.gigaom.com">

				<input type="hidden" name="timestamp" value="1443847434" />
				<input type="hidden" name="hash" value="1673212d9221411c00f0069a7588c606"/>
				<input type="hidden" name="newsletterSave" value="save" />
				<input type="hidden" name="merge_existing_subscriptions" value="merge" />
											<input type="hidden" name="lists[daily][]" value="tech" />
														<input type="hidden" name="lists[daily][]" value="cloud" />
														<input type="hidden" name="lists[daily][]" value="data" />
														<input type="hidden" name="lists[daily][]" value="media" />
														<input type="hidden" name="lists[daily][]" value="mobile" />
														<input type="hidden" name="lists[daily][]" value="science-energy" />
														<input type="hidden" name="lists[daily][]" value="social-web" />
														<input type="hidden" name="lists[pro][]" value="weeklyupdate" />
														<input type="hidden" name="lists[offers][]" value="offers" />
														<input type="hidden" name="lists[offers][]" value="events" />
														<input type="hidden" name="lists[offers][]" value="webinars" />
														<input type="hidden" name="lists[offers][]" value="research" />
														<input type="hidden" name="lists[omsays][]" value="omsays" />
							Don't miss out. Sign up to get all the news you need delivered right to your inbox.				<p class="form-elements go-field-button">
					<input type="email" name="email" value="" placeholder="Enter email address"/>
					<button class="button">Get started</button>
</p>
			</form>
			<div class="subscribed">
<p>
					You're subscribed! If you like, you can <a href="https://accounts.gigaom.com/newsletters/">update your settings</a>
</p>
</div>
</div>
		<script>
		// when this is added to the page, publish that that has occurred
			jQuery( function( $ ) {
				amplify.publish('go-local-bsocial-cta-loaded');
			});
		</script>
</div>
					</li>
					<li class="research">
						<header class="subheader">Gigaom Research</header>
						<div id="go-subscribe-nav-subscription-sidepanel" class="subscription section">
							<i class="goicon icon-person"></i>
							<header>Individual subscription</header>
							<div class="prompt">
<p>
									Register for a free 7 day trial.
</p>
<p>
									<a href="https://research.gigaom.com/subscription/sign-up/" class="button">Get started</a>
</p>
</div>
							<div class="subscribed">
<p>
									You're subscribed! Review details <a href="https://accounts.gigaom.com/my-profile/subscription/">here</a>.
</p>
</div>
</div>
						<!-- 
						<div id="go-subscribe-nav-individual-sidepanel" class="individual section hide">
							<i class="goicon icon-person"></i>
							<header>Individual subscription</header>
							<div class="prompt">
<p>
									Register to get unlimited access to Gigaom Research content.
</p>
<p>
									<a href="https://research.gigaom.com/subscription/sign-up/individual/" class="button">Get started</a>
</p>
</div>
							<div class="subscribed">
<p>
									You're subscribed! Review details <a href="https://accounts.gigaom.com/my-profile/subscription/">here</a>.
</p>
</div>
</div>
						-->
						<div id="go-subscribe-nav-advisory-sidepanel" class="advisory section hide">
							<i class="goicon icon-person"></i>
							<header>Advisory subscription</header>
							<div class="subscribed"></div>
							<div class="prompt"></div>
</div>
						<div id="go-subscribe-nav-enterprise-sidepanel" class="enterprise section">
							<i class="goicon icon-people"></i>
							<header>Corporate subscription</header>
							<div class="subscribed"></div>
							<div class="prompt">
<p>
									Company-wide access to Gigaom Research, analyst briefings or inquiries,
									Gigaom Event tickets &amp; much more.
</p>
<p>
									<a href="http://research.gigaom.com/pricing-corporate-research/" data-tracking-campaign="gorcs" data-tracking-medium="sh" data-tracking-source="gigaom" data-tracking-content="getstarted" data-tracking-term="subscription-header" class="button">Get started</a>
</p>
</div>
</div>
					</li>
				</ul>
</div>
		</li>
			</ul>
</nav>
<nav id="sidepanel-follow" class="sidepanel follow right">
	<ul class="links follow">
		<li>
						<div class="container share">
				<header class="container-header">Share</header>
				<ul class="content with-icons">
					<li><a href="https://twitter.com/intent/tweet?url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;via=gigaom&#038;text=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid"><i class="goicon icon-twitter"></i>Twitter</a></li>
					<li><a href="https://www.facebook.com/dialog/feed?app_id=180650338636285&#038;link=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;name=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid&#038;description=At+first+glance+it%26%238217%3Bs+hard+to+see+how+the+open-source+software+framework+Hadoop%2C+which+was+developed+for+analyzing+large+data+sets+generated+by+web+sites%2C+would+be+useful+for+the+power+grid+%26%238212%3B+open-source+tools+and+utilities+don%26%238217%3Bt+often+mix.+But+that+was+before+the+smart+%5B%26hellip%3B%5D&#038;caption=Gigaom&#038;redirect_uri=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F"><i class="goicon icon-facebook"></i>Facebook</a></li>
					<li><a href="http://www.linkedin.com/shareArticle?mini=true&#038;url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;title=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid&#038;source=https%3A%2F%2Fgigaom.com&#038;summary=At+first+glance+it%26%238217%3Bs+hard+to+see+how+the+open-source+software+framework+Hadoop%2C+which+was+developed+for+analyzing+large+data+sets+generated+by+web+sites%2C+would+be+useful+for+the+power+grid+%26%238212%3B+open-source+tools+and+utilities+don%26%238217%3Bt+often+mix.+But+that+was+before+the+smart+%5B%26hellip%3B%5D"><i class="goicon icon-linkedin"></i>LinkedIn</a></li>
					<li><a href="http://www.reddit.com/submit?url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&#038;title=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid"><i class="goicon icon-reddit"></i>Reddit</a></li>
					<li><a href="https://plus.google.com/share?url=url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F"><i class="goicon icon-googleplus"></i>Google+</a></li>
					<li><a href="mailto:?subject=Check%20out%20%22How%20to%20Use%20Open-Source%20Hadoop%20for%20the%20Smart%20Grid%22&#038;body=Thought%20you%20might%20enjoy%20this%20%22How%20to%20Use%20Open-Source%20Hadoop%20for%20the%20Smart%20Grid%22%20from%20Katie%20Fehrenbacher%3A%0D%0A%0D%0Ahttps%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F"><i class="goicon icon-email"></i>Email</a></li>
				</ul>
</div>
					</li>
	</ul>
</nav>
<nav id="sidepanel-account" class="sidepanel account right">
	<ul class="links">
	</ul>
</nav>

<div id="wp_footer">		<script type='text/javascript'>
		var googletag = googletag || {};
		googletag.cmd = googletag.cmd || [];
		(function() {
		var gads = document.createElement('script');
		gads.async = true;
		gads.type = 'text/javascript';
		var useSSL = 'https:' == document.location.protocol;
		gads.src = (useSSL ? 'https:' : 'http:') +
		'//www.googletagservices.com/tag/js/gpt.js';
		var node = document.getElementsByTagName('script')[0];
		node.parentNode.insertBefore(gads, node);
		})();
		</script>
				<script>
			(function(d) {
				var config = {
					kitId: 'egz8uhv',
					scriptTimeout: 3000
				},
				h=d.documentElement,t=setTimeout(function(){h.className=h.className.replace(/\bwf-loading\b/g,"")+" wf-inactive";},config.scriptTimeout),tk=d.createElement("script"),f=false,s=d.getElementsByTagName("script")[0],a;h.className+=" wf-loading";tk.src='//use.typekit.net/'+config.kitId+'.js';tk.async=true;tk.onload=tk.onreadystatechange=function(){a=this.readyState;if(f||a&&a!="complete"&&a!="loaded")return;f=true;clearTimeout(t);try{Typekit.load(config)}catch(e){}};s.parentNode.insertBefore(tk,s)
			})(document);
		</script>
		<div id="go-remote-identity-login-form">
	<div class="logging-in">
		<header>Signing in...</header>
</div>
	<form id="go-remote-identity-login" action="https://accounts.gigaom.com/subscription/sign-in/" enctype="application/x-www-form-urlencoded" method="post" class="login clearfix">
		<header>Sign in</header>
		<input type="hidden" name="redirect_to" value="https://gigaom.com/2009/06/02/how-to-use-open-source-hadoop-for-the-smart-grid/" id="redirect_to">
		<ul>
			<li class="email">
				<label for="go-remote-identity-log">Email address</label>
				<input type="email" name="log" id="go-remote-identity-log">
			</li>
			<li class="password">
				<label for="go-remote-identity-pwd">Password</label>
				<input type="password" name="pwd" id="go-remote-identity-pwd">
			</li>
			<li class="remember">
				<label for="rememberme">Remember me</label>
				<input type="checkbox" name="rememberme" value="forever" id="rememberme">
			</li>
			<li class="actions">
				<button class="button action-button submit" type="submit">Continue</button>
				<a href="" class="forgot-password">Forgot your password?</a>
			</li>
		</ul>
	</form>
	<div class="social">
		<header>Or sign in via social media</header>
		<ul class="buttons">
			<li class="linkedin">
				<a href="https://accounts.gigaom.com?goauth_start=1&#038;goauth_action=loginoverlay&#038;goauth_service=linkedin&#038;type=authenticate&#038;loc=%2F%3Fgoauth_action%3Dclosewindow" rel="nofollow"><i class="goicon icon-linkedin"></i>LinkedIn</a>
			</li>
			<li class="twitter">
				<a href="https://accounts.gigaom.com?goauth_start=1&#038;goauth_action=loginoverlay&#038;goauth_service=twitter&#038;type=authenticate&#038;loc=%2F%3Fgoauth_action%3Dclosewindow" rel="nofollow"><i class="goicon icon-twitter"></i>Twitter</a>
			</li>
			<li class="facebook">
				<a href="https://accounts.gigaom.com?goauth_start=1&#038;goauth_action=loginoverlay&#038;goauth_service=facebook&#038;type=authenticate&#038;loc=%2F%3Fgoauth_action%3Dclosewindow" rel="nofollow"><i class="goicon icon-facebook"></i>Facebook</a>
			</li>
		</ul>
		<a href="" class="why">Why?</a>
		<div class="why-details">
			<ol>
				<li>One click to login. No more pesky passwords!</li>
				<li>Easily share your likes and links.</li>
				<li>See what's popular with Gigaom Research readers.</li>
			</ol>
<p>
				We will never post to your social networks unless you share something.
				<a href="https://gigaom.com/terms-of-service/">Terms</a> and <a href="https://gigaom.com/privacy-policy/">Privacy</a>.
</p>
</div>
</div>
		<div class="lost-password">
		<header>Forgot your password?</header>
		<form id="go-remote-identity-forgot" action="https://accounts.gigaom.com/wp-login.php?action=lostpassword" enctype="application/x-www-form-urlencoded" method="post">
			<input type="hidden" name="redirect_to" value="" id="forgot_redirect_to">
			<ul>
				<li class="email">
					<label for="go-remote-identity-user_login">Email address</label>
					<input type="email" name="user_login" id="go-remote-identity-user_login">
				</li>
				<li class="actions">
					<button class="button action-button submit" type="submit">Get new password</button>
				</li>
			</ul>
		</form>
</div>
</div>
		<!-- Quantcast Tag -->
		<script type="text/javascript">
		var _qevents = _qevents || [];

		(function() {
		var elem = document.createElement('script');
		elem.src = (document.location.protocol == 'https:' ? 'https://secure' : 'http://edge') + '.quantserve.com/quant.js';
		elem.async = true;
		elem.type = 'text/javascript';
		var scpt = document.getElementsByTagName('script')[0];
		scpt.parentNode.insertBefore(elem, scpt);
		})();

		_qevents.push({
		qacct:'p-7f76HAgni1Oqs'
		});
		</script>

		<noscript>
		<div style="display:none;">
		<img src="//pixel.quantserve.com/pixel/p-7f76HAgni1Oqs.gif" height="1" width="1" alt="Quantcast"/>
</div>
		</noscript>
		<!-- End Quantcast tag -->
		<!-- Compete CrossPoint Tag for gigaom.com -->
		<script type="text/javascript">
		__compete_code = 'bb0600f729c3213d9d68f9daaaa24a40';
		</script>
		<script type="text/javascript" src="//c.compete.com/bootstrap/s/bb0600f729c3213d9d68f9daaaa24a40/gigaom-com/bootstrap.js"></script>
		<noscript>
			<img width="1" height="1" src="https://ssl-gigaom-com-bb0600.c-col.com" alt="Compete Crosspoint"/>
		</noscript>
		<!-- End Compete CrossPoint Tag for gigaom.com -->
		<!-- Chartbeat -->
		<script type="text/javascript">
			var _sf_async_config={};
			/** CONFIGURATION START **/
			_sf_async_config.uid = 16916;
			_sf_async_config.useCanonical = true;
			_sf_async_config.domain = "gigaom.com";
							_sf_async_config.sections = "primary_channel:Cleantech,primary_channel:Science &amp; Energy,channel:Cleantech,channel:Data,channel:Science &amp; Energy,post_tag:Google,post_tag:Hadoop";
				_sf_async_config.authors = "Katie Fehrenbacher";
							/** CONFIGURATION END **/
			(function(){
				function loadChartbeat() {
					window._sf_endpt=(new Date()).getTime();
					var e = document.createElement("script");
					e.setAttribute("language", "javascript");
					e.setAttribute("type", "text/javascript");
					e.setAttribute('src', '//static.chartbeat.com/js/chartbeat.js');
					document.body.appendChild(e);
				}
				var oldonload = window.onload;
				window.onload = (typeof window.onload != "function") ?
				loadChartbeat : function() { oldonload(); loadChartbeat(); };
			})();
		</script>
		<!-- comScore -->
		<script>
			var _comscore = _comscore || [];
			_comscore.push({ c1: "2", c2: "13557238" });
			(function() {
				var s = document.createElement("script"), el = document.getElementsByTagName("script")[0]; s.async = 'async';
				s.src = (document.location.protocol == "https:" ? "https://sb" : "http://b") + ".scorecardresearch.com/beacon.js";
				el.parentNode.insertBefore(s, el);
			})();
		</script>
		<noscript>
			<img src="http://b.scorecardresearch.com/p?c1=2&amp;c2=13557238&amp;cv=2.0&amp;cj=1" alt="comScore" />
		</noscript>
		<!-- Nielsen Online SiteCensus V6.0 -->
		<script type="text/javascript">
		(function () {
			var d = new Image(1, 1);
			d.onerror = d.onload = function () {
				d.onerror = d.onload = null;
			};
			d.src = ["//secure-us.imrworldwide.com/cgi-bin/m?ci=us-thestreet&cg=0&cc=1&si=", escape(window.location.href), "&rp=", escape(document.referrer), "&ts=compact&rnd=", (new Date()).getTime()].join('');
		})();
		</script>
		<noscript>
<div>
				<img src="//secure-us.imrworldwide.com/cgi-bin/m?ci=us-thestreet&amp;cg=0&amp;cc=1&amp;ts=noscript" width="1" height="1" alt="" />
</div>
		</noscript>
					<!-- Bizo -->
			<script type="text/javascript">
				var _bizo_data_partner_id = "459";
									var _bizo_data_partner_channel_id = "gigaom.tech.com";
								</script>
			<script type="text/javascript">
				(function(){(function(){var b,a;a=document.createElement("script");a.type="text/javascript";a.async='async';a.src=""+(window.location.protocol==="https:"?"https://sjs.":"http://js.")+"bizographics.com/insight.min.js";b=document.getElementsByTagName("script")[0];return b.parentNode.insertBefore(a,b)})();})();
			</script>
			<!-- END Bizo -->
			<script type='text/javascript'>
/* <![CDATA[ */
var bstat = {"post":"33266","blog":"1","guid":"http:\/\/earth2tech.com\/?p=33266","endpoint":"https:\/\/accounts.gigaom.com\/wp-admin\/admin-ajax.php?action=bstat","signature":"d5601aac9526d87ffd485692749c9b57"};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/bstat-light/components/js/bstat.js?ver=5'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-google-analytics/components/js/min/go-google-analytics-tracking.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ui/components/js/min/external/jquery.blockUI.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ui/components/js/min/external/jquery.dotdotdot.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ui/components/js/min/external/colorbox/jquery.colorbox-min.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ui/components/js/min/external/jquery.cookie.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ui/components/js/min/external/jquery.ba-dotimeout.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ui/components/js/min/jquery.inline-bumpdown.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ui/components/js/min/external/jquery.ba-throttle-debounce.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ui/components/js/min/external/waypoints.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-timepicker/components/js/min/external/moment.min.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/foundation/foundation.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/foundation/foundation.tooltips.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/foundation/foundation.section.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/external/ios-orientation-change.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/foundation/jquery.event.move.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/external/jquery.easing.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/external/jquery.cycle.min.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/external/jquery.rwdImageMaps.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/external/jquery.mustache.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var go_theme = {"property":"gigaom","ajaxurl":"https:\/\/gigaom.com\/wp-admin\/admin-ajax.php","template_url":"https:\/\/gigaom.com\/wp-content\/themes\/vip\/gigaom5","wp_url":"https:\/\/gigaom.com"};
var go_theme_injection_areas = [];
var go_responsive = {"tablet":{"go-inject-6":{"widget":"go-widget-areas-4","class":"","title":"After first loop"},"go-inject-15":{"widget":"go-ads-9","class":"comment-ad","title":"Tablet Portrait Ad"}},"full":{"go-inject-7":{"widget":"go-widget-areas-4","class":"","title":"Section A"},"go-inject-11":{"widget":"postloop-25","class":"","title":"Related Stories"},"go-inject-10":{"widget":"go-ads-3","class":"","title":"Ad B"},"go-inject-12":{"widget":"go-ads-7","class":"","title":"Ad C"},"go-inject-8":{"widget":"go-widget-areas-5","class":"","title":"Section B"}}};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/core/init.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-google-analytics/components/js/min/go-google-analytics-resize.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/plugins/go-channels/components/js/min/go-channels.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/core/nav.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/core/resize.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/core/resize.dynamic.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/core/text-scale.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/core/single.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/core/gallery.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/core/waterfall.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/account-nav.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/external/skrollr.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5/js/lib/behavior.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-remote-identity/components//js/min/go-remote-identity-goidentity.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var go_remote_identity_data = {"identity_server":"https:\/\/accounts.gigaom.com","sign_in":"https:\/\/accounts.gigaom.com\/subscription\/sign-in\/?redirect_to=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&reauth=1"};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-remote-identity/components//js/min/go-remote-identity.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-remote-identity/components//js/min/go-remote-identity-login.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-subscribe-nav/components/js/min/go-subscribe-nav.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var bsocial_comments = {"nonce":"2b4812bacd","endpoint":"https:\/\/gigaom.com\/wp-admin\/admin-ajax.php","logged_in_as":"0"};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/bsocial-comments/components/js/bsocial-comments.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var go_local_bsocial = {"title":null,"twitter_id":"gigaom","reddit_page":null,"facebook_page":"https:\/\/www.facebook.com\/Gigaom","excerpt_max_length":"104","quote_max_length":"104","general_max_length":"109"};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-local-bsocial/components/js/min/go-local-bsocial.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-local-bsocial/components/js/min/go-local-bsocial-cta.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-social-comments/components/js/min/gravatar.js?ver=1'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-social-comments/components/js/min/jquery.tools.min.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var go_socialcomments = {"auth_types":{"twitter":"Twitter","facebook":"Facebook","linkedin":"LinkedIn","wordpress":"WordPress","gigaom":"Gigaom"},"user":{"service":"","first_name":"","full_name":"","email":"","avatar":"","logout":""},"property":"gigaom","throbber":"<img class=\"wijax-load\" src=\"https:\/\/gigaom.com\/wp-content\/themes\/vip\/gigaom5-plugins\/go-social-comments\/components\/images\/ajax-loader.gif\" alt=\"loading\">"};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-social-comments/components/js/min/go-socialcomments.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-includes/js/comment-reply.min.js?ver=4.3'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-local-bsocial-comments/components/js/min/go-local-bsocial-comments.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var go_ads = {"dfp_targeting":[["post_tag","google"],["post_tag","hadoop"],["post_tag","cleantech"],["post_tag","data"],["post_tag","science &amp; energy"]],"debug":"","defined_slots":[],"defined_objects":[]};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-ads/components/js/min/go-ads.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var go_contentwidgets = {"layout_preferences":[]};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-contentwidgets/components/js/min/go-contentwidgets.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var share_links = {"facebook":"https:\/\/www.facebook.com\/dialog\/feed?app_id=180650338636285&link=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&name=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid&description=&caption=Gigaom&redirect_uri=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F","twitter":"https:\/\/twitter.com\/intent\/tweet?url=https%3A%2F%2Fgigaom.com%2F2009%2F06%2F02%2Fhow-to-use-open-source-hadoop-for-the-smart-grid%2F&via=gigaom&text=How+to+Use+Open-Source+Hadoop+for+the+Smart+Grid"};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-select-and-share/components/js/min/go-select-and-share.js?ver=1436146263123'></script>
<script type='text/javascript'>
/* <![CDATA[ */
var scrib_authority_data = {"primary":null};
var scrib_authority_taxonomies = {"post_tag":{"name":"post_tag","labels":{"name":"Tags","singular_name":"Tag"}},"company":{"name":"company","labels":{"name":"Companies","singular_name":"Companies"}},"technology":{"name":"technology","labels":{"name":"Technologies and Products","singular_name":"Technologies and Products"}},"person":{"name":"person","labels":{"name":"People","singular_name":"People"}},"go_syn_category":{"name":"go_syn_category","labels":{"name":"Partner Categories","singular_name":"Partner Categories"}},"channel":{"name":"channel","labels":{"name":"Channel","singular_name":"Channel"}},"primary_channel":{"name":"primary_channel","labels":{"name":"Primary Channel","singular_name":"Primary Channel"}}};
var go_search_suggest = {"terms":[]};
/* ]]> */
</script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/scriblio-authority/components/js/jquery.scrib-authority.js?ver=7'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-search-suggest/components/js/min/external/matching.js?ver=1436146263123'></script>
<script type='text/javascript' src='https://gigaom.com/wp-content/themes/vip/gigaom5-plugins/go-search-suggest/components/js/min/go-search-suggest.js?ver=1436146263123'></script>
<script type="text/javascript">
	var wijax_widget_reload = true;
	var wijax_queue = {
		max_allowed_requests: 3,
		timer: false,
		processing: [],
		processed: [],
		queued: [],
		process: function( set_timer ) {
			if ( false !== set_timer ) {
				set_timer = true;
			}//end if

			// allow X wijax requests to process
			while (
				wijax_queue.processing.length < wijax_queue.max_allowed_requests
				&& wijax_queue.queued.length > 0
			) {
				var item = wijax_queue.queued.shift();

				jQuery.ajax( item );

				wijax_queue.processing.push( item );
			}//end while

			if ( ! wijax_queue.queued.length ) {
				wijax_queue.timer = false;
				return;
			}//end if

			if ( set_timer ) {
				wijax_queue.timer = setTimeout( wijax_queue.process, 300 );
			}//end if
		},// end process
		mark_as_processed: function( url ) {
			// find the wijax request that completed
			for ( var i in wijax_queue.processing ) {
				// if the URLs don't match, then this wasn't the request that just completed
				if ( wijax_queue.processing[ i ].url != url ) {
					continue;
				}//end if

				// stick the wijax request into the processed array
				wijax_queue.processed.push( Object.create( wijax_queue.processing[ i ] ) );

				// remove it from the processing array
				wijax_queue.processing.splice( i, 1 );
			}//end for
		}
	};

	;(function($){
		$.fn.myWijaxLoader = function() {
			var widget_source = $(this).attr('href');
			var $widget_area = $(this).closest('.wijax-loading');
			var $widget_parent = $widget_area.parent();
			var opts = $.parseJSON( $widget_parent.find('span.wijax-opts').text() );
			var varname = opts.varname;
			var title_before = unescape( opts.title_before );
			var title_after = unescape( opts.title_after );

			wijax_queue.queued.push({
				url: widget_source,
				dataType: 'script',
				cache: true,
				complete: function() {
					wijax_queue.mark_as_processed( widget_source );
				},
				success: function() {
					// insert the fetched markup
					$( $widget_area ).replaceWith( window[varname] );

					// find the widget title, add it to the DOM, remove the temp span
					var $widget_title_el = $widget_parent.find('span.wijax-widgettitle');
					var widget_title = $widget_title_el.text();

					// don't set a widget title div if there is no title text
					if (widget_title)
						$widget_parent.prepend(title_before + widget_title + title_after);

					$widget_title_el.remove();

					// find and set the widget ID and classes
					var $widget_attr_el = $widget_parent.find( 'span.wijax-widgetclasses' );
					var widget_id = $widget_attr_el.attr( 'id' );
					var widget_classes = $widget_attr_el.attr( 'class' );
					$widget_parent.attr( 'id' , widget_id );
					$widget_parent.addClass( widget_classes );
					$widget_parent.removeClass( 'widget_wijax' );
					$widget_attr_el.remove();

					// trigger an event in case anything else needs to know when this widget has loaded
					$( document ).trigger( 'wijax-loaded', [ widget_id ] );
				}
			});

			// for each queuing of a wijax request, pass in a boolean that indicates whether or not
			// to start a new setTimeout
			wijax_queue.process( ! wijax_queue.timer );
		};

		// do the onload widgets
		$(window).load(function(){
			// find and load the widgets
			$('a.wijax-source.wijax-onload').each(function() {
				$(this).myWijaxLoader();
			});

			// if we've already scrolled or there is a hash in the url,
			// fire the scroll event and get the excerpts and widgets
			if ( ( document.location.hash ) || ( window.pageYOffset > 25 ) || ( document.body.scrollTop > 25 ) )
				$( document ).trigger( 'scroll' );
		});

		// do the onscroll actions
		$(window).one('scroll', function(){
			// widgets
			$('a.wijax-source.wijax-onscroll').each(function() {
				$(this).myWijaxLoader();
			});
		});
	})(jQuery);
</script>
</div>

<script type="text/javascript">
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-67278278-46']);
_gaq.push(['_setCustomVar',1,'template','old_site_gc',1]);
_gaq.push(['_setCustomVar',2,'v','{ezoic_variation_id}',1]);
_gaq.push(['_setCustomVar',3,'t','126',1]);
_gaq.push(['_setAllowAnchor',true]);
_gaq.push(['_setSiteSpeedSampleRate', 10]);
_gaq.push(['_trackPageview']);
_gaq.push(['b._setAccount', 'UA-38339005-1']);
_gaq.push(['b._setCustomVar',1,'template','old_site_gc',1]);
_gaq.push(['b._setCustomVar',2,'domain','gigaom.com',3]);
_gaq.push(['b._setSiteSpeedSampleRate', 20]);
_gaq.push(['b._trackPageview']);

_gaq.push(['c._setAccount', 'UA-1136722-40']);
_gaq.push(['c._trackPageview']);


(function() {
 var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
 ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
 var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();
var ez_tos_track_count = 0;
var ez_last_activity_count = 0;
(function (__ez_tos) {
  window.setInterval(function () {
    __ez_tos = (function (t) {
      return t[0] == 45 ? (parseInt(t[1]) + 1) + ':00' : (t[1] || '0') + ':' + (parseInt(t[0]) + 15);
    })(__ez_tos.split(':').reverse());

    ez_tos_track_count++;
    if(ez_tos_track_count > 1 && ez_tos_track_count < (ez_last_activity_count + 4) && ez_tos_track_count < 240)
    {
        if(window.pageTracker)
        {
            pageTracker._trackEvent('Time', 'Log', __ez_tos)
        }
        else
        {
           _gaq.push(['_trackEvent', 'Time', 'Log', __ez_tos]);
           _gaq.push(['b._trackEvent', 'Time', 'Log', __ez_tos]);
        }
		
		if(typeof(_paq) != 'undefined')
        {
            _paq.push(['trackEvent', 'Time', __ez_tos, 'TimeOnPage']);
        }

    }
  }, 15000);
})('00');

</script>

<script type="text/javascript">


if(typeof $ezJQuery == 'undefined')
{
    if (typeof jQuery == 'undefined')
    {
        document.write('<scr'+'ipt type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></sc'+'ript>');
    }
    else
    {
        $ezJQuery = jQuery;
    }
}

</script>

<script type="text/javascript">


if (typeof $ezJQuery == 'undefined' && typeof jQuery != 'undefined')
{
    $ezJQuery = jQuery.noConflict();
}

</script>

<script type="text/javascript">
if(typeof $ezJQuery != 'undefined')
{
    $ezJQuery("body").mousemove(function(e){
      ez_last_activity_count = ez_tos_track_count;
    });
    $ezJQuery("body").keypress(function(e){
      ez_last_activity_count = ez_tos_track_count;
    });
    $ezJQuery(window).scroll(function(e){
      ez_last_activity_count = ez_tos_track_count;
    });
}
else
{
    ez_last_activity_count = 8;
}
</script>
<script type='text/javascript' src='//gigaom.com/utilcave_com/inc/tb.php?cb=16&template=orig'></script>
<script>
$ezJQuery(function() {
    if (typeof run_body_onload == 'function') {
        run_body_onload();
    }
    if (typeof ezoicJSPageLoad == 'function') {
        ezoicJSPageLoad($ezJQuery);
    }
});
</script>


<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>
</html>
