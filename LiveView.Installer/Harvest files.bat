@echo off
set heat="C:\Program Files (x86)\WiX Toolset v4.0\bin\heat.exe"

set net9=..\LiveView\bin\Release\net9.0-windows
set net462=..\LiveView\bin\Release\net462

%heat% dir "%net9%" -cg Net9Components -dr INSTALLFOLDER_NET9 -o Net9Components.wxs -gg -sreg -sfrag -var var.Net9Source
%heat% dir "%net462%" -cg Net462Components -dr INSTALLFOLDER_NET462 -o Net462Components.wxs -gg -sreg -sfrag -var var.Net462Source

pause