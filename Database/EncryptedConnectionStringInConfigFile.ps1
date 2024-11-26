# Define the paths
$appPath = "C:\Work\Sziltech\LiveView"
$connectionStringsFilePath = "$appPath\Database\ConnectionStrings.xml"
$configFilePath = "$appPath\LiveView"
$webConfigFilePath = "$configFilePath\web.config"
$appConfigPath = "$configFilePath\App.config"

# Read the content from the ConnectionStrings file (assuming the content is a full web.config file)
$webConfigContent = Get-Content -Path $connectionStringsFilePath -Raw

# Write the content to the web.config
Set-Content -Path $webConfigFilePath -Value $webConfigContent

# Read the newly updated web.config content as XML
[xml]$webConfig = Get-Content -Path $webConfigFilePath

# Find the connectionStrings section and encrypt it
$connectionStringsSection = $webConfig.configuration.SelectSingleNode("//connectionStrings")
if ($connectionStringsSection) {
    # Encrypt the connectionStrings section using aspnet_regiis
    $aspnetRegiisPath = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe"
    $encryptionCmd = "& `"$aspnetRegiisPath`" -pef `"connectionStrings`" `"$configFilePath`" -prov DataProtectionConfigurationProvider"
    Invoke-Expression $encryptionCmd

    # Reload the web.config to capture the encrypted section
    [xml]$webConfig = Get-Content -Path $webConfigFilePath
} else {
    Write-Host "No connectionStrings section found in the web.config"
    exit
}

# Load the app.config file as XML
[xml]$appConfig = Get-Content -Path $appConfigPath

# Ensure we correctly access the configuration node
$configurationNode = $appConfig.SelectSingleNode("/configuration")
if (-not $configurationNode) {
    Write-Host "Error: Unable to locate the configuration node in the app.config"
    exit
}

# Find and remove the old connectionStrings section from the app.config
$oldConnectionStringsSection = $configurationNode.SelectSingleNode("//connectionStrings")
if ($oldConnectionStringsSection) {
    $configurationNode.RemoveChild($oldConnectionStringsSection)
}

# Get the encrypted connectionStrings section from the web.config
$encryptedConnectionStringsSection = $webConfig.configuration.SelectSingleNode("//connectionStrings")
if ($encryptedConnectionStringsSection) {
    # Import the encrypted connectionStrings section into app.config
    $newConnectionStringsSection = $appConfig.CreateElement("connectionStrings")
    $newConnectionStringsSection.InnerXml = $encryptedConnectionStringsSection.InnerXml

    # Add the configProtectionProvider attribute
    $newConnectionStringsSection.SetAttribute("configProtectionProvider", "DataProtectionConfigurationProvider")

    # Append the new section to the configuration
    $configurationNode.AppendChild($newConnectionStringsSection)

    # Save the modified app.config file
    $appConfig.Save($appConfigPath)
    Write-Host "Connection strings have been updated and encrypted successfully in app.config with protection provider."
} else {
    Write-Host "No connectionStrings section found in the web.config"
}