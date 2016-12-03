[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md)

|   |   |   |   |
|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC)** | **[openPDC Wiki Home](openPDC_Home.md)** | **[Documentation](openPDC_Documentation_Home.md)** |

# Signal Reference Notes

For synchrophasor measurements the signal reference field is critical - it is used to map device elements in a protocol frame (e.g., IEEE C37.118) to and from measurements. The format of this field is very regular:

The text based signal reference field must contain the Acroynm of the associated Device, followed by a dash (`-`), followed by the two character SignalType Suffix then optionally followed by an index. Note that the mapping is by order, not by index or name. Thus, it is critical that the indexed measurements be modeled in the order that they are returned from the source device. For example SHELBY-PM4 represents the fourth phasor magnitude for the SHELBY Device and SHELBY-SF represents its status flags.

The information below describes the original specification:

---

In order to rebroadcast data from the sub-second sources, a field is required to be able to associate each point with its associated "field" in a synchrophasor protocol data frame. This document defines these relations.

This field is normally for internal use only and is stored in a field associated with each defined measurement point:

| **Type of Point** | Description | **Abbreviation** | **Indexed?** |
| ----------------- | ----------- | ---------------- | ------------ |
| Phasor Magnitude  | Voltage (Volts) or Current (Amps) | **PM** | Yes |
| Phasor Angle | Angle (Degrees) | **PA** | Yes |
| Frequency | Frequency (Hz) | **FQ** | No |
| dF/dt | Frequency rate of change | **DF** | No |
| Digital Value |    | **DV** | Yes |
| Analog Value |    | **AV** | Yes |
| Status Flags |    | **SF** | No |


Examples below follow the prescribed format of: the PMU/device acronym, a dash and one of the above abbreviations. Also, if the type of point is indexed, adding the associated entry index, for example:

|     |     |
| --- | --- |
| SHELBY-PM1 | ß Magnitude associated with Phasor1 entry |
| SHELBY-PA1 | ß Angle associated with Phasor1 entry |
| SHELBY-PM2 | ß Magnitude associated with Phasor2 entry |
| SHELBY-PA2 | ß Angle associated with Phasor2 entry |
| SHELBY-PM3 | ß Magnitude associated with Phasor3 entry |
| SHELBY-PA3 | ß Angle associated with Phasor3 entry |
| SHELBY-PM4 | ß Magnitude associated with Phasor4 entry |
| SHELBY-PA4 | ß Angle associated with Phasor4 entry |
| SHELBY-PM5 | ß Magnitude associated with Phasor5 entry |
| SHELBY-PA5 | ß Angle associated with Phasor5 entry |
| SHELBY-FQ | ß Frequency value associated with Frequency entry |
| SHELBY-DF | ß Rate of frequency change associated with Frequency entry |
| SHELBY-DV1 | ß Digital Value 1 |
| SHELBY-DV2 | ß Digital Value 2 |
| SHELBY-SF | ß Status Flags |

Using this information you can map individual measurements to and from most any synchrophasor protocol data frame.

---

Apr 12, 2013 at 5:55:03 PM - Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 7  
Oct 5, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=About%20the%20Signal%20Reference) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
