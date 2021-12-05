using System.Text.RegularExpressions;

namespace Day5;

public class GraphLine
{
    public GraphLine(GraphPoint origin, GraphPoint destination)
    {
        Origin = origin;
        Destination = destination;
    }
    public GraphLine(string input)
    {
        var mappingRegex = new Regex(@"^(\d+),(\d+) -> (\d+),(\d)");
        var matches = mappingRegex.Match(input);
        if (!matches.Success)
        {
            throw new ArgumentException($"Supplied parameter ({input}) did not match the mapping regex.", nameof(input));
        }

        var coords = Enumerable.Range(1, 4)
            .Select(i => matches.Groups[i])
            .Select(g => g.Value)
            .Select(int.Parse)
            .ToList();

        Origin = new GraphPoint(coords[0], coords[1]);
        Destination = new GraphPoint(coords[2], coords[3]);
    }

    public GraphPoint Destination { get; set; }

    public GraphPoint Origin { get; set; }

    public bool IsVertical => Origin.X == Destination.X;
    public bool IsHorizontal => Origin.Y == Destination.Y;
    public bool IsStraight => IsVertical || IsHorizontal;

    public IList<GraphPoint> CalculatePoints()
    {
        var points = new List<GraphPoint>();

        GraphPoint traversal = Origin;
        var direction = (
            x: Origin.X < Destination.X ? 1 : -1,
            y: Origin.Y < Destination.Y ? 1 : -1
        );

        points.Add(traversal);
        do
        {
            if (traversal.X != Destination.X)
            {
                traversal.X += direction.x;
            }

            if (traversal.Y != Destination.Y)
            {
                traversal.Y += direction.y;
            }
            points.Add(traversal);
        } while (traversal.X != Destination.X || traversal.Y != Destination.Y);

        return points;
    }

    public override string ToString()
    {
        return $"{Origin.X},{Origin.Y} -> {Destination.X},{Destination.Y}";
    }
}