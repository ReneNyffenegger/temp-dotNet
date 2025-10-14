#
#  This is the script that will
#  be executed in the 'Powershell Host'.
#

if (-not (get-variable -name x -errorAction silentlyContinue) ) { $x =  2 }
if (-not (get-variable -name y -errorAction silentlyContinue) ) { $y =  3 }
if (-not (get-variable -name z -errorAction silentlyContinue) ) { $z = 10 }

write-output ($x + $y*$z)
