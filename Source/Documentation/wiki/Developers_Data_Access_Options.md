[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# openPDC Data Access Options

1. [Real-time data acquisition](#1-real-time-data-acquisition)
2. [Near real-time data acquisition](#2-near-real-time-data-acquisition)
3. [Historical data acquisition](#3-historical-data-acquisition)

---

## 1. Real-time data acquisition

The openPDC supports real-time subscription based data acquisition via the Gateway Exchange Protocol. You can see the API in action on the Graph Measurements screen inside the openPDC Manager - every time you check a new point in the list it "subscribes" via this real-time API. Code usage is fairly simple - there is an API that can be called to "subscribe" to data in multiple formats (example below). API's exist for .NET, Java, C++ and Unity 3D:

- Assembly: `GSF.TimeSeries.dll`
- Class: `GSF.TimeSeries.Transport.DataSubscriber`
- Relevant Methods:

```cs
/// <summary>
/// Subscribes (or re-subscribes) to a data publisher for a synchronized set of data points.
/// </summary>
/// <param name="compactFormat">Boolean value that determines if the compact measurement format should be used. Set to false for full fidelity measurement serialization; otherwise set to true for bandwidth conservation.</param>
/// <param name="framesPerSecond">The desired number of data frames per second.</param>
/// <param name="lagTime">Allowed past time deviation tolerance, in seconds (can be subsecond).</param>
/// <param name="leadTime">Allowed future time deviation tolerance, in seconds (can be subsecond).</param>
/// <param name="filterExpression">Filtering expression that defines the measurements that are being subscribed.</param>
/// <param name="useLocalClockAsRealTime">Boolean value that determines whether or not to use the local clock time as real-time.</param>
/// <param name="ignoreBadTimestamps">Boolean value that determines if bad timestamps (as determined by measurement's timestamp quality) should be ignored when sorting measurements.</param>
/// <param name="allowSortsByArrival">Gets or sets flag that determines whether or not to allow incoming measurements with bad timestamps to be sorted by arrival time.</param>
/// <param name="timeResolution">Gets or sets the maximum time resolution, in ticks, to use when sorting measurements by timestamps into their proper destination frame.</param>
/// <param name="allowPreemptivePublishing">Gets or sets flag that allows system to preemptively publish frames assuming all expected measurements have arrived.</param>
/// <param name="downsamplingMethod">Gets the total number of downsampled measurements processed by the concentrator.</param>
/// <returns>true if subscribe was successful; otherwise false.</returns>

public virtual bool SynchronizedSubscribe(
    bool compactFormat, 
    int framesPerSecond, 
    double lagTime, 
    double leadTime, 
    string filterExpression, 
    bool useLocalClockAsRealTime = false,
    bool ignoreBadTimestamps = false,
    bool allowSortsByArrival = true, 
    long timeResolution = Ticks.PerMillisecond, 
    bool allowPreemptivePublishing = true, 
    DownsamplingMethod downsamplingMethod = DownsamplingMethod.LastReceived);

/// <summary>
/// Subscribes (or re-subscribes) to a data publisher for an unsynchronized set of data points.
/// </summary>
/// <param name="compactFormat">Boolean value that determines if the compact measurement format should be used. Set to false for full fidelity measurement serialization; otherwise set to true for bandwidth conservation.</param> 
/// <param name="throttled">Boolean value that determines if data should be throttled at a set transmission interval or sent on change.</param>
/// <param name="filterExpression">Filtering expression that defines the measurements that are being subscribed.</param>
/// <param name="lagTime">When <paramref name="throttled" /> is true, defines the data transmission speed in seconds (can be subsecond).</param>
/// <param name="leadTime">When <paramref name="throttled" /> is true, defines the allowed time deviation tolerance to real-time in seconds (can be subsecond).</param>
/// <param name="useLocalClockAsRealTime">When <paramref name="throttled" /> is true, defines boolean value that determines whether or not to use the local clock time as real-time. Set to false to use latest received measurement timestamp as real-time.</param>
/// <returns> true if subscribe was successful; otherwise false.</returns>

public virtual bool UnsynchronizedSubscribe(
    bool compactFormat, 
    bool throttled, 
    string filterExpression, 
    double lagTime = 10.0D, 
    double leadTime = 5.0D,
    bool useLocalClockAsRealTime = false);
```

### Here is an operational example:

- [*GridSolutionsFramework Application:* DataSubscriberTestProgram](https://github.com/GridProtectionAlliance/gsf/tree/master/Source/Applications/DataSubscriberTest)

Note that all this code exists in the TimeSeries Framework - this is important since phasor gateways, historians, etc. in the future can all use this same code.

These two API calls provide the following possible real-time data subscriptions:

- A synchronized (i.e., concentrated by time) set of subscribed data points
- An on-change unsynchronized set of subscribed data points
- A throttled (e.g., downsampled to every few seconds) unsynchronized set of subscribed data points

To pick up data you simply attach to the NewMeasurements event and receive a collection of measurements:

```cs
static DataSubscriber subscriber = new DataSubscriber();
subscriber.NewMeasurements += subscriber_NewMeasurements;

// Initialize subscriber
subscriber.ConnectionString = "server=localhost:6165";
subscriber.Initialize();

// Start subscriber connection cycle
subscriber.Start();

static void subscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
{
    dataCount += e.Argument.Count;

    if (dataCount % (5 * 60) == 0)
        Console.WriteLine(string.Format("{0} total measurements received so far: {1}", dataCount, e.Argument.ToDelimitedString(", ")));
}
```

To better understand using this API, open the [GridSolutionFramework](https://github.com/GridProtectionAlliance/gsf) solution and evaluate the [DataSubscriberTest](https://github.com/GridProtectionAlliance/gsf/tree/master/Source/Applications/DataPublisherTest) application. You can run this application in debug mode (multiple instances actually) as well as starting an instance of the associated DataPublisherTest app to see it in action.

## 2. Near real-time data acquisition

With the development of this new real-time API, the web service based data acquisition for near-real time data that has always existed will now be optional - that is, if a user "chooses" to install a local historian (this is being added as a configuration setup screen step) then the near real-time data web service will then be available - otherwise it will not be available for data. It should be noted that the statistics historian is a separate local historian and will always be available. This data access option uses the web service API:

[Getting Started, Time Series WebService](Getting_Started.md#time-series-web-service)

## 3. Historical data acquisition

When accessing the statistics historian or the optional local historian for historical data you can always use the web service aforementioned in [2. Near real-time data acquisition](#2-near-real-time-data-acquisition) - details in the web-link above. Note however, there is another, more direct, way to access the data. For faster historical data acquisition you can use the historian API directly. For an example of how to use this you can look at the statistics reader code in the GridSolutionsFramework HistorianAdapters library:

- [*GridSolutionsFramework* Source/Libraries/Adapters/HistorianAdapters/StatisticsReader.cs](https://github.com/GridProtectionAlliance/gsf/blob/master/Source/Libraries/Adapters/HistorianAdapters/StatisticsReader.cs)

This API reads data directly from the historical `.D` files over a given time span as fast as possible. Additionally, you can look at the source code for the [*GridSolutionsFramework* Source/Tools/HistorianPlaybackUtility](https://github.com/GridProtectionAlliance/gsf/tree/master/Source/Tools/HistorianPlaybackUtility) for another example of how to use the data read / extraction API directly.

---

Dec 3, 2016 11:00 PM - Last edited by [aj](https://github.com/ajstadlin), version 4  
Jun 10, 2014 3:08:40 PM - Edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 3  
Oct 5, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Data%20Access%20Options%20%28Developers%29) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)