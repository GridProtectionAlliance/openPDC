Imports System.Reflection
Imports System.Runtime.InteropServices

' Assembly identity attributes.
<Assembly: AssemblyVersion("1.1.60.50685")> 

' Informational attributes.
<Assembly: AssemblyCompany("TVA")> 
<Assembly: AssemblyCopyright("No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.")> 
<Assembly: AssemblyProduct("openPDC")> 

' Assembly manifest attributes.
#If DEBUG Then
<Assembly: AssemblyConfiguration("Debug Build")> 
#Else
<Assembly: AssemblyConfiguration("Release Build")>
#End If
<Assembly: AssemblyTitle("PMU Connection Tester")> 
<Assembly: AssemblyDescription("openPDC PMU Connection Tester")> 

' Other configuration attributes.
<Assembly: ComVisible(False)> 
<Assembly: Guid("8a76a65e-5664-441e-9a8d-fe0909047c3d")> 
