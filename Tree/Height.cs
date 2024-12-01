public class Height
{
    //This is bottom up approach
    public static int height(Node node)
    {
        if(node == null)
            return 0;
        
        else
        {   
            int leftH = height(node.left);
            int rightH = height(node.right);

            return (Math.Max(leftH, rightH) + 1);
        }   
    }
    
}
