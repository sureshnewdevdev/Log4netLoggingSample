using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore;

namespace Log4netLoggingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure
                    .AddLog4Net(@"C:\Source\Dotnet\logfournet\Log4netLoggingSample\log4net.config"))
                .BuildServiceProvider();

            // Get a logger
            var logger = serviceProvider.GetService<ILogger<Program>>();

            // Use the logger
            logger.LogInformation("This is an information log.");
            logger.LogWarning("This is a warning log.");
            logger.LogError("This is an error log.");

            Console.WriteLine("Logging complete. Check the console output and log file.");

            Console.WriteLine();
            Console.Read();
        }
    }
}
