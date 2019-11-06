//
//    https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed
//      The .NET Framework consists of two main components, which are versioned separately:
//        o A set of assemblies, which are collections of types and resources that provide the functionality for your apps. The .NET Framework and assemblies share the same version number.
//        o The common language runtime (CLR), which manages and executes your app's code. The CLR is identified by its own version number
//
using System;
using System.Reflection;

class C {
   public static void Main() {

      var clrVersion    = Environment.Version;
      var dotNetVersion = Assembly.GetAssembly(typeof(Environment)).GetName().Version;
      Console.WriteLine("CLR  Version is " + clrVersion.ToString());
      Console.WriteLine(".NET Version is " + dotNetVersion.ToString());

//    Console.
   }
}
