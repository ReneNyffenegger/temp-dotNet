add-type -path '.\System.Data.SQLite.dll'

$sqlite = new-object -typeName System.Data.SQLite.SQLiteConnection
$sqlite.ConnectionString = "Data Source=""$pwd\test.db"""
$sqlite.Open()

$sql = $sqlite.CreateCommand()
$sql.CommandText = 'select * from tab'

$adapter = New-Object -TypeName System.Data.SQLite.SQLiteDataAdapter $sql
$data = New-Object System.Data.DataSet
$adapter.Fill($data)


$arrExp=@()
foreach ($datarow in $data.Tables.rows) {

   write-host "$($datarow.col_1) $($datarow.col_2) $($datarow.col_3)"

#   $row = New-Object psobject
#   $row | Add-Member -Name URL -MemberType NoteProperty -Value ($datarow.origin_url)
#   $row | Add-Member -Name UserName -MemberType NoteProperty -Value ($datarow.username_value)
#   $row | Add-Member -Name Password -MemberType NoteProperty -Value (([System.Text.Encoding]::UTF8.GetString([System.Security.Cryptography.ProtectedData]::Unprotect($datarow.password_value,$null,[System.Security.Cryptography.DataProtectionScope]::CurrentUser))))
    $arrExp += $row
}

$sql.Dispose()
$SQLite.Close()
