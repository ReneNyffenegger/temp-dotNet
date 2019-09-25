@echo off

@dotnet new console -o simpleApp

rem     Creates:
rem
rem     ─simpleApp
rem      │   Program.cs
rem      │   simpleApp.csproj
rem      │
rem      └───obj
rem              project.assets.json
rem              simpleApp.csproj.nuget.cache
rem              simpleApp.csproj.nuget.dgspec.json
rem              simpleApp.csproj.nuget.g.props
rem              simpleApp.csproj.nuget.g.targets
rem

cd simpleApp

dotnet run

rem
rem
rem ─simpleApp
rem  │   Program.cs
rem  │   simpleApp.csproj
rem  │
rem  ├───bin
rem  │   └───Debug
rem  │       └───netcoreapp3.0
rem  │               simpleApp.deps.json
rem  │               simpleApp.dll
rem  │               simpleApp.exe
rem  │               simpleApp.pdb
rem  │               simpleApp.runtimeconfig.dev.json
rem  │               simpleApp.runtimeconfig.json
rem  │
rem  └───obj
rem      │   project.assets.json
rem      │   simpleApp.csproj.nuget.cache
rem      │   simpleApp.csproj.nuget.dgspec.json
rem      │   simpleApp.csproj.nuget.g.props
rem      │   simpleApp.csproj.nuget.g.targets
rem      │
rem      └───Debug
rem          └───netcoreapp3.0
rem                  simpleApp.AssemblyInfo.cs
rem                  simpleApp.AssemblyInfoInputs.cache
rem                  simpleApp.assets.cache
rem                  simpleApp.csproj.FileListAbsolute.txt
rem                  simpleApp.csprojAssemblyReference.cache
rem                  simpleApp.dll
rem                  simpleApp.exe
rem                  simpleApp.pdb
rem 
