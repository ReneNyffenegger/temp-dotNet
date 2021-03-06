using System;
using System.Collections.Generic;

class P {

    private static void callBack(String s) {
       Console.WriteLine("Callback: " + s);
    }


    static void Main() {
        List<String> names = new List<String>();
        names.Add("Foo");
        names.Add("Bar");
        names.Add("Baz");


//      names.ForEach(Console.WriteLine);
        names.ForEach(callBack);

     // The following demonstrates the anonymous method feature of C#
     // to display the contents of the list to the console.
        names.ForEach( delegate(String name) {
            Console.WriteLine("Anonymous function: " + name);
        });

     // --------------------------------------------------

     //
     // Use object initializer:
     //
        List<int> numbers = new List<int> {1,1,2,3,5,8};
        foreach (int i in numbers) {
          Console.WriteLine("i = " + i);
        }


    }

//  private static void Print(string s)
//  {
//      Console.WriteLine(s);
//  }
}
