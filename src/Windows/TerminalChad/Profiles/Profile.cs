
using TerminalChad.Json.Extensions;
using TerminalChad.Profiles.Application;
using TerminalChad.Profiles.Scripts;
using TerminalChad.Themes;

namespace TerminalChad.Profiles;

public class Profile {
    public string profileName = "default";
    public Theme theme { get; set; } = new Theme();
    public List<ApplicationDependency> applicationDependencies { get; set; } = new List<ApplicationDependency>();
    public List<QuickScript> quickScripts { get; set; } = new List<QuickScript>();

    public void Export(bool OverrideExistingProfiles = false) {
        if (ProfileHelper.ProfileExists(profileName) || Directory.Exists(ProfileHelper.GetProfilePath(profileName)) && !OverrideExistingProfiles) {
            throw new Exception("Profile with the same name already exists.");
        }
        else {
            Save();
        }
    }

    private void Save() {
        Directory.CreateDirectory(ProfileHelper.GetProfilePath(profileName));
        string json = this.toJson();
        File.WriteAllText(Path.Combine(ProfileHelper.GetProfilePath(profileName), "profile.json"), json);
    }
}
