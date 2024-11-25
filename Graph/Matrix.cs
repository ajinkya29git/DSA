using System;
using System.Collections.Generic;

public static class Matrix
{    
    static readonly int ROW = 4;
    static readonly int COL = 4;
    static readonly bool[,] visited = new bool[ROW,COL];

    static int[,] grid = new int[,] {
        { 1, 2, 3, 4 },
        { 5, 6, 7, 8 },
        { 9, 10, 11, 12 },
        { 13, 14, 18, 16 }
    };

    static int[][] grid2 = {
        new int[] {1,1,0,0,0},
        new int[] {1,1,0,0,0},
        new int[] {0,0,1,0,0},
        new int[] {0,0,0,1,1}
    };

    // Direction vectors in which we can explore
    static int[] dRow = { -1, 0, 1, 0 };
    static int[] dCol = { 0, 1, 0, -1 };
    static List<(int, int)> N = new List<(int, int)>() {(-1,0), (0,1), (1,0), (0,-1)};


    static bool isCellValid(int i, int j, int m, int n)
    {
        if(i>=0 && i<m && j>=0 && j<n)
            return true;
        else
            return false;
    }

    static bool isValid(int row, int col)
    {
        // Check boundry conditions
        if (row < 0 || col < 0 || row >= ROW || col >= COL)
            return false; 
        
        else
            return true;
    }

    static void BFS(int[,] grid, bool[,] vis, int row, int col)
    {
        // Stores indices of the matrix cells
        Queue<(int, int)> q = new Queue<(int, int)>();

        q.Enqueue((row, col));
        visited[row, col] = true;

        // Iterate while the queue is not empty
        while (q.Count!=0)
        {
            // var (x, y) = q.Dequeue();
            var cell = q.Dequeue();
            int x = cell.Item1;
            int y = cell.Item2;
            
            Console.Write(grid[x, y] + " ");    //answer
        
            // Explore Neighbours
            for(int i = 0; i < N.Count; i++) 
            {
                int adjx = x + N[i].Item1;
                int adjy = y + N[i].Item2;
                
                if (isValid(adjx, adjy) && !vis[adjx, adjy]) 
                {
                    q.Enqueue((adjx, adjy));
                    visited[adjx, adjy] = true;
                }
            }
        }
    }

    static void DFS(int[][] grid2, int i, int j, int m, int n)
    {
        grid2[i][j] = 0;

        if(isCellValid(i, j-1, m, n) && grid2[i][j-1]==1)
            DFS(grid2, i, j-1, m, n);
        
        if(isCellValid(i-1, j, m, n) && grid2[i-1][j]==1)
            DFS(grid2, i-1, j, m, n);
        
        if(isCellValid(i, j+1, m, n) && grid2[i][j+1]==1)
            DFS(grid2, i, j+1, m, n);
        
        if(isCellValid(i+1, j, m, n) && grid2[i+1][j]==1)
            DFS(grid2, i+1, j, m, n);

    }
    
    public static void bfsInMatrix()
    { 
        BFS(grid, visited, 0, 0);
    }

    public static void dfsInMatrix()
    {
        int m = grid2.Length;
        int n = grid2[0].Length;
        
        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                if(grid2[i][j]=='1')
                {
                    DFS(grid2, i, j, m, n);
                }
                    
            }
        }
    }
} 
