Imports System.Reflection
Imports System.Runtime.InteropServices

' Assembly identity attributes.
<Assembly: AssemblyVersion("1.1.83.54923")> 

' Informational attributes.
<Assembly: AssemblyCompany("Grid Protection Alliance")> 
<Assembly: AssemblyCopyright("Copyright © 2010, All Rights Reserved.")> 
<Assembly: AssemblyProduct("openPDC")> 

' Assembly manifest attributes.
#If DEBUG Then
<Assembly: AssemblyConfiguration("Debug Build")> 
#Else
<Assembly: AssemblyConfiguration("Release Build")>
#End If
<Assembly: AssemblyTitle("PMU Connection Tester")> 
<Assembly: AssemblyDescription("PMU Connection Tester")> 

' Other configuration attributes.
<Assembly: ComVisible(False)> 
<Assembly: Guid("8a76a65e-5664-441e-9a8d-fe0909047c3d")> 
