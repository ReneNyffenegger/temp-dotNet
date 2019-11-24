//
// Demonstrates that a collection initializer calls add behind the scenes.
//
// Collection initializers let you specify one or more element initializers
// when you initialize a collection type that implements IEnumerable and has
// Add with the appropriate signature as an instance method or an extension
// method. 
//

using System;
using System.Collections;

class Coll : IEnumerable {

   public Coll() {
      Console.WriteLine("Constructor");
   }

   public void Add(int item) {
      Console.WriteLine($"adding {item}");
   }

   public IEnumerator GetEnumerator() {
   //
   // The method GetEnumerator() is required by IEnumerable.
   //
   // It is not required for this example, therefore, we
   // just return null:
   //
      return null;
   }

}

class Prg {

   static void Main() {
   //
   // X.cs(35,44): error CS1922: Cannot initialize type 'Coll<int>' with a collection initializer because it does not implement 'System.Collections.IEnumerable'
   //
      Coll coll = new Coll {1, 1, 2, 3, 5, 8};
   }
}
