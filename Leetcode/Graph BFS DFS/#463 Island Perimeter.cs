public class Solution 
{    
    public bool isValid(int i, int j, int m, int n)
    {
        if(i>=0 && i<m && j>=0 && j<n)
            return true;
        
        return false;
    }
    
    public int DFS(int[][] grid, int i, int j, int count, int m, int n)
    {
        grid[i][j]=-1;     //mark as visited
        
        if(!isValid(i-1, j, m , n) || grid[i-1][j]==0)
            count++;
        else if(grid[i-1][j]==1)
            count = DFS(grid, i-1, j, count, m, n);
        
        if(!isValid(i, j+1, m , n) || grid[i][j+1]==0)
            count++;
        else if(grid[i][j+1]==1)
            count = DFS(grid, i, j+1, count, m, n);
        
        if(!isValid(i+1, j, m , n) || grid[i+1][j]==0)
            count++;
        else if(grid[i+1][j]==1)
            count = DFS(grid, i+1, j, count, m, n);
        
        if(!isValid(i, j-1, m , n) || grid[i][j-1]==0)
            count++;
        else if(grid[i][j-1]==1)
            count = DFS(grid, i, j-1, count, m, n);
        
        return count;
    }
    
    public int IslandPerimeter(int[][] grid) 
    {
        int m = grid.Length;
        int n = grid[0].Length;
        
        int peri = 0;
        
        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                if(grid[i][j]==1)
                {
                    peri = DFS(grid, i, j, 0, m, n);
                }
                    
            }
        }
        
        return peri;
    }
}