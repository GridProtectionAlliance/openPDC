[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# How to Bulk Apply line-to-line Sqrt(3) Adjustment to all Voltage Magnitudes

The following SQL server script can be run against your openPDC configuration database to convert all line-to-neutral voltage magnitudes to line-to-line by applying a square root of 3 factor to the value:

```sql
USE openPDC
GO
UPDATE Measurement SET Multiplier = 1.732050807568877 
WHERE Measurement.PointID IN
    (SELECT CONVERT(INT, SUBSTRING(ID, CHARINDEX(':', ID) + 1, 10)) AS PointID
    FROM ActiveMeasurement WHERE SignalType='VPHM')
```

---

Aug 1, 2012 4:38 PM - Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 6  
Oct 4, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Bulk%20apply%20line-to-line%20Sqrt%283%29%20adjustment%20to%20all%20voltage%20magnitudes) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)