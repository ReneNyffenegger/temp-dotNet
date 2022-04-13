//
//    csc writeBlobToFile.cs
//
//    Comapre
//        C:\Users\Rene\github\.NET-API\MySql\Data\MySqlClient\writeBlobToFile.cs
//

using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;

class Prg {

   static void Main() {
      SqlConnection conn = new SqlConnection("Database=tq84_db;Server=.;trusted_connection=true");
      conn.Open();

      SqlCommand      sql = new SqlCommand("select filename, image from tableWithBlob", conn);
      sql.CommandType     = CommandType.Text;
      SqlDataReader   rdr = sql.ExecuteReader();

      while (rdr.Read()) {
         String     filename = rdr.GetString    (0);

         int   blobLen  = (int) rdr.GetBytes(1, 0, null, 0, 0);
         Byte[] bytes   = new Byte[blobLen];
         rdr.GetBytes(1, 0, bytes, 0, blobLen);

         Console.WriteLine($"{filename}: {blobLen} bytes");
         File.WriteAllBytes(filename, bytes);
      }
   }
}
