﻿namespace LesserKnown.NET;

public class Program
{
    static void Main(string[] args)
    {

        var pollyTest = new PollyDemo();
        //pollyTest.Run();

        var pInvokeTest = new PInvoke();
        pInvokeTest.Run();
    }
}
