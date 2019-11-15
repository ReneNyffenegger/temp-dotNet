using System;

class Cls {
   public int    num;
   public string txt;
}

class Prg {

   static void Main() {
  
      Cls obj = new Cls() { num = 42, txt = "Hello World" };

      Console.WriteLine("num = {0}, txt = {1}", obj.num, obj.txt);

   }

}
