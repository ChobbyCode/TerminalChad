using TerminalChad.CLI.Input;
using TerminalChad.Profiles.Application;

namespace TerminalChad.CLI;

public class Program
{
    public static string version = "v1.0.0";
    public static Config.Config? config { get; private set; }

    public static void Main(string[] args)
    {
        List<string> arguments = args.ToList();
        bool useConfig = true;
        if (arguments.Count > 0 && arguments[0] == "-!c") {
            useConfig = false;
            Console.WriteLine("Skipping config...");
            arguments.RemoveAt(0); // Remove the flag to stop errors
        }
        if (!IsWindows()) throw new NotSupportedException("TerminalChad only supports Windows OS at the moment.");

        if (useConfig) InitConfig();

        InputParser parser = new InputParser();
        parser.ParseInput(arguments.ToArray());
    }

    private static void InitConfig() {
        try
        {
            config = new TerminalChad.Config.Config();
            config.ReadConfig(); // Read existing config file
            config.WriteConfig(); // If there was an update this will fix any issues caused from updating
            config.RunConfigInfo(); // Load the settings
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred whilst trying to read the config file. Please run the setup command to fix this.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private static bool IsWindows() => OperatingSystem.IsWindows();
}