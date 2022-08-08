add-type -path 'C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\PrivateAssemblies\Microsoft.VisualStudio.Setup.Configuration.Interop.dll'

$conf = new-object Microsoft.VisualStudio.Setup.Configuration.SetupConfigurationClass
