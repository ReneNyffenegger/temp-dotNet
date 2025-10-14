[PowerShell] $ps1 = [PowerShell]::Create()
[PowerShell] $ps2 = [PowerShell]::Create()

$x = 7
$y = 9
$z = 2

$ps1.AddScript("$pwd\the-script.ps1", $true ).Invoke()
$ps2.AddScript("$pwd\the-script.ps1", $false).Invoke()
