public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


public class Solution 
{
    public void DFSVLR(Node node)
    {
        if(node == null || node.left==null)
            return;
        
        node.left.next = node.right;
        
        if(node.next != null) //Key step -leveraging the given fact that tree is Perfect Binary tree
            node.right.next = node.next.left;
        
        DFSVLR(node.left);
        DFSVLR(node.right);
    }
    
    public Node Connect(Node root) 
    {
        if(root==null)
            return null;
        
        DFSVLR(root);
        
        return root;
    }
}