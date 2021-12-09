namespace Day7;

public static class IntExtensions
{
    public static int AbsDifference(this int x, int y) => Math.Max(x, y) - Math.Min(x, y);

    public static int Factorial(this int x) => Enumerable.Range(1, x)
        .Reverse()
        .Aggregate((a, b) => a * b);
}