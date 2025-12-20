using Newtonsoft.Json;
using TerminalChad.Models.Versioning;
using TerminalChad.Json.Extensions;

namespace TerminalChad.Models.Profiles;

/// <summary>
/// This helps TerminalChad to understand how to configure an application
/// </summary>
public class ConfigurationInformation
{
    public TerminalChadVersionInfo def { get; set; } = new TerminalChadVersionInfo();
    public string URI { get; set; } = String.Empty;

    public string toJson()
    {
        return this.toJson(Formatting.Indented);
    }
}
