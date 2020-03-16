#
#  TODO: https://github.com/microsoft/referencesource/blob/master/System.Data.Entity/System/Data/Common/EntitySql/ParseResult.cs
#

$null = [System.Reflection.Assembly]::LoadWithPartialName('Microsoft.SqlServer.Management.SqlParser')

[Microsoft.SqlServer.Management.SqlParser.Parser.ParseResult] $rst = [Microsoft.SqlServer.Management.SqlParser.Parser.Parser]::Parse( { statements.sql });

# $rst.GetType().GetType().BaseType.FullName

#$script.GetType().FullName
# [Microsoft.SqlServer.Management.SqlParser.Parser.ParseResult]::GetProperty("Script", [System.Reflection.BindingFlags]::NonPublic -or [System.Reflection.BindingFlags]::Instance).GetValue($rst);

#[Microsoft.SqlServer.Management.SqlParser.SqlCodeDom.SqlScript]
$script = $rst.GetType().GetProperty("Script", 
#   ( [System.Reflection.BindingFlags]::NonPublic -or [System.Reflection.BindingFlags]::Instance ) -as [System.Reflection.BindingFlags]
      [System.Reflection.BindingFlags]::NonPublic  +  [System.Reflection.BindingFlags]::Instance 
    ).GetValue($rst);

# $script.GetType().FullName

#$script = [Microsoft.SqlServer.Management.SqlParser.Parser.ParseResult]::GetProperty('Script', [System.Reflection.BindingFlags]::NonPublic -or [System.Reflection.BindingFlags]::Instance).GetValue($rst);
# $script = [System.Type]::GetProperty('Script', [System.Reflection.BindingFlags]::NonPublic -or [System.Reflection.BindingFlags]::Instance).GetValue($rst);

# $rst.GetType().FullName

#$rst.script

$script.xml
