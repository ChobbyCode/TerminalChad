using System;

namespace TerminalChad.CLI.Input;

internal class InputMessages
{
    public static void PrintBasic()
    {
        Console.WriteLine($"Copyright (c) ChobbyCode 2024-{DateTime.Now.Year}, All The Rights Reserved, MIT License");
        Console.WriteLine("Terminal Chad is a tool which allows for easy theme customisation of the Windows Terminal.\n");
        Console.WriteLine("usage: terminalchad [command] [command] \n");
        Console.WriteLine("   COMMAND   ALTERNATIVE    DESCRIPTION \n");
        Console.WriteLine("     help        -h    Prints additional help information");
        Console.WriteLine("     controls          Prints control information for windows terminal");
        Console.WriteLine("     credits           Prints the credits and legal information");
        Console.WriteLine("     version     -v    Prints the version of application");
        Console.WriteLine("     which       -w    Prints the location the TC exe file is located\n");
        Console.WriteLine("     setup       -s    Runs the setup script of the application");
        Console.WriteLine("     update      -u    View update information\n");
        Console.WriteLine("     theme       -t    Change your current theme of TerminalChad");
        Console.WriteLine("     profile           Configure profiles for your system.");
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
        Console.WriteLine($"TerminalChad {Program.version} (c) ChobbyCode {DateTime.Now.Year}, All Rights Reserved, MIT License");
        Console.WriteLine("Windows Terminal (c) Microsoft Corporation, All Rights Reserved ");
        Console.WriteLine("Windows Powershell (c) Microsoft Corporation, All Rights Reserved ");
        Console.WriteLine("TerminalChad, ChobbyCode or any contributor is not affiliated, nor endorsed by Microsoft Corporation or any partnering entity.\n");
        Console.WriteLine("===Credits===\n");
        Console.WriteLine("- ChobbyCode\n");
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

    public static void Which() {
        Console.WriteLine($"TerminalChad Path: '{System.Environment.ProcessPath}'\n\nIf you are looking to uninstall the application please download the installer/uninstaller from https://github.com/ChobbyCode/TerminalChad");
    }
}
