using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        using (PowerShell powerShell = PowerShell.Create())
        {
            while (true)
            {
                // 0.5초 동안 쉽니다.
                Thread.Sleep(500);

                // 사용자의 입력을 받습니다.
                Console.Write("Input Command or press ENTER to skip: ");
                string input = Console.ReadLine();

                // 입력이 ""인 경우 생략하고 다음 루프로 넘어갑니다.
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                // PowerShell 명령어를 실행합니다.
                powerShell.AddScript(input);
                powerShell.Streams.ClearStreams();
                var results = powerShell.Invoke();

                // PowerShell 명령어 실행 결과를 출력합니다.
                Console.WriteLine("Results:");
                foreach (var result in results)
                {
                    Console.WriteLine(result.ToString());
                }
            }
        }
    }
}
