using System.Reflection;
using System.Runtime.InteropServices;

// Assembly identity attributes.
[assembly: AssemblyVersion("1.1.19.42607")]

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
[assembly: AssemblyDescription("Remote console application for windows service that hosts input, action and output adapters.")]
[assembly: AssemblyTitle("openPDC Remote Console")]

// Other configuration attributes.
[assembly: ComVisible(false)]
[assembly: Guid("1db0288f-db88-45d5-9187-5ab60e4dba69")]
