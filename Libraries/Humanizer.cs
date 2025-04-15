using Humanizer;
using System.ComponentModel;
namespace LesserKnown.NET;

internal class HumanizerDemo
{
    public void Run()
    {
        // https://github.com/Humanizr/Humanizer

        // Humanizer is a library that converts enums, dates, timespans, and other types to human readable strings.
        TimeSpan timeSpan = TimeSpan.FromDays(1);
        Console.WriteLine(timeSpan.Humanize()); // Output: "one day" 
        Console.WriteLine(DateTime.UtcNow.AddHours(-30).Humanize());
        Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
        Console.WriteLine(DateTime.UtcNow.AddHours(30).Humanize());
        Console.WriteLine(DateTime.UtcNow.AddHours(2).Humanize());
        Console.WriteLine(DateTimeOffset.UtcNow.AddHours(1).Humanize());

        // Humanizer can also be used to convert enum values to human readable strings.

        // DescriptionAttribute is honored
        Console.WriteLine(EnumUnderTest.MemberWithDescriptionAttribute.Humanize());

        // In the absence of Description attribute string.Humanizer kicks in
        Console.WriteLine(EnumUnderTest.MemberWithoutDescriptionAttribute.Humanize());

        // Of course you can still apply letter casing
        Console.WriteLine(EnumUnderTest.MemberWithoutDescriptionAttribute.Humanize().Transform(To.TitleCase));

        // Dasherize and Hyphenate replace underscores with dashes in the string
        Console.WriteLine("some_title".Dasherize());
        Console.WriteLine("some_title".Hyphenate());
    }
}

public enum EnumUnderTest
{
    [Description("Custom description")]
    MemberWithDescriptionAttribute,
    MemberWithoutDescriptionAttribute,
    ALLCAPITALS
}