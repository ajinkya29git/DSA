using System;
using System.Collections.Generic;

class BFS
{
    static bool[] visited = new bool[Graph.V];
    
    static Queue<int> q = new Queue<int>();

    public static void bfs()
    {
        //Main for loop to handle disconnected graph
        for(int i = 0; i < Graph.adj.Count; i++)
        {
            if(!visited[i])
            {
                visited[i] = true;
                q.Enqueue(i);
                
                while(q.Count > 0)
                {
                    int s = q.Dequeue();
                    Console.Write(s + " ");

                    for(int n = 0; n<Graph.adj[s].Count; n++)
                    {
                        int node = Graph.adj[s][n];
                        
                        if(!visited[node])
                        {
                            visited[node] = true;
                            q.Enqueue(node);
                        }
                    }
                }
            }
        }
        
    }
}