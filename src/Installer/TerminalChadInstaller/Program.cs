using InstallerJazz;
using InstallerJazz.Models;
using InstallerJazz.Updater.Models;
using Newtonsoft.Json;

namespace DemoInstaller;

public class Program {
    public static void Main(string[] args) {
        if (args.Length == 0) {
            InstallBasic(args);
        }
        if (args.Length > 0) {
            if (args[0] == "update") {
                var versionInfoPath = Path.Combine(Environment.CurrentDirectory, @"\version.json");
                if (Path.Exists(versionInfoPath)) {
                    string versionTxt = File.ReadAllText(versionInfoPath);
                    if (string.IsNullOrEmpty(versionTxt)) { return; }
                    VersionInfo? versionInfo = JsonConvert.DeserializeObject<VersionInfo?>(versionTxt);
                    if (versionInfo == null) return;

                    string exePath = Environment.CurrentDirectory;
                    UpdateBasic(args, versionInfo.Version, exePath);

                }
                else {
                    Console.WriteLine("Corrupted Terminal Chad Files! Failed To Find version.json information. Automatically repairing installation.");
                    InstallBasic(args);
                }
            }
            else {
                Console.WriteLine("Invalid arguments");
                Console.ReadLine();
            }
        }

    }

    public static void InstallBasic(string[] args) {
        InstallArguments installArguments = new InstallArguments() {
            WindowName = "TerminalChad Installer",
            Website = "https://github.com/ChobbyCode/TerminalChad",
            HelpURL = "https://github.com/ChobbyCode/TerminalChad/issues",

            SourceURL = "https://github.com/ChobbyCode/TerminalChad/zipball/InstallerFiles",
            VersionInfoURL = "https://github.com/ChobbyCode/TerminalChad/zipball/VersionInformation",

            InstallDotNet = true, // As this is meant for c# apps, it is designed to also automatically install dotnet
            EnableInstallFeature = true, // Select which features you want to have enabled
            EnableUninstallFeature = true,
            EnableUpdateFeature = false,

            TargetLocation = "\\Program Files\\TerminalChad\\", // Relative Location Where The App Will Be Installed
            AllowUsersToChooseInstallDrive = true, // If this is enabled it allows the users to choose full install drive. If not target location will have to be change to a full path so "C:\ProgramFiles..."
        };

        AppPackager appPackager = new AppPackager(args, installArguments);
    }

    public static void UpdateBasic(string[] args, int version, string installLocation) {
        InstallArguments installArguments = new InstallArguments() {
            WindowName = "TerminalChad Updater",
            Website = "https://github.com/ChobbyCode/TerminalChad",
            HelpURL = "https://github.com/ChobbyCode/TerminalChad/issues",

            SourceURL = "https://github.com/ChobbyCode/TerminalChad/zipball/InstallerFiles",
            VersionInfoURL = "https://github.com/ChobbyCode/TerminalChad/zipball/VersionInformation",
            AppVersion = version,

            InstallDotNet = false, // As this is meant for c# apps, it is designed to also automatically install dotnet
            EnableInstallFeature = false, // Select which features you want to have enabled
            EnableUninstallFeature = false,
            EnableUpdateFeature = true,

            TargetLocation = installLocation, // Relative Location Where The App Will Be Installed
            AllowUsersToChooseInstallDrive = false, // If this is enabled it allows the users to choose full install drive. If not target location will have to be change to a full path so "C:\ProgramFiles..."
        };

        AppPackager appPackager = new AppPackager(args, installArguments);

    }
}