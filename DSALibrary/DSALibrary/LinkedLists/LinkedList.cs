using System.Collections.Generic;

namespace DSALibrary.LinkedLists;

public class LinkedList
{
    private ListNode _head;
    private ListNode _tail;
    
    public int Length { get; private set; }
    
    public LinkedList()
    {
        // using the dummy node here wasn't very intuitive for me
        // TODO: id like to revisit this data structure without the dummy node
        
        _head = new ListNode(-1);
        _tail = _head;
        Length = 0;
    }
    
    public int Get(int index)
    {
        var current = _head.Next;
        var count = 0;

        while (current != null)
        {
            if (count == index)
            {
                return current.Value;
            }
            current = current.Next;
            count++;
        }

        return int.MinValue;
    }

    public void InsertHead(int val)
    {
        var newHead = new ListNode(val, _head.Next);
        _head.Next = newHead;
        if (newHead.Next == null)
        {
            _tail = newHead;
        }
        Length++;
    }

    public void InsertTail(int val)
    {
        _tail.Next = new ListNode(val);
        _tail = _tail.Next;
        Length++;
    }

    public bool Remove(int index) 
    {
        var current = _head;
        var count = 0;

        while (count < index && current !=  null)
        {
            current = current.Next;
            count++;
        }

        if (current is not { Next: not null }) return false;
        
        if (current.Next == _tail)
        {
            _tail = current;
        }

        current.Next = current.Next.Next;
        Length--;
        return true;

    }

    public List<int> GetValues()
    {
        var current = _head.Next;
        var values = new List<int>();

        while (current != null)
        {
            values.Add(current.Value);
            current = current.Next;
        }
        return values;
    }
}