//
//    https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-code-examples
//
//

/*
create table tq84_ex (
   id  int,
   num float,
   txt varchar(10)
);


insert into tq84_ex values ( 10, 10.01, 'ten');
insert into tq84_ex values (  5,  5.5 , 'five');
insert into tq84_ex values (  7,  7.7 , 'seven');
insert into tq84_ex values (  3,  3.3 , 'three');
insert into tq84_ex values (  8,  8.8 , 'eight');
*/

using System;
using System.Data;
using System.Data.OleDb;

class Program {

    static void Main() {

/*

Unhandled Exception: System.ArgumentException: Format of the initialization string does not conform to specification starting at index 32.
   at System.Data.Common.DbConnectionOptions.GetKeyValuePair(String connectionString, Int32 currentPosition, StringBuilder buffer, Boolean useOdbcRules, String& keyname, String& key
value)
   at System.Data.Common.DbConnectionOptions.ParseInternal(Hashtable parsetable, String connectionString, Boolean buildChain, Hashtable synonyms, Boolean firstKey)
   at System.Data.Common.DbConnectionOptions..ctor(String connectionString, Hashtable synonyms, Boolean useOdbcRules)
   at System.Data.OleDb.OleDbConnectionString..ctor(String connectionString, Boolean validate)
   at System.Data.OleDb.OleDbConnectionFactory.CreateConnectionOptions(String connectionString, DbConnectionOptions previous)
   at System.Data.ProviderBase.DbConnectionFactory.GetConnectionPoolGroup(DbConnectionPoolKey key, DbConnectionPoolGroupOptions poolOptions, DbConnectionOptions& userConnectionOptio
ns)
   at System.Data.OleDb.OleDbConnection.ConnectionString_Set(DbConnectionPoolKey key)
   at System.Data.OleDb.OleDbConnection..ctor(String connectionString)
   at Program.Main()


*/

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.accdb";

//
//      Following connect string causes:
//
//          The database you are trying to open requires a newer version of Microsoft Access.
//
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db-new-format-because-of-long-number.accdb.";
//
//      -----------------------------------------------------------------------------------------------------

//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db1.accdb";
        Console.WriteLine(connectionString);

        // Provide the query string with a parameter placeholder.
        string queryString =
            "SELECT id, num, txt from tq84_ex "
                + "WHERE id > @id_p "
                + "ORDER BY num DESC;";

     // Specify the parameter value.
        int paramValue = 5;

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.

        using (OleDbConnection connection = new OleDbConnection(connectionString)) {
         // Create the Command and Parameter objects.
            OleDbCommand command = new OleDbCommand(queryString, connection);
            command.Parameters.AddWithValue("@id_p", paramValue);

            // Open the connection in a try/catch block. 
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                }
                reader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
