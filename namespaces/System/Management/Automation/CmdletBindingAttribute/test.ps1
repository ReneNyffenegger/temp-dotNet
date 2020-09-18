set-strictMode -version latest

# PROPERTIES
# ConfirmImpact	| Gets and sets a ConfirmImpact value that indicates the "destructiveness" of the operation and when it should be confirmed. This should only be used when SupportsShouldProcess is specified. |  (Inherited from CmdletCommonMetadataAttribute)
# DefaultParameterSetName	| Gets and sets the cmdlet default parameter set| (Inherited from CmdletCommonMetadataAttribute)
# HelpUri	| Gets and sets a HelpUri value that indicates the location of online help. This is used by Get-Help to retrieve help content when -Online is specified | (Inherited from CmdletCommonMetadataAttribute)
# PositionalBinding	| When true, the script will auto-generate appropriate parameter metadata to support positional parameters if the script hasn't already specified multiple parameter sets or specified positions explicitly via the ParameterAttribute.|
# RemotingCapability	| Gets and sets the RemotingBehavior value that declares how this cmdlet should interact with ambient remoting. | (Inherited from CmdletCommonMetadataAttribute)
# SupportsPaging	| Gets and sets a Boolean value that indicates the Cmdlet supports Paging. By default the value is false, meaning the cmdlet doesn't support Paging. | (Inherited from CmdletCommonMetadataAttribute)
# SupportsShouldProcess	| Gets and sets a Boolean value that indicates the Cmdlet supports ShouldProcess. By default the value is false, meaning the cmdlet doesn't support ShouldProcess. |  (Inherited from CmdletCommonMetadataAttribute)
# SupportsTransactions|	Gets and sets a Boolean value that indicates the Cmdlet supports Transactions. By default the value is false, meaning the cmdlet doesn't support Transactions. |  (Inherited from CmdletCommonMetadataAttribute)

function bla {

  [CmdletBinding(
     positionalBinding = $false
   )]
  
     param
     (
        [parameter(HelpMessage="Stores the execution working directory.")]
        [int64         ] $num = 42 ,
        [parameter(HelpMessage="Compare two directories recursively for differences.")]
        [alias    ('c')]
        [string        ] $text = 'Hello world' ,
        [parameter(HelpMessage='Show usage')]
        [alias    ('h')]
        [switch        ] $help
     )

  if ($help) {

     write-host 'bla [-num <long>] [-text <string>] [-help]  [<CommonParameters>]'
     return

  }

  write-host "text = '$text', num = $num"

}

get-help bla

bla -help
bla -h
bla
bla -t   'good bye'
bla -num  99


