//
//   set ORACLE_HOME=c:\oracle\18c
//   csc -reference:%oracle_home%\ODP.NET\bin\4\Oracle.DataAccess.dll prog.cs
//
using System;
using Oracle.DataAccess.Client;
namespace NovDec2008 {
  class Program {
    static void Main(string[] args) {
      // create connection string using EZCONNECT format
      // this format specifies the server and the Oracle
      // service name as the datasource
      // using the format: server/oracle service name
      // no tnsnames.ora or sqlnet.ora file is needed
      string constr = "User Id=rene; " +
                           "Password=rene; " +
                           "Data Source=ORA18";
      // create connection object
      OracleConnection con = new OracleConnection(constr);
      // use "try" block to open connection
      // if an error occurs, simply display the message
      // since there is a "catch" block a "using" statement is not used
      try {
        // attempt to open the connection
        con.Open();
        // if no exception was thrown this line will execute
        // display simple success message
        Console.WriteLine("Successfully connected to Oracle!\n");
        // display the connection string (without password)
        Console.WriteLine("Connection String: " + con.ConnectionString);
      }
      catch (OracleException ex) {
        // an OracleException was thrown
        // simply display the message
        Console.WriteLine(ex.Message);
      }
      finally {
        // clean up the connection object
        con.Dispose();
      }
      // prevent the console from closing when running in VS environment
      Console.WriteLine();
      Console.Write("ENTER to continue...");
      Console.ReadLine();
    }
  }
}
