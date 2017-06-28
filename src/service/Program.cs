using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace httpstub.service
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Quoting Api Nodes");

            var stub = new HttpStub();

            stub.Start();
        }
    }
}
