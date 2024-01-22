$RunDirectory = Split-Path -Path $MyInvocation.MyCommand.Path -Parent

winget install --id=Neovim.Neovim  -e
git clone https://github.com/NvChad/NvChad %USERPROFILE%\AppData\Local\nvim --depth 1 && nvim
winget install zig.zig

Write-Host "Please restart your shell for certain changes to take place"
Read-Host;
