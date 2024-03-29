﻿
using System.Diagnostics;
using TerminalChad.Setup;
using TerminalChad.Themes;

namespace TerminalChad.CLI.Setup;

internal class Setup
{
    private string _baseDir = AppDomain.CurrentDomain.BaseDirectory;
    private string _terminalChadFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/";
    private string _themeFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/";
    private string _activeFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/";

    public void Init()
    {
        DirectorySetup st = new DirectorySetup();
        st.CreateDirectories();

        CreateFolders();
        ModifyPowershellConfig();

        if (!Directory.Exists($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/")) {
            Directory.CreateDirectory($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/");
        }

        ThemeDownloader downloader = new();
        downloader.DownloadThemeZip("chobbycode.terminalchadthemes", "/", true);

        ThemeLoader loader = new ThemeLoader();
        loader.LoadTheme("default");
        Console.WriteLine("Installing Themes");

        Console.WriteLine("Successfully Setup. Please start a new instance of Powershell Terminal for certain changes to take place \n");
    }

    private void CreateFolders()
    {
        CreateFolder(_terminalChadFolder);
        CreateFolder(_themeFolder);
        CreateFolder(_activeFolder);

        // Redundant as it downloads externally now

        /*DirectoryInfo source = new DirectoryInfo($"{_baseDir}/Themes");
        DirectoryInfo target = new DirectoryInfo(_themeFolder);

        CopyFiles(source, target);*/
    }

    private void CreateFolder(string path)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
    }

    private void ModifyPowershellConfig()
    {
        try
        {
            CreatePowershellConfig();
            // This is prob not needed
            for (int i = 0; i < 10; i++)
            {
                var PowerhellConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\WindowsPowerShell\Microsoft.PowerShell_profile.ps1";
                string writeText = $"invoke-expression -Command \"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1\"";
                File.WriteAllText(PowerhellConfigFile, writeText);
            }
        }catch { }
    }

    private void CreatePowershellConfig()
    {
        var PowershellFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\WindowsPowerShell\";
        var PowershellConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\WindowsPowerShell\Microsoft.PowerShell_profile.ps1";

        if (!Directory.Exists(PowershellFolder)) Directory.CreateDirectory(PowershellFolder);
        if (!File.Exists(PowershellConfigFile)) File.Create(PowershellConfigFile);

        StreamWriter sw = new StreamWriter(PowershellConfigFile);
        try
        {
            sw.Write($"invoke-expression -Command \"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1\"");
            sw.Write($"invoke-expression -Command \"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1\"");
        }
        catch { } finally { sw.Close(); }
    }

    private void UpdateLocalThemes()
    {
        File.Copy(Path.Combine(_baseDir, "\\Themes"), _themeFolder);
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
                Console.WriteLine($"Success | {file.Directory.Name}.{file.Name}");
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
