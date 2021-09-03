dim objTest, intResult
Set objTest = WScript.CreateObject ("tq84.ComClassExample")

intResult = objTest.AddTheseUp (100, 200)
Wscript.echo "Result = " & intResult
