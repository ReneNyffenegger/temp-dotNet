#
#  https://gist.github.com/SQLDBAWithABeard/8ed2e37b122342c93e17c9f7115e6db2
#

[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SqlServer.Management.SqlParser") | Out-Null
$ParseOptions = New-Object Microsoft.SqlServer.Management.SqlParser.Parser.ParseOptions
$ParseOptions.BatchSeparator = 'GO'
# 
# ## No Errors
$Sql = "Select * from sys.sysdatabases"
$Script = [Microsoft.SqlServer.Management.SqlParser.Parser.Parser]::Parse($SQL, $ParseOptions)
$Script.Errors

## Errors

$Sql = "Select Name from sys.sysdatabases Where Name IN ('DBName)"
$Script = [Microsoft.SqlServer.Management.SqlParser.Parser.Parser]::Parse($SQL, $ParseOptions)
$Script.Errors
