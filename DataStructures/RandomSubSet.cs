using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pretero.DataStructures;

namespace DataStructures
{
    /// <summary>
    /// For creating a random subset of a larger set.  A random subset can be 
    /// based on a given criteria or simply randomly generated.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class RandomSubSet<T> where T : IEquatable<T>
    {
        private readonly IList<T> _list;
        private readonly Random _rnd = new Random();

        public RandomSubSet(IEnumerable<T> set)
        {
            _list = new List<T>(set);
            Pivot = 0;
        }

        public int Pivot { get; private set; }

        /// <summary>
        /// Returns a new set that represents the portion of the list that has been 
        /// moved before the pivot point
        /// </summary>
        /// <returns>An enumerable set of items, or an empty set if there are no items before
        /// the pivot</returns>
        public IEnumerable<T> GetFilteredSet()
        {
            var subList = new T[Pivot];

            Array.Copy(_list.ToArray(),
                0,
                subList,
                0,
                Pivot);

            return subList;
        }

        public int FilteredItemCount
        {
            get { return Pivot; }
        }

        public T this[int index] { get { return _list[index]; } }

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

            _list.Swap(_rnd.Next(Pivot, _list.Count), Pivot);
            Pivot++;

            return true;
        }

        /// <summary>
        /// Move a single item that matches the given criteria
        /// </summary>
        /// <param name="criteria">A function that returns true for all items that
        /// should be considered for moving to the filtered section</param>
        /// <returns></returns>
        public bool MoveRandom(Func<T, bool> criteria)
        {
            var subSet = _list.Skip(Pivot).Where(criteria).ToArray();

            var subSetLength = subSet.Count();
            if (subSetLength == 0)
                return false;

            var itemId = _list.IndexOf(subSet.Skip(_rnd.Next(subSetLength)).First());
            _list.Swap(itemId, Pivot);
            Pivot++;
            return true;
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

        /// <summary>
        /// Returns a random item from the non-filtered section that matches the criteria
        /// </summary>
        /// <param name="item">An item, if found, matching the criteria</param>
        /// <param name="criteria">The criteria to use when searching for an item</param>
        /// <returns>true if a matching items is found, false otherwise</returns>
        public bool TryGetRandomNonFiltered(out T item, Func<T, bool> criteria)
        {
            item = default(T);
            var subSet = _list.Skip(Pivot).Where(criteria).ToArray();

            var subSetLength = subSet.Count();
            if (subSetLength == 0)
                return false;

            item = subSet.Skip(_rnd.Next(subSetLength)).First();
            return true;
        }
    }
}
