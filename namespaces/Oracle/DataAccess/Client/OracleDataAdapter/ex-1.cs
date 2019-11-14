//
//   set ORACLE_HOME=c:\oracle\18c
//   csc -debug -reference:%oracle_home%\ODP.NET\bin\4\Oracle.DataAccess.dll ex-1.cs
//
//
//    https://docs.oracle.com/cd/B28359_01/win.111/b28375/OracleDataAdapterClass.htm
//
using System;
using System.Data;
using Oracle.DataAccess.Client;
 

class OracleDataAdapterSample {

  static void Main() {

    string constr = "User Id=rene;Password=rene;Data Source=ORA18";
    string cmdstr = "SELECT * from tq84_p";
 
     // Create the adapter with the selectCommand txt and the
     // connection string
     OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, constr);
  
     // Create the builder for the adapter to automatically generate
     // the Command when needed
     OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
 
    // Create and fill the DataSet using the EMP
    DataSet dataset = new DataSet();
    adapter.Fill(dataset, "TQ84_P");
 
    // Get the EMP table from the dataset
    DataTable table = dataset.Tables["TQ84_P"];
 
    // Indicate DataColumn EMPNO is unique
    // This is required by the OracleCommandBuilder to update the EMP table
    table.Columns["VAL_ONE"].Unique = true;
 
    // Get the first row from the EMP table
    DataRow row = table.Rows[0];
 
    // Update the salary
    double val_two = double.Parse(row["VAL_TWO"].ToString());
    row["VAL_TWO"] = val_two * 2;
 
    // Now update the EMP using the adapter
    // The OracleCommandBuilder will create the UpdateCommand for the
    // adapter to update the EMP table
    adapter.Update(dataset, "TQ84_P");
 
    Console.WriteLine("Row updated successfully");
  }
}
