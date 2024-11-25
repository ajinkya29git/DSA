using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


class Graph
{
    public static int V = 6;

    //creates an Array of List<int> objects. Array size is V
    // public static List<List<int>> adj = new List<List<int>>(new List<int> [V]);
    public static List<List<int>> adj = new List<List<int>>(V);

    //Fn to create Adj list from edge list
    static void AddEdge((int, int) edge)
    {
        adj[edge.Item1].Add(edge.Item2);
        adj[edge.Item2].Add(edge.Item1);  //Adding both the edges in an Undirected graph
    }

    static void printAdjMtx()
    {
        for(int i = 0; i < adj.Count; i++)
        {
            Console.Write(i + " : ");
            
            for(int j = 0; j < adj[i].Count; j++)
                Console.Write(adj[i][j] + " ");
            
            Console.WriteLine();
        }
    }

    static void Main()
    {
        for(int i = 0; i < V; i++)
        {
            // adj[i] = new List<int>();
            adj.Add(new List<int>());
        }

        var edges = new List<(int, int)> {(1,2),(1,0),(2,0),(2,3),(2,4),(5,5)};

        foreach(var edge in edges)
        {
            AddEdge(edge);
        }

        printAdjMtx();

        //DFS
        Console.WriteLine("Complete DFS of the graph");
        DFS.dfs();

        //BFS
        Console.WriteLine("Complete BFS of the graph");
        BFS.bfs();

        //BFS in 2-D Array LC#200
        Console.WriteLine("Complete BFS of the 2D array");
        Matrix.bfsInMatrix();

        //DFS in 2-D Array LC#200
        Console.WriteLine("Complete DFS of the 2D array");
        Matrix.dfsInMatrix();

        Console.WriteLine();
    }
}