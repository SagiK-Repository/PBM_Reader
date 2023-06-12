using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PBM_Reader.Common.Static
{
    using System;
    using System.Diagnostics;

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

        public void Close()
        {
            process.Close();
            process.Dispose();
        }
    }
}
