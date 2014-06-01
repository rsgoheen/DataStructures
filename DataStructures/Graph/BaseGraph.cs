using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretero.DataStructures
{
   public abstract class BaseGraph<T> where T : IEquatable<T>
   {
      protected readonly bool IsDirected;

      protected BaseGraph(bool isDirected)
      {
         IsDirected = isDirected;
      }

      protected BaseGraph(bool isDirected, IEnumerable<T> verticies)
      {
         IsDirected = isDirected;
         _verticies.AddRange(verticies.Select(x => new Vertex<T>(x)));
      }

      protected BaseGraph(bool isDirected, IEnumerable<Tuple<T, T>> items)
      {
         IsDirected = isDirected;
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

         if (!IsDirected)
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
