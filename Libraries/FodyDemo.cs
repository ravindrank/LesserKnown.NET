using System.ComponentModel;

namespace LesserKnown.NET;

public class Person : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name => $"{FirstName} {LastName}";

    // Gets triggered automatically whenever Name changes

    // https://github.com/Fody/PropertyChanged/wiki/On_PropertyName_Changed
    public void OnNameChanged() => Console.WriteLine($"Name Set to:{Name}");
}