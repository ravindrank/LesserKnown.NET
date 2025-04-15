using Polly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LesserKnown.NET.Tips
{
    public class CancTokensDemo:MainDemo
    {
        
        // Source : https://codewithmukesh.com/blog/20-tips-from-a-senior-dotnet-developer/#7-cancellation-tokens-are-important

        // Bad Example(Ignoring Cancellation)
        /*
        //[HttpGet("long-task1")]
        public async Task<IActionResult> LongRunningTask1()
        {
            await Task.Delay(5000); // Simulating long task
            return Ok("Task Completed");
        }

        // Here, if the user cancels the request, the server still processes the full 5-second delay, wasting resources.In real world scenarios, this could be even a very costly database query.

        // Better Example (Using Cancellation Tokens)

        //[HttpGet("long-task2")]
        public async Task<IActionResult> LongRunningTask2(CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(5000, cancellationToken); // Task can be canceled
                return Ok("Task Completed");
            }
            catch (TaskCanceledException)
            {
                return StatusCode(499, "Client closed request"); // 499 is a common status for client cancellations
            }
        }


        //  Here, if the client cancels the request, the Task.Delay throws a TaskCanceledException, and the operation stops immediately

        // Example: Passing Cancellation Token to Database Queries
        //If you’re executing database queries using Entity Framework Core, always pass the cancellation token:
        void dbCall()
        {
            var users = await _context.Users
                .Where(u => u.IsActive)
                .ToListAsync(cancellationToken);
        }
        //This ensures that if the request is canceled, the database query also stops execution, preventing unnecessary load on the database.

        //Handling Cancellation in Background Tasks
        //When running background tasks in worker services or hosted services, cancellation tokens ensure they stop gracefully when the application shuts down.

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWorkAsync(stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }

        // Here, the loop checks stoppingToken.IsCancellationRequested to exit gracefully instead of continuing indefinitely.
        */
        
    }
}
