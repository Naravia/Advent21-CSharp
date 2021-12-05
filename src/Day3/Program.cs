// See https://aka.ms/new-console-template for more information

using Day3;
async Task<IList<BinaryNumber>> LoadCommands(string input)
{
    var lines = await File.ReadAllLinesAsync(input);
    return lines
        .Select(binaryNumber => new BinaryNumber(binaryNumber))
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

Console.WriteLine("Solving Day 3 Part 1...");
new Part1(commands).Solve();

Console.WriteLine("Solving Day 3 Part 2...");
new Part2(commands).Solve();