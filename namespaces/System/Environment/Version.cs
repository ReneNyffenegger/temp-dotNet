//
//    https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed
//      The .NET Framework consists of two main components, which are versioned separately:
//        o A set of assemblies, which are collections of types and resources that provide the functionality for your apps. The .NET Framework and assemblies share the same version number.
//        o The common language runtime (CLR), which manages and executes your app's code. The CLR is identified by its own version number
//
//
//   dotnet "C:\Program Files\dotnet\sdk\3.0.100\Roslyn\bincore\csc.dll"  ^
//      -reference:"C:\Program Files\dotnet\sdk\3.0.100\Microsoft\Microsoft.NET.Build.Extensions\net461\lib\System.Runtime.dll"    ^
//      -out:Version_core_3.dll ^
//      Version.cs                                                                                                                 
//
//   Compare with output of clrver.exe
//
//   https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed#clr_a:
//      For the .NET Framework 4.5 and later versions, don't use the
//      Environment.Version property to detect the version of the CLR. Instead,
//      query the registry as described in Find .NET Framework versions 4.5 and
//      later with code. (https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed#net_d)
using System;
using System.Reflection;

class C {
   public static void Main() {

      var clrVersion    = Environment.Version;
      var dotNetVersion = Assembly.GetAssembly(typeof(Environment)).GetName().Version;
      Console.WriteLine("CLR  Version is " + clrVersion.ToString());
      Console.WriteLine(".NET Version is " + dotNetVersion.ToString());
      Console.WriteLine($"Version = {Environment.Version}");

//    Console.
   }
}
