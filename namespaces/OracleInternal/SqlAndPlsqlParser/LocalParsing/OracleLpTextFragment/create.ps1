add-type -PSPath c:\Oracle\19\ODP.NET\managed\common\Oracle.ManagedDataAccess.dll

$x = 'select * from dual'

$lpTextFragment = [OracleInternal.SqlAndPlsqlParser.LocalParsing.OracleLpTextFragment]::new($x, 0, $x.Length-1)
