
namespace TerminalChad.CLI.Input;

internal class InputMessages
{
    public static void PrintBasic()
    {
        Console.WriteLine("Copyright (c) ChobbyCode 2024, All Rights Reserved, MIT License");
        Console.WriteLine("Terminal Chad is a Terminal extension to make your terminal look better, quicker and more easily.\n");
        Console.WriteLine("     help    - Prints additional help information");
        Console.WriteLine("     version - Prints the version of application");
        Console.WriteLine("     setup   - Runs the setup script of the application\n");
        Console.WriteLine("     theme   - Change your current theme of TerminalChad");
    }

    public static void PrintVersion()
    {
        Console.WriteLine($"TerminalChad {Program.version}");
    }
}
