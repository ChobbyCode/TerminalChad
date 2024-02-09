
namespace TerminalChad.Profiles.Installer;

public class ProfileInstaller
{
    public void ReadProfile(FileInfo file)
    {
        string profileText = File.ReadAllText(file.FullName);
    }
}
