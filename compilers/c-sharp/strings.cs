using System;

class C {

   static void Main() {

      string txt = "Hello World";

      Console.WriteLine( " He said: \"Hello World\". ");      

   //
   // Verbatim Strings (@"…")
   //
   //    Note: the @ sign can also be used to introduce a verbatim identifer (for (int @for in … ))
   //

      Console.WriteLine(@" He said ""Hello World"". ");      

      Console.WriteLine( " new\n line.");
      Console.WriteLine(@" new
 line.");
//    Console.WriteLine(@" He said \"Hello World\". ");      



      Console.WriteLine( " > P:\\ath\\to\\directory");
      Console.WriteLine(@" > P:\ath\to\directory");

      Console.WriteLine( "He said, \"This is the last \u0063hance\x0021\"");
      Console.WriteLine(@"He said, ""This is the last \u0063hance\x0021""");


   //
   // Interpolated strings ($"…")
   //
      Console.WriteLine($" interpolated> He said: {txt}");

   //
   // Verbatime and interpolated
   //
   //
      Console.WriteLine(@$"@$");

   }

}
