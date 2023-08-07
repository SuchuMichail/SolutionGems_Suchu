namespace MyExtensionsV2.Tests;

public class TestFirstOrDefault
{
    [Fact]
    public void WithoutFunc()
    {
        List<int> list_null_int = null;
        List<string> list_null_string = null;

        List<int> list_empty_int = new List<int>();
        List<string> list_empty_string = new List<string>();


        List<int> list = new List<int>() { 1, 2, 3 };

        Assert.Equal(1, list.FirstOrDefault());

        Assert.Equal(0, list_null_int.FirstOrDefault());
        Assert.Equal(null, list_null_string.FirstOrDefault());


        Assert.Equal(0, list_empty_int.FirstOrDefault());
        Assert.Equal(null, list_empty_string.FirstOrDefault());
    }

    [Fact]
    public void WithFunc()
    {
        List<int> list_null_int = null;
        List<string> list_null_string = null;

        List<int> list_empty_int = new List<int>();
        List<string> list_empty_string = new List<string>();

        List<int> list = new List<int>() { 1, 2, 3 };

        Assert.Equal(2, list.FirstOrDefault(o => o > 1));

        Assert.Equal(0, list.FirstOrDefault(o => o < 0));

        Assert.Equal(null, list_null_string.FirstOrDefault(o => o == "a"));
        Assert.Equal(null, list_empty_string.FirstOrDefault(o => o == "a"));

        Assert.Equal(0, list_null_int.FirstOrDefault(o => o > 1));
        Assert.Equal(0, list_empty_int.FirstOrDefault(o => o > 1));
    }
}
