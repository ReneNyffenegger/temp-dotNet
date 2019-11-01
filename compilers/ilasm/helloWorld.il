//  https://stackoverflow.com/a/12741647/180275
//
//  ilasm /exe helloWorld.il /deb=opt
//
//    Peverify makes sure your generated MSIL is correct and runs.
//    ilasm generates your assembly if its syntactically correct. Anything else is not checked. (Type safety etc.) 
//  peverify /md /il helloWorld.exe
//


//
//  Prevent
//     warning : Reference to undeclared extern assembly 'mscorlib'. Attempting autodetect
//
.assembly extern mscorlib {
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}

//
//   Prevent The module 'C:\Users\OMIS.Rene\github\temp\dotNet\compilers\ilasm\helloWorld.exe' was expected to contain an assembly manifest.
//
.assembly HelloWorld {
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 )
  .hash   algorithm 0x00008004
  .ver    0:0:0:0
}


.method private hidebysig static void  Main(string[] args) cil managed {

    .entrypoint
    .custom instance void [mscorlib]System.STAThreadAttribute::.ctor() = ( 01 00 00 00 )

 // Code size       11 (0xb)
    .maxstack  1

    IL_0000:  ldstr      "Hello World"
    IL_0005:  call        void [mscorlib]System.Console::WriteLine(string)
    IL_000a:  ret

 } // end of method Class1::Main
