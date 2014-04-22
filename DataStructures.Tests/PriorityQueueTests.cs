using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Pretero.DataStructures;

namespace DataStructures.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        [Category("Unit")]
        public void TestBasicIntSort()
        {
            var items = ((IList<int>)Enumerable.Range(1, 100).ToList());
            items.Shuffle();

            var priorityQueue = new PriorityQueue<int> {items};

            Assert.That(priorityQueue.Peek(), Is.EqualTo(1));
            Assert.That(priorityQueue.ToList(), Is.EquivalentTo(Enumerable.Range(1, 100).ToList()));
        }

        [TestMethod]
        [Category("Unit")]
        public void TestReverseIntSort()
        {
            var items = ((IList<int>)Enumerable.Range(1, 100).ToList());
            items.Shuffle();

            var priorityQueue = new PriorityQueue<int>(true) { items };

            Assert.That(priorityQueue.Peek(), Is.EqualTo(100));
            Assert.That(priorityQueue.ToList(), Is.EquivalentTo(Enumerable.Range(1, 100).Reverse().ToList()));
        }

        [TestMethod]
        [Category("Unit")]
        public void TestSortWithDuplicateKeys()
        {
            var items = ((IList<int>)Enumerable.Range(1, 1000)
                .Select(x => x % 10).ToList());
            items.Shuffle();

            var priorityQueue = new PriorityQueue<int>() { items };

            Assert.That(priorityQueue.Peek(), Is.EqualTo(0));
            Assert.That(priorityQueue.ToList(), Is.EquivalentTo(items.OrderBy(x => x).ToList()));
        }

        [TestMethod]
        [Category("Unit")]
        public void TestAdd()
        {
            var items = ((IList<int>)Enumerable.Range(1, 1000)
                .Select(x => x % 10).ToList());
            items.Shuffle();

            var priorityQueue = new PriorityQueue<int>() { items };

            Assert.That(priorityQueue.Peek(), Is.EqualTo(0));
            Assert.That(priorityQueue.ToList(), Is.EquivalentTo(items.OrderBy(x => x).ToList()));
        }

    }
}
