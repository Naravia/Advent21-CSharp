using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Day1;

async Task<IList<Depth>> LoadDepths(string input)
{
    var lines = await File.ReadAllLinesAsync(input);
    return lines
        .Select(int.Parse)
        .Select(i => new Depth(i))
        .ToList();
}

void Day1Part2(IList<Depth> depths)
{
    var window = new[]
    {
        depths[0],
        depths[1],
        depths[2]
    };
    var windowIdx = 0;
}

const string file = "input.txt";
if (!File.Exists(file))
{
    await Console.Error.WriteLineAsync($"Cannot find file {file}, exiting");
    return;
}

Console.WriteLine($"Loading input from {file}");
var depths = await LoadDepths(file);

Console.WriteLine("Solving Day 1 Part 1...");
new Part1(depths).Solve();

Console.WriteLine("Solving Day 1 Part 2...");
new Part2(depths).Solve();