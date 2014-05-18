using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pretero.DataStructures;
using System;

namespace DataStructures.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void InitializeGraphTests()
        {
            var verticies = Enumerable.Range(1, 100).ToList();

            var graph = new Pretero.DataStructures.Graph<int>(verticies);

            Assert.That(graph.Verticies.Count(),
            Is.EqualTo(verticies.Count()));
        }
    }
}

namespace Pretero.DataStructures
{
    public class Graph<T>
    {
        private readonly List<T> _verticies = new List<T>();

        public Graph(IEnumerable<T> verticies)
        {
            _verticies.AddRange(verticies);
        }

        public IEnumerable<T> Verticies {
            get { return _verticies; } 
        }
    }
}
