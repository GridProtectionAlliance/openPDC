::*******************************************************************************************************
::  UpdateDependencies.bat - Gbtc
::
::  Tennessee Valley Authority, 2009
::  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
::
::  This software is made freely available under the TVA Open Source Agreement (see below).
::
::  Code Modification History:
::  -----------------------------------------------------------------------------------------------------
::  02/26/2011 - Pinal C. Patel
::       Generated original version of source code.
::
::*******************************************************************************************************

@ECHO OFF

SET vs="%VS100COMNTOOLS%\..\IDE\devenv.com"
SET tfs="%VS100COMNTOOLS%\..\IDE\tf.exe"
SET source1="\\GPAWEB\NightlyBuilds\TVACodeLibrary\Beta\Libraries\*.*"
SET target1="..\..\Source\Dependencies\TVA"
SET source2="\\GPAWEB\NightlyBuilds\TimeSeriesFramework\Beta\Libraries\TimeSeriesFramework.*"
SET target2="..\..\Source\Dependencies\TimeSeriesFramework"
SET source3="\\GPAWEB\NightlyBuilds\openHistorian\Beta\Libraries\*.*"
SET target3="..\..\Source\Dependencies\TVA"
SET solution="..\..\Source\Synchrophasor.sln"
SET sourcetools=..\..\Source\Applications\openPDC\openPDCSetup\
SET frameworktools=\\GPAWEB\NightlyBuilds\TVACodeLibrary\Beta\Tools\
SET historiantools=\\GPAWEB\NightlyBuilds\openHistorian\Beta\Tools\
SET /p checkin=Check-in updates (Y or N)? 

ECHO.
ECHO Getting latest version...
%tfs% get %target1% /version:T /force /recursive /noprompt
%tfs% get %target2% /version:T /force /recursive /noprompt

ECHO.
ECHO Checking out dependencies...
%tfs% checkout %target1% /recursive /noprompt
%tfs% checkout %target2% /recursive /noprompt
%tfs% checkout "%sourcetools%ConfigCrypter.exe" /noprompt
%tfs% checkout "%sourcetools%ConfigurationEditor.exe" /noprompt
%tfs% checkout "%sourcetools%HistorianPlaybackUtility.exe" /noprompt

ECHO.
ECHO Updating dependencies...
XCOPY %source1% %target1% /Y
XCOPY %source2% %target2% /Y
XCOPY %source3% %target3% /Y
XCOPY "%frameworktools%ConfigCrypter\ConfigCrypter.exe" "%sourcetools%ConfigCrypter.exe" /Y
XCOPY "%frameworktools%ConfigEditor\ConfigEditor.exe" "%sourcetools%ConfigurationEditor.exe" /Y
XCOPY "%historiantools%HistorianPlaybackUtility\HistorianPlaybackUtility.exe" "%sourcetools%HistorianPlaybackUtility.exe" /Y

:: ECHO.
:: ECHO Building solution...
:: %vs% %solution% /Build "Release|Any CPU"

IF /I "%checkin%" == "Y" GOTO Checkin
GOTO Finalize

:Checkin
ECHO.
ECHO Checking in dependencies...
%tfs% checkin %target1% /noprompt /recursive /comment:"Synchrophasor: Updated code library dependencies."
%tfs% checkin %target2% /noprompt /recursive /comment:"Synchrophasor: Updated time-series framework dependencies."
%tfs% checkin "%sourcetools%ConfigCrypter.exe" /noprompt /comment:"Synchrophasor: Updated code library tool: ConfigCrypter."
%tfs% checkin "%sourcetools%ConfigurationEditor.exe" /noprompt /comment:"Synchrophasor: Updated code library tools: ConfigurationEditor."
%tfs% checkin "%sourcetools%HistorianPlaybackUtility.exe" /noprompt /comment:"Synchrophasor: Updated openHistorian tool: HistorianPlaybackUtility."

:Finalize
ECHO.
ECHO Update complete