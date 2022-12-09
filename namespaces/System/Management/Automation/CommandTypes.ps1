$enumValues = [System.Enum]::GetValues('System.Management.Automation.CommandTypes')

$enumValues.foreach( {
  "$($_.value__)`t$($_.ToString())"
} )
