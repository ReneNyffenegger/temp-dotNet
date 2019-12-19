//
//    csc -r:Microsoft.Build.dll prog.cs
//

using System;
using System.Collections.Generic;
using Microsoft.Build.Execution;
using Microsoft.Build.Evaluation;

static class Prg {

   static void Main(string[] args) {

      string projectFile = args[0];

//    Project proj = new Project("Project.csproj");
//    Project proj = new Project("Visual-Studio-2019-generated.csproj");
      Project proj = new Project(projectFile);

      foreach (KeyValuePair<string, string> globalProperty in proj.GlobalProperties) {
         Console.WriteLine("{0,-30} = {1}", globalProperty.Key, globalProperty.Value);
      }

      foreach (KeyValuePair<string, ProjectTargetInstance> target in proj.Targets) {
         Console.WriteLine("{0,-30} = {1}", target.Key, target.Value);
      }

   }

}
