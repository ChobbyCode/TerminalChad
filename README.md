<h1 align="center">Terminal Chad</h1>
<h6 align="center">Configurable, Themes, Profiles.</h6>

<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/cdf6a6fc-43d4-4405-9130-e4f2ac88f06d" alt="drawing" width="49%"> 
<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/ba39e2e6-047b-4138-b328-201f33a91a5a" alt="drawing" width="49%">
<img src="https://github.com/ChobbyCode/TerminalChad/assets/100038952/2a409b0a-dc55-4d8c-8f09-2f1291d7a82d" alt="drawing" width="98%">


## Features (for v1.0.0)

- Themes Provided By [TerminalChadThemeRepository](https://github.com/ChobbyCode/TerminalChadThemes)
- Profiles To Quickly Swap Between Themes, Installed Programs, & Quickscripts

### Experimental Features

- Quickscipts | Powershell scripts which can automatically run to complete a task, instead of manually having to execute a ps1 or bat script, it will execute when a condition is met. Must be enabled through settings.

<h1><u><b>How To Install</b></u></h1>

As of TerminalChad v0.2.0, the installation process for TerminalChad is rather simple. Just follow the steps laid out below to make sure you have it up and running fully.

## Dependencies

- Windows Terminal. This can be downloaded from the Microsoft Store.
- [TerminalChad uses some nerd fonts, click here to download the required ones.](https://github.com/ChobbyCode/TerminalChad/raw/main/src/TerminalChad/Fonts/TerminalChad-Fonts.zip)
- TerminalChad uses OhMyPosh. OhMyPosh will automatically install with the installer.

<h2><u>Download The Installer</u></h2>

To install TerminalChad, first download the installer from the releases tab. 

The installer will ask for an install drive. Depending on your computer you may have a C drive, D drive etc. Please provide the drive you want to install the program on. 

### From the command line

Open up Windows Terminal and type the following command to check that terminalchad is installed. Type one of the following commands into terminalchad.

```
terminalchad which
terminalchad version
```
> This will return the location at which terminalchad is installed to.
> This will return the version of terminalchad which is installed.

# How To Use Terminal Chad

In a console type:
### terminalchad [operator] [operator] [operator]

### How to setup terminalchad

Run:
```
terminalchad setup
```
> This will create the required directories in %appodata%/terminalchad which are required for the application to run. You may notice that the theme of your console changes when you run this command. 

The setup operator may change your theme of your windows terminal. If you already had a theme setup and want to restore it, simply type - in order:
```
terminalchad theme restore
terminalchad theme generate RestorePoint
```
> The 'restore' operator will swap the theme back to the last applied theme
> The 'generate' operator will generate a terminalchad theme called RestorePoint which you can swap to any point

Once you have ran those commands please type the following command:
```
terminalchad theme set default
```

Then when you want to swap to your old configuration, you can freely type:
```
terminalchad theme set RestorePoint
```
> [!Warning]
> For this to work, you must have ran the terminalchad theme generate RestorePoint command

## Features

### Themes

#### Themes list

Below gets a list of all the themes on your device
```
terminalchad theme list
```

#### Themes set

``` 
terminalchad theme set [theme_name]
```
> where it says theme_name provide a theme you have installed which you would be able to get with the list operator

#### Themes reload
```
terminalchad theme reload
```
> Downloads the latest themes provided by the TerminalChadTheme Library

#### Themes download
```
terminalchad theme download user.repo
```
> this uses the same format as how neovim plugins are typically installed. 

An example of a complete command that would work is provided below:
```
terminalchad theme download chobbycode.terminalchadthemes
```
By default the terminalchadtheme command will download from the main branch, if a theme library has the themes on the master branch you can run the following:
```
terminalchad theme download chobbycode.terminalchadthemes / -m
```
> this command is how you'd download the latest terminalchadtheme library prior to terminalchad v0.1.2. from tc 0.1.2 you can use reload

#### Themes generate

```
terminalchad theme generate [theme_name]
```
This will create a new theme from your current windows terminal configuration which you can easily share to your friends. 
> [!Warning]
> Make sure to swap [theme_name] or for the name of the theme which you want to call it

#### Themes export

Not implemented yet.

### Profiles

Profiles are similar to themes but expand upon what's included in them.

