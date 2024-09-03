using System;
using System.Text;

namespace DSALibrary.LinkedLists;

public class DoublyLinkedList
{
    private ListNode _head;
    private ListNode _tail;

    public DoublyLinkedList()
    {
        // TODO: another dummy node implementation that I don't fully absorb
        // this dummy node stuff isn't the most intuitive for me
        _head = new ListNode(-1, null, null);
        _tail = new ListNode(-1, null, null);

        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public void InsertFront(int value)
    {
        var newNode = new ListNode(-1, _head, _head.Next);

        _head.Next.Prev = newNode;
        _head.Next = newNode;
    }

    public void InsertEnd(int value)
    {
        var newNode = new ListNode(value, _tail.Prev, _tail);

        _tail.Prev.Next = newNode;
        _tail.Prev = newNode;
    }

    public void RemoveFront()
    {
        _head.Next.Next.Prev = _head;
        _head.Next = _head.Next.Next;
    }

    public void RemoveEnd()
    {
        _tail.Prev.Prev.Next = _tail;
        _tail.Prev = _tail.Prev.Prev;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var current = _head.Next;
        while (current != _tail && current != null)
        {
            sb.Append($"{current.Value} -> ");
            current = current.Next;
        }

        return sb.ToString();
    }

    public void PrintList()
    {
        Console.WriteLine(ToString());
    }
}