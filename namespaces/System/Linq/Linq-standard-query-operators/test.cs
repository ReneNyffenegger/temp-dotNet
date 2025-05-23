//
// Extension methods enable you to "add" methods to existing types without
// creating a new derived type, recompiling, or otherwise modifying the original
// type. Extension methods are a special kind of static method, but they are
// called as if they were instance methods on the extended type. For client code
// written in C#, F# and Visual Basic, there is no apparent difference between
// calling an extension method and the methods that are actually d
//
// The most common extension methods are the LINQ standard query operators that
// add query functionality to the existing System.Collections.IEnumerable and
// System.Collections.Generic.IEnumerable<T> types.
//
// To use the standard query operators, first bring them into scope with a
// using System.Linq directive. Then any type that implements IEnumerable<T>
// appears to have instance methods such as
//   - GroupBy,
//   - OrderBy,
//   - Average,
//   - and so
// on.
//

using System;
using System.Linq;

class Prg {

   static void Main() {

      string[] words  = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
      System.Linq.IOrderedEnumerable<string> sorted =  words.OrderBy(wrd => wrd);

   //
   // OrderBy returns in fact a
   //    System.Linq.OrderedEnumerable<System.String, System.String>
      Console.WriteLine(sorted.GetType().FullName);

      foreach (string word in sorted) {
         Console.WriteLine(word);
      }
   }
}
