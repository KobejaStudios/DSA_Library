using System.Collections.Generic;

namespace DSALibrary.AbstractDataStructures;

public class MQueue
{
    private List<int> _data = new();

    public MQueue()
    {
        _data = new List<int>();
    }

    public void Enqueue(int value)
    {
        _data.Add(value);
    }

    public int Dequeue(int value)
    {
        var result = _data[0];
        _data.RemoveAt(0);
        return result;
    }

    public int Peek()
    {
        return _data[0];
    }
}