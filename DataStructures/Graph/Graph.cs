using System;
using System.Collections.Generic;
using System.Linq;

namespace Pretero.DataStructures
{
   public class Graph<T> : BaseGraph<T> where T : IEquatable<T>
    {
        public Graph() : base(false) { }

        public Graph(IEnumerable<T> verticies)
           : base(false, verticies) { }

        public Graph(IEnumerable<Tuple<T,T>> items)
           : base(false, items) { }
    }
}
