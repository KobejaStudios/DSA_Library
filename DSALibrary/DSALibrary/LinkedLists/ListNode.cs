namespace DSALibrary.LinkedLists;

public class ListNode
{
    public int Value { get; set; }
    public ListNode? Next { get; set; }

    public ListNode(int value)
    {
        Value = value;
        Next = null;
    }

    public ListNode(int value, ListNode next)
    {
        Value = value;
        Next = next;
    }
}