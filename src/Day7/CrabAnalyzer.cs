namespace Day7;

public class CrabAnalyzer
{
    private readonly List<CrabPosition> _crabs;

    public CrabAnalyzer(IEnumerable<CrabPosition> crabs)
    {
        _crabs = crabs
            .OrderBy(c => c.HorizontalPosition)
            .ToList();
    }

    private int CalculateFuelCost(int target)
    {
        return _crabs.Sum(c => c.HorizontalPosition.AbsDifference(target));
    }

    public int CalculateCheapestFuelPosition()
    {
        return Enumerable.Range(_crabs.First().HorizontalPosition, _crabs.Last().HorizontalPosition)
            .Select(CalculateFuelCost)
            .Min();
    }
}