using System;
using PBM_Reader.Common.Static;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "pbm 127.0.0.1:9100 cluster show";
            PowerShellHandling powerShellHandling = new PowerShellHandling();

            string output = powerShellHandling.ExecuteCommand(command);
            Console.WriteLine(output);

            powerShellHandling.Close();

            Console.ReadLine();
        }
    }
}
