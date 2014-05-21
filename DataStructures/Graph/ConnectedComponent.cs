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

        private Dictionary<Vertex<T>, int> _groupings = new Dictionary<Vertex<T>, int>();

        public ConnectedComponent(Graph<T> graph)
        {
            _graph = graph;
            ProcessGraph();
        }

        private void ProcessGraph()
        {
            var group = 0;
            foreach (var vertex in _graph.Verticies)
            {
                
            }

        }
    }
}
