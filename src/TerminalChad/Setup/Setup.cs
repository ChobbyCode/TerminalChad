
using TerminalChad.Themes;

namespace TerminalChad.CLI.Setup;

internal class Setup
{
    private string baseDir = AppDomain.CurrentDomain.BaseDirectory;
    private string ThemeFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/";

    public void Init()
    {
        ModifyPowershellConfig();

        if (!Directory.Exists($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/")) {
            Directory.CreateDirectory($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/");
        }
        ThemeLoader loader = new ThemeLoader();
        loader.LoadTheme("default");

        Console.WriteLine("Successfully Setup. Please start a new instance of Powershell Terminal for certain changes to take place");
    }

    private void ModifyPowershellConfig()
    {
        var PowerhellConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\WindowsPowerShell\Microsoft.PowerShell_profile.ps1";
        string writeText = $"invoke-expression -Command \"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1\"";
        File.WriteAllText(PowerhellConfigFile, writeText);
    }

    private void UpdateLocalThemes()
    {
        File.Copy(baseDir + @"\Themes", ThemeFolder);
    }
}
