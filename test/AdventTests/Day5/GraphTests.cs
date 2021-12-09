using System.Collections;
using Day5;
using NUnit.Framework;

namespace AdventTests.Day5;

public class GraphTests
{
    private static void AssertPoint(ICollection collection, GraphPoint point, int count)
    {
        Assert.Contains((point, count), collection);
    }

    [Test]
    public void Can_Plot_SimpleLine()
    {
        // Arrange
        var line = new GraphLine((1, 1), (1, 3));
        var graph = new Graph();

        // Act
        graph.PlotLine(line);

        // Assert
        var points = graph.PlottedPoints;
        Assert.AreEqual(3, points.Count);
        AssertPoint(points, new GraphPoint(1, 1), 1);
        AssertPoint(points, new GraphPoint(1, 2), 1);
        AssertPoint(points, new GraphPoint(1, 3), 1);
    }

    [Test]
    public void Can_Plot_HugeLine()
    {
        // Arrange
        var line = new GraphLine((500, 750), (500, 450));
        var graph = new Graph();

        // Act
        graph.PlotLine(line);

        // Assert
        var points = graph.PlottedPoints;
        Assert.AreEqual(301, points.Count);
        for (var y = 450; y <= 750; ++y)
        {
            AssertPoint(points, (500, y), 1);
        }
    }

    [Test]
    public void Can_Plot_IntersectingLines()
    {
        // Arrange
        var lines = (
            a: new GraphLine((3, 1), (3, 5)),
            b: new GraphLine((1, 3), (5, 3))
        );
        var graph = new Graph();

        // Act
        graph.PlotLine(lines.a);
        graph.PlotLine(lines.b);

        // Assert
        var points = graph.PlottedPoints;

        // Verify Line A
        for (var y = 1; y <= 5; ++y)
        {
            AssertPoint(points, (3, y), y == 3 ? 2 : 1);
        }

        // Verify Line B
        for (var x = 1; x <= 5; ++x)
        {
            AssertPoint(points, (x, 3), x == 3 ? 2 : 1);
        }
    }

    [Test]
    public void Can_Plot_SinglePoint()
    {
        // Arrange
        var line = new GraphLine((0, 0), (0, 0));
        var graph = new Graph();

        // Act
        graph.PlotLine(line);

        // Assert
        AssertPoint(graph.PlottedPoints, (0, 0), 1);
    }

    [Test]
    public void Can_PlotSinglePoint_MultipleTimes()
    {
        // Arrange
        var line = new GraphLine((0, 0), (0, 0));
        var graph = new Graph();

        // Act
        graph.PlotLine(line);
        graph.PlotLine(line);
        graph.PlotLine(line);

        // Assert
        Assert.AreEqual(1, graph.PlottedPoints.Count);
        AssertPoint(graph.PlottedPoints, (0, 0), 3);
    }

    [Test]
    public void Can_Plot_SubLines()
    {
        // Arrange
        var lines = (
            a: new GraphLine((1, 1), (5, 1)),
            b: new GraphLine((2, 1), (4, 1))
        );
        var graph = new Graph();

        // Act
        graph.PlotLine(lines.a);
        graph.PlotLine(lines.b);

        // Assert
        var points = graph.PlottedPoints;
        Assert.AreEqual(5, points.Count);
        AssertPoint(points, (1, 1), 1);
        AssertPoint(points, (2, 1), 2);
        AssertPoint(points, (3, 1), 2);
        AssertPoint(points, (4, 1), 2);
        AssertPoint(points, (5, 1), 1);
    }

    [Test]
    public void Can_Plot_NegativeLines()
    {
        // Arrange
        var line = new GraphLine((0, 0), (-5, 0));
        var graph = new Graph();

        // Act
        graph.PlotLine(line);

        // Assert
        var points = graph.PlottedPoints;
        Assert.AreEqual(6, points.Count);
        for (var x = 0; x >= -5; --x)
        {
            AssertPoint(points, (x, 0), 1);
        }
    }
}