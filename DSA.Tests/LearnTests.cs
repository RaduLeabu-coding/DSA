using DSA.Common;
using Xunit;

public class LearnTests
{
    [Fact]
    public void FindPair_ReturnsCorrectIndices()
    {
        int[] arr = { 2, 7, 11, 15 };
        int targetSum = 9;
        int[] result = TransactionCalculator.FindPair(arr, targetSum);
        Assert.Equal(new[] { 0, 1 }, result);
    }

    [Fact]
    public void FindPair_ReturnsEmptyArrayWhenNoPairFound()
    {
        int[] arr = { 1, 2, 3, 4 };
        int targetSum = 8;
        int[] result = TransactionCalculator.FindPair(arr, targetSum);
        Assert.Empty(result);
    }

    [Fact]
    public void TestMostFrequent()
    {
        int[] arr = { 1, 3, 2, 3, 4, 3, 5 };
        int result = TransactionCalculator.FindMostFrequent(arr);
        Assert.Equal(3, result);
    }

    [Fact]
    public void FindMostFrequentMisraGries_ReturnsMostFrequentCandidate()
    {
        int[] arr = { 1, 3, 2, 3, 4, 3, 5 };

        int result = TransactionCalculator.FindMostFrequentMisraGries(arr, 3);

        Assert.Equal(3, result);
    }
}