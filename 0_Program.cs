namespace LesserKnown.NET;

public class Program
{
    static void Main(string[] args)
    {
        Util.PrintDemoStart("MainDemo");

        var pollyTest = new PollyDemo();
        //pollyTest.Run();

        var pInvokeTest = new PInvoke();
        //pInvokeTest.Run();

        var exprTest = new Exprs();
        //exprTest.Run();

        var spanTest = new SpanT();
        //spanTest.Run();

        var memTest = new MemoryT();
        //memTest.Run();

        //Fody Demo

        FodyDemo fodyDemo = new FodyDemo();
        fodyDemo.Run();


        // Message Pack Demo

        MpDemo mpDemo = new MpDemo();   
        //mpDemo.Run();

        // Dynamic code gen

        DynamicCodeGen dynamicCodeGen = new DynamicCodeGen();
        // dynamicCodeGen.Run();

        HumanizerDemo humanizer = new HumanizerDemo();  
        humanizer.Run();
        humanizer = null;

        CancTokensDemo cancTokensDemo = new CancTokensDemo();
        cancTokensDemo.Run();
        Util.PrintDemoEnd("MainDemo");
    }
}
