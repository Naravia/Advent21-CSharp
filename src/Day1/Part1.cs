namespace Day1;

public class Part1
{
    private readonly IList<Depth> _depths;

    public Part1(IList<Depth> depths)
    {
        _depths = depths;
    }

    public void Solve()
    {
        var previousDepth = _depths.First();
        var largerMeasurements = 0;
        foreach (var depth in _depths)
        {
            if (depth.Amount > previousDepth.Amount)
            {
                ++largerMeasurements;
            }

            previousDepth = depth;
        }

        Console.WriteLine($"{largerMeasurements} measurement(s) are larger than the previous measurement.");
    }
}