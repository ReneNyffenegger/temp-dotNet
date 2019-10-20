//
//   set ORACLE_HOME=c:\oracle\18c
//   csc                                                              OracleConnection.cs
//   csc -reference:%oracle_home%\ODP.NET\bin\4\Oracle.DataAccess.dll OracleConnection.cs
//   csc -appconfig:OracleConnection.exe.config -reference:%oracle_home%\ODP.NET\bin\4\Oracle.DataAccess.dll OracleConnection.cs
//
//   copy ...\...dll .
//   OracleConnection.exe
//
//
using System;
using System.Data;
using Oracle.DataAccess.Client; 
 
class OracleConnectionSample {

  static void Main() {  

    // Connect
    string constr = "User Id=rene;Password=rene;Data Source=Ora18";
    OracleConnection con = new OracleConnection(constr);
    con.Open();
 
    // Execute a SQL SELECT
    OracleCommand cmd = con.CreateCommand();
    cmd.CommandText = "select * from emp";
    OracleDataReader reader = cmd.ExecuteReader();
 
    // Print all employee numbers
    while (reader.Read()) {
      Console.WriteLine(reader.GetInt32(0));
    }
 
    // Clean up
    reader.Dispose();
    cmd.Dispose();
    con.Dispose();
  }
}
