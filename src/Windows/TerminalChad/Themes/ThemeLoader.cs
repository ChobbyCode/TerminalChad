using System.Diagnostics;

namespace TerminalChad.Themes;

internal class ThemeLoader
{
    private string ThemeFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/";
    private string Theme = "default";

    // List of all the special locations that are modified by a theme
    private string PoshConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/config.json";
    private string ProfileConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1";
    private string StartUpTextConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/startup-text.ps1";
    private string TerminalConfigLocation = $@"C:\Users\{Environment.UserName}\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json";

    public void LoadTheme(string theme)
    {
        Theme = theme.ToLower();
        if(Directory.Exists(Path.Combine(ThemeFolder, theme)))
        {
            CopyTheme();
            Console.WriteLine("Theme installed. Please start a new instance of Powershell Terminal for certain changes to take place");
        }else
        {
            Console.WriteLine("Theme doesn't exist");
        }
    }

    private void CopyTheme()
    {
        CopyPosh();
        CopyScripts();
        CopyTerminalConfig();
    }

    private void CopyPosh()
    {
        File.Copy($"{ThemeFolder}{Theme}/config.json", PoshConfigLocation, true);
    }

    private void CopyScripts()
    {
        File.Copy($"{ThemeFolder}{Theme}/profile.ps1", ProfileConfigLocation, true);
        File.Copy($"{ThemeFolder}{Theme}/startup-text.ps1", StartUpTextConfigLocation, true);
    }

    private void CopyTerminalConfig()
    {
        File.Copy($"{ThemeFolder}{Theme}/settings.json", TerminalConfigLocation, true);
    }
}
