[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](https://github.com/GridProtectionAlliance/openPDC/wiki)** | **[Documentation](https://github.com/GridProtectionAlliance/openPDC/wiki/Documentation)** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# Custom Point Tag Naming Convention

As of version 2.0.166, the openPDC now supports custom point tag naming conventions, i.e., the format of the point tag names automatically created by the system for device measurements can now be controlled by an expression. The expression is defined in the openPDC.exe.config file under `systemSettings\PointTagNameExpression`.

As an example, here is a possible tag naming convention expression:

`{CompanyAcronym}_{DeviceAcronym}[?{SignalType.Source}=Phasor[-{SignalType.Suffix}{SignalIndex}]]:[?{Phase}=A[PhaseA_]][?{Phase}=B[PhaseB_]][?{Phase}=C[PhaseC_]][?{Phase}=+;[PosSeq_]][?{Phase}=-[NegSeq_]][?{Phase}=0[ZeroSeq_]]{SignalType.LongAcronym}[?{SignalType.Source}!=Phasor[?{SignalIndex}!=-1[{SignalIndex}]]]`

Here are examples that would come from the expression above assuming a device name of SHELBY:

- `GPA_SHELBY-PM1:PosSeq_VoltageMagnitude`
- `GPA_SHELBY-PA1:PosSeq_VoltageAngle`
- `GPA_SHELBY-PM2:PosSeq_CurrentMagnitude`
- `GPA_SHELBY-PA2:PosSeq_CurrentAngle`
- `GPA_SHELBY-PM3:PhaseA_VoltageMagnitude`
- `GPA_SHELBY-PA3:PhaseA_VoltageAngle`
- `GPA_SHELBY-PM4:PhaseA_CurrentMagnitude`
- `GPA_SHELBY-PA4:PhaseA_CurrentAngle`
- `GPA_SHELBY:Frequency`
- `GPA_SHELBY:DfDt`
- `GPA_SHELBY:Analog1`
- `GPA_SHELBY:Analog2`
- `GPA_SHELBY:Digital1`
- `GPA_SHELBY:Digital2`
- `GPA_SHELBY:StatusFlags`
- `GPA_SHELBY:QualityFlags`

The `{CompanyAcronym}`, `{DeviceAcronym}`, `{VendorAcronym}`, `{PhasorLabel}`, `{Phase}`, and `{SignalIndex}` are fixed parameter fields. `{Phase}` defaults to "_" (underscore) meaning no phase (i.e., tag is not a phasor) and `{SignalIndex}` defaults to -1 meaning no signal index (i.e., tag is not enumerated). Any `{SignalType.*}` field is derived from the SignalType table in the database (see below). Note that `{SignalIndex}` will always be enumerated (i.e., not -1) for the following signal types: IPHM, IPHA, VPHM, VPHA, ALOG, DIGI and STAT; and when `{SignalType.Source}=Phasor`, `{Phase}` will be one of A, B, C, +, -, or 0.

All field expressions surrounded in `{ }` will be immediately replaced with their string equivalents before further expression evaluation. Note that as a result of the expression syntax `<`, `>`, `=`, `!`, `{`, `}`, `[`, and `]` are reserved symbols. To embed any of these symbols into the final point tag name you must prefix the symbol with a backslash, e.g., the expression `\[{SignalType.Acronym}\]` when the acronym was VPHA would result in `[VPHA]`.

Optional expressions are represented with `[?expression[result]]` and can be nested (e.g., `[?expression1[?expression2[result]]]`). Expressions should not contain extraneous white space for proper evaluation.

Only simple boolean comparison operations are allowed in expressions, e.g., `A=B` (or `A==B`), `A!=B` (or `A<>B`), `A>B`, `A>=B`, `A<B` and `A<=B` - nothing more. Any expression that fails to evaluate will be evaluated as FALSE. Note that if both left (A) and right (B) operands can be parsed as a number (i.e., as an integer or floating-point value) then the expression will be numerically evaluated otherwise expression will be a culture and case-insensitive string comparison. Nested expressions are evaluated as cumulative AND operators. There is no defined nesting limit.
 
Note that the `{SignalType.*}` parameter fields are derived from the following table:

| **ID** | **Name** | **Acronym** | **Suffix** | **Abbreviation** | **LongAcronym** | **Source** | **EngineeringUnits** |
| ------ | -------- | ----------- | ---------- | ---------------- | --------------- | ---------- | -------------------- |
| **1** | Current Magnitude | IPHM | PM | I | CurrentMagnitude | Phasor | Amps |
| **2** | Current Phase Angle | IPHA | PA | IH | CurrentAngle | Phasor | Degrees |
| **3** | Voltage Magnitude | VPHM | PM | V | VoltageMagnitude | Phasor | Volts |
| **4** | Voltage Phase Angle | VPHA | PA | VH | VoltageAngle | Phasor | Degrees |
| **5** | Frequency | FREQ | FQ | F | Frequency | PMU | Hz |
| **6** | Frequency Delta (dF/dt) | DFDT | DF | DF | DfDt | PMU |    |
| **7** | Analog Value | ALOG | AV | AV | Analog | PMU |    |
| **8** | Status Flags | FLAG | SF | S | StatusFlags | PMU |    |
| **9** | Digital Value | DIGI | DV | DV | Digital | PMU |    |
| **10** | Calculated Value | CALC | CV | CV | Calculated | PMU |    |
| **11** | Statistic | STAT | ST | ST | Statistic | Any |    |
| **12** | Alarm | ALRM | AL | AL | Alarm | Any |    |
| **13** | Quality Flags | QUAL | QF | QF | QualityFlags | Frame |    |

---

Jul 25, 2014 7:07:57 PM Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 8  
Oct 4, 2015 Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Custom%20Point%20Tag%20Naming%20Convention) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
