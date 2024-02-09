

using TerminalChad.CLI.Input;
using TerminalChad.Profiles.Installer;
using TerminalChad.Profiles.Installer.Scripts;

namespace TerminalChad.CLI;

public class Program
{
    public static string version = "patch-v0.2.1";

    public static void Main(string[] args)
    {
        /*Console.WriteLine(version);
        Installer installer = new Installer();
        Console.ReadLine();
        installer.DownloadApplication(SupportedApplications.GIT);*/

        InputParser parser = new InputParser();
        parser.ParseInput(args);
    }
}