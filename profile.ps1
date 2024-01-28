$RunDirectory = Split-Path -Path $MyInvocation.MyCommand.Path -Parent


$ScreenWidth = (Get-Host).UI.RawUI.MaxWindowSize.Width
if(103 -lt $ScreenWidth)
{
    $starttext = $RunDirectory + "\startup-text.ps1"
        invoke-expression -Command $starttext
}
else
{
    Clear-Host;
    Write-Host "Terminal Chad Small Mode"
}

$ohmyposhLoc = $RunDirectory + "\src\TerminalChad\Config\Posh\config.json"
oh-my-posh.exe init pwsh --config $ohmyposhLoc  | Invoke-Expression


