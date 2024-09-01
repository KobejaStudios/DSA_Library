namespace DSALibrary.MinHeap;

public class HeapNode
{
    public int Value { get; private set; }
    public HeapNode? Left { get; private set; }
    public HeapNode? Right { get; private set; }
    
    public HeapNode(int value, HeapNode? left = null, HeapNode? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}