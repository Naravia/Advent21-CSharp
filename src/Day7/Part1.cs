namespace Day7;

public class Part1
{
    private readonly List<CrabPosition> _crabs;

    public Part1(List<CrabPosition> crabs)
    {
        _crabs = crabs;
    }

    public void Solve()
    {
        var analyzer = new CrabAnalyzer(_crabs);
        Console.WriteLine($"Sum: {analyzer.CalculateCheapestFuelPosition()}");
    }
}