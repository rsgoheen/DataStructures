using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            HeapArray.Add(val);
            SetAt(HeapArray.Count - 1, val);
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
            {
                throw new IndexOutOfRangeException("Popping an empty priority queue");
            }

            T valRet = HeapArray[0];

            SetAt(0, HeapArray[HeapArray.Count - 1]);
            HeapArray.RemoveAt(HeapArray.Count - 1);
            DownHeap(0);
            return valRet;
        }

        protected virtual void SetAt(int i, T val)
        {
            HeapArray[i] = val;
        }

        protected bool RightSonExists(int i)
        {
            return RightChildIndex(i) < HeapArray.Count;
        }

        protected bool LeftSonExists(int i)
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
            SetAt(i, HeapArray[j]);
            SetAt(j, valHold);
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
                int iContinue = -1;

                if (RightSonExists(i) && Right(i).CompareTo(ArrayVal(i)) == CompareToItemComesBefore)
                {
                    iContinue = Left(i).CompareTo(Right(i)) > 0 ? RightChildIndex(i) : LeftChildIndex(i);
                }
                else if (LeftSonExists(i) && Left(i).CompareTo(ArrayVal(i)) == CompareToItemComesBefore)
                {
                    iContinue = LeftChildIndex(i);
                }

                if (iContinue >= 0 && iContinue < HeapArray.Count)
                {
                    Swap(i, iContinue);
                }

                i = iContinue;
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
