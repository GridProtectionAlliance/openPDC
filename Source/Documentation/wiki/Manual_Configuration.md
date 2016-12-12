[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# How to Manually Configure the openPDC

This guide is designed to assist you in configuring the openPDC to gather data from your devices and transmit that data to other devices or applications. The following sections will go over which tables you will need to edit and explain the relevant column values. Any columns that are not specified are not necessary for simple configurations and can be left with their default values.

Before you begin your configuration, please note that this guide assumes you are using only the InitialDataSet in your database; not the SampleDataSet. In the case of SQLite, this means using the "openPDC-InitialDataSet.db" file instead of the "openPDC-SampleDataSet.db" file. In the case of SQL Server and MySQL, it means running only the "openPDC.sql" and "InitialDataSet.sql" files when you set up your database.

If you need to reset your database in order to do this, please read the [FAQ](FAQ.md#i-need-to-reset-my-database-what-should-i-do). However, you are strongly encouraged to use the SampleDataSet as an example to help you understand how to configure your database.

- [Configuring inputs](#configuring-inputs)
    - [The Node table](#the-node-table)
        - [The ID column](#the-id-column)
        - [The Name column](#the-name-column)
        - [The CompanyID column](#the-companyid-column)
        - [The Description column](#the-description-column)
        - [The Master column](#the-master-column)
        - [The Enabled column](#the-enabled-column)
    - [The Historian table](#the-historian-table)
        - [The NodeID column](#the-nodeid-column)
        - [The ID column](#the-id-column-1)
        - [The Acronym column](#the-acronym-column)
        - [The Name column](#the-name-column-1)
        - [The AssemblyName column](#the-assemblyname-column)
        - [The TypeName column](#the-typename-column)
        - [The IsLocal column](#the-islocal-column)
        - [The Enabled column](#the-enabled-column-1)
    - [The Device table](#the-device-table)
        - [The NodeID column](#the-nodeid-column-1)
        - [The ID column](#the-id-column-2)
        - [The ParentID column](#the-parentid-column)
        - [The Acronym column](#the-acronym-column-1)
        - [The Name column](#the-name-column-2)
        - [The IsConcentrator column](#the-isconcentrator-column)
        - [The CompanyID column](#the-companyid-column-1)
        - [The HistorianID column](#the-historianid-column)
        - [The AccessID column](#the-accessid-column)
        - [The ProtocolID column](#the-protocolid-column)
        - [The ConnectionString column](#the-connectionstring-column)
        - [The Enabled column](#the-enabled-column-2)
    - [The Phasor table](#the-phasor-table)
        - [The ID column](#the-id-column-3)
        - [The DeviceID column](#the-deviceid-column)
        - [The Label column](#the-label-column)
        - [The Type column](#the-type-column)
        - [The Phase column](#the-phase-column)
        - [The SourceIndex column](#the-sourceindex-column)
    - [The Measurement table](#the-measurement-table)
        - [The SignalID column](#the-signalid-column)
        - [The HistorianID column](#the-historianid-column-1)
        - [The PointID column](#the-pointid-column)
        - [The DeviceID column](#the-deviceid-column-1)
        - [The PointTag column](#the-pointtag-column)
        - [The SignalTypeID column](#the-signaltypeid-column)
        - [The PhasorSourceIndex column](#the-phasorsourceindex-column)
        - [The SignalReference column](#the-signalreference-column)
        - [The Description column](#the-description-column-1)
        - [The Enabled column](#the-enabled-column-3)
- [Configuring outputs](#configuring-outputs)
    - [The OutputStream table](#the-outputstream-table)
        - [The NodeID column](#the-nodeid-column-2)
        - [The ID column](#the-id-column-4)
        - [The Acronym column](#the-acronym-column-2)
        - [The Name column](#the-name-column-3)
        - [The Type column](#the-type-column-1)
        - [The ConnectionString column](#the-connectionstring-column-1)
        - [The DataChannel column](#the-datachannel-column)
        - [The CommandChannel column](#the-commandchannel-column)
        - [The IDCode column](#the-idcode-column)
        - [The UseLocalClockAsRealTime column](#the-uselocalclockasrealtime-column)
        - [The Enabled column](#the-enabled-column-4)
    - [The OutputStreamDevice table](#the-outputstreamdevice-table)
        - [The NodeID column](#the-nodeid-column-3)
        - [The AdapterID column](#the-adapterid-column)
        - [The ID column](#the-id-column-5)
        - [The Acronym column](#the-acronym-column-3)
        - [The BpaAcronym column](#the-bpaacronym-column)
        - [The Name column](#the-name-column-4)
        - [The Enabled column](#the-enabled-column-5)
    - [The OutputStreamDeviceAnalog table](#the-outputstreamdeviceanalog-table)
        - [The NodeID column](#the-nodeid-column-4)
        - [The OutputStreamDeviceID column](#the-outputstreamdeviceid-column)
        - [The ID column](#the-id-column-6)
        - [The Label column](#the-label-column-1)
        - [The Type column](#the-type-column-2)
    - [The OutputStreamDeviceDigital table](#the-outputstreamdevicedigital-table)
        - [The NodeID column](#the-nodeid-column-5)
        - [The OutputStreamDeviceID column](#the-outputstreamdeviceid-column-1)
        - [The ID column](#the-id-column-7)
        - [The Label column](#the-label-column-2)
    - [The OutputStreamDevicePhasor table](#the-outputstreamdevicephasor-table)
        - [The NodeID column](#the-nodeid-column-6)
        - [The OutputStreamDeviceID column](#the-outputstreamdeviceid-column-2)
        - [The ID column](#the-id-column-8)
        - [The Label column](#the-label-column-3)
        - [The Type column](#the-type-column-3)
        - [The Phase column](#the-phase-column-1)
    - [The OutputStreamMeasurement table](#the-outputstreammeasurement-table)
        - [The NodeID column](#the-nodeid-column-7)
        - [The AdapterID column](#the-adapterid-column-1)
        - [The ID column](#the-id-column-9)
        - [The HistorianID column](#the-historianid-column-2)
        - [The PointID column](#the-pointid-column-1)
        - [The SignalReference column](#the-signalreference-column-1)
- [Troubleshooting](#troubleshooting)

---

## Configuring inputs

This section will go over all the tables you will need to modify in your openPDC database in order to receive data from your devices.

### The Node table

This table contains information about the openPDC instances using the database. You will most likely only need to enter one record into this table. If you have multiple instances of the openPDC using your openPDC database, you will need to add a record for each of them.

#### The ID column

The ID column is a GUID used to identify each of the nodes. The values in this column are generated automatically. Once the value has been generated, you will need to copy it to your openPDC configuration file. The file is located in the `SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\Applications\openPDC` folder. The file is called openPDC.exe.config.

**Note**: Aside from the configuration file, there are several other places in the database where you will need to specify the ID of your node so you may want to keep it in a place that is easily accessible as you configure the system.

Enter the node ID in the value attribute of the following tag.

**Note**: Access places brackets around the GUID. These are necessary in the database, but you should not include them in the configuration file.

```xml
<configuration>
  <categorizedSettings>
    <systemSettings>
      <add name="NodeID" value="[NodeID]" description="Unique Node ID" encrypted="false" />
    </systemSettings>
  </categorizedSettings>
</configuration>
```

#### The Name column

Enter a name by which you can identify the openPDC instance.

#### The CompanyID column

The values in this column should come from the *ID* column of the *Company* table.

#### The Description column

Enter a short description of the node.

#### The Master column

This should be true for one of your nodes. The rest of the nodes should be false. It will determine which node to access by default when using the openPDCManager.

#### The Enabled column

This column enables or disables the node in the openPDCManager. You will typically want to set this value to true.

---

### The Historian table

All measurements that enter the openPDC are archived by a historian. This section will guide you in setting up the default local historian.

#### The NodeID column

Enter the ID of your node into this column. The values in this column should come from the [ID](#the-id-column) column in the [Node](#the-node-table) table.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The Acronym column

Enter the Acronym to be used to identify the historian within the program. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore `_` is the only special character allowed. You can enter a maximum of 16 characters.

#### The Name column

Enter a name by which you can identify the historian.

#### The AssemblyName column

Enter the name of the dll for the historian. The dll should be located in the openPDC output folder (`SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\Applications\openPDC` where `SOURCEDIR` is the root directory of the openPDC source). The assembly name of the default local historian is "HistorianAdapters.dll".

#### The TypeName column

This specifies the type of the historian. The default local historian is of type "HistorianAdapters.LocalOutputAdapter".

#### The IsLocal column

Should be self-explanatory. Set this to true for the default local historian.

#### The Description column

Enter a short description of the historian.

#### The Enabled column

If you are going to attempt to connect to your historian through the openPDC, you need to have it enabled. Set this column to true.

---

### The Device table

This table contains information about the devices sending data to an instance of the openPDC. Devices can be PMUs or PDCs. PMUs that are connected through an intermediary PDC should also be present in this table.

#### The NodeID column

Enter the ID of your node into this column. The values in this column should come from the
[ID](#the-id-column) column in the [Node](#the-node-table) table.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The ParentID column

For PMUs that are connected through an intermediary PDC, enter the ID of the intermediary PDC into this column. Leave it blank for all other devices.

#### The Acronym column

Enter the Acronym to be used to identify the device within the program. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore `_` is the only special character allowed. You can enter a maximum of 16 characters.

#### The Name column

Enter a name by which you can identify the device.

#### The IsConcentrator column

Should be self-explanatory. If your device is a concentrator, this should be true. Otherwise, it should be false.

#### The CompanyID column

The values in this column should come from the *ID* column of the *Company* table.

#### The HistorianID column

Enter the ID of the historian that will archive the data coming from this device. The values in this column should come from the
[ID](#the-id-column-1) column in the [Historian](#the-historian-table) table.

#### The AccessID column

Every device has an Access ID (also known as Device ID). The value of this column needs to match the Access ID of the device.

#### The ProtocolID column

The value of this column should come from the *ID* column in the *Protocol* table. It determines the protocol used by the device. For your reference, the possible values are in the following table.

| Value | Protocol |
| ----- | -------- |
| 1 | BPA PDCstream |
| 2 | OPC |
| 3 | IEEE 1344-1995 |
| 4 | IEEE C37.118 Draft 6 |
| 5 | IEEE C37.118-2005 |
| 6 | FNet |
| 7 | SEL Fast Message |
| 8 | Macrodyne |

#### The ConnectionString column

The connection string is used to define how to connect to the device. A quick guide to configuring your connection string can be found on the [Getting Started](Getting_Started.md#configuring-a-connection-string) page.

**Note**: The sample connection strings on the Getting Started page include the phasorProtocol and accessID keys. Leave these out as they have been defined in the other columns of your Device table.

#### The Enabled column

Disabled devices will not be recognized by the openPDC. You will typically want to set this value to true.

---
### The Phasor table

This table defines the phasors that are being sent from your devices.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The DeviceID column

The values in this column should come from the [ID](#the-id-column-2) column of the [Device](#the-device-table) table. This defines which device the phasor is coming from.

#### The Label column

Enter some text with which to identify the phasor.

#### The Type column

A single letter that defines whether the phasor is a voltage or a current. The possible values are 'V' for voltage and 'I' for current.

#### The Phase column

The possible values for this column are in the following table.

| Value | Description |
| ----- | ----------- |
| + | Positive Sequence |
| - | Negative Sequence |
| 0 | Zero Sequence |
| A | A-Phase |
| B | B-Phase |
| C | C-Phase |

#### The SourceIndex column

Defines the position of the phasor in the measurement stream starting at 1. In other words, the first phasor in the stream should have source index 1, the second should have source index 2, and so on. This number must be accurate in order to interpret the phasor data stream.

---

### The Measurement table

This table defines every single measurement that is sent to the openPDC. Each device will have at least three measurements associated with it: Status Flags, Frequency, and Frequency Delta (dF/dt). Each phasor will have exactly two measurements associated with it: Phase Magnitude and Phase Angle. Additional measurements include Analog Values, Digital Values, and Calculated Values. Information about the types of measurements can be found in the *SignalType* table.

#### The SignalID column

The ID column is a GUID used to identify each of the measurements. The values in this column are generated automatically.

#### The HistorianID column

This column specifies which historian is going to archive the measurement. The values in this column should come from the [ID](#the-id-column-1) column in the [Historian](#the-historian-table) table.

#### The PointID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The DeviceID column

This column specifies which device the measurement is coming from. The values in this column should come from the [ID](#the-id-column-2) column in the [Device](#the-device-table) table.

#### The PointTag column

The values in this column are not necessary for the openPDC to operate; they simply describe the measurement. The following convention is suggested for consistency.

```
CCC_PPPP-DDDD:IIIH
```

- `CCC` is a three character company identifier.
- `PPPP` is a four character identification of the device.
- `DDDD` is a destination identifier. If there is no destination identifier, leave it out (and remove the dash, not the colon).
- `III` is a device manufacturer identifier.
- `H` identifies the signal type (from the <u>Abbreviation</u> column in the *SignalType* table).

##### Examples

**TVA_SHEL:ABBS**

```
Company: TVA  
Device: SHELBY  
Device Manufacturer: ABB
Signal Type: Status Flags
```

**TVA_SHEL-LAGO:ABBIH**

```
Company: TVA
Device: SHELBY
Destination: LAGO Phasor Degrees
Device Manufacturer: ABB
Signal Type: Current Phase Angle
```

#### The SignalTypeID column

This defines the signal type of the measurement. The values for this column should come from the *ID* column of the *SignalType* table.

#### The PhasorSourceIndex column

This column should be defined for all measurements that are components of a phasor. The values in this column should come from the
[SourceIndex](#the-sourceindex-column) column in the [Phasor](#the-phasor-table) table.

#### The SignalReference column

This column defines the link between a device and its measurements. It is vitally important for the openPDC to collect data properly. The following lists the information you will need in order to enter the values correctly.

- Device acronym from the [Acronym](#the-acronym-column-1) column in the [Device](#the-device-table) table
- Suffix of the signal type from the *Suffix* column in the *SignalType* table.
- Phasor source index from the [PhasorSourceIndex](#the-phasorsourceindex-column) column in the [Measurement](#the-measurement-table) table.

##### The following defines the syntax for the *SignalReference* values.

```
ACRONYM-SX#
```

- `ACRONYM` is the device acronym
- `SX` is the suffix of the signal type
- `#` is a trailing number defined in cases where there may or may not be another measurement with the same SignalReference value

###### Rules for the trailing number:

- If the measurement is a phasor, the trailing number is the phasor source index.
- If the measurement is a digital value or an analog value, the trailing number should be unique and incremental (starting at 1).
- If the measurement is anything else, it does not have a trailing number.

##### SignalReference example:

If SHELBY has 3 digital values, 2 analog values, and 2 phasors, the SignalReference values for those measurements would look like they do in the following table.

| PhasorSourceIndex | SignalReference | Description |
| ----------------- | --------------- | ----------- |
|    | SHELBY-SF | Shelby Status Flags |
|    | SHELBY-FQ | Shelby Frequency |
|    | SHELBY-DF | Shelby Frequency Delta (dF/dt) |
|    | SHELBY-DV1 | Shelby Digital Value 1 |
|    | SHELBY-DV2 | Shelby Digital Value 2 |
|    | SHELBY-DV3 | Shelby Digital Value 3 |
|    | SHELBY-AV1 | Shelby Analog Value 1 |
|    | SHELBY-AV2 | Shelby Analog Value 2 |
| 1 | SHELBY-PM1 | Shelby Phasor 1 Magnitude |
| 1 | SHELBY-PA1 | Shelby Phasor 1 Angle |
| 2 | SHELBY-PM2 | Shelby Phasor 2 Magnitude |
| 2 | SHELBY-PA2 | Shelby Phasor 2 Angle |

#### The Description column

Enter a description of the measurement.

#### The Enabled column

True if the measurement is enabled for processing. False if it is to be ignored. You typically want to set this value to true.

---

## Configuring outputs

This section will go over all the tables you will need to modify in your openPDC database in order to send data to other devices or applications. The important thing to remember when you're defining your output devices is that they can be *virtual* devices. This means that they may or may not be real devices reporting to the openPDC. This allows you to create output devices that send out only the information you want to send rather than all the information that is received. However, if you simply want to gather all the data and send it out in one stream, then you can define all your output devices exactly like your input devices.

### The OutputStream table

This defines the streams through which the openPDC will be sending data.

#### The NodeID column

Enter the ID of your node into this column. The values in this column should come from the [ID](#the-id-column) column in the [Node](#the-node-table) table.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The Acronym column

Enter the Acronym to be used to identify the stream within the program. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore `_` is the only special character allowed. You can enter a maximum of 16 characters.

#### The Name column

Enter a name by which you can identify the stream.

#### The Type column

This column defines the type of the output protocol. Enter '0' for IEEE C37.118 or '1' for BPA PDCstream.

#### The ConnectionString column

If you are using the IEEE C37.118 protocol, leave this column blank. If you are using the BPA PDCstream protocol, you will need to specify the INI configuration file. In the example on the [Getting Started](Getting_Started.md#creating-and-verifying-an-ieee-c37118-2005-data-stream) page, the value entered into this column is "iniFileName=TESTSTREAM.ini". Simply replace "TESTSTREAM.ini" with the name of your INI configuration file and place the file in the `SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\Applications\openPDC` directory (`SOURCEDIR` is the root directory of the openPDC source code).

#### The DataChannel column

This defines the connection information for the channel through which the openPDC is sending data. The value of this column is entered in connection string format. Example: "Port=0; Clients=localhost:8800". For the "Port" key, a value of '0' means that any local port can be used. A value of '-1' means that it won't bind to a local port. Multiple clients may be defined using a comma-separated list.

#### The CommandChannel column

This defines the connection information for the command channel. The value of this column is entered in connection string format. Example: "Port=8900".

#### The IDCode column

Enter an identification number. This number is used (much like a station address) in some protocols to identify the sender. In other cases, it is ignored.

#### The UseLocalClockAsRealTime column

Defines whether or not to use the local clock as real time. If this is set to false, the system will use the timestamp of the most recent measurement as real local time.

#### The Enabled column

Used to enable or disable the OutputStream. You will typically want to set this value to true.

---

### The OutputStreamDevice table

This table is used to define your virtual output devices.

#### The NodeID column

Enter the ID of your node into this column. The values in this column should come from the [ID](#the-id-column) column in the [Node](#the-node-table) table.

#### The AdapterID column

Specify the output stream ID the device is associated with. The values in this column should come from the [ID](#the-id-column-4) column in the [OutputStream](#the-outputstream-table) table.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The Acronym column

Enter the Acronym to be used to identify the device within the program. By convention, it should be entered in all uppercase with no embedded spaces. Also by convention, underscore `_` is the only special character allowed. You can enter a maximum of 16 characters.

#### The BpaAcronym column

Like the [Acronym](#the-acronym-column-2) column, but with a maximum of only four characters.

#### The Name column

Enter a name by which you can identify the device.

#### The Enabled column

Disabled devices will not be recognized by the openPDC. You will typically want to set this value to true.

---

### The OutputStreamDeviceAnalog table

This table is used to define the analog values associated with your virtual output devices. If you have no analog values to define, feel free to skip ahead to the [OutputStreamDeviceDigital](#the-outputstreamdevicedigital-table"> table.

#### The NodeID column

Enter the ID of your node into this column. The values in this column should come from the [ID](#the-id-column) column in the [Node](#the-node-table) table.

#### The OutputStreamDeviceID column

Enter the ID of the virtual output device that the analog value is associated with. The values in this column should come from the
[ID](#the-id-column-5) column in the [OutputStreamDevice](#the-outputstreamdevice-table) table.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The Label column

Enter a label by which to identify the analog value.

#### The Type column

Specify the type of the analog value. The following table lists the possible values in this column.

| Value | Description |
| ----- | ----------- |
| 0 | Single point-on-wave |
| 1 | RMS of analog input |
| 2 | Peak of analog input |

---

### The OutputStreamDeviceDigital table

This table is used to define the digital values associated with your virtual output devices. If you have no digital values to define, feel free to skip ahead to the [OutputStreamDevicePhasor](#the-outputstreamdevicephasor-table) table.

#### The NodeID column

Enter the ID of your node into this column. The values in this column should come from the [ID](#the-id-column) column in the [Node](#the-node-table) table.

#### The OutputStreamDeviceID column

Enter the ID of the virtual output device that the digital value is associated with. The values in this column should come from the
[ID](#the-id-column-5) column in the [OutputStreamDevice](#the-outputstreamdevice-table) table.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The Label column

Enter a label by which to identify the digital value.

---
### The OutputStreamDevicePhasor table

This table is used to define the phasors associated with your virtual output devices.

#### The NodeID column

Enter the ID of your node into this column. The values in this column should come from the [ID](#the-id-column) column in the [Node](#the-node-table) table.

#### The OutputStreamDeviceID column

Enter the ID of the virtual output device that the phasor is associated with. The values in this column should come from the
[ID](#the-id-column-5) column in the [OutputStreamDevice](#the-outputstreamdevice-table) table.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The Label column

Enter a label by which to identify the phasor.

#### The Type column

Specify whether the phasor is a voltage or a current. Enter 'V' for voltage or 'I' for current.

#### The Phase column

The possible values for this column are in the following table.

| Value | Description |
| + | Positive Sequence |
| - | Negative Sequence |
| 0 | Zero Sequence |
| A | A-Phase |
| B | B-Phase |
| C | C-Phase |

---

### The OutputStreamMeasurement table

This table defines every single measurement that is sent from the openPDC. This table provides a link between the input measurements and the virtual output devices that you just defined. Each virtual output device will have at least three measurements associated with it: Status Flags, Frequency, and Frequency Delta (dF/dt). Each output analog value will have one measurement associated with it. Each output digital value will also have one measurement associated with it. Each output phasor will have exactly two measurements associated with it: Phase Magnitude and Phase Angle. Information about the types of measurements can be found in the *SignalType* table.

#### The NodeID column

Enter the ID of your node into this column. The values in this column should come from the [ID](#the-id-column) column in the [Node](#the-node-table) table.

#### The AdapterID column

Specify the output stream ID the measurement is associated with. The values in this column should come from the [ID](#the-id-column-4) column in the [OutputStream](#the-outputstream-table) table.

#### The ID column

The values in this column are generated automatically starting from 1 and incrementing each time you add a record. Each value must be unique throughout the table.

#### The HistorianID column

The value in this column must match the value in the [HistorianID](#the-historianid-column-1) column for the corresponding measurement in the [Measurement](#the-measurement-table) table.

#### The PointID column

The value in this column must match the value in the [PointID](#the-pointid-column) column for the corresponding measurement in the [Measurement](#the-measurement-table) table.

#### The SignalReference column

**Note**: This description is essentially the same as the [SignalReference](#the-signalreference-column) description for the [Measurement](#the-measurement-table) table. The only difference is you are now linking output measurements to virtual output devices. Use the values from the output tables to create the signal reference values.

This column defines the link between a virtual device and its output measurements. It is vitally important for the openPDC to send the data properly. The following lists the information you will need in order to enter the values correctly.

- Virtual device acronym from the [Acronym](#the-acronym-column-3) column in the [OutputStreamDevice](#the-outputstreamdevice-table) table
- Suffix of the signal type from the *Suffix* column in the *SignalType* table
- Phasor source index from the [PhasorSourceIndex](#the-phasorsourceindex-column) column in the [Measurement](#the-measurement-table) table

##### The following defines the syntax for the SignalReference values.

```
ACRONYM-SX#
```

- `ACRONYM` is the virtual device acronym
- `SX` is the suffix of the signal type
- `#` is a trailing number defined in cases where there may or may not be another output measurement with the same SignalReference value

###### Rules for the trailing number:

- If the output measurement is a phasor, the trailing number is the phasor source index.
- If the output measurement is a digital value or an analog value, the trailing number should be unique and incremental (starting at 1).
- If the output measurement is anything else, it does not have a trailing number.

##### SignalReference example:

If SHELBY has 3 digital values, 2 analog values, and 2 phasors, the SignalReference values for those output measurements would look like they do in the following table.

| PhasorSourceIndex | SignalReference | Description |
| ----------------- | --------------- | ----------- |
|     | SHELBY-SF | Shelby Status Flags |
|     | SHELBY-FQ | Shelby Frequency |
|     | SHELBY-DF | Shelby Frequency Delta (dF/dt) |
|     | SHELBY-DV1 | Shelby Digital Value 1 |
|     | SHELBY-DV2 | Shelby Digital Value 2 |
|     | SHELBY-DV3 | Shelby Digital Value 3 |
|     | SHELBY-AV1 | Shelby Analog Value 1 |
|     | SHELBY-AV2 | Shelby Analog Value 2 |
| 1 | SHELBY-PM1 | Shelby Phasor 1 Magnitude |
| 1 | SHELBY-PA1 | Shelby Phasor 1 Angle |
| 2 | SHELBY-PM2 | Shelby Phasor 2 Magnitude |
| 2 | SHELBY-PA2 | Shelby Phasor 2 Angle |

---

### Troubleshooting

If you are still having trouble after using this guide, please make sure that you have followed the instructions for changing your configuration file outlined in the [ID](#the-id-column) column in the [Node](#the-node-table) table.

Another thing to check is to make sure that you have defined your [OutputStreamMeasurement](#the-outputstreammeasurement-table) table based on your output devices rather than the input measurements (the number of output measurements you should define is explained in the description of the [OutputStreamMeasurement](#the-outputstreammeasurement-table) table) [PointID](#the-pointid-column-1) values do not need to be unique in this table (you can associate two output measurements with the same input measurement if, for instance, you need to send the same measurement over two different output streams).

Everything else is fairly straightforward, but there is a lot of configuration involved so it may be worthwhile to double-check your tables to make sure you haven't made any mistakes. It is also possible that your configuration is more complicated than the configurations covered by this guide in which case you can take a look at the database documentation (coming soon) for a more detailed description of the tables and fields. Finally, if you think you may have found a bug, you are encouraged to create an item on the issue tracker in order to bring it to our attention.<

---

Mar 25, 2015 9:01 PM - Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 12  
Oct 4, 2015 - Migrated from [CodePlex](https://openpdc.codeplex.com/wikipage?title=Manual%20Configuration) by [aj](https://github.com/ajstadlin)  
Dec 10, 2016 - Updated by [aj](https://github.com/ajstadlin), version 12.1

---

Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
