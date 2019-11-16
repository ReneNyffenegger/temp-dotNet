using System;

class C {

   static void Main() {

      string txt = "Hello World";

      Console.WriteLine( " He said: \"Hello World\". ");      

   //
   // Verbatim Strings (@"…")
   //

      Console.WriteLine(@" He said ""Hello World"". ");      

      Console.WriteLine( " new\n line.");
      Console.WriteLine(@" new
 line.");
//    Console.WriteLine(@" He said \"Hello World\". ");      

   //
   // Interpolated strings ($"…")
   //
      Console.WriteLine($" interpolated> He said: {txt}");

   }

}
