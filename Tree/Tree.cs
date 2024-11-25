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

public static class Tree
{   
    public static Node root;

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


    }
}