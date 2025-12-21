
using TerminalChad.CLI;

namespace TerminalChad.Models.Versioning;

public class TerminalChadVersionInfo
{
    // This is meant to be converted into json and tells teminalchad the version of the json it is using

    public int packVersion { get; set; } = 1;
    public string version { get; set; }
    public string name { get; set; } = "TerminalChad";
    public string author { get; set; } = "ChobbyCode";

    public TerminalChadVersionInfo()
    {
        version = Program.version;
    }
}
