namespace TQ84 {

   public class Obj {

      static void Main(string[] args) {

      //
      // nameof() is evaluated at compile time
      //
         System.Console.WriteLine("args.Length = " + args.Length);

         foreach (string arg in args) {
            System.Console.WriteLine("  arg = " + arg);
         }

      }

   }

}
