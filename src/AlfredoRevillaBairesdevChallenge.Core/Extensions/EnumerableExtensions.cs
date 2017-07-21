using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace AlfredoRevillaBairesdevChallenge
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj)
        {
            return obj == null || !obj.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

    }
}