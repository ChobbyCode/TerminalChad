<h1 align="center">Terminal Chad</h1>
<h6 align="center">Making your terminal giga again</h6>

<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/cdf6a6fc-43d4-4405-9130-e4f2ac88f06d" alt="drawing" width="49%"> 
<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/ba39e2e6-047b-4138-b328-201f33a91a5a" alt="drawing" width="49%">
<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/2a409b0a-dc55-4d8c-8f09-2f1291d7a82d" alt="drawing" width="98%">


>>> ###### Images Subject To Change


## Indexes 

## Features (v0.1.1)

- Configurable themes for powershell
- Theme Switcher
- Dedicated Installer
- Ease Of Use
- Reworks Look & Feel Of Powershell
- Highly Customisable
- Package-manger-like Installer For User Themes

## Installation

TerminalChad has a very simple way of installing itself. All you require is git, a nerd font and powershell. Run all the commands in powershell. If you have any issues, please build the app from scratch and report it in the issues tab.

## Dependecies

Copy and paste the following commands into powershell to install all the dependecies:
```
winget install Microsoft.DotNet.SDK.8
winget install JanDeDobbeleer.OhMyPosh
winget install Neovim.Neovim
```
You also require the base fonts, you can download them by clicking below. Just extract the zip file and select all the fonts, then right click and install. [Credits NerdFonts](https://www.nerdfonts.com/font-downloads)

[Click here to download all the required nerd fonts in TerminalChad for the base themes](https://github.com/ChobbyCode/TerminalChad/raw/main/src/TerminalChad/Fonts/TerminalChad-Fonts.zip)

## Installing Application

## Via Installer

### 0. Run This Command

This command is required to be run as by default your system does not have a $Profile folder
```
New-Item -Path $profile -Type File -Force
```

### 1. Download Installer

Navigate to the releases page and download your selected Installer. Then run the Installer, follow the provided instructions.

### 2. Setup TerminalChad

Once you have installed TerminalChad, we next need to enable it. This is easily done by typing the following command in Windows Terminal:
```bash
TerminalChad setup
```

### 3. Selecting a Theme

To select a theme just type TerminalChad theme, this will give you a list themes.
We can then type the name of the theme after the command i.e.
```bash
terminalchad theme set
terminalchad theme set retro
```

There are several themes included in TerminalChad, however you can make your own:

[Click here to view how to make your own theme](https://github.com/ChobbyCode/TerminalChad/wiki/Themes)

## Non-install-supported Platforms

>> This is for non installer supported platforms

### 0. Run This Command

Breaking News: Run this command or stuff breaks
```
New-Item -Path $profile -Type File -Force
```

### 1. Clone Repository

Clone the following repository using git or download manually

```git
git clone "https://github.com/ChobbyCode/TerminalChad.git" --depth 1
```

### 2. Build Application

Navigate to the file "src/TerminalChad/TerminalChad.csproj" and open in Visual Studio or prefered editor. Build the application.
You can also build from command line.
```bash
cd src/TerminalChad/
dotnet build
```

### 3. Run from command line

>> Note this may not work if the application isn't added to the System Path Variable, application will do this automatically in the future

Run the following command from command line to see if the application is installed & setup correctly
```bash
terminalchad version
```

Then if it is installed we can run the following command, follow instructions from app from here:
```bash
terminalchad setup
```


## ToDo List

Before discussing the checklist, we should probably discuss what is the goal of TerminalChad:

The goal of TerminalChad is to remove the annoyance of setting up new computers with weird configuration and applications: when I was setting up neovim, it took me a whole 2 days: so I plan to change that to under 5 minutes.

- [x] Download Custom Themes
- [ ] Automatic Dependency Installation
- [ ] Package Manager
- [ ] Install all required tools on new computers
