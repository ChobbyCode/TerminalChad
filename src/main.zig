const std = @import("std");
const print = std.debug.print();
const list = @import("Methods/list.zig");

// Methods Stuff
const Installer = @import("install.zig");

pub fn main() !void {
    // Get the arguments past into the application
    var general_purpose_allocator = std.heap.GeneralPurposeAllocator(.{}){};
    const gpa = general_purpose_allocator.allocator();
    const args = try std.process.argsAlloc(gpa);
    defer std.process.argsFree(gpa, args);

    if (args.len == 1) {
        list.ListMethods();
    }
}

fn processInput(i: []const u8) !void {
    // Ugly if statements because I don't think there's switch statements
    if (std.mem.eql(i, "install")) {
        Installer.Install();
    } else {
        print("Invalid 'chad' input");
    }
}

fn printTerminal(i: []const u8) !void {
    print(i ++ "\n", .{});
}
