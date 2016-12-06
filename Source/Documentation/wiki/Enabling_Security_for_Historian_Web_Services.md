[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md)

|   |   |   |   |
|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC)** | **[openPDC Wiki Home](openPDC_Home.md)** | **[Documentation](openPDC_Documentation_Home.md)** |

# Enabling Security for Historian Web Services

Below are a few easy steps to turn on security for the historian time-series data services. This uses the same role-based security as defined in the openPDC, i.e., you will control access to the web service using the openPDC Manager security configuration.

In the example configuration steps defined below as long as a user and/or group has a "role" defined in the openPDC security system (i.e., a Windows user and/or group has a defined role of Administrator, Editor or Viewer) then they can access the read portion of the web service. Only Administrator and Editor roles will have write access.

You can modify the IncludedResources value to further control security if needed, e.g., allow different access control to statistics and data historians. For example, setting the `IncludedResources` value to: `"*:6152/historian/timeseriesdata/read/*=*; *:6152/historian/timeseriesdata/write/*=Administrator,Editor;"` turns on security for data historian but not statistics historian.

If you want any user or group that has a role defined in the openPDC to have access to read or writes in any of the historian web services, the value to insert into IncludedResources can be very simple: `"*/historian/*=*; "`.

Configuration steps:

1. top openPDC service
2. Edit openPDC.exe.config file (have to run editor with admin access) and make following changes:
    - **`configuration\categorizedSettings\securityProvider\add name="IncludedResources"`** - insert the following text into the value:  **`"*/historian/timeseriesdata/read/*=*; */historian/timeseriesdata/write/*=Administrator,Editor; "`**
    - **`configuration\categorizedSettings\ppaTimeSeriesDataService\add name="SecurityPolicy"`** - set value to **`"GSF.ServiceModel.SecurityPolicy, GSF.ServiceModel"`**
3. Save openPDC.exe.config
4. Restart openPDC service

XML updates should look similar to the following:<br>
```xml
<configuration>
  <categorizedSettings>
    <securityProvider>
      <add name="IncludedResources" value="*/historian/timeseriesdata/read/*=*; */historian/timeseriesdata/write/*=Administrator,Editor;  UpdateSettings,UpdateConfigFile=Special; Settings,Schedules,Help,Status,Version,Time,Health,List,Invoke,ListCommands,ListReports,GetReport=*; Processes,Start,ReloadCryptoCache,ReloadSettings,Reschedule,Unschedule,SaveSchedules,LoadSchedules,ResetHealthMonitor,Connect,Disconnect,Initialize,ReloadConfig,Authenticate,RefreshRoutes,TemporalSupport,LogEvent,GenerateReport,ReportingConfig=Administrator,Editor; *=Administrator" description="Semicolon delimited list of resources to be secured along with role names." encrypted="false" />
    </securityProvider>
    <ppaTimeSeriesDataService>
      <add name="SecurityPolicy" value="GSF.ServiceModel.SecurityPolicy, GSF.ServiceModel" description="Assembly qualified name of the authorization policy to be used for securing the web service." encrypted="false" />
    </ppaTimeSeriesDataService>
  </categorizedSettings>
</configuration>
```

---

Jun 19, 2014 6:56 PM - Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 7  
Oct 2, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Enabling%20Security%20for%20Historian%20Web%20Services) by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)