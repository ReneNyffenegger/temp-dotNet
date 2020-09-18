#
#  Found in microsofts documentation
#  
#  Does not seem to work intuitively!
#


function Get-Numbers {
    [CmdletBinding(SupportsPaging = $true)]
    param()

    $FirstNumber = [Math]::Min($PSCmdlet.PagingParameters.Skip                    , 100)
    $LastNumber  = [Math]::Min($PSCmdlet.PagingParameters.First + $FirstNumber - 1, 100)

    if ($PSCmdlet.PagingParameters.IncludeTotalCount) {

        $TotalCountAccuracy = 1.0
        $TotalCount = $PSCmdlet.PagingParameters.NewTotalCount(100, $TotalCountAccuracy)
        Write-Output $TotalCount
    }

    $FirstNumber .. $LastNumber | Write-Output

    $psCmdLet.GetType().FullName
    $psCmdLet.PagingParameters.GetType().FullName
}


get-numbers -first 10 -skip 4 -includeTotalCount
