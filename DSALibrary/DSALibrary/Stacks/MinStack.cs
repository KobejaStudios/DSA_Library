using System;
using System.Collections.Generic;

namespace DSALibrary.Stacks;

public class MinStack
{
    private readonly Stack<(int value, int minValue)> _base;

    public MinStack()
    {
        _base = new Stack<(int, int)>();
    }

    public void Push(int value)
    {
        _base.Push((value, _base.Count == 0 ? value : Math.Min(value, _base.Peek().minValue)));
    }

    public void Pop()
    {
        _base.Pop();
    }

    public int Top()
    {
        return _base.Peek().value;
    }

    public int PopTop()
    {
        return _base.Pop().value;
    }

    public int GetMin()
    {
        return _base.Peek().minValue;
    }
}