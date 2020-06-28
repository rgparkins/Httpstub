using System;

namespace rgparkins.HttpStub.service
{
    class Program
    {
        public static void Main(string[] args)
        {
            var PORT = 8000;
            Console.WriteLine("Welcome to the Http stub");

            var stub = new HttpStub(PORT);

            stub.Start();
        }
    }
}
