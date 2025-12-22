using System.IO;

namespace TerminalChad.Themes;

public class Theme {
    public readonly string themeDirectory = Path.Combine(@$"C:\users\{Environment.UserName}\appdata\roaming\TerminalChad\Themes\");
    public readonly string themePath = Path.Combine(@$"C:\users\{Environment.UserName}\appdata\roaming\TerminalChad\Themes\default\");
    private string PoshConfigLocation = String.Empty;
    private string PowershellProfileConfigLocation = String.Empty;
    private string StartupTextConfigLocation = String.Empty;
    private string TerminalConfigLocation = String.Empty;

    private string Active_PoshConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/config.json";
    private string Active_ProfileConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1";
    private string Active_StartUpTextConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/startup-text.ps1";
    private string Active_TerminalConfigLocation = $@"C:\Users\{Environment.UserName}\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json";

    public Theme(bool fromCurrentState, string themeName) {
        GenerateConfigLocationsForSaving(themeName);
        Console.WriteLine("Creating New Theme from Current State");
        themePath = Path.Combine(themeDirectory, themeName);
        SaveTheme();
        Console.WriteLine("Theme Created Successfully!");
        Console.WriteLine($"Theme Location: {themePath}");
    }

    public Theme(string path) {
        themePath = path;
        GenerateConfigLocations();
    }

    public Theme(DirectoryInfo path) {
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
        if(!Directory.Exists(themePath)) {
            Directory.CreateDirectory(themePath);
        }
        if(!File.Exists(PoshConfigLocation)) {
            File.Create(PoshConfigLocation).Close();
        }
        if(!File.Exists(PowershellProfileConfigLocation)) {
            File.Create(PowershellProfileConfigLocation).Close();
        }
        if(!File.Exists(StartupTextConfigLocation)) {
            File.Create(StartupTextConfigLocation).Close();
        }
        if(!File.Exists(TerminalConfigLocation)) {
            File.Create(TerminalConfigLocation).Close();
        }

        File.Copy(Active_PoshConfigLocation, PoshConfigLocation, true);
        File.Copy(Active_ProfileConfigLocation, PowershellProfileConfigLocation, true);
        File.Copy(Active_StartUpTextConfigLocation, StartupTextConfigLocation, true);
        File.Copy(Active_TerminalConfigLocation, TerminalConfigLocation, true);
    }

    private void GenerateConfigLocations() {
        PoshConfigLocation = Path.Combine(themePath, "config.json");
        PowershellProfileConfigLocation = Path.Combine(themePath, "profile.ps1");
        StartupTextConfigLocation = Path.Combine(themePath, "startup-text.ps1");
        TerminalConfigLocation = Path.Combine(themePath, "settings.json");
    }

    private void GenerateConfigLocationsForSaving(string name) {
        PoshConfigLocation = Path.Combine(themeDirectory, $"{name}\\", "config.json");
        PowershellProfileConfigLocation = Path.Combine(themeDirectory, $"{name}\\", "profile.ps1");
        StartupTextConfigLocation = Path.Combine(themeDirectory, $"{name}\\", "startup-text.ps1");
        TerminalConfigLocation = Path.Combine(themeDirectory, $"{name}\\", "settings.json");
    }
}
