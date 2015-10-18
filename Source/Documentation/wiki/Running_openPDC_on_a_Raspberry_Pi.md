

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Running_openPDC_on_a_Raspberry_Pi</title>



<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body>

<h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>

<hr />

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



<div class="WikiContent">

<div class="wikidoc">

<h2>Running the openPDC on a Raspberry Pi and Pi 2</h2>

To avoid needing to compile Mono and speed up the installation process, we have posted an image for download with the needed version of Mono (i.e., version 3.12.1 that includes

<a href="http://www.mono-project.com/news/2015/03/07/mono-tls-vulnerability/">FREAK security fix</a>) and the openPDC (i.e., version 2.1.64) preinstalled for running on a Raspberry Pi and Pi 2 with the Raspbian OS. Download the zip file below that contains

 the image:<br>

<ul>

<li><a href="http://www.gridprotectionalliance.org/products/openPDC/Releases/2.1/POSIX/openPDC_Raspbian.zip">openPDC Rasbian Image</a> (2.08GB zipped)</li></ul>

<br>

Unzip the downloaded image file on a computer with an SD card reader. Note that the image size, when unzipped, is 6GB - as a result you will need an SD card at least that large to hold the image, 8 GB is the recommended minimum. Make sure to read raspberrypi.org&#39;s

 information on <a href="http://www.raspberrypi.org/documentation/installation/sd-cards.md">

SD cards</a>. Use the following instructions for deploying the image onto an SD card:<br>

<ul>

<li><a href="http://www.raspberrypi.org/documentation/installation/installing-images/windows.md">Windows</a>

</li><li><a href="http://www.raspberrypi.org/documentation/installation/installing-images/mac.md">Mac OS</a>

</li><li><a href="http://www.raspberrypi.org/documentation/installation/installing-images/linux.md">Linux</a></li></ul>

<br>

For the initial boot it is recommended to start the Raspberry Pi up with a connected monitor and keyboard. When the Raspberry Pi is first powered on with the openPDC image on the SD card, the system will request a username (prompted as &quot;login&quot;) and

 password - these are the defaults for a Raspbian OS image, specifically:<br>

<ul>

<li><i>Login</i>: pi </li><li><i>Password</i>: raspberry</li></ul>

<br>

After you enter the default credentials, the Rasbian configuration application (raspi-config) will launch. The following steps should be executed at a minimum:<br>

<br>

<ol>

<li>Run the &quot;Expand Filesystem&quot; command to make all SD card space available

</li><li>Run the &quot;Change User Password&quot; command for the default user (pi) </li><li>Run the &quot;Enable Boot to Desktop/Scratch&quot; command to set desired boot operation</li></ol>

<br>

Once you have configured the Raspberry Pi, select &quot;Finish&quot; from the configuration tool to reboot the system. The openPDC is set to automatically run at startup as a daemon with security enabled. Run the following command from a terminal session to

 access the openPDC:<br>

<ul>

<li>mono /opt/openPDC/openPDCConsole.exe</li></ul>

<br>

This will start the openPDC remote console session. Authentication is required, enter &quot;pi&quot; as the user name and the current password for this user. The console may make a few authentication attempts with the provided credentials testing various authentication

 options. Once authenticated, type &quot;version&quot; in the console and press Enter - this will show the running openPDC version and current OS details.<br>

<br>

The default openPDC configuration comes with a sample device and an available IEEE C37.118 output stream. If the Raspberry Pi is connected to a network, the outputs can be exercised immediately. The IEEE C37.118 output stream will be listening on TCP port 8900

 for both commands and data.<br>

<br>

For best openPDC performance, the Raspberry Pi 2 is recommended. The new Raspberry Pi 2 Model B has 4 cores, 1 GB of RAM and better CPU performance all of which provide a very practical and performant micro-environment for running the openPDC.<br>

<br>

The openPDC also runs on the original Raspberry Pi (same image for both platforms). For optimal performance on this single core system it is recommended that the configuration of the openPDC on the Raspberry Pi be reduced to its primary tasks.<br>

<br>

For more details, read the <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_on_Linux_and_Mac.md">

openPDC Linux Deployment Instructions</a>.<br>

<br>

Thanks!<br>

Ritchie<br>

<br>

</div>

<div></div>

</div>



<hr />

<div class="WikiComments">

<div id="comment31632">

    <div class="SubText">

        <a name="C31632"></a>

        <a href="https://www.codeplex.com/site/users/view/Andrew__M">Andrew__M</a>

        <span class="smartDate" title="5/6/2015 2:37:23 AM" localtimeticks="1430905043">May 6, 2015 at 2:37 AM</span>&nbsp;

        

</div>

    Thanks Ritchie - yes, the Pi 2 is running quite nicely. I&#39;ve got four 100MB files built up so far - so yes, Historian is running well. Heck of a data collection platform for under &#36;100 &#40;Pi 2, 32GB MicroSD, Case, Power Supply, and a RS232 serial port adapter&#41;.<p>

</div>



<div id="comment31628">

    <div class="SubText">

        <a name="C31628"></a>

        <a href="https://www.codeplex.com/site/users/view/ritchiecarroll">ritchiecarroll</a>

        <span class="smartDate" title="5/5/2015 8:19:53 PM" localtimeticks="1430882393">May 5, 2015 at 8:19 PM</span>&nbsp;

        

</div>

    Hi Andrew - yes, as you have already discovered, the openHistorian is already there - although we still need to post a config file that has this already enabled as per instructions. And BTW, the performance on the Pi 2 is very nice.<p>

</div>



<div id="comment31580">

    <div class="SubText">

        <a name="C31580"></a>

        <a href="https://www.codeplex.com/site/users/view/Andrew__M">Andrew__M</a>

        <span class="smartDate" title="4/21/2015 10:04:49 PM" localtimeticks="1429679089">Apr 21, 2015 at 10:04 PM</span>&nbsp;

        

</div>

    Does the openPDC image for Raspberry Pi have the openHistorian 1.0 built in to it&#63; I&#39;m going to give it a try with a Pi 2, but don&#39;t have the hardware yet. Thanks&#33;<p>

</div>



<div id="comment31476">

    <div class="SubText">

        <a name="C31476"></a>

        <a href="https://www.codeplex.com/site/users/view/ritchiecarroll">ritchiecarroll</a>

        <span class="smartDate" title="3/20/2015 8:48:21 PM" localtimeticks="1426909701">Mar 20, 2015 at 8:48 PM</span>&nbsp;

        

</div>

    It&#39;s ready...<p>

</div>



<div id="comment31475">

    <div class="SubText">

        <a name="C31475"></a>

        <a href="https://www.codeplex.com/site/users/view/Alessio_M">Alessio_M</a>

        <span class="smartDate" title="3/19/2015 6:01:06 PM" localtimeticks="1426813266">Mar 19, 2015 at 6:01 PM</span>&nbsp;

        

</div>

    Hi there&#33;<br>Any news on the openPDC image for Raspberry Pi&#63;<br><br>Thanks<p>

</div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="3/27/2015 1:30:35 AM" LocalTimeTicks="1427445035">Mar 27, 2015 at 1:30 AM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ritchiecarroll.md">ritchiecarroll</a>, version 10

Migrated from <a href="https://openpdc.codeplex.com/wikipage?title=Running%20openPDC%20on%20a%20Raspberry%20Pi">CodePlex</a> Oct 4, 2015 by <a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</html>


