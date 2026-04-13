# Functional testing

## Simulate a PMU

### PMU capture
A PMU capture file is a binary file with the `.PmuCapture` file extension.
These files can be created by connecting to a real device using the
[PMU Connection Tester](https://github.com/GridProtectionAlliance/PMUConnectionTester)
and capturing the network packets into a file using the `File > Capture > Start Capture...`
menu option. Once you feel you have collected enough packets, you can use the
`File > Capture > Stop Capture` menu option to complete the process.

The openPDC includes a [sample capture file](https://github.com/GridProtectionAlliance/openPDC/blob/testing-adapters-doc/Source/Applications/openPDC/openPDC/Sample1344.PmuCapture)
captured from a PMU using the IEEE 1344-1995 protocol. To set up a device in openPDC
that streams the data from this sample file, use the Input Device Wizard in the
openPDC Manager. Navigate to `Inputs > Input Device Wizard` and enter the following
data into the form in Step 1.

**Connection String**: file=Sample1344.PmuCapture; definedframerate=30; simulatetimestamp=true; autorepeatfile=true; transportprotocol=file   
**Device ID Code**: 2  
**Device Protocol**: IEEE 1344-1995

On step 2 of the wizard, click on the  `Request Configuration` button. This will
cause openPDC to search the sample file for a configuration frame and send it back
to the Input Device Wizard.

On step 3, the wizard should have loaded the data from the configuration frame into
a device named `SHELBY`. You can click the `Accept Phase Guesses` button and then
the `Finish` button to finish creating the `SHELBY` device for testing.

A similar process can be used to stream sample data from any device you have captured
data from using the PMU Connection Tester. Here are some general tips to help make
this process go smoothly.

* If you are using TCP to connect to the PMU, try starting the capture before connecting to the PMU.
  This will ensure that the configuration frame ends up in the PMU capture file when the PMU Connection
  Tester requests it from the device.
* If the PMU is broadcasting UDP packets to the PMU Connection Tester, try starting the capture shortly
  before the top of the minute. The PMU will typically send a configuration frame once every 60 seconds
  near the top of the minute, so this will help to ensure that the capture includes that frame.
* If you have a capture file with no configuration frame, you can use the PMU Connection Tester to save
  the PMU's configuration frame to an XML file using `File > Config File > Save...` The XML file can be
  used in step 2 of the Input Device Wizard instead of using the `Request Configuration` button.


## Simulate measurement values

The openPDC provides input adapters that can produce random data for testing in lieu of real PMU data.
The process for setting up one of these adapters typically involves first creating a virtual PMU device
and modeling its measurements. After that, create a custom input adapter with the `OutputMeasurements`
connection string parameter referencing the virtual PMU's measurements.

### Virtual Device: Model the PMU

To create the virtual PMU device, use the openPDC Manager. Navigate to `Inputs > Add New Device Based Input`
and enter the following information before clicking the `Save` button.

**Acronym**: TEST  
**Name**: Test  
**Protocol**: Virtual Device  
**Enabled**: checked

After creating the virtual device, create a measurement associated with that device that will be referenced
by the custom input adapter. Navigate to `Metadata > Measurements` and click the `Add New` button. Enter the
following information before clicking the `Save` button.

**Point Tag**: TEST:FREQ  
**Signal Reference**: TEST-FQ  
**Device**: TEST  
**Measurement Type**: Frequency  
**Enabled**: checked

### Random Values Input Adapter: Simply produce some random values

The `Random Values` input adapter can be used to produce a fixed number of randomly generated data values
between 0 and 1. Using this adapter in tandem with other configuration features such as measurement adders
and multipliers, it provides a simple mechanism for testing various downstream features such as communications
protocols, visualizations, and analytics.

To set up a `Random Values` adapter, use the openPDC Manager. Navigate to `Inputs > Manage Custom Inputs` and
enter the following information before clicking `Save`. After saving the adapter, you will also want to
initialize the adapter by finding and selecting it from the grid at the bottom of the page and then clicking
the `Initialize` button. This example adapter configuration assumes the configuration for the `TEST` virtual
device from the previous section was set up beforehand.

**Name**: RANDOM_INPUT  
**Type**: Random Values  
**Connection String**: OutputMeasurements={FILTER ActiveMeasurements WHERE Device = 'TEST'}; PointsToSend=1800  
**Enabled**: checked

One important thing to note about the `Random Values` adapter is that it does not attempt to perform any timestamp
alignment on the data it produces. One way to work around this is to use the `Normalize Subsecond Timestamps`
filter adapter to adjust the timestamps on the way out of the input adapter. Navigate to
`Inputs > Manage Custom Filters` and enter the following information before clicking `Save`. After saving the
adapter, you will also want to initialize the adapter by finding and selecting it from the grid at the bottom
of the page and then clicking the `Initialize` button.

**Name**: TIME_ALIGNMENT
**Type**: Normalize Subsecond Timestamps
**Connection String**: InputMeasurementKeys={FILTER ActiveMeasurements WHERE Device = 'TEST'}
**Enabled**: checked

### Moving Value Input Adapter: Correlating input data with output data

The `Moving Value` adapter provides a more controlled mechanism for generating random values that can be used to
help correlate input values with output values. This can be useful for testing the correctness of downstream
computations as well as the precision and accuracy with which a downstream protocol transmits data.

To set up a `Moving Value` adapter, use the openPDC Manager. Navigate to `Inputs > Manage Custom Inputs` and
enter the following information before clicking `Save`. After saving the adapter, you will also want to
initialize the adapter by finding and selecting it from the grid at the bottom of the page and then clicking
the `Initialize` button.

This setup will select a random value between 59 and 61 to publish as the value for the TEST device's
measurement. After publishing the same value for 5 seconds, it will select a new random value and spend
1 second gradually moving to that new random value. Note that this adapter does perform timestamp alignment
on the measurements it produces.

**Name**: MOVING_INPUT  
**Type**: Moving Value  
**Connection String**: OutputMeasurements={FILTER ActiveMeasurements WHERE Device = 'TEST'}; MinHoldTime=5; MaxHoldTime=5; MinMoveTime=1; MaxMoveTime=1; MinValue=59; MaxValue=61  
**Enabled**: checked

If you had previously set up the `Random Values` adapter, make sure to disable that adapter before enabling this
one or you will see data coming from both adapters. By holding the random value it selects for 5 seconds, you
should be able to correlate the input data with any of your output data by simply observing both ends during that
5-second window when the value does not change. The gradual changes between values also enables you to recognize
the periods between held values when transforming data via computations.

## Simulate a PMU data outage

The previous tests using a virtual device and an input adapter for testing provide a convenient way to simulate
a data outage to determine what happens in your concentrators downstream. Simply disable the input adapter, and
it will appear to all downstream systems that the device is connected but not providing any data.

# Load testing and stress testing

## Simulate multiple PMUs

To perform load testing or stress testing, we will discuss some strategies for quickly scaling the system up
to simulate a large collection of PMUs. This allows us to test how downstream adapters, concentrators,
computations, and protocols react to different volumes of data.

### PDC Simulator

The PDC Simulator is a simple tool developed by OSISoft that is convenient for creating a simple IEEE C37.118
stream containing one or more simulated PMU devices. The openPDC can be quickly configured to connect to the
simulator using the openPDC Manager's Input Device Wizard. Furthermore, the PDC Simulator can be used to easily
test PMU error codes by manually turning them on or off via checkboxes.

You can download version 1.0.2.5 from GPA's nightly build servers.  
https://gridprotectionalliance.org/NightlyBuilds/Tools/PDCSimulator.zip

By default, the PDC Simulator is configured using both a TCP command channel and a UDP data channel with 1 PMU.
This can be quickly changed to use only a single TCP channel by unchecking the `Enable UDP Unicast` checkbox.
The number of PMUs can be increased by changing the number in the `Total number of PMUs` textbox. Once you have
finished configuring your data source, click the large `Start` button at the top of the window.

Use the openPDC Manager to connect to the simulator by navigating to `Inputs > Input Device Wizard`. Enter the
following information into step 1 of the wizard.

**Connection String**: port=4712; maxSendQueueSize=-1; server=127.0.0.1; islistener=false; transportprotocol=tcp; interface=0.0.0.0  
**Device ID Code**: 0  
**Device Protocol**: IEEE C37.118-2005

On step 2 of the wizard, click on the  `Request Configuration` button. This will send a command frame to the
simulator, causing it to send the configuration frame back to the Input Device Wizard. After the configuration
frame has been received enter the following information.

**Connection is to Concentrator**: checked  
**PDC Acronym**: PDCSIM01  
**Use Source Prefix: "PDCSIM01!"**: checked

On step 3 of the wizard, ensure that `Use Config Frame Labels` is unchecked. Click `Finish` to complete the
input device setup. Afterward, the openPDC should be receiving simulated data from the PDC Simulator.

Note that the PDC Simulator automatically assigns names and ID Codes to the PMUs, and there is no configuration
to override it. The `Use Source Prefix` checkbox on step 2 of the wizard better enables you to set up multiple
PDC Simulators for testing, if needed. However, keep in mind that downstream name/ID conflicts may still arise
from using this method.

### Random Frames Input Adapter: Time-aligned PMU simulation with randomly generated data

The `Random Frames` input adapter is specially designed to provide an accurate representation of the data delivery
characteristics of a PMU. Given multiple output measurements, it will publish those measurements as frames with
timestamps aligned to the given frame rate. In addition, it has parameters for adjusting latency characteristics.
Furthermore, if the adapter's internal timer falls behind due to processing delays, it will attempt to generate
all the frames that were missed due to the delays.

For a basic demonstration of how the `Random Frames` adapter works, use the openPDC Manager to create a virtual
device. Navigate to `Inputs > Add New Device Based Input` and enter the following information before clicking
`Save`.

**Acronym**: TEST  
**Name**: Test  
**Protocol**: Virtual Device  
**Enabled**: checked  

Next, we will create two measurements. Navigate to `Metadata > Measurements` and click the `Add New` button.
Enter the following information before clicking `Save`.

**Point Tag**: TEST:VPHM  
**Signal Reference**: TEST-PM1  
**Device**: TEST  
**Measurement Type**: Voltage Magnitude  
**Enabled**: checked

For the second measurement, simply click the `Add New` button again and enter the following information
before clicking `Save`.

**Point Tag**: TEST:VPHA  
**Signal Reference**: TEST-PA1  
**Device**: TEST  
**Measurement Type**: Voltage Phase Angle  
**Enabled**: checked

Finally, create the input adapter by navigating to `Inputs > Manage Custom Inputs`. Enter the following
information before clicking `Save`. After saving the adapter, you will also want to initialize the
adapter by finding and selecting it from the grid at the bottom of the page and then clicking
the `Initialize` button.

**Name**: FRAME_INPUT  
**Type**: Random Frames  
**Connection String**: OutputMeasurements={FILTER ActiveMeasurements WHERE Device = 'TEST'}  
**Enabled**: checked

The `Random Frames` adapter is the most accurate simulator that openPDC offers which can quickly be
scaled up by scripting the creation of devices, measurements, and input adapters necessary for testing.
The following scripts have been used internally to perform stress tests at GPA. When executed as-is
against the SQL configuration database, these scripts will generate 500 virtual devices with 10
phasors (20 measurements) each.

* [01 - GenerateIntegers.sql](Testing_Adapters.files/01%20-%20GenerateIntegers.sql)
* [02 - VirtualDevices.sql](Testing_Adapters.files/02%20-%20VirtualDevices.sql)
* [03 - Measurements.sql](Testing_Adapters.files/03%20-%20Measurements.sql)
* [04 - RandomValueAdapters.sql](Testing_Adapters.files/04%20-%20RandomValueAdapters.sql)
* [05 - EnableAdapters.sql](Testing_Adapters.files/05%20-%20EnableAdapters.sql)

After making changes to the database configuration, use the openPDC Console to issue the
`ReloadConfig` command to the openPDC service. This will cause the openPDC service to load the
latest changes from the database configuration into the in-memory runtime configuration and begin
producing random frame-based measurement data.