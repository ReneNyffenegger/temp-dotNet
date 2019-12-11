// csc -debug -r:%cd%\Oracle.DataAccess.dll TwoReaders.cs
//
using System;
using System.Data;
using Oracle.DataAccess.Client;

static class Prg {
   static void Main() {

      OracleConnection ora   = new OracleConnection($"user Id=rene;password=rene;data source=Ora18");
      ora.Open();

      OracleCommand  sql;
      sql = new OracleCommand("select    2  n from dual union all select      3  n from dual union all select    1  n from dual", ora); OracleDataReader rdr_1 = sql.ExecuteReader();
      sql = new OracleCommand("select 'two' t from dual union all select 'three' t from dual union all select 'one' t from dual", ora); OracleDataReader rdr_2 = sql.ExecuteReader();

      while (rdr_1.Read()) {
             rdr_2.Read()  ;
  
         Console.WriteLine($"  {rdr_1["n"]}: {rdr_2["t"]}");
      }
   }
}
