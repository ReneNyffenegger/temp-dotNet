# $oleDbConn = new-object System.Data.OleDb.OleDbConnection "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$pwd\data.xlsx; Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';"
# $oleDbConn = new-object System.Data.OleDb.OleDbConnection "Provider=OraOLEDB.Oracle;User Id=[DWH_DM_RISKFINANCE];Data Source=DREAMTST1.BN.CH;OSAuthent=1"

  $oleDbConn = new-object System.Data.OleDb.OleDbConnection "Provider=OraOLEDB.Oracle;User Id=rene;Password=rene;Data Source=ORA19"
  $oleDbConn.Open()
