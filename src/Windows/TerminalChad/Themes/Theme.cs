using System.IO;

namespace TerminalChad.Themes;

public class Theme {
    // themeDirectory should never be updated. It will always point to the app data directory
    public static readonly string themeDirectory = Path.Combine(@$"C:\users\{Environment.UserName}\appdata\roaming\TerminalChad\Themes\");
    // themPath must be combination of themeDirectory and the theme name
    // When the theme is initialized, it should generate the themePath automatically from the themeName in case the theme was passed to another user
    public readonly string themeName = "default";
    public string themePath { get; private set; } = Path.Combine(@$"C:\users\{Environment.UserName}\appdata\roaming\TerminalChad\Themes\default\");

    // These are automatically generated every time a new theme is created
    private string PoshConfigLocation = String.Empty;
    private string PowershellProfileConfigLocation = String.Empty;
    private string StartupTextConfigLocation = String.Empty;
    private string TerminalConfigLocation = String.Empty;

    // These are the active config locations. These should not really be changed.
    private readonly string Active_PoshConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/config.json";
    private readonly string Active_ProfileConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1";
    private readonly string Active_StartUpTextConfigLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/startup-text.ps1";
    private readonly string Active_TerminalConfigLocation = $@"C:\Users\{Environment.UserName}\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json";

    public Theme() {
        GenerateConfigLocations();
        themePath = Path.Combine(themeDirectory, themeName);
    }

    public Theme(bool fromCurrentState, string themeName) {
        if (fromCurrentState) {
            GenerateConfigLocationsForSaving(themeName);
            Console.WriteLine("Creating New Theme from Current State");
            this.themeName = themeName;
            themePath = Path.Combine(themeDirectory, themeName);
            SaveTheme();
            Console.WriteLine("Theme Created Successfully!");
            Console.WriteLine($"Theme Location: {themePath}");
        } else {
            throw new NotImplementedException();
        }
    }

    public Theme(string path) {
        if (!Directory.Exists(path)) {
            Console.WriteLine("Error Loading Theme: The Provided Directory Doesn't Exist!");
            return;
        }
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
        CopyTheme();
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
