using DSALibrary.LinkedLists;
using System.Collections.Generic;

namespace DSALibrary.Queue;

public class Deque
{
    private ListNode _head;
    private ListNode _tail;

    public Deque()
    {
        // dummy node implementation
        _head = new ListNode(-1);
        _tail = new ListNode(-1);
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public bool IsEmpty()
    {
        return _head == _tail;
        var q = new Queue<int>();
        q.Peek();
    }

    public void Append(int value)
    {
        var node = new ListNode(value)
        {
            Prev = _tail.Prev,
            Next = _tail
        };
        _tail.Prev.Next = node;
        _tail.Prev = node;
    }

    public void AppendLeft(int value)
    {
        var node = new ListNode(value)
        {
            Prev = _head,
            Next = _head.Next
        };
        _head.Next.Prev = node;
        _head.Next = node;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            return -1;
        }

        var target = _tail.Prev;
        var prev = target.Prev;
        var result = target.Value;
        
        _tail.Prev = prev;
        prev.Next = _tail;
        return result;
    }

    public int PopLeft()
    {
        if (IsEmpty())
        {
            return -1;
        }

        var targetNode = _head.Next;
        var next = targetNode.Next;
        var result = targetNode.Value;
        
        _head.Next = next;
        next.Prev = _head;
        return result;
    }
}