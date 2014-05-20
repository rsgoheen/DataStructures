using System;
using System.Collections.Generic;
using System.Linq;

namespace Pretero.DataStructures
{
    public class Graph<T> where T : IEquatable<T>
    {
        public Graph(IEnumerable<T> verticies)
        {
            _verticies.AddRange(verticies.Select(x => new Vertex<T>(x)));
        }

        public Graph(IEnumerable<Tuple<T,T>> items)
        {
            foreach (var item in items)
            {
                var firstVertex = RetrieveOrCreateVertex(item.Item1);
                var secondVertex = RetrieveOrCreateVertex(item.Item2);
            }
        }

        private Vertex<T> RetrieveOrCreateVertex(T value)
        {
            return _verticies.SingleOrDefault(x => x.Value.Equals(value))
                   ?? new Vertex<T>(value);
        }

        private readonly List<Vertex<T>> _verticies = new List<Vertex<T>>();

        public IEnumerable<T> Verticies
        {
            get { return _verticies.Select(x => x.Value); }
        }

        public void AddEdge(T first, T second)
        {
            var firstVertex = _verticies.Single(x => x.Value.Equals(first));
            var secondVertex = _verticies.Single(x => x.Value.Equals(second));

            firstVertex.AddEdge(secondVertex);
            secondVertex.AddEdge(firstVertex);

            Edges++;
        }

        public IEnumerable<Vertex<T>> AdjacentTo(T first)
        {
            var vertex = _verticies.Single(x => x.Value.Equals(first));
            return vertex.AdjacentVerteces;
        }

        public int Edges { get; private set; }
    }
}
