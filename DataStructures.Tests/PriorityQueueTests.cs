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
            var items = Enumerable.Range(1, 100).ToList().Shuffle();

            var priorityQueue = new PriorityQueue<int> { items };

            Assert.That(priorityQueue.Peek(), Is.EqualTo(1));
            Assert.That(priorityQueue.ToList(), Is.EquivalentTo(Enumerable.Range(1, 100).ToList()));
        }

        [TestMethod]
        [Category("Unit")]
        public void TestReverseIntSort()
        {
            var items = Enumerable.Range(1, 100).ToList().Shuffle();

            var priorityQueue = new PriorityQueue<int>(true) { items };

            Assert.That(priorityQueue.Peek(), Is.EqualTo(100));
            Assert.That(priorityQueue.ToList(), Is.EquivalentTo(Enumerable.Range(1, 100).Reverse().ToList()));
        }

        [TestMethod]
        [Category("Unit")]
        public void TestSortWithDuplicateKeys()
        {
            var items = Enumerable.Range(1, 1000)
                .Select(x => x % 10).ToList()
                .Shuffle();

            var priorityQueue = new PriorityQueue<int>() { items };

            Assert.That(priorityQueue.Peek(), Is.EqualTo(0));
            Assert.That(priorityQueue.ToList(), Is.EquivalentTo(items.OrderBy(x => x).ToList()));
        }

        [TestMethod]
        [Category("Unit")]
        public void TestAdd()
        {
            var items = Enumerable.Range(100, 1000).ToList().Shuffle();

            var priorityQueue = new PriorityQueue<int>() { items };

            Enumerable.Range(1, 10).ToList().ForEach(priorityQueue.Add);
            Enumerable.Range(10000, 10).ToList().ForEach(priorityQueue.Add);

            ((List<int>)items).AddRange(Enumerable.Range(1, 10));
            ((List<int>)items).AddRange(Enumerable.Range(10000, 10));

            Assert.That(priorityQueue.Peek(), Is.EqualTo(1));
            Assert.That(priorityQueue.ToList(), Is.EquivalentTo(items.OrderBy(x => x).ToList()));
        }

    }
}
