
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TerminalChad.Config;

// Before anyone asks why we use yaml. We are using it as for unexperienced people can understand it a lot easier, because json can be difficult to read for config files which
// are edited by the user

public class Config
{
    public string StartDirectory { get; set; } = "~";
    public List<String> StartApplications { get; set; } = new List<String>();
    public bool forceLSPs { get; set; }

    public void WriteConfig()
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        var yaml = serializer.Serialize(this);
        if (!File.Exists($"{GlobalVariables.RoamingDirectory}config.yml"))
        {
            StreamWriter sz = new StreamWriter($"{GlobalVariables.RoamingDirectory}config.yml");
            try
            {
                sz.Write("");
            }
            catch { }
            finally { sz.Close(); }
        }
        StreamWriter sw = new StreamWriter($"{GlobalVariables.RoamingDirectory}config.yml");
        try
        {
            sw.Write( yaml );
        }catch { }
        finally { sw.Close(); }

        System.Console.WriteLine(yaml);
    }
}
