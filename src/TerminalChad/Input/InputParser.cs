
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
                break;
        }
    }
}
