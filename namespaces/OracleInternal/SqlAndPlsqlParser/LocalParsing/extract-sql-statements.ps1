

param (
   $whence
)

# add-type -literalPath ~\ODAC\managed\23.8.0\lib\netstandard2.1\Oracle.ManagedDataAccess.dll

$parser = new-object OracleInternal.SqlAndPlsqlParser.OracleLpParser 0

$src = get-stringValueOrFileContent $whence

$stmts =  $stmts = $parser.ParseStatements($null, $src)

return $stmts.text.fragment
