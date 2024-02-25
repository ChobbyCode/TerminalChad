

using TerminalChad.CLI.Input;
using Newtonsoft.Json;
using TerminalChad.Models.Profiles;

namespace TerminalChad.CLI;

public class Program
{
    // 0.3.1 is the patch for the weird bug with the config file
    // 0.3.2 is the patch for the weird bug with the config file and how it just resets everything
    public static string version = "patch-v0.3.2";

    public static void Main(string[] args)
    {
        try
        {
            TerminalChad.Config.Config cfg = new TerminalChad.Config.Config();
            cfg.ReadConfig();
            cfg.WriteConfig();
            cfg.RunConfigInfo();
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred whilst trying to read the config file. Please run the setup command to fix this.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //ConfigurationInformation configureInformation = new();
        //Console.WriteLine(configureInformation.toJson());

        InputParser parser = new InputParser();
        parser.ParseInput(args);
    }
}