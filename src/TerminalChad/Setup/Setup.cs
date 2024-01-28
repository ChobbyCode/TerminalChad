
namespace TerminalChad.CLI.Setup;

internal class Setup
{
    private string baseDir = AppDomain.CurrentDomain.BaseDirectory;

    public void Init()
    {
        ModifyTerminalConfig();
    }

    private void ModifyTerminalConfig()
    {
        string TerminalConfigFile = $@"C:\Users\{Environment.UserName}\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json";
        File.Copy(baseDir + @"\WriteFiles\Terminal\settings.json", TerminalConfigFile, true);
    }
}
