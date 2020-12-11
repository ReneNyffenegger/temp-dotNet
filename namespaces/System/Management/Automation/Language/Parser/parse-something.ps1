#
#   https://blog.iisreset.me/so-you-think-you-can-parse/
#
$ParseErrors = @()
$InputString = 'string,@{key="value1","value2"},"another string"'
$FakeCommand = "Totally-NotACmdlet -FakeParameter $InputString"
$AST = [System.Management.Automation.Language.Parser]::ParseInput($FakeCommand,[ref]$null,[ref]$ParseErrors)

if(-not $ParseErrors){

    # Use Ast.Find() to locate the CommandAst parsed from our fake command
    $CmdAst = $AST.Find({param($ChildAst) $ChildAst -is [System.Management.Automation.Language.CommandAst]},$false)
    # Grab the user-supplied arguments (index 0 is the command name, 1 is our fake parameter)
    $ArgumentAst = $CmdAst.CommandElements[2]
    if ($ArgumentAst -is [System.Management.Automation.Language.ArrayLiteralAst]) {
        write-host 'Argument was a list'
        # Inspect $ArgumentAst.Elements
    }
    else {
        write-host 'Argument was a scalar.'
        # Test if it's a [StringConstantExpressionAst] or [HashtableAst], otherwise throw an error  
    }
}
