using System;
using System.Linq;

namespace DSALibrary.DynamicArray;

public class DynamicArray
{
    private int[] _base;
    public int Capacity { get; private set; }
    public int Length { get; private set; }
    
    public DynamicArray(int capacity)
    {
        Capacity = capacity;
        Length = 0;
        _base = new int[Capacity];
    }

    public int Get(int index)
    {
        if (index <= Capacity)
        {
            return _base[index];
        }

        throw new IndexOutOfRangeException($"index: {index} is not in bounds of the array");
    }

    public void Set(int index, int value)
    {
        if (index <= Capacity)
        {
            _base[index] = value;
        }
        else
        {
            throw new IndexOutOfRangeException($"index: {index} is not in bounds of the array");
        }
    }

    /// <summary>
    /// Pushes a value to the end of the array.
    /// If the array does not have room we first resize it.
    /// Note that this isn't pushing a value to the end using 'Capacity' but instead
    /// using 'Length' as our true size may often be smaller than our 'Capacity'
    /// </summary>
    /// <param name="value"></param>
    public void PushBack(int value)
    {
        if (Length == Capacity)
        {
            Resize();
        }

        _base[Length] = value;
        Length++;
    }

    /// <summary>
    /// Pops the last element off the array and returns it's value.
    /// This is a 'soft delete' as the elements are not being removed
    /// but instead the 'Length' property is just being decremented which results
    /// in a shorter array while technically the 'deleted' values remain intact and in place
    /// </summary>
    public int PopBack()
    {
        // we decrement Length first because Length = the 'count' of elements
        // but arrays are 0 indexed.
        if (Length > 0)
        {
            Length--;
        }
        else
        {
            throw new InvalidOperationException("The array is empty");
        }
        return _base[Length];
    }

    /// <summary>
    /// Doubles the size of the array in contiguous memory and copies the original array values
    /// </summary>
    public void Resize()
    {
        var temp = _base;
        Capacity *= 2;
        _base = new int[Capacity];

        for (int i = 0; i < temp.Length; i++)
        {
            _base[i] = temp[i];
        }

        _base.Contains(4);
    }

    public bool Contains(int value)
    {
        return _base.Any(n => n == value);
    }
}