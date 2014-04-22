using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Pretero.DataStructures;

namespace DataStructures.Tests
{
    [TestFixture]
    public class ListExtensionTests
    {
        [Test]
        [Category("Unit")]
        public void LastItemShuffled()
        {
            var count = 0;

            var rnd = new Random();

            for (var i = 0; i < 10; i++)
            {
                var list = Enumerable.Range(1, 500).ToList();
                list.Shuffle(rnd);

                Debug.WriteLine(string.Join(", ", list.Take(5)));

                if (list.Last() == 500)
                    count++;
            }

            Assert.IsTrue(count != 10, "Last item is not shuffled after 10 attempts");
        }
    }
}
