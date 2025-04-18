using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = MessagePack.KeyAttribute;

namespace LesserKnown.NET;

[MessagePackObject]
public class MessagePackBinaryDemo
{
    // Key attributes take a serialization index (or string name)
    // The values must be unique and versioning has to be considered as well.
    // Keys are described in later sections in more detail.
    [Key(0)]
    public int Age { get; set; }

    [Key(1)]
    public string FirstName { get; set; }

    [Key(2)]
    public string LastName { get; set; }

    // All fields or properties that should not be serialized must be annotated with [IgnoreMember].
    [IgnoreMember]
    public string FullName { get { return FirstName + LastName; } }
}

[MessagePackObject(keyAsPropertyName: true)]
public class MessagePackJsonDemo
{
    public int Age { get; set; }
    public string Name { get; set; }
}

public class MessagePackDemo : MainDemo
{

    public void Run()
    {
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

        EndDemo();
    }
}