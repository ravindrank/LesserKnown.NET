namespace LesserKnown.NET;

public class Person
{
    public string Name { get; init; }

    public void Run()
    {
        var person = new Person { Name = "John" };
        //person.Name = "Doe"; // Error: Cannot modify init-only property
    }

}
