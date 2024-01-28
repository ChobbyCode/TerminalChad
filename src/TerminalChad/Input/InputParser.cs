
using TerminalChad.Themes;

namespace TerminalChad.CLI.Input;

internal class InputParser
{
    public void ParseInput(string[] input)
    {
        if (input == null || input.Length == 0)
        {
            InputMessages.PrintBasic();
            return;
        }

        // Main Commands
        switch(input[0])
        {
            case "help":
                break;
            case "version":
                InputMessages.PrintVersion();
                break;
            case "setup":
                Setup.Setup setup = new();
                setup.Init();
                break;
            case "theme":
                ThemeLoader loader = new ThemeLoader();
                if(input.Length > 1)
                {
                    loader.LoadTheme(input[1]);
                }
                else
                {
                    Console.WriteLine("Please Provide A Theme. Below are the installed themes: \n");
                    foreach(string s in Directory.GetDirectories($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/"))
                    {
                        DirectoryInfo dI = new DirectoryInfo(s);
                        Console.WriteLine(dI.Name);
                    }
                }
                break;
            default:
                InputMessages.PrintBasic();
                break;
        }
    }
}
