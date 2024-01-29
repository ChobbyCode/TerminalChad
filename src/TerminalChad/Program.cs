

using TerminalChad.CLI.Input;

namespace TerminalChad.CLI;

public class Program
{
    public static string version = "v0.1.1";

    public static void Main(string[] args)
    {
        InputParser parser = new InputParser();
        parser.ParseInput(args);
    }
}