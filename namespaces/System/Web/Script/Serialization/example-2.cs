using System;
using System.Web.Services;
using System.Web.Script.Serialization;

// [System.Web.Script.Services.ScriptService]
class C {

//  public class Obj {
//    public string field1 { get; set; }
//    public string field2 { get; set; } 
//  }  

   public class Obj {
     public Int32  num   { get; set; }
     public String txt   { get; set; }
     public String[] ary { get; set; }
//   public string field2 { get; set; } 
   }  

   static void Main() {

       String json = @"
        { 
          ""num"":  42,
          ""txt"":""Hello, World"",
          ""ary"":[""zero"", ""one"", ""two""]
        }";


       JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

//     System.Collections.Generic.Dictionary<System.String, System.Object[]> 
//     result =
//    (System.Collections.Generic.Dictionary<System.String, System.Object[]>)
//       jsonSerializer.DeserializeObject(@"
//
       dynamic result = jsonSerializer.DeserializeObject( json );

//     System.Collections.Generic.Dictionary<string, System.Object> result = jsonSerializer.DeserializeObject(@"{ ""field1"":""value1"",""field2"":""value2"" }");

       Console.WriteLine(result.GetType().FullName);
//     Console.WriteLine(result["num"].GetType().FullName);
       Console.WriteLine(result["num"]);
       Console.WriteLine(result["txt"]);
       Console.WriteLine(result["ary"][2]);

       Obj obj = (Obj) jsonSerializer.Deserialize( json, typeof(Obj) );

//     Console.WriteLine(result["num"].GetType().FullName);
       Console.WriteLine(obj.num);
       Console.WriteLine(obj.txt);
       Console.WriteLine(obj.ary[2]);



//    Obj myDeserializedObj = (Obj) JavaScriptConverter.Deserialize(@"{ ""field1"":""value1"",""field2"":""value2"" }", typeof(Obj));

//    Console.WriteLine("field1: {0}", myDeserializedObj.field1);

   }

}
