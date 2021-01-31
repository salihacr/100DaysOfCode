using System;
using System.Collections.Generic;

namespace Graphs
{
    class DFSGraph
    {
        private int V; // No of vertices
        private List<int>[] adj;

        public DFSGraph(int V)
        {
            this.V = V;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int vertex, int weight)
        {
            adj[vertex].Add(weight);
        }

        void DFSUtil(int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.Write(vertex + " ");

            foreach (int i in adj[vertex])
            {
                int n = i;
                if (!visited[n])
                {
                    DFSUtil(n, visited);
                }
            }
        }
        public void SolveDFS()
        {
            bool[] visited = new bool[V];

            for (int i = 0; i < V; ++i)
            {
                if (visited[i] == false)
                {
                    DFSUtil(i, visited);
                }
            }
        }
    }
}
