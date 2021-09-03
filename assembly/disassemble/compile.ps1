csc -nologo -target:library      cls.cs    -out:cls.dll
csc -nologo -reference:cls.dll   simple.cs

ildasm cls.dll     -out:cls.il
ildasm simple.exe  -out:simple.il

ilasm -dll cls.il
ilasm      simple.il
