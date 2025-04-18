using BenchmarkDotNet.Running;
using LesserKnown.NET.Libraries;
using System.Diagnostics;
using System.Numerics;

namespace LesserKnown.NET;

public class Program
{
    static async Task Main(string[] args)
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
        //mpDemo.Run();

        // Dynamic code gen Demo
        DynamicCodeGenDemo dynamicCodeGenDemo = new DynamicCodeGenDemo();
        //dynamicCodeGenDemo.Run();

        HumanizerDemo humanizerDemo = new HumanizerDemo();
        //humanizerDemo.Run();

        CancTokensDemo cancTokensDemo = new CancTokensDemo();
        // await cancTokensDemo.Run();

        // If you run in Debug mode: you will see below message
        //    * Assembly LesserKnown.NET which defines benchmarks is non-optimized
        // Benchmark was built without optimization enabled(most probably a DEBUG configuration). Please, build it in RELEASE.
        // If you want to debug the benchmarks, please see https://benchmarkdotnet.org/articles/guides/troubleshooting.html#debugging-benchmarks.

        // Switch to Release mode before calling
        BenchMarkRunnerDemo benchMarkRunnerDemo = new BenchMarkRunnerDemo();
        //benchMarkRunnerDemo.Run();

        LLMDemo lLMDemo = new LLMDemo();
        lLMDemo.Run();

        Util.PrintDemoEnd("MainDemo");
    }
}
