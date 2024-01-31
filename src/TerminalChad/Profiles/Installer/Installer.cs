
using System.Diagnostics;
using TerminalChad.Profiles.Installer.Scripts;

namespace TerminalChad.Profiles.Installer;

public class Installer
{
    private string ScriptsFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/";

    public void DownloadApplication(SupportedApplications application)
    {
        // First create scripts just incase they don't exist
        ScriptCreator creator = new ScriptCreator();
        creator.CreateAllScripts();

        switch (application)
        {
            case SupportedApplications.GIT:
                RunPSScript($"{ScriptsFolder}git.ps1");
                break;
        }
    }

    public void RunPSScript(string path)
    {
        ExecuteScript(path);
    }

    public void ExecuteScript(string pathToScript)
    {
        var scriptArguments = "-ExecutionPolicy Bypass -File \"" + pathToScript + "\"";
        var processStartInfo = new ProcessStartInfo("powershell.exe", scriptArguments);
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardError = true;

        using var process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        Console.WriteLine(output); // I am invoked using ProcessStartInfoClass!
    }
}
