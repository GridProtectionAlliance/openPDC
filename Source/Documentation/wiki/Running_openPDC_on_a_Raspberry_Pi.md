![The Open Source Phasor Data Concentrator](https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png)
# Open Source Phasor Data Concentrator
***
    |    |    |    |
----|----|----|----|
[**Grid Protection Alliance**](http://www.gridprotectionalliance.org) | [**openPDC Project on GitHub**](https://github.com/GridProtectionAlliance/openPDC) | [**openPDC Wiki Home**](https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md) | [**Documentation**](https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Documentation_Home.md) |
***
# Running the openPDC on a Raspberry Pi and Pi 2
To avoid needing to compile Mono and speed up the installation process, we have posted an image for download with the needed version of Mono (i.e., version 3.12.1 that includes [FREAK security fix](http://www.mono-project.com/news/2015/03/07/mono-tls-vulnerability/)
) and the openPDC (i.e., version 2.1.64) preinstalled for running on a Raspberry Pi and Pi 2 with the Raspbian OS.  Download the zip file below that contains the image:

* [openPDC Raspbian Image](http://www.gridprotectionalliance.org/products/openPDC/Releases/2.1/POSIX/openPDC_Raspbian.zip) (2.08GB zipped)

Unzip the downloaded image file on a computer with an SD card reader. Note that the image size, when unzipped, is 6GB - as a result you will need an SD card at least that large to hold the image, 8 GB is the recommended minimum.  Make sure to read raspberrypi.org's information on [SD Cards](http://www.raspberrypi.org/documentation/installation/sd-cards.md).  Use the following instructions for deploying the image onto an SD card:

* [Windows](http://www.raspberrypi.org/documentation/installation/installing-images/windows.md)
* [Mac OS](http://www.raspberrypi.org/documentation/installation/installing-images/mac.md)
* [Linux](http://www.raspberrypi.org/documentation/installation/installing-images/linux.md">Linux)

For the initial boot it is recommended to start the Raspberry Pi up with a connected monitor and keyboard. When the Raspberry Pi is first powered on with the openPDC image on the SD card, the system will request a username and
 password - these are the defaults for a Raspbian OS image, specifically:
```
Login: pi
Password: raspberry
```
After you enter the default credentials, the Raspbian configuration application (raspi-config) will launch.  The following steps should be executed at a minimum:
* Run the "Expand Filesystem" command to make all SD card space available
* Run the "Change User Password" command for the default user *pi*
* Run the "Enable Boot to Desktop/Scratch" command to set desired boot operation

Once you have configured the Raspberry Pi, select "Finish" from the configuration tool to reboot the system. The openPDC is set to automatically run at startup as a daemon with security enabled. Run the following command from a terminal session to access the openPDC:
```
mono /opt/openPDC/openPDCConsole.exe
```

This will start the openPDC remote console session. Authentication is required, enter "pi" as the user name and the current password for this user.  The console may make a few authentication attempts with the provided credentials testing various authentication options.  Once authenticated, type "version" in the console and press Enter - this will show the running openPDC version and current OS details.

The default openPDC configuration comes with a sample device and an available IEEE C37.118 output stream.  If the Raspberry Pi is connected to a network, the outputs can be exercised immediately.  The IEEE C37.118 output stream will be listening on TCP port 8900 for both commands and data.

For best openPDC performance, the Raspberry Pi 2 is recommended.  The new Raspberry Pi 2 Model B has 4 cores, 1 GB of RAM and better CPU performance all of which provide a very practical and performant micro-environment for running the openPDC.  

The openPDC also runs on the original Raspberry Pi (same image for both platforms).  For optimal performance on this single core system it is recommended that the configuration of the openPDC on the Raspberry Pi be reduced to its primary tasks.

For more details, read the [openPDC Linux Deployment Instructions](https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_on_Linux_and_Mac.md)

Thanks!<br />
Ritchie

***

# openPDC on Raspberry Pi Example Procedures
* [openPDC on Raspberry Pi 3 Model B, Raspbian Jessie Full Desktop](https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_on_a_Raspberry_Pi.files/Example-openPDC_on_RaspberryPi-3B_Raspbian_Jessie.pdf)
* [openPDC on Raspberry Pi 3 Model B, Raspbian Jessie Lite](https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_on_a_Raspberry_Pi.files/Example-openPDC_on_RaspberryPi-3B_Raspbian_Jessie_Lite.pdf)
* [openPDC on Raspberry Pi Zero, Raspbian Jessie Lite](https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Running_openPDC_on_a_Raspberry_Pi.files/Example-openPDC_on_RaspberryPi-Zero_Raspbian_Jessie_Lite.pdf)

***

### Comments
* May 6, 2015 at 2:37:23 AM, Id# C31632 - [Andrew__M](https://www.codeplex.com/site/users/view/Andrew__M)<br />
> Thanks Ritchie - yes, the Pi 2 is running quite nicely. I've got four 100MB files built up so far - so yes, Historian is running well. Heck of a data collection platform for under $100 Pi 2, 32GB MicroSD, Case, Power Supply, and a RS232 serial port adapter.

* May 5, 2015 at 8:19:53 PM, Id# C31628 - [ritchiecarroll](https://www.codeplex.com/site/users/view/ritchiecarroll)<br />  
> Hi Andrew - yes, as you have already discovered, the openHistorian is already there - although we still need to post a config file that has this already enabled as per instructions. And BTW, the performance on the Pi 2 is very nice.

* Apr 21, 2015 at 10:04:49 PM, Id# C31580 - [Andrew__M](https://www.codeplex.com/site/users/view/Andrew__M)<br />
> Does the openPDC image for Raspberry Pi have the openHistorian 1.0 built in to it?  I'm going to give it a try with a Pi 2, but don't have the hardware yet. Thanks!

* Mar 20, 2015 at 8:48:21 PM, Id# C31476 - [ritchiecarroll](https://www.codeplex.com/site/users/view/ritchiecarroll)<br />
> It's ready...

* Mar 19, 2015 at 6:01:06 PM, Id# C31475 - [Alessio_M](https://www.codeplex.com/site/users/view/Alessio_M)<br />
> Hi there, Any news on the openPDC image for Raspberry Pi?  Thanks

***

Edited Mar 27, 2015 1:30:35 AM by [ritchiecarroll](https://github.com/ritchiecarroll), version 10<br />
Migrated Oct 4, 2015 by [//aj](https://github.com/ajstadlin) from [CodePlex](https://openpdc.codeplex.com/wikipage?title=Running%20openPDC%20on%20a%20Raspberry%20Pi)<br />
Edited Aug 14, 2016 11:45:00 AM by [//aj](https://github.com/ajstadlin)

***
####
Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)