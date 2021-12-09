namespace Day6;

public class FishTracker
{
    private readonly Queue<Lanternfish> _fishQueue = new();
    private readonly Queue<Lanternfish> _spawnQueue = new();
    private int _day;
    private int _index;

    public FishTracker(List<Lanternfish> lanternfishes)
    {
        _index = lanternfishes.Max(f => f.Index);
        foreach (var lanternfish in lanternfishes.OrderBy(f => f.SpawnTimer))
        {
            _fishQueue.Enqueue(lanternfish);
        }
    }

    public void AdvanceDay()
    {
        ++_day;
        while (_fishQueue.Peek().SpawnTimer - _day < 0)
        {
            _fishQueue.Enqueue(_fishQueue.Dequeue() with {SpawnTimer = _day + 6});
            _spawnQueue.Enqueue(new Lanternfish(_day + 8, ++_index));
        }

        while (_spawnQueue.Count > 0 && _spawnQueue.Peek().SpawnTimer - _day == 6)
        {
            _fishQueue.Enqueue(_spawnQueue.Dequeue());
        }
    }

    public string CalculateCurrentState()
    {
        var fishByIndex = CalculateFishState()
            .Select(f => f.SpawnTimer.ToString());

        return $"Day {_day}: {fishByIndex.Aggregate((x, y) => $"{x},{y}")}";
    }

    public IEnumerable<Lanternfish> CalculateFishState()
    {
        return _fishQueue
            .Concat(_spawnQueue)
            .OrderBy(f => f.Index)
            .Select(f => f with {SpawnTimer = f.SpawnTimer - _day});
    }

    public int FishCount => CalculateFishState().Count();
}