using System;

delegate double funcPtr(int i);


public class L {

   private static double half(int i) { return i/2.0; }

   static void Main() {

   // Using delegate / function Function Pointer
      funcPtr f_d = half;

   // Use func, no delegate needed: 
      Func<int, double> f_F = half;

      Console.WriteLine(f_d(5));
      Console.WriteLine(f_F(7));

  
   // Using lambda notation
      Func<int, int> square = x => x * x;
      Console.WriteLine(square(5));

   }
}
