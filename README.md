<h1 align="center">Terminal Chad</h1>
<h6 align="center">Making your terminal giga again</h6>

## Indexes 

## Installation

To install the application run the following command:

## Dependecies

#### Required
- Nerd Font (any will do)
- Powershell + Windows Terminal

#### Extras
- Some random file editor (neovim recommended)
- Zig (only if building)

## Quick Install

#### 1. Clone git repo

>> Please make sure you change 'YOU' to your actual user
```powershell
git clone "https://github.com/ChobbyCode/TerminalChad.git" C:/users/YOU/appdata/roaming/TerminalChad/ --depth 1
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
>> Please make sure you change 'YOU' to your actual user
```powershell
powershell -noprofile -noexit -command "invoke-expression'. ''"C:/users/YOU/appdata/roaming/TerminalChad/profile.ps1"''' "
```

