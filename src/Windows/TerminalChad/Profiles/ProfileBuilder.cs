using Newtonsoft.Json;
using TerminalChad.Themes;

namespace TerminalChad.Profiles;
public class ProfileBuilder {
    Profile profile = new Profile();

    public ProfileBuilder() {
        OpenBuilder();
        profile.Export();
        Console.WriteLine($"Profile '{profile.profileName}' created successfully!");
    }

    public ProfileBuilder(string profileName, bool existing) {
        if (!existing) {
            // Don't question it buddy. Just leave it alone.
            throw new ArgumentException("The 'existing' parameter must be true to load an existing profile.");
        }

        LoadExistingProfile(profileName);
        PrintExistingValues();
        OpenBuilder(profileName, true);
        profile.Export();
    }

    private void LoadExistingProfile(string name) {
        // name should not be a file path. Just name of a profile, such as 'default' or 'work'.
        string profilePath = ProfileHelper.GetProfilePath(name);
        string profileConfigPath = Path.Combine(profilePath, "profile.json");

        if(!ProfileHelper.ProfileExists(name)) {
            // Profile should have already been validated before this point, so it's fine to throw an exception here.
            throw new Exception($"Profile '{name}' does not exist.");
        }

        if(!File.Exists(profileConfigPath)) {
            // Again, profile should have been validated before this point.
            throw new Exception($"Profile configuration file not found at '{profileConfigPath}'.");
        }

        string profileJson = File.ReadAllText(profileConfigPath);
        profile = JsonConvert.DeserializeObject<Profile>(profileJson) ?? new Profile();
    }

    private void PrintExistingValues() {
        Console.WriteLine("Existing Profile Values:");
        Console.WriteLine($"Profile Name: {profile.profileName}");
        Console.WriteLine($"Theme: {profile.theme}");
        Console.WriteLine("Application Dependencies:");
        foreach(var app in profile.applicationDependencies) {
            Console.WriteLine($"- {app.Name} (Get: {app.WinGetCommand})");
        }
        Console.WriteLine("Quick Scripts:");
        foreach(var script in profile.quickScripts) {
            Console.WriteLine($"- {script.Name} (Path: {script.ScriptPath})");
        }
    }

    private void OpenBuilder(string name = "", bool prexisting = false) {
        // The name of the profile will already be provided by the profile command.
        if (String.IsNullOrEmpty(name)) {
            name = GetName();
        }

        if (!prexisting) {
            if (ProfileHelper.ProfileExists(name)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A profile with the name '{name}' already exists. Please choose a different name.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else {
                profile.profileName = name;
            }
        }
        // Get theme
        string theme = GetTheme();
        Theme theme1 = new Theme(Path.Combine(Theme.themeDirectory, theme));
        this.profile.theme = theme1;
    }

    private string GetName() {
        bool valid = false;
        string? prof = String.Empty;
        while (!valid) {
            Console.Write("Please enter a name to pick as your new profile: ");
            prof = Console.ReadLine();
            if (!String.IsNullOrEmpty(prof) && !ProfileHelper.ProfileExists(prof)) {
                valid = true;
            }
            Console.WriteLine("The profile name you provided is either empty or already exists, please try again.");
        }
        return prof ?? "default";
    }
    
    private string GetTheme() {
        bool valid = false;
        string? theme = String.Empty;
        while (!valid) {
            Console.WriteLine("Below is a list of existing themes:");
            List<string> themes = Directory.GetDirectories(Themes.Theme.themeDirectory).ToList();
            foreach (string t in themes) {
                Console.Write($"{t},");
            }
            Console.WriteLine();
            Console.Write("Please pick one of these themes:");
            theme = Console.ReadLine();
            if (String.IsNullOrEmpty(theme) || !Directory.Exists(Path.Combine(Theme.themeDirectory, theme))) {
                Console.WriteLine("The them you provided does not exist, please try again");
            }
            else valid = true;
        }
        return theme ?? "default";
    }
}
