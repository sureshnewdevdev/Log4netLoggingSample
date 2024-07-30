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

            Console.WriteLine("Enter your Choice");
            Console.WriteLine("Choices are 1-Read, 2-  write, 3 - exit");
            string choice = Console.ReadLine();

            while (choice != "3")
            {
                if (choice == "1")
                {
                    logger.LogInformation("Uer choice is One(read).");
                    logger.LogError("Uer choice is One(read).");

                }
                if (choice == "2")
                {
                    logger.LogWarning("Uer choice is two(write).");

                }
                if(choice == "3")
                {
                    logger.LogCritical($"Uer choice is three. selected time is {DateTime.Now.ToString()}");
                }
                choice = Console.ReadLine();
            }




            // Use the logger
            //logger.LogInformation("This is an information log.");
            //logger.LogWarning("This is a warning log.");
            //logger.LogError("This is an error log.");

            Console.WriteLine("Logging complete. Check the console output and log file.");

            Console.WriteLine();
            Console.Read();
        }
    }
}
