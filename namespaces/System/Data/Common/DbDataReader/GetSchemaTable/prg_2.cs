using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

class Prg {


   private static void showSchema(DataTable cols) {
      foreach (DataRow row in cols.Rows) {
            foreach (DataColumn column in cols.Columns) {
                Console.WriteLine(String.Format("{0} = {1} ({2})",
                   column.ColumnName, row[column], row[column].GetType().FullName));
            }
            Console.WriteLine("---");
      }

   }

   static void Main () {

      string csvFilePath = Directory.GetCurrentDirectory();

      string provider =
         // "Microsoft.Jet.OLEDB.4.0"
            "Microsoft.ACE.OLEDB.12.0";

      string connectionString           =
          $"Provider={provider};"       + 
          $"Data Source={csvFilePath};" +
          $"Extended Properties='text';";

      using OleDbConnection connection = new OleDbConnection(connectionString);
      connection.Open();

      DbCommand command = new OleDbCommand("select * from tab_1.csv", connection);
//
//       Of course, the constructor returns an OleDbCommand object. Thus, the
//       following line would probably be more correct. But because this
//       program serves at demonstrating the basic functionality of ExecuteReader() and
//       Read(), I have not done so.
//
//    OleDbCommand command = new OleDbCommand("select id, num, txt from data.csv", connection);


      DbDataReader reader = command.ExecuteReader();
      DataTable    cols   = reader.GetSchemaTable();

//    DataTableReader schemeaReader = new DataTableReader(cols);


      String colFormat = "  {0,-10} | {1,-15} | {2,4} {3,3} {4,3} ";

      Console.WriteLine(String.Format(colFormat,
        "Col name",
        "Type"    ,
        "Size"    ,
        "Prc"     ,
        "Scl"
      ));

   //
   // Column information is stored in rows…
   //
      foreach (DataRow colInfo in cols.Rows) {

         String       colName      = (String)      colInfo["ColumnName"      ];
//       RuntimeType  dataType     = (RuntimeType) colInfo["DataType"        ];
         TypeInfo     dataType     = (TypeInfo   ) colInfo["DataType"        ];
         Int32        colSize      = (Int32)       colInfo["ColumnSize"      ];
         Int16        numPrecision = (Int16)       colInfo["NumericPrecision"];
         Int16        numScale     = (Int16)       colInfo["NumericScale"    ];

         Console.WriteLine(String.Format(colFormat,
             colName,
             dataType.ToString(),
             colSize,
             numPrecision,
             numScale
         ));

      }

//    showSchema(cols);

//q   DataTableReader dtReader = cols.CreateDataReader();
//q   showSchema(dtReader.GetSchemaTable());

//
//       With an OleDbCommand, the ExecuteReader method returns
//       a DbDataReader object:
//
//    OleDbDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
         Console.WriteLine(
//          String.Format(" {0,2} | {1,5:F1} | {2}",
            String.Format(" {0,2} | {1,2} | {2,5:F2} | {3,-5} | {4}",
                                         reader.GetInt32   (0),
                                         reader.GetInt32   (1),
                                         reader.GetDouble  (2),
                                         reader.GetString  (3),
                                         reader.GetDateTime(4)
//             reader.IsDBNull(0) ? '' : reader.GetInt32   (0),
//             reader.IsDBNull(1) ? '' : reader.GetInt32   (1),
//             reader.IsDBNull(2) ? '' : reader.GetDouble  (2),
//             reader.IsDBNull(3) ? '' : reader.GetString  (3),
//             reader.IsDBNull(4) ? '' : reader.GetDateTime(4)
//             --
//             reader.IsDBNull(0) ? "-" : reader.GetInt32   (0).ToString(),
//             reader.IsDBNull(1) ? "-" : reader.GetInt32   (1).ToString(),
//             reader.IsDBNull(2) ? "-" : reader.GetDouble  (2).ToString(),
//             reader.IsDBNull(3) ? "-" : reader.GetString  (3).ToString(),
//             reader.IsDBNull(4) ? "-" : reader.GetDateTime(4).ToString()
//             --
//             reader.IsDBNull(0) ? "-" : reader.GetString(0),
//             reader.IsDBNull(1) ? "-" : reader.GetString(1),
//             reader.IsDBNull(2) ? "-" : reader.GetString(2),
//             reader.IsDBNull(3) ? "-" : reader.GetString(3),
//             reader.IsDBNull(4) ? "-" : reader.GetString(4)
         ));
      }
   }
}
