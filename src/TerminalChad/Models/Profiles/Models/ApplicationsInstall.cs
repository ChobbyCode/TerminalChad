
using TerminalChad.Profiles.Installer;

namespace TerminalChad.Models.Profiles.Models;

public class ApplicationsInstall
{
    public List<SupportedApplications> Applications { get; set; } = new List<SupportedApplications>();
}
