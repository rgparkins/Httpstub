using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace service
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Quoting Api Nodes");

            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var builder = new WebHostBuilder()
                .UseKestrel()
                .ConfigureServices(services =>  {
                    services.AddSingleton<RequestCache>();
                })
                .UseStartup<Startup>()
                .UseUrls("http://*:8099");

            var host = builder.Build();
            host.Run();
        }
    }
}
