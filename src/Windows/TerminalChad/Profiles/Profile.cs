
using TerminalChad.Profiles.Application;
using TerminalChad.Profiles.Scripts;
using TerminalChad.Themes;

namespace TerminalChad.Profiles;

public class Profile {
    Theme theme { get; set; } = new Theme();
    List<ApplicationDependency> applicationDependencies { get; set; } = new List<ApplicationDependency>();
    List<QuickScript> quickScripts { get; set; } = new List<QuickScript>();
}
