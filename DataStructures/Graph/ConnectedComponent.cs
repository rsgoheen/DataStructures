using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretero.DataStructures
{
    public class ConnectedComponent<T> where T: IEquatable<T>
    {
        private readonly Graph<T> _graph;
        private readonly Dictionary<Vertex<T>, int> _groupings = new Dictionary<Vertex<T>, int>();

        public ConnectedComponent(Graph<T> graph)
        {
            _graph = graph;
            ProcessGraph();
        }

        private void ProcessGraph()
        {
            var grouping = 0;
            foreach (var vertex in _graph.Verticies)
            {
                if (_groupings.ContainsKey(vertex))
                    continue;

                DFS(vertex, grouping++);
            }
        }

        private void DFS(Vertex<T> vertex, int grouping)
        {
            var vertexStack = new Stack<Vertex<T>>();
            var visited = new HashSet<Vertex<T>>();
            vertexStack.Push(vertex);

            while (vertexStack.Count > 0)
            {
                var item = vertexStack.Pop();

                if (visited.Contains(item))
                    continue;

                visited.Add(item);

                if (!_groupings.ContainsKey(item))
                    _groupings.Add(item, grouping);

                foreach (var childItem in item.AdjacentVerteces)
                {
                    if(vertexStack.Contains(childItem))
                        continue;

                    vertexStack.Push(childItem);
                }
            }

        }

        public bool AreConnected(T first, T second)
        {
            var firstVertex = _graph.Verticies.SingleOrDefault(x => x.Value.Equals(first));
            var secondVertex = _graph.Verticies.SingleOrDefault(x => x.Value.Equals(second));

            if (firstVertex == null || secondVertex == null)
                return false;

            return _groupings[firstVertex] == _groupings[secondVertex];
        }
    }
}
