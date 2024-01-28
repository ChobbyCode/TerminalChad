<h1 align="center">Terminal Chad</h1>
<h6 align="center">Making your terminal giga again</h6>

## Indexes 

## Features

- Reworks look of Powershell
- Customisable startup message

## Installation

TerminalChad has a very simple way of installing itself. All you require is git, a nerd font and powershell. Run all the commands in powershell. If you have any issues, please build the app from scratch and report it in the issues tab.

## Dependecies

#### Required
- Nerd Font [(Here is the required one for the default theme)](https://github.com/ryanoasis/nerd-fonts/releases/download/v3.1.1/Terminus.zip)
- Powershell + Windows Terminal
- [Dotnet 8.0 RunTime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.101-windows-x64-installer)

## Installing Application

>> This is for non installer supported platforms

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