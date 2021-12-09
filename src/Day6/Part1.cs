namespace Day6;

public class Part1
{
    private readonly List<Lanternfish> _lanternfishes;

    public Part1(List<Lanternfish> lanternfishes)
    {
        _lanternfishes = lanternfishes;
    }

    public void Solve()
    {
        var tracker = new FishTracker(_lanternfishes);

        for (var i = 0; i < 80; ++i)
        {
            tracker.AdvanceDay();
        }

        var fish = tracker.CalculateFishState();
        Console.WriteLine($"After 80 days there are {fish.Count()} fish.");
    }
}