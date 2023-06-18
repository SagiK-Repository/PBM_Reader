using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter IP address:");
            string ipAddress = Console.ReadLine();

            Console.WriteLine("Enter port:");
            int port = int.Parse(Console.ReadLine());

            // Petabridge 서버에 연결
            using (TcpClient client = new TcpClient(ipAddress, port))
            {
                NetworkStream stream = client.GetStream();

                // "cluster show" 명령어 전송
                byte[] commandBytes = Encoding.ASCII.GetBytes("cluster show\n");
                stream.Write(commandBytes, 0, commandBytes.Length);

                // 결과 수신
                byte[] buffer = new byte[4096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string result = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                // 결과 출력
                Console.WriteLine("Cluster show result:");
                Console.WriteLine(result);
            }

        }
    }
}
