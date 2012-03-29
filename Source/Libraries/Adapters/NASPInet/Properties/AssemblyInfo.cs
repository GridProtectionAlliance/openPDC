using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;

// Assembly identity attributes.
[assembly: AssemblyVersion("1.5.72.0")]

// Informational attributes.
[assembly: AssemblyCompany("Grid Protection Alliance")]
[assembly: AssemblyCopyright("Copyright © 2010.  All Rights Reserved.")]
[assembly: AssemblyProduct("openPDC")]

// Assembly manifest attributes.
#if DEBUG
[assembly: AssemblyConfiguration("Debug Build")]
#else
[assembly: AssemblyConfiguration("Release Build")]
#endif
[assembly: AssemblyDefaultAlias("NASPInet")]
[assembly: AssemblyDescription("NASPInet input and output adapters.")]
[assembly: AssemblyTitle("NASPInet")]

// Other configuration attributes.
[assembly: CLSCompliant(false)]
[assembly: ComVisible(false)]
[assembly: Guid("e78b7e5b-4b8f-4341-a540-5a42961eae09")]
