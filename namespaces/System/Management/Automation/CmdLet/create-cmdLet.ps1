#
#    https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_functions_advanced_parameters?view=powershell-7
#
# Create a cmdlet that accepts a [datetime] argument.
add-type @'

   using System;
   using System.Management.Automation;

  [Cmdlet("show", "stars")]
   public class showStarsCmdLet : Cmdlet {
 
    [Parameter(Position=0)]
     public int nofStars { get; set; }
 
     protected override void ProcessRecord() {
        WriteObject(new string('*', nofStars));
     }
   }

'@ -passThru | % assembly | import-module


show-stars 10
