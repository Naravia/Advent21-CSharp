namespace Day5;

public struct GraphPoint : IComparable<GraphPoint>
{
    public GraphPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public int CompareTo(GraphPoint other)
    {
        var xComparison = X.CompareTo(other.X);
        return xComparison != 0 ? xComparison : Y.CompareTo(other.Y);
    }

    public static implicit operator GraphPoint(ValueTuple<int, int> tuple)
    {
        return new GraphPoint(tuple.Item1, tuple.Item2);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}