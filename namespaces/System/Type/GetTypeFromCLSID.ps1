  $guid = '{3DBFEF35-6F15-4453-BC19-D7AD5CC04756}'
# $guid = '{fafa4e17-1ee2-4905-a10e-fe7c18bf5554}' # https://stackoverflow.com/a/25576950

[type] $typ = [Type]::GetTypeFromCLSID($guid)

$obj  = [Activator]::CreateInstance($typ)

$obj.GetType()
