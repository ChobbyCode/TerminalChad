using System;
using System.IO;
using System.IO.Compression;

namespace TerminalChad.Profiles;
public class ProfileCommand {
    /* === Intentions Of Profile Command ===
     * 
     * - Have users be able to create a profile which contains:
     *      - Themes
     *      - Applications To Install
     *      - Scripts Which They Can Run
     * 
     * === USAGE ===
     * 
     * terminalchad profile -n          Creates a new profile
     * terminalchad profile -u          Enables a profile which already exists
     * terminalchad profile -d          Downloads profile(s) from a zipball url
     * terminalchad profile -m [PROFILE_NAME] -x               Deletes profile
     * terminalchad profile -m [PROFILE_NAME] -r [NEW_NAME]    Renames a profile
     * terminalchad prfiles -m [PROFILE_NAME] -w               Gets path of the profile
     * terminalchad profile -m [PROFILE_NAME] -c [SETTING_NAME] [NEW_VALUE] Changes value of a profile setting
     * terminalchad profile -m [PROFILE_NAME] -b               Reopens the profile builder
     */

    public void Parse(string[] args) {
        List<string> arguments = TidyUpArguments(args) ?? new List<string>();

        if (arguments.Count == 0) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No profile command modifier provided. Please provide one of the following modifiers: '-n', '-u', '-d', '-m'");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        SwitchInput(arguments);
    }

    private void SwitchInput(List<string> args) {
        switch (args[0]) {
            case "-n":
                CreateNewProfile();
                break;
            case "-u":
                EnableProfile();
                break;
            case "-d":
                DownloadProfile();
                break;
            case "-m":
                args.RemoveAt(0);
                ManageProfile(args);
                break;
            default:
                Console.WriteLine("Invalid operator");
                break;
        }
    }

    private void CreateNewProfile() {
        // TO DO: Implement profile creation logic
    }

    private void EnableProfile() {
        // TO DO: Implement profile enabling logic
    }

    private void DownloadProfile() {
        // TO DO: Implement profile downloading logic
    }

    private void ManageProfile(List<string> args) {
        if (!ProfileExists(args[0])) {
            Console.WriteLine("Profile Doesn't Exist, Can't Manage Non-Existing Profile. Check You Typed The Name Properly");
        }

        string profileName = args[0];
        args.RemoveAt(0);

        switch (args[0]) {
            case "-x":
                DeleteProfile(profileName);
                break;
            case "-r":
                RenameProfile(profileName, args[1]);
                break;
            case "-w":
                GetProfilePath(profileName);
                break;
            case "-c":
                ChangeProfileSetting(profileName, args[1], args[2]);
                break;
            case "-b":
                ReopenProfileBuilder(profileName);
                break;
            default:
                Console.WriteLine("No operator provided! Please provide an operator");
                break;
        }
    }

    private void DeleteProfile(string profileName) {
        // TO DO: Implement profile deletion logic
    }

    private void RenameProfile(string profileName, string newProfileName) {
        // TO DO: Implement profile renaming logic
    }

    private void GetProfilePath(string profileName) {
        // TO DO: Implement logic to get profile path
    }

    private void ChangeProfileSetting(string profileName, string settingName, string newValue) {
        // TO DO: Implement logic to change profile setting
    }

    private void ReopenProfileBuilder(string profileName) {
        // TO DO: Implement logic to reopen profile builder
    }

    private List<string>? TidyUpArguments(string[] args) {
        // Remove the first argument which is 'profile'
        List<string> arguments = args.ToList();
        arguments.RemoveAt(0);
        // Then check that the first argument is one of the valid modifiers: '-n', '-u', '-d', '-m'
        if (arguments.Count !> 0) return null;
        if (arguments[0] != "-n" && arguments[0] != "-u" && arguments[0] != "-d" && arguments[0] != "-m") {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"'{arguments[0]}' is not recognised as a valid profile command modifier.");
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }
        else return arguments;
    }

    private bool ProfileExists(string profileName) {
        // Build the path to the profile
        // Profiles exist in %APPDATA%\TerminalChad\Profiles\[PROFILE_NAME]
        // Profiles may also exist as zipballs, in that case they must be unzipped before they can be read.
        // Profiles may be .zip, but also have the files extension .tchprofile. Both are to be treated as profiles.
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string profilesPath = Path.Combine(appDataPath, "TerminalChad", "Profiles");

        // Check if the profile exists as a directory
        if (Directory.Exists(Path.Combine(profilesPath, profileName))) {
            // Must also contain magic config.json file which can be extracted
            if (File.Exists(Path.Combine(profilesPath, profileName, "config.json"))) {
                return true;
            }
            else {
                // We can fall back to the other methods of checking but print corrupted profile message
                Console.WriteLine($"Profile at '{Path.Combine(profilesPath, profileName)}', missing config.json file.");
            }
        }

        // Zipball paths

        string zipballPath = Path.Combine(profilesPath, $"{profileName}.zip");
        string tchprofilePath = Path.Combine(profilesPath, $"{profileName}.tchprofile");

        if (File.Exists(zipballPath)) {
            UncompressProfile(zipballPath);
        } else if (File.Exists(tchprofilePath)) {
            UncompressProfile(tchprofilePath);
        }
        return true;

    }
    private bool UncompressProfile(string profile) {
        FileInfo sourceLocation = new FileInfo(profile);
        string extension = sourceLocation.Extension;
        if (extension != ".zip" || extension != ".tchprofile") {
            Console.WriteLine("Can't decompress a profile unless it is a .zip of tchprofile");
            return false;
        }
        // crop .zip or .tchprofile from end of sourceLocation
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string profilesPath = Path.Combine(appDataPath, "TerminalChad", "Profiles");

        // Remove extension
        string targetLocation = Path.Combine(Path.GetDirectoryName(profile) ?? profilesPath, sourceLocation.Name);

        // Create a relevant number to add to the end of target location if it already exists;
        if (Directory.Exists(targetLocation)) {
            int i = 0;
            string tmpLocation = targetLocation;
            while (Directory.Exists(tmpLocation)) {
                i++;
                tmpLocation = $"{targetLocation}(i)";
            }
            targetLocation = tmpLocation;
        }


        try {
            ZipFile.ExtractToDirectory(sourceLocation.FullName, targetLocation);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }
} 