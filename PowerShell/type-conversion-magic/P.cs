namespace TQ84 {

   public class P {

      private int val;

      public static P Parse(string str) {
         P p = new P();
         switch (str) {
            case "one"  : p.val = 1; break;
            case "two"  : p.val = 2; break;
            case "three": p.val = 3; break;
            case "four" : p.val = 4; break;
            case "five" : p.val = 5; break;
            case "six"  : p.val = 6; break;
            case "seven": p.val = 7; break;
            case "eight": p.val = 8; break;
            case "nine" : p.val = 9; break;
            default     : p.val =-1; break;
         }

         return p;
      }

      public static implicit operator int(P p) {
        return p.val;
      }

   }
}
//
//  csc -nologo -target:library P.cs
//  add-type -path 'P.dll'
//  $p = [TQ84.P] "five"
//  3 * $p
