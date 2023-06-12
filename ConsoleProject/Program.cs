using PBM_Reader.Common.Static;

string command = "Get-Process";
PowerShellHandling powerShellHandling = new PowerShellHandling();

List<string> outputLines = powerShellHandling.ExecuteCommandLines(command);

for (int i = 0; i < outputLines.Count; i++)
    Console.WriteLine($"[{i}] - {outputLines[i]}");