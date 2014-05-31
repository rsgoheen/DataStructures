using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretero.DataStructures
{
    public class Bipartate<T> where T : IEquatable<T>
    {
        private readonly Graph<T> _graph;
        private readonly HashSet<T> _first = new HashSet<T>();
        private readonly HashSet<T> _second = new HashSet<T>();

        public Bipartate(Graph<T> graph)
        {
            _graph = graph;
            BFS();
        }

        private void ProcessGraph()
        {
            foreach (var vertex in _graph.Verticies)
                BFS(vertex);
        }

        private void BFS(Vertex<T> startVertex)
        {
            if (IsVisited(startVertex))
                return;

            var vertexQueue = new Queue<Vertex<T>>();
            var IsFirstSet = true;



        }

        private bool IsVisited(Vertex<T> startVertex)
        {
            return (_first.Contains(startVertex.Value) && _second.Contains(startVertex.Value);
        }

        public bool IsBipartate { get; private set; }
    }
}
