param(
    [string]$CsprojPath = ".\LiveView.Agent.Maui\LiveView.Agent.Maui.csproj",
    [string]$ManifestPath = ".\LiveView.Agent.Maui\Platforms\Android\AndroidManifest.xml"
)

$solutionDirectory = "C:\Work\Sziltech\LiveView\"
$csprojFullPath = [System.IO.Path]::Combine($solutionDirectory, $CsprojPath)
$manifestFullPath = [System.IO.Path]::Combine($solutionDirectory, $ManifestPath)
$xml = [xml](Get-Content $csprojFullPath)

$fileVersionPropertyGroup = $xml.Project.PropertyGroup | Where-Object { $_.FileVersion }
$appDisplayVersionPropertyGroup = $xml.Project.PropertyGroup | Where-Object { $_.ApplicationDisplayVersion }

if ($fileVersionPropertyGroup -and $appDisplayVersionPropertyGroup)
{
    $buildNumber = $fileVersionPropertyGroup.BuildNumber
    $newBuildNumber = [Convert]::ToInt32($buildNumber) + 1

    # Update version number in csproj
    $fileVersionPropertyGroup.BuildNumber = $newBuildNumber.ToString()
    $xml.Save($csprojFullPath)

    # Update version number in AndroidManifest.xaml
    $manifestXml = [xml](Get-Content $manifestFullPath)
    $manifestXml.manifest.attributes["android:versionCode"].value = $newBuildNumber
    $manifestXml.Save($manifestFullPath)
}
else
{
    Write-Host "Required PropertyGroup elements not found in the XML."
}

$path = "$solutionDirectory\LiveView.Agent.Maui\bin\Release\net9.0-android\publish"

Write-Host "Cleaning...";
Remove-Item -Path "$path\*" -Recurse

Write-Host ".NET Publishing...";
Set-Location $solutionDirectory
$currentDirectory = Get-Location
Write-Host "$currentDirectory"
dotnet publish "$solutionDirectory\LiveView.sln" -c Release -f net9.0-android /p:BundleLocalization=en-GB /p:LocalizationCulture=en-GB

Write-Host "Searching generated APK..."

if (-not (Test-Path -Path $path))
{
    Write-Host "Not found: $path";
	$path = Get-Location
    Write-Host "Changing to: $path";
}

$apkPath = Get-ChildItem -Path "$path\*-Signed.apk" | Select-Object -ExpandProperty FullName

Write-Host "APK generated at: $apkPath"
return $apkPath