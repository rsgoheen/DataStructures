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
        }

        private IEnumerable<Tuple<int, int>> GetVertices()
        {
            foreach (var item in Enumerable.Range(1, 10).Select(x => new Tuple<int, int>(x, x+1)))
                yield return item;

            foreach (var item in Enumerable.Range(11, 20).Select(x => new Tuple<int, int>(x, x + 1)))
                yield return item;

            foreach (var item in Enumerable.Range(11, 20).Select(x => new Tuple<int, int>(x, x + 1)))
                yield return item;
        }
    }
}
