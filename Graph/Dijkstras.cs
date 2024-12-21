using System;
using System.Collections.Generic;

public class WeightedGraph
{
    public int Vertices;
    public List<(int to, int weight)>[] adj;

    public WeightedGraph(int vertices)
    {
        Vertices = vertices;
        adj = new List<(int, int)>[vertices];
        for (int i = 0; i < vertices; i++)
            adj[i] = new List<(int, int)>();
    }

    public void AddEdge(int u, int v, int weight)
    {
        adj[u].Add((v, weight));
        adj[v].Add((u, weight)); // For undirected WeightedGraph back edge is must
    }
    
    // public void PrintQ(Queue<(int vertex, int distance)> pq)
    // {
    //   foreach(var pair in pq)
    //   {
    //     Console.Write(pair.vertex + ": " + pair.distance + "   ");
    //   }
    //   Console.WriteLine();
    // }

    public int[] Dijkstra(int source)
    {
        int[] dist = new int[Vertices];
        bool[] visited = new bool[Vertices];
        
        Array.Fill(dist, int.MaxValue);
        dist[source] = 0;

        // Min-Heap (priority queue)
        PriorityQueue<(int vertex, int distance), int> pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((source, 0), 0);

        while(pq.Count > 0)
        {
            var (currNode, currDist) = pq.Dequeue();
            
        //Note : here node is makred visited after Dequeue, in normal BFS it is marked visited after Enqueue

            if(!visited[currNode])
            {
                visited[currNode] = true;
                
                foreach(var neighbor in adj[currNode])
                {
                    if(!visited[neighbor.Item1] && currDist + neighbor.Item2 < dist[neighbor.Item1])
                    {
                        dist[neighbor.Item1] = currDist + neighbor.Item2;
                        pq.Enqueue((neighbor.Item1, dist[neighbor.Item1]), dist[neighbor.Item1]);
                    }
                }
            }
        }
        return dist;
    }
}

class Program
{
    static void Main(string[] args)
    {
        WeightedGraph graph = new WeightedGraph(5);
        graph.AddEdge(0, 1, 6);
        graph.AddEdge(0, 3, 2);
        graph.AddEdge(1, 2, 5);
        graph.AddEdge(1, 3, 8);
        graph.AddEdge(1, 4, 7);
        graph.AddEdge(2, 4, 1);
        graph.AddEdge(3, 4, 7);

        int source = 0;
        int[] shortestPaths = graph.Dijkstra(source);

        for (int i = 0; i < shortestPaths.Length; i++)
        {
            Console.WriteLine($"Node {i}: {shortestPaths[i]}");
        }
    }
}
