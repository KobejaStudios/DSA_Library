using System;
using System.Collections.Generic;

namespace DSALibrary.Stacks;

public class MaxStack
{
    private readonly Stack<(int value, int maxValue)> _base;

    public MaxStack()
    {
        _base = new Stack<(int, int)>();
    }

    public void Push(int value)
    {
        _base.Push((value, _base.Count == 0 ? value : Math.Max(value, _base.Peek().maxValue)));
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

    public int GetMax()
    {
        return _base.Peek().maxValue;
    }
}