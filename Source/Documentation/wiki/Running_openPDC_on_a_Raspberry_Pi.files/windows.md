
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
    <title>Installing Operating System Images using Windows - Raspberry Pi Documentation</title>
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
    <a href='//www.raspberrypi.org/documentation'>documentation</a> &gt; <a href='//www.raspberrypi.org/documentation/installation'>installation</a> &gt; <a href='//www.raspberrypi.org/documentation/installation/installing-images'>installing-images</a> &gt; windows</nav>

<article class="entry-content">
    <h1>Installing Operating System Images using Windows</h1>
<ul>
<li>Insert the SD card into your SD card reader and check which drive letter was assigned. You can easily see the drive letter (for example <code>G:</code>) by looking in the left column of Windows Explorer. You can use the SD Card slot (if you have one) or a cheap SD adaptor in a USB port.</li>
<li>Download the Win32DiskImager utility from the <a href="http://sourceforge.net/projects/win32diskimager/">Sourceforge Project page</a> (it is also a zip file); you can run this from a USB drive.</li>
<li>Extract the executable from the zip file and run the <code>Win32DiskImager</code> utility; you may need to run the utility as administrator. Right-click on the file, and select <strong>Run as administrator</strong>.</li>
<li>Select the image file you extracted above.</li>
<li>Select the drive letter of the SD card in the device box. Be careful to select the correct drive; if you get the wrong one you can destroy your data on the computer's hard disk! If you are using an SD card slot in your computer and can't see the drive in the Win32DiskImager window, try using a cheap SD adaptor in a USB port.</li>
<li>Click <code>Write</code> and wait for the write to complete.</li>
<li>Exit the imager and eject the SD card.</li>
</ul>
<hr />
<p><em>This article uses content from the eLinux wiki page <a href="http://elinux.org/RPi_Easy_SD_Card_Setup">RPi_Easy_SD_Card_Setup</a>, which is shared under the <a href="http://creativecommons.org/licenses/by-sa/3.0/">Creative Commons Attribution-ShareAlike 3.0 Unported license</a></em></p></article>

                <footer class="licence">
                    <aside class="octocat">
                        <a href="https://github.com/raspberrypi/documentation/blob/master/installation/installing-images/windows.md"><img src="/wp-content/themes/mind-control/images/octocat.jpg" /></a>
                    </aside>
                    <aside class="links">
                        <a href="https://github.com/raspberrypi/documentation/blob/master/installation/installing-images/windows.md" class="github">View/Edit this page on GitHub</a><br />
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
