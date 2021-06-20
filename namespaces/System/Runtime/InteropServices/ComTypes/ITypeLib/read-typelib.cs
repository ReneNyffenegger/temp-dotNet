//
//    https://stackoverflow.com/a/34696484/180275
//
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

public class TypeLibTest {
 
  [DllImport("oleaut32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
   private static extern IntPtr LoadTypeLib(
          string fileName,
      out System.Runtime.InteropServices.ComTypes.ITypeLib typeLib);
 
   public static void Main(string[] args) {
 
      System.Runtime.InteropServices.ComTypes.ITypeLib typeLib = null;
      IntPtr ptr = IntPtr.Zero;
   
      try {
   
         LoadTypeLib(args[0], out typeLib);
         typeLib.GetLibAttr(out ptr);
   
         var typeAttr = (System.Runtime.InteropServices.ComTypes.TYPELIBATTR) Marshal.PtrToStructure(ptr, typeof(System.Runtime.InteropServices.ComTypes.TYPELIBATTR));
         Console.WriteLine("{0}.{1}", typeAttr.wMajorVerNum, typeAttr.wMinorVerNum);   
      }
      catch (COMException ex) {
   
         Console.WriteLine("Error: " + ex.Message);        
   
      }
      finally {
   
          if (typeLib != null && ptr != IntPtr.Zero) {
             typeLib.ReleaseTLibAttr(ptr);
          }
      }
   }
}
