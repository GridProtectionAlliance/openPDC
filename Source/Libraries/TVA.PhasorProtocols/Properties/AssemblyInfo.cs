using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;

// Assembly identity attributes.
[assembly: AssemblyVersion("1.0.17.33088")]

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
[assembly: AssemblyDefaultAlias("TVA.PhasorProtocols")]
[assembly: AssemblyDescription("Standard phasor protocol implementations.")]
[assembly: AssemblyTitle("TVA.PhasorProtocols")]

// Other configuration attributes.
[assembly: CLSCompliant(false)]
[assembly: ComVisible(false)]
[assembly: Guid("6d59b0ed-1991-4f12-a739-2cf8543dd9b2")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
