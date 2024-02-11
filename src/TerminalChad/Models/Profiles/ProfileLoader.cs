﻿
using Newtonsoft.Json;
using TerminalChad.Models.Profiles.Models;
using TerminalChad.Profiles.Installer;
using TerminalChad.Themes;

namespace TerminalChad.Models.Profiles;

public class ProfileLoader
{
    private String _profile { get; set; } = String.Empty;

    private String ProfileFolder = $"C:/users/{Environment.UserName}/appdata/roaming/TerminalChad/Profiles/";

    public void LoadProfile(String Profile)
    {
        _profile = Profile.ToLower();
        if (Directory.Exists(Path.Combine(ProfileFolder, _profile)))
        {
            InstallProfile();
        }
        else
        {
            Console.WriteLine("Profile doesn't exist");
        }
    }

    private void InstallProfile()
    {
        InstallApplications();
        SetTheme();
    }

    private void SetTheme()
    {
        ThemeGet? themeGet = JsonConvert.DeserializeObject<ThemeGet>(
            File.ReadAllText($"{ProfileFolder}{_profile}/theme.json"));
        if (themeGet == null) return;

        ThemeDownloader themeDownloader = new ThemeDownloader();
        themeDownloader.DownloadThemeZip(themeGet.GetURI, themeGet.SaveName, true);

        ThemeLoader themeLoader = new ThemeLoader();
        themeLoader.LoadTheme(themeGet.ApplyName);
    }

    private void InstallApplications()
    {
        ApplicationsInstall? InstallApplications = JsonConvert.DeserializeObject<ApplicationsInstall>(
            File.ReadAllText($"{ProfileFolder}{_profile}/applications.json"));
        if (InstallApplications == null) return;

        ApplicationInstaller Installer = new ApplicationInstaller();
        foreach(var a in InstallApplications.Applications)
        {
            Installer.DownloadApplication(a);
        }
    }
}