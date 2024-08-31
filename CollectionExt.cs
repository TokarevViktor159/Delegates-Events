using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates_Events
{
    static class CollectionExt
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null) throw new ArgumentNullException("Collection is null");
            if (!collection.Any()) throw new ArgumentException("Collection is empty");

            T maxItem = collection.First();
            float maxValue = convertToNumber(maxItem);

            float curValue;
            foreach (T item in collection)
            {
                curValue = convertToNumber(item);
                if (curValue > maxValue)
                {
                    maxValue = curValue;
                    maxItem = item;
                }
            }
            return maxItem;
        }
    }
}
