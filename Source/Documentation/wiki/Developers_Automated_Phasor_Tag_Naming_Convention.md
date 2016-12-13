[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Automated Phasor Tag Naming Convention

In a semi-formal summary, the following is the format the openPDC uses for its automated tag naming convention used to identify measurements:

## BNF Grammar:

|     |     |     |     |
| --- | --- | --- | --- |
| **Digit** | `:=` | `[ "A-Z", "0-9", -, !, _, @, #, $]` | Upper case letters, numbers, '!', '-', '@', '#', '_' and '$' are allowed characters |
| **CompanyID** | `:=` | `<Digit>{3}` | 3 Digit company abbreviation, example list below |
| **PMUID** | `:=` | `<Digit>+` | Variable length device acronymn |
| **Constraint** | `:=` | `<Digit>+` | Optional variable length uniqueness constraint, typically phase angle or magnitude reference and index (e.g., PA1 or PM3) |
| **PMUType** | `:=` | `<Digit>{3}` | Optional 3 digit PMU Type/Brand, list suggested below |
| **SignalType** | `:=` | `<Digit><Digit>?` | 1 or 2 digit signal type code, list suggested below |
| **TagName** | `:=` | `<CompanyID> "_" <PMUID> ( "-" <Constraint> )? ":" <PMUType>? <SignalType>` 

### Described verbally, the measurement point tag name will be defined as follows:

1. A three digit company ID followed by an underscore, followed by
2. The PMU/device acronym, followed by
3. A dash and optionally a phase angle (i.e., &quot;PA&quot;) or magnitude (i.e., &quot;PM&quot;) marker with index needed to create a unique point name, followed by
4. A colon and an optional three digit PMU brand abbreviation, followed by
5. A 1 or 2 digit signal type

### Example 3-Digit Company Abbreviations:

| **Company Name** | **Abbreviation** |
| ---------------- | ---------------- |
| Entergy | ENT |
| TVA | TVA |
| Amern | AMR |
| New York ISO | NYI 
| New York Power Authority | NYP |
| NERC | NRC |
| AEP | AEP |

### Suggested PMU Type/Brand List:

| **PMU Brand** | **Abbreviation** |
| ------------- | ---------------- |
| Arbiter | ARB |
| ABB | ABB |
| Mehtatech | MTA |
| Machrodyne | MAC |
| Schweitzer | SEL |

### Signal Type Code List:

| **Signal Type** | **Abbreviation** |
| --------------- | ---------------- |
| Current | I |
| Voltage | V |
| Frequency | F |
| Phase Angle | H |
| Frequency Error | DF |
| Status | S |
| Digital Value 1 | D1 |
| Digital Value 2 | D2 |
| Analog Value 2 | A1 |
| Analog Value 2 | A2 |

---

Aug 7, 2013 at 5:07 PM - Last edited  by [ritchiecarroll](https://github.com/ritchiecarroll), version 6  
Oct 5, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Automated%20Phasor%20Tag%20Naming%20Convention) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)