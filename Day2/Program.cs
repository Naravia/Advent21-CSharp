using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Day2;

async Task<IList<SubmarineCommand>> LoadCommands(string input)
{
    var lines = await File.ReadAllLinesAsync(input);
    return lines
        .Select(command => new SubmarineCommand(command))
        .ToList();
}

const string file = "input.txt";
if (!File.Exists(file))
{
    await Console.Error.WriteLineAsync($"Cannot find file {file}, exiting");
    return;
}

Console.WriteLine($"Loading input from {file}");
var commands = await LoadCommands(file);

Console.WriteLine("Solving Day 2 Part 1...");
new Part1(commands).Solve();

Console.WriteLine("Solving Day 2 Part 2...");
new Part2(commands).Solve();