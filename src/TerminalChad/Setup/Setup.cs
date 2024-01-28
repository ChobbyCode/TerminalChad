
using TerminalChad.Themes;

namespace TerminalChad.CLI.Setup;

internal class Setup
{
    private string baseDir = AppDomain.CurrentDomain.BaseDirectory;

    public void Init()
    {
        ModifyPowershellConfig();

        if (!Directory.Exists($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/")) {
            Directory.CreateDirectory($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/");
        }
        ThemeLoader loader = new ThemeLoader();
        loader.LoadTheme("default");
    }

    private void ModifyPowershellConfig()
    {
        var PowerhellConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\WindowsPowerShell\Microsoft.PowerShell_profile.ps1";
        string writeText = $"invoke-expression -Command \"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1\"";
        File.WriteAllText(PowerhellConfigFile, writeText);
    }
}
