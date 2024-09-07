﻿using System.Collections.Generic;

namespace DSALibrary.Sorting;

public class MergeSort
{
    public int[] SortArray(int[] input, int startIndex, int endIndex)
    {
        if (endIndex - startIndex + 1 <= 1) return input;

        var middleIndex = (startIndex + endIndex) / 2;
        
        // sort both halfs
        SortArray(input, startIndex, middleIndex);
        SortArray(input, middleIndex + 1, endIndex);
        
        // merge everything
        input = MergeHalves(input, startIndex, middleIndex, endIndex);
        return input;
    }

    private int[] MergeHalves(int[] input, int startIndex, int middleIndex, int endIndex)
    {
        // 3 pointers
        
        // 1 pointer at start of left half array
        // 1 pointer at start of right half array
        // 1 pointer at insertion index of original array
        
        // if left pointer < right pointer, insert left into original array, increment left
        // else, insert right pointer into original, increment right
        // if left <= right, insert left first
        // increment insertion pointer every insert
        // when 1 side is out of bounds, insert all remaining elements into original array
        
        // because we'll be inserting into the input array we will need to create temp arrays
        // for the iteration since we'll be writing to the original array as we traverse the temps

        var leftLength = middleIndex - startIndex + 1;
        var rightLength = endIndex - middleIndex;

        var tempLeft = new int[leftLength];
        var tempRight = new int[rightLength];

        for (int i = 0; i < leftLength; i++)
        {
            tempLeft[i] = input[startIndex + i];
        }

        for (int i = 0; i < rightLength; i++)
        {
            tempRight[i] = input[middleIndex + 1 + i];
        }

        var leftPointer = 0;
        var rightPointer = 0;
        var insertionPointer = startIndex;

        while (leftPointer < leftLength && rightPointer < rightLength)
        {
            if (tempLeft[leftPointer] <= tempRight[rightPointer])
            {
                input[insertionPointer] = tempLeft[leftPointer];
                leftPointer++;
            }
            else
            {
                input[insertionPointer] = tempRight[rightPointer];
                rightPointer++;
            }
            insertionPointer++;
        }

        while (leftPointer < leftLength)
        {
            input[insertionPointer] = tempLeft[leftPointer];
            leftPointer++;
            insertionPointer++;
        }

        while (rightPointer < rightLength)
        {
            input[insertionPointer] = tempRight[rightPointer];
            rightPointer++;
            insertionPointer++;
        }
        
        return input;
    }

    public List<Pair> Merge(List<Pair> pairs)
    {
        return default;
    }
}

public class Pair
{
    public int Key { get; set; }
    public string Value { get; set; }

    public Pair(int key, string value)
    {
        Key = key;
        Value = value;
    }
}