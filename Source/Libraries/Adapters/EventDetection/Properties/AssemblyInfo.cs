using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;

// Assembly identity attributes.
[assembly: AssemblyVersion("1.0.4.31271")]

// Informational attributes.
[assembly: AssemblyCompany("TVA")]
[assembly: AssemblyCopyright("No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.")]
[assembly: AssemblyProduct("openPDC")]

// Assembly manifest attributes.
#if DEBUG
[assembly: AssemblyConfiguration("Debug Build")]
#else
[assembly: AssemblyConfiguration("Release Build")]
#endif
[assembly: AssemblyDefaultAlias("EventDetection")]
[assembly: AssemblyDescription("Event detection output adapters.")]
[assembly: AssemblyTitle("EventDetection")]

// Other configuration attributes.
[assembly: CLSCompliant(false)]
[assembly: ComVisible(false)]
[assembly: Guid("784becf9-c3ff-4248-ac7a-67eab006cd4e")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
