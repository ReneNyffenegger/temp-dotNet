Add-Type -TypeDefinition @'
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Concfg {
    public class ShortcutManager {
        public static void ResetConsoleProperties(string path) {
            if (!System.IO.File.Exists(path)) { return; }

            var lnk = new ShellLink();
            var data = (IShellLinkDataList)lnk;
			var file = (IPersistFile)lnk;

            file.Load(path, 2 /* STGM_READWRITE */);
            data.RemoveDataBlock( 0xA0000002 /* NT_CONSOLE_PROPS_SIG */);
            file.Save(path, true);

            Marshal.ReleaseComObject(data);
            Marshal.ReleaseComObject(file);
            Marshal.ReleaseComObject(lnk);
        }
    }
    [ComImport, Guid("00021401-0000-0000-C000-000000000046")]
    class ShellLink { }
    [ComImport, Guid("45e2b4ae-b1c3-11d0-b92f-00a0c90312e1"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IShellLinkDataList {
        void AddDataBlock(IntPtr pDataBlock);
        void CopyDataBlock(uint dwSig, out IntPtr ppDataBlock);
        void RemoveDataBlock(uint dwSig);
        void GetFlags(out uint pdwFlags);
        void SetFlags(uint dwFlags);
    }
}
'@

