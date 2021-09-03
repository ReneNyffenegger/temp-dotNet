using System.Runtime.InteropServices;

[assembly: ComVisible(true)]

namespace tq84 {

   //
   //  By default, an interface is enabled for both early and late-binding.
   //  Using the InterfaceType attribute, we define the interface to be late-binding only (InterfaceIsIDispatch)
   //
  [ /* Guid("11234567-89ab-cdef-0123-456789abcdef") , */
   InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
   public interface IComClassExample {
      [DispId(1)]
       int AddTheseUp(int adder1, int adder2);
   }

  [Guid("fedcba98-7654-3210-fedc-ba9876543210"), 
   ClassInterface(ClassInterfaceType.None)]
   public class ComClassExample : IComClassExample {
   
      public ComClassExample() {}
   
      public int AddTheseUp(int adder1, int adder2) {
         return adder1 + adder2;
      }
   
   }

}
