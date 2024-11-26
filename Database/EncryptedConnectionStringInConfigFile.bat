@echo off

SET config_file_path="C:\Work\Sziltech\LiveView\LiveView"

REM Encrypt connection string
C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "connectionStrings" "%config_file_path%" -prov DataProtectionConfigurationProvider

REM Encrypt connection string for this machine
REM C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pi "connectionStrings" "%config_file_path%" -prov DataProtectionConfigurationProvider

REM Decrypt connection string
REM C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pdf "connectionStrings" "%config_file_path%"

pause
