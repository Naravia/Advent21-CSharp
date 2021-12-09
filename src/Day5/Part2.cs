namespace Day5;

public class Part2
{
    private readonly IList<GraphLine> _ventMappings;

    public Part2(IList<GraphLine> ventMappings)
    {
        _ventMappings = ventMappings;
    }

    public void Solve()
    {
        var graph = new Graph();

        foreach (var mapping in _ventMappings)
        {
            graph.PlotLine(mapping);
        }

        var intersectingPoints = graph
            .PlottedPoints
            .Count(point => point.count >= 2);

        Console.WriteLine($"There are {intersectingPoints} intersecting points.");
    }
}