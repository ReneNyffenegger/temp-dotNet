#
#  https://mike-ward.net/2008/09/02/a-lean-method-for-invoking-com-in-c/
#

Add-Type -TypeDefinition @'

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace tq84
{
//  using System;
//  using System.Runtime.InteropServices;



    public class MinimizeAll
    {
        public static void go()
        {
            var shell = new Shell32();
            var shellDispatch = (IShellDispatch)shell;
            shellDispatch.MinimizeAll();
        }
    }

    [ComImport, Guid("13709620-C279-11CE-A49E-444553540000")]
    // Retrieving the COM class factory for component with CLSID {93709620-C279-11CE-A49E-444553540000} failed due to the following error: 80040154 Class not register
    class Shell32
    {
    }

 //
 //  TODO:
 //    Compare with https://docs.microsoft.com/en-us/dotnet/api/shell32.ishelldispatch?view=powershellsdk-1.1.0
 //
    [ComImport, Guid("D8F015C0-C278-11CE-A49E-444553540000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IShellDispatch
    {
        [DispId(0x60020007)]
        void MinimizeAll();
    }
}
'@

[tq84.MinimizeAll]::go()
