using Day5;

async Task<IList<GraphLine>> LoadMappings(string input)
{
    var lines = await File.ReadAllLinesAsync(input);
    return lines
        .Select(mapping => new GraphLine(mapping))
        .ToList();
}

const string file = "input.txt";
if (!File.Exists(file))
{
    await Console.Error.WriteLineAsync($"Cannot find file {file}, exiting");
    return;
}


Console.WriteLine($"Loading input from {file}");
var mappings = await LoadMappings(file);

Console.WriteLine("Solving Day 5 Part 1...");
new Part1(mappings).Solve();

Console.WriteLine("Solving Day 5 Part 2...");
new Part2(mappings).Solve();