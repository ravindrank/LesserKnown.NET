namespace LesserKnown.NET;

public class Program
{
    static void Main(string[] args)
    {

        var pollyTest = new PollyDemo();
        //pollyTest.Run();

        var pInvokeTest = new PInvoke();
        //pInvokeTest.Run();

        var exprTest = new Exprs();
        exprTest.Run();

        var spanTest = new SpanT();
        spanTest.Run();

        var memTest = new MemoryT();
        memTest.Run();

        //Fody Demo
        Person person = new Person
        {
            FirstName = "John",
            LastName = "Doe"
        };


        Person p2 = new Person()
        {
            FirstName = "Ravi"
        };

        Person p3 = new Person();
    }
}
