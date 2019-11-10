#
#  https://stackoverflow.com/a/20484505/180275
#
$cmdLetMetaData = new-object System.Management.Automation.CommandMetadata(get-command stop-process)

$cmdLetMetaData.CommandType.FullName
#
#  Microsoft.PowerShell.Commands.StopProcessCommand

$cmdLetMetaData.ConfirmImpact
#
#  Medium

$cmdLetMetaData.DefaultParameterSetName
#
#  Id

$cmdLetMetaData.Parameters
#
#  Key         Value
#  ---         -----
#  Name        System.Management.Automation.ParameterMetadata
#  Id          System.Management.Automation.ParameterMetadata
#  InputObject System.Management.Automation.ParameterMetadata
#  PassThru    System.Management.Automation.ParameterMetadata
#  Force       System.Management.Automation.ParameterMetadata

$cmdLetMetaData.PositionalBinding
#
#  True

$cmdLetMetaData.RemotingCapability
#
#  PowerShell


$cmdLetMetaData.SupportsPaging
#
#  False

$cmdLetMetaData.SupportsShouldProcess
#
#  True

$cmdLetMetaData.SupportsTransactions
#
#  False


# [System.Management.Automation.ProxyCommand]::Create($cmdLetMetaData)

