#
#  Found at https://chocolatey.org/install.ps1
#

$params = "x -o`"$tempDir`" -bd -y `"$file`""

# use more robust Process as compared to Start-Process -Wait (which doesn't
# wait for the process to finish in PowerShell v3)
$process = New-Object System.Diagnostics.Process
$process.StartInfo = New-Object System.Diagnostics.ProcessStartInfo($7zaExe, $params)
$process.StartInfo.RedirectStandardOutput = $true
$process.StartInfo.UseShellExecute = $false
$process.StartInfo.WindowStyle = [System.Diagnostics.ProcessWindowStyle]::Hidden
$process.Start() | Out-Null
$process.BeginOutputReadLine()
$process.WaitForExit()
$exitCode = $process.ExitCode
$process.Dispose()
