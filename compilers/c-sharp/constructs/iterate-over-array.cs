using System;
using System.Collections.Generic;

class Prg {

   static void Main() {

      string[] ary = new string[]{"foo", "bar", "baz"};

      foreach (string elem in ary) {
         Console.WriteLine(elem);
      }
      foreach (string elem in new List<string>(ary)) {
         Console.WriteLine(elem);
      }

   }

}
