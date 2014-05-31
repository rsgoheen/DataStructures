using System;
using System.Collections.Generic;
using System.Linq;

namespace Pretero.DataStructures
{
    public class Graph<T> where T : IEquatable<T>
    {
        public Graph() { }

        public Graph(IEnumerable<T> verticies)
        {
            _verticies.AddRange(verticies.Select(x => new Vertex<T>(x)));
        }

        public Graph(IEnumerable<Tuple<T,T>> items)
        {
            foreach (var item in items)
                AddEdge(item.Item1, item.Item2);
        }

        private Vertex<T> RetrieveOrCreateVertex(T value)
        {
            var vertex = _verticies.SingleOrDefault(x => x.Value.Equals(value));

           if (vertex == null)
           {
              vertex = new Vertex<T>(value);
              _verticies.Add(vertex);
           }

           return vertex;
        }

        private readonly List<Vertex<T>> _verticies = new List<Vertex<T>>();

        public IEnumerable<Vertex<T>> Verticies
        {
            get { return _verticies; }
        }

        public void AddEdge(T first, T second)
        {
            var firstVertex = RetrieveOrCreateVertex(first);
            var secondVertex = RetrieveOrCreateVertex(second);

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
