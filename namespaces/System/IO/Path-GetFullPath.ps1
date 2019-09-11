#
# Potentially with a tilde:
#
$env:temp

#
# Expand tilde:
#
[System.IO.Path]::GetFullPath($env:temp)
