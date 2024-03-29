﻿
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
                InputMessages.HelpExtended();
                break;
            case "version":
                InputMessages.PrintVersion();
                break;
            case "setup":
                Setup.Setup setup = new();
                setup.Init();
                break;
            case "theme":
                ThemeSwitch(input);
                break;
            case "profile":
                ProfileSwitch(input);
                break;
            case "update":
                Console.WriteLine("Please write the command 'TerminalChadUpdate true' in full. Do not put 'terminalchad TerminalChadUpdat...', just the first command.");
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

    private void ProfileSwitch(string[] input)
    {
        if (2 > input.Length)
        {
            Console.WriteLine("Please provide an operator | 'set' or 'download'");
            return;
        }
        switch (input[1])
        {
            case "set":
                if (input.Length > 2)
                {
                    ProfileLoader loader = new ProfileLoader();
                    loader.LoadProfile(input[2]);
                }
                else
                {
                    Console.WriteLine("Please Provide A Theme. Below are the installed themes: \n");
                    foreach (string s in Directory.GetDirectories($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Profiles/"))
                    {
                        DirectoryInfo dI = new DirectoryInfo(s);
                        Console.WriteLine(dI.Name);
                    }
                }
                break;
            case "download":
                Console.WriteLine("Unimplemented");
                break;
            default:
                Console.WriteLine("No.");
                break;
        }
    }

    private void ThemeSwitch(string[] input)
    {
        if (2 > input.Length)
        {
            Console.WriteLine("Please provide an operator | 'set' or 'download' or 'reload'");
            return;
        }
        switch (input[1])
        {
            case "set":
                if (input.Length > 2)
                {
                    ThemeLoader loader = new();
                    loader.LoadTheme(input[2]);
                }
                else
                {
                    Console.WriteLine("Please Provide A Theme. Below are the installed themes: \n");
                    foreach (string s in Directory.GetDirectories($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/"))
                    {
                        DirectoryInfo dI = new DirectoryInfo(s);
                        Console.WriteLine(dI.Name);
                    }
                }
                break;
            case "download":
                if (input.Length > 3)
                {
                    if(input[4] == "-m")
                    {
                        ThemeDownloader loader = new();
                        loader.DownloadThemeZip(input[2], input[3], true);
                    }
                    else
                    {
                        ThemeDownloader loader = new();
                        loader.DownloadThemeZip(input[2], input[3]);
                    }
                }
                else
                {
                    Console.WriteLine("Please provide a github repository to download the theme from. It will download from the main branch.");
                    Console.WriteLine("A name for the theme to be saved as must be provided as the second parameter. \n");
                    Console.WriteLine("Example \n");
                    Console.WriteLine("terminalchad download chobbycode.terminalchad themes");
                }
                break;
            case "reload":
                ThemeDownloader downloader = new();
                downloader.DownloadThemeZip("chobbycode.terminalchadthemes", "/", true);
                break;
            default:
                Console.WriteLine("No.");
                break;
        }        
    }
}
