

using TerminalChad.CLI.Input;
using TerminalChad.Profiles;
using Newtonsoft.Json;

namespace TerminalChad.CLI;

public class Program
{
    public static string version = "patch-v0.2.3";

    public static void Main(string[] args)
    {
        // Config Files Not Implemented Yet

        //TerminalChad.Config.Config cfg = new TerminalChad.Config.Config();
        //cfg.WriteConfig();
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