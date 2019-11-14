using System;
using System.Data;
using System.Data.Odbc;

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



class Program {
    static void Main() {
        // The connection string assumes that the Access 
        // Northwind.mdb is located in the c:\Data folder.
        //
        string connectionString =
//          "Driver={Microsoft Access Driver (*.mdb)};"
//          + "Dbq=c:\\Data\\Northwind.mdb;Uid=Admin;Pwd=;";
           "DRIVER={MySQL ODBC 8.0 Unicode Driver};" +
//         "dns=TQ84_MySQL";
           "SERVER=localhost;" +
           "DATABASE=tq84_db;" +
           "USER=rene;"        +
           "PASSWORD=rene;"    +
           "OPTION=3;";

        // Provide the query string with a parameter placeholder.
        string queryString =
             "SELECT id, num, txt from tq84_ex " // Note: no dbo. !!!!!
                + "WHERE id > ? "
                + "ORDER BY num DESC;";


        // Specify the parameter value.
        int paramValue = 5;

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (OdbcConnection connection = new OdbcConnection(connectionString)) {
            // Create the Command and Parameter objects.
            OdbcCommand command = new OdbcCommand(queryString, connection);
            command.Parameters.AddWithValue("?", paramValue);                            // No Named Valued in ODBC?

            // Open the connection in a try/catch block. 
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try {
                connection.Open();
                OdbcDataReader reader = command.ExecuteReader();
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
