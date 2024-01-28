
using TerminalChad.Themes;

namespace TerminalChad.CLI.Setup;

internal class Setup
{
    private string baseDir = AppDomain.CurrentDomain.BaseDirectory;
    private string TerminalChadFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/";
    private string ThemeFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/";
    private string ActiveFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/";

    public void Init()
    {
        CreateFolders();
        ModifyPowershellConfig();

        if (!Directory.Exists($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/")) {
            Directory.CreateDirectory($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/");
        }
        ThemeLoader loader = new ThemeLoader();
        loader.LoadTheme("default");

        Console.WriteLine("Successfully Setup. Please start a new instance of Powershell Terminal for certain changes to take place");
    }

    private void CreateFolders()
    {
        CreateFolder(TerminalChadFolder);
        CreateFolder(ThemeFolder);
        CreateFolder(ActiveFolder);

        DirectoryInfo source = new DirectoryInfo($"{baseDir}/Themes");
        DirectoryInfo target = new DirectoryInfo(ThemeFolder);

        CopyFiles(source, target);
    }

    private void CreateFolder(string path)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
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

    private void CopyFiles(DirectoryInfo source, DirectoryInfo target)
    {
        Directory.CreateDirectory(target.FullName);

        foreach (var file in source.GetFiles())
        {
            try
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Success | {file.Name}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed  | {file.Name}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        foreach (var sourceSubDirectory in source.GetDirectories())
        {
            var targetSubDirectory = target.CreateSubdirectory(sourceSubDirectory.Name);
            CopyFiles(sourceSubDirectory, targetSubDirectory);
        }
    }
}
