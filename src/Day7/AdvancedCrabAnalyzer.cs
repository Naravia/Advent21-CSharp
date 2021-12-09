namespace Day7;

public class AdvancedCrabAnalyzer
{
    private readonly List<CrabPosition> _crabs;

    public AdvancedCrabAnalyzer(IEnumerable<CrabPosition> crabs)
    {
        _crabs = crabs
            .OrderBy(c => c.HorizontalPosition)
            .ToList();
    }

    private static int CalculateSteps(int steps)
    {
        return Enumerable.Range(1, steps).Sum();
    }

    private int CalculateFuelCost(int target)
    {
        return _crabs
            .Select(c => c.HorizontalPosition.AbsDifference(target))
            .Select(c => c == 0 ? 0 : CalculateSteps(c))
            .Sum();
    }

    public int CalculateCheapestFuelPosition()
    {
        return Enumerable.Range(_crabs.First().HorizontalPosition, _crabs.Last().HorizontalPosition)
            .Select(CalculateFuelCost)
            .Min();
    }
}