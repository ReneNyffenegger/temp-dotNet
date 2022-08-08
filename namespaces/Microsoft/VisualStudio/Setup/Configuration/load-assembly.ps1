add-type -path 'C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\PrivateAssemblies\Microsoft.VisualStudio.Setup.Configuration.Interop.dll'

$conf = new-object Microsoft.VisualStudio.Setup.Configuration.SetupConfigurationClass

# https://www.cazzulino.com/how-to-get-vsinstallroot.html
$guid = new-object Guid "177F0C4A-1CD3-4DE7-A32C-71DBBB9FA36D"
$obj  = [Activator]::CreateInstance([Type]::GetTypeFromCLSID($guid)) 
[Microsoft.VisualStudio.Setup.Configuration.ISetupConfiguration2] $obj  = [Activator]::CreateInstance([Type]::GetTypeFromCLSID($guid)) 
[Microsoft.VisualStudio.Setup.Configuration.SetupConfiguration] $obj  = [Activator]::CreateInstance([Type]::GetTypeFromCLSID($guid)) 
$i = $obj -as [Microsoft.VisualStudio.Setup.Configuration.ISetupConfiguration2]
$instance = $i.GetInstanceForCurrentProcess()
