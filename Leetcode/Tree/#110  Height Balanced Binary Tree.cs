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
    
    public int DFSHeight(TreeNode node)
    {
        if(node == null)
            return 0;
        
        int leftH = DFSHeight(node.left);
        int rightH = DFSHeight(node.right);
        
        if(leftH==-1 || rightH==-1 || Math.Abs(leftH - rightH) > 1)  //IMP check
            return -1;
        
        return Math.Max(leftH, rightH) + 1;
    }
    
    public bool IsBalanced(TreeNode root) 
    {
        
        if(DFSHeight(root) == -1)
            return false;
        
        return true;
    }
}