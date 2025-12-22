
namespace TerminalChad.Themes;

public class ThemeCommand {
    public static void ThemeSwitch(string[] input) {
        if (2 > input.Length) {
            Console.WriteLine("Please provide an operator | 'set' or 'generate' or 'download' or 'reload' or 'list'");
            Console.WriteLine("\nset          - Sets the current theme. Provide a theme name to set that theme.");
            Console.WriteLine("generate     - Generates a new theme based on the current terminal state. Provide a name for the theme.");
            Console.WriteLine("download     - Downloads a theme from a github repository. Provide the repository in the format 'username.repositoryname'.");
            Console.WriteLine("reload       - Downloads the latest themes from the main TerminalChad themes repository.");
            Console.WriteLine("list         - Lists all installed themes.");
            return;
        }
        switch (input[1]) {
            case "set":
                if (input.Length > 2) {
                    ThemeLoader loader = new();
                    loader.LoadTheme(input[2]);
                }
                else {
                    Console.WriteLine("No theme provided. Please type 'terminalchad -t list' to view all existing themes.");
                }
                break;
            case "list":
                string themeDir = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Themes/";
                if (Directory.Exists(themeDir)) {
                    string[] themes = Directory.GetDirectories(themeDir);
                    Console.WriteLine("Installed Themes:");
                    foreach (string theme in themes) {
                        Console.WriteLine(" - " + Path.GetFileName(theme));
                    }
                }
                else {
                    Console.WriteLine("No themes directory found. Please run 'terminalchad -s' to set up TerminalChad.");
                }
                break;
            case "generate":
                if (input.Length > 2) {
                    Theme newTheme = new Theme(true, input[2]);
                    newTheme.Use();

                }
                else {
                    Console.WriteLine("Please provide a name for the new theme.");
                    Console.WriteLine("Example \n");
                    Console.WriteLine("terminalchad -t generate mynewtheme");
                }
                break;
            case "download":
                if (input.Length > 3) {
                    if (input[4] == "-m") {
                        ThemeDownloader loader = new();
                        loader.DownloadThemeZip(input[2], input[3], true);
                    }
                    else {
                        ThemeDownloader loader = new();
                        loader.DownloadThemeZip(input[2], input[3]);
                    }
                }
                else {
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
