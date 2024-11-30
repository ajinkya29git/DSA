using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


class Graph
{
    public static int V = 6;

    //1st method to represent Graph - creates an Array of List<int> objects. Array size is V
    // public static List<int>[] adj = new List<int>[V];
    
    //2nd method - creates an outer list of size V (passing V is optional here)
    public static List<List<int>> adj = new List<List<int>>(V);

    //3rd method
    // public static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();


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
            /* 
            if (!graph.ContainsKey(i))
                graph[i] = new List<int>();
            */
        }

        var edges = new List<(int, int)> {(1,2),(1,0),(2,0),(2,3),(2,4),(5,5)};

        foreach(var edge in edges)
        {
            AddEdge(edge);
        }

        printAdjMtx();

        //DFS
        Console.Write("Complete DFS of the graph : ");
        DFS.dfs();

        //BFS
        Console.Write("Complete BFS of the graph : ");
        BFS.bfs();

        //BFS Level-wise in Graph
        Console.WriteLine("Level wise BFS of the Graph");
        BFS.bfsLevelWise();

        //BFS in 2-D Array LC#200
        Console.Write("Complete BFS of the 2D array : ");
        Matrix.bfsInMatrix();

        //DFS in 2-D Array LC#200
        Console.WriteLine("Complete DFS of the 2D array");
        Matrix.dfsInMatrix();

        Console.WriteLine();
    }
}