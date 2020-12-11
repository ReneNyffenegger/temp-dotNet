#
#   https://blog.iisreset.me/so-you-think-you-can-parse/
#
$ParseErrors = @()

$InputString = 'string,@{key="value1","value2"},"another string"'

$AST = [System.Management.Automation.Language.Parser]::ParseInput($InputString,[ref]$null,[ref]$ParseErrors)

$ParseErrors
