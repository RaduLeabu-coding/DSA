namespace DSA.Tests;
using DSA.DataStructures;
using Xunit;
public class MaxArrayTests
{
    [Fact]
    public void MaxSubArray_ReturnsMaximumSumAndItsValues()
    {
        // Arrange
        MaxSub max = new MaxSub();

        int[] nums =
        {
            -2, 1, -3, 4, -1, 2, 1, -5, 4
        };

        int[] expectedValues =
        {
            4, -1, 2, 1
        };

        // Act
        var result = max.MaxSubArray(nums);

        // Assert
        Assert.Equal(6, result.Sum);
        Assert.Equal(expectedValues, result.idx);
    }
}