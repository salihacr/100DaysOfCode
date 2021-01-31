using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    class BFSGraph
    {
        private int _vertex;

        LinkedList<int>[] _adj;

        public BFSGraph(int vertex)
        {
            _adj = new LinkedList<int>[vertex];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
            _vertex = vertex;
        }
        public void AddEdge(int vertex, int weight)
        {
            _adj[vertex].AddLast(weight);
        }
        public void SolveBFS(int source)
        {
            bool[] visited = new bool[_vertex];

            for (int i = 0; i < _vertex; i++)
            {
                visited[i] = false;
            }

            Queue<int> queue = new Queue<int>();
            visited[source] = true;

            queue.Enqueue(source);

            while (queue.Any())
            {
                source = queue.First();
                Console.Write(source + " ");
                queue.Dequeue();

                LinkedList<int> list = _adj[source];

                foreach (var item in list)
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }
        }
    }
}
