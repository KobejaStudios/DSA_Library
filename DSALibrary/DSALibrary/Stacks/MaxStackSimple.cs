using System;
using System.Collections.Generic;

namespace DSALibrary.Stacks;

public class MaxStackSimple
{
    private Stack<int> _base;
    private Stack<int> _maxStack;
    
    public MaxStackSimple()
    {
        _base = new Stack<int>();
        _maxStack = new Stack<int>();
    }

    public void Push(int value)
    {
        _base.Push(value);
        _maxStack.Push(_maxStack.Count == 0 ? value : Math.Max(value, _maxStack.Peek()));
    }

    public void Pop()
    {
        _base.Pop();
        _maxStack.Pop();
    }

    public int Top()
    {
        return _base.Peek();
    }

    public int GetMax()
    {
        return _maxStack.Peek();
    }
}