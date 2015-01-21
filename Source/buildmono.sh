#!/bin/sh
#Build openPDC on Mono - to execute, chmod +x buildmono.sh
xbuild /p:Configuration=Mono /p:PreBuildEvent="" /p:PostBuildEvent="" Synchrophasor.sln