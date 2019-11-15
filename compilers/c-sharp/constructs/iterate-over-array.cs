using System;
class Prg {

   static void Main() {

      string[] ary = new {"foo", "bar", "baz"};

      foreach (string elem in ary) { // error CS0746: Invalid anonymous type member declarator. Anonymous type members must be declared with a member assignment, simple name or member access.
         Console.WriteLine(elem);
      }

   }

}
