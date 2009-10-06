@ECHO OFF
REM Passing in "false" for argument #1 will cause the build to take place in unattended mode.
C:\WINDOWS\Microsoft.NET\Framework\v3.5\msbuild.exe Synchrophasor.buildproj /p:BuildInteractive=%1 /l:FileLogger,Microsoft.Build.Engine;logfile=Synchrophasor.output
