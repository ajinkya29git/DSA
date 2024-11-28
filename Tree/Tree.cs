using System;
using System.Collections.Generic;

public class Node
{
    public int data;
    public Node left, right;
    public Node(int value)
    {
        data = value;
        left = null;
        right = null;
    }
}

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

public class BFS
{
    public static void bfs(Node root)
    {
        Queue<Node> q = new Queue<Node>();
        
        q.Enqueue(root);
        
        while(q.Count > 0)
        {
            Node current = q.Dequeue();
            Console.Write(current.data + " ");

            if(current.left != null)
                q.Enqueue(current.left);
            if(current.right != null)
                q.Enqueue(current.right);
        }
    }

    public static void bfsLevelWise(Node root)
    {
        Queue<Node> q = new Queue<Node>();

        q.Enqueue(root);
        int level = 1;

        while(q.Count > 0)
        {
            int levelSize = q.Count;

            //This extra for loop compared to normal BFS
            for(int i = 0; i < levelSize; i++)
            {
                Node current = q.Dequeue();

                Console.WriteLine(current.data + " : " + level);

                if(current.left != null)
                    q.Enqueue(current.left);
                
                if(current.right != null)
                    q.Enqueue(current.right);
            }

            level++;
            
        }
    }
}

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
public static class Tree
{   
    public static Node root;

    static Tree()
    {
        // root = new Node(1);
        // root.left = new Node(2);
        // root.left.left = new Node(3);
        // root.left.left.left = new Node(4);
        // root.left.right = new Node(5);
        // root.left.right.left = new Node(6);
        // root.left.right.left.right = new Node(7);
        // root.left.right.left.right.left = new Node(8);

        root = new Node(4);
        root.left = new Node(8);
        root.left.left = new Node(0);
        root.left.right = new Node(1);
        root.right = new Node(5);
        root.right.right = new Node(6);
    }
    public static void Main()
    {
        //1 Height
        Console.WriteLine($"Height of the tree : {Height.height(root)}");

        //2 BFS
        Console.WriteLine($"BFS Traversal of the tree : ");
        BFS.bfs(root);
        Console.WriteLine("");

        //3 BFS with Levels
        Console.WriteLine($"BFS Traversal of the tree and Levels : ");
        BFS.bfsLevelWise(root);

        //4 DFS Pre Order
        List<int> vlr = new List<int>();
        DFS.VLR(root, vlr);
        Console.WriteLine("Pre Order Traversal : " + string.Join(",", vlr));

        //5 DFS In Order
        List<int> lvr = new List<int>();
        DFS.LVR(root, lvr);
        Console.WriteLine("In Order Traversal : " + string.Join(",", lvr));

        //6 DFS Post Order
        List<int> lrv = new List<int>();
        DFS.LRV(root, lrv);
        Console.WriteLine("Post Order Traversal : " + string.Join(",", lrv));

    }
}