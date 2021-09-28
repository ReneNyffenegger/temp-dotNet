using System;
using System.Runtime.InteropServices;

public class INTF_Auto     { [DllImport("unmanaged.dll", CharSet = CharSet.Auto   )] public static extern int  Str     (String txt_in, System.Text.StringBuilder txt_out); }
public class INTF_Unicode  { [DllImport("unmanaged.dll", CharSet = CharSet.Unicode)] public static extern int  Str     (String txt_in, System.Text.StringBuilder txt_out); }
public class INTF_Ansi     { [DllImport("unmanaged.dll", CharSet = CharSet.Ansi   )] public static extern int  Str     (String txt_in, System.Text.StringBuilder txt_out); }

public class INTF_PtrDword { [DllImport("unmanaged.dll", CharSet = CharSet.Ansi   )] public static extern void PtrDWord(ref UInt32 ptr); }

public delegate int callbackFunction(int a, int b);
public class INTF_CallBack { [DllImport("unmanaged.dll"                           )] public static extern int  callCallback(callbackFunction callback, int a, int b);      }
