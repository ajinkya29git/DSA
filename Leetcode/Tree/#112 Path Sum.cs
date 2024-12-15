public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution 
{
    public bool DfsVLR(TreeNode node, int currSum, int targetSum)
    {
        if(node == null)
            return false;
        
        currSum += node.val;
        
        if(node.left == null && node.right == null)
        {
            if(currSum == targetSum)
                return true;
            else 
                return false;          //IMP Backtracking step
        }
        
        bool leftSubTree = DfsVLR(node.left, currSum, targetSum);
        bool rightSubTree = DfsVLR(node.right, currSum, targetSum);
        
        return leftSubTree || rightSubTree; //Key step - returning OR of left and right subtree
    }
    
    public bool HasPathSum(TreeNode root, int targetSum) 
    {    
        if(root == null)
            return false;
        
        bool ans = DfsVLR(root, 0, targetSum);
        
        return ans;
    }
}