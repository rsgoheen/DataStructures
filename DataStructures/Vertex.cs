using System;
using System.Collections.Generic;
using System.Linq;

namespace Pretero.DataStructures
{
    public class Vertex<T> where T : IEquatable<T>
    {
        private readonly List<Vertex<T>> _edges = new List<Vertex<T>>();
        private readonly T _vertex;

        public Vertex(T vertex)
        {
            _vertex = vertex;
        }

        public void AddEdge(Vertex<T> edgeTo)
        {
            if (_edges.Any(x => x == edgeTo))
                return;

            _edges.Add(edgeTo);
        }

        public T Value
        {
            get { return _vertex; }
        }

        public IEnumerable<Vertex<T>> AdjacentVerteces { get { return _edges; } }
    }
}