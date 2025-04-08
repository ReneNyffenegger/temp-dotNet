# Old version (Omis?)
# add-type -PSPath c:\Oracle\19\ODP.NET\managed\common\Oracle.ManagedDataAccess.dll
#
# Version 1 IGS:
# try { add-type -literalPath C:\Oracle\Client\odp.net\managed\common\Oracle.ManagedDataAccess.dll } catch { out-errorRecord $_ }

# Version 2 IGS:
using assembly "C:\Oracle\Client\odp.net\managed\common\Oracle.ManagedDataAccess.dll"
using namespace Oracle.ManagedDataAccess.Client

$x = 'select * from dual'

#
# The property 'new' cannot be found on this object. Verify that the property exists.
#
$lpTextFragment = [OracleInternal.SqlAndPlsqlParser.LocalParsing.OracleLpTextFragment]::new($x, 0, $x.Length-1)
