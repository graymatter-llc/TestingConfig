using System;
using System.IO;
using System.Collections;
using Microsoft.Extensions.Configuration;

namespace TestingConfig
{
    class Program
    {

        static void Main(string[] args)
        {
            String releaseType = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            // See what variable is set for a Console App
            releaseType ??= "Local";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{releaseType}.json", optional: true)
                .AddUserSecrets<Program>(optional: true);

            IConfiguration config = builder.Build();

            Console.WriteLine();
            Console.WriteLine("GetEnvironmentVariables: ");
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                Console.WriteLine("  {0} = {1}", de.Key, de.Value);

            Console.WriteLine($"Arguments: {args.Length}");
            foreach (String arg in args)
                Console.Write(arg + " ");
            Console.WriteLine("\n");
            Console.WriteLine("Hello World!");
            Console.WriteLine("releaseType: " + releaseType);
            // This is coming from Secrets
            Console.WriteLine("Secret: "+(config.GetSection("ConnectionStrings")["default"]));
            Console.WriteLine("Non-Secret: " + (config.GetSection("ConnectionStrings")["myDb2"]));
        }
    }
}
