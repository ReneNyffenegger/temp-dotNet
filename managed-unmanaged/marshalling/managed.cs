using System;
using System.Runtime.InteropServices;

public class INTF_Auto    { [DllImport("unmanaged.dll", CharSet = CharSet.Auto   )] public static extern int passString(String txt); }
public class INTF_Unicode { [DllImport("unmanaged.dll", CharSet = CharSet.Unicode)] public static extern int passString(String txt); }
public class INTF_Ansi    { [DllImport("unmanaged.dll", CharSet = CharSet.Ansi   )] public static extern int passString(String txt); }