const std = @import("std");
const fs = std.fs;

pub fn main() !void {
    try deleteSettingsFile();
}

pub fn deleteSettingsFile() !void {
    const stdout = std.io.getStdOut().writer();
    try stdout.print("Hello, {s}!\n", .{"world"});

    ask_user("Hello, World");
}

fn ask_user(i: []const u8) ![]const u8 {
    const stdin = std.io.getStdIn().reader();
    const stdout = std.io.getStdOut().writer();

    var buf: [10]u8 = undefined;

    try stdout.print(i, .{});

    if (try stdin.readUntilDelimiterOrEof(buf[0..], '\n')) |user_input| {
        return user_input;
    } else {
        return @as([]const u8, "");
    }
}
