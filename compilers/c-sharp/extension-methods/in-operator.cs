//
// https://stackoverflow.com/a/3165188/180275
//
using System;
using System.Linq;

static class Extensions {

    public static bool In<T>(this T item, params T[] items) {
        if (items == null)
            throw new ArgumentNullException("items");

        return items.Contains(item);
    }

}


class Program {


    static void f(int n) {

       if (n.In(1,2,3,4,5,6,7,8,9,10)) {
          Console.WriteLine($"{n} is in 1..10");
       }
       else {
          Console.WriteLine($"{n} is not in 1..10");
       }

    }

    static void Main() {

        f( 4);
        f(42);

     //
     // Works with strings, too:
     //
        string name = "Bob";
        if (name.In("andy", "joel", "matt")) {
           Console.WriteLine("x");
        }
        else {
           Console.WriteLine("y");
        }
    }
}
