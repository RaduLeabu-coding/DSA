namespace DSA.Tests;
using DSA.Common;
using Xunit;


public class DFSTests
{
    [Fact]
    public void FloodFill_RecolorsOnlyConnectedCells()
    {
        // Arrange
        int[][] image =
        {
            new[] { 1, 1, 1 },
            new[] { 1, 1, 0 },
            new[] { 1, 0, 1 }
        };

        int[][] expected =
        {
            new[] { 2, 2, 2 },
            new[] { 2, 2, 0 },
            new[] { 2, 0, 1 }
        };

        // Act
        int[][] result = DFSandBFS.FloodFill(image, 1, 1, 2);

        // Assert
        Assert.Equal(expected, result);
    }
}

