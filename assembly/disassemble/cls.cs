//
//  csc -target:library cls.cs -out
//

using System;
using System.Runtime.InteropServices;

namespace nsDll {
   public class cls {

      private String txt;

      public cls(string t) {
         txt = t;
      }

   [DllImport("User32.dll", EntryPoint = "MessageBox" /*, CharSet = CharSet.Auto */ )]
    internal static extern int msgBox(
        IntPtr hWnd,
        string lpText,
        string lpCaption,
        uint   uType
     );

      public void msg() {
         msgBox(IntPtr.Zero, txt, "msgBox", 0);
      }
   }
}
