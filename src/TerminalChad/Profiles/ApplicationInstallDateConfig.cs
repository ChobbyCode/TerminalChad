
namespace TerminalChad.Profiles;

public class ApplicationInstallDateConfig
{
    public DateTime GitLastInstallTime { get; set; }

    public ApplicationInstallDateConfig()
    {
        GitLastInstallTime = DateTime.Now.AddDays(-1);
    }
}
