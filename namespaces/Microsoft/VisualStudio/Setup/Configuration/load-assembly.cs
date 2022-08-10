// $assembly = 'C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\PrivateAssemblies\Microsoft.VisualStudio.Setup.Configuration.Interop.dll'
// cp $assembly .
// & C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe -reference:"$assembly" load-assembly.cs
// .\load-assembly.exe

using System;

class t {
   static public void Main() {

      Type typ = Type.GetTypeFromCLSID(new Guid("177F0C4A-1CD3-4DE7-A32C-71DBBB9FA36D"));
      Console.WriteLine("typ");

      var config = (Microsoft.VisualStudio.Setup.Configuration.ISetupConfiguration2) Activator.CreateInstance(typ);
      Console.WriteLine("config");

      var instance = config.GetInstanceForCurrentProcess();

      Console.WriteLine("instance");
      
      // There are many other useful members here you might use to inspect the current VS from a 
      // setup/installation point of view.
      var installPath = instance.GetInstallationPath();
      Console.WriteLine("installPath");

   }
}
