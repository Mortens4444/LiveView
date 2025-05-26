@echo off
setlocal enabledelayedexpansion

set "TargetDir=C:\NuGetTest"

pushd Database
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd LiveView.Core
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd Mtf.Controls.Sunell.IPR66
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd Mtf.Controls.Sunell.IPR67
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd CameraForms
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd CameraApp
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd Sequence
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd LiveView.Agent
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd Mtf.Web
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd LiveView.WebApi
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd UpgradeCodeGenerator
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd Watchdog
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd

pushd LiveView
for /R %%P in (*.csproj) do (
    echo Checking: %%~nxP
    pushd %%~dpP
    FOR /F "tokens=1,2,*" %%A IN ('dotnet list package --outdated --source "%TargetDir%"') DO (
        IF "%%A"==">" (
            set "PackageName=%%B"
            echo   Updating: !PackageName! in %%~nxP
            dotnet add package !PackageName! -s "%TargetDir%"
            IF ERRORLEVEL 1 (
                echo     Error: !PackageName! update failed.
            ) ELSE (
                echo     OK: !PackageName! update success.
            )
            echo.
        )
    )
    popd
)
popd