# <div align="center">Installer Jazz</div>
<div align="center">The worst way to handle installing an application</div>

## How To Use This?

InstallerJazz is designed to be a quick and cheeky way to get simple applications installing and ready to go. If you're developing a simple hobby project, then this is for you. If you're creating a commercial application, or a full scale application which will be used my hundreds of people, then it would be better to use the windows installer (msi). InstallerJazz can be used as a quick way to share programs. Say your friend wants to try out your program but you don't want to send them the source code, and have they compile it? Then instead spend two or three minutes creating an installer with installer jazz and send the exe file to them. 

#### *Pros*
- Quick to setup, and easy to use
- Easily debuggable
- No hassle
#### *Cons*
- Not configurable for large applications. For example if file X needs to go here, and file Y needs to go here
- Is designed with Windows machines in mind, so may not work as intended on Linux, or MacOS. 

This is a combination of the installers that I have developed for [Micro Macro](https://github.com/ChobbyCode/MicroMacro), and [Terminal Chad](https://github.com/ChobbyCode/TerminalChad) which have been put into a collection of about 50 dlls to make it a bit easier to make an installer. If you are going to use this it would be easier to just use the windows installer thing. I only made this to be awkward.

## Dependencies

- Dotnet
- Visual Studio, or Someway To Compile & Debug C# Code. 

## Step 1: Clone this repository

![image](https://github.com/user-attachments/assets/3f4284b7-fde7-44b5-a2b7-493add16db2a)

You first need to clone the repository. This can be done through visual studio, vscode, or git. Or you can click the blue code button at the top of this page, and then hit download zip. 

## Step 2: Open Solution & Add New Project

![image](https://github.com/user-attachments/assets/c73aa001-3d72-4b06-ab2e-abec563c2092)

Next, open the solution in visual studio, or neovim, and add a new console application to the solution. The recommended naming scheme for this program is '[PROGRAM]Installer' where [PROGRAM] is the name of your application.

![image](https://github.com/user-attachments/assets/26532cdf-24bd-454f-a283-ac3408a2dd8b)

Inside visual studio, right click on the project, and click Add > Project Reference. Check the box which says InstallerJazz, you do not need references to the other projects. If you add references to the other projects it may make the installer slower, and have a greater file size.

## Step 3: Copy This Demo Code

If you're not exactly sure how to do this, there is a Demo Installer project in the solution simply called 'Demo' and is fully set out to install one of my other applications called Terminal Chad. 

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

Have a good read through this code to become familiar with the layout of InstallerJazz. This is actually the only code you need to write to get InstallerJazz functioning. 

#### For further documentation on how the installer arguments work, please see [here](https://github.com/ChobbyCode/InstallerJazz/blob/master/Docs/InstallArguments.md)

## Step 4: Setting A Location For The Application To Get The Binary Files From

### Method 1:

If you already have a dedicated loation where a zip ball file for the binaries of the application can be downloaded you can skip method 2. 

Instead, update the InstallArguments with relative information:

```
SourceURL = "https://WEBSITE.COM/URL/TO/YOUR/ZIP/BALL/DOWNLOAD",
```

### Method 2:

![image](https://github.com/user-attachments/assets/2c2a84be-8c8d-4a37-9fa3-445fb32a9ebb)

If you dont have a dedicated site for a zipball of your application to be downlaoded from, then we can utilise github branches to store the binaries for us. 

Create a new github branch on a **PUBLIC** repository, and name it something simple such as InstallerFiles. Then update the Installer arguments as such:

>[!WARNING]
>The url must be in the format of 'https://github.com/[USER]/[REPO]/zipball/[BRANCH]'. You **MUST** make sure you include the 'zipball' in the url or it will download a HTML page instead, and try to install the HTML page. 

```
SourceURL = "https://github.com/ChobbyCode/TerminalChad/zipball/InstallerFiles",
```

On this branch, we can then upload all the binary files for your program. Make sure you remove any vunerable files such as .db .pdb or as such which may contain system information about your computer. As this is public and what gets installed on other's computers!

## Produce A Single Exe Application

If you are creating an installer, you likely just want a single .exe file. Fortuantly this isn't TOO complicated and can be done in a few steps.

### Go Build > Publish 

<img width="376" height="324" alt="image" src="https://github.com/user-attachments/assets/193f40c7-aa2f-4c2a-90e5-5d8d242637b4" />

Go Build > Publish within Visual Studio.

<img width="823" height="586" alt="image" src="https://github.com/user-attachments/assets/9d3af334-6646-4825-965d-58d3fb9217c8" />

Select Folder as the target output.

<img width="821" height="584" alt="image" src="https://github.com/user-attachments/assets/28fe40ac-b5b2-48ce-9812-2dedb99b9d19" />

Folder again.

<img width="814" height="582" alt="image" src="https://github.com/user-attachments/assets/0ccf05a2-6cc5-4469-becc-9170f6d93be6" />

This can be left the same, then click finish.

<img width="891" height="260" alt="image" src="https://github.com/user-attachments/assets/74b9ad50-9c0a-49ec-bd7b-d357c7ecfbf0" />

Click on 'Show All Settings'

<img width="576" height="533" alt="image" src="https://github.com/user-attachments/assets/db15e39c-94bd-4bf7-8c3b-7e1187fc050d" />

<img width="566" height="519" alt="image" src="https://github.com/user-attachments/assets/5e400c16-b1b7-4184-af26-6f843db311d1" />

Change Deployment Method to say 'Self-Contained'.

Change Target Runtime to 'win-x86', make sure the architecture is the same architecture as your CPU, or the application won't work.

IMPORTANT: Make sure you click the drop down which appeasrs and check Produce Single File.

Now You Can Click Save.

<img width="916" height="96" alt="image" src="https://github.com/user-attachments/assets/302ff9b9-bf52-47eb-8a3a-3c8d5fd214dc" />

Press The Publish Button. Then Navigate To The Location Where It Says It Published To. You can find this where it says target location.

<img width="431" height="29" alt="image" src="https://github.com/user-attachments/assets/62e32d94-5182-4340-802e-f3f2955a9639" />

## Further Functionality: Updating A Prexisting Application

InstallerJazz also has capabilities to update prexisting applications.

Simply, create a new branch, similarly to what we did for the binary files, and name it VersionInformation. On this branch create one file called version.json and put the following json code into it:

```
{
    "Version": 1
}
```

Now, inside of your Install Arguments modify the following:

```
EnableUpdateFeature = true,
```

We must make sure the Update Feature is enabled in the first place, or it would just be a waste.

```
VersionInfoURL = "https://github.com/[USER]/[REPO]/zipball/VersionInformation",
```

Similarly to how we set the location up for the installer binary files, we can do the same for the Version Information

>[!WARNING]
>The url must be in the format of 'https://github.com/[USER]/[REPO]/zipball/[BRANCH]'. You **MUST** make sure you include the 'zipball' in the url or it will download a HTML page instead, and the installer application will throw an exception.

### This Bit Is Important So Read Carefully

You must package the installer inside of the binary files of your original application. Then have your original application invoke the Installer application and immedietly terminate itself using the Process.Start method. 
Examples can be seen in [MicroMacro](https://github.com/ChobbyCode/MicroMacro). Note, if you do check MicroMacro on how to properly do this, MicroMacro uses an out of date version of InstallerJazz, and may function slightly differently to the current version but the concepts of downloading the files and invoking the Process.Start is the exact same. 

Everytime you update you application where the binary files are stored, you must incrememnt the "Version": ... in version.json on your VersionInformation branch. Then every time you bundle the updater with the binary files you must increment the version inside the InstallerArguments. Yes, this does mean recompiling every single time, AND will likely change in the future, however currently this is the best way of doing this. 
