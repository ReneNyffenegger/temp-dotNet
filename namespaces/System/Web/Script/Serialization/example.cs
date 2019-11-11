using System;
using System.Web.Script.Serialization;

class C {

    public class Obj {
      public string field1 { get; set; }
      public string field2 { get; set; } 
    }  

   static void Main() {


      Obj myDeserializedObj = (Obj) JavaScriptConverter.Deserialize(@"{ ""field1"":""value1"",""field2"":""value2"" }", typeof(Obj));

      Console.WriteLine("field1: {0}", myDeserializedObj.field1);

   }

}
