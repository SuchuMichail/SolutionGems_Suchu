namespace MyExtensionsV2.Tests;

public class TestAny
{
    [Fact]
    public void WithoutFunc()
    {
        List<int>? list_null = null;
        List<int> list_empty = new List<int>();
        List<int> list = new List<int>() { 1,2,3 };

        Assert.False(list_null.Any());
        Assert.False(list_empty.Any());

        Assert.True(list.Any());
    }

    [Fact]
    public void WithFunc()
    {
        List<int>? list_null = null;
        List<int> list_empty = new List<int>();
        List<int> list = new List<int>() { 1, 2, 3 };

        Assert.False(list_null.Any(o => o < 1));
        Assert.False(list_empty.Any(o => o < 1));

        Assert.True(list.Any(o => o > 1));
    }
}
