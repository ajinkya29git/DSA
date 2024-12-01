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
