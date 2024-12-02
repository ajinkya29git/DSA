using System;
using System.Collections.Generic;

public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) 
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution 
{
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) 
    {
        
        // Step 1: Build the Un-directed graph representation of the tree
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        // BuildGraph(root, null, graph);
        BuildGraph(root, graph);

        // Step 2: Perform Level-wise BFS to find nodes at distance K
        var result = new List<int>();
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        
        queue.Enqueue(target.val);      //Start node in BFS is target node
        visited.Add(target.val);

        int distance = 0;

        while (queue.Count > 0) 
        {
            if (distance == k) 
            {
                while (queue.Count > 0) 
                {
                    result.Add(queue.Dequeue());
                }
                break;
            }

            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++) 
            {
                int currentNode = queue.Dequeue();
                
                foreach (var neighbor in graph[currentNode]) 
                {
                    if (!visited.Contains(neighbor)) 
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            distance++;
        }

        return result;
    }


    private void AddEdge(int v1, int v2, Dictionary<int, List<int>> graph)
    {
        if(!graph.ContainsKey(v1))
        {
            graph[v1] = new List<int>();
        }

        graph[v1].Add(v2);

        if(!graph.ContainsKey(v2))
        {
            graph[v2] = new List<int>();
        }

        graph[v2].Add(v1);

    }

    private void BuildGraph(TreeNode node, Dictionary<int, List<int>> graph)
    {
        if(node==null)
            return;

        //Edge case - when input tree has only one node
        if(!graph.ContainsKey(node.val))
            graph[node.val] = new List<int>();

        if(node.left!=null)
        {
            AddEdge(node.val, node.left.val, graph);
            BuildGraph(node.left, graph);
        }

        if(node.right!=null)
        {
            AddEdge(node.val, node.right.val, graph);
            BuildGraph(node.right, graph);
        }
    }

    //2nd way to Build the Graph
    private void BuildGraph(TreeNode node, TreeNode parent, Dictionary<int, List<int>> graph) 
    {
        if (node == null) 
            return;

        if (!graph.ContainsKey(node.val)) 
        {
            graph[node.val] = new List<int>();
        }

        if (parent != null) 
        {
            graph[node.val].Add(parent.val);
            
            if (!graph.ContainsKey(parent.val)) 
            {
                graph[parent.val] = new List<int>();
            }
            graph[parent.val].Add(node.val);
        }

        BuildGraph(node.left, node, graph);
        
        BuildGraph(node.right, node, graph);
    }
    
    private static void PrintGraph(Dictionary<int, List<int>> graph)
    {
        foreach(var kvp in graph)
        {
            Console.Write(kvp.Key + ":");
            foreach(var v in graph[kvp.Key])
                Console.Write(v + " ");

            Console.WriteLine();
        }
    }

    public static void Main()
    {
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(5);
        root.left.left = new TreeNode(6);
        root.left.right = new TreeNode(2);
        root.left.right.left = new TreeNode(7);
        root.left.right.right = new TreeNode(4);
        root.right = new TreeNode(1);

        var result = DistanceK(root, root.left.right.right, 2);

        Console.WriteLine(string.Join(',', result));
    }
}

