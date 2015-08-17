::*******************************************************************************************************
::  UpdateDependencies.bat - Gbtc
::
::  Copyright © 2013, Grid Protection Alliance.  All Rights Reserved.
::
::  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
::  the NOTICE file distributed with this work for additional information regarding copyright ownership.
::  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
::  not use this file except in compliance with the License. You may obtain a copy of the License at:
::
::      http://www.opensource.org/licenses/eclipse-1.0.php
::
::  Unless agreed to in writing, the subject software distributed under the License is distributed on an
::  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
::  License for the specific language governing permissions and limitations.
::
::  Code Modification History:
::  -----------------------------------------------------------------------------------------------------
::  02/26/2011 - Pinal C. Patel
::       Generated original version of source code.
::  08/26/2013 - J. Ritchie Carroll
::       Updated to roll-down schema files from Grid Solutions Framework.
::
::*******************************************************************************************************

@ECHO OFF

SET vs="%VS110COMNTOOLS%\..\IDE\devenv.com"
SET tfs="%VS110COMNTOOLS%\..\IDE\tf.exe"
SET replace="\\GPAWEB\NightlyBuilds\Tools\ReplaceInFiles\ReplaceInFiles.exe"
SET source1="\\GPAWEB\NightlyBuilds\GridSolutionsFramework\Beta\Libraries\*.*"
SET target1="..\..\Source\Dependencies\GSF"
SET sourceschema=..\..\Source\Dependencies\GSF\Data
SET targetschema=..\..\Source\Data
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
%tfs% get "%sourcetools%StatHistorianReportGenerator.exe" /force /recursive /noprompt
%tfs% get "%sourcetools%NoInetFixUtil.exe" /version:T /force /recursive /noprompt
%tfs% get "%sourcetools%DNP3ConfigGenerator.exe" /version:T /force /recursive /noprompt

ECHO.
ECHO Checking out dependencies...
%tfs% checkout %target1% /recursive /noprompt
%tfs% checkout "%sourcetools%ConfigCrypter.exe" /noprompt
%tfs% checkout "%sourcetools%ConfigurationEditor.exe" /noprompt
%tfs% checkout "%sourcetools%DataMigrationUtility.exe" /noprompt
%tfs% checkout "%sourcetools%HistorianPlaybackUtility.exe" /noprompt
%tfs% checkout "%sourcetools%HistorianView.exe" /noprompt
%tfs% checkout "%sourcetools%StatHistorianReportGenerator.exe" /noprompt
%tfs% checkout "%sourcetools%NoInetFixUtil.exe" /noprompt
%tfs% checkout "%sourcetools%DNP3ConfigGenerator.exe" /noprompt
%tfs% checkout "%targetschema%" /recursive /noprompt

ECHO.
ECHO Updating dependencies...
XCOPY %source1% %target1% /Y /E
XCOPY "%frameworktools%ConfigCrypter\ConfigCrypter.exe" "%sourcetools%ConfigCrypter.exe" /Y
XCOPY "%frameworktools%ConfigEditor\ConfigEditor.exe" "%sourcetools%ConfigurationEditor.exe" /Y
XCOPY "%frameworktools%DataMigrationUtility\DataMigrationUtility.exe" "%sourcetools%DataMigrationUtility.exe" /Y
XCOPY "%frameworktools%HistorianPlaybackUtility\HistorianPlaybackUtility.exe" "%sourcetools%HistorianPlaybackUtility.exe" /Y
XCOPY "%frameworktools%HistorianView\HistorianView.exe" "%sourcetools%HistorianView.exe" /Y
XCOPY "%frameworktools%StatHistorianReportGenerator\StatHistorianReportGenerator.exe" "%sourcetools%StatHistorianReportGenerator.exe" /Y
XCOPY "%frameworktools%NoInetFixUtil\NoInetFixUtil.exe" "%sourcetools%NoInetFixUtil.exe" /Y
XCOPY "%frameworktools%DNP3ConfigGenerator\DNP3ConfigGenerator.exe" "%sourcetools%DNP3ConfigGenerator.exe" /Y

ECHO.
ECHO Updating database schema defintions...
FOR /R "%sourceschema%" %%x IN (*.db) DO DEL "%%x"
FOR /R "%sourceschema%" %%x IN (GSFSchema.*) DO REN "%%x" "openPDC.*"
FOR /R "%sourceschema%" %%x IN (GSFSchema-InitialDataSet.*) DO REN "%%x" "openPDC-InitialDataSet.*"
FOR /R "%sourceschema%" %%x IN (GSFSchema-SampleDataSet.*) DO REN "%%x" "openPDC-SampleDataSet.*"
MOVE /Y "%sourceschema%\*.*" "%targetschema%\"
MOVE /Y "%sourceschema%\MySQL\*.*" "%targetschema%\MySQL\"
MOVE /Y "%sourceschema%\Oracle\*.*" "%targetschema%\Oracle\"
MOVE /Y "%sourceschema%\SQL Server\*.*" "%targetschema%\SQL Server\"
MOVE /Y "%sourceschema%\SQLite\*.*" "%targetschema%\SQLite\"
%replace% /r /v "%targetschema%\*.sql" GSFSchema openPDC
%replace% /r /v "%targetschema%\*.sql" "--*" ""
%replace% /r /v "%targetschema%\*SampleDataSet.sql" TestingAdapters HistorianAdapters
%replace% /r /v "%targetschema%\*SampleDataSet.sql" VirtualOutputAdapter LocalOutputAdapter
%replace% /r /v "%targetschema%\*SampleDataSet.sql" TESTDEVICE SHELBY
%replace% /r /v "%targetschema%\*SampleDataSet.sql" "Test Device" Shelby
%replace% /r /v "%targetschema%\*SampleDataSet.sql" "'TEST'" "'SHEL'"
%replace% /r /v "%targetschema%\*db-update.bat" GSFSchema openPDC
SET cwd=%CD%
CD %targetschema%\SQLite
CALL db-update.bat
CD "%cwd%"

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
%tfs% checkin "%sourcetools%StatHistorianReportGenerator.exe" /noprompt /comment:"Synchrophasor-VS2012: Updated openHistorian trending tool: StatHistorianReportGenerator."
%tfs% checkin "%sourcetools%NoInetFixUtil.exe" /noprompt /comment:"Synchrophasor-VS2012: Updated grid solutions framework tool: NoInetFixUtil."
%tfs% checkin "%sourcetools%DNP3ConfigGenerator.exe" /noprompt /comment:"Synchrophasor-VS2012: Updated grid solutions framework tool: DNP3ConfigGenerator."
%tfs% checkin "%targetschema%" /noprompt /recursive /comment:"Synchrophasor-VS2012: Updated database schema definitions from GSF source."

:Finalize
ECHO.
ECHO Update complete