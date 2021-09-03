namespace nsDll {
   class cls {

      private String txt;

      public cls(t string) {
         txt = t;
      }

    [DllImport("User32.dll", EntryPoint = "MessageBox" /*, CharSet = CharSet.Auto) */]
    internal static extern int msgBox(
        IntPtr hWnd,
        string lpText,
        string lpCaption,
        uint   uType
     );

      public msg() {
         msgBox(0, txt, "msgBox", 0);
      }
   }
}
