using System;
using System.Collections.Generic;

class Cls {
   public int    num;
   public string txt;

   public void print() {
      Console.WriteLine("num = {0}, txt = {1}", num, txt);
   }
}

class Prg {

   static void Main() {
  
      Cls obj = new Cls() { num = 42, txt = "Hello World" };

//    Console.WriteLine("num = {0}, txt = {1}", obj.num, obj.txt);
      obj.print();

      List<Cls> lst = new List<Cls>() {

         new Cls() { num = 1, txt = "one" },
         new Cls() { num = 2, txt = "two" },

      };

      foreach (Cls elem in lst) {
         elem.print();
      }

   }

}
