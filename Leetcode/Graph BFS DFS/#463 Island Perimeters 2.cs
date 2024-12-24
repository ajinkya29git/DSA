public class Solution 
{
    public bool IsValid(int i, int j, int m, int n) 
    {
        if(i >= 0 && i < m && j >= 0 && j < n)
          return true;
        
        return false;
    }

    public int DFS(int[][] grid, int i, int j, int m, int n) 
    {
        // Base cases: If out of bounds or water cell
        if (!IsValid(i, j, m, n) || grid[i][j] == 0) 
            return 1;

        // If already visited
        if (grid[i][j] == -1) 
            return 0;

        // Mark as visited
        grid[i][j] = -1;

        // Recursive DFS to check neighbors
        return DFS(grid, i - 1, j, m, n) + // Top
               DFS(grid, i + 1, j, m, n) + // Bottom
               DFS(grid, i, j - 1, m, n) + // Left
               DFS(grid, i, j + 1, m, n);  // Right
    }

    public int IslandPerimeter(int[][] grid) 
    {
        int m = grid.Length;
        int n = grid[0].Length;

        for (int i = 0; i < m; i++) 
        {
            for (int j = 0; j < n; j++) 
            {
                if (grid[i][j] == 1) 
                {
                    // Start DFS from the first land cell and return the perimeter
                    return DFS(grid, i, j, m, n);
                }
            }
        }

        return 0; // No land cells
    }
}
