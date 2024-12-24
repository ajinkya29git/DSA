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
        grid[i][j]=0;
        count++;
        
        if(isValid(i-1, j, m , n) && grid[i-1][j]==1)
            count = DFS(grid, i-1, j, count, m, n);
        
        if(isValid(i, j+1, m , n) && grid[i][j+1]==1)
            count = DFS(grid, i, j+1, count, m, n);
        
        if(isValid(i+1, j, m, n) && grid[i+1][j]==1)
            count = DFS(grid, i+1, j, count, m, n);
        
        if(isValid(i, j-1, m, n) && grid[i][j-1]==1)
            count = DFS(grid, i, j-1, count, m, n);
        
        return count;
    }
    
    public int MaxAreaOfIsland(int[][] grid) {
        
        int m = grid.Length;
        int n = grid[0].Length;
        
        int maxx= 0;
        
        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                if(grid[i][j]==1)
                {
                    int count = DFS(grid, i, j, 0,m, n);
                    maxx = Math.Max(count, maxx);
                }
                    
            }
        }
        
        return maxx;
        
    }
}