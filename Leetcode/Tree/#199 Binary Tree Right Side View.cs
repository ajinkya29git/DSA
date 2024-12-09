public class TreeNode {
  public int val;
  public TreeNode left;
  public TreeNode right;
  public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
    this.val = val;
    this.left = left;
    this.right = right;
  }
}

public class Solution 
{
    public void DFSVRL(TreeNode node, int depth, List<int> ans)
    {
        if(node == null)
            return;
        
        if(depth == ans.Count)  //Key step - If visiting this depth for 1st time, add the node value
            ans.Add(node.val);
        
        DFSVRL(node.right, depth+1, ans);
        DFSVRL(node.left, depth+1, ans);
    }
    
    public IList<int> RightSideView(TreeNode root) 
    {
        List<int> ans = new List<int>();
        
        DFSVRL(root, 0, ans);
        
        return ans;
    }
}