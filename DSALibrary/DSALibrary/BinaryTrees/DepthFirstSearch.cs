namespace DSALibrary.BinaryTrees;

public class DepthFirstSearch
{
    public bool DfsBinarySearchTree(TreeNode? root, int target)
    {
        if (root is null) return false;

        if (root.Value < target)
        {
            return DfsBinarySearchTree(root.Right, target);
        }
        
        if (root.Value > target)
        {
            return DfsBinarySearchTree(root.Left, target);
        }

        return true;
    }

    public TreeNode InsertBST(TreeNode? root, int val)
    {
        if (root is null) return new TreeNode(val);

        if (val > root.Value)
        {
            root.Right = InsertBST(root.Right, val);
        }

        if (val < root.Value)
        {
            root.Left = InsertBST(root.Left, val);
        }

        return root;
    }

    public TreeNode GetMin(TreeNode? root)
    {
        var current = root;

        while (current != null && current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }

    public TreeNode RemoveBST(TreeNode? root, int target)
    {
        if (root is null) return null;

        if (target < root.Value)
        {
            root.Left = RemoveBST(root.Left, target);
        }

        else if (target > root.Value)
        {
            root.Right = RemoveBST(root.Right, target);
        }
        
        // we've found the target node
        else
        {
            if (root.Left == null)
            {
                return root.Right;
            }
            if (root.Right == null)
            {
                return root.Left;
            }
            
            // swap root with min value from right sub tree
            // then remove the min node, since we've swapped the root value with it's value
            // we've technically removed the root, but now we have a dupe node that we need to remove.
            // since we know this is the min node, it will be the simple case where it has at most 1 child
            var minNode = GetMin(root.Right);
            root.Value = minNode.Value;
            root.Right = RemoveBST(root.Right, minNode.Value);
        }

        return root;
    }

    public void InOrderTraversal(TreeNode root)
    {
        if (root == null) return;
        
        // traverse left child
        InOrderTraversal(root.Left);
        
        // do something with current node, in this case we're just printing it
        Console.WriteLine(root.Value);
        
        // traverse right child
        InOrderTraversal(root.Right);
        
        // because we're going left to right we traverse left recursive
        // DO something with current
        // then traverse left recursive
    }

    public void ReverseOrderTraversal(TreeNode root)
    {
        if (root == null) return;
        
        ReverseOrderTraversal(root.Right);
        Console.WriteLine(root.Value);
        ReverseOrderTraversal(root.Left);
    }

    public void PreOrderTraversal(TreeNode root)
    {
        if (root == null) return;
        
        Console.WriteLine(root.Value);
        PreOrderTraversal(root.Left);
        PreOrderTraversal(root.Right);
    }

    public void PostOrderTraversal(TreeNode root)
    {
        if (root == null) return;
        
        PostOrderTraversal(root.Left);
        PostOrderTraversal(root.Right);
        Console.WriteLine(root.Value);
    }
}