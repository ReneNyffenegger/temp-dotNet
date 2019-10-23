using System;

internal delegate double funcPtr(double a, double b);

internal class funcs {

  public static double add (double a, double b) { return a + b; }
  public static double mult(double a, double b) { return a * b; }
  public static double sub (double a, double b) { return a - b; }
  public static double div (double a, double b) { return a / b; }

}

internal class nTimes {

   private double n_;

   public nTimes(double n) { n_ = n; }

   public double add (double a, double b) { return n_ * (a + b); }
   public double mult(double a, double b) { return n_ * (a * b); }
   public double sub (double a, double b) { return n_ * (a - b); }
   public double div (double a, double b) { return n_ * (a / b); }

}


public class SamplesDelegate  {

   private static void callFunc(funcPtr f) {
      double result = f(42, 5);
      Console.WriteLine(result);
   }

   public static void Main()  {

      funcPtr fAdd  = new funcPtr(funcs.add );
      funcPtr fMult = new funcPtr(funcs.mult);
      funcPtr fDiv  = new funcPtr(funcs.div );
      funcPtr fSub  = new funcPtr(funcs.sub );

      callFunc(fAdd );
      callFunc(fMult);
      callFunc(fDiv );
      callFunc(fSub );

      nTimes nTimes_3 = new nTimes(3);
      nTimes nTimes_5 = new nTimes(5);
      nTimes nTimes_7 = new nTimes(7);
      nTimes nTimes_9 = new nTimes(9);

      funcPtr fAdd_n  = new funcPtr(nTimes_3.add );
      funcPtr fMult_n = new funcPtr(nTimes_5.mult);
      funcPtr fDiv_n  = new funcPtr(nTimes_7.div );
      funcPtr fSub_n  = new funcPtr(nTimes_9.sub );
      
      callFunc(fAdd_n );
      callFunc(fMult_n);
      callFunc(fDiv_n );
      callFunc(fSub_n );
   }

}
