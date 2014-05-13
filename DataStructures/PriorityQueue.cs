using System;
using System.Collections;
using System.Collections.Generic;

namespace Pretero.DataStructures
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable
    {
        protected readonly int CompareToItemComesBefore;

        public PriorityQueue(bool reverseOrder  = false)
        {
            CompareToItemComesBefore = reverseOrder ? 1 : -1;
        }

        protected List<T> HeapArray = new List<T>();

        public virtual int Count
        {
            get { return HeapArray.Count; }
        }

        public virtual void Add(IEnumerable<T> range)
        {
            foreach (var item in range)
                Add(item);
        }

        public virtual void Add(T val)
        {
            HeapArray.Add(val); // use Add to allocate space in list for new item
            AddAt(HeapArray.Count - 1, val);
            UpHeap(HeapArray.Count - 1);
        }

        public virtual T Peek()
        {
            if (HeapArray.Count == 0)
            {
                throw new IndexOutOfRangeException("Peeking at an empty priority queue");
            }

            return HeapArray[0];
        }

        public virtual T Pop()
        {
            if (HeapArray.Count == 0)
                throw new IndexOutOfRangeException("Popping an empty priority queue");

            var valRet = HeapArray[0];

            AddAt(0, HeapArray[HeapArray.Count - 1]);
            HeapArray.RemoveAt(HeapArray.Count - 1);
            DownHeap(0);
            return valRet;
        }

        protected virtual void AddAt(int i, T val)
        {
            HeapArray[i] = val;
        }

        protected bool RightChildNodeExists(int i)
        {
            return RightChildIndex(i) < HeapArray.Count;
        }

        protected bool LeftChildNodeExists(int i)
        {
            return LeftChildIndex(i) < HeapArray.Count;
        }

        protected int ParentIndex(int i)
        {
            return (i - 1) / 2;
        }

        protected int LeftChildIndex(int i)
        {
            return 2 * i + 1;
        }

        protected int RightChildIndex(int i)
        {
            return 2 * (i + 1);
        }

        protected T ArrayVal(int i)
        {
            return HeapArray[i];
        }

        protected T Parent(int i)
        {
            return HeapArray[ParentIndex(i)];
        }

        protected T Left(int i)
        {
            return HeapArray[LeftChildIndex(i)];
        }

        protected T Right(int i)
        {
            return HeapArray[RightChildIndex(i)];
        }

        protected void Swap(int i, int j)
        {
            T valHold = ArrayVal(i);
            AddAt(i, HeapArray[j]);
            AddAt(j, valHold);
        }

        protected void UpHeap(int i)
        {
            while (i > 0 && ArrayVal(i).CompareTo(Parent(i)) == CompareToItemComesBefore)
            {
                Swap(i, ParentIndex(i));
                i = ParentIndex(i);
            }
        }

        protected void DownHeap(int i)
        {
            while (i >= 0)
            {
                var next = -1;

                if (RightChildNodeExists(i) && Right(i).CompareTo(ArrayVal(i)) == CompareToItemComesBefore)
                {
                    next = Left(i).CompareTo(Right(i)) > 0 ? RightChildIndex(i) : LeftChildIndex(i);
                }
                else if (LeftChildNodeExists(i) && Left(i).CompareTo(ArrayVal(i)) == CompareToItemComesBefore)
                {
                    next = LeftChildIndex(i);
                }

                if (next >= 0 && next < HeapArray.Count)
                {
                    Swap(i, next);
                }

                i = next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return HeapArray.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
