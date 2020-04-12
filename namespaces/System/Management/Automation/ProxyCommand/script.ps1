#
# https://devblogs.microsoft.com/powershell/dir-ad/ 
#

$md = new-object System.Management.Automation.CommandMetadata (get-command get-childitem)
$proxyCmd = [System.Management.Automation.ProxyCommand]::Create($md)

$proxyCmd.GetType().FullName
#
#  System.String 
#
