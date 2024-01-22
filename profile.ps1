$RunDirectory = Split-Path -Path $MyInvocation.MyCommand.Path -Parent


$ohmyposhLoc = $RunDirectory + "\Oh-My-Posh\config.json"
oh-my-posh.exe init pwsh --config $ohmyposhLoc  | Invoke-Expression
