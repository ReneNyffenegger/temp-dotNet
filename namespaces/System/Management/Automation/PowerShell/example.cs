//
//  Compiling source file:
//
//    csc -reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\WindowsPowerShell\3.0\System.Management.Automation.dll" example.cs
//

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

class PS {

   static void Main() {

      PowerShell ps = PowerShell.Create();

      Console.WriteLine($"PowerShell created");
      Console.WriteLine($"  ps.InstanceId          = {ps.InstanceId}");
      Console.WriteLine($"  ps.InvocationStateInfo = {ps.InvocationStateInfo.State}"); // NotStarted

      ps.AddCommand("Get-Process");

      PSCommand cmd = ps.Commands;
      Console.WriteLine($"  cmd                    = {cmd.ToString()}");

      CommandCollection cmds = cmd.Commands;
      foreach (Command c in cmds) {
         Console.WriteLine($"  c.commandText = {c.CommandText}");
      }


      Collection<PSObject> res = ps.Invoke();

      foreach (PSObject obj in res) {
         Process prc = (Process) obj.BaseObject;
//       Console.WriteLine($"  obj = {obj}");    
         Console.WriteLine($"  prc: Id = {prc.Id}, ProcessName = {prc.ProcessName}");    
      }


   }

}
