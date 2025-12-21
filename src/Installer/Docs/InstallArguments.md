# How The Install Arguments Work

This documentation file will fully explain how the Install Arguments work.

First, if not already, either open the Demo project in the solution, or create your own and copy this code. Remember to add all the required project references. If you don't know how to do this, see the README.md in the root folder.

```
using InstallerJazz;
using InstallerJazz.Models;

namespace DemoInstaller;

public class Program {
    public static void Main(string[] args) {
        InstallArguments installArguments = new InstallArguments() {
            WindowName = "DemoInstaller", // Console name
            Website = "https://github.com/ChobbyCode/TerminalChad", // Either your project's website, or source code
            HelpURL = "https://github.com/ChobbyCode/TerminalChad/issues", // Have this redirect to where users can get help, or make a support request. If you are unsure have it redirect to the github issues page
            AppVersion = 0, // Quite Important To Set This To The Correct Value

            SourceURL = "https://github.com/ChobbyCode/TerminalChad/zipball/InstallerFiles", // The url where it will download the program from
            VersionInfoURL = "https://github.com/ChobbyCode/TerminalChad/zipball/VersionInformation", // Information on the version of the application

            InstallDotNet = true, // As this is meant for c# apps, it is designed to also automatically install dotnet
            EnableInstallFeature = true, // Select which features you want to have enabled
            EnableUninstallFeature = true,
            EnableUpdateFeature = true,

            TargetLocation = "\\Program Files\\TerminalChad\\", // Relative Location Where The App Will Be Installed
            AllowUsersToChooseInstallDrive = true, // If this is enabled it allows the users to choose full install drive. If not target location will have to be change to a full path so "C:\ProgramFiles..."
        };

        AppPackager appPackager = new AppPackager(args, installArguments);
    }
}
```

The code above is configured to install TerminalChad which is another application of mine. 

Each part will now be explained.

### Installer Arguments

```
InstallArguments installArguments = new InstallArguments();
```

This is how you configure the settings of the installer. You can have multiple settings, and have them chosen based off application arguments.

```
InstallArguments installArgs1 = new InstallArguments();
InstallArguments installArgs2 = new InstallArguments();
InstallArguments installArgs3 = new InstallArguments();

switch (args[0]) {
    case "1":
        AppPackager appPackager1 = new AppPackager(args, installArgs1);
        break;
    case "2":
        AppPackager appPackager2 = new AppPackager(args, installArgs2);
        break;
    case "3":
        AppPackager appPackager3 = new AppPackager(args, installArgs3);
        break;
}     
```

You could even have it dynamically choose arguments based off which application is starting it.

### App Packager

```
AppPackager appPackager = new AppPackager(args, installArguments);
```

This will automatically start the installation process after a new appPackager is defined. It takes in the Install Arguments at that is all. 

### Basic Information

```
WindowName = "DemoInstaller", 
Website = "https://github.com/ChobbyCode/TerminalChad",
HelpURL = "https://github.com/ChobbyCode/TerminalChad/issues",
```

There is some basic information at the top of the InstallArgument. 

WindowName will be the name of the Console. 

Website will point to the website of your project. If you don't have one leave it blank, but it is recommended to at least point to the source code. 

HelpURL will be the support page of your project. If you don't have one leave it blank, but it is recommended to at least point to the issues page on your github. 

### AppVersion

> [!WARNING]
> ONLY REQUIRED IF YOU HAVE THE UPDATE FEATURE ENABLED

```
AppVersion = 0,
```

If you are using the update feature of the installer, it is very important that you make sure to increment the app version every time as when the application downloads the latest application information it will check to see if the AppVersion of the available application is greater than the AppVersion of the installed application. In the future, this may be extrapolated into a separate AppVersion.json file, so you don't have to recompile every single time. 

### Install Options

```
InstallDotNet = true, 
EnableInstallFeature = true, 
EnableUninstallFeature = true,
EnableUpdateFeature = true,
```

These should be self explanatory.

InstallDotNet automatically installs dotnet, it is recommended to keep this enabled.

Enable****Feature, you can choose which features of the application it is bundled with as you please. 

### Target Location

```
TargetLocation = "\\Program Files\\TerminalChad\\",
AllowUsersToChooseInstallDrive = true,
```

If you want the user to be able to pick what drive the application installs on, do the above. 

If the user picks the install drive make sure it is a relative path, so if they chose the E drive the TargetLocation which be concatenated to 'E:\ProgramFiles\TerminalChad\'

```
TargetLocation = "C:\\Program Files\\TerminalChad\\",
AllowUsersToChooseInstallDrive = false,
```

Here is the code which you would have to do if the user had no chose in where the application was installed.

> Note: Applications cannot install per user, and only globally if you do it this way