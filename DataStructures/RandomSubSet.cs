using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pretero.DataStructures;

namespace Pretero.DataStructures
{
    /// <summary>
    /// For creating a random subset of a larger set.  A random subset can be 
    /// based on a given criteria or simply randomly generated.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RandomSubSet<T> where T : IEquatable<T>
    {
        private readonly IList<T> _list;
        private readonly Random _rnd = new Random();

        public RandomSubSet(IEnumerable<T> set)
        {
            _list = new List<T>(set);
            _list.Shuffle();
            Pivot = 0;
        }

        public int Pivot { get; private set; }

        /// <summary>
        /// Returns a new set that represents the portion of the list that has been 
        /// moved before the pivot point
        /// </summary>
        /// <returns>An enumerable set of items, or an empty set if there are no items before
        /// the pivot</returns>
        public IEnumerable<T> GetFilteredItems()
        {
            for (var i = 0; i < Pivot; i++)
                yield return _list[i];
        }

        public int FilteredItemCount
        {
            get { return Pivot; }
        }

        public int Count { get { return _list.Count; } }

        /// <summary>
        /// Move one item, randomly selected, into the filtered section
        /// </summary>
        /// <returns>true if there is an item that was moved, false if no item was moved</returns>
        public bool MoveRandom()
        {
            if (!_list.Any())
                return false;

            if (Pivot == _list.Count() - 1)
                return false;

            Pivot++;

            return true;
        }

        /// <summary>
        /// Move a single item that matches the given criteria
        /// </summary>
        /// <param name="criteria">A function that returns true for all items that
        /// should be considered for moving to the filtered section</param>
        /// <param name="count">The number of items to move</param>
        /// <returns></returns>
        public bool MoveRandom(Func<T, bool> criteria, int count = 1)
        {
            var pivotStart = Pivot;

            var matchingItemIds = _list
                .SkipWhile(x => _list.IndexOf(x) < pivotStart)
                .Where(criteria)
                .Take(count)
                .Select(x => _list.IndexOf(x))
                .ToArray();

            foreach (var itemId in matchingItemIds)
            {
                _list.Swap(itemId, Pivot++);

                if (Pivot >= _list.Count)
                    break;
            }

            return pivotStart != Pivot;
        }

        /// <summary>
        /// Move all items matching the given criteria into the filtered section
        /// </summary>
        /// <param name="criteria">A function that returns true for all items that
        /// should be considered for moving to the filtered section</param>
        /// <returns>True if one or more items are moved, false if zero items are moved</returns>
        public bool MoveAll(Func<T, bool> criteria)
        {
            var itemIds = _list
                .Where(criteria)
                .Select(item => _list.IndexOf(item))
                .Where(id => id >= Pivot)
                .ToArray();

            if (itemIds.Length == 0)
                return false;

            foreach (var id in itemIds)
            {
                _list.Swap(id, Pivot);
                Pivot++;
            }

            return true;
        }
    }
}
