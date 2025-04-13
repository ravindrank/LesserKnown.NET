using MessagePack;

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


        // Message Pack Demo

        MessagePackBinaryDemo mc = new MessagePackBinaryDemo
        {
            Age = 50,
            FirstName = "Bill",
            LastName = "Yeates",
        };

        byte[] bytes = MessagePackSerializer.Serialize(mc);
        MessagePackBinaryDemo mcd = MessagePackSerializer.Deserialize<MessagePackBinaryDemo>(bytes);

        // You can dump MessagePack binary blobs to human readable json.
        // Using indexed keys (as opposed to string keys) will serialize to MessagePack arrays,
        // hence property names are not available.

        var json = MessagePackSerializer.ConvertToJson(bytes);
        Console.WriteLine(json);
        
        MessagePackJsonDemo mc2 = new MessagePackJsonDemo
        {
            Age = 40,
            Name = "John",
        };

        byte[] bytes2 = MessagePackSerializer.Serialize(mc2);
        MessagePackJsonDemo mcd2 = MessagePackSerializer.Deserialize<MessagePackJsonDemo>(bytes2);
        var json2 = MessagePackSerializer.ConvertToJson(bytes2);
        Console.WriteLine(json2);
    }
}
