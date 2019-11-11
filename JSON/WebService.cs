using System;
using System.Net;

class M {

   public static void Main() {
      var client = new WebClient();
      client.Headers.Add("User-Agent", ".NET-WebClient/1.0 TQ84");

      var content = client.DownloadString("https://jsonplaceholder.typicode.com/posts/1");
      Console.WriteLine(content); 
   }
}
