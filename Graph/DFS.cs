using System;
using System.Collections.Generic;


class DFS
{
    public static bool[] visited = new bool[Graph.V];

    public static void dfsRec(int s)
    {
        visited[s] = true;
        
        Console.Write(s + " -> ");

        foreach(int i in Graph.adj[s])
        {
            Console.Write( i + " ");
            
            if(!visited[i])
            {
                Console.WriteLine();
                dfsRec(i);
            }
            
        }
        
    }

    public static void dfs()
    {
        //Main for loop to handle disconnected graph
        for(int i = 0; i < Graph.adj.Count; i++)
        {
            if(!visited[i])
            {   
                dfsRec(i);
                Console.WriteLine();
            }
        }
        
        Console.WriteLine();
    }
}