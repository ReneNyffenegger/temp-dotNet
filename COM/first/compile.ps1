# sn -k ComClassExample.snk # Creates file ComClassExample.snk with a key-pair.
# csc -keyfile:ComClassExample.snk -target:library ComClassExample.cs -out:ComClassExample.dll
# regasm -verbose -codebase -regfile ComClassExample.dll # Create ComClassExample.reg

# run as admin:
reg import ComClassExample.reg
