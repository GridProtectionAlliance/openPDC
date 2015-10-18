
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
    <title>Installing Operating System Images on Linux - Raspberry Pi Documentation</title>
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
    <a href='//www.raspberrypi.org/documentation'>documentation</a> &gt; <a href='//www.raspberrypi.org/documentation/installation'>installation</a> &gt; <a href='//www.raspberrypi.org/documentation/installation/installing-images'>installing-images</a> &gt; linux</nav>

<article class="entry-content">
    <h1>Installing Operating System Images on Linux</h1>
<p>Please note that the use of the <code>dd</code> tool can overwrite any partition of your machine. If you specify the wrong device in the instructions below you could delete your primary Linux partition. Please be careful.</p>
<ul>
<li>
<p>Run <code>df -h</code> to see what devices are currently mounted.</p>
</li>
<li>
<p>If your computer has a slot for SD cards, insert the card. If not, insert the card into an SD card reader, then connect the reader to your computer.</p>
</li>
<li>
<p>Run <code>df -h</code> again. The new device that has appeared is your SD card. The left column gives the device name of your SD card; it will be listed as something like <code>/dev/mmcblk0p1</code> or <code>/dev/sdd1</code>. The last part (<code>p1</code> or <code>1</code> respectively) is the partition number but you want to write to the whole SD card, not just one partition. Therefore you need to remove that part from the name (getting, for example, <code>/dev/mmcblk0</code> or <code>/dev/sdd</code>) as the device for the whole SD card. Note that the SD card can show up more than once in the output of df; it will do this if you have previously written a Raspberry Pi image to this SD card, because the Raspberry Pi SD images have more than one partition.</p>
</li>
<li>
<p>Now that you've noted what the device name is, you need to unmount it so that files can't be read or written to the SD card while you are copying over the SD image.</p>
</li>
<li>
<p>Run <code>umount /dev/sdd1</code>, replacing <code>sdd1</code> with whatever your SD card's device name is (including the partition number).</p>
</li>
<li>
<p>If your SD card shows up more than once in the output of <code>df</code> due to having multiple partitions on the SD card, you should unmount all of these partitions.</p>
</li>
<li>
<p>In the terminal, write the image to the card with the command below, making sure you replace the input file <code>if=</code> argument with the path to your <code>.img</code> file, and the <code>/dev/sdd</code> in the output file <code>of=</code> argument with the right device name. This is very important, as you will lose all data on the hard drive if you provide the wrong device name. Make sure the device name is the name of the whole SD card as described above, not just a partition of it; for example <code>sdd</code>, not <code>sdds1</code> or <code>sddp1</code>; or <code>mmcblk0</code>, not <code>mmcblk0p1</code>.</p>
<pre><code class="language-bash">dd bs=4M if=2015-09-24-raspbian-jessie.img of=/dev/sdd</code></pre>
</li>
<li>
<p>Please note that block size set to <code>4M</code> will work most of the time; if not, please try <code>1M</code>, although this will take considerably longer.</p>
</li>
<li>
<p>Also note that if you are not logged in as root you will need to prefix this with <code>sudo</code>.</p>
</li>
<li>
<p>The <code>dd</code> command does not give any information of its progress and so may appear to have frozen; it could take more than five minutes to finish writing to the card. If your card reader has an LED it may blink during the write process. To see the progress of the copy operation you can run <code>pkill -USR1 -n -x dd</code> in another terminal, prefixed with <code>sudo</code> if you are not logged in as root. The progress will be displayed in the original window and not the window with the <code>pkill</code> command; it may not display immediately, due to buffering.</p>
</li>
<li>
<p>Instead of <code>dd</code> you can use <code>dcfldd</code>; it will give a progress report about how much has been written.</p>
</li>
<li>
<p>You can check what's written to the SD card by <code>dd</code>-ing from the card back to another image on your hard disk, truncating the new image to the same size as the original, and then running <code>diff</code> (or <code>md5sum</code>) on those two images.</p>
</li>
<li>
<p>The SD card might be bigger than the original image, and dd will make a copy of the whole card. We must therefore truncate the new image to the size of the original image.  Make sure you replace the input file if= argument with the right device name. <code>diff</code> should report that the files are identical.</p>
<pre><code class="language-bash">dd bs=4M if=/dev/sdd of=from-sd-card.img
truncate --reference 2015-09-24-raspbian-jessie.img from-sd-card.img
diff -s from-sd-card.img 2015-09-24-raspbian-jessie.img</code></pre>
</li>
<li>
<p>Run <code>sync</code>; this will ensure the write cache is flushed and that it is safe to unmount your SD card.</p>
</li>
<li>Remove the SD card from the card reader.</li>
</ul>
<hr />
<p><em>This article uses content from the eLinux wiki page <a href="http://elinux.org/RPi_Easy_SD_Card_Setup">RPi_Easy_SD_Card_Setup</a>, which is shared under the <a href="http://creativecommons.org/licenses/by-sa/3.0/">Creative Commons Attribution-ShareAlike 3.0 Unported license</a></em></p></article>

                <footer class="licence">
                    <aside class="octocat">
                        <a href="https://github.com/raspberrypi/documentation/blob/master/installation/installing-images/linux.md"><img src="/wp-content/themes/mind-control/images/octocat.jpg" /></a>
                    </aside>
                    <aside class="links">
                        <a href="https://github.com/raspberrypi/documentation/blob/master/installation/installing-images/linux.md" class="github">View/Edit this page on GitHub</a><br />
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
