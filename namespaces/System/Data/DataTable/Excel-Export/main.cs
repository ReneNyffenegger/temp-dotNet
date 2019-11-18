using System;
using System.Data;  
using System.IO;
using ExcelExport;

class Prg {

   public static void Main() {
      var dataTable = new DataTable();  
      dataTable.TableName = "DC";  
      dataTable.Columns.Add("id");  
      dataTable.Columns.Add("Name");  
      dataTable.Columns.Add("Email");  
  
      var row = dataTable.NewRow();  
      row["id"] = Guid.NewGuid().ToString();  
      row["Name"] = "Bruce Wayne";  
      row["Email"] = "batman@superheroes.com";  
      dataTable.Rows.Add(row);  
  
      row = dataTable.NewRow();  
      row["id"] = Guid.NewGuid().ToString();  
      row["Name"] = "Clark Kent";  
      row["Email"] = "superman@superheroes.com";  
      dataTable.Rows.Add(row);  
  
      row = dataTable.NewRow();  
      row["id"] = Guid.NewGuid().ToString();  
      row["Name"] = "Peter Parker";  
      row["Email"] = "spiderman@superheroes.com";  
      dataTable.Rows.Add(row);  
  
      dataTable.AcceptChanges();  
  
//    dataTable.ExportToExcel(@"c:\temp\exported.xls");  
      dataTable.ExportToExcel($@"{Directory.GetCurrentDirectory()}\exported.xlsx");  

   }

}
