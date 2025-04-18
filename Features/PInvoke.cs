﻿using System.Runtime.InteropServices;

namespace LesserKnown.NET;

[StructLayout(LayoutKind.Sequential)]
public class MySystemTime
{
    public ushort wYear;
    public ushort wMonth;
    public ushort wDayOfWeek;
    public ushort wDay;
    public ushort wHour;
    public ushort wMinute;
    public ushort wSecond;
    public ushort wMilliseconds;
}
internal static class NativeMethods
{
    [DllImport("Kernel32.dll")]
    internal static extern void GetSystemTime(MySystemTime st);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    internal static extern int MessageBox(
        IntPtr hWnd, string lpText, string lpCaption, uint uType);
}

public class PInvokeDemo:MainDemo
{
    public void Run()
    {
        MySystemTime sysTime = new MySystemTime();
        NativeMethods.GetSystemTime(sysTime);        
        string dt = $"System time is: \nYear: {sysTime.wYear}\nMonth: {sysTime.wMonth}\nDayOfWeek: {sysTime.wDayOfWeek}\nDay: {sysTime.wDay}";
        Console.WriteLine("Click OK to close the Demo Box and continue!");
        NativeMethods.MessageBox(IntPtr.Zero, dt, "Platform Invoke Example", 0);

        EndDemo();
    }
}