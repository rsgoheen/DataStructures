using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pretero.DataStructures;

namespace DataStructures.Tests.Graph
{
    [TestFixture]
    public class BipartiteTests
    {
        [Test]
        public void GraphIsBipartite()
        {
            var graph = new Pretero.DataStructures.Graph<int>();

            for (var i = 0; i < 100; i += 3)
            {
                graph.AddEdge(i, i + 1);
                graph.AddEdge(i, i + 2);

                graph.AddEdge(i + 1, i + 3);
                graph.AddEdge(i + 2, i + 3);
            }

            var bipartate = new Bipartate<int>(graph);

            Assert.That(bipartate.IsBipartate,
                Is.True);
        }

        [Test]
        public void GraphIsNotBipartite()
        {
           var graph = new Pretero.DataStructures.Graph<int>();

           for (var i = 0; i < 100; i += 3)
           {
              graph.AddEdge(i, i + 1);
              graph.AddEdge(i, i + 2);
              graph.AddEdge(i, i + 3);

              graph.AddEdge(i + 1, i);
              graph.AddEdge(i + 2, i + 1);
           }

           var bipartate = new Bipartate<int>(graph);

           Assert.That(bipartate.IsBipartate,
               Is.False);
        }
    }
}
