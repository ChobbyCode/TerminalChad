<h1 align="center">Terminal Chad</h1>
<h6 align="center">Making your terminal giga again</h6>

## Indexes 

## Features

- Reworks look of Powershell
- Customisable startup message

### Also included with Terminal Chad (If the install script works as intended)
- [NeoVim](https://neovim.io)
- [NvChad](https://nvchad.com)
- [Zig 'The Chad Language'](https://ziglang.org)

## Installation

TerminalChad has a very simple way of installing itself. All you require is git, a nerd font and powershell. Run all the commands in powershell. If you have any issues, please build the app from scratch and report it in the issues tab.

## Dependecies

#### Required
- Nerd Font (any will do)
- Powershell + Windows Terminal
- Git

#### Extras
- Some random file editor (neovim recommended)
- Zig (only if building)

## Quick Install

#### 1. Clone git repo

```powershell
git clone "https://github.com/ChobbyCode/TerminalChad.git" %USERPROFILE%/appdata/roaming/TerminalChad/ --depth 1
```

#### 2. Setup $Profile for usage 

Open '$Profile' in prefered editor.

You can type this in powershell to get the location to the folder.
```powershell
$Profile
```
```powershell
nvim $Profile // Open in NeoVim
code $Profile // Open in VSCode
```

Add the following commands to the '$Profile' file:
```powershell
powershell -noprofile -noexit -command "invoke-expression'. ''"%USERPROFILE%/appdata/roaming/TerminalChad/profile.ps1"''' "
```

