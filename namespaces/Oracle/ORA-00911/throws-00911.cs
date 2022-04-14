using System;
using Oracle.ManagedDataAccess.Client;

static class ORA_00911 {

   static void execStatement(OracleConnection conn, string stmt) {
   try {

        OracleCommand cmd = (Oracle.ManagedDataAccess.Client.OracleCommand) conn.CreateCommand();
        cmd.CommandText   = stmt;
        cmd.ExecuteNonQuery();
   }
   catch (Exception ex) {
        Console.WriteLine($"Statement {stmt} threw {ex.ToString()}");
   }
   }


   static int Main(string[] args) {

        OracleConnection conn = new Oracle.ManagedDataAccess.Client.OracleConnection("Data Source=ora19;User Id=rene;Password=rene");
        conn.Open();
        System.Data.Common.DbTransaction trx = conn.BeginTransaction();

        execStatement(conn, "insert into ora_00911_test(id, text          ) values (1, 'one'           )");
        execStatement(conn, "insert into ora_00911_test(filename, id, text) values ('xyz.txt', 2, 'two')");

        trx.Commit();
        conn.Dispose();

        return 0;
   }
}
