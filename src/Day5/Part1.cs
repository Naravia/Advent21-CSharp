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

        foreach (var mapping in _ventMappings.Where(mapping => mapping.IsStraight))
        {
            graph.PlotLine(mapping);
        }

        var intersectingPoints = graph
            .PlottedPoints
            .Count(point => point.count >= 2);
        
        Console.WriteLine(graph.PrintGraph());
        
        Console.WriteLine($"There are {intersectingPoints} intersecting points.");
    }
}