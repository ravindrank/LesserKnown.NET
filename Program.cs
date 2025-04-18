namespace LesserKnown.NET;

public class Program
{
    static void Main(string[] args)
    {
        Util.PrintDemoStart("MainDemo");

        var pollyTestDemo = new PollyDemo();
        //pollyTestDemo.Run();

        var pInvokeTestDemo = new PInvokeDemo();
        //pInvokeTestDemo.Run();

        var exprTestDemo = new ExprsDemo();
        //exprTestDemo.Run();

        var spanTestDemo = new SpanTDemo();
        //spanTestDemo.Run();

        var memTestDemo = new MemoryTDemo();
        //memTestDemo.Run();

        //Fody Demo
        FodyDemo fodyDemo = new FodyDemo();
        //fodyDemo.Run();

        // Message Pack Demo
        MessagePackDemo mpDemo = new MessagePackDemo();   
        mpDemo.Run();

        // Dynamic code gen Demo
        DynamicCodeGenDemo dynamicCodeGenDemo = new DynamicCodeGenDemo();
        //dynamicCodeGenDemo.Run();

        HumanizerDemo humanizerDemo = new HumanizerDemo();
        //humanizerDemo.Run();

        CancTokensDemo cancTokensDemo = new CancTokensDemo();
        //cancTokensDemo.Run();

        Util.PrintDemoEnd("MainDemo");
    }
}
