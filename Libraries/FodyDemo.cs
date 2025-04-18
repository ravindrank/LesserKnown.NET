﻿using System.ComponentModel;

// Fody https://github.com/Fody/PropertyChanged/wiki/On_PropertyName_Changed

namespace LesserKnown.NET;

public class Person : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name => $"{FirstName} {LastName}";
    // Gets triggered automatically whenever Name changes
    public void OnNameChanged() => Console.WriteLine($"Name Set to:{Name}");
}

public class FodyDemo : MainDemo
{
    public void Run()
    {
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

        EndDemo();
    }
}