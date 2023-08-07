namespace MyExtensions.Tests;

public class FirstTest
{
    [Fact]
    public void WithoutFunc()
    {
        List<int> list0 = new List<int>() { 1, 2, 3 };
        Assert.Equal(1, list0.First());
 

        List<int> list1 = null;
        List<int> list2 = new List<int>();

        Assert.Throws<InvalidOperationException>(() => list1.First());
        Assert.Throws<InvalidOperationException>(() => list2.First());
    }
    
    [Fact]
    public static void WithFunc()
    {
        Console.WriteLine("TTTTTTTTT");
    }
}