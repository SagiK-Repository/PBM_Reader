using System.Diagnostics;

string command = "Get-Process"; // 실행할 PowerShell 명령어

ProcessStartInfo psi = new ProcessStartInfo();
psi.FileName = "powershell.exe";
psi.Arguments = $"-Command \"{command}\"";
psi.RedirectStandardOutput = true;
psi.UseShellExecute = false;

Process process = new Process();
process.StartInfo = psi;
process.Start();

string output = process.StandardOutput.ReadToEnd();
Console.WriteLine(output);

process.Start();
string output1 = process.StandardOutput.ReadToEnd();
process.WaitForExit();

Console.WriteLine(output1);