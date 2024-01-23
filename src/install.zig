const std = @import("std");
const print = std.debug.print();

pub fn Install() void {
    print("Modifying Config Files & Other Important Stuff | This may take a moment... \n", .{});
}

/// Modifies the terminal config for colours and stuff
/// Location: C:\Users\jacob\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState\settings.json
fn ModifyTerminalConfig() !void {
    const TerminalConfig = "/AppData/Local/Packages/Microsoft.WindowsTerminal_8wekyb3d8bbwe/LocalState/settings.json";
    print(TerminalConfig, .{});
}
