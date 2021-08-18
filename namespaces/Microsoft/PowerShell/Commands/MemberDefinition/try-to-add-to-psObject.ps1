$process = (get-process powershell)[0]

$process_toString = $process | get-member ToString

"type      : $($process_toString.GetType().FullName)"   # Microsoft.PowerShell.Commands.MemberDefinition
"memberType: $($process_toString.memberType)"           # System.Management.Automation.PSMemberTypes MemberType {get;}
"definition: $($process_toString.Definition)"           # string ToString()
"def type  : $($process_toString.Definition.GetType())" # string

# $toString = new-object  Microsoft.PowerShell.Commands.MemberDefinition System.Collections.Hashtable, ToString, Method, 'val 1: $($this.val_1)'
  $toString = new-object  Microsoft.PowerShell.Commands.MemberDefinition System.Collections.Hashtable, ToString, Method, 'string ToString()'

"type      : $($toString.GetType().FullName)"
"memberType: $($toString.memberType)"
"definition: $($toString.Definition)"

$process_toString | get-member * -force
