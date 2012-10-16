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

SET vs="%VS110COMNTOOLS%\..\IDE\devenv.com"
SET tfs="%VS110COMNTOOLS%\..\IDE\tf.exe"
SET source1="\\GPAWEB\NightlyBuilds\GridSolutionsFramework\Beta\Libraries\*.*"
SET target1="..\..\Source\Dependencies\GSF"
SET solution="..\..\Source\Synchrophasor.sln"
SET sourcetools=..\..\Source\Applications\openPDC\openPDCSetup\
SET frameworktools=\\GPAWEB\NightlyBuilds\GridSolutionsFramework\Beta\Tools\
SET /p checkin=Check-in updates (Y or N)? 

ECHO.
ECHO Getting latest version...
%tfs% get %target1% /version:T /force /recursive /noprompt
%tfs% get "%sourcetools%ConfigCrypter.exe" /force /recursive /noprompt
%tfs% get "%sourcetools%ConfigurationEditor.exe" /force /recursive /noprompt
%tfs% get "%sourcetools%DataMigrationUtility.exe" /force /recursive /noprompt
%tfs% get "%sourcetools%HistorianPlaybackUtility.exe" /force /recursive /noprompt
%tfs% get "%sourcetools%HistorianView.exe" /force /recursive /noprompt

ECHO.
ECHO Checking out dependencies...
%tfs% checkout %target1% /recursive /noprompt
%tfs% checkout "%sourcetools%ConfigCrypter.exe" /noprompt
%tfs% checkout "%sourcetools%ConfigurationEditor.exe" /noprompt
%tfs% checkout "%sourcetools%DataMigrationUtility.exe" /noprompt
%tfs% checkout "%sourcetools%HistorianPlaybackUtility.exe" /noprompt
%tfs% checkout "%sourcetools%HistorianView.exe" /noprompt

ECHO.
ECHO Updating dependencies...
XCOPY %source1% %target1% /Y /U
XCOPY "%frameworktools%ConfigCrypter\ConfigCrypter.exe" "%sourcetools%ConfigCrypter.exe" /Y
XCOPY "%frameworktools%ConfigEditor\ConfigEditor.exe" "%sourcetools%ConfigurationEditor.exe" /Y
XCOPY "%frameworktools%DataMigrationUtility\DataMigrationUtility.exe" "%sourcetools%DataMigrationUtility.exe" /Y
XCOPY "%frameworktools%HistorianPlaybackUtility\HistorianPlaybackUtility.exe" "%sourcetools%HistorianPlaybackUtility.exe" /Y
XCOPY "%frameworktools%HistorianView\HistorianView.exe" "%sourcetools%HistorianView.exe" /Y

:: ECHO.
:: ECHO Building solution...
:: %vs% %solution% /Build "Release|Any CPU"

IF /I "%checkin%" == "Y" GOTO Checkin
GOTO Finalize

:Checkin
ECHO.
ECHO Checking in dependencies...
%tfs% checkin %target1% /noprompt /recursive /comment:"Synchrophasor-VS2012: Updated grid solutions framework dependencies."
%tfs% checkin "%sourcetools%ConfigCrypter.exe" /noprompt /comment:"Synchrophasor-VS2012: Updated grid solutions framework tool: ConfigCrypter."
%tfs% checkin "%sourcetools%ConfigurationEditor.exe" /noprompt /comment:"Synchrophasor-VS2012: Updated grid solutions framework tool: ConfigurationEditor."
%tfs% checkin "%sourcetools%DataMigrationUtility.exe" /noprompt /comment:"Synchrophasor-VS2012: Updated grid solutions framework tool: DataMigrationUtility."
%tfs% checkin "%sourcetools%HistorianPlaybackUtility.exe" /noprompt /comment:"Synchrophasor-VS2012: Updated openHistorian playback / export tool: HistorianPlaybackUtility."
%tfs% checkin "%sourcetools%HistorianView.exe" /noprompt /comment:"Synchrophasor-VS2012: Updated openHistorian trending tool: HistorianView."

:Finalize
ECHO.
ECHO Update complete