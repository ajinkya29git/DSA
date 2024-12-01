public class DFS
{
    public static void VLR(Node node, List<int> vlr)
    {
        if(node == null)
            return;

        vlr.Add(node.data);  

        VLR(node.left, vlr);

        VLR(node.right, vlr);

    }

    public static void LVR(Node node, List<int> lvr)
    {
        if(node == null)
            return;  

        LVR(node.left, lvr);

        lvr.Add(node.data);

        LVR(node.right, lvr);

    }

    public static void LRV(Node node, List<int> lrv)
    {
        if(node == null)
            return;

        LRV(node.left, lrv);

        LRV(node.right, lrv);

        lrv.Add(node.data);
    }
}
