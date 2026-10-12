param(
    [Parameter(Mandatory = $true)]
    [string]$Name
)

$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$Name = $Name.Trim()

if ([string]::IsNullOrWhiteSpace($Name)) {
    throw "Bitte einen Projektnamen angeben."
}

$reserved = @(
    ".vscode", "scripts", ".git", ".pio",
    "include", "lib", "src", "test"
)
if ($reserved -contains $Name.ToLowerInvariant()) {
    throw "Der Name '$Name' ist reserviert."
}

if ($Name -match '[<>:"/\\|?*]') {
    throw "Ungueltige Zeichen im Projektnamen: $Name"
}

$Dest = Join-Path $Root $Name
if (Test-Path -LiteralPath $Dest) {
    throw "Ordner existiert bereits: $Dest"
}

$Template = Join-Path $PSScriptRoot "template"
if (-not (Test-Path -LiteralPath $Template)) {
    throw "Vorlage fehlt: $Template"
}

Copy-Item -Path $Template -Destination $Dest -Recurse

Write-Host ""
Write-Host "Projekt angelegt: $Dest"
Write-Host "Sketch:           $Dest\src\main.cpp"
Write-Host ""
Write-Host "Als Naechstes: Terminal -> Run Task -> PlatformIO: Build"
Write-Host "Projektordner: $Name"
Write-Host ""
