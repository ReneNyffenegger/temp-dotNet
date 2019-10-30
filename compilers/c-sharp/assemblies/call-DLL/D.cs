//
//  csc -target:library D.cs -reference:E.dll
//
using System;

public class D {
   public static void PrintSomething() {
      Console.WriteLine(E.something);
   }
}
