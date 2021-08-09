[byte[]] $bytes = [System.Text.Encoding]::ASCII.GetBytes('Hello world.')
$byteCollection = [Microsoft.PowerShell.Commands.ByteCollection]::new($bytes)

# $byteCollection = new-object Microsoft.PowerShell.Commands.ByteCollection  -argumentList $bytes
$byteCollection

$byteCollection = new-object Microsoft.PowerShell.Commands.ByteCollection 256, $bytes, "dummy.txt"
$byteCollection

