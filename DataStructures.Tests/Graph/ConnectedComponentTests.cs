using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pretero.DataStructures;

namespace DataStructures.Tests.Graph
{
    [TestFixture]
    public class ConnectedComponentTests
    {
        [Test]
        public void ConnectedComponentTest()
        {
            var graph = new Pretero.DataStructures.Graph<int>(GetVertices());

            var cc = new ConnectedComponent<int>(graph);

            Assert.That(cc.AreConnected(1,11),
                Is.False);

            Assert.That(cc.AreConnected(1, 10),
                Is.True);
        }

        private IEnumerable<Tuple<int, int>> GetVertices()
        {
            foreach (var item in Enumerable.Range(1, 9).Select(x => new Tuple<int, int>(x, x+1)))
                yield return item;

            foreach (var item in Enumerable.Range(11, 19).Select(x => new Tuple<int, int>(x, x + 1)))
                yield return item;

            foreach (var item in Enumerable.Range(21, 29).Select(x => new Tuple<int, int>(x, x + 1)))
                yield return item;
        }
    }
}
