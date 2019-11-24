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
using System.Collections.Generic;

class example<T> // : IEnumerable<T>
{
   public void Add(T item) {
      Console.WriteLine($"adding {item}");
   }

//   public IEnumerator<T> GetEnumerator() {
//      return null;
//
//   }
//
//   IEnumerator IEnumerable.GetEnumerator() {
//   // Detour, call previous method:
//      return GetEnumerator();
//   }

}

class Prg {

   static void Main() {
   //
   // X.cs(35,44): error CS1922: Cannot initialize type 'example<int>' with a collection initializer because it does not implement 'System.Collections.IEnumerable'
   //
      example<int> coll = new example<int> {1, 1, 2, 3, 5, 8};
   }
}
