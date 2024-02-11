﻿
namespace TerminalChad.Profiles.Installer.Scripts;

public class ScriptCreator
{
    public void CreateAllScripts()
    {
        DeleteAllScripts();

        CreateWingetInstallScript("git.ps1", "--id Git.Git -e --source winget");
        CreateWingetInstallScript("firefox.ps1", "-e --id Mozilla.Firefox");
        CreateWingetInstallScript("neovim.ps1", "--id=Neovim.Neovim  -e");
        CreateWingetInstallScript("visualstudios.ps1", "--id Microsoft.VisualStudio.2022.Community");
        CreateWingetInstallScript("vscode.ps1", "-e --id Microsoft.VisualStudioCode");
        CreateWingetInstallScript("dotnet.ps1", "winget install Microsoft.DotNet.SDK.8");
    }

    public void DeleteAllScripts()
    {
        string[] CurrentInstallScripts = Directory.GetFiles(GlobalVariables.ScriptsFolder);
        foreach (string c in CurrentInstallScripts)
        {
            try
            {
                File.Delete(c);
            }
            catch
            {
                Console.WriteLine("Failed to delete script");
            }
        }
    }

    public void CreateWingetInstallScript(string filename, string arguments)
    {
        try
        {
            FileInfo path = new FileInfo(GlobalVariables.ScriptsFolder + filename);
            if (path.Exists)
            {
                File.Delete(path.FullName);
                File.Create(path.FullName);
            }

            string compiledText = $@"C:\Users\{Environment.UserName}\AppData\Local\Microsoft\WindowsApps\winget.exe install " + arguments;

            File.WriteAllText(path.FullName, compiledText);
        }
        catch
        {
            Console.WriteLine($"Failed to create a valid install script for: '{filename}'");
        }
    }
}
