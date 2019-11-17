//
//    csc Main.cs WordCount.cs
//

using System;
using ExtensionMethods;

class Prg {

   public static void Main() {

      string txt = "foo, bar, baz etc";
      Console.WriteLine($"txt contains {txt.WordCount()} word");

   }

}
