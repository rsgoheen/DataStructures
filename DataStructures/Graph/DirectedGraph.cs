using System;
using System.Collections.Generic;

namespace Pretero.DataStructures
{
   public class DirectedGraph<T> : BaseGraph<T> where T : IEquatable<T>
   {
      public DirectedGraph() : base(true) { }

      public DirectedGraph(IEnumerable<T> verticies)
         : base(true, verticies) { }

      public DirectedGraph(IEnumerable<Tuple<T, T>> items)
         : base(true, items) { }
   }
}
