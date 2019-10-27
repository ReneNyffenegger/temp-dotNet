class C {

   public static void Main() {

//    System.Object o = new {x = 42, y = 13};
      var           o = new {num = 42, text = "Hello world"};
      System.Console.WriteLine(o.GetType().FullName);
      System.Console.WriteLine(o.GetType().BaseType.FullName);
      System.Console.WriteLine(o.ToString());

      System.Console.WriteLine(o.num + " " + o.text);


      System.Reflection.PropertyInfo[] props = o.GetType().GetProperties();

      foreach (System.Reflection.PropertyInfo prop in props) {
         System.Console.WriteLine("{0}: {1} {2} {3}", prop.Name, prop.GetValue(o, null), prop.PropertyType.FullName, prop.CanWrite);
      }

   }
}
