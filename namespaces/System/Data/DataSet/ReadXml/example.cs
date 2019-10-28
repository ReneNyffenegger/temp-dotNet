using System;
using System.Data;
using System.IO;
public class C {

   private static void printProperty(DataSet ds, string propertyName) {
      Console.WriteLine("{0,-20} {1}", propertyName + ':', ds.GetType().GetProperty(propertyName).GetValue(ds));
   }

   public static void Main() {
      
       DataSet ds = new DataSet();
       using (FileStream str= new FileStream("data.xml", FileMode.Open, FileAccess.Read)) {
          ds.ReadXml(str);
       }

       printProperty(ds, "DataSetName");
       printProperty(ds, "HasErrors"  );

       DataTableCollection tabs = ds.Tables;
       foreach (DataTable tab in tabs) {
          Console.WriteLine("table {0}", tab);
       }

       DataTable directionsResponse = tabs["DirectionsResponse"];
       foreach (DataRow row in directionsResponse.Rows) {
          foreach (DataColumn col in directionsResponse.Columns) {
             Console.WriteLine(col);
          }
       }

       Console.WriteLine("Status {0}", directionsResponse.Rows[0]["status"]);

       DataTable route = tabs["route"];
       Console.WriteLine($"route.Rows.Count = {route.Rows.Count}");
       int route_id = (int)route.Rows[0]["route_Id"];
       Console.WriteLine($@"route_id = {route_id}");

//      DataTable leg = pathes.Tables["leg"];
        DataTable leg = tabs["leg"];

 //     if (leg.Rows.Count != 1) {
 //                 error = "none or multiple leg";
 //                 return null;
 //     }

        DataRow legRow = leg.Select($"route_Id = {route_id}")[0];
        int leg_Id = (int)legRow["leg_Id"];
        Console.WriteLine("leg_Id = {0}", leg_Id);

        string start_adress = (string)legRow["start_address"];
        string end_adress   = (string)legRow["end_address"];

        Console.WriteLine($"{start_adress} -> {end_adress}");


     // Table duration
     // DataTable duration     = pathes.Tables["duration"];
        DataTable duration     = tabs["duration"];
        DataRow[] durationRows = duration.Select($"leg_Id = {leg_Id} AND step_Id IS NULL");
 
        if (durationRows.Length != 1) {
            Console.WriteLine("none or multiple duration");
            return;
        }
 
        int durationValue = int.Parse((string)durationRows[0]["value"]);
        Console.WriteLine($"durationValue {durationValue}");

 
//      DataTable distance     = pathes.Tables["distance"];
        DataTable distance     = tabs         ["distance"];
        DataRow[] distanceRows = distance.Select($"leg_Id = {leg_Id} AND step_Id IS NULL");

        if (distanceRows.Length != 1) {
            Console.WriteLine("none or multiple distance");
            return;
        }

        int distanceValue = int.Parse((string)distanceRows[0]["value"]);
        Console.WriteLine($"distanceValue = {distanceValue}");
 
  //     Console.WriteLine("DataSetName",

   }

}
