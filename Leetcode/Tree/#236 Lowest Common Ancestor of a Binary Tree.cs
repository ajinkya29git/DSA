public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
 
public class Solution 
{
    
    public TreeNode DFSLCA(TreeNode node, TreeNode p, TreeNode q)
    {
        /* 4 cases
        1. if node is null OR node=p OR node=q return node
        2. if both leftSubTree=null and rightSubTree=null return null
        3. if both leftSubTree!=null and rightSubTree!=null return node
        4. if either leftSubTree or rightSubTree is !null and other is null return not null subtree
        */
        
        if(node==null || node==p || node==q)
            return node;
        
        TreeNode leftSubTreeRoot = DFSLCA(node.left, p, q);
        TreeNode rightSubTreeRoot = DFSLCA(node.right, p, q);
        
        if(leftSubTreeRoot==null && rightSubTreeRoot==null)
            return null;
        
        if(leftSubTreeRoot!=null && rightSubTreeRoot!=null)
            return node;
        
        if(leftSubTreeRoot==null & rightSubTreeRoot!=null)
            return rightSubTreeRoot;
        
        
        return leftSubTreeRoot; //here leftSubTreeRoot!=null & rightSubTreeRoot==null
        
    }
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
    {
        
        return DFSLCA(root, p, q);     //can use the same given fn
    }
}