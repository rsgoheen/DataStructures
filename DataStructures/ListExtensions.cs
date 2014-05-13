using System;
using System.Collections.Generic;

namespace Pretero.DataStructures
{
    public static class ListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list, Random rand = null)
        {
            if (rand == null)
                rand = new Random();

            for (var i = 1; i < list.Count; i++)
                list.Swap(i, rand.Next(0, i + 1));

            return list;
        }

        public static void Swap<T>(this IList<T> list, int first, int second)
        {
            if (first < 0 || first >= list.Count)
                throw new ArgumentOutOfRangeException("first");
            if (second < 0 || second >= list.Count)
                throw new ArgumentOutOfRangeException("second");

            if (first == second)
                return;

            var temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }
    }
}
