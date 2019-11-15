using System;
using System.Data;
using System.Data.OracleClient;

class C {
    static void Main() {

//  public void ReadData(string connectionString) {

       string queryString = "SELECT id, num, txt from tq84_ex";
       using (OracleConnection connection = new OracleConnection("Data Source=ORA18;user id=rene;password=rene")) {

          OracleCommand command = new OracleCommand(queryString, connection);
          connection.Open();
          using(OracleDataReader reader = command.ExecuteReader()) {
        // Always call Read before accessing data.
        	 while (reader.Read()) {
            	Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetDouble(1) + ", " + reader.GetString(2));
        	 }
          }
       }
//  }
    }
}
