
namespace TerminalChad.Setup;

public class DirectorySetup
{
    private string _terminalChadFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/";
    private string _themeFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/";
    private string _activeFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/";
    private string _languageServers = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Microsoft.LanguageServerProtocols";

    public void CreateDirectories()
    {
        CreateDirectory(_terminalChadFolder);
        CreateDirectory(_themeFolder);
        CreateDirectory(_activeFolder);
        CreateDirectory(_languageServers);
    }

    private void CreateDirectory(string path)
    {
        string[] split = path.Split(new char[] { '/', '\\' });
        string buildPath = split[0] + @"\";
        for(int i = 1; i < split.Length; i++)
        {
            buildPath += split[i] + @"\";
            try
            {
                if(!Directory.Exists(buildPath)) Directory.CreateDirectory(buildPath);
            }catch (Exception ex) { }
        }
    }
}
