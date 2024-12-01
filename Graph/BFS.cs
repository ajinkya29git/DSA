using System;
using System.Collections.Generic;

class BFS
{
    public static void bfs()
    {
        bool[] visited = new bool[Graph.V];
        Queue<int> q = new Queue<int>();

        //Main for loop to handle disconnected graph
        for(int i = 0; i < Graph.adj.Count; i++)
        {
            if(!visited[i])
            {
                visited[i] = true;
                q.Enqueue(i);
                
                while(q.Count > 0)
                {
                    int currentNode = q.Dequeue();
                    Console.Write(currentNode + " ");

                    for(int n = 0; n<Graph.adj[currentNode].Count; n++)
                    {
                        int node = Graph.adj[currentNode][n];
                        
                        if(!visited[node])
                        {
                            visited[node] = true;
                            q.Enqueue(node);
                        }
                    }
                }
            }
        }
        
        Console.WriteLine("");
        
    }

    public static void bfsLevelWise()
    {
        bool[] visited = new bool[Graph.V];
        Queue<int> q = new Queue<int>();

        for(int i=0; i<Graph.adj.Count; i++)
        {
            if(!visited[i])
            {
                visited[i] = true;
                q.Enqueue(i);

                while(q.Count > 0)
                {
                    int levelSize = q.Count;
                    
                    for(int count=0; count<levelSize; count++)  //Extra for loop compared to normal BFS
                    {
                        int currentNode = q.Dequeue();
                        Console.Write(currentNode + " ");

                        //Explore neighbours
                        foreach(var v in Graph.adj[currentNode])
                        {
                            if(!visited[v])
                            {
                                q.Enqueue(v);
                                visited[v] = true;
                            }
                        }
                    }

                    Console.WriteLine("");
                }
            }
        }
    }
}