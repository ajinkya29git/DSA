public class Tree2Graph
{
    public static void PrintGraph(Dictionary<int, List<int>> graph)
    {
        foreach(var kvp in graph)
        {
            Console.Write(kvp.Key + ":");
            foreach(var v in graph[kvp.Key])
                Console.Write(v + " ");

            Console.WriteLine();
        }
    }

    public static void AddEdge(int v1, int v2, Dictionary<int, List<int>> graph)
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

    public static void BuildGraph(Node node, Dictionary<int, List<int>> graph)
    {
        if(node==null)
            return;

        if(node.left!=null)
        {
            AddEdge(node.data, node.left.data, graph);
            BuildGraph(node.left, graph);
        }

        if(node.right!=null)
        {
            AddEdge(node.data, node.right.data, graph);
            BuildGraph(node.right, graph);
        }
    }
}
