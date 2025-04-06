using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// from https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interop/using-type-dynamic

namespace LesserKnown.NET
{
    public class Dynamik
    {

        public void Run()
        {
            {
                ExampleClass ec = new ExampleClass();
                // The following call to exampleMethod1 causes a compiler error
                // if exampleMethod1 has only one parameter. Uncomment the line
                // to see the error.
                //ec.exampleMethod1(10, 4);

                dynamic dynamic_ec = new ExampleClass();
                // The following line is not identified as an error by the
                // compiler, but it causes a run-time exception.
                dynamic_ec.exampleMethod1(10, 4);

                // The following calls also do not cause compiler errors, whether
                // appropriate methods exist or not.
                dynamic_ec.someMethod("some argument", 7, null);
                dynamic_ec.nonexistentMethod();

                // Valid.
                ec.exampleMethod2("a string");


                // Conversions between dynamic objects and other types are easy.
                // Conversions enable the developer to switch between dynamic and non - dynamic behavior.
                // You can convert any to dynamic implicitly, as shown in the following examples.

                dynamic d1 = 7;
                dynamic d2 = "a string";
                dynamic d3 = System.DateTime.Today;
                dynamic d4 = System.Diagnostics.Process.GetProcesses();

                // Conversely, you can dynamically apply any implicit conversion to any expression of type dynamic.
                int i = d1;
                string str = d2;
                DateTime dt = d3;
                System.Diagnostics.Process[] procs = d4;

                // The following statement does not cause a compiler error, even though ec is not
                // dynamic. A run-time exception is raised because the run-time type of d1 is int.
                ec.exampleMethod2(d1);
                // The following statement does cause a compiler error.
                //ec.exampleMethod2(7);
            }
        }
    }
    public class ExampleClass
    {
        public ExampleClass() { }
        public ExampleClass(int v) { }

        public void exampleMethod1(int i) { }

        public void exampleMethod2(string str) { }
    }
}
