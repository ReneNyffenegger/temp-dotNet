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
using System.Data.SqlClient;

class Program {

    static void Main() {
        string connectionString =
            "Data Source=(local);Initial Catalog=tq84_db;"
            + "Integrated Security=true";

        // Provide the query string with a parameter placeholder.
        string queryString =
            "SELECT id, num, txt from dbo.tq84_ex "
                + "WHERE id > @id_p "
                + "ORDER BY num DESC;";

     // Specify the parameter value.
        int paramValue = 5;

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.

        using (SqlConnection connection = new SqlConnection(connectionString)) {
         // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id_p", paramValue);

            // Open the connection in a try/catch block. 
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                }
                Console.WriteLine("Going to close reader");
                reader.Close();
                Console.WriteLine("reader closed");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
