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

        if (!UpdaterApplicationPaired()) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Warning: The updater application is missing. Please reinstall TerminalChad by visiting https://github.com/ChobbyCode/TerminalChad to ensure you receive updates.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        if (useConfig) {
            bool configInitialized = InitConfig();
            if (args.Length > 0 &&  args[0] == "setup") {
                // Allow setup to run even if config failed to initialize
            } else
            if (!configInitialized) {
                return; // Stop execution if config failed to initialize as this can cause error when program tries to use profile or theme command
            }
        }

        InputParser parser = new InputParser();
        parser.ParseInput(arguments.ToArray());
    }

    private static bool InitConfig() {
        try
        {
            config = new TerminalChad.Config.Config();
            config.ReadConfig(); // Read existing config file
            config.WriteConfig(); // If there was an update this will fix any issues caused from updating
            config.RunConfigInfo(); // Load the settings
            return true;
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred whilst trying to read the config file. Please run the setup command to fix this.\n");
            Console.WriteLine("Type 'terminalchad setup' to fix this issue.\n");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
    }

    private static bool IsWindows() => OperatingSystem.IsWindows();

    private static bool UpdaterApplicationPaired() {
        // Get base dir of terminalchad.exe
        string baseDir = AppContext.BaseDirectory;
        string updaterPath = Path.Combine(baseDir, "TerminalChadUpdater.exe");
        if (File.Exists(updaterPath)) {
            return true;
        }
        else return false;
    }
}