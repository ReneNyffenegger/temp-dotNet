# sn -k ComClassExample.snk # Creates file ComClassExample.snk with a key-pair.
# csc -keyfile:ComClassExample.snk -target:library ComClassExample.cs -out:ComClassExample.dll
# regasm -verbose -codebase -regfile ComClassExample.dll # Create ComClassExample.reg

# run as admin:
#   BUT See also https://stackoverflow.com/questions/37193356/registering-net-com-dlls-without-admin-rights-regasm
reg import ComClassExample.reg

# regasm -verbose -codebase -unregister ComClassExample.dll # Create ComClassExample.reg
