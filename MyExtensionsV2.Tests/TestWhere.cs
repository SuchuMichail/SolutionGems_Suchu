using System.Collections.Generic;

namespace MyExtensionsV2.Tests;

public class TestWhere
{
    [Fact]
    public void Test()
    {
        List<int>? list_null = null;
        List<int> list_empty=new List<int>();
        List<int> list_test = new List<int>() { 1, 2, 3 };

        List<int> list_res = new List<int>() { 2, 3 };

        Assert.Equal(list_empty, list_null.Where(o => o < 1));
        Assert.Equal(list_empty, list_empty.Where(o => o < 1));

        Assert.Equal(list_res, list_test.Where(o => o > 1));
    }
}
