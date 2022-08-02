# 
#  github\temp\dotNet\namespaces\System\Data\OleDb\OleDbConnection\GetSchema
#
#  ./do.ps1 "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$pwd\..\..\data.xlsx; Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';"

#
#  ./do.ps1 "Provider=Microsoft.JET.OLEDB.4.0;Data Source=$psScriptRoot\..\..\data.xlsx; Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';"
#

param (
   [string] $connectionString
)

set-strictMode -version latest

$conn = new-object System.Data.OleDb.OleDbConnection $connectionString
$conn.Open()

[System.Data.DataTable] $schema = $conn.GetSchema()

write-host "Columns"
[System.Data.DataColumnCollection] $cols = $schema.Columns
foreach ($col in $cols) {
   write-host "  $($col.ColumnName)"
 # CollectionName
 # NumberOfRestrictions
 # NumberOfIdentifierParts
}

write-host "CollectionNames"
foreach ($row in $schema.Rows) {
   $collName  = $row['CollectionName']
   write-host "  $collName"
#  $collection = $conn.GetSchema($collName)
#  $collection
}

[System.Data.DataTable] $tables = $conn.GetSchema("Tables")
$tables.Rows
