using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pretero.DataStructures;

namespace DataStructures.Tests.Graph
{
    class BipartiteTests
    {
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
        }
    }
}
