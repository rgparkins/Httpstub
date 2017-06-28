using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace httpstub
{
    public class HttpStub : IDisposable
    {
        private IWebHost host;

        public HttpStub(int port = 8005)
        {
            var config = new ConfigurationBuilder()
                            .AddEnvironmentVariables()
                            .Build();

            host = new WebHostBuilder()
                .UseKestrel()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<RequestCache>();
                })
                .UseStartup<Startup>()
                .UseUrls("http://*:"+ port).Build();
        }

        public int Port { get; private set; }

        public void Dispose()
        {
            host?.Dispose();
        }

        public void Start()
        {
            host.Start();
        }
    }
}