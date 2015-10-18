

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head>

<meta charset="utf-8" />

<title>Developers Two Customer Adapter Examples</title>



<!--HtmlToGmd.Head-->



<!--/HtmlToGmd.Head-->

</head>

<body>

<h1><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Logo.png" alt="The Open Source Phasor Data Concentrator" /></a></h1>

<hr />

<!--HtmlToGmd.Body-->

<div id="NavigationMenu">

<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">

<tr>

<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>

<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>

</tr>

</table>

</div>

<hr />

<!--/HtmlToGmd.Body-->



<div class="WikiContent">

<div class="wikidoc">This will detail the creation of two custom adapters to help demonstrate the process for those that are new to openPDC. These examples will go into slightly more detail and serve as a walk through for creating an adapter from conception

 to completion. The first custom adapter will read sample phasor data from a CSV file on initialization and subsequently pass that data as output one frame at a time. This may be useful for testing adapters without the presence of real time measurements when

 the user desires to control the value of the measurements as well. The second custom adapter will take as input the voltage magnitudes from the previous adapter and convert them to their per unit value and output them. This will show how to take input from

 the <i>PublishFrame()</i> method and perform calculations before subsequently outputting the newly calculated values.<br>

<br>

A sample CSV file containing three 500kV positive sequence voltages can be found here:

<a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Two_Customer_Adapter_Examples.files/samplePhasorData.csv">

samplePhasorData.csv</a><br>

<br>

Begin by creating the first adapter which will serve as the data simulator.

<hr>

<h2>Open a New Project in Visual Studio</h2>

<ol>

<li>Run Visual Studio. </li><li>Navigate to File / New / Project. </li><li>Select <i>Class Library (Visual C#)</i>. </li><li>Name your library <i>SampleDataSimulator</i> and click OK.</li></ol>

<hr>

<h2>Adding References</h2>

You&#39;ll first need to add the appropriate libraries from the openPDC source code. Open the Solution Explorer tab on the right of the window or navigate to

<i>View / Solution Explorer</i>. Right click on <i>References</i> and click <i>Add Reference</i>.

<br>

<br>

A dialog box will appear allowing you to navigate to the directory which contains your library files.

<br>

<br>

Click on the <i>Browse Tab</i>.<br>

<br>

Navigate to the install directory for openPDC. This is typically located in <i>C:/Program Files/openPDC/</i><br>

<br>

Grab the following files from this directory:

<ul>

<li>TimeSeriesFramework.dll </li><li>TVA.Core.dll </li><li>TVA.PhasorProtocols.dll</li></ul>

<br>

You should also grab the CSV reader library from here: <a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Two_Customer_Adapter_Examples.files/ReadWriteCSV.dll">

ReadWriteCSV.dll</a> and add it as a reference to your project.<br>

<br>

These libraries will now appear in the <i>References</i> section <br>

<hr>

<h2>Coding the Data Simulator Adapter</h2>

Visual Studio will start you off with a simple shell to work from:<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">using</span> System;

<span style="color:Blue">using</span> System.Collections.Generic;

<span style="color:Blue">using</span> System.Linq;

<span style="color:Blue">using</span> System.Text;



<span style="color:Blue">namespace</span> SampleDataSimulator

{

    <span style="color:Blue">public</span> <span style="color:Blue">class</span> Class1

    {

    }

}

</pre>

</div>

<br>

The top of the file is where you specify which libraries you&#39;d like to use in your code.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">using</span> System;

<span style="color:Blue">using</span> System.Collections.Generic;

<span style="color:Blue">using</span> System.Linq;

<span style="color:Blue">using</span> System.Text;

<span style="color:Blue">using</span> TimeSeriesFramework;

<span style="color:Blue">using</span> TimeSeriesFramework.Adapters;

<span style="color:Blue">using</span> TVA;

<span style="color:Blue">using</span> TVA.PhasorProtocols;

<span style="color:Blue">using</span> ReadWriteCSV;

</pre>

</div>

<br>

Rename your <i>Class1</i> to <i>sampleDataSimulator</i>.The next step is extend the base class of the

<i>CalculatedMeasurementBase</i>. <br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">namespace</span> SampleDataSimulator

{

    <span style="color:Blue">public</span> <span style="color:Blue">class</span> sampleDataSimulator : CalculatedMeasurementBase

    {



    }

}

</pre>

</div>

<br>

After you type the name of the base class a blue tab will appear under your parent class. Clicking on the tab will implement the abstract class. This will give you the

<i>PublishFrame()</i> method for you to override. For this adapter you will also have to override the

<i>Initialize()</i> method.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">namespace</span> SampleDataSimulator

{

    <span style="color:Blue">public</span> <span style="color:Blue">class</span> sampleDataSimulator : CalculatedMeasurementBase

    {

        <span style="color:Blue">public</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> Initialize()

        {

            <span style="color:Blue">base</span>.Initialize();

        }



        <span style="color:Blue">protected</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> PublishFrame(IFrame frame, <span style="color:Blue">int</span> index)

        {

            <span style="color:Blue">throw</span> <span style="color:Blue">new</span> NotImplementedException();

        }

    }

}

</pre>

</div>

<br>

Now we can begin with the customization of this adapter. Lets begin by giving it a few useful instance variables.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">public</span> <span style="color:Blue">class</span> sampleDataSimulator : CalculatedMeasurementBase

{



    <span style="color:Blue">int</span> numberOfFrames = 0;

    <span style="color:Blue">int</span> numberOfRows = 0;

    <span style="color:Blue">int</span> numberOfColumns = 0;

    <span style="color:Blue">string</span>[,] voltagePhasorData = <span style="color:Blue">new</span> <span style="color:Blue">string</span>[100, 6];



    <span style="color:Blue">public</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> Initialize()

    {...

</pre>

</div>

<br>

The <i>numberOfFrames</i> variable will count the number of frames published by the adapter. The

<i>numberOfRows</i> and <i>numberOfColumns</i> variables are just used for indexing during the reading of the CSV file. The two-dimensional string array

<i>voltagePhasorData</i> will be used to store the data read in from the CSV file. The dimensions of the array are based on the dimensions of the data in the CSV file. There are 100 rows (or frames) of data with 6 measurements in each row.<br>

<br>

The CSV file should only have to be read once and the adapter should have access to that data as long as the adapter remains. Because of this, the code to read the CSV file can be put into the

<i>Initialize()</i> method and is only executed when the adapter is created.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">public</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> Initialize()

{

    <span style="color:Gray">///</span><span style="color:Green"> Initialize the adapter in openPDC</span>

    <span style="color:Blue">base</span>.Initialize();



    <span style="color:Gray">///</span><span style="color:Green"> Read voltage phasor data from CSV file</span>

    <span style="color:Blue">using</span> (CsvFileReader reader =  <span style="color:Blue">new</span> CsvFileReader(<span style="color:#A31515">@&quot;C:\Program Files\openPDC\samplePhasorData.csv&quot;</span>))

    {

    CsvRow row = <span style="color:Blue">new</span> CsvRow();

    <span style="color:Blue">while</span> (reader.ReadRow(row))

    {

        <span style="color:Blue">foreach</span> (<span style="color:Blue">string</span> s <span style="color:Blue">in</span> row)

        {

            voltagePhasorData[numberOfRows, numberOfColumns] = s;

             numberOfColumns&#43;&#43;;

        }

            numberOfRows&#43;&#43;;

            numberOfColumns = 0;

        }

    }



    <span style="color:Gray">///</span><span style="color:Green"> Reset data indices</span>

    numberOfRows = 0;

    numberOfColumns = 0;



    OnStatusMessage(<span style="color:#A31515">&quot;&#39;SampleDataSimulator&#39; has been successfully initialized.&quot;</span>);

    OnStatusMessage(<span style="color:#A31515">&quot;&#39;SampleDataSimulator&#39; will begin to output simulated voltage phasors.&quot;</span>);

}

</pre>

</div>

<br>

The file location used in the constructor method call of <i>CsvFileReader</i> must be changed to the location on your machine where the sample data CSV file is located.<br>

<br>

Now you can begin to override the <i>PublishFrame()</i> method. Start by incrementing

<i>numberOfFrames</i>. This variable will be used for indexing the frame from the CSV file for output.

<i>numberOfFrames</i> also must rollover before it exceeds the dimensions of the <i>

voltagePhasorData</i> array.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">protected</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> PublishFrame(IFrame frame, <span style="color:Blue">int</span> index)

{

    <span style="color:Gray">///</span><span style="color:Green"> Increment number of published frames</span>

    numberOfFrames&#43;&#43;;



    <span style="color:Gray">///</span><span style="color:Green"> Reset frame counter</span>

    <span style="color:Blue">if</span> (numberOfFrames &gt; 99) <span style="color:Gray">///</span><span style="color:Green"> Change this</span>

    {

        numberOfFrames = 0;

    }

 }

</pre>

</div>

<br>

Since you don&#39;t have to deal with any incoming measurements or computation in this adapter, you can move straight to preparing the sample data for output. Begin by creating an array of

<i>IMeasurement</i> objects. You can think of this array you are creating as an array of blank measurements which have properties identical to those specified in the

<i>outputMeasurements</i> parameter of the connection string.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Gray">///</span><span style="color:Green"> Prepare to clone the output measurements.</span>

IMeasurement[] outputMeasurements = OutputMeasurements;

</pre>

</div>

<br>

Next, create a list of IMeasurement objects to use as the actual output measurements.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Gray">///</span><span style="color:Green"> Create a list of IMeasurement objects</span>

List&lt;IMeasurement&gt; output = <span style="color:Blue">new</span> List&lt;IMeasurement&gt;();

</pre>

</div>

<br>

Then, add each of the output measurements to the output list by cloning the blank measurements. Don&#39;t forget to convert the data from a string to a double before outputting.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">for</span> (<span style="color:Blue">int</span> i = 0; i &lt; 6; i&#43;&#43;)

{

    output.Add(Measurement.Clone(outputMeasurements[i],

                        Convert.ToDouble(voltagePhasorData[numberOfFrames, i]),

                                                   frame.Timestamp));

}

</pre>

</div>

<br>

Lastly, you will use the <i>OnNewMeasurements()</i> method to output these measurements.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Gray">///</span><span style="color:Green"> Output the next measurement frame</span>

OnNewMeasurements(output);

</pre>

</div>

<br>

Now, your <i>PublishFrame()</i> method in it&#39;s entirety should be as shown below:<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">protected</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> PublishFrame(IFrame frame, <span style="color:Blue">int</span> index)

{

    <span style="color:Gray">///</span><span style="color:Green"> Increment number of published frames</span>

    numberOfFrames&#43;&#43;;



    <span style="color:Gray">///</span><span style="color:Green"> Reset frame counter</span>

    <span style="color:Blue">if</span> (numberOfFrames &gt; 99) <span style="color:Gray">///</span><span style="color:Green"> Change this</span>

    {

        numberOfFrames = 0;

    }



    <span style="color:Gray">///</span><span style="color:Green"> Prepare to clone the output measurements.</span>

    IMeasurement[] outputMeasurements = OutputMeasurements;



    <span style="color:Gray">///</span><span style="color:Green"> Create a list of IMeasurement objects</span>

    List&lt;IMeasurement&gt; output = <span style="color:Blue">new</span> List&lt;IMeasurement&gt;();



    <span style="color:Blue">for</span> (<span style="color:Blue">int</span> i = 0; i &lt; 6; i&#43;&#43;)

    {

        output.Add(Measurement.Clone(outputMeasurements[i],

                            Convert.ToDouble(voltagePhasorData[numberOfFrames, i]),

                                                       frame.Timestamp));

    }



    <span style="color:Gray">///</span><span style="color:Green"> Output the next measurement frame</span>

    OnNewMeasurements(output);

    }

}

</pre>

</div>

<br>

Now, compile your adapter in Visual Studio by pressing <i>Shift&#43;F6</i> or by navigating to

<i>Build / Build SampleDataSimulator</i> in the drop down menu. The first adapter is now complete. You can set this aside for now and begin the second adapter.

<hr>

<h2>Coding the Per Unit Calculator</h2>

Now that you have an adapter that will spit out some data for you, (it should go without saying that adapter reading from the CSV file is just used for development and testing purposes if there are no measurements available.) you can create another adapter

 which will take the voltage magnitudes from there and convert them to a per unit value. This example focuses on reading in the incoming measurements from the

<i>IFrame</i> input parameter of the <i>PublishFrame()</i> method and ...<br>

<br>

Open a new project in Visual Studio. Select <i>Class Library</i> again and name it

<i>CalculatePerUnitValue</i>. Again, Visual Studio will provide you with an empty shell to begin your project. As with the previous example, add the necessary references and include them at the top of your *.cs file.

<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">using</span> System;

<span style="color:Blue">using</span> System.Collections.Generic;

<span style="color:Blue">using</span> System.Linq;

<span style="color:Blue">using</span> System.Text;

<span style="color:Blue">using</span> TimeSeriesFramework;

<span style="color:Blue">using</span> TimeSeriesFramework.Adapters;

<span style="color:Blue">using</span> TVA;

<span style="color:Blue">using</span> TVA.PhasorProtocols;



<span style="color:Blue">namespace</span> CalculatePerUnitValue

{

    <span style="color:Blue">public</span> <span style="color:Blue">class</span> Class1

    {

       

    }

}

</pre>

</div>

<br>

Rename the class to <i>MyNewAdapter</i> and extend the base class of <i>CalculatedMeasurementBase</i> by clicking on the blue tab that appears below the class declaration. You&#39;ll also want to override the

<i>Initialize()</i> method again.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">namespace</span> CalculatePerUnitValue

{

    <span style="color:Blue">public</span> <span style="color:Blue">class</span> MyNewAdapter : CalculatedMeasurementBase

    {

        <span style="color:Blue">public</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> Initialize()

        {

            <span style="color:Blue">base</span>.Initialize();

        }



        <span style="color:Blue">protected</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> PublishFrame(IFrame frame, <span style="color:Blue">int</span> index)

        {

            <span style="color:Blue">throw</span> <span style="color:Blue">new</span> NotImplementedException();

        }

    }

}



</pre>

</div>

<br>

Add some useful instance variables to your adapter.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">int</span> numberOfFrames;

<span style="color:Blue">int</span> baseKV;

</pre>

</div>

<br>

<i>numberOfFrames</i> will be used in a similar fashion to the previous adapter as well as used for timing console output. Here&#39;s an example: if you have an adapter with running at 30 frames per second it can be difficult to use the

<i>OnStatusMessage()</i> method for effectively troubleshooting or debugging your adapter. However, if you maintain a counter based on the number of frames (the number of times

<i>PublishFrame()</i> has been called) then you can used the modulus operator to slow down the console output. In the example below, if you modulus

<i>numberOfFrames</i> by 30 then you can send a message to the console every 1 second for a 30 fps adapter. This is very useful for troubleshooting.<br>

<br>

In the implementation of the <i>Initialize()</i> method, you will simply set <i>baseKV</i> (the measurements in the sample file are 500kV voltages) and send a message to the console.

<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">public</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> Initialize()

{

    <span style="color:Blue">base</span>.Initialize();



    baseKV = 500000;



    <span style="color:Gray">///</span><span style="color:Green"> Print to the console</span>

    OnStatusMessage(<span style="color:#A31515">&quot;Adapter has been successfully initialized...&quot;</span>);

}

</pre>

</div>

<br>

You will begin the <i>PublishFrame()</i> method in the same manner as the previous adapter by incrementing

<i>numberOfFrames</i> and forcing it to rollover.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Blue">protected</span> <span style="color:Blue">override</span> <span style="color:Blue">void</span> PublishFrame(IFrame frame, <span style="color:Blue">int</span> index)

{

    <span style="color:Gray">///</span><span style="color:Green"> Increment the number of published frames. This number is</span>

    <span style="color:Gray">///</span><span style="color:Green"> used to properly time the console output.</span>

    numberOfFrames&#43;&#43;;



    <span style="color:Gray">///</span><span style="color:Green"> So that the number of frames does not continue on forever</span>

    <span style="color:Gray">///</span><span style="color:Green"> The number is arbitrary, but it needs to rollover like this</span>

    <span style="color:Blue">if</span> (numberOfFrames &gt; 1000)

    {

        numberOfFrames = 0;

    }

}

</pre>

</div>

<br>

Then create a list to store the raw measurement values and a list to store the input measurement keys. While it is not done here, storing the input measurement keys in a similar manner to the raw measurements will give you a mechanism for sorting your measurements

 into a desired order.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Gray">///</span><span style="color:Green"> Create a list to store the raw measurement values</span>

List&lt;<span style="color:Blue">double</span>&gt; processedMeasurements = <span style="color:Blue">new</span> List&lt;<span style="color:Blue">double</span>&gt;();



<span style="color:Gray">///</span><span style="color:Green"> Create a list to store the input measurement keys</span>

List&lt;<span style="color:Blue">string</span>&gt; inputMeasurementKeys = <span style="color:Blue">new</span> List&lt;<span style="color:Blue">string</span>&gt;();

</pre>

</div>

<br>

Now, you can extract the raw measurement values and the measurement keys from the

<i>IFrame</i> input parameter. All of the information concerning the input measurements and time stamp is contained in this object. However, only the raw value and input measurement key are demonstrated in this example.<br>

<br>

Here you will perform a simple calculation to convert the voltage magnitudes to their per unit equivalent and print a debug message to the console every 1 second.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Gray">///</span><span style="color:Green"> Remove the measurement values from the IFrame object</span>

<span style="color:Blue">foreach</span> (IMeasurement measurement <span style="color:Blue">in</span> frame.Measurements.Values)

{

    processedMeasurements.Add(measurement.Value / baseKV);

    inputMeasurementKeys.Add(measurement.Key.ToString());



    <span style="color:Blue">if</span> (numberOfFrames % 30 == 0)

    {

        OnStatusMessage(measurement.Key.ToString() &#43; <span style="color:#A31515">&quot;: &quot;</span> &#43; measurement.Value.ToString());

    }



}

</pre>

</div>

<br>

In the same way as the previous adapter, prepare the measurements for output before publishing.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Gray">///</span><span style="color:Green"> Prepare to clone the output measurements</span>

IMeasurement[] outputMeasurements = OutputMeasurements;



<span style="color:Gray">///</span><span style="color:Green"> Create a list to store the output measurements</span>

List&lt;IMeasurement&gt; output = <span style="color:Blue">new</span> List&lt;IMeasurement&gt;();



<span style="color:Blue">for</span> (<span style="color:Blue">int</span> i = 0; i &lt; outputMeasurements.Length; i&#43;&#43;)

{

    output.Add(Measurement.Clone(outputMeasurements[i],

                                              processedMeasurements[i],

                                                          frame.Timestamp));

}

</pre>

</div>

<br>

Now, send a message to output the measurements.<br>

<br>

<div style="color:Black; background-color:White">

<pre>

<span style="color:Gray">///</span><span style="color:Green"> Output the measurements</span>

OnNewMeasurements(output);

</pre>

</div>

<br>

This adapter is now complete. Compile your code as before.

<hr>

<h2>Adding the Adapters to openPDC</h2>

From the Visual Studio folder, navigate to <i>Projects / SampleDataSimulator / SampleDataSimulator / bin / Debug /</i> and grab the file

<i>SampleDataSimulator.dll</i>. Also, grab the file <i>CalculatePerUnitValue.dll</i> from its respective project folder.<br>

<br>

Save the following files to the main openPDC directory:

<ul>

<li>SampleDataSimulator.dll </li><li>CalculatePerUnitValue.dll </li><li><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Two_Customer_Adapter_Examples.files/ReadWriteCSV.dll">ReadWriteCSV.dll</a> (This is a file for reading from and writing to CSV files)

</li><li><a href="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Two_Customer_Adapter_Examples.files/samplePhasorData.csv">samplePhasorData.csv</a> (This is a file containing the sample data for this example)</li></ul>

<br>

Now, run the openPDC Manager and navigate to the <i>Adapters</i> tab. Select <i>Calculated Measurements</i> as this is the type of adapters that you have created. Click on the

<i>Clear</i> button to empty the fields before entering in the adapter information. First, begin with the data simulator adapter.<br>

<br>

<b>Acronym:</b> DATA<br>

<b>Name:</b> SampleDataSimulator<br>

<b>Assembly:</b> SampleDataSimulator.dll<br>

<b>Type Name:</b> SampleDataSimulator.sampleDataSimulator<br>

<b>Frames Per Second: </b>30<br>

<b>Output Measurements:</b> SIMULATEDPHASOR:1;SIMULATEDPHASOR:2;SIMULATEDPHASOR:3;SIMULATEDPHASOR:4;SIMULATOEDPHASOR:5;SIMULATEDPHASOR:6;<br>

<br>

The <i>Acronym</i> and <i>Name</i> parameters are arbitrary; you can use whatever you&#39;d like here. The

<i>Acronym</i> will be used as an identifier on the console output when your adapter sends a message to the console. The

<i>Assembly</i> parameter is the name of the *.dll file containing your custom code. The

<i>Type Name</i> parameter is the namespace of your adapter followed by the class name. For example:<br>

<br>

<b>Type Name:</b> namespace.class<br>

<br>

The <i>Output Measurements</i> parameter tells openPDC what ID to give to the measurements that your adapter outputs. You will then be able to use these IDs as input measurement keys to your per unit calculator to specify its input.<br>

<br>

Make sure the <i>Enabled</i> check box is checked True and click the <i>Save</i> button.<br>

<br>

Now repeat the procedure for the per unit converter adapter.<br>

<br>

<b>Acronym:</b> PU<br>

<b>Name:</b> PerUnitCalculator<br>

<b>Assembly:</b> CalculatePerUnitValue.dll<br>

<b>Type Name:</b> CalculatePerUnitValue.MyNewAdapter<br>

<b>Frames Per Second: </b>30<br>

<b>Input Measurements:</b> SIMULATEDPHASOR:1;SIMULATEDPHASOR:3;SIMULATEDPHASOR:5;<br>

<b>Output Measurements:</b> PERUNIT:1;PERUNIT:2;PERUNIT:3;<br>

<br>

<i>Note: Only the voltage magnitudes have been included as inputs to this adapter. The angles which the previous adapter output have not been included.</i><br>

<br>

Maked sure the <i>Enabled</i> check box is checked True and click the <i>Save</i> button.<br>

<br>

Navigate to the <i>Home</i> tab of the openPDC Manager and restart openPDC. Once openPDC has been restarted, click on the

<i>System Console</i>. You should now see the adapters console output printing every second to the console. It should show the ID string for that measurement and its raw value.

<hr>

<h2>Making Changes to Your Adapter</h2>

In order for you to make changes to your adapter (if either there is a mistake or you would like to add something to it) you will need to make the changes in Visual Studio and compile as before. Then, you will have to put that into the openPDC directory. The

 problem with this is that if your *.dll file is name the same as its predecessor then you will not be able to overwrite it because openPDC is using it. In order to replace the old *.dll with the new one you must turn off the openPDC service completely.<br>

<br>

Open the Windows Services Dialog Box (In Windows 7, type &#39;services.msc&#39; into the search field on the Start Menu). Scroll down until you see openPDC and click the stop button at the top or click the word &#39;Stop&#39; on the top left. Now, save the

 new *.dll into the openPDC directory, overwriting the old one. From the Services Dialog Box, click &#39;Start&#39;. The openPDC service will start and you can now check for the changes that you have made.

<br>

<br>

<i>Note: If you are running on an older machine without a tremendous amount of resources (CPU, RAM, etc) it is recommended to close the openPDC Manager before starting the openPDC service again. Then, reopen the manager after the service has started. This will

 help prevent your machine from seizing up.</i><br>

</div>

</div>

<hr />

<div class="WikiComments">

<div id="wikiCommentsEmpty">No comments yet.<br></div>

</div>

<div id="footer">

<hr />

Last edited <span class="smartDate" title="7/1/2012 6:27:55 PM" LocalTimeTicks="1341192475">Jul 1, 2012 at 6:27 PM</span> by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/kevinjones.md">kevinjones</a>, version 2<br />

Migrated from <a href="http://openpdc.codeplex.com/wikipage?title=Two%20Custom%20Adapter%20Examples">CodePlex</a> Oct 5, 2015 by <a id="wikiEditByLink" href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/Contributors/ajstadlin.md">ajs</a>

</div>



<!--HtmlToGmd.Foot-->

<div id="copyright">

<hr />

Copyright 2015 <a href="http://www.gridprotectionoalliance.org">Grid Protection Alliance</a>

</div>

<!--/HtmlToGmd.Foot-->

</body>

</html>


