using System;
using Microsoft.Win32;

class Prg {

   public static void Main() {

      try {
         RegistryKey globalEnv = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
         Console.WriteLine("Global path: {0}", globalEnv.GetValue("PATH"));
      }
      catch (UnauthorizedAccessException) {
         Console.WriteLine("Not enough permission to access Environment Key of HKLM");
      }

      RegistryKey userEnv   = Registry.CurrentUser.CreateSubKey(@"Environment");
      Console.WriteLine("User path:   {0}", userEnv  .GetValue("PATH"));

   }
}
