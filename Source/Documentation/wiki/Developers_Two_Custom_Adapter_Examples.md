[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md)

|   |   |   |   |
|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org)** | **[openPDC Project on GitHub](https://github.com/GridProtectionAlliance/openPDC)** | **[openPDC Wiki Home](openPDC_Home.md)** | **[Documentation](openPDC_Documentation_Home.md)** |

# Two Custom Adapter Examples

This will detail the creation of two custom adapters to help demonstrate the process for those that are new to openPDC. These examples will go into slightly more detail and serve as a walk through for creating an adapter from conception to completion. The first custom adapter will read sample phasor data from a CSV file on initialization and subsequently pass that data as output one frame at a time. This may be useful for testing adapters without the presence of real time measurements when the user desires to control the value of the measurements as well. The second custom adapter will take as input the voltage magnitudes from the previous adapter and convert them to their per unit value and output them. This will show how to take input from the `PublishFrame()` method and perform calculations before subsequently outputting the newly calculated values.

A sample CSV file containing three 500kV positive sequence voltages can be found here: [samplePhasorData.csv](Developers_Two_Custom_Adapter_Examples.files/samplePhasorData.csv)

Begin by creating the first adapter which will serve as the data simulator.

## Open a New Project in Visual Studio

1. Run Visual Studio
2. Navigate to "File / New / Project"
3. Select "Class Library (Visual C#)"
4. Name your library "SampleDataSimulator" and click OK.

---

## Adding References

You'll first need to add the appropriate libraries from the openPDC source code. Open the Solution Explorer tab on the right of the window or navigate to "View / Solution Explorer". Right click on "References" and click "Add Reference".

A dialog box will appear allowing you to navigate to the directory which contains your library files.

Click on the "Browse Tab".

Navigate to the install directory for openPDC. This is typically located in `C:\Program Files\openPDC\`

Grab the following files from this directory:

- TimeSeriesFramework.dll
- TVA.Core.dll
- TVA.PhasorProtocols.dll

You should also grab the CSV reader library from here: [ReadWriteCSV.dll](Developers_Two_Custom_Adapter_Examples.files/ReadWriteCSV.dll) and add it as a reference to your project.

These libraries will now appear in the "References" section

---

## Coding the Data Simulator Adapter

Visual Studio will start you off with a simple shell to work from:

```cs
System;
System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SampleDataSimulator
{
    public class Class1
    {
    }
}
```

The top of the file is where you specify which libraries you'd like to use in your code.

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSeriesFramework;
using TimeSeriesFramework.Adapters;
using TVA;
using TVA.PhasorProtocols;
using ReadWriteCSV;
```

Rename your `Class1` to `sampleDataSimulator`.The next step is extend the base class of the `CalculatedMeasurementBase`.

```cs
namespace SampleDataSimulator
{
    public class sampleDataSimulator : CalculatedMeasurementBase
    {
    }
}
```

After you type the name of the base class a blue tab will appear under your parent class. Clicking on the tab will implement the abstract class. This will give you the`PublishFrame()` method for you to override. For this adapter you will also have to override the`Initialize()` method.
```cs
namespace SampleDataSimulator
{
    public class sampleDataSimulator : CalculatedMeasurementBase
    {
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void PublishFrame(IFrame frame,  int index)
        {
            throw new NotImplementedException();
        }
    }
}
```

Now we can begin with the customization of this adapter. Lets begin by giving it a few useful instance variables.

```cs
public class sampleDataSimulator : CalculatedMeasurementBase
{
    int numberOfFrames = 0;
    int numberOfRows = 0;
    int numberOfColumns = 0;
    string[,] voltagePhasorData = new string[100, 6];
    
    public override void Initialize()
    {...
```

The`numberOfFrames` variable will count the number of frames published by the adapter. The `numberOfRows` and `numberOfColumns` variables are just used for indexing during the reading of the CSV file. The two-dimensional string array `voltagePhasorData` will be used to store the data read in from the CSV file. The dimensions of the array are based on the dimensions of the data in the CSV file. There are 100 rows (or frames) of data with 6 measurements in each row.

The CSV file should only have to be read once and the adapter should have access to that data as long as the adapter remains. Because of this, the code to read the CSV file can be put into the `Initialize()` method and is only executed when the adapter is created.

```cs
public override void Initialize()
{
    /// Initialize the adapter in openPDC
    base.Initialize();
    
    /// Read voltage phasor data from CSV file
    using (CsvFileReader reader =  new CsvFileReader(@"C:\Program Files\openPDC\samplePhasorData.csv"))
    {
    CsvRow row = new CsvRow();
    while (reader.ReadRow(row))
    {
        foreach (string s in row)
        {
            voltagePhasorData[numberOfRows, numberOfColumns] = s;
            numberOfColumns++;
        }
    }
    
    /// Reset data indices
    numberOfRows = 0;
    numberOfColumns = 0;
    OnStatusMessage("'SampleDataSimulator' has been successfully initialized.");
    OnStatusMessage("'SampleDataSimulator' will begin to output simulated voltage phasors.");
}
```

The file location used in the constructor method call of `CsvFileReader` must be changed to the location on your machine where the sample data CSV file is located.

Now you can begin to override the `PublishFrame()` method. Start by incrementing `numberOfFrames`. This variable will be used for indexing the frame from the CSV file for output. `numberOfFrames` also must rollover before it exceeds the dimensions of the `voltagePhasorData` array.

```cs
protected override void PublishFrame(IFrame frame, int index)
{
    /// Increment number of published frames
    numberOfFrames++;
    
    /// Reset frame counter
    if (numberOfFrames > 99) /// Change this
    {
        numberOfFrames = 0;
    }
 }
```

Since you don't have to deal with any incoming measurements or computation in this adapter, you can move straight to preparing the sample data for output. Begin by creating an array of `IMeasurement` objects. You can think of this array you are creating as an array of blank measurements which have properties identical to those specified in the `outputMeasurements` parameter of the connection string.
```cs
/// Prepare to clone the output measurements.
IMeasurement[] outputMeasurements = OutputMeasurements;
```

Next, create a list of IMeasurement objects to use as the actual output measurements.

```cs
/// Create a list of IMeasurement objects
List<IMeasurement> output = new List<IMeasurement>();
```

Then, add each of the output measurements to the output list by cloning the blank measurements. Don`t forget to convert the data from a string to a double before outputting.

```cs
for (int i = 0; i > 6; i++)
{
    output.Add(Measurement.Clone(outputMeasurements[i],
       Convert.ToDouble(voltagePhasorData[numberOfFrames, i]),
       frame.Timestamp));
}
```

Lastly, you will use the `OnNewMeasurements()` method to output these measurements.

```cs
/// Output the next measurement frame
OnNewMeasurements(output);
```

Now, your `PublishFrame()` method in it's entirety should be as shown below:

```cs
protected override void PublishFrame(IFrame frame, int index)
{
    /// Increment number of published frames
    numberOfFrames++;
    
    /// Reset frame counter
    if (numberOfFrames > 99) /// Change this
    {
        numberOfFrames = 0;
    }
    
    /// Prepare to clone the output measurements.
    IMeasurement[] outputMeasurements = OutputMeasurements;
    
    /// Create a list of IMeasurement objects
    List<IMeasurement> output = new List<IMeasurement>();
    for (int i = 0; i < 6; i++)
    {
        output.Add(Measurement.Clone(outputMeasurements[i],
            Convert.ToDouble(voltagePhasorData[numberOfFrames, i]),
            frame.Timestamp));
    }
    
    /// Output the next measurement frame
    OnNewMeasurements(output);
    }
}
```

Now, compile your adapter in Visual Studio by pressinf *Shift+F6* or by navigating to
"Build / Build SampleDataSimulator" in the drop down menu. The first adapter is now complete. You can set this aside for now and begin the second adapter.

---

## Coding the Per Unit Calculator

Now that you have an adapter that will spit out some data for you, (it should go without saying that adapter reading from the CSV file is just used for development and testing purposes if there are no measurements available.) you can create another adapter which will take the voltage magnitudes from there and convert them to a per unit value. This example focuses on reading in the incoming measurements from the `IFrame` input parameter of the `PublishFrame()` method and ...

Open a new project in Visual Studio. Select "Class Library" again and name it "CalculatePerUnitValue". Again, Visual Studio will provide you with an empty shell to begin your project. As with the previous example, add the necessary references and include them at the top of your *.cs file.

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSeriesFramework;
using TimeSeriesFramework.Adapters;
using TVA;
using TVA.PhasorProtocols;
namespace CalculatePerUnitValue
{
    public class Class1
    {
       
    }
}
```

Rename the class to `MyNewAdapter` and extend the base class of `CalculatedMeasurementBase` by clicking on the blue tab that appears below the class declaration. You'll also want to override the `Initialize()` method again.

```cs
namespace CalculatePerUnitValue
{
    public class MyNewAdapter : CalculatedMeasurementBase
    {
        public override void Initialize()
        {
            base.Initialize();
        }
        protected overridevoid PublishFrame(IFrame frame, int index)
        {
            throw new NotImplementedException();
        }
    }
}
```

Add some useful instance variables to your adapter.<br>

```cs
int numberOfFrames;
int baseKV;
```

`numberOfFrames` will be used in a similar fashion to the previous adapter as well as used for timing console output. Here's an example: if you have an adapter with running at 30 frames per second it can be difficult to use the `OnStatusMessage()` method for effectively troubleshooting or debugging your adapter. However, if you maintain a counter based on the number of frames (the number of times `PublishFrame()` has been called) then you can used the modulus operator to slow down the console output. In the example below, if you modulus `numberOfFrames` by 30 then you can send a message to the console every 1 second for a 30 fps adapter. This is very useful for troubleshooting.

In the implementation of the `Initialize()` method, you will simply set `baseKV` (the measurements in the sample file are 500kV voltages) and send a message to the console.

```cs
public override void Initialize()
{
    base.Initialize();
    baseKV = 500000;
    /// Print to the console</span>
    OnStatusMessage("Adapter has been successfully initialized...");
}
```

You will begin the <i>PublishFrame()</i> method in the same manner as the previous adapter by incrementing `numberOfFrames` and forcing it to rollover.

```cs
protected override void PublishFrame(IFrame frame, int index)
{
    /// Increment the number of published frames. This number is
    /// used to properly time the console output.
    numberOfFrames++;
    
    /// So that the number of frames does not continue on forever
    /// The number is arbitrary, but it needs to rollover like this
    if (numberOfFrames > 1000)
    {
        numberOfFrames = 0;
    }
}
```

Then create a list to store the raw measurement values and a list to store the input measurement keys. While it is not done here, storing the input measurement keys in a similar manner to the raw measurements will give you a mechanism for sorting your measurements into a desired order.

```cs
/// Create a list to store the raw measurement values
List<double> processedMeasurements = new List<double>();

/// Create a list to store the input measurement keys
List<string> inputMeasurementKeys = new List<string>();
```

Now, you can extract the raw measurement values and the measurement keys from the `IFrame` input parameter. All of the information concerning the input measurements and time stamp is contained in this object. However, only the raw value and input measurement key are demonstrated in this example.

Here you will perform a simple calculation to convert the voltage magnitudes to their per unit equivalent and print a debug message to the console every 1 second.

```cs
/// Remove the measurement values from the IFrame object
foreach (IMeasurement measurement in frame.Measurements.Values)
{
    processedMeasurements.Add(measurement.Value / baseKV);
    inputMeasurementKeys.Add(measurement.Key.ToString());
    if (numberOfFrames % 30 == 0)
    {
        OnStatusMessage(measurement.Key.ToString() + ": " + measurement.Value.ToString());
    }
}
```

In the same way as the previous adapter, prepare the measurements for output before publishing.<br>

```cs
/// Prepare to clone the output measurements
IMeasurement[] outputMeasurements = OutputMeasurements;
/// Create a list to store the output measurements
List<IMeasurement> output = new List<IMeasurement>();
for (int i = 0; i < outputMeasurements.Length; i++)
{
    output.Add(Measurement.Clone(outputMeasurements[i],
        processedMeasurements[i],
        frame.Timestamp));
}
```

Now, send a message to output the measurements.<br>

```cs
/// Output the measurement
OnNewMeasurements(output);
```

This adapter is now complete. Compile your code as before.

---

## Adding the Adapters to openPDC

From the Visual Studio folder, navigate to "Projects / SampleDataSimulator / SampleDataSimulator / bin / Debug /" and grab the file "SampleDataSimulator.dll". Also, grab the file "CalculatePerUnitValue.dll" from its respective project folder.

Save the following files to the main openPDC directory:

- SampleDataSimulator.dll
- CalculatePerUnitValue.dll
- [ReadWriteCSV.dll](Developers_Two_Custom_Adapter_Examples.files/ReadWriteCSV.dll) (This is a file for reading from and writing to CSV files)
- [samplePhasorData.csv](Developers_Two_Custom_Adapter_Examples.files/samplePhasorData.csv) (This is a file containing the sample data for this example)

Now, run the openPDC Manager and navigate to the "Adapters" tab. Select "Calculated Measurements" as this is the type of adapters that you have created. Click on the "Clear" button to empty the fields before entering in the adapter information. First, begin with the data simulator adapter.

**Acronym:** `DATA`  
**Name:** `SampleDataSimulator`  
**Assembly:** `SampleDataSimulator.dll`  
**Type Name:** `SampleDataSimulator.sampleDataSimulator`  
**Frames Per Second:** `30`  
**Output Measurements:** `SIMULATEDPHASOR:1;SIMULATEDPHASOR:2;SIMULATEDPHASOR:3;SIMULATEDPHASOR:4;SIMULATOEDPHASOR:5;SIMULATEDPHASOR:6;`

The `Acronym` and `Name` parameters are arbitrary; you can use whatever you'd like here. The `Acronym` will be used as an identifier on the console output when your adapter sends a message to the console. The `Assembly` parameter is the name of the *.dll file containing your custom code. The `Type Name` parameter is the namespace of your adapter followed by the class name. For example:

**Type Name:** `namespace.class`

The `Output Measurements` parameter tells openPDC what ID to give to the measurements that your adapter outputs. You will then be able to use these IDs as input measurement keys to your per unit calculator to specify its input.

Make sure the "Enabled"check box is checked True and click the "Save" button.

Now repeat the procedure for the per unit converter adapter.

**Acronym:** `PU` 
**Name:** `PerUnitCalculator`    
**Assembly:** `CalculatePerUnitValue.dll`  
**Type Name:** `CalculatePerUnitValue.MyNewAdapter`  
**Frames Per Second:** `30`  
**Input Measurements:** `SIMULATEDPHASOR:1;SIMULATEDPHASOR:3;SIMULATEDPHASOR:5;`  
**Output Measurements:** `PERUNIT:1;PERUNIT:2;PERUNIT:3;`

*Note: Only the voltage magnitudes have been included as inputs to this adapter. The angles which the previous adapter output have not been included.*

Maked sure the "Enabled" check box is checked True and click the "Save" button.

Navigate to the "Home" tab of the openPDC Manager and restart openPDC. Once openPDC has been restarted, click on the "System Console". You should now see the adapters console output printing every second to the console. It should show the ID string for that measurement and its raw value.

---

## Making Changes to Your Adapter

In order for you to make changes to your adapter (if either there is a mistake or you would like to add something to it) you will need to make the changes in Visual Studio and compile as before. Then, you will have to put that into the openPDC directory. The problem with this is that if your *.dll file is name the same as its predecessor then you will not be able to overwrite it because openPDC is using it. In order to replace the old *.dll with the new one you must turn off the openPDC service completely.

Open the Windows Services Dialog Box (In Windows 7, type "services.msc" into the search field on the Start Menu). Scroll down until you see openPDC and click the stop button at the top or click the word "Stop" on the top left. Now, save the new *.dll into the openPDC directory, overwriting the old one. From the Services Dialog Box, click "Start". The openPDC service will start and you can now check for the changes that you have made.

*Note: If you are running on an older machine without a tremendous amount of resources (CPU, RAM, etc) it is recommended to close the openPDC Manager before starting the openPDC service again. Then, reopen the manager after the service has started. This will
 help prevent your machine from seizing up.*

---

Jul 1, 2012 6:27 PM - Last edited by [kevinjones](Contributors/kevinjones.md), version 2  
Oct 5, 2015 - Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Two%20Custom%20Adapter%20Examples)  by [aj](https://github.com/ajstadlin)

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)