[System.Reflection.Assembly]::LoadWithPartialName('Microsoft.VisualBasic')
$value = [Microsoft.VisualBasic.Interaction]::InputBox("Enter a value ")
write-output "You entered $value"
