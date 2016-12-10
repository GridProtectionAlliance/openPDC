[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Running openPDC in a Virtual Machine

Although the openPDC will run in a virtualized environment, and many deployments do this, there are various constraints which should be considered. Normally, GPA does not recommend running a *production* instance of the openPDC in a virtualized environment: phasor data input to the PDC is continuous and VM time slicing can result in bursts of output that are dependent on overall hardware loading of other virtualized machines running on the same hardware.

Accurate time management is a critical dimension of any PDC functionality, but is especially problematic under Hyper-V, which does not provide CPU clock counts during the VM sleep state. Other VM solutions, such as VMware attempt to make clock count adjustments based on sleep state.

As a massively multi-threaded application, the openPDC effectively utilizes all of the CPU cores available. Additionally, multiple streams of high volume network traffic being routed to the same physical network cards hosting the multiple virtual servers may cause I/O throttling or high collision rates. Therefore, the preferred solution is properly sizing physical hardware for the PDC.

---

Feb 23, 2015 2:51 PM - Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 2  
Oct 4, 2015 - Migrated from [CodePlex](https://openpdc.codeplex.com/wikipage?title=Running%20openPDC%20in%20Virtual%20Machine) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)