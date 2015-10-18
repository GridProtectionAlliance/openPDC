
<!--[if IE 7]>
<html class="ie ie7" lang="en-GB">
<![endif]-->
<!--[if IE 8]>
<html class="ie ie8" lang="en-GB">
<![endif]-->
<!--[if !(IE 7) | !(IE 8)  ]><!-->
<html lang="en-GB">
<!--<![endif]-->
<head>
<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no" />
    <title>SD Cards - Raspberry Pi Documentation</title>
    <meta name="description" content="This section includes some simple guides to setting up the software on your Raspberry Pi. We recommend that beginners start by downloading and installing NOOBS." />
    <link rel="icon" type="image/png" href="/wp-content/themes/mind-control/images/favicon.png" />
    <link rel="publisher" href="https://plus.google.com/+RaspberryPi" />
    <!--[if lt IE 9]>
    <script src="/wp-content/themes/mind-control/js/html5.js"></script>
    <![endif]-->

    <link rel="stylesheet" href="/wp-content/themes/mind-control/css/prism.css" />
    <link rel="stylesheet" href="/wp-content/themes/mind-control/style.css" />
    <link rel="stylesheet" href="/wp-content/themes/mind-control/mobile.css" />
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Roboto+Slab:100,300,400,700">
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Roboto:100italic,100,300italic,300,400italic,400,500italic,500,700italic,700,900italic,900">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="/wp-content/themes/mind-control/js/jquery.main.js"></script>
    <script src="/wp-content/themes/mind-control/js/prism.js"></script>

    <script type="text/javascript">//<![CDATA[
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-46270871-1']);
			            _gaq.push(['_trackPageview']);
        (function () {
            var ga = document.createElement('script');
            ga.type = 'text/javascript';
            ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';

            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(ga, s);
        })();
        //]]></script>

    <link rel='canonical' href='https://www.raspberrypi.org/' />
    <link rel='shortlink' href='https://www.raspberrypi.org/' />
</head>

<body class="documentation">
    <div class="container">
        <header id="header">
            <nav id="nav">
                <ul id="menu-nav-bar" class="menu"><li id="menu-item-6901" class="home mobile menu-item menu-item-type-post_type menu-item-object-page current-menu-item page_item page-item-5372 current_page_item menu-item-6901"><a href="/">Home</a></li>
                    <li id="menu-item-8279" class="close-menu menu-item menu-item-type-custom menu-item-object-custom menu-item-8279"><a href="#">Close Menu</a></li>
                    <li id="menu-item-6902" class="yellow menu-item menu-item-type-post_type menu-item-object-page menu-item-6902"><a href="/blog/">Blog</a></li>
                    <li id="menu-item-6903" class="red menu-item menu-item-type-post_type menu-item-object-page menu-item-6903"><a href="/downloads/">Downloads</a></li>
                    <li id="menu-item-6904" class="purple menu-item menu-item-type-post_type menu-item-object-page menu-item-6904"><a href="/community/">Community</a></li>
                    <li id="menu-item-6905" class="green menu-item menu-item-type-post_type menu-item-object-page menu-item-6905"><a href="/help/">Help</a></li>
                    <li id="menu-item-6907" class="pink menu-item menu-item-type-custom menu-item-object-custom menu-item-6907"><a href="/forums/">Forums</a></li>
                    <li id="menu-item-6908" class="blue menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-6908"><a href="/resources/">Resources</a>
                        <ul class="sub-menu">
                        	<li id="menu-item-6911" class="blue2 menu-item menu-item-type-taxonomy menu-item-object-resource-category menu-item-6911"><a href="/resources/teach/">Teach</a></li>
                        	<li id="menu-item-6909" class="blue3 menu-item menu-item-type-taxonomy menu-item-object-resource-category menu-item-6909"><a href="/resources/learn/">Learn</a></li>
                        	<li id="menu-item-6910" class="blue4 menu-item menu-item-type-taxonomy menu-item-object-resource-category menu-item-6910"><a href="/resources/make/">Make</a></li>
                        </ul>
                    </li>
                    <li id="menu-item-7165" class="menu mobile menu-item menu-item-type-custom menu-item-object-custom menu-item-7165"><a href="#">Menu</a></li>
                    <li id="menu-item-6912" class="search mobile menu-item menu-item-type-custom menu-item-object-custom menu-item-6912"><a href="#">Search</a></li>
                    <li id="menu-item-7154" class="shop menu-item menu-item-type-post_type menu-item-object-page menu-item-7154"><a href="/buy/">Buy</a></li>
                </ul>
            </nav>
            <form class="search" action="/">
                <input name="s" class="search" value="" />
                <input type="submit" class="submit" value="Search" />
            </form>
        </header>

        <div class="main">

<nav class="breadcrumbs">
    <a href='//www.raspberrypi.org/documentation'>documentation</a> &gt; <a href='//www.raspberrypi.org/documentation/installation'>installation</a> &gt; sd-cards</nav>

<article class="entry-content">
    <h1>SD Cards</h1>
<p>The Raspberry Pi should work with any SD-compatible cards, although there are some guidelines that should be followed:</p>
<ul>
<li>SD card size (capacity). For installation of NOOBS, the minimum recommended card size is 8GB. For image installations we recommend a minimum of 4GB; some distributions can run on much smaller cards, specifically OpenElec and Arch.</li>
<li>SD card class. The card class determines the sustained write speed for the card; a class 4 card will be able to write at 4MB/s, whereas a class 10 should be able to attain 10 MB/s. However it should be noted that this does not mean a class 10 card will outperform a class 4 card for general usage, because often this write speed is achieved at the cost of read speed and increased seek times.</li>
<li>SD card physical size. The original <a href="https://www.raspberrypi.org/products/model-a/">Raspberry Pi Model A</a> and <a href="https://www.raspberrypi.org/products/model-b/">Raspberry Pi Model B</a> require full-size SD cards. The newer <a href="https://www.raspberrypi.org/products/model-a-plus/">Raspberry Pi Model A+</a>, <a href="https://www.raspberrypi.org/products/model-b-plus/">Raspberry Pi Model B+</a> and <a href="https://www.raspberrypi.org/products/raspberry-pi-2-model-b/">Raspberry Pi 2 Model B</a> require micro-SD cards.</li>
</ul>
<p>We recommend buying the <a href="http://swag.raspberrypi.org/products/noobs-8gb-sd-card">Raspberry Pi SD card</a>; this is an 8GB class 6 microSD card (with a full-size SD adaptor) that outperforms almost all other SD cards on the market and is a good value solution.</p>
<p>If you are having trouble with corruption of your SD cards, make sure you follow these steps:</p>
<ol>
<li>Make sure you are using a genuine SD card. There are many cheap SD cards available that are actually smaller than advertised or will not last very long.</li>
<li>Make sure you are using a good quality power supply. You can check your power supply by measuring the voltage between TP1 and TP2 on the Raspberry Pi; if this drops below 4.75V when doing complex tasks then it is most likely unsuitable.</li>
<li>Make sure you are using a good quality USB cable for the power supply. When using a high quality power supply, the TP1-&gt;TP2 voltage can drop below 4.75V. This is generally due to the resistance of the wires in the USB power cable; to save money USB cables have as little copper in them as possible, and as much as 1V (or one watt) can be lost over the length of the cable.</li>
<li>Make sure you are properly shutting down your Raspberry Pi before powering it off. Type <code>sudo halt</code> and wait for the Pi to signal it is ready to be powered off by flashing the activity LED.</li>
<li>Finally, corruption has been observed if you are overclocking the Pi. This problem has previously been fixed, although the workaround used may mean that it can still happen. If after checking the steps above you are still having problems with corruption, please let us know.</li>
</ol></article>

                <footer class="licence">
                    <aside class="octocat">
                        <a href="https://github.com/raspberrypi/documentation/blob/master/installation/sd-cards.md"><img src="/wp-content/themes/mind-control/images/octocat.jpg" /></a>
                    </aside>
                    <aside class="links">
                        <a href="https://github.com/raspberrypi/documentation/blob/master/installation/sd-cards.md" class="github">View/Edit this page on GitHub</a><br />
                        <a href="/creative-commons/">Read our usage and contributions policy</a><br />
                        <a href="/creative-commons/" class="cc"><img src="//i.creativecommons.org/l/by-sa/4.0/88x31.png" alt="Creative Commons Licence"></a>
                    </aside>
                </footer>

                <div style="clear: both;"></div>

            </div>

            <div style="clear: both;"></div>

            <aside id="social-icons" class="footer">
                <div class="footer-contents">
                    <ul id="menu-social-icons" class="menu">
                        <li id="menu-item-6924" class="twitter menu-item menu-item-type-custom menu-item-object-custom menu-item-6924"><a href="https://twitter.com/Raspberry_Pi">@Raspberry_Pi on Twitter</a></li>
                        <li id="menu-item-6925" class="googleplus menu-item menu-item-type-custom menu-item-object-custom menu-item-6925"><a href="https://plus.google.com/+RaspberryPi">+RaspberryPi on Google+</a></li>
                        <li id="menu-item-6926" class="facebook menu-item menu-item-type-custom menu-item-object-custom menu-item-6926"><a href="https://www.facebook.com/raspberrypi">Raspberry Pi on Facebook</a></li>
                        <li id="menu-item-6927" class="github menu-item menu-item-type-custom menu-item-object-custom menu-item-6927"><a href="https://github.com/raspberrypi">Raspberry Pi on GitHub</a></li>
                        <li id="menu-item-6928" class="githublearning menu-item menu-item-type-custom menu-item-object-custom menu-item-6928"><a href="https://github.com/raspberrypilearning">Raspberry Pi Learning on GitHub</a></li>
                        <li id="menu-item-6929" class="youtube menu-item menu-item-type-custom menu-item-object-custom menu-item-6929"><a href="https://www.youtube.com/channel/UCFIjVWFZ__KhtTXHDJ7vgng">Raspberry Pi on YouTube</a></li>
                        <li id="menu-item-6930" class="vimeo menu-item menu-item-type-custom menu-item-object-custom menu-item-6930"><a href="https://vimeo.com/raspberrypi">Raspberry Pi on Vimeo</a></li>
                    </ul>
                </div>
            </aside>

        <footer id="footer">
            <div class="footer-contents">
                <ul id="menu-about-us" class="menu">
                    <li id="menu-item-6888" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-6888"><a href="/about/">About us</a></li>
                    <li id="menu-item-6892" class="menu-item menu-item-type-post_type menu-item-object-help menu-item-6892"><a href="/help/faqs/">FAQs</a></li>
                    <li id="menu-item-6893" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-6893"><a href="/cookies/">Cookies</a></li>
                    <li id="menu-item-6895" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-6895"><a href="/creative-commons/">Creative Commons</a></li>
                    <li id="menu-item-6896" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-6896"><a href="/trademark-rules/">Trademark rules</a></li>
                    <li id="menu-item-6898" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-6898"><a href="/contact-us/">Contact us</a></li>
                </ul>

                <footer>
                    Raspberry Pi Foundation<br />
                    UK registered charity 1129409
                </footer>
            </div>
        </footer>
    </div>
</body>
</html>
