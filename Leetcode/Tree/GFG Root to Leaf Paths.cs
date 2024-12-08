using System;
using System.Collections.Generic;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    private void dfs(TreeNode node, List<List<int>> ans, List<int> path)
    {
        if (node == null)
            return;

        path.Add(node.val);

        if (node.left == null && node.right == null)
        {
            ans.Add(new List<int>(path)); // Make a DEEP Copy of the path list
        }
        
        dfs(node.left, ans, path);
        dfs(node.right, ans, path);

        // IMP Backtrack: remove the current node from path (last node in path)
        path.RemoveAt(path.Count - 1);
    }


    public List<List<int>> Paths(TreeNode root)
    {
        List<List<int>> ans = new List<List<int>>();
        List<int> path = new List<int>();
        
        // Start DFS from the root node
        dfs(root, ans, path);
        
        return ans;
    }
}

class Program
{
    static void Main()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);

        Solution solution = new Solution();
        List<List<int>> result = solution.Paths(root);

        foreach (var path in result)
        {
            Console.WriteLine(string.Join(" ", path));
        }
    }
}
