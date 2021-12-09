namespace Day6;

public class EfficientFishTracker
{
    private const int MAX_LIFESPAN = 11;
    private readonly long[] _fishes = new long[MAX_LIFESPAN];
    private int _day;

    public EfficientFishTracker(List<Lanternfish> lanternfishes)
    {
        foreach (var fish in lanternfishes)
        {
            _fishes[fish.SpawnTimer]++;
        }
    }

    public long FishCount => _fishes.Sum();

    private int GetDayIndex(int daysFromNow)
    {
        return (_day + daysFromNow) % MAX_LIFESPAN;
    }

    public void AdvanceDay()
    {
        _day++;
        var resetIndex = GetDayIndex(6);
        var spawnedFishIndex = GetDayIndex(8);
        var dayIndex = GetDayIndex(-1);
        _fishes[resetIndex] += _fishes[dayIndex];
        _fishes[spawnedFishIndex] += _fishes[dayIndex];
        _fishes[dayIndex] = 0;
    }
}