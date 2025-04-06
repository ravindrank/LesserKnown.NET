using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

public class PInvoke
{
    public void Run()
    {
        MySystemTime sysTime = new MySystemTime();
        NativeMethods.GetSystemTime(sysTime);

        string dt = $"System time is: \nYear: {sysTime.wYear}\nMonth: {sysTime.wMonth}\nDayOfWeek: {sysTime.wDayOfWeek}\nDay: {sysTime.wDay}";
        NativeMethods.MessageBox(IntPtr.Zero, dt, "Platform Invoke Example", 0);
    }
}