// set ORACLE_HOME=c:\oracle\18c
// csc -debug -reference:%oracle_home%\ODP.NET\bin\4\Oracle.DataAccess.dll  createTable-showFieldDefinitions.cs

using System;
using Oracle.DataAccess.Client;

class Prg {

   static void Main() {

      OracleConnection ora = new OracleConnection($"user Id=rene;password=rene;data source=ORA18");
      ora.Open();

      OracleCommand stmt = ora.CreateCommand();
      stmt.CommandText = "begin execute immediate 'drop table DataTypeTest'; exception when others then null; end;";
      stmt.ExecuteNonQuery();

      stmt.CommandText = "create table DataTypeTest (num number(10,3), flt float, rel real)";
      stmt.ExecuteNonQuery();

      stmt.CommandText = "select * from DataTypeTest";
      OracleDataReader res = stmt.ExecuteReader(); 


      for (int fld=0; fld<res.FieldCount; fld++) {
         Console.WriteLine($"{res.GetName(fld)}: {res.GetDataTypeName(fld)} - {res.GetFieldType(fld)} - {Type.GetTypeCode(res.GetFieldType(fld))}");
      }

   }
}
