using System;
using System.IO;
using System.IO.Compression;

namespace TerminalChad.Profiles;

internal class ProfileHelper {
    internal static bool ProfileExists(string profileName) {
        // Build the path to the profile
        // Profiles exist in %APPDATA%\TerminalChad\Profiles\[PROFILE_NAME]
        // Profiles may also exist as zipballs, in that case they must be unzipped before they can be read.
        // Profiles may be .zip, but also have the files extension .tchprofile. Both are to be treated as profiles.
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string profilesPath = Path.Combine(appDataPath, "TerminalChad", "Profiles");

        // Check if the profile exists as a directory
        if (Directory.Exists(Path.Combine(profilesPath, profileName))) {
            // Must also contain magic config.json file which can be extracted
            if (File.Exists(Path.Combine(profilesPath, profileName, "profile.json"))) {
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
            return true;
        }
        else if (File.Exists(tchprofilePath)) {
            UncompressProfile(tchprofilePath);
            return true;
        }
        else return false;
    }
    internal static bool UncompressProfile(string profile) {
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
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    internal static string GetProfilePath(string profileName) {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string profilesPath = Path.Combine(appDataPath, "TerminalChad", "Profiles");
        return Path.Combine(profilesPath, profileName);
    }

    internal static Profile GetProfile(string profileName) {
        if (!ProfileExists(profileName)) {
            throw new Exception($"Profile '{profileName}' does not exist.");
        }

        string profilePath = GetProfilePath(profileName);
        string profileConfigPath = Path.Combine(profilePath, "profile.json");
        if (!File.Exists(profileConfigPath)) {
            throw new Exception($"Profile configuration file not found at '{profileConfigPath}'.");
        }
        string profileJson = File.ReadAllText(profileConfigPath);
        Profile profile = Newtonsoft.Json.JsonConvert.DeserializeObject<Profile>(profileJson) ?? new Profile();
        return profile;
    }

}
