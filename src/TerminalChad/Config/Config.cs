
using Newtonsoft.Json;

namespace TerminalChad.Config;

// The comment below was written on the 05/02/24

// Before anyone asks why we use yaml. We are using it as for unexperienced people can understand it a
// lot easier, because json can be difficult to read for config files which
// are edited by the user

// The comment below was written on the 21/02/24

// No we are actually going to use json because yaml is terrible, I am not bothering learning something new

public class Config
{
    //public string StartDirectory { get; set; } = "~";
    //public List<String> StartApplications { get; set; } = new List<String>();
    //public bool ForceLSPs { get; set; } = false;
    //public bool UsePlugins { get; set; } = false;
    public bool UseOldTitler { get; set; } = false;
    public int minTitleWidth { get; set; } = 103;

    public void WriteConfig()
    {
        //if (File.Exists($"{GlobalVariables.RoamingDirectory}config.json")) return;

        var yaml = JsonConvert.SerializeObject(this, Formatting.Indented);

        if (!File.Exists($"{GlobalVariables.RoamingDirectory}config.json"))
        {
            StreamWriter sz = new StreamWriter($"{GlobalVariables.RoamingDirectory}config.json");
            try
            {
                sz.Write("");
            }
            catch { }
            finally { sz.Close(); }
        }
        StreamWriter sw = new StreamWriter($"{GlobalVariables.RoamingDirectory}config.json");
        try
        {
            sw.Write(yaml);
        }
        catch { }
        finally { sw.Close(); }
    }

    public void ReadConfig()
    {
        if (!File.Exists($"{GlobalVariables.RoamingDirectory}config.json")) return;

        string configText = File.ReadAllText($"{GlobalVariables.RoamingDirectory}config.json");

        //json contains a string containing your YAML
        var p = JsonConvert.DeserializeObject<Config>(configText);

        // Update the variables
        //this.StartDirectory = p.StartDirectory;
        //this.StartApplications = p.StartApplications;
        //this.ForceLSPs = p.ForceLSPs;
        //this.UsePlugins = p.UsePlugins;
        this.UseOldTitler = p.UseOldTitler;
        this.minTitleWidth = p.minTitleWidth;
    }

    public void RunConfigInfo()
    {
        UpdateMinWidth();
    }

    private void UpdateMinWidth()
    {
        // Unfortunately this requires a rewrite of most of the themes code. :(
        // Later that day:
        // No I don't actually, I just can override it after it has originally created it :) Not good tho :(

        // Sorry

        List<string> _profileInformation = new List<string>();
        if (UseOldTitler == true) {
            _profileInformation = new List<string>(){
                "$RunDirectory = Split-Path -Path $MyInvocation.MyCommand.Path -Parent",
            "",
            "",
            "$ScreenWidth = (Get-Host).UI.RawUI.MaxWindowSize.Width",
            $"if({this.minTitleWidth} -lt $ScreenWidth)",
            "{",
            "   $starttext = $RunDirectory + \"\\startup-text.ps1\"",
            "       invoke-expression -Command $starttext",
            "}",
            "else ",
            "{",
            "   Clear-Host;",
            "   Write-Host \"Terminal Chad Small Mode\"",
            "}",
            "",
            "$ohmyposhLoc = $RunDirectory + \"\\src\\TerminalChad\\Config\\Posh\\config.json\"",
            "oh-my-posh.exe init pwsh --config $ohmyposhLoc  | Invoke-Expression"
            };
        }else
        {
            var Profile = new List<string>(){
            "",
            "$ohmyposhLoc = $RunDirectory + \"\\src\\TerminalChad\\Config\\Posh\\config.json\"",
            "oh-my-posh.exe init pwsh --config $ohmyposhLoc  | Invoke-Expression",
            ""
            };

            List<String> startText = File.ReadAllLines($"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/startup-text.ps1").ToList();

            foreach(string j in Profile)
            {
                startText.Add(j);
            }

            _profileInformation = startText;
        }

            // Combine array into one string
            var s = String.Empty;
        foreach(string h in _profileInformation)
        {
            s += h + "\n";
        }

        // This is defo gonna cause an bug in the future, I am totally going to forget I put this here.
        string ProfilesLocation = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/.active/profile.ps1";

        if (!File.Exists($"{GlobalVariables.RoamingDirectory}config.json"))
        {
            StreamWriter sz = new StreamWriter(ProfilesLocation);
            try
            {
                sz.Write("");
            }
            catch { }
            finally { sz.Close(); }
        }
        StreamWriter sw = new StreamWriter(ProfilesLocation);
        try
        {
            sw.Write(s);
        }
        catch { }
        finally { sw.Close(); }
    }
}
