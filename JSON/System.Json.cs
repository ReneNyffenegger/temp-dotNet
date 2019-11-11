//
//    https://stackoverflow.com/a/9573161/180275
//
using System;
using System.Json;


class C {

   static void Main() {

      JsonValue value = JsonValue.Parse(@"{ ""name"":""Prince Charming"", ...");

      JsonObject result = value as JsonObject;
      
      Console.WriteLine("Name .... {0}", (string)result["name"]);
      Console.WriteLine("Artist .. {0}", (string)result["artist"]);
      Console.WriteLine("Genre ... {0}", (string)result["genre"]);
      Console.WriteLine("Album ... {0}", (string)result["album"]);

  }
}
