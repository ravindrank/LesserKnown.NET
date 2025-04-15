using Polly;

namespace LesserKnown.NET;

public class PollyDemo
{
    public void Run()
    {
        Console.WriteLine("------------------------------------------ POLLY DEMO START ------------------------------------------");
        var retryPolicy = Policy
            .Handle<Exception>()
            .Retry(10, (exception, timeSpan) =>
            {
                Console.WriteLine($"Retrying due to: {exception.Message}");
            });
        retryPolicy.Execute(() =>
        {
            // Simulate a method that may fail
            Console.WriteLine("Executing risky operation...");
            throw new Exception("Simulated failure");
        });
        Console.WriteLine("------------------------------------------ POLLY DEMO END ------------------------------------------");
    }        

}