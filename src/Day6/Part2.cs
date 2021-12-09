namespace Day6;

public class Part2
{
    private readonly List<Lanternfish> _lanternfishes;

    public Part2(List<Lanternfish> lanternfishes)
    {
        _lanternfishes = lanternfishes;
    }

    public void Solve()
    {
        var tracker = new EfficientFishTracker(_lanternfishes);

        const int dayCount = 256;
        for (var i = 0; i < dayCount; ++i)
        {
            tracker.AdvanceDay();
        }

        Console.WriteLine($"After {dayCount} days there are {tracker.FishCount} fish.");
    }
}