public class C {

   private delegate int tq84_delegate(string s, float f);

   static void Main(string[] args) {
      System.Type t = typeof(tq84_delegate);
      System.Console.WriteLine("Assembly: " + t.Assembly  );
      System.Console.WriteLine("ToString: " + t.ToString());
      System.Console.WriteLine("BaseType: " + t.BaseType  );  // System.MulticastDelegate
   }
}
