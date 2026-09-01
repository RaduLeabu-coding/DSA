namespace DSA.Tests;
using DSA.Strings;
using Xunit;
public class PalindroameTests
{
    [Fact]
    public void TestIsPalindrome()
    {
        Assert.True(LexicographicallySmallestPalindrome.IsPalindrome("racecar"));
    }

    [Fact]
    public void TestSmallestLexiPalindromMutation()
    {
        var result1 = new LexicographicallySmallestPalindrome().SmallestPalindrome("aaabbbb");
        Assert.Equal("abbbba", result1);

        var result2 = new LexicographicallySmallestPalindrome().SmallestPalindrome("civic");
        Assert.Equal("civic", result2);

        var result3 = new LexicographicallySmallestPalindrome().SmallestPalindrome("aabbcc");
        Assert.Equal("abcba", result3);

        var result4 = new LexicographicallySmallestPalindrome().SmallestPalindrome("abcde");
        Assert.Equal("NO PALINDROME", result4);

        var result5 = new LexicographicallySmallestPalindrome().SmallestPalindrome("a");
        Assert.Equal("a", result5);    
    }

    [Fact]
    public void TestIsPrime()
    {
        Assert.True(LexicographicallySmallestPalindrome.IsPrime(7));
        Assert.False(LexicographicallySmallestPalindrome.IsPrime(8));
    }
}
