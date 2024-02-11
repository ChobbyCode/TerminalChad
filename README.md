<h1 align="center">Terminal Chad</h1>
<h6 align="center">Making your terminal giga again</h6>

<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/cdf6a6fc-43d4-4405-9130-e4f2ac88f06d" alt="drawing" width="49%"> 
<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/ba39e2e6-047b-4138-b328-201f33a91a5a" alt="drawing" width="49%">
<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/2a409b0a-dc55-4d8c-8f09-2f1291d7a82d" alt="drawing" width="98%">


>>> ###### Images Subject To Change


## Indexes 

## Features (v0.2.31)

- Configurable themes for powershell
- Theme Switcher
- Dedicated Installer
- Ease Of Use
- Reworks Look & Feel Of Powershell
- Highly Customisable
- Package-manger-like Installer For User Themes
- Updater

## Experimental (for v0.2.31)

- Profiles & Mass-Application Configuration

## Installation

TerminalChad has a very simple way of installing itself. All you require is git, a nerd font and powershell. Run all the commands in powershell. If you have any issues, please build the app from scratch and report it in the issues tab.

## Required Fonts

[Click here to download all the required nerd fonts in TerminalChad for the base themes](https://github.com/ChobbyCode/TerminalChad/raw/main/src/TerminalChad/Fonts/TerminalChad-Fonts.zip)

## Installing Application

## Via Installer

### 1. Run This Command

This command is required to be run as by default your system does not have a $Profile folder
```
New-Item -Path $profile -Type File -Force
```

### 2. Download Installer

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

## Updating

To update the application you can run the following command:
>> ###### The true is required as that puts the application in automatic mode
```
TerminalChadUpdate true
```

## Uninstall

To uninstall the application, you can download the installer and select the 'Uninstall' option instead. Make sure you pass in the drive you installed TerminalChad on.


## ToDo List

View the trello board [here](https://trello.com/b/IuorHvB0/terminalchad)

Before discussing the checklist, we should probably discuss what is the goal of TerminalChad:

The goal of TerminalChad is to remove the annoyance of setting up new computers with weird configuration and applications: when I was setting up neovim, it took me a whole 2 days: so I plan to change that to under 5 minutes.

- [x] Download Custom Themes
- [x] Automatic Dependency Installation
- [ ] Package Manager
- [ ] Install all required tools on new computers
- [ ] Mass Configuration

View more on the [trello board](https://trello.com/b/IuorHvB0/terminalchad)
