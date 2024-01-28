
namespace TerminalChad.CLI.Setup;

internal class Setup
{
    private string baseDir = AppDomain.CurrentDomain.BaseDirectory;

    public void Init()
    {
        ModifyTerminalConfig();
        ModifyPowershellConfig();
    }

    private void ModifyTerminalConfig()
    {
        string TerminalConfigFile = $@"C:\Users\{Environment.UserName}\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json";
        File.Copy(baseDir + @"\Config\Terminal\settings.json", TerminalConfigFile, true);
    }

    private void ModifyPowershellConfig()
    {
        // Sorry For The Code Below :) This code is messy because I can't be bothered to do it more efficiently & it works!

        // I sure do love powerhell
        var PowerhellConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\WindowsPowerShell\Microsoft.PowerShell_profile.ps1";
        // I love powershell in CSharp files
        string writeText = $"invoke-expression -Command \"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/profile.ps1\"";
        File.WriteAllText(PowerhellConfigFile, writeText);

        // Add the files to the appdata directory
        string ProfileWriteLoc = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/profile.ps1";
        File.Copy(@$"{baseDir}\Config\PowerShell\profile.ps1", ProfileWriteLoc, true);
        string StartupTextWriteLoc = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/startup-text.ps1";
        File.Copy(@$"{baseDir}\Config\PowerShell\startup-text.ps1", StartupTextWriteLoc, true);

        if(!Directory.Exists($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Config")) Directory.CreateDirectory($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Config");
        if (!Directory.Exists($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Config/Posh/")) Directory.CreateDirectory($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Config/Posh/");
        File.Copy(@$"{baseDir}\Config\Posh\config.json", $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Config/Posh/config.json", true);
    }
}
