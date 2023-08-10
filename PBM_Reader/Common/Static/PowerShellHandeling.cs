using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PBM_Reader.Common.Static
{
    public class PowerShellHandling
    {
        private Process process;

        public PowerShellHandling()
        {
            InitializeProcess();
        }

        private void InitializeProcess()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "powershell.exe";
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            process = new Process();
            process.StartInfo = psi;
            process.Start();
        }

        public string ExecuteCommand(string command)
        {
            process.StandardInput.WriteLine(command);
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }

        public List<string> ExecuteCommandLines(string command)
        {
            process.StandardInput.WriteLine(command);
            process.StandardInput.Close();

            List<string> lines = new List<string>();
            string line;
            while ((line = process.StandardOutput.ReadLine()) != null)
            {
                lines.Add(line);
            }

            process.WaitForExit();

            return lines;
        }

        public string ExecuteCommands(string command)
        {
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("Write-Output -NoEnumerate 'COMMAND_EXECUTED'"); // 명령 실행 완료 신호 추가
            process.StandardInput.Flush();

            string output = "";
            string line;
            while ((line = process.StandardOutput.ReadLine()) != null)
            {
                if (line.Trim().Equals("COMMAND_EXECUTED", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                output += line + Environment.NewLine;
            }

            process.WaitForExit();

            return output;
        }

        public void Close()
        {
            process.Close();
            process.Dispose();
        }
    }
}
