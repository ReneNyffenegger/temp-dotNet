//
//  csc -reference:"c:\Program Files\Microsoft SQL Server\140\SDK\Assemblies\Microsoft.SqlServer.Smo.dll" test.cs
//
public class C {

  static void Main(string[] args) {
  // Connect to the local, default instance of SQL Server.   

     Microsoft.SqlServer.Management.Smo.Server srv = new 
     Microsoft.SqlServer.Management.Smo.Server     ();

  // The connection is established when a property is requested.   
     System.Console.WriteLine(srv.Information.Version);   
  }   
}
