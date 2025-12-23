
//using TerminalChad.Profiles;
using TerminalChad.Profiles;
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
            case "-h":
                InputMessages.HelpExtended();
                break;
            case "version":
            case "-v":
                InputMessages.PrintVersion();
                break;
            case "which":
            case "-w":
                InputMessages.Which();
                break;
            case "setup":
            case "-s":
                Setup.Setup setup = new();
                setup.Init();
                break;
            case "theme":
            case "-t":
                ThemeCommand.ThemeSwitch(input);
                break;
            case "profile":
            case "-p":
                ProfileCommand profile = new ProfileCommand();
                profile.Parse(input);
                break;
            case "update":
            case "-u":
                // TO DO: Have this automatically check for updates and enable the installer.
                break;
            case "controls":
                InputMessages.PrintControls();
                break;
            case "credits":
                InputMessages.PrintCredits();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"'{input[0]}' is not recognised as a TerminalChad command, or TerminalChad extension command");
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
    }
   }
