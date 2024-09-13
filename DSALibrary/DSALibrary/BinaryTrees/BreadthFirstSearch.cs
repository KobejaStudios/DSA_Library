namespace DSALibrary.BinaryTrees;

public class BreadthFirstSearch
{
    public void Bfs(TreeNode? root)
    {
        var queue = new Queue<TreeNode>();
        if (root != null)
        {
            queue.Enqueue(root);
        }

        var level = 0;

        while (queue.Count > 0)
        {
            Console.WriteLine($"Level: {level}");
            var len = queue.Count;
            for (int i = 0; i < len; i++)
            {
                var current = queue.Dequeue();

                Console.WriteLine(current.Value);
                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            level++;
        }
    }
}