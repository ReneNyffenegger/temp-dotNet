/* 
 * The MIT License (MIT)
 *
 * Copyright (c) 2018 https://github.com/TheVice/
 *
 *    https://gist.github.com/TheVice/d635167fb937cc899e340feb4a968289
 *
 * csc -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\XamlBuildTask.dll"                               ^
 *     -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\Microsoft.Build.Utilities.v4.0.dll"              ^
 *     -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\Microsoft.Build.Framework.dll"                   ^
 *     -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\PresentationBuildTasks.dll"                      ^
 *        todo.cs
 *
 */


//  See also
//      https://stackoverflow.com/questions/37118347/set-relative-path-of-baml-xaml-in-g-cs-using-markupcompilepass1

using System;
using System.IO;
using System.Xml;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks.Windows;

namespace Utils
{
    class MarkupCompilePass
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2) return;
#if NET20
            string pathToDotNetFramework = ToolLocationHelper.GetPathToDotNetFramework(TargetDotNetFrameworkVersion.Version20);

            string pathToReference = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            if (string.IsNullOrEmpty(pathToReference))
                pathToReference = Environment.GetEnvironmentVariable("ProgramFiles");
            if (string.IsNullOrEmpty(pathToReference))
                pathToReference = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            pathToReference = Path.Combine(pathToReference, string.Format("Reference Assemblies{0}Microsoft{0}Framework{0}v3.0", Path.DirectorySeparatorChar));

            ITaskItem[] references = new ITaskItem[]
            {
                new TaskItem(Path.Combine(pathToDotNetFramework, "mscorlib.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "System.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "System.Xml.dll")),
                new TaskItem(Path.Combine(pathToReference, "WindowsBase.dll")),
                new TaskItem(Path.Combine(pathToReference, "ReachFramework.dll")),
                new TaskItem(Path.Combine(pathToReference, "System.Printing.dll")),
                new TaskItem(Path.Combine(pathToReference, "PresentationCore.dll")),
                new TaskItem(Path.Combine(pathToReference, "PresentationFramework.dll"))
            };
#else
            string pathToDotNetFramework = ToolLocationHelper.GetPathToDotNetFramework(TargetDotNetFrameworkVersion.Version40);

            ITaskItem[] references = new ITaskItem[]
            {
                new TaskItem(Path.Combine(pathToDotNetFramework, "mscorlib.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "System.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "System.Xml.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "System.Xaml.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "WPF", "WindowsBase.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "WPF", "ReachFramework.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "WPF", "System.Printing.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "WPF", "PresentationCore.dll")),
                new TaskItem(Path.Combine(pathToDotNetFramework, "WPF", "PresentationFramework.dll"))
            };
#endif
            string additionReference = string.Empty;

            if (3 < args.Length)
            {
                string ext = Path.GetExtension(args[args.Length - 3]).ToLower();

                if (".exe" == ext || ".dll" == ext)
                {
                    additionReference = args[args.Length - 3];
                }
            }

            int count = args.Length - (string.IsNullOrEmpty(additionReference) ? 2 : 3);
            int aCount = 0;
            int pCount = 0;
            ITaskItem[] applicationsCandidates = new ITaskItem[count];
            ITaskItem[] pagesCandidates = new ITaskItem[count];

            for (int i = 0; i < count; i++)
            {
                bool isApplication = false;

                using (FileStream fileStream = new FileStream(args[i], FileMode.Open))
                {
                    using (XmlReader xmlReader = XmlReader.Create(fileStream))
                    {
                        while (xmlReader.Read())
                        {
                            isApplication = (xmlReader.Depth == 0 &&
                                xmlReader.NodeType == XmlNodeType.Element &&
                                xmlReader.Name == "Application");
                            if (isApplication || xmlReader.Depth > 0) break;
                        }
                    }
                }

                if (isApplication)
                {
                    applicationsCandidates[aCount] = new TaskItem(args[i]);
                    aCount++;
                }
                else
                {
                    pagesCandidates[pCount] = new TaskItem(args[i]);
                    pCount++;
                }
            }

            ITaskItem[] applications = ((aCount > 0) ? new ITaskItem[aCount] : null);
            ITaskItem[] pages = ((pCount > 0 ) ? new ITaskItem[pCount] : null);

            if (aCount > 0)
            {
                Array.Copy(applicationsCandidates, applications, aCount);
            }

            if (pCount > 0)
            {
                Array.Copy(pagesCandidates, pages, pCount);
            }

            MarkupCompilePass1 markupCompilePass1 = new MarkupCompilePass1();
            markupCompilePass1.Language = "C#";
            markupCompilePass1.BuildEngine = new InternalEngine();
            markupCompilePass1.References = references;
            markupCompilePass1.ApplicationMarkup = applications;
            markupCompilePass1.PageMarkup = pages;
            markupCompilePass1.AssemblyName = args[args.Length - 2];
            markupCompilePass1.OutputPath = args[args.Length - 1];

            bool isExecute = markupCompilePass1.Execute();

            if (isExecute && !string.IsNullOrEmpty(additionReference) && markupCompilePass1.RequirePass2ForMainAssembly)
            {
                MarkupCompilePass2 markupCompilePass2 = new MarkupCompilePass2();
                markupCompilePass2.Language = markupCompilePass1.Language;
                markupCompilePass2.BuildEngine = markupCompilePass1.BuildEngine;

                ITaskItem[] referencesEx =  new ITaskItem[references.Length + 1];
                Array.Copy(references, 0, referencesEx, 1, references.Length);
                referencesEx[0] = new TaskItem(additionReference);

                markupCompilePass2.References = referencesEx;
                markupCompilePass2.AssemblyName = markupCompilePass1.AssemblyName;
                markupCompilePass2.OutputPath = markupCompilePass1.OutputPath;

                /*isExecute = */markupCompilePass2.Execute();
            }
        }
    }
}
