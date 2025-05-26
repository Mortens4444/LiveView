@echo off

pushd Mtf.Extensions
call "CreatePackage - Mtf.Extensions.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Extensions package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.Windows.Forms.Extensions.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Windows.Forms.Extensions package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd

pushd Mtf.LanguageService
call "CreatePackage - Mtf.LanguageService.Windows.Forms.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.LanguageService.Windows.Forms package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.LanguageService.WPF.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.LanguageService.WPF package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd

pushd Mtf.Database
call "CreatePackage"
if %errorlevel% neq 0 (
    echo Error during Mtf.Database package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd

pushd Mtf.HardwareKey
call "CreatePackage.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.HardwareKey package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd

pushd Mtf.Joystick
call "CreatePackage.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Joystick package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd
pushd Mtf.Permissions
call "CreatePackage.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Permissions package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd

pushd Mtf.Wmi
call "CreatePackage.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Wmi package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd

pushd Mtf.Serial
call "CreatePackage.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Serial package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd

pushd Mtf.Network
call "CreatePackage - Mtf.Network.Interfaces.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Network.Interfaces package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.Network.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Network package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd

pushd Mtf.Controls
call "CreatePackage - Mtf.Controls.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Controls package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.Controls.Video.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Controls.Video package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.Controls.Video.Chromium.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Controls.Video.Chromium package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.Controls.Video.FFmpeg.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Controls.Video.FFmpeg package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.Controls.Video.Legacy.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Controls.Video.Legacy package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.Controls.Video.VLC.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Controls.Video.VLC package creation. Exiting.
    popd
    exit /b %errorlevel%
)

call "CreatePackage - Mtf.Controls.Video.OpenCvSharp.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.Controls.Video.OpenCvSharp package creation. Exiting.
    popd
    exit /b %errorlevel%
)

REM call "CreatePackage - Mtf.Controls.Video.ActiveX.bat"
REM if %errorlevel% neq 0 (
    REM echo Error during Mtf.Controls.Video.ActiveX package creation. Exiting.
    REM popd
    REM exit /b %errorlevel%
REM )
popd

pushd Mtf.MessageBoxes
call "CreatePackage.bat"
if %errorlevel% neq 0 (
    echo Error during Mtf.MessageBoxes package creation. Exiting.
    popd
    exit /b %errorlevel%
)
popd