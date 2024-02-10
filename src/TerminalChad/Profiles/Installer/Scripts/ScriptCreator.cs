
namespace TerminalChad.Profiles.Installer.Scripts;

public class ScriptCreator
{
    public void CreateAllScripts()
    {
        DeleteAllScripts();

        CreateWingetInstallScript("git.ps1", "--id Git.Git -e --source winget");
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
