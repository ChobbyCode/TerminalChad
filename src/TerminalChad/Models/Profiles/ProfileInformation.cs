
namespace TerminalChad.Models.Profiles;

public class ProfileInformation
{
    public List<Application> applications { get; set; } = new List<Application>();
    public string? theme { get; set; }  // Null is used when the profile doesn't effect the theme of the interface
}
