$assembly = [Reflection.Assembly]::LoadFrom("C:\Oracle\Client\odp.net\managed\common\Oracle.ManagedDataAccess.dll");

$assembly.GetTypes()

$assembly.GetTypes() | ForEach-Object {
    Write-Output "Type: $($_.FullName)"
    $_ | Get-Member -MemberType Method, Property
}
