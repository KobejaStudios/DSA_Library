namespace DSALibrary.LinkedLists;

public class ListNode
{
    public ListNode? Prev { get; set; }
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

    public ListNode(int value, ListNode prev, ListNode next)
    {
        Value = value;
        Prev = prev;
        Next = next;
    }
}