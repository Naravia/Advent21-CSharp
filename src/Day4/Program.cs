// See https://aka.ms/new-console-template for more information

using Day4;

async Task<(IList<int> calls, IList<BingoBoard> boards)> LoadBoards(string input)
{
    var lines = await File.ReadAllLinesAsync(input);

    var calls = lines
        .First()
        .Split(',')
        .Select(int.Parse)
        .ToList();

    var boards = new List<BingoBoard>();
    for (var idx = 1; idx < lines.Length; ++idx)
    {
        var line = lines[idx].Trim();
        if (line is {Length: 0})
        {
            continue;
        }
        
        boards.Add(new BingoBoard(lines.Skip(idx).Take(5)));
        idx += 5;
    }

    return (calls, boards);
}

const string file = "input.txt";
if (!File.Exists(file))
{
    await Console.Error.WriteLineAsync($"Cannot find file {file}, exiting");
    return;
}

Console.WriteLine($"Loading input from {file}");
var (calls, boards) = await LoadBoards(file);

Console.WriteLine("Solving Day 4 Part 1...");
new Part1(calls, boards).Solve();

Console.WriteLine("Solving Day 4 Part 2...");
new Part2(calls, boards).Solve();