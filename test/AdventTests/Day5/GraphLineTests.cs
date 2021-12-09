using Day5;
using NUnit.Framework;

namespace AdventTests.Day5;

public class GraphLineTests
{
    [Test]
    public void CalculatePoints_CanReturn_MultiplePoints()
    {
        // Arrange
        var line = new GraphLine((1, 1), (1, 3));

        // Act
        var points = line.CalculatePoints();

        // Assert
        Assert.AreEqual(3, points.Count);
        Assert.Contains(new GraphPoint(1, 1), points);
        Assert.Contains(new GraphPoint(1, 2), points);
        Assert.Contains(new GraphPoint(1, 3), points);
    }

    [Test]
    public void CalculatePoints_CanReturn_SinglePoint()
    {
        // Arrange
        var line = new GraphLine((1, 1), (1, 1));

        // Act
        var points = line.CalculatePoints();

        // Assert
        Assert.AreEqual(1, points.Count);
        Assert.Contains(new GraphPoint(1, 1), points);
    }

    [Theory]
    [TestCase(1, 1, 5, 1, true)]
    [TestCase(1, 1, 5, 2, false)]
    [TestCase(1, 1, 5, 0, false)]
    [TestCase(1, 1, 5, 5, false)]
    [TestCase(1, 1, 1, 1, true)]
    [TestCase(640, 713, 327, 713, true)]
    public void IsHorizontal_Detects_HorizontalLines(int ox, int oy, int dx, int dy, bool isHorizontal)
    {
        // Arrange
        var line = new GraphLine((ox, oy), (dx, dy));

        // Assert
        Assert.AreEqual(isHorizontal, line.IsHorizontal);
    }

    [Theory]
    [TestCase(1, 1, 5, 1, false)]
    [TestCase(1, 1, 5, 2, false)]
    [TestCase(1, 1, 5, 0, false)]
    [TestCase(1, 1, 5, 5, false)]
    [TestCase(1, 1, 1, 1, true)]
    [TestCase(1, 1, 1, 5, true)]
    [TestCase(257, 183, 257, 514, true)]
    public void IsVertical_Detects_VerticalLines(int ox, int oy, int dx, int dy, bool isVertical)
    {
        // Arrange
        var line = new GraphLine((ox, oy), (dx, dy));

        // Assert
        Assert.AreEqual(isVertical, line.IsVertical);
    }

    [Theory]
    [TestCase(1, 1, 5, 1, true)]
    [TestCase(1, 1, 5, 2, false)]
    [TestCase(1, 1, 5, 0, false)]
    [TestCase(1, 1, 5, 5, false)]
    [TestCase(1, 1, 1, 1, true)]
    [TestCase(1, 1, 1, 5, true)]
    public void IsStraight_Detects_StraightLines(int ox, int oy, int dx, int dy, bool isStraight)
    {
        // Arrange
        var line = new GraphLine((ox, oy), (dx, dy));

        // Assert
        Assert.AreEqual(isStraight, line.IsStraight);
    }

    [Test]
    public void GraphLine_ParsesCoords_Correctly()
    {
        // Arrange
        const string input = "640,713 -> 327,713";

        // Act
        var line = new GraphLine(input);

        // Assert
        Assert.AreEqual(640, line.Origin.X);
        Assert.AreEqual(713, line.Origin.Y);
        Assert.AreEqual(327, line.Destination.X);
        Assert.AreEqual(713, line.Destination.Y);
    }
}