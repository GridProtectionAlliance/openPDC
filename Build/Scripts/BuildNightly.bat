::*******************************************************************************************************
::  BuildNightly.bat - Gbtc
::
::  Tennessee Valley Authority, 2009
::  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
::
::  This software is made freely available under the TVA Open Source Agreement (see below).
::
::  Code Modification History:
::  -----------------------------------------------------------------------------------------------------
::  10/20/2009 - Pinal C. Patel
::       Generated original version of source code.
::  09/14/2010 - Mihir Brahmbhatt
::		 Change Framework path from v3.5 to v4.0
::	09/15/2010 - Mihir Brahmbhatt
::		Add parameters to skip help files
::*******************************************************************************************************

@ECHO OFF
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\msbuild.exe Synchrophasor.buildproj /p:SkipHelpFiles=true /l:FileLogger,Microsoft.Build.Engine;logfile=Synchrophasor.output