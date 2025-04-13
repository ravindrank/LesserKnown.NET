namespace LesserKnown.NET;

public class PersonA
{
    public string Name { get; init; }

    public void Run()
    {
        var person = new PersonA { Name = "John" };
        //person.Name = "Doe"; // Error: Cannot modify init-only property
    }

}
