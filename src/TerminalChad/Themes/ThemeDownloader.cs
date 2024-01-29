
using System.IO.Compression;
using System.Net;
using TerminalChad.CLI;

namespace TerminalChad.Themes;

public class ThemeDownloader
{
    public bool DownloadThemeZip(string url, string name, bool master = false)
    {
        string[] s = url.Split(new char[] {'.'});
        if (s.Length != 2) return false;
        string path;
        if(master) path = "https://github.com/" + s[0] + "/" + s[1] + "/zipball/master";
        else path = "https://github.com/" + s[0] + "/" + s[1] + "/zipball/main";

        string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        // Temp directories & stuff
        if (Directory.Exists(baseDir + @"\tmp\")) Directory.Delete(baseDir + @"\tmp\", true);
        if (Directory.Exists(baseDir + @"\tmp\files\")) Directory.Delete(baseDir + @"\tmp\files\", true);

        if (!Directory.Exists(baseDir + @"\tmp\")) Directory.CreateDirectory(baseDir + @"\tmp\");
        if (!Directory.Exists(baseDir + @"\tmp\zip")) Directory.CreateDirectory(baseDir + @"\tmp\zip");
        if (!Directory.Exists(baseDir + @"\tmp\dez")) Directory.CreateDirectory(baseDir + @"\tmp\dez");
        if (!Directory.Exists(baseDir + @"\tmp\files\")) Directory.CreateDirectory(baseDir + @"\tmp\files\");

        Console.WriteLine("Downloading Latest Version: ");
        Console.Write("Fetching Files From: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(path);
        Console.ForegroundColor = ConsoleColor.White;
        using (var client = new WebClient())
        {
            client.DownloadFile(path, baseDir + @"\tmp\zip\download.zip");
        }

        ZipFile.ExtractToDirectory(baseDir + @"\tmp\zip\download.zip", baseDir + @"\tmp\dez\");

        string DownloadLocation = Directory.GetDirectories(baseDir + @"\tmp\dez\")[0];
        DirectoryInfo source = new(DownloadLocation);
        DirectoryInfo target = new($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/{name}/");

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Status  | File");
        Console.ForegroundColor = ConsoleColor.White;
        CopyFiles(source, target);

        return true;
    }


    private static void CopyFiles(DirectoryInfo source, DirectoryInfo target)
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
