namespace DelegatesEvents.Extensions;

public static class CollectionExtension
{
    public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        if (convertToNumber == null)
            throw new ArgumentNullException(nameof(convertToNumber));

        var max = float.MinValue;
        var maxItem = collection.FirstOrDefault();
        if (maxItem is null)
            return default;

        foreach (var item in collection)
        {
            var value = convertToNumber(item);
            if (value > max)
            {
                max = value;
                maxItem = item;
            }
        }

        return maxItem;
    }
}
