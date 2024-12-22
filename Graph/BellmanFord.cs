using System;
using System.Collections.Generic;

class BellmanFord
{
  public static void BellmanFordShortestPaths(int V, int src, List<List<int>> edges)
  {
    int[] dist = new int[V];
    Array.Fill(dist, int.MaxValue);

    dist[src] = 0;

    // Relax all edges (Vertices - 1) times
    for (int i = 0; i < V - 1; i++)
    {
        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            int wt = edge[2];
            
            if (dist[u] != int.MaxValue && dist[u] + wt < dist[v])
            {
                dist[v] = dist[u] + wt;
            }
        }
    }

    // Check for negative-weight cycles
    foreach (var edge in edges)
    {
        int u = edge[0];
        int v = edge[1];
        int wt = edge[2];
        
        if (dist[u] != int.MaxValue && dist[u] + wt < dist[v])
        {
            Console.WriteLine("Graph contains a negative-weight cycle.");
            return;
        }
    }

    PrintDistances(dist, src);
  }

  private static void PrintDistances(int[] distance, int source)
  {
    Console.WriteLine($"Shortest distances from vertex {source}:");
    for (int i = 0; i < distance.Length; i++)
    {
        Console.WriteLine($"To {i}: {(distance[i] == int.MaxValue ? "∞" : distance[i].ToString())}");
    }
  }
      
  static void Main(string[] args)
  {
    int V = 5;
    List<List<int>> edges = new List<List<int>>();
    
    edges.Add(new List<int> {0, 1, -1});
    edges.Add(new List<int> {0, 2, 4});
    edges.Add(new List<int> {1, 2, 3});
    edges.Add(new List<int> {1, 3, 2});
    edges.Add(new List<int> {1, 4, 2});
    edges.Add(new List<int> {3, 2, 5});
    edges.Add(new List<int> {3, 1, 1});
    edges.Add(new List<int> {4, 3, -3});
    
    int src = 0;

    // Find shortest paths from vertex 0
    BellmanFordShortestPaths(V, src, edges);
  }
}
