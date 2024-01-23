const print = @import("std").debug.print;

pub fn ListMethods() void {
    print("Terminal Chad | Terminal Extension v0.0.1 \n", .{});
    print("Copyright (c) ChobbyCode 2024. All rights reserved. \n", .{});
    print("\n", .{});
    printTabbed("update   - Updates the application");
    printTabbed("install  - Installs the application");
    printTabbed("config   - Opens the config file");
}

fn printTabbed(comptime text: []const u8) void {
    print("    " ++ text ++ "\n", .{});
}
