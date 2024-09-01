using System;
using System.Collections.Generic;

namespace DSALibrary.Stacks;

public class MinStackSimple
{
    private Stack<int> _base;
    private Stack<int> _minStack;
    
    public MinStackSimple()
    {
        _base = new Stack<int>();
        _minStack = new Stack<int>();
    }
    
    public void Push(int value)
    {
        _base.Push(value);
        _minStack.Push(_minStack.Count == 0 ? value : Math.Min(value, _minStack.Peek()));
    }
    
    public void Pop()
    {
        _base.Pop();
        _minStack.Pop();
    }
    
    public int Top()
    {
        return _base.Peek();
    }
    
    public int GetMin()
    {
        return _minStack.Peek();
    }
}