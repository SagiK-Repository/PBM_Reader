using System.Collections.Generic;
using System.Diagnostics;

namespace PBM_Reader.Common.Static
{
    public class PowerShellHandling
    {
        private Process _process;

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

            _process = new Process();
            _process.StartInfo = psi;
            _process.Start();
        }

        public string ExecuteCommand(string command)
        {
            _process.StandardInput.WriteLine(command);
            _process.StandardInput.Close();

            string output = _process.StandardOutput.ReadToEnd();
            _process.WaitForExit();

            return output;
        }

        public List<string> ExecuteCommandLines(string command)
        {
            _process.StandardInput.WriteLine(command);
            _process.StandardInput.Close();

            List<string> lines = new List<string>();
            string line;
            while ((line = _process.StandardOutput.ReadLine()) != null)
            {
                lines.Add(line);
            }

            _process.WaitForExit();

            return lines;
        }

        public void Close()
        {
            _process.Close();
            _process.Dispose();
        }
    }
}
