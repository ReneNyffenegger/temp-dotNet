using System;
using System.Reflection;

//
// Prevent warning CS8632:
//   The annotation for nullable reference types should only
//   be used in code within a '#nullable' annotations context.
// 
#nullable enable

class Prg {

   public static void Main() { // Needs to be public for reflection!

      Int32   num   =    42;
      Int32?  num_  =  null;

//    String  str   = "hello world";
//    String? str_                 ;

//             Int32   num         ;
//    Nullable<Int32>  num_  =  null        ;

//    Nullable<String> str_                 ;

//    Nullable<Int32> num__ = 3;

//str = null;
  Console.WriteLine("toString: {0}", num_.ToString());
      

      Console.WriteLine(
         String.Format("  num: {0}, num_: {1}<",
                          num     , num_
         ));

      Type       prg = typeof(Prg);

      foreach (var m in prg.GetMethods()) {
         Console.WriteLine($"m = {m.ToString()}");
      }

      MethodInfo met = prg.GetMethod("Main");
      MethodBody bod = met.GetMethodBody();
      dynamic    vai = bod.LocalVariables;

      Console.WriteLine($"vai.Count = {vai.Count}");
      foreach (var v in vai) {
         Console.WriteLine($"v = {v.ToString()}");
      }

      Console.WriteLine("  type of num:  {0}", vai[0].LocalType.FullName);
      Console.WriteLine("  type of num_: {0}", vai[1].LocalType.FullName);
//    num_ = 1;
//    Console.WriteLine("  type of num_: {0}", Nullable.GetType(num_).FullName);
//    Console.WriteLine("  type of num__: {0}", num__.GetType().FullName);

   }
}
