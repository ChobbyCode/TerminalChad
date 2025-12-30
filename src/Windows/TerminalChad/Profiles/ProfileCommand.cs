using System;
using System.IO;
using System.IO.Compression;
using TerminalChad.Profiles.Application;

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
     * terminalchad profile -n [PROFILE_NAME] [THEME]                           Creates a new profile
     * terminalchad profile -u                                                  Enables a profile which already exists
     * terminalchad profile -d                                                  Downloads profile(s) from a zipball url
     * terminalchad profile -m [PROFILE_NAME] -x                                Deletes profile
     * terminalchad profile -m [PROFILE_NAME] -r [NEW_NAME]                     Renames a profile
     * terminalchad prfiles -m [PROFILE_NAME] -w                                Gets path of the profile
     * terminalchad profile -m [PROFILE_NAME] -c [SETTING_NAME] [NEW_VALUE]     Changes value of a profile setting
     * terminalchad profile -m [PROFILE_NAME] -b                                Reopens the profile builder
     * terminalchad profile help me please                                      Prints help information about the help command
     */

    public void Parse(string[] args) {
        List<string>? arguments = TidyUpArguments(args);
        if (arguments == null || arguments.Count == 0) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("To access help information about the help command type: 'terminalchad profile help me please'");
            Console.WriteLine("No profile command modifier provided. Please provide one of the following modifiers: '-n', '-u', '-d', '-m'");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
        if (arguments.Count == 3 && args[1] == "help" && args.Length >= 5 && args[2] == "me" && args[3] == "please") {
            PrintHelpInformation();
            return;
        }

        SwitchInput(arguments);
    }

    private void PrintHelpInformation() {
        Console.WriteLine("* === PROFILE USAGE ===");
        Console.WriteLine("*");
        Console.WriteLine("* terminalchad profile -n [PROFILE_NAME] [THEME]                           Creates a new profile");
        Console.WriteLine("* terminalchad profile -u                                                  Enables a profile which already exists");
        Console.WriteLine("* terminalchad profile -d                                                  Downloads profile(s) from a zipball url");
        Console.WriteLine("* terminalchad profile -m [PROFILE_NAME] -x                                Deletes profile");
        Console.WriteLine("* terminalchad profile -m [PROFILE_NAME] -r [NEW_NAME]                     Renames a profile");
        Console.WriteLine("* terminalchad prfiles -m [PROFILE_NAME] -w                                Gets path of the profile");
        Console.WriteLine("* terminalchad profile -m [PROFILE_NAME] -c [SETTING_NAME] [NEW_VALUE]     Changes value of a profile setting");
        Console.WriteLine("* terminalchad profile -m [PROFILE_NAME] -b                                Reopens the profile builder");
        Console.WriteLine("* terminalchad profile help me please                                      Prints help information about the help command");
    }

    private void SwitchInput(List<string> args) {
        switch (args[0]) {
            case "-n":
            case "generate": // for compatablity with theme command
                CreateNewProfile();
                break;
            case "-u":
                EnableProfile(args[1]);
                break;
            case "-d":
                DownloadProfile();
                break;
            case "-m":
                args.RemoveAt(0);
                ManageProfile(args);
                break;
            case "help":
                PrintHelpInformation();
                break;
            default:
                Console.WriteLine("Invalid operator");
                break;
        }
    }

    private void CreateNewProfile() {
        ProfileBuilder builder = new ProfileBuilder();
    }

    private void EnableProfile(string profileName) {
        Profile profile = ProfileHelper.GetProfile(profileName);
        // TO DO: Have it automatically source the scripts to run

        profile.theme.Use();
        foreach (ApplicationDependency dependency in profile.applicationDependencies) {
            dependency.Install();
        }

        Console.WriteLine("Profile Enabled");
    }

    private void DownloadProfile() {
        // TO DO: Implement profile downloading logic
        throw new NotImplementedException();
    }

    private void ManageProfile(List<string> args) {
        if (!ProfileHelper.ProfileExists(args[0])) {
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
        string profilePath = ProfileHelper.GetProfilePath(profileName);
        if (!ProfileHelper.ProfileExists(profileName) || !Directory.Exists(profilePath)) {
            Console.WriteLine("Profile Doesn't Exist, Can't Delete Non-Existing Profile. Check You Typed The Name Properly");
            return;
        }
        Directory.Delete(profilePath, true);
        Console.WriteLine($"Deleted profile at {profilePath}");
    }

    private void RenameProfile(string profileName, string newProfileName) {
        if (!ProfileHelper.ProfileExists(profileName)) {
            Console.WriteLine("Profile doesn't exist, can't modify a non existing profile");
            return;
        } 
        if (ProfileHelper.ProfileExists(newProfileName)) {
            Console.WriteLine($"Profile with the name '{newProfileName}' already exists, can't rename a profile to a profile which has a name which already exists.");
            return;
        }
        Profile profile = ProfileHelper.GetProfile(profileName);
        profile.profileName = newProfileName;
        profile.Export(true);
    }

    private void GetProfilePath(string profileName) {
        if (!ProfileHelper.ProfileExists(profileName)) {
            Console.WriteLine("Profile doesn't exist.");
            return;
        }
        Console.WriteLine($"Profile is located at: '{ProfileHelper.GetProfilePath(profileName)}'");
    }

    private void ChangeProfileSetting(string profileName, string settingName, string newValue) {
        // TO DO: Implement logic to change profile setting 
        throw new NotImplementedException();
    }

    private void ReopenProfileBuilder(string profileName) {
        // TO DO: Implement logic to reopen profile builder
        throw new NotImplementedException();
    }

    private List<string>? TidyUpArguments(string[] args) {
        if (args.Length < 2) {
            return null;
        }
        // Remove the first argument which is 'profile'
        List<string> arguments = args.ToList();
        arguments.RemoveAt(0);
        // Then check that the first argument is one of the valid modifiers: '-n', '-u', '-d', '-m'
        if (arguments.Count > 0) {
            if (arguments[0] != "-n" && arguments[0] != "-u" && arguments[0] != "-d" && arguments[0] != "-m" && arguments[0] != "help") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"'{arguments[0]}' is not recognised as a valid profile command modifier.");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
            else return arguments;
        }
        else {             
            return null;
        }
    }
}