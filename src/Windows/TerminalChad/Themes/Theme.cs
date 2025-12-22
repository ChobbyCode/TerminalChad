using System.IO;

namespace TerminalChad.Themes;

public class Theme {
    public readonly string themeDirectory = Path.Combine(@$"C:\users\{Environment.UserName}\appdata\roaming\TerminalChad\Themes\");
    public readonly string themePath = Path.Combine(@$"C:\users\{Environment.UserName}\appdata\roaming\TerminalChad\Themes\default");
    private string PoshConfigLocation = String.Empty;
    private string PowershellProfileConfigLocation = String.Empty;
    private string StartupTextConfigLocation = String.Empty;
    private string TerminalConfigLocation = String.Empty;

    private string Active_PoshConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/config.json";
    private string Active_ProfileConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1";
    private string Active_StartUpTextConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/startup-text.ps1";
    private string Active_TerminalConfigLocation = $@"C:\Users\{Environment.UserName}\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json";

    Theme(bool fromCurrentState, string themeName) {
        Console.WriteLine("Creating New Theme from Current State");
        themePath = Path.Combine(themeDirectory, themeName);
        SaveTheme();
        Console.WriteLine("Theme Created Successfully!");
        Console.WriteLine($"Theme Location: {themePath}");
    }

    Theme(string path) {
        themePath = path;
        GenerateConfigLocations();
    }

    Theme(DirectoryInfo path) {
        themePath = path.FullName;
        GenerateConfigLocations();
    }

    public void Use() {
        if (!Directory.Exists(themePath)) {
            Console.WriteLine("Error Loading Theme: Theme Doesn't Exist!");
            return;
        }
        
    }

    private void CopyTheme() {
        File.Copy(PoshConfigLocation, Active_PoshConfigLocation, true);
        File.Copy(PowershellProfileConfigLocation, Active_ProfileConfigLocation, true);
        File.Copy(StartupTextConfigLocation, Active_StartUpTextConfigLocation, true);
        File.Copy(TerminalConfigLocation, Active_TerminalConfigLocation, true);
    }

    private void SaveTheme() {
        File.Copy(Active_PoshConfigLocation, PoshConfigLocation, true);
        File.Copy(Active_ProfileConfigLocation, PowershellProfileConfigLocation, true);
        File.Copy(Active_StartUpTextConfigLocation, StartupTextConfigLocation, true);
        File.Copy(Active_TerminalConfigLocation, TerminalConfigLocation, true);
    }

    private void GenerateConfigLocations() {
        PoshConfigLocation = Path.Combine(themePath, "\\config.json");
        PowershellProfileConfigLocation = Path.Combine(themePath, "\\profile.ps1");
        StartupTextConfigLocation = Path.Combine(themePath, "\\startup-text.ps1");
        TerminalConfigLocation = Path.Combine(themePath, "\\settings.ps1");
    }
}
