namespace LesserKnown.NET;

public static class Util
{
    private static void PrintWithPadding(string demoString)
    {
        int chars = (Console.WindowWidth - demoString.Length) / 2;
        string padding = new string('-', chars);
        Console.WriteLine(padding + demoString + padding);
        Console.WriteLine();
    }

    public static void PrintDemoStart(string demoName)
    {
        string demoString = $" {demoName} START ";
        PrintWithPadding(demoString);
    }
    public static void PrintDemoEnd(string demoName)
    {
        string demoString = $" {demoName}  END  ";
        PrintWithPadding(demoString);
    }
}

public class MainDemo
{
    public string DemoName { get; set; }

    public MainDemo()
    {
        DemoName = GetType().Name;
        Util.PrintDemoStart(DemoName);
    }

    public void EndDemo()
    {
        Util.PrintDemoEnd(DemoName);
    }
    public void Run()
    {
        EndDemo(); 
    }
}