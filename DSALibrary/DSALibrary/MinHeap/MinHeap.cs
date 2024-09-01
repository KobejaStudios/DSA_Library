using System.Collections.Generic;
using System.Linq;

namespace DSALibrary.MinHeap;

public class MinHeap
{
    private List<HeapNode> _data = new();

    #region Get Node

    public HeapNode GetFirst()
    {
        return _data.First();
    }

    public HeapNode GetLast()
    {
        return _data.Last();
    }
    
    public HeapNode? GetLeftNode(int index)
    {
        var targetIndex = index * 2 + 1;

        return targetIndex <= _data.Count ? _data[targetIndex] : null;
    }

    public HeapNode? GetRightNode(int index)
    {
        var targetIndex = index * 2 + 2;

        return targetIndex <= _data.Count ? _data[targetIndex] : null;
    }

    public HeapNode? GetParentNode(int index)
    {
        var targetIndex = (index - 1) / 2;

        return targetIndex >= 0 ? _data[targetIndex] : null;
    }

    #endregion

    #region Get Index

    public int GetLeftChildIndex(int index)
    {
        return index * 2 + 1;
    }

    public int GetRightChildIndex(int index)
    {
        return index * 2 + 2;
    }

    public int GetParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    #endregion

    #region Heap Manipulation

    public void Insert(int value)
    {
        var newNode = new HeapNode(value);
        _data.Add(newNode);

        var newNodeIndex = _data.Count - 1;

        while (newNodeIndex > 0 && _data[newNodeIndex].Value > _data[GetParentIndex(newNodeIndex)].Value)
        {
            (_data[GetParentIndex(newNodeIndex)], _data[newNodeIndex]) = (_data[newNodeIndex], _data[GetParentIndex(newNodeIndex)]);
        }
    }

    public void Delete()
    {
        // we only ever delete the root node from the heap!
        // pop the last node and make it the root, thus deleting the root node
        var last = _data.Last();
        _data.RemoveAt(_data.Count - 1);
        _data[0] = last;

        var trickleNodeIndex = 0;

        while (HasGreaterChild(trickleNodeIndex))
        {
            var largerChildIndex = GetLargestChildIndex(trickleNodeIndex);

            (_data[trickleNodeIndex], _data[largerChildIndex]) = (_data[largerChildIndex], _data[trickleNodeIndex]);

            trickleNodeIndex = largerChildIndex;
        }
    }
    
    #endregion

    #region Utils

    public bool HasGreaterChild(int index)
    {
        // TODO check
        return _data[GetLeftChildIndex(index)] != null && 
               _data[GetLeftChildIndex(index)].Value > _data[index].Value || 
               _data[GetRightChildIndex(index)] != null && 
               _data[GetRightChildIndex(index)].Value > _data[index].Value;
    }

    public int GetLargestChildIndex(int index)
    {
        if (_data[GetRightChildIndex(index)] == null)
        {
            return GetLeftChildIndex(index);
        }

        if (_data[GetRightChildIndex(index)].Value > _data[GetLeftChildIndex(index)].Value)
        {
            return GetRightChildIndex(index);
        }

        return GetLeftChildIndex(index);
    }

    #endregion
}