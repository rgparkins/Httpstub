using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Parkwell.HttpStub.service
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Http stub");

            var stub = new HttpStub(8000);

            stub.Start();
        }
    }
}
