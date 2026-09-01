namespace DSA.Tests;
using DSA.DataStructures;
using Xunit;
public class DynamicArrayTests
{
    [Fact]
    public void AddShouldIncreaseCount()
    {
        var dynamicArray = new DynamicArray<int>();
        dynamicArray.Add(1);
        Assert.Equal(1, dynamicArray.Count);
    }
    
    [Fact]
    public void AddShouldResizeWhenCapacityIsFull()
    {
    var dynamicArray = new DynamicArray<int>();

    dynamicArray.Add(1);
    dynamicArray.Add(2);
    dynamicArray.Add(3);

    Assert.Equal(3, dynamicArray.Count);
    Assert.Equal(1, dynamicArray.Get(0));
    Assert.Equal(2, dynamicArray.Get(1));
    Assert.Equal(3, dynamicArray.Get(2));
}
}
