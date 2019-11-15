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

       string[] connectionStrings = new string[] {
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Extended Properties='Excel 12.0 Xml;HDR=Yes'",
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Extended Properties='Excel 12.0 Xml'"        ,
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;",                             //                        !! Unrecognized database format 'C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx'
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Excel 12.0 Xml",
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Excel 12.0 Xml;HDR=Yes",
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx",               //                        !! Does not work!
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;HDR=Yes",       //                        !! Does not work!
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Excel 12.0 Xml;HDR=Yes",       //                           OK
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;HDR=Yes;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx",       //                           OK
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Excel 12.0 Xml"        ,       //                        !! Format of the initialization string does not conform to specification starting at index 121.
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;HDR=Yes;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;foobarbaz=1",
                             @"Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Extended Properties='Excel 12.0 Xml;HDR=Yes'",

       };


//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Extended Properties='Excel 12.0 Xml;HDR=Yes'";
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Extended Properties='Excel 12.0 Xml;HDR=Yes'";
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;";                             //                        !! Unrecognized database format 'C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx'
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Excel 12.0 Xml";
// .    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Excel 12.0 Xml;HDR=Yes";
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx";               //                        !! Does not work!
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;HDR=Yes";       //                        !! Does not work!
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Excel 12.0 Xml;HDR=Yes";       //                           OK
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;HDR=Yes;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx";       //                           OK
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Excel 12.0 Xml"        ;       //                        !! Format of the initialization string does not conform to specification starting at index 121.
//      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Excel 12.0 Xml;HDR=Yes;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;foobarbaz=1";
//      string connectionString =          @"Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OMIS.Rene\github\temp\dotNet\namespaces\System\Data\OleDb\db.xlsx;Extended Properties='Excel 12.0 Xml;HDR=Yes'";

        foreach (string connectionString in connectionStrings) {
           Console.WriteLine(connectionString);

        // Provide the query string with a parameter placeholder.
        string queryString =
            "SELECT id, num, txt from [tq84_ex$] "
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
}
