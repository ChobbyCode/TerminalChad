
using System.Diagnostics;

namespace TerminalChad.Profiles.Application;

public class ApplicationDependency {
    public string Name { get; set; } = "New Application Dependency";
    public string Description { get; set; } = "New Application Dependency";

    // When the Application Dependency is executed, will it download a file from which must be executed?
    public bool URIDownload { get; set; } = false;
    public string? FileType { get; set; } = null; // The type of file downloaded which will be executed. 

    // Recommended to use winget commands where possible for better compatibility.
    public string WinGetCommand { get; set; } = "winget install Microsoft.AzureCLI"; // The winget command to install the application.

    public void Install() {
        bool install = GetInstallConfirmation();
        if (!install) {
            Console.WriteLine("Installation cancelled by user.");
            return;
        } else {
            bool success = RunWingetCommand(); 
            if (!success) {
                Console.WriteLine("Installation failed.");
            } else {
                Console.WriteLine("Installation completed.");
            }
        }
    }

    private bool ValidateWingetCommand() {
        // TO DO: Improve the validation in here, currently it is just very basic to make sure that it is actually a winget command
        if (!WinGetCommand.StartsWith("winget ", StringComparison.OrdinalIgnoreCase)) {
            return false;
        } else {
            return true;
        }

    }
    private bool RunWingetCommand() {
        // TO DO: Modify the process start task so that winget does not interfer with the console, and then we will be able to get the error code from winget to see if it was sucesssful
        bool valid = ValidateWingetCommand();
        if (!valid) {
            Console.WriteLine("The provided winget command is not valid. Installation aborted.");
            return false;
        }
        ProcessStartInfo startInfo = new() {
            FileName = "winget",
            Arguments = WinGetCommand.Replace("winget ", string.Empty, StringComparison.OrdinalIgnoreCase),
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new() { StartInfo = startInfo };
        process.OutputDataReceived += (_, args) => { if (args.Data != null) { Console.WriteLine(args.Data); } };
        process.ErrorDataReceived += (_, args) => { if (args.Data != null) { Console.Error.WriteLine(args.Data); } };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        Console.WriteLine($"winget exited with code {process.ExitCode}.");
        return true;
    }

    private void ExecutePowerShellScript() {
        throw new NotImplementedException();
    }

    private bool GetInstallConfirmation() {
        Console.WriteLine($"The application '{Name}' is about to be installed.");
        Console.WriteLine("The script ");
        ConsoleColor foregroundCol = Console.ForegroundColor;
        ConsoleColor backgroundCol = Console.BackgroundColor;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"DANGER: '{WinGetCommand}'");
        Console.ForegroundColor = foregroundCol; // reset color
        Console.BackgroundColor = backgroundCol; // reset color
        Console.WriteLine("will be executed! Running unchecked scripts on your system could be dangerous! PLEASE read them.\0");

        bool validInput = false;
        while (!validInput) {
            Console.Write("Do you wish to run this ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("potentially dangerous");
            Console.ForegroundColor = foregroundCol; // reset color
            Console.BackgroundColor = backgroundCol; // reset color
            Console.Write(" code? (y/n): ");
            string? input = Console.ReadLine();
            if (input != null) {
                input = input.ToLower();
                if (input == "y" || input == "yes") {
                    return true;
                }
                else if (input == "n" || input == "no") {
                    return false;
                }
                else {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
        }
        return false;
    }
}
