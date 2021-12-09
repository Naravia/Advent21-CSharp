using Day6;

async Task<List<Lanternfish>> LoadLanternfish(string input)
{
    var csv = await File.ReadAllTextAsync(input);
    var columns = csv.Split(',');
    return columns
        .Select(int.Parse)
        .Select((spawnTimer, idx) => new Lanternfish(spawnTimer, idx))
        .ToList();
}

const string file = "input.txt";
if (!File.Exists(file))
{
    await Console.Error.WriteLineAsync($"Cannot find file {file}, exiting");
    return;
}

Console.WriteLine($"Loading input from {file}");
var fish = await LoadLanternfish(file);

Console.WriteLine("Solving Day 6 Part 1...");
new Part1(fish).Solve();

Console.WriteLine("Solving Day 6 Part 2...");
new Part2(fish).Solve();