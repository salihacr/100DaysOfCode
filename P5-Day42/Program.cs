using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dijkstra dijkstra = new Dijkstra();

            int[,] graph = {
                    { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                    { 0, 0, 4, 0, 10, 0, 2, 0, 0 },
                    { 0, 0, 0, 14, 0, 2, 0, 1, 6 },
                    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                    { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };
            dijkstra.SolveDijkstra(graph, 0, 9);

            Console.WriteLine("------------------");

            DFSGraph dfs = new DFSGraph(4);

            dfs.AddEdge(0, 1);
            dfs.AddEdge(0, 2);
            dfs.AddEdge(1, 2);
            dfs.AddEdge(2, 0);
            dfs.AddEdge(2, 3);
            dfs.AddEdge(3, 3);

            Console.WriteLine("Following is Depth First Traversal");

            dfs.SolveDFS();



            BFSGraph bfs = new BFSGraph(4);

            bfs.AddEdge(0, 1);
            bfs.AddEdge(0, 2);
            bfs.AddEdge(1, 2);
            bfs.AddEdge(2, 0);
            bfs.AddEdge(2, 3);
            bfs.AddEdge(3, 3);

            Console.Write("\nFollowing is Breadth First " +
                  "Traversal(starting from " +
                  "vertex 2)\n");

            bfs.SolveBFS(2);


            Console.ReadKey();
        }
    }
}
