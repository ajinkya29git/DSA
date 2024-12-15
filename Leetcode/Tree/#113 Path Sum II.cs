public class Solution 
{
    public void DfsVLR(TreeNode node, int currSum, int targetSum, List<IList<int>> ans, List<int> currPath)
    {
        if(node==null)
            return;
        
        currSum += node.val;
        currPath.Add(node.val);
        
        if(node.left==null && node.right==null)
        {
            if(currSum == targetSum)
            {
                ans.Add(new List<int>(currPath));
            }
                
        }
        
        DfsVLR(node.left, currSum, targetSum, ans, currPath);
        DfsVLR(node.right, currSum, targetSum, ans, currPath);
        
        //IMP Backtracking step : Remove the current node from the path
        currPath.RemoveAt(currPath.Count - 1);
        
        return;
    }
    
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) 
    {
        List<IList<int>> ans = new List<IList<int>>();
        
        int currSum = 0;
        List<int> currPath = new List<int>();
        
        DfsVLR(root, currSum, targetSum, ans, currPath);
        
        return ans;     
    }
}