using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("openPDC Test Adapters")]
[assembly: AssemblyDescription("Test adapters.")]
[assembly: AssemblyCompany("TVA")]
[assembly: AssemblyProduct("openPDC")]
[assembly: AssemblyCopyright("No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.")]
[assembly: AssemblyTrademark("Author: J. Ritchie Carroll, Pinal C. Patel")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug Build")]
#else
[assembly: AssemblyConfiguration("Release Build")]
#endif

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

//The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("64555b34-89bb-4f48-906a-9b4ff91cedb4")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// <Assembly: AssemblyVersion("1.0.*")>
[assembly: AssemblyVersion("1.0.0.0")]
