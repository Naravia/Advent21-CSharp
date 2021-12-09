using Day7;

async Task<List<CrabPosition>> LoadCrabPositionsAsync(string input)
{
    var values = await File.ReadAllTextAsync(input);
    return values
        .Split(',')
        .Select(int.Parse)
        .Select(i => new CrabPosition(i))
        .ToList();
}

const string puzzleFile = "input.txt";
const string sampleFile = "sample_input.txt";

if (!File.Exists(sampleFile))
{
    await Console.Error.WriteLineAsync($"Cannot find file {sampleFile}, exiting");
    return;
}
if (!File.Exists(puzzleFile))
{
    await Console.Error.WriteLineAsync($"Cannot find file {puzzleFile}, exiting");
    return;
}

Console.WriteLine($"Loading input from {sampleFile}");
var sampleCrabs = await LoadCrabPositionsAsync(sampleFile);

Console.WriteLine($"Loading input from {puzzleFile}");
var puzzleCrabs = await LoadCrabPositionsAsync(puzzleFile);


Console.WriteLine("Solving Day 6 Part 1 (Sample) ...");
new Part1(sampleCrabs).Solve();
Console.WriteLine("Solving Day 6 Part 1 (Puzzle) ...");
new Part1(puzzleCrabs).Solve();

Console.WriteLine("Solving Day 6 Part 2 (Sample) ...");
new Part2(sampleCrabs).Solve();
Console.WriteLine("Solving Day 6 Part 2 (Puzzle) ...");
new Part2(puzzleCrabs).Solve();
