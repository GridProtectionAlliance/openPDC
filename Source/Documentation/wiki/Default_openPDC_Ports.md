[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Default openPDC Network Port Usage

- openPDC listens on **TCP 6165** for the gateway data exchange protocol, remote subscriptions (such as development PDCs) will connect to the openPDC on this port.
-	openPDC listens on **TCP 8500** for the remote console utility, however, if the console is only used locally this will not need a firewall rule.
-	Note that other firewall ports may need to be opened between openPDC and other substation devices (e.g., substationSBG and/or PMU connections). Connections to field devices are typically TCP based.
-	Windows environment elements (e.g., DFS Replication) may require additional firewall ports to be opened.

For reference, other service ports on openPDC that could be enabled include:

-	Historian metadata web-service that would listen on **port 6151**
-	Historian data web-service that would listen on **port 6152**
-	Statistics metadata web-service that would listen on **port 6051**
-	Statistics data web-service that would listen on **port 6052**
-	Alarm data web-service that would listen on **port 5018**
-	External AES mode data-publisher that would listen on **port 6166**
-	External TLS mode data-publisher that would listen on **port 6167**

---

Dec 14, 2016 - Converted to markdown from Default_openPDC_Ports.rtf by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)