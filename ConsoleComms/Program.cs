using System;
using Grpc.Core;
using ServerComms;

namespace ConsoleComms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new Server
            {
                Services =
                {
                    CommsService.BindService(new CommsServiceImpl())
                },
                Ports =
                {
                    new ServerPort("localhost", 50051, ServerCredentials.Insecure)
                }
            };

            server.Start();

            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
