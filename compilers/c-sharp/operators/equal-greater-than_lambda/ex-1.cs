/*

   C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe ex-1.cs

*/
using System;

class Prg {

   private int x;
   public Prg(int x_) { x = x_; }

   public string subtract(int i) => (x-i).ToString();

// public int Mult(int i) => {
//   var bla = i * 2;
//   return i * x;
// }

   static void Main () {

//    delegate a = ( x ) => { x*2; }

      Prg p_1000 = new Prg(1000);
      Prg p_9999 = new Prg(9999);

      Console.WriteLine(p_1000.subtract( 200));
      Console.WriteLine(p_9999.subtract(3333));
//    Console.WriteLine(p_1000.Mult    (3));

   }
}
