using System;
using System.IO;
using System.Net;

class C {

   public static void Main() {

       string url = "https://renenyffenegger.ch";

       HttpWebRequest  req = (HttpWebRequest ) HttpWebRequest.Create(url);
       HttpWebResponse res = (HttpWebResponse) req.GetResponse();
       Console.WriteLine("Status code: {0}", res.StatusCode);

       WebHeaderCollection hed = res.Headers;

       foreach (string H in hed) {
          Console.WriteLine("{0,-20} {1}", H + ':', hed[H]);
       }

       Stream       str = res.GetResponseStream();
       StreamReader rdr = new StreamReader(str);
       string       lin;
       while ((lin = rdr.ReadLine() != null) {
          Console.WriteLine(lin);
       }
   }
}
