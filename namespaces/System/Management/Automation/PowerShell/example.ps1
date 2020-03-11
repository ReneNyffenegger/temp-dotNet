#
# https://stackoverflow.com/a/8668891
#

$ps = [PowerShell]::Create()
$null = $ps.AddScript(@'
    Get-ChildItem $build_path `
        -Include *.bak, *.orig, *.txt, *.chirp.config `
        -Recurse | Remove-Item -Verbose
'@)

$ps.Invoke()
$ps.Streams.Verbose -replace '(.*)Target "(.*)"(.*)','Removing File $2'
