This file will explain the architecture of how terminalchad handles themes.

This file will be helpful for debugging.

```
%appdata%
    | TerminalChad
        | .active
        | Microsoft.LanguageServerProtocols
        | Profiles
        | Scripts
        | Themes <-- Themes are stored here
        | tmp
        | config.json
        
```
The themes for terminalchad are stored in %appdata%/terminalchad/themes.
This is not yet configurable in settings, and is forced here.

Themes are stored in the themes directory

```
%appdata%
    | TerminalChad
        | config.json
        | Themes
            | default
                | config.json
                | profile.ps1
                | settings.json
                | startup-text.ps1
```

There are four files in a theme
- config.json
- profile.ps1
- settings.json
- startup-text.ps1

config.json is the config for OhMyPosh.

profile.ps1 is some setup configuration for when windows terminal starts up to make sure terminalchad functions properly.

settings.json is the colour scheme configuration for windows terminal.

startup-text.ps1 is the text which states TerminalChad when windows terminal starts up. This can be disabled in %appdata%/terminalchad/config.json. set UseOldTitler to false.