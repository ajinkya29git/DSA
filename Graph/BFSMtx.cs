using System;
using System.Collections.Generic;

public static class BFSMtx
{    
    static readonly int ROW = 4;
    static readonly int COL = 4;
    static readonly bool[,] visited = new bool[ROW,COL];

    static int [,]grid = new int[,] {
        { 1, 2, 3, 4 },
        { 5, 6, 7, 8 },
        { 9, 10, 11, 12 },
        { 13, 14, 18, 16 }
    };

    // Direction vectors in which we can explore
    static int[] dRow = { -1, 0, 1, 0 };
    static int[] dCol = { 0, 1, 0, -1 };
    static List<(int, int)> N = new List<(int, int)>() {(-1,0), (0,1), (1,0), (0,-1)};


    static bool isValid(bool[,] vis, int row, int col)
    {
        // Check boundry conditions
        if (row < 0 || col < 0 || row >= ROW || col >= COL)
            return false;

        // If cell is already visited
        if (vis[row,col])
            return false;

        return true;
    }

    static void BFS(int[,] grid, bool[,] vis, int row, int col)
    {
        // Stores indices of the matrix cells
        Queue<(int, int)> q = new Queue<(int, int)>();

        q.Enqueue((row, col));
        visited[row,col] = true;

        // Iterate while the queue is not empty
        while (q.Count!=0)
        {
            var cell = q.Dequeue();
            int x = cell.Item1;
            int y = cell.Item2;
            Console.Write(grid[x,y] + " ");
        
            // Explore Neighbours
            for(int i = 0; i < N.Count; i++) 
            {
                int adjx = x + N[i].Item1;
                int adjy = y + N[i].Item2;
                
                if (isValid(visited, adjx, adjy)) 
                {
                    q.Enqueue((adjx, adjy));
                    visited[adjx,adjy] = true;
                }
            }
        }
    }

    public static void bfsInMatrix()
    { 
        BFS(grid, visited, 0, 0);
    }
} 
