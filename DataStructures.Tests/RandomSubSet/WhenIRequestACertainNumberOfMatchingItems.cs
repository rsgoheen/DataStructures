using System.Linq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Pretero.DataStructures;
using System;

namespace DataStructures.Tests
{
    [TestFixture]
    public class WhenIRequestACertainNumberOfMatchingItems
    {
        [Test]
        public void IGetASubsetMatchingMyCountAndCriteria()
        {
            var list = new RandomSubSet<int>(Enumerable.Range(1, 100).ToList());

            Assert.That(list.MoveRandom(x => x%2 == 0, 10),
                Is.True);

            var subset = list.GetFilteredItems().ToList();
            Assert.That(subset.Count,
                Is.EqualTo(10));
            Assert.That(subset.All(x => x%2 == 0),
                Is.True);
        }

        [Test]
        public void AndThereAreFewerItemsAvailable_IGetASmallerSubsetThanMyRequestedCount()
        {
            var list = new RandomSubSet<int>(Enumerable.Range(1, 100).ToList());

            Assert.That(list.MoveRandom(x => x % 20 == 0, 10),
                Is.True);

            var subset = list.GetFilteredItems().ToList();
            Assert.That(subset.Count,
                Is.EqualTo(5));
            Assert.That(subset.All(x => x % 20 == 0),
                Is.True);
        }

        [Test]
        public void AndThereAreNoMatches_ThenTheSubsetIsEmpty()
        {
            var list = new RandomSubSet<int>(Enumerable.Range(1, 10).ToList());

            Assert.That(list.MoveRandom(x => x % 20 == 0, 10),
                Is.False);

            var subset = list.GetFilteredItems().ToList();
            Assert.That(subset.Count,
                Is.EqualTo(0));
        }
    }
}
