using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;

namespace DataStructures.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void InitializeGraphTests()
        {
            var verticies = Enumerable.Range(1, 100).ToList();

            var graph = new Pretero.DataStructures.Graph<int>(verticies);

            Assert.That(graph.Verticies.Count(),
                Is.EqualTo(verticies.Count()));

            for (var i = 1; i < 100; i++)
                graph.AddEdge(i, i + 1);

            Assert.That(graph.Verticies.Count(),
                Is.EqualTo(verticies.Count()));

            Assert.That(graph.AdjacentTo(1).Count(),
                Is.EqualTo(1));
            Assert.That(graph.AdjacentTo(1).Select(x => x.Value),
                Contains.Item(2));
            Assert.That(graph.AdjacentTo(2).Select(x => x.Value),
                Contains.Item(1));

            Assert.That(graph.Edges,
                Is.EqualTo(99));
        }

        [Test]
        public void InitializeGraphTestsTupleConstructor()
        {
           var verticies = Enumerable.Range(1, 99).ToList();

           Func<int, Tuple<int,int>> tupleList = x => new Tuple<int, int>(x, x + 1);

           var graph = new Pretero.DataStructures.Graph<int>(verticies.Select(tupleList));

           Assert.That(graph.Verticies.Count(),
               Is.EqualTo(verticies.Count() + 1));

           Assert.That(graph.AdjacentTo(1).Count(),
               Is.EqualTo(1));
           Assert.That(graph.AdjacentTo(1).Select(x => x.Value),
               Contains.Item(2));
           Assert.That(graph.AdjacentTo(2).Select(x => x.Value),
               Contains.Item(1));

           Assert.That(graph.Edges,
               Is.EqualTo(99));
        }
    }
}

