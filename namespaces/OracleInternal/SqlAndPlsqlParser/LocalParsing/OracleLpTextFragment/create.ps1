# Old version (Omis?)
# add-type -PSPath c:\Oracle\19\ODP.NET\managed\common\Oracle.ManagedDataAccess.dll
#
# Version 1 IGS:
# try { add-type -literalPath C:\Oracle\Client\odp.net\managed\common\Oracle.ManagedDataAccess.dll } catch { out-errorRecord $_ }
  try { add-type -literalPath C:\Oracle\Client\odp.net\managed\common\Oracle.ManagedDataAccess.dll } catch { $_.exception.loaderExceptions }
  # -> Could not load file or assembly 'System.Text.Json, Version=4.0.1.1, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' or one of its dependencies. The system cannot find the file specified.

# Version 2 IGS:
# using assembly "C:\Oracle\Client\odp.net\managed\common\Oracle.ManagedDataAccess.dll"
# using namespace Oracle.ManagedDataAccess.Client

$x = 'select * from dual'

#
# The property 'new' cannot be found on this object. Verify that the property exists.
#
$lpTextFragment = [OracleInternal.SqlAndPlsqlParser.LocalParsing.OracleLpTextFragment]::new($x, 0, $x.Length-1)
