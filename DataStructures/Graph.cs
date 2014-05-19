using System;
using System.Collections.Generic;
using System.Linq;

namespace Pretero.DataStructures
{
    public class Graph<T> where T : IEquatable<T>
    {
        public int Edges { get; private set; }

        private readonly List<Vertex<T>> _verticies = new List<Vertex<T>>();

        public Graph(IEnumerable<T> verticies)
        {
            _verticies.AddRange(verticies.Select(x => new Vertex<T>(x)));
        }

        public IEnumerable<T> Verticies
        {
            get { return _verticies.Select(x => x.Value); }
        }

        public void AddEdge(T first, T second)
        {
            var vertex = _verticies.Single(x => x.Value.Equals(first));
            vertex.AddEdge(second);

            vertex = _verticies.Single(x => x.Value.Equals(second));
            vertex.AddEdge(first);

            Edges++;
        }

        public IEnumerable<T> AdjacentTo(T first)
        {
            var vertex = _verticies.Single(x => x.Value.Equals(first));
            return vertex.AdjacentVerteces;
        }
    }

    public class Vertex<T> where T : IEquatable<T>
    {
        private readonly List<T> _edges = new List<T>();
        private readonly T _vertex;

        public Vertex(T vertex)
        {
            _vertex = vertex;
        }

        public void AddEdge(T edgeTo)
        {
            _edges.Add(edgeTo);
        }

        public T Value
        {
            get { return _vertex; }
        }

        public IEnumerable<T> AdjacentVerteces { get { return _edges; } }
    }
}
