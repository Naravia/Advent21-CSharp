namespace Day7;

public class Part2
{
    private readonly List<CrabPosition> _crabs;

    public Part2(List<CrabPosition> crabs)
    {
        _crabs = crabs;
    }

    public void Solve()
    {
        var analyzer = new AdvancedCrabAnalyzer(_crabs);
        Console.WriteLine($"Sum: {analyzer.CalculateCheapestFuelPosition()}");
    }
}