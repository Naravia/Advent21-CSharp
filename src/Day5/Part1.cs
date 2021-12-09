namespace Day5;

public class Part1
{
    private readonly IList<GraphLine> _ventMappings;

    public Part1(IList<GraphLine> ventMappings)
    {
        _ventMappings = ventMappings;
    }

    public void Solve()
    {
        var graph = new Graph();

        var lines = _ventMappings.Where(mapping => mapping.IsStraight).ToList();
        foreach (var mapping in lines)
        {
            graph.PlotLine(mapping);
        }

        var intersectingPoints = graph
            .PlottedPoints
            .Count(point => point.count >= 2);

        // Console.WriteLine(graph.PrintGraph());

        Console.WriteLine($"There are {intersectingPoints} intersecting points.");
    }
}