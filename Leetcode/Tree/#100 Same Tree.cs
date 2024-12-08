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
    
    public bool dfs(TreeNode p, TreeNode q)
    {
        if(p==null && q==null)
            return true;
        if(p==null && q!=null)
            return false;
        if(p!=null && q==null)
            return false;
        if(p.val != q.val)
            return false;
        
        bool ansLeft = dfs(p.left, q.left);
        
        bool ansRight = dfs(p.right, q.right);
        
        return ansLeft && ansRight;
    }
    
    public bool IsSameTree(TreeNode p, TreeNode q) 
    {
        
        bool ans = dfs(p, q);
        
        return ans;
        
    }
}