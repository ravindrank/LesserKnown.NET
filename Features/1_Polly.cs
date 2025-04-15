using Polly;

namespace LesserKnown.NET;

public class PollyDemo: MainDemo
{
    const int retryCount = 10;
    public void Run()
    {
        var retryPolicy = Policy
            .Handle<Exception>()
            .Retry(retryCount, (exception, timeSpan) =>
            {
                Console.WriteLine($"Retrying due to: {exception.Message}");
            });
        retryPolicy.Execute(() =>
        {
            // Simulate a method that may fail
            Console.WriteLine("Executing risky operation...");

            //throw new Exception("Simulated failure");
        });
        EndDemo();
    }        

}