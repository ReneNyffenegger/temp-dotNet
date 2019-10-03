//
//  https://decoder.cloud/2017/11/02/we-dont-need-powershell-exe/
//
//  Compilation:
//
//     I had to set the reference for System.Managment.Automtion.dl when compiling the source.
//     I found the path to the assembly in Powershell with
//        [psobject].assembly.location
//
//   csc.exe /reference:C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Management.Automation\v4.0_3.0.0.0__31bf3856ad364e35\System.Management.Automation.dll  interpreter.cs
//
//   Following trials did not work:
//
//                                                   csc.exe /reference:system.management.automation.dll  interpreter.cs
//     c:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /reference:system.management.automation.dll  interpreter.cs
//

using System.Collections.ObjectModel; 
using System.Management.Automation; 
using System.Management.Automation.Runspaces; 
using System.IO;
using System;
using System.Text;

namespace PSLess {

 class PSLess {

   static void Main(string[] args) {

//   if(args.Length ==0) Environment.Exit(1);
//   string script=LoadScript(args[0]);

   //
   //  Use @" … " because of new lines
   //    (Error message  error CS1010: Newline in constant )
   //
     string script = @"
       $x = 7
       $y = 6
       write-output ($x*$y)
     ";

     string s=RunScript(script);

     Console.WriteLine(s);
     Console.ReadKey();
   }

//  private static string LoadScript(string filename) { 
//    string buffer ="";
//    try {
//      buffer = File.ReadAllText(filename);
//    }
//    catch (Exception e) { 
//      Console.WriteLine(e.Message);
//      Environment.Exit(2);
//    }
//   return buffer;
//  }

 private static string RunScript(string script) { 

    Runspace MyRunspace = RunspaceFactory.CreateRunspace();
    MyRunspace.Open();
    Pipeline MyPipeline = MyRunspace.CreatePipeline(); 
    MyPipeline.Commands.AddScript(script);
    MyPipeline.Commands.Add("Out-String");
    Collection<PSObject> outputs = MyPipeline.Invoke();
    MyRunspace.Close();
    StringBuilder sb = new StringBuilder(); 

   foreach (PSObject pobject in outputs) { 
       sb.AppendLine(pobject.ToString()); 
   }
   return sb.ToString(); 
  }
 }
}
