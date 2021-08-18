#
#  https://qiita.com/Q11Q/items/9f47ea23ec690fa37f39
#
$Source=@"

using System;
using System.Runtime.InteropServices;
using ComTypes = System.Runtime.InteropServices.ComTypes;

namespace ListTypeLibInfo {
   
   public class Program {

     [DllImport("oleaut32.dll", PreserveSig=false)]
      public static extern ComTypes.ITypeLib LoadTypeLib([In, MarshalAs(UnmanagedType.LPWStr)] string typelib);
   
      public static void Main(string[] args) {
   
         ComTypes.ITypeLib lib;
   
         try {
             lib = LoadTypeLib(args[0]);
         }
         catch (Exception ex) {
              Console.WriteLine("Error:" + ex.Message);
              return;
         }

         Console.WriteLine("Type info count = " + lib.GetTypeInfoCount());

         for (int i = 0; i < lib.GetTypeInfoCount(); i++) {

            IntPtr ppta;
            ComTypes.ITypeInfo info;
            int con;
            string sname, doc, hlp;
            lib.GetTypeInfo(i, out info);
            info.GetDocumentation(-1, out sname, out doc, out con, out hlp);
            info.GetTypeAttr(out ppta);

            try {
               ComTypes.TYPEATTR ta = (ComTypes.TYPEATTR)Marshal.PtrToStructure(ppta, typeof(ComTypes.TYPEATTR));
               if (ta.typekind == ComTypes.TYPEKIND.TKIND_ENUM) {
                  for (int j = 0; j < ta.cVars; j++) {
                     IntPtr ppvd;
                     int pcnames;
                     string[] names = {string.Empty};

                     info.GetVarDesc(j, out ppvd);
                     try {
                        ComTypes.VARDESC vd = (ComTypes.VARDESC)Marshal.PtrToStructure(ppvd, typeof(ComTypes.VARDESC));
                        info.GetNames(vd.memid, names, 1, out pcnames);
                        Console.WriteLine("{0}\t{1}\t{2}", sname, names[0], Marshal.GetObjectForNativeVariant(vd.desc.lpvarValue));
                     }
                     finally {
                       info.ReleaseVarDesc(ppvd);
                     }
                  }
               }
            } finally {
               info.ReleaseTypeAttr(ppta);
            }
         }
      }
   }
}

"@
# CSharpコードのコンパイル
Add-Type -TypeDefinition $Source

[ListTypeLibInfo.Program]::main("C:\Windows\system32\stdole2.tlb")
[ListTypeLibInfo.Program]::main("C:\Program Files (x86)\Common Files\Microsoft Shared\DAO\dao360.dll")
