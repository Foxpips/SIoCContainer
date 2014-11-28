using System.Collections.Generic;

namespace SIoCContainer.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, ICollection<KeyValuePair<TKey, TValue>> collection)
        {
            foreach (var item in collection)
            {
                dictionary.Add(item.Key, item.Value);
            }
        }
    }
}