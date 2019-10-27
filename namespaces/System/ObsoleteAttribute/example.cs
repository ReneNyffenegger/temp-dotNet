using System;

public class C {

  [ObsoleteAttribute("Method abc is obsolte, use xyz")]
   public static void abc() { Console.WriteLine("abc"); }

   public static void xyz() { Console.WriteLine("xyz"); }

}

public class M {

    public static void Main() {
       C.abc();
       C.xyz();
    }
}
