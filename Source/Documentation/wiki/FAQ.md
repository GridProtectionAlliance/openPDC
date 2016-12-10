[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# FAQ - Frequently Asked Questions

- [Where can I find the installer for the PMU Connection Tester?](FAQ.md#where-can-i-find-the-installer-for-the-pmu-connection-tester)
- [Does the openPDC provide build scripts?](FAQ.md#does-the-openpdc-provide-build-scripts)
- [Can I run the openPDC on a 64-bit OS?](FAQ.md#can-i-run-the-openpdc-on-a-64-bit-os)
- [Why does the openPDC include x86 platform targets?](FAQ.md#why-does-the-openpdc-include-x86-platform-targets)
- [Can I run the openPDC on low-performance machines?](FAQ.md#can-i-run-the-openpdc-on-low-performance-machines)
- [Synchrophasor Questions](FAQ.md#synchrophasor-questions)
    - [openPDC Questions](FAQ.md#openpdc-questions)
        - [What happens to a device when you set a device's "Connection is to Concentrator" property to true?](FAQ.md#what-happens-to-a-device-when-you-set-a-devices-connection-is-to-concentrator-property-to-true)
        - [What is the difference between the initial data set and the sample data set?](FAQ.md#what-is-the-difference-between-the-initial-data-set-and-the-sample-data-set)
        - [I set up the SQL Server Management Studio and executed the SQL files, but how do I see the changes I made?](FAQ.md#i-set-up-the-sql-server-management-studio-and-executed-the-sql-files-but-how-do-i-see-the-changes-i-made)
        - [Does the Device ACRONYM need to be unique? The modeling instructions don't say so, but they do say that it is how the device is referenced by the program.](FAQ.md#does-the-device-acronym-need-to-be-unique-the-modeling-instructions-dont-say-so-but-they-do-say-that-it-is-how-the-device-is-referenced-by-the-program)
        - [What are the status flags measurements that are defined for each device?](FAQ.md#what-are-the-status-flags-measurements-that-are-defined-for-each-device)
        - [Does the SignalReference field in the Measurement table need to be unique?](FAQ.md#does-the-signalreference-field-in-the-measurement-table-need-to-be-unique)
        - [I receive an error like the following: "Invalid pointer address"](FAQ.md#i-receive-an-error-like-the-following-invalid-pointer-address)
        - [Would data from a single PMU Device typically be used at more than one Substation? Or is a particular PMU strongly associated with a single Substation?](FAQ.md#would-data-from-a-single-pmu-device-typically-be-used-at-more-than-one-substation-or-is-a-particular-pmu-strongly-associated-with-a-single-substation)
        - [When the openPDC is collecting data from other PDCs, is the the parent (concentrator) device or the child device associated with a measurement?](FAQ.md#when-the-openpdc-is-collecting-data-from-other-pdcs-is-the-the-parent-concentrator-device-or-the-child-device-associated-with-a-measurement)
        - [Is it possible to configure the minimum and maximum time delays that the openPDC waits for the data of the PMUs in the system arrive (also known as the "resynchronization buffer")?](FAQ.md#is-it-possible-to-configure-the-minimum-and-maximum-time-delays-that-the-openpdc-waits-for-the-data-of-the-pmus-in-the-system-arrive-also-known-as-the-resynchronization-buffer)
        - [I cannot get a setting I entered into the configuration file to save. When the application runs it keeps coming up blank and getting removed from the file. What's wrong?](FAQ.md#i-cannot-get-a-setting-i-entered-into-the-configuration-file-to-save-when-the-application-runs-it-keeps-coming-up-blank-and-getting-removed-from-the-file-whats-wrong)
        - [Does the openPDC support redundant configurations?](FAQ.md#does-the-openPDC-support-redundant-configurations)
        - [What is the difference between Active, Passive or Hybrid connections as it appears in device status under Connection Type?](FAQ.md#what-is-the-difference-between-active-passive-or-hybrid-connections-as-it-appears-in-device-status-under-connection-type)
        - [I receive SQL Server connection or authentcation errors.](FAQ.md#i-receive-sql-server-connection-or-authentcation-errors)
        - [When setting up a SQLite database, I receive a message like the following, "Could not load file or assembly 'System.Data.SQLite' or one of its dependencies."](FAQ.md#when-setting-up-a-sqlite-database-i-receive-a-message-like-the-following-could-not-load-file-or-assembly-system-data-sqlite-or-one-of-its-dependencies)
        - [I need to reset my database. What should I do?](FAQ.md#i-need-to-reset-my-database-what-should-i-do)
        - [I receive an error like the following when using an Access Database: (openPDC Manager::AccessDenied)](FAQ.md#i-receive-an-error-like-the-following-when-using-an-access-database-openpdc-manager-access-denied)

    - [openPDCManager Questions](FAQ.md#openpdcmanager-questions)
        - [When I run the openPDC Manager, I receive an error that states my operating system does not support SHA-2 algorithms. How can I fix this?](FAQ.md#when-i-run-the-openpdc-manager-i-receive-an-error-that-states-my-operating-system-does-not-support-sha-2-algorithms-how-can-i-fix-this)
        - [I am having trouble installing Silverlight Tools on my system. What does "The hash value is not correct" mean?](FAQ.md#i-am-having-trouble-installing-silverlight-tools-on-my-system-what-does-the-hash-value-is-not-correct-mean)
        - [I receive an error saying "The installer was interrupted before openPDC Manager could be installed. You need to restart the installer to try again." But when I restart, it simply tells me the same thing. What should I do?](FAQ.md#i-receive-an-error-saying-the-installer-was-interrupted-before-openpdc-manager-could-be-installed-you-need-to-restart-the-installer-to-try-again-but-when-i-restart-it-simply-tells-me-the-same-thing-what-should-i-do)
        - [When I try to install openPDC, I recieve an error "Cannot delete the existing openPDC."](FAQ.md#when-i-try-to-install-openpdc-i-recieve-an-error-cannot-delete-the-existing-openpdc)
        - [I just installed the openPDCManager. Why isn't it working properly?](FAQ.md#i-just-installed-the-openpdcmanager-why-isnt-it-working-properly)
        - [When I go to the webpage, I just get a white screen with an "error on page" icon on the statusbar.](FAQ.md#when-i-go-to-the-webpage-i-just-get-a-white-screen-with-an-error-on-page-icon-on-the-statusbar)
        - [The openPDCManager doesn't appear to be connecting to my database.](FAQ.md#the-openpdcmanager-doesnt-appear-to-be-connecting-to-my-database)
        - [Why am I receiving a "CrossDomainError"?](FAQ.md#why-am-i-receiving-a-crossdomainerror)
        - [What is the purpose of the local checkbox on the Manage Historians? Are there cases where they would not on the local network? What does this change when active?](FAQ.md#what-is-the-purpose-of-the-local-checkbox-on-the-manage-historians-are-there-cases-where-they-would-not-on-the-local-network-what-does-this-change-when-active)
        - [The specified service does not exist as an installed service](FAQ.md#the-specified-service-does-not-exist-as-an-installed-service)

- [Historian Questions](FAQ.md#historian-questions)
    - [I receive network permissions or HTTP related errors](FAQ.md#i-receive-network-permissions-or-http-related-errors)
    - [I noticed that my history file seems to stay the same size all of the time. Does it only store a certain amount of history?](FAQ.md#i-noticed-that-my-history-file-seems-to-stay-the-same-size-all-of-the-time-does-it-only-store-a-certain-amount-of-history)
    - [How does the openPDC handle situations where a historian is not responding?](FAQ.md#how-does-the-openpdc-handle-situations-where-a-historian-is-not-responding)
    - [How does the openPDC handle the locally cached measurements?](FAQ.md#how-does-the-openpdc-handle-the-locally-cached-measurements)

- [Hadoop Questions](FAQ.md#hadoop-questions)
    - [What is Hadoop?](FAQ.md#what-is-hadoop)
    - [How does Hadoop relate to the openPDC?](FAQ.md#how-does-hadoop-relate-to-the-openpdc)
    - [How are openPDC and Hadoop used in production?](FAQ.md#how-are-openpdc-and-hadoop-used-in-production)

### Where can I find the installer for the PMU Connection Tester?

*Answer -*  The latest installer for the PMU Connection Tester can be found in the [Nightly Builds](Nightly_Builds.md). See the [PMU Connection Tester](PMU_Connection_Tester.md) documentation page for more information.

#### Does the openPDC provide build scripts

*Answer -*  Yes, the entire build process is command line driven and currently the only files that are checked-out and checked-in are the version files (`AssemblyInfo.*`); we do not archive the build binaries in source control because the build script allows for building a specific version by passing in the version specs to the build script from the command line. The Build.bat file is just a simple wrapper that calls the MSBuild script and proxies the command line parameter
 for the BuildInteractive property that can be used for the build to take place in *unattended* mode (nice for automated nightly builds).

The one trick to getting the build script to work correctly apart from having the required tools (mentioned in `openPDC\Contributor Resources\Tools\Build Tools\Readme.txt`) installed is to make sure that the build machine has an entry for the CodePlex TFS login credentials in Control Panel > User Accounts > Advanced tab > Manage Passwords or else the build script might fail if the credentials have not been entered prior to the build by accessing CodePlex TFS from inside Visual Studio (see: [Saving Password in Team Explorer](http://codeplex.codeplex.com/Wiki/View.aspx?title=Using%20TFS%20and%20Team%20Explorer%20with%20CodePlex&referringTitle=Home#Password)).

Almost all the properties used by the build script can be overridden from the command line and the way this can be done is to run the build script from command line and overriding the default property values using the `/p` switch like:

`C:\WINDOWS\Microsoft.NET\Framework\v3.5\msbuild.exe Synchrophasor.buildproj /p:SkipHelpFiles=Yes;BuildDeployFolder="C:\Build"`

A full list of overridable properties can be seen in the Master.buildproj file, but here are some handy ones:

- `SkipHelpFiles` - Yes or any other text to skip building the help docs.
- `BuildDeployFolder` - Final destination of the build output; build output is always available where the build takes place.  By default this is `c:\windows\temp\msbuild\openpdc`).
- `BuildFlavor` - Debug or Release. 
- `SourceVersion` - Specific version of the source code to be built. For example: C31221 to build committed changes up to changeset #31221.
- `ForceBuild` - true to force a build even if there are no new changes since the last successful build.  By default the build process will be skipped if no new changes have been committed since the last successful build.

#### Can I run the openPDC on a 64-bit OS?

*Answer -*  Yes, but if you are using Access for your system configuration database you must run openPDC as a 32-bit application. We recommend using SQL Server, MySQL or other database in production so that you can run as a 64-bit application.

Note that later versions of the openPDC, starting at 2.0, only support 64-bit installations on Windows platforms. SQLite is the recommended *no installation required* database for new versions of openPDC.

#### Why does the openPDC include x86 platform targets?

*Answer -*  This is to force the build outputs to run as a 32-bit app on a 64-bit system so that it will also work with Access if needed. AnyCPU targets cause applications to run as 64-bit on 64-bit systems and 32-bit on 32-bit systems - x86 forces 32-bit operation on 32-bit or 64-bit systems.

The automated nightly build forces a complete x86 build of the entire system (available as openPDCSetup.msi (x86) - opposed to openPDCSetup64.msi (AnyCPU)) so that when you install the 32-bit version of the openPDC on a 64-bit system, it will run as a 32-bit system that will work with Access, even though you are on a 64-bit server.

Also, you change the target output for the entire solution in Visual Studio to x86 (this is a local user setting) and run with an Access database for your configuration.

#### Can I run the openPDC on low-performance machines?

*Answer -*  Yes, but you may need to lower the process priority of the openPDC to High instead of RealTime in order to prevent locking of the system on single-core machines, particularly if you've chosen to use a MySQL database for your openPDC configuration. There is a setting in the configuration file (openPDC.exe.config, found in the [installation directory](Getting_Started.md#install_directory)) that you can use to change the process priority of the openPDC.

```xml
<configuration>
  <categorizedSettings>
    <systemSettings>
      <add name="ProcessPriority" value="High" />
    </systemSettings>
  </categorizedSettings>
</configuration>
```

Starting with version 2.1 of the openPDC, you can now [run the openPDC on a Raspberry Pi](Running_openPDC_on_a_Raspberry_Pi.md)

---

## Synchrophasor Questions

### openPDC Questions

#### What happens to a device when you set a device's *Connection is to Concentrator* property to true?

*Answer -*  The *Connection is to Concentrator* property designates the device connection as having more than one device in a frame since a connection to multiple devices for a single connection has to be handled a little differently than a connection that contains a connection to a single device. Think of it this way: the openPDC models every device (i.e., PMU) regardless of its source - that is, whether the device came by proxy through a concentrator or  directly it has its own definition. The connection information can then either be associated with device itself (direct connection) or its parent concentrator (which is also technically a *device*) - so the flag simply defines if the connection has data or if the connection contains devices which have data. If you check this box the system will expect to have some children devices defined for it (even if only one).

#### What is the difference between the initial data set and the sample data set?

*Answer -*  Please note the following table.

| Database Type | Structural Definition | Initial Data Set           | Sample Data Set           |
| ------------- | --------------------- | -------------------------- | ------------------------- |
| SQL Server    | openPDC.sql           | InitialDataSet.sql         | SampleDataSet.sql         |
| MySQL         | openPDC.sql           | InitialDataSet.sql         | SampleDataSet.sql         |
| SQLite        | openPDC.db            | openPDC-InitialDataSet.db  | openPDC-SampleDataSet.db  |
| MS Access     | openPDC.mdb           | openPDC-InitialDataSet.mdb | openPDC-SampleDataSet.mdb |

- The structural definition is just the database structure with absolutely no data.
- The initial data set is the recommended initial data set for the openPDC with no nodes, devices, or output streams.
- The sample data set is the initial data set plus one defined node, sample input and output stream for "out-of-the-box" testing.

#### I set up the SQL Server Management Studio and executed the SQL files, but how do I see the changes I made?

*Answer -*  In the Object Explorer view on the left, right-click on *Databases* and select *Refresh*. The openPDC database will now show up in the list of Databases.

#### Does the Device ACRONYM need to be unique? The modeling instructions don't say so, but they do say that it is how the device is referenced by the program.

*Answer -*  Yes, this acronym must be unique. It becomes a key part of the signal reference used to identify and associate measurements to their PMU values.

#### What are the status flags measurements that are defined for each device?

*Answer -*  The status flags measurement is a double-word bitmapped flag contained in each frame that holds data about the device and its measurements.

**Upper Word** - This is an "Abstracted" set of flags that are consistent across all devices regardless of their protocol for reporting to the openPDC:

- Bits 31-21: Reserved 
- Bit 20: Data discarded : 0 when data is discarded from the real-time stream due to late arrival.
- Bit 19: Data valid : 0 when PMU data is valid, 1 when invalid or PMU is in test mode.
- Bit 18: Synchronization valid : 0 when in device is in sync, 1 when it is not.
- Bit 17: Data sorting : 0 by time stamp, 1 by arrival. 
- Bit 16: Device error (including configuration error) : 0 when in error. 

**Lower Word** - These are the 'Original' set of status flags reported by device itself and would therefore be protocol specific. For the IEEE C37.118 protocol, this lower byte has the following mapping:

- Bit 15: Data valid - 0 when PMU data is valid, 1 when invalid or PMU is in test mode.
- Bit 14: PMU error including configuration error - 0 when no error. 
- Bit 13: PMU sync - 0 when in sync. 
- Bit 12: Data sorting - 0 by time stamp, 1 by arrival. 
- Bit 11: PMU trigger detected - 0 when no trigger. 
- Bit 10: Reserved for future common flags - presently set to 0. 
- Bits 09-06: Reserved for security - presently set to 0. 
- Bits 05-04: Unlocked time:
    - 00 = sync locked, best quality 
    - 01 = Unlocked for 10 s 
    - 10 = Unlocked for 100 s 
    - 11 = Unlocked over 1000 s 
- Bits 03-00: Trigger reason:
    - 1111-1000 = Available for user definition 
    - 0111 = Digital 
    - 0110 = Reserved 
    - 0101 = df/dt high 
    - 0100 = Frequency high/low 
    - 0011 = Phase-angle diff 
    - 0010 = Magnitude 

#### Does the SignalReference field in the Measurement table need to be unique?

*Answer -*  Like device acronyms, signal reference values must be unique (the database definitions should enforce this constraint). The signal reference creates an association between a unique individual signal (i.e., a measurement) and a channel value within a parsed frame of phasor data from a specific PMU.

#### I receive an error like the following: "Invalid pointer address"

For example: **"The system detected an invalid pointer address in attempting to use a pointer argument in a call."**

*Answer -*  Recent Windows versions default to IPv6 addressing. You will need to either supply DNS or IPv6 addresses (e.g., ::1 which is the IPv6 equivalent of 127.0.0.1) or force IPv4 addressing. In order to force IPv4 addressing, either add interface=0.0.0.0 to the connection string or, if you are using the PMU Connection Tester, change ForceIPv4 to true in the PMU Connection Tester configuration.

#### Would data from a single PMU Device typically be used at more than one Substation? Or is a particular PMU strongly associated with a single Substation?

*Answer -*  PMU definitions in the system normally refer directly to a piece of field hardware which is typically located at a substation. The important concept is one definition for one physical device regardless of delivery mechanism (direct connection, within a concentration stream from a PDC, etc.) If the same device data comes in from multiple streams and it is desirable to capture all instances of the data - the device will have to be modeled and named separately for each stream (e.g., MYPMU-1, MYPMU-2). This may be useful for critical devices that have a primary and backup data flow.

#### When the openPDC is collecting data from other PDCs, is the the parent (concentrator) device or the child device associated with a measurement?

*Answer *  Measurements are always associated with a PMU. The PDC record exists only to define the *connection* and which PMUs will arrive through this connection. After this it has no further purpose.

#### Is it possible to configure the minimum and maximum time delays that the openPDC waits for the data of the PMUs in the system arrive (also known as the "resynchronization buffer")?

*Answer -*  Yes, the **LagTime** and **LeadTime** columns in the OutputStream table are the *resynchronization* parameters. They operate is as follows:

**LagTime** is a double precision number that defines the allowed past time deviation tolerance, in seconds (can be subsecond). It defines the time sensitivity to past measurement timestamps and is the number of seconds allowed before assuming a measurement timestamp is too old. This becomes the maximum amount of delay that can be introduced by the concentrator to allow time for data to flow into the system.

**LeadTime** is a double precision number that defines the allowed future time deviation tolerance, in seconds (can be subsecond). It defines the time sensitivity to future measurement timestamps and is the number of seconds allowed before assuming a measurement timestamp is too advanced. This becomes the tolerated +/- accuracy of the local clock to real-time.

Because the measurements being received by remote phasor devices are usually measured relative to GPS time, these timestamps are typically more accurate than the local system clock. As a result, we can use the latest received timestamp as the best local time measurement we have (ignoring transmission delays); but, even these times can be incorrect so we still have to apply reasonability checks to these times. To do this, we use the local system time and the LeadTime value to validate the latest measured timestamp. If the newest received measurement timestamp gets too old or creeps too far into the future (both validated + and - against defined lead time property value), we will fall back on local system time. Note that this creates a dependency on a fairly accurate local clock - the smaller the lead time deviation tolerance, the better the needed local clock accuracy. For example, a lead time deviation tolerance of a few seconds might only require keeping the local clock synchronized to an NTP time source; but, a sub-second  tolerance would require that the local clock be very close to GPS time.

Note that your lag time should be defined as it relates to the rate at which data is coming into the concentrator. Make sure you allow enough time for transmission of data over the network allowing any needed time for possible network congestion. Lead time should be defined as your confidence in the accuracy of your local clock (e.g., if you set lead time to 2, this means you trust that your local clock is within plus or minus 2 seconds of real-time.)

The other important property is UseLocalClockAsRealTime which defines a flag that determines whether or not to use the local clock time as real time. You should only use your local system clock as real time if the time is locally GPS hardware-synchronized or if the incoming measurement values being sorted were not measured relative to a GPS-synchronized clock (e.g., non PMU device).

#### I cannot get a setting I entered into the configuration file to save. When the application runs it keeps coming up blank and getting removed from the file. What's wrong?

*Answer -*  This setting may be set up for encryption. Check the `encrypted` attribute, and make sure it is set to `encrypted="false"`

#### Does the openPDC support redundant configurations?

*Answer -*  There are two primary options for configuring the openPDC to support system redundancy using typical clustering technologies. When deployed as a Windows service, the openPDC supports both *fail over* and *load balanced* configurations:

1. The most common, and easiest to configure, redundancy deployment option will be the *fail over* cluster. In this mode, the openPDC is deployed on two systems: a primary and a hot stand-by. Both the primary and hot stand-by nodes will both share the same configuration and archive data to the same location, as only one of the systems will be active at one time. When one system fails or needs to go offline for maintenance, the other system is activated.
2. Although more involved to set up and configure, the openPDC can be deployed in a load-balanced environment. In this mode, multiple openPDC instances are up and running simultaneously. Additionally, each open PDC would be set up in server mode, listening for incoming connections and/or streaming data. All incoming data would be passed to an openPDC via a data proxy. The data proxy could be set up as an adapter in a *substation* openPDC, then sent to the control center load-balanced openPDC cluster. The load balanced option also allows for all the openPDC data services to be "distributed" to clients based on load.

#### What is the difference between Active, Passive or Hybrid connections, as it appears in device status under Connection Type?

*Answer -*  Connections to devices can be direct "active" (such as TCP or serial) or unattended "passive" (such as UDP). Both transports styles have their pros and cons. Active traffic is typically sent with a transport level CRC and will "resend" if a packet failed to transport; since this is data is time-sensitive in nature, this can cause live data streams to fall further and further behind over time. Because of this issue, active style connections are only recommended for smaller data payloads, like those delivered from a connection to a single device. Passive traffic is broadcast without concern about whether or not the intended recipient received the data. This has been described effectively as "turning on the fire-hose". The good thing about a passive connection is that data stream will not fall behind; it doesn"t care if you missed a packet. But, therein lies the primary issue with passive transports. More recent devices are supporting an active "command" channel and a passive "data" channel, a "hybrid" connection type which is ideal for protocols requiring control commands to request a configuration and/or start a data stream. Future protocol versions supporting this kind of dual connectivity should be able to solve all aforementioned transport issues with passive channel packet loss by allowing the command channel to re-request missed packets from a local short term archive. This would not necessarily be useful from a real-time perspective but would be valuable in making sure your archive was complete.

#### I receive SQL Server connection or authentcation errors.

**WARNING: Failed to load database configuration due to exception: Login failed for user 'openPDCUser'. The user is not associated with a trusted SQL Server connection. Attempting to use last known good configuration.**

*Answer -*  This error can be caused by setting up the wrong authentication mode for your SQL Server (for example, you set up your SQL server for Windows Authentication mode only). Follow these steps to fix it:

1. Launch SQL Server Management Studio Express. 
2. Connect to your server.
3. In the Object Explorer on the left, right-click the server and select "Properties".
4. On the left under "Select a page", select "Security".
5. Under "Server authentication", select "SQL Server and Windows Authentication mode".
6. Select "OK".
7. In the Object Explorer, right-click on the server again, and select "Restart". **NOTE**: You may need to run SQL Server Management Studio Express as an administrator in order to restart the server.
8. Once the server has restarted, try running openPDC again.

#### When setting up a SQLite database, I receive a message like the following, "Could not load file or assembly 'System.Data.SQLite' or one of its dependencies".

*Answer -*  You may need to install the Microsoft Visual C++ 2010 Redistributable Package. They can be found at the following locations.

[Microsoft Visual C++; 2010 Redistributable Package (x64)](http://www.microsoft.com/download/en/details.aspx?id=14632)  
[Microsoft Visual C++; 2010 Redistributable Package (x86)](http://www.microsoft.com/download/en/details.aspx?id=5555)

Also make sure the SQLite assemblies can be found in the openPDC installation folder.

#### I need to reset my database. What should I do?

*Answer -*  Use the Configuration Setup Utility to create a new database - this is the simplest and preferred way to create a new configuration.

If you need to do this manually, follow these steps corresponding to your database:

- [SQLite/Access](FAQ.md#resetting-your-sqlite-or-access-database)
- [SQL Server](FAQ.md#resetting-your-sql-server-database)
- [MySQL](FAQ.md#resetting-your-mysql-database)

**IMPORTANT**: The following steps will reset the database back to the state when you first created it. Any information you entered into the database will be lost.

##### Resetting your SQLite or Access database

1. Navigate to `SOURCEDIR\Synchrophasor\Current Version\Build\Output\Debug\openPDC` and delete the file `openPDC.db` for SQLite or `openPDC.mdb` for Access (`SOURCEDIR` is the directory where you extracted the openPDC source code files). *Note that the database may be installed in another folder if not runing from source code.*
2. [Setting up an Access database](Getting_Started.md#setting-up-an-access-database).

##### Resetting your SQL Server database

1. Launch SQL Server Management Studio Express and connect to your database server
2. In the Object Explorer on the left, expand "Databases"
3. Right-click "openPDC" and select "Delete"
4. Select the check box labeled "Close existing connections", and select "OK"
5. [Setting up a SQL Server database](Getting_Started.md#setting-up-a-sql-server-database).

##### Resetting your MySQL database

1. Open your native command terminal and run the following command: `mysql -uroot -p`
2. Enter your root password and press "Enter"
3. Once you've entered the MySQL prompt, enter the following commands:
    `DROP DATABASE openPDC;`
    `exit`
4. [Setting up a MySQL database](Getting_Started.md#setting-up-a-mysql-database)

#### I receive an error like the following when using an Access Database: "Access Denied"

For Example: "openPDC Manager::Access Denied: Error Loading security provider: Operation must use an updatable query"

*Answer -*  This error usually occurs when the Access database is saved to a folder that you do not have permission to. Try one of the following to fix this error:

- Navigate to `C:\Program Data\openPDC` and right-click on the openPDC Access file. Uncheck the box that says "read-only", then click 'OK'.
- When setting up the Access database with the configuration utility, browse to a different location on the "Set up an Access database" screen and proceed with the configuration.

### openPDCManager Questions

#### When I run the openPDC Manager, I receive an error that states my operating system does not support SHA-2 algorithms. How can I fix this?

*Answer -*  Go to registry key **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Cryptography\Defaults\Provider**, find its subkey named "Microsoft Enhanced RSA and AES Cryptographic Provider (Prototype)", export it to .reg, edit this .reg and delete " (Prototype)" from its name. When you import it back, the original key will be duplicated to the new key without "(Prototype)", with the same contents. From now on, SHA256CryptoServiceProvider will work on this XPSP3 machine.

#### I am having trouble installing Silverlight Tools on my system. What does "The hash value is not correct" mean?

*Answer -*  This happens because the Silverlight installation tries to download the Silverlight Developer Runtime and cannot access the server. Try following these steps in order to perform the installation:

1. Download and save the [Microsoft Silverlight 3 Tools for VS 2008 SP1](http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en) to your workstation.
2. Create a new directory on your workstation.
3. From the command prompt, run the following command: `silverlight3_tools.exe /x`
4. Specify the directory you created in step 2.
5. Download and save the [Silverlight Developer Runtime](http://silverlight.dlservice.microsoft.com/download/C/5/B/C5BB5CD8-E871-49AC-8A40-61010E1FD1CF/Silverlight_Developer.exe) to the directory you created in step 2.
6. Run SPInstaller.exe which is currently in the directory that you created in step 2.
7. Once the installation is finished, you may delete the directory you created in step 2.


#### I receive an error saying "The installer was interrupted before openPDC Manager could be installed. You need to restart the installer to try again." But when I restart, it simply tells me the same thing. What should I do?

*Answer -*  This could be that you simply need to run the installer as an administrator, if this is not the issue then the first thing to check is to make sure you have .NET 3.5 and IIS 4.0 or later installed on your system. Additionally, if you are using IIS 7, you need to install IIS 6 Management Compatibility by going to "Programs and Features > Turn Windows Features on or off > Internet Information Service > Web Management Tools > IIS6 Management Compatibility".

If you are still receiving this problem, you may need to register ASP.NET with IIS.

1. Locate *aspnet_regiis.exe* in the `C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727` directory
2. Open the command prompt and navigate to that directory. 
3. Type the command: `aspnet_regiis -i`
4. Try to install the openPDCManager again. 

#### When I try to install openPDC, I recieve an error "Cannot delete the existing openPDC."

*Answer -*  This can happen if files in the openPDC programs folder are moved or removed without uninstalling and perhaps other things could cause this as well. Try removing the following registry key (run *RegEdit.exe* to find or remove registry keys):

`HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Installer\Products\DEC6D3946C055FC4393A03C663F4013A`

If you don't find this key, search for openPDC within `HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Installer\Products\` and delete this key. Once deleted, try reinstalling the application.

#### I just installed the openPDCManager. Why isn't it working properly?

*Answer -*  If you used the installers, you will need to modify the `web.config` file in the openPDCManager to point to the correct services URL.  

Change these settings:

```xml
<appSettings>
  <!-- <add key="BaseServiceUrl" value="http://localhost/openPDCManagerServices/" /> -->
  <add >key="BaseServiceUrl" value="http://localhost:1068/" />
</appSettings>
```

This is what you should change it to:

```xml
<appSettings>
  <add key="BaseServiceUrl" value="http://localhost/openPDCManagerServices/" />
  <!-- <add key="BaseServiceUrl" value="http://localhost:1068/" /> -->
</appSettings>
```

#### When I go to the webpage, I just get a white screen with an &quot;error on page&quot; icon on the statusbar.</h4>

*Answer -* Check if the following MIME types are registered on your machine.

- `.xaml --> application/xaml+xml`
- `.xap --> application/x-silverlight-app`

#### The openPDCManager doesn't appear to be connecting to my database.

*Answer -*  You need to modify the &quot;web.config&quot; file in the openPDCManagerServices (note this is not the same file as the &quot;web.config&quot; file in the openPDCManager). The process is described on the [openPDCManager configuration page](openPDC_Manager_Configuration.md#configure_database_connection).

Additionally, if you are using IIS 7, you may need to register the MIME type for `.svc` files. Open the command prompt and type

`"%windir%\Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ServiceModelReg.exe" -r -y`

#### Why am I receiving a CrossDomainError?

*Answer -*  It's possible that you will need to move the `clientaccesspolicy.xml` file up one level in the directory structure. The file should be located in the installation directory for `openPDCManagerServices` (`C:\Inetpub\wwwroot\openPDCManagerServices` by default).
 
#### What is the purpose of the local checkbox on the Manage Historians? Are there cases where they would not on the local network? What does this change when active?

*Answer -*  Basically the checkbox on local network is used for "auto-assignment" of default values for *LocalOutputAdapter* vs. *RemoteOutputAdapter* if type name is null. This way assignment of AssemblyName and TypeName fields is completely optional if you are using the built-in archiving code (for instance, binary file format used with Hadoop). However, you will need to enter these fields for commercial historians or other custom archive destinations.

#### The Specified service does not exist as an installed service

*Answer -*  We have encountered this error, when we have installed different versions of openPDC manager and when it says application may not be fully unistalled after the unistall is complete. 

1. Please go to the control panel and try to uninstall the version that already exists. 
2. Once it is uninstalled pull up the command prompt and execute the below. 
    `sc create openPDC binPath= "C:\Program Files\openPDC\openPDC.exe"`
3. If you have not got success in getting rid of the error then, Please go back to the file location and find the INSTALLERS folder and try to uninstall from that folder. (If you still have a problem, please go back to the previous version INSTALLERS folder find `openPDCSetup64.msi` copy that in the present folder and try to uninstall). This should finally help you.

---

## Historian Questions

#### I receive network permissions or HTTP related errors

For Example:

**[LocalDevArchive] MetadataService could not be loaded - HTTP could not register URL `http://+:6151/historian/.` Your process does not have access rights to this namespace (see http://go.microsoft.com/fwlink/?LinkId=70353 for details).**

**[LocalDevArchive] TimeSeriesDataService could not be loaded - HTTP could not register URL `http://+:6152/historian/`. Your process does not have access rights to this namespace (see http://go.microsoft.com/fwlink/?LinkId=70353 for details).**

*Answer -*  Windows 7 defines user access control lists to manage permissions to HTTP web services. Open the command prompt as an administrator, and run the following commands using your user account ID and domain.  **NOTE**: If you are not logged into a domain, use your computer name as the domain name.

```dos
netsh http add urlacl url=http://+:6151/historian user=DOMAIN\user
netsh http add urlacl url=http://+:6152/historian user=DOMAIN\user
```

A GUI is available which can perform a similar task: [Download: httpconfig.zip](http://www.stevestechspot.com/downloads/httpconfig.zip) from www.stevestechspot.com.

#### I noticed that my history file seems to stay the same size all of the time. Does it only store a certain amount of history?

*Answer -*  The historian pre-allocates the data files it uses for writing time-series data and "rolls over" to a new file once the current file is full. The size along with other parameters of the historian data file can be configured in the openPDC config file under the `<archiveFile>` section.


#### How does the openPDC handle situations where a historian is not responding?

*Answer -* In the event that a historian stops responding to the openPDC's attempts to send it data, the openPDC will buffer the data meant for that historian. The openPDC will attempt to re-establish communication to the historian with rolling connection attempts. When the connection to the historian is established the data will then be sent to the historian for archival.


#### How does the openPDC handle the locally cached measurements?

*Answer -*  If the openPDC has cached measurements for a historian that does respond, the openPDC will push the entire cache of data to the historian as soon as the historian is reconnected - this data will be pushed to the historian as quickly as possible to relieve memory pressure. If the historian continues to not respond, the openPDC will start dropping the oldest data in order not to exceed a user configurable number of points in memory (this to avoid possible out-of-memory errors). The settings to control the number of points maintained in memory can be found in the openPDC configuration file (`SOURCEDIR\Build\Output\Debug\Applications\openPDC\openPDC.exe.config` where `SOURCEDIR` is the root directory of the source code). These numbers can be adjusted to a much higher levels on 64-bit machines with large amounts of available memory.

**IMPORTANT**: The openPDC will send the entire cached measurement queue to the archiver therefore it is imperative that the space taken by cached points on the openPDC server cannot exceed the space available on the archive server.

**Note**: These settings will not appear in your configuration file until you run openPDC.exe for the first time.

```xml
<configuration
  <categorizedSettings>
    <thresholdSettings>
      <add name="MeasurementWarningThreshold" value="100000" />
      <add name="MeasurementDumpingThreshold" value="500000" />
      <add name="DefaultSampleSizeWarningThreshold" value="10" />
    </thresholdSettings>
  </categorizedSettings>
</configuration>
```

| Setting Name | Description |
| ------------ | ----------- |
| MeasurementWarningThreshold | Number of unarchived measurements allowed in any output adapter queue before displaying a warning message |
| MeasurementDumpingThreshold |Number of unarchived measurements allowed in any output adapter queue before taking evasive action and dumping data |
| DefaultSampleSizeWarningThreshold | Default number of unpublished samples (in seconds) allowed in any action adapter queue before displaying a warning message |

---

## Hadoop Questions

#### What is Hadoop?

*Answer -*  Hadoop is a framework for running applications on large clusters built from commodity hardware.

#### How does Hadoop relate to the openPDC?

*Answer -*  The openPDC is capable of collecting petabytes of synchrophasor data. On a standard desktop system, processing that data linearly can take hundreds of days. Hadoop will be utilized to process that data on many machines in parallel, greatly reducing the time needed by dividing the work among the nodes.

#### How are openPDC and Hadoop used in production?

*Answer -*  The following are references to using openPDC and Hadoop in production with both HDFS for cheap scalable storage and MapReduce for processing large amounts of time series data.

*Original Whitepapers*

- [http://www.cloudera.com/resource/hadoop-platform-smartgrid-tva-josh-patterson](http://www.cloudera.com/resource/hadoop-platform-smartgrid-tva-josh-patterson)
    - [Archived PDF](FAQ.files/chadnug03102011v1-111004121455-phpapp01.pdf)
- [http://www.cloudera.com/blog/2009/06/smart-grid-hadoop-tennessee-valley-authority-tva](http://www.cloudera.com/blog/2009/06/smart-grid-hadoop-tennessee-valley-authority-tva)

*OSCON-data presentation (good TVA story here)*

- [http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard](http://www.slideshare.net/jpatanooga/oscon-data-2011-lumberyard)
    - [Archived PDF](FAQ.files/osconlumberyard20110518v8-110929133838-phpapp02.pdf)

*High Level articles/coverage of project*

- [http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva](http://www.slideshare.net/cloudera/hadoop-as-the-platform-for-the-smartgrid-at-tva)
    - [Archived PDF](FAQ.files/hadoopastheplatformforthesmartgridattva-100830160157-phpapp02.pdf)
- [http://www.tva.gov/news/releases/octdec09/data_collection_software.htm](http://www.tva.gov/news/releases/octdec09/data_collection_software.htm)
    - [Archive Not Available]()
- [http://jpatterson.floe.tv/index.php/2009/10/29/the-smartgrid-goes-open-source](http://jpatterson.floe.tv/index.php/2009/10/29/the-smartgrid-goes-open-source)
    - [Archived WayBack](FAQ.files/JPatterson_floe_tv_2009-10-29_the-smartgrid-goes-open-source.md)
- [http://gigaom.com/cleantech/the-google-android-of-the-smart-grid-openpdc](http://gigaom.com/cleantech/the-google-android-of-the-smart-grid-openpdc)
- [http://news.cnet.com/8301-13846_3-10393259-62.html](http://news.cnet.com/8301-13846_3-10393259-62.html)
- [http://gigaom.com/cleantech/how-to-use-open-source-hadoop-for-the-smart-grid](http://gigaom.com/cleantech/how-to-use-open-source-hadoop-for-the-smart-grid)

*Engineering Literature*

- [https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version](https://openpdc.svn.codeplex.com/svn/Hadoop/Current%20Version)
- [Hadoop openPDC Dataminning Tools Guide](FAQ.files/openPDC_Datamining_Tools_Guide.pdf)

*General time series processing with Hadoop* (along with another source code example)

- [http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1](http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-1)
- [http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2](http://www.cloudera.com/blog/2011/03/simple-moving-average-secondary-sort-and-mapreduce-part-2)
- [http://www.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3](http://www.cloudera.com/blog/2011/04/simple-moving-average-secondary-sort-and-mapreduce-part-3)

---

Mar 25, 2015 at 9:12 PM Last edited by [ritchiecarroll](https://github.com/ritchiecarroll), version 90  
Oct 3, 2015 Migrated from [CodePlex](http://openpdc.codeplex.com/wikipage?title=Automated%20Connection%20Failover) by [aj](https://github.com/ajstadlin)

---

Copyright 2016 [Grid Protection Alliance](http://www.gridprotectionalliance.org)
