
namespace TerminalChad.Profiles.Installer.Scripts;

public class ScriptCreator
{
    public void CreateAllScripts()
    {
        CreateWingetInstallScript("git.ps1", "--id Git.Git -e --source winget");
    }

    public void CreateWingetInstallScript(string filename, string arguments)
    {
        try
        {
            FileInfo path = new FileInfo($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/" + filename);
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
