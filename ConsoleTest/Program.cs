using Akka.Actor;
using Petabridge.Cmd.Common.Client;
using Petabridge.Cmd.Remote;
using System;
using System.Threading.Tasks;

namespace MyAkkaApp
{
    public static class Program
    {
        public static async Task Main()
        {
            var host = "127.0.0.1";
            var port = 9100;

            // Create a Petabridge.Cmd client
            var client = await PetabridgeCmdClient.CreateAsync(host, port);

            // Send "cluster show" command to the remote server
            var response = await client.ExecCommandAsync("cluster show");

            // Display response from the remote server
            Console.WriteLine(response);

            // Shutdown the client
            await client.ShutdownAsync();
        }
    }
}
