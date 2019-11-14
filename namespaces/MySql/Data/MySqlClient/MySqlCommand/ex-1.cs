//
//    csc /r:C:\Windows\Microsoft.NET\assembly\GAC_MSIL\MySql.Data\v4.0_8.0.18.0__c5687fc88969c44d\MySql.Data.dll ex-1.cs
//


using MySql.Data.MySqlClient;

class C {

   static void Main() {
   //
   //  Add old guids=true in order to prevent
   //
   //      System.FormatException: Guid should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).
   //
       MySqlConnection myConnection = new MySqlConnection("Database=tq84_db;Data Source=OMIS-NC-08;User Id=rene;Password=rene;old guids=true");
       
       string myInsertQuery = "insert into tab_1 (id, txt) values (42, 'forty-two')";

       MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

       myCommand.Connection = myConnection; // new MySqlConnection("Database=tq84_db;Data Source=localhost;User Id=rene;Password=rene");
//  myConnection;
       myConnection.Open();

       myCommand.ExecuteNonQuery();
       myCommand.Connection.Close();

  }
}
