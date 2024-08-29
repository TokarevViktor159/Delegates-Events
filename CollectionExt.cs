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

            T max_item = collection.First();
            float max_value = convertToNumber(max_item);

            float cur_value;
            foreach (T item in collection)
            {
                cur_value = convertToNumber(item);
                if (cur_value > max_value)
                {
                    max_value = cur_value;
                    max_item = item;
                }
            }
            return max_item;
        }
    }
}
