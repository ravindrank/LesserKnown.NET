using OllamaSharp;

namespace LesserKnown.NET;

public class LLMDemo: MainDemo
{
    private Uri uri;
    private OllamaApiClient ollama;
    private void Init()
    {
        uri = new Uri("http://localhost:11434");
        ollama = new OllamaApiClient(uri);
        ollama.SelectedModel = "deepseek-r1:1.5b";
    }

    private async Task<string> GenerateDetailsUsingLLM(string? projectName, string? projectType, string? domains, string? technologies)
    {

        var chat = new Chat(ollama);
        string result = string.Empty;
        const int MaxWords = 30;
        const string cleanupEnd = "</think>";
        string prompt = $"Generate a summary within {MaxWords} words for a technical project having a project type of {projectType} involving domains like {domains} and technologies like {technologies}";

        Console.WriteLine($"\nUsing prompt:{prompt}");

        await foreach (var answerToken in chat.SendAsync(prompt))
            result += answerToken;

        //Console.WriteLine($"\nGot result:{result}\n Cleaning up...");

        var thinkEnd = result.IndexOf(cleanupEnd);
        var final = result
            .Substring(thinkEnd + cleanupEnd.Length)
            .Replace("\n", "")
            .Replace("\t", "")
            .Replace("\\", "")
            .Replace("\"", "")
            .Replace("**Summary:**", "");

        Console.WriteLine($"\nGenerated Summary:\n{final}");
        return final;
    }

    public void Run()
    {
        Init();
        GenerateDetailsUsingLLM("DemoProject", "Web App", "Finance, Health", "C#, .NET, SQL Server").Wait();
        EndDemo();
    }
}
