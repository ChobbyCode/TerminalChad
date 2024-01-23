const std = @import("std");
const list = @import("Methods/list.zig");

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
