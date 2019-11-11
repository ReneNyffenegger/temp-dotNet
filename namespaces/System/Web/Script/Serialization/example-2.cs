using System;
using System.Web.Services;
using System.Web.Script.Serialization;

 [System.Web.Script.Services.ScriptService]
class C {

    public class Obj {
      public string field1 { get; set; }
      public string field2 { get; set; } 
    }  

   static void Main() {

       JavascriptSerializer YourSerializer = new JavascriptSerializer();

//    Obj myDeserializedObj = (Obj) JavaScriptConverter.Deserialize(@"{ ""field1"":""value1"",""field2"":""value2"" }", typeof(Obj));

//    Console.WriteLine("field1: {0}", myDeserializedObj.field1);

   }

}
