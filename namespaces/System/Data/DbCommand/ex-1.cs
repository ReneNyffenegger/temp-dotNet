using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
// using System.Reflection;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;
//
//   set ORACLE_HOME=c:\oracle\18c
//   csc -debug -reference:%oracle_home%\ODP.NET\bin\4\Oracle.DataAccess.dll -r:C:\Windows\Microsoft.NET\assembly\GAC_MSIL\MySql.Data\v4.0_8.0.18.0__c5687fc88969c44d\MySql.Data.dll ex-1.cs && .\ex-1.exe

class Prg {

   private static void executeCommands(IDbConnection con) {

      con.Open();
  
//    DbCommand cmd  = new DbCommand();
      IDbCommand cmd = con.CreateCommand();
//    cmd.Connection = con as DbConnection;
      cmd.CommandText = @"
         create table tq84_tab (
            id  integer,
            num float,
            txt varchar(10)
         )
      ";

      cmd.ExecuteNonQuery();
   }

   static void Main() {
      IDbConnection con_1   = new OracleConnection(@"User Id=rene;Password=rene;Data Source=ORA18");
      IDbConnection con_2   = new MySqlConnection (@"Database=tq84_db;Data Source=OMIS-NC-08;User Id=rene;Password=rene;old guids=true");
//    IDbConnection con_3   = new OleDbConnection (@"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\DbCommand\excel.xlsx");
      OleDbConnection con_3 = new OleDbConnection (@"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\DbCommand\excel.xlsx");
      OleDbCommand command = new OleDbCommand("create table [foobar$] (col1 integer, col2 integer)", con_3);
      con_3.Open();
      command.ExecuteNonQuery();

//    executeCommands(con_1);
//    executeCommands(con_2);
      executeCommands(con_3);


   }

}
