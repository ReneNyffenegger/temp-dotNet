//
//    csc  readFileIntoBlob.cs
//
//    compare
//      C:/Users/Rene/github/.NET-API/MySql/Data/MySqlClient/readFileIntoBlob.cs
//

using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

class Prg {

   private static void insertFile(SqlCommand sql, string fileName) {

      string filePath = $@"img\{fileName}";

      FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
      Byte[]     data = new Byte[file.Length];

      file.Read(data, 0, (int)file.Length);

      sql.Parameters["@filename"].Value = fileName;
      sql.Parameters["@image"   ].Value = data;
      sql.ExecuteNonQuery();

   }

   static void Main() {
      SqlConnection conn = new SqlConnection("Database=tq84_db;Server=.;trusted_connection=true");
      conn.Open();

      SqlCommand    sql;

      sql = new SqlCommand("drop table if exists tableWithBlob", conn);
      sql.ExecuteNonQuery();

//    sql = new SqlCommand("create table tableWithBlob(filename varchar(50), image mediumblob    )", conn);
      sql = new SqlCommand("create table tableWithBlob(filename varchar(50), image varbinary(max))", conn);
      sql.ExecuteNonQuery();

      sql = new SqlCommand("insert into tableWithBlob values (@filename, @image)", conn);
//    sql.Parameters.Add("@filename", SqlDbType.String    );
      sql.Parameters.Add("@filename", SqlDbType.Char      );
//    sql.Parameters.Add("@image"   , SqlDbType.MediumBlob);
      sql.Parameters.Add("@image"   , SqlDbType.VarBinary );

      insertFile(sql, "Ball.jpg"       );
      insertFile(sql, "mysql_PNG32.png");
      insertFile(sql, "T-Shirt.jpg"    );

      conn.Close();
   }
}

