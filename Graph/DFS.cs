using System;
using System.Collections.Generic;


class DFS
{
    static int V = 6;

    static List<List<int>> adj = new List<List<int>>(new List<int> [V]);
    static bool[] visited = new bool[V];

    static void AddEdge((int, int) edge)
    {
        adj[edge.Item1].Add(edge.Item2);
        adj[edge.Item2].Add(edge.Item1);
    }

    static void dfs(int s)
    {
        visited[s] = true;
        
        Console.Write(s + " ");

        foreach(int i in adj[s])
        {
            if(!visited[i])
            {
                dfs(i);
            }
        }
    }

    static void Main()
    {
        for(int i = 0; i < V; i++)
        {
            adj[i] = new List<int>();
        }

        var edges = new List<(int, int)>{(1,2),(2,0),(0,3),(4,5)};

        foreach(var edge in edges)
        {
            AddEdge(edge);
        }

        Console.WriteLine("Complete DFS of the graph");

        for(int i = 0; i < adj.Count; i++)
        {
            if(!visited[i])
            {
                dfs(i);
            }
        }
        Console.WriteLine();
    }
}