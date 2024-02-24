

using TerminalChad.CLI.Input;
using TerminalChad.Profiles;
using Newtonsoft.Json;

namespace TerminalChad.CLI;

public class Program
{
    // 0.3.1 is the patch for the weird bug with the config file
    public static string version = "patch-v0.3.1";

    public static void Main(string[] args)
    {
        // Config Files Not Implemented Yet

        // Come up with a better patch later
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

            // Last application install dates | Not Used, but don't remove
            //WriteConfig();

            //ProfileLoader pl = new ProfileLoader();
            //pl.LoadProfile("default");

            //Console.WriteLine(version);
            //Installer installer = new Installer();
            //installer.DownloadApplication(SupportedApplications.GIT);

            InputParser parser = new InputParser();
        parser.ParseInput(args);

        /*ConfigurationCopyAddressFile file = new ConfigurationCopyAddressFile()
        {
            Copy =
            {
                new Models.Profiles.Models.ConfigurationCopyAddressSingular()
                {
                    target = "%appdata%/TerminalChad",
                    source = "~/Desktop"
                }
            }
        };

        ConfigurationLoader configurationLoader = new ConfigurationLoader();
        configurationLoader.LoadConfigurations(file);*/
    }

    public static void WriteConfig()
    {
        if (!File.Exists(GlobalVariables.ApplicationInstallConfigFile))
        {
            StreamWriter sw = new StreamWriter(GlobalVariables.ApplicationInstallConfigFile);
            try
            {
                sw.Write("");
            }
            catch
            (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            finally { sw.Close(); }

            StreamWriter sz = new StreamWriter(GlobalVariables.ApplicationInstallConfigFile);
            try
            {
                ApplicationInstallDateConfig config = new ApplicationInstallDateConfig();
                Console.WriteLine(JsonConvert.SerializeObject(config, Formatting.Indented));
                sz.WriteLine(JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            catch
            (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            finally { sz.Close(); }
        }
    }
}