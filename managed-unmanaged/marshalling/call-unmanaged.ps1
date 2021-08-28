if (-not ( $pwd -in ($env:path -split ';') )) {
 #
 # Add current directory if not already in path
 #
   $env:PATH="$pwd;$env:path"
}



add-type -typeDefinition ( get-content -raw "$psScriptRoot/managed.cs" )

$ret = [INTF_Unicode]::Str("Unicode") # Calls StrW
$ret = [INTF_Ansi   ]::Str("Ansi"   ) # Calls StrA
$ret = [INTF_Auto   ]::Str("Auto"   ) # Calls StrW

[UInt32] $num = 99
[INTF_PtrDword]::PtrDWord([ref] $num)
"num = $num"
