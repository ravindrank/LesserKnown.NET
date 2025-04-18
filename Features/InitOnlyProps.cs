namespace LesserKnown.NET;

public class PersonA
{
    public string Name { get; init; }
    public record PhysicalAddress(
    string Street,
    string City,
    string StateOrProvince,
    string ZipCode)
    {
        public string FullAddress { get; init; } = $"{Street}, {City}, {StateOrProvince} {ZipCode}";
    }

    public void Run()
    {
        var person = new PersonA { Name = "John" };
        //person.Name = "Doe"; // Error: Cannot modify init-only property

        var address = new PhysicalAddress("123 Main St", "Anytown", "CA", "90210")
        {
            FullAddress = "123 Main St, Anytown, CA 90210" // Set during initialization
        };
        // address.FullAddress = "New Address"; // Error: Cannot modify init-only property
    }

}
