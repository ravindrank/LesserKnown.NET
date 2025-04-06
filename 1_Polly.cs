﻿using Polly;
using Polly.Extensions.Http;

namespace LesserKnown.NET
{
    public class PollyDemo
    {
        public void Run()
        {
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
        }        

    }

}