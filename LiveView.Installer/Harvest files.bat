@echo off
set heat="C:\Program Files (x86)\WiX Toolset v4.0\bin\heat.exe"

REM set lvFiles=..\LiveView\bin\Release\net9.0-windows
set lvFiles=..\LiveView\bin\Release\net462

%heat% dir "%lvFiles%" -cg LiveViewFiles -dr INSTALLFOLDER -o LiveViewFiles.wxs -srd -gg -sreg -sfrag -var var.LvFilesSource

pause