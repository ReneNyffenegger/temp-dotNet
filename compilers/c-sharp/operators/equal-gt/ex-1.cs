using System;

class Prg {

   private int x;
   public Prg(int x_) { x = x_; }

   public string gnirtSoT(int i) => (x-i).ToString();

   static void Main () {

//    delegate a = ( x ) => { x*2; }

      Prg p_1000 = new Prg(1000);
      Prg p_9999 = new Prg(9999);

      Console.WriteLine(p_1000.gnirtSoT( 200));
      Console.WriteLine(p_9999.gnirtSoT(3333));

   }
}

