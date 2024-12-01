using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

public static class Tree
{   
    public static Node root, root2, root3;

    static Tree()
    {
        root = new Node(1);
        root.left = new Node(2);
        root.left.left = new Node(3);
        root.left.left.left = new Node(4);
        root.left.right = new Node(5);
        root.left.right.left = new Node(6);
        root.left.right.left.right = new Node(7);
        root.left.right.left.right.left = new Node(8);

        root2 = new Node(4);
        root2.left = new Node(8);
        root2.left.left = new Node(0);
        root2.left.right = new Node(1);
        root2.right = new Node(5);
        root2.right.right = new Node(6);

        root3 = new Node(3);
        root3.left = new Node(5);
        root3.left.left = new Node(6);
        root3.left.right = new Node(2);
        root3.left.right.left = new Node(7);
        root3.left.right.right = new Node(4);
        root3.right = new Node(1);
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
        BFS.bfsLevelWise(root2);

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

        //7 Tree to Graph
        Console.WriteLine("Graph representation of the give Tree is : ");
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        Tree2Graph.BuildGraph(root3, graph);
        Tree2Graph.PrintGraph(graph);

    }
}