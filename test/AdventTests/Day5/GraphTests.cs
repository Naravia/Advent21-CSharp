using System.Collections;
using System.Collections.Generic;
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
}