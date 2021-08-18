add-type -typeDefinition ( get-content -raw "$psScriptRoot/managed.cs" )

$ret = [INTF_Unicode]::passString("Unicode") # Calls passStringW
$ret = [INTF_Ansi   ]::passString("Ansi"   ) # Calls passStringA
$ret = [INTF_Auto   ]::passString("Auto"   ) # Calls passStringW
