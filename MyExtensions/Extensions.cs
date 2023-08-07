namespace MyExtensions;

public static class Extensions
{
    public static TSource First<TSource>(this IEnumerable<TSource>? sources, Predicate<TSource>? predicate)
    {
        if (sources == null || sources.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        if (predicate == null)
        {
            return sources.First();
        }

        foreach(var item in sources)
        {
            if (predicate?.Invoke(item) == true) return item;
        }

        throw new InvalidOperationException();
    }

    public static TSource First<TSource>(this IEnumerable<TSource>? sources)
    {
        if (sources == null || sources.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return sources.ElementAt(0);
    }


}