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
      private readonly HashSet<Vertex<T>> _first = new HashSet<Vertex<T>>();
      private readonly HashSet<Vertex<T>> _second = new HashSet<Vertex<T>>();

      public Bipartate(Graph<T> graph)
      {
         IsBipartate = true;
         _graph = graph;
         ProcessGraph();
      }

      private void ProcessGraph()
      {
         foreach (var vertex in _graph.Verticies)
         {
            if (!IsBipartate)
               break;
            BFS(vertex);
         }
      }

      private void BFS(Vertex<T> startVertex)
      {
         if (IsVisited(startVertex))
            return;

         _first.Add(startVertex);

         var vertexQueue = new Queue<Vertex<T>>();
         var IsFirstSet = true;

         vertexQueue.Enqueue(startVertex);

         while (vertexQueue.Count > 0)
         {
            var currentVertex = vertexQueue.Dequeue();

            var currentSet = IsFirstSet
                ? _first
                : _second;

            foreach (var targetVertex in currentVertex.AdjacentVerteces)
            {
               if (IsVisited(targetVertex))
                  continue;

               if (currentSet.Contains(targetVertex))
               {
                  IsBipartate = false;
                  System.Diagnostics.Debug.WriteLine("Not bipartate at node " + targetVertex);
                  return;
               }

               vertexQueue.Enqueue(targetVertex);
               currentSet.Add(targetVertex);
            }

            IsFirstSet = !IsFirstSet;
         }

      }

      private bool IsVisited(Vertex<T> startVertex)
      {
         return (_first.Contains(startVertex) && _second.Contains(startVertex));
      }

      public bool IsBipartate { get; private set; }
   }
}
