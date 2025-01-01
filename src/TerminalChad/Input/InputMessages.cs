
namespace TerminalChad.CLI.Input;

internal class InputMessages
{
    public static void PrintBasic()
    {
        Console.WriteLine("Copyright (c) ChobbyCode 2025, All Rights Reserved, MIT License");
        Console.WriteLine("Terminal Chad is a Terminal extension to make your terminal look better, quicker and more easily.\n");
        Console.WriteLine("usage: terminalchad [command] [command] \n");
        Console.WriteLine("     help        Prints additional help information");
        Console.WriteLine("     controls    Prints control information for windows terminal");
        Console.WriteLine("     credits     Prints the credits and legal information");
        Console.WriteLine("     version     Prints the version of application\n");
        Console.WriteLine("     setup       Runs the setup script of the application");
        Console.WriteLine("     update      View update information\n");
        Console.WriteLine("     theme       Change your current theme of TerminalChad");
        //Console.WriteLine("     profile     Profiles allow easy mass-swapping of config files on a range of applications");
    }

    public static void HelpExtended()
    {
        var _HelpText = File.ReadAllLines($"{AppDomain.CurrentDomain.BaseDirectory}/Docs/help.txt");
        foreach(var s in _HelpText)
        {
            Console.WriteLine(s);
        }
    }

    public static void PrintCredits()
    {
        Console.WriteLine($"TerminalChad {Program.version} (c) ChobbyCode 2024, All Rights Reserved, MIT License");
        Console.WriteLine("Windows Terminal (c) Microsoft Corporation, All Rights Reserved ");
        Console.WriteLine("Windows Powershell (c) Microsoft Corporation, All Rights Reserved ");
        Console.WriteLine("TerminalChad, ChobbyCode or any contributor is not affiliated, nor endorsed by Microsoft Corporation or any partnering entity.\n");
        Console.WriteLine("===Credits===\n");
        Console.WriteLine("Programming: \n");
        Console.WriteLine("- ChobbyCode\n");
        Console.WriteLine("Testing: \n");
        Console.WriteLine("- ChobbyCode");
        Console.WriteLine("- Boenaenae");
    }

    public static void PrintControls()
    {
        Console.WriteLine("'Ctrl + Shift + T'       New Terminal");
        Console.WriteLine("'Ctrl + Shift + W'       Close Open Terminal");
        Console.WriteLine("'Shift + Alt + Add'      Open New Split Terminal");
    }

    public static void PrintVersion()
    {
        Console.WriteLine($"TerminalChad {Program.version}");
    }
}
