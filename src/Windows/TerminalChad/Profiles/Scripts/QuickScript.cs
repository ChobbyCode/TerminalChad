
using System.Diagnostics;

namespace TerminalChad.Profiles.Scripts;
public class QuickScript {
    FileInfo ScriptPath { get; set; } = new FileInfo("C:\\Path\\To\\Script.ps1");

    string Name { get; set; } = "New Quick Script";
    string Description { get; set; } = "New Quick Script Description";

    public void Run() {
        bool valid = VerifyFilePath();
        if (!valid) {
            Console.WriteLine("The provided script path is not valid. Aborting execution.");
            return;
        }

        string[] scriptLines = File.ReadAllLines(ScriptPath.FullName);
        Console.WriteLine($"Executing script '{Name}':");
        ExecuteScript();

    }
    
    private void ExecuteScript() {
        try {
            ProcessStartInfo startInfo = new() {
                FileName = ResolvePowerShellExecutable(),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            startInfo.ArgumentList.Add("-NoLogo");
            startInfo.ArgumentList.Add("-NoProfile");
            startInfo.ArgumentList.Add("-ExecutionPolicy");
            startInfo.ArgumentList.Add("Bypass");
            startInfo.ArgumentList.Add("-File");
            startInfo.ArgumentList.Add(ScriptPath.FullName);

            using Process process = Process.Start(startInfo)!;
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (!string.IsNullOrWhiteSpace(output)) {
                Console.WriteLine(output);
            }

            if (!string.IsNullOrWhiteSpace(error)) {
                Console.Error.WriteLine(error);
            }
        }
        catch (Exception ex) {
            Console.Error.WriteLine($"Failed to execute script: {ex.Message}");
        }
    }
    private static string ResolvePowerShellExecutable() =>
        OperatingSystem.IsWindows() ? "powershell.exe" : "pwsh";

    // TO DO: Expand this method to provide a more detailed version of verifying the file.
    private bool VerifyFilePath() => ScriptPath.Exists;
}
