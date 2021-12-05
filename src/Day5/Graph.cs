using System.Text;

namespace Day5;

public class Graph
{
    private readonly SortedDictionary<GraphPoint, int> _graph = new();

    public List<(GraphPoint point, int count)> PlottedPoints => _graph.Select(kv => (kv.Key, kv.Value)).ToList();

    public void PlotLine(GraphLine mapping)
    {
        foreach (var point in mapping.CalculatePoints())
        {
            if (_graph.ContainsKey(point))
            {
                _graph[point]++;
            }
            else
            {
                _graph.Add(point, 1);
            }
        }
    }

    public int GetPointCount(GraphPoint point)
    {
        return _graph.ContainsKey(point) ? _graph[point] : 0;
    }

    public string PrintGraph()
    {
        var sb = new StringBuilder();
        var points = PlottedPoints;
        var max = (
            x: points.Max(p => p.point.X),
            y: points.Max(p => p.point.Y)
        );

        var lengths = (
            x: max.x.ToString().Length,
            y: max.y.ToString().Length
        );

        sb.Append(string.Empty.PadLeft(lengths.y + 1));

        for (var x = 0; x <= max.x; ++x)
        {
            sb.Append(x.ToString().PadLeft(lengths.x));
        }

        sb.AppendLine();

        for (var y = 0; y <= max.y; ++y)
        {
            sb.Append(y.ToString().PadLeft(lengths.y));
            sb.Append('|');
            for (var x = 0; x <= max.x; ++x)
            {
                var pointCount = GetPointCount((x, y));
                sb.Append((pointCount == 0 ? "." : pointCount.ToString()).PadLeft(lengths.x));
            }
            sb.AppendLine();
        }

        sb.Append(string.Empty.PadLeft(lengths.y + 1));

        for (var x = 0; x <= max.x * lengths.x; ++x)
        {
            sb.Append('-');
        }

        return sb.ToString();
    }
}