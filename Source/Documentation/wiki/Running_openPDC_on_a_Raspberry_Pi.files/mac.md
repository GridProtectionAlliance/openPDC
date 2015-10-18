
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
    <title>Installing Operating System Images on Mac OS - Raspberry Pi Documentation</title>
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
    <a href='//www.raspberrypi.org/documentation'>documentation</a> &gt; <a href='//www.raspberrypi.org/documentation/installation'>installation</a> &gt; <a href='//www.raspberrypi.org/documentation/installation/installing-images'>installing-images</a> &gt; mac</nav>

<article class="entry-content">
    <h1>Installing Operating System Images on Mac OS</h1>
<p>On Mac OS you have the choice of the command line <code>dd</code> tool or using the graphical tool ImageWriter to write the image to your SD card.</p>
<h2>(Mostly) graphical interface</h2>
<ul>
<li>Connect the SD card reader with the SD card inside. Note that it must be formatted in FAT32.</li>
<li>From the Apple menu, choose About This Mac, then click on More info...; if you are using Mac OS X 10.8.x Mountain Lion or newer then click on System Report.</li>
<li>Click on USB (or Card Reader if using a built-in SD card reader) then search for your SD card in the upper right section of the window. Click on it, then search for the BSD name in the lower right section; it will look something like 'diskn' where n is a number (for example, disk4). Make sure you take a note of this number.</li>
<li>Unmount the partition so that you will be allowed to overwrite the disk; to do this, open Disk Utility and unmount it (do not eject it, or you will have to reconnect it). Note that On Mac OS X 10.8.x Mountain Lion, &quot;Verify Disk&quot; (before unmounting) will display the BSD name as &quot;/dev/disk1s1&quot; or similar, allowing you to skip the previous two steps.</li>
<li>
<p>From the terminal run:</p>
<pre><code>sudo dd bs=1m if=path_of_your_image.img of=/dev/rdiskn</code></pre>
<p>Remember to replace <code>n</code> with the number that you noted before!</p>
<ul>
<li>
<p>If this command fails, try using <code>disk</code> instead of <code>rdisk</code>:</p>
<pre><code>sudo dd bs=1m if=path_of_your_image.img of=/dev/diskn</code></pre>
</li>
</ul>
</li>
</ul>
<h2>Command line</h2>
<ul>
<li>
<p>If you are comfortable with the command line, you can write the image to a SD card without any additional software. Open a terminal, then run:</p>
<p><code>diskutil list</code></p>
</li>
<li>Identify the disk (not partition) of your SD card e.g. <code>disk4</code> (not <code>disk4s1</code>).</li>
<li>
<p>Unmount your SD card by using the disk identifier to prepare copying data to it:</p>
<p><code>diskutil unmountDisk /dev/disk&lt;disk# from diskutil&gt;</code></p>
<p>e.g. <code>diskutil unmountDisk /dev/disk4</code></p>
</li>
<li>
<p>Copy the data to your SD card:</p>
<p><code>sudo dd bs=1m if=image.img of=/dev/rdisk&lt;disk# from diskutil&gt;</code></p>
<p>e.g. <code>sudo dd bs=1m if=2015-09-24-raspbian-jessie.img of=/dev/rdisk4</code></p>
<ul>
<li>
<p>This may result in an <code>dd: invalid number '1m'</code> error if you have GNU
coreutils installed. In that case you need to use <code>1M</code>:</p>
<p><code>sudo dd bs=1M if=image.img of=/dev/rdisk&lt;disk# from diskutil&gt;</code></p>
</li>
</ul>
<p>This will take a few minutes, depending on the image file size.
You can check the progress by sending a <code>SIGINFO</code> signal pressing <kbd>Ctrl</kbd>+<kbd>T</kbd>.</p>
<ul>
<li>
<p>If this command still fails, try using <code>disk</code> instead of <code>rdisk</code>:</p>
<pre><code>e.g. `sudo dd bs=1m if=2015-09-24-raspbian-jessie.img of=/dev/disk4`</code></pre>
<p>or</p>
<pre><code>e.g. `sudo dd bs=1M if=2015-09-24-raspbian-jessie.img of=/dev/disk4`</code></pre>
</li>
</ul>
</li>
</ul>
<h2>Alternative method</h2>
<p><strong>Note: Some users have reported issues with using Mac OS X to create SD cards.</strong></p>
<p>These commands and actions need to be performed from an account that has administrator privileges.</p>
<ul>
<li>From the terminal run <code>df -h</code>.</li>
<li>Connect the SD card reader with the SD card inside.</li>
<li>Run <code>df -h</code> again and look for the new device that wasn't listed last time. Record the device name of the filesystem's partition, for example <code>/dev/disk3s1</code>.</li>
<li>
<p>Unmount the partition so that you will be allowed to overwrite the disk:</p>
<pre><code>sudo diskutil unmount /dev/disk3s1</code></pre>
<p>(or open Disk Utility and unmount the partition of the SD card (do not eject it, or you will have to reconnect it)</p>
</li>
<li>Using the device name of the partition, work out the raw device name for the entire disk by omitting the final &quot;s1&quot; and replacing &quot;disk&quot; with &quot;rdisk&quot;. This is very important as you will lose all data on the hard drive if you provide the wrong device name. Make sure the device name is the name of the whole SD card as described above, not just a partition of it (for example, rdisk3, not rdisk3s1). Similarly, you might have another SD drive name/number like rdisk2 or rdisk4; you can check again by using the <code>df -h</code> command both before and after you insert your SD card reader into your Mac. For example, <code>/dev/disk3s1</code> becomes <code>/dev/rdisk3</code>.</li>
<li>
<p>In the terminal, write the image to the card with this command, using the raw disk device name from above. Read the above step carefully to be sure you use the correct rdisk number here:</p>
<pre><code>sudo dd bs=1m if=2015-09-24-raspbian-jessie.img of=/dev/rdisk3</code></pre>
<p>If the above command reports an error (<code>dd: bs: illegal numeric value</code>), please change <code>bs=1m</code> to <code>bs=1M</code>.</p>
<p>If the above command reports an error <code>dd: /dev/rdisk3: Permission denied</code> then that is because the partition table of the SD card is being protected against being overwritten by MacOS. Erase the SD card's partition table using this command:</p>
<pre><code>sudo diskutil partitionDisk /dev/disk3 1 MBR "Free Space" "%noformat%" 100%</code></pre>
<p>That command will also set the permissions on the device to allow writing. Now try the <code>dd</code> command again.</p>
<p>Note that <code>dd</code> will not feedback any information until there is an error or it is finished; information will be shown and the disk will re-mount when complete. However if you wish to view the progress you can use 'ctrl-T'; this generates SIGINFO, the status argument of your tty, and will display information on the process.</p>
</li>
<li>
<p>After the <code>dd</code> command finishes, eject the card:</p>
<pre><code>sudo diskutil eject /dev/rdisk3</code></pre>
<p>(or: open Disk Utility and eject the SD card)</p>
</li>
</ul>
<hr />
<p><em>This article uses content from the eLinux wiki page <a href="http://elinux.org/RPi_Easy_SD_Card_Setup">RPi_Easy_SD_Card_Setup</a>, which is shared under the <a href="http://creativecommons.org/licenses/by-sa/3.0/">Creative Commons Attribution-ShareAlike 3.0 Unported license</a></em></p></article>

                <footer class="licence">
                    <aside class="octocat">
                        <a href="https://github.com/raspberrypi/documentation/blob/master/installation/installing-images/mac.md"><img src="/wp-content/themes/mind-control/images/octocat.jpg" /></a>
                    </aside>
                    <aside class="links">
                        <a href="https://github.com/raspberrypi/documentation/blob/master/installation/installing-images/mac.md" class="github">View/Edit this page on GitHub</a><br />
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
