if (-not ( $pwd -in ($env:path -split ';') )) {
 #
 # Add current directory if not already in path
 #
   $env:PATH="$pwd;$env:path"
}



add-type -typeDefinition ( get-content -raw "$psScriptRoot/managed.cs" )

$outString = new-object System.text.StringBuilder 100
$ret = [INTF_Unicode]::Str("Unicode", $outString); write-host "ret = $ret, outString = $($outString.toString())" # Calls StrW
$ret = [INTF_Ansi   ]::Str("Ansi"   , $outString); write-host "ret = $ret, outString = $($outString.toString())" # Calls StrA
$ret = [INTF_Auto   ]::Str("Auto"   , $outString); write-host "ret = $ret, outString = $($outString.toString())" # Calls StrW

[UInt32] $num = 99
[INTF_PtrDword]::PtrDWord([ref] $num)
"num = $num"

[INTF_CallBack]::callCallback( { param ( [int]$a, [int]$b) return $a * $b },  4, 3)
[INTF_CallBack]::callCallback( { param ( [int]$a, [int]$b) return $a + $b },  4, 3)
