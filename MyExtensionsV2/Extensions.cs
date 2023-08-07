namespace MyExtensionsV2;

public static class Extensions
{
    public static TSource First<TSource>(this IEnumerable<TSource>? collection)
    {
        if (collection == null || collection.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return collection.ElementAt(0);
    }

    public static TSource First<TSource>(this IEnumerable<TSource>? collection, Predicate<TSource>? predicate)
    {
        if (collection == null || collection.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        if (predicate == null)
        {
            return collection.First();
        }

        foreach (var item in collection)
        {
            if (predicate?.Invoke(item) == true)
            {
                return item;
            }
        }

        throw new InvalidOperationException();
    }

    

    public static TSource? FirstOrDefault<TSource>(this IEnumerable<TSource> collection)
    {
        if (collection == null || collection.Count() == 0)
        {
            return default;
        }

        return collection.ElementAt(0);
    }

    public static TSource? FirstOrDefault<TSource>(this IEnumerable<TSource>? collection, Predicate<TSource>? predicate)
    {
        if (collection == null || collection.Count() == 0)
        {
            return default;
        }

        if (predicate == null)
        {
            return collection.FirstOrDefault();
        }

        foreach (var item in collection)
        {
            if(predicate?.Invoke(item) == true)
            {
                return item;
            }
        }

        return default;
    }

    

    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource>? collection, Predicate<TSource> predicate)
    {
        List<TSource> res = new List<TSource>();

        if (collection == null || collection.Count() == 0)
        {
            return res;
        }


        foreach (var item in collection)
        {
            if(predicate?.Invoke(item) == true)
            {
                res.Add(item);
            }
        }

        return res;
    }



    public static bool Any<TSource>(this IEnumerable<TSource>? collection) 
    {
        if (collection == null || collection.Count() == 0)
        {
            return false;
        }

        return true;
    }

    public static bool Any<TSource>(this IEnumerable<TSource>? collection, Predicate<TSource>? predicate)
    {
        if (collection == null || collection.Count() == 0)
        {
            return false;
        }

        if (predicate == null)
        {
            return collection.Any();
        }

        foreach(var item in collection)
        {
            if(predicate?.Invoke(item) == true)
            {
                return true;
            }
        }

        return false;
    }
}