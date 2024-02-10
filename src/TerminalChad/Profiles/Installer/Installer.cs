
using System.Diagnostics;
using TerminalChad.Profiles.Installer.Scripts;
using Newtonsoft.Json;

namespace TerminalChad.Profiles.Installer;

public class Installer
{
    public void DownloadApplication(SupportedApplications application)
    {
        // First create scripts just incase they don't exist
        ScriptCreator creator = new ScriptCreator();
        creator.CreateAllScripts();

        switch (application)
        {
            case SupportedApplications.GIT:
                if (isInstallable(application)) ; /*RunPSScript($"{GlobalVariables.ScriptsFolder}git.ps1");*/
                break;
        }
    }

    private bool isInstallable(SupportedApplications application)
    {
        bool returnValue = false;

        ApplicationInstallDateConfig? installConfig = JsonConvert.DeserializeObject<ApplicationInstallDateConfig>(File.ReadAllText(GlobalVariables.ApplicationInstallConfigFile));
        if (installConfig == null) return false;

        switch (application)
        {
            case SupportedApplications.GIT:
                if (installConfig.GitLastInstallTime.AddDays(1) <= DateTime.Now) returnValue = true;
                installConfig.GitLastInstallTime = DateTime.Now;
                break;
        }

        string json = JsonConvert.SerializeObject(installConfig);
        File.WriteAllText(GlobalVariables.ApplicationInstallConfigFile, json);

        return returnValue;
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
