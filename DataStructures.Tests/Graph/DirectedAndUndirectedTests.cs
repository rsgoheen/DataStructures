using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pretero.DataStructures;

namespace DataStructures.Tests.Graph
{
   [TestFixture]
   public class DirectedAndUndirectedTests
   {
      [Test]
      public void DirectedAndUndirectedGraphReachabilityTests()
      {
         var items = Enumerable.Range(1, 10).Select(x => new Tuple<int, int>(x, x + 1)).ToArray();

         var directedGraph = new DirectedGraph<int>(items);
         var undirectedGraph = new Graph<int>(items);

         Assert.That(IsAdjacent(directedGraph, 1, 2),
            Is.True);

         Assert.That(IsAdjacent(directedGraph, 2, 1),
            Is.False);

         Assert.That(IsAdjacent(undirectedGraph, 1, 2),
            Is.True);

         Assert.That(IsAdjacent(undirectedGraph, 2, 1),
            Is.True);
      }

      private bool IsAdjacent(BaseGraph<int> graph, int first, int second)
      {
         var firstVertex = graph.Verticies.First(x => x.Value == first);
         var secondVertex = graph.Verticies.First(x => x.Value == second);

         return firstVertex.AdjacentVerteces.Any(x => x == secondVertex);
      }
   }
}
