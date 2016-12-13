[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Controlling UDP Data Loss

Regarding the issues that some openPDC users have reported about UDP data loss on 120 fps streams, a new parameter has been introduced to the connection string for input devices called *bufferSize*. This property controls the size of the kernel buffer used to receive data from the device so that packets will not be dropped during garbage collection. If you are experiencing UDP data loss, try increasing the buffer size by setting this property via the connection string used to connect to your device.

Example connection string (2 MB buffer):

`localport=4712; transportprotocol=udp; interface=0.0.0.0;` **`bufferSize=2097152`**

If modifying this property does not solve the UDP data loss, you may also try reading the information below.

---

Some openPDC users have reported UDP data loss on 120 fps streams and/or systems that were heavily loaded. That is even though Wireshark reported all the data arriving on the system, the openPDC wasn't receiving all the data. The issue here is the .NET Garbage Collector that blocks threads during a blocking/forced unused memory collection every 10-15 seconds - the more memory that is in use amplifies the time required to collect. More specifically, if you do not retrieve data from the Windows UDP socket buffer queue fast enough it will replace the existing buffer with new data. When the garbage collector starts taking more time there is more opportunity for loss (data replacement with new data) on the UDP socket. During garbage collection data loss can simply be caused by amplification in memory usage (which causes GC to take longer) or heavily loaded system (meaning the GC is competing for CPU and therefore taking longer). The issue can occur simply by increasing samples per second and/or using large lag times, like 30 seconds.

The solution is to force garbage collection more often. All recent versions of the openPDC include a setting in the configuration file to do a generation zero garbage collection on a specified interval - increasing the frequency of garbage collection for generation zero objects on the 4.0 framework will resolve data loss when lag times (i.e., basic memory utilization) are reasonable (e.g., 3-5 seconds of lag time) even when receiving data at 120 samples per second

On .NET 4.0 builds the issue can return once lag times are increased (e.g., to 30 seconds) thereby increasing memory pressure and the need to collect large volumes of data - this is because with a large lag time the allocated memory will be promoted to generation 2 and 3 and a generation zero collection will be ineffective. Increasing the garbage collection to generation to 2 or 3 on an interval may increase CPU loading to a point where data can again occur.

On .NET 4.5 the garbage collector has been vastly improved - the improvements include an "optimized" collect as well the ability to perform a non-blocking collect. On the .NET 4.5 build of the openPDC, code has been modified such that the interval garbage collection method can be performed against generation 1 through 3 objects using optimized, non-blocking garbage collection running every 5 milliseconds without a significant impact on CPU loading\*. With this in place testing showed no data loss even with significant memory usage at 120 samples per second.

***Bottom line:***

If you are experiencing UDP data loss on GPA products where you can confirm that data is being received (e.g., with Wireshark), simply enabling the interval garbage collection method may help (i.e., change the `systemSettings/GCGenZeroInterval` to 50 milliseconds); continuing to increase frequency (i.e., lower interval) could make a difference. Upgrading the system to the .NET 4.5 version of the openPDC (version 2.0) will resolve the issue entirely.

\* Note that on .NET 4.5 deployments, garbage collection performance can be affected by the runtime settings in the config file (e.g., openPDC.exe.config). If these settings are defined in config file (see example below), please remove them so that the default settings will be used:

```xml
<runtime>
    <gcConcurrent enabled="false" />
    <gcServer enabled="true" />
</runtime>
```

---

Apr 22, 2013 at 3:30:20 PM Last edited by [staphen](http://www.codeplex.com/site/users/view/staphen), version 4  
Oct 4, 2015 Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Controlling%20UDP%20Data%20Loss) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)