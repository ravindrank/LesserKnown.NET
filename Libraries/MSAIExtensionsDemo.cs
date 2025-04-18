using Microsoft.Extensions.AI;
using System.ComponentModel;

namespace LesserKnown.NET;

public class MSAIExtensionsDemo : MainDemo
{
    public async Task<string> DemoAsync()
    {
        IChatClient ollamaClient = new OllamaChatClient(new Uri("http://localhost:11434/"), "llama3.1");

        IChatClient client = new ChatClientBuilder(ollamaClient)
        .UseFunctionInvocation()
        .Build();

        [Description("Gets the weather")]
        static string GetWeather() => Random.Shared.NextDouble() > 0.5 ? "It's sunny" : "It's raining";

        ChatOptions chatOptions = new()
        {
            Tools = [AIFunctionFactory.Create(GetWeather)]
        };
        string result = string.Empty;
        try
        {
            ChatResponse response = await client.GetResponseAsync("Do I need an umbrella?", chatOptions);
            result = response.Text;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return result;
    }
    public async void Run()
    {
        var response = await DemoAsync();
        Console.WriteLine(response);
        EndDemo();
    }
}
