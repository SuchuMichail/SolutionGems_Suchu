namespace MyExtensionsV2.Tests;

public class TestFirst
{
    [Fact]
    public void WithoutFunc()
    {
        List<int> list = new List<int>() { 1, 2, 3 };
        Assert.Equal(1, list.First());


        List<int>? list_null = null;
        List<int> list_empty = new List<int>();

        Assert.Throws<InvalidOperationException>(() => list_null.First());
        Assert.Throws<InvalidOperationException>(() => list_empty.First());
    }

    [Fact]
    public void WithFunc()
    {
        List<int> list = new List<int>() { 1, 2, 3 };

        Assert.Equal(2, list.First(o => o > 1));
        Assert.Equal(1, list.First(null));

        Assert.Throws<InvalidOperationException>(() => list.First(o => o < 0));

        List<int>? list_null = null;
        List<int> list_empty = new List<int>();

        Assert.Throws<InvalidOperationException>(() => list_null.First(o => o > 1));
        Assert.Throws<InvalidOperationException>(() => list_empty.First(o => o < 1));
    }
}