using System;
using System.Reflection;


public class C {

   public int    foo {get; set;}
   public string bar {get; set;}

   public C(int foo_, string bar_) {
      foo = foo_;
      bar = bar_;
   }

}

public class P {

//q    private static void printPropertyValue(object obj, string propertyName) {
//q 
//q       Type         tp = obj.GetType();
//q //    Console.WriteLine($"tp = {tp.ToString()}");
//q       PropertyInfo pi = tp.GetProperty(propertyName);
//q 
//q       if (pi is null) {
//q          Console.WriteLine($"pi = null for {propertyName}");
//q       }
//q       else {
//q          Console.WriteLine($"Value of {propertyName} is {pi.GetValue(obj)}");
//q       }
//q    }

   public static void Main() {

      PropertyInfo pi_C_foo = typeof(C).GetProperty("foo");
      PropertyInfo pi_C_bar = typeof(C).GetProperty("bar");

      C c1 = new C(42, "Hello World");
      C c2 = new C(99, "Ninety-nine");

      Console.WriteLine($"c1.foo = {pi_C_foo.GetValue(c1)}");
      Console.WriteLine($"c1.bar = {pi_C_bar.GetValue(c1)}");

      Console.WriteLine($"c2.foo = {pi_C_foo.GetValue(c2)}");
      Console.WriteLine($"c2.bar = {pi_C_bar.GetValue(c2)}");

//    printPropertyValue(c1, "foo");
//    printPropertyValue(c1, "bar");
//    printPropertyValue(c1, "baz");

//    printPropertyValue(c2, "foo");
//    printPropertyValue(c2, "bar");

   }

}
