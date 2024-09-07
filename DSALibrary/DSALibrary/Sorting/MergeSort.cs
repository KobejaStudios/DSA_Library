using System.Collections.Generic;

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

    public float[] SortFloat(float[] input, int startIndex, int endIndex)
    {
        if (endIndex - startIndex + 1 <= 1) return input;

        var middle = (endIndex - startIndex) / 2;

        SortFloat(input, startIndex, middle);
        SortFloat(input, middle + 1, endIndex);

        MergeHalvesFloat(input, startIndex, middle, endIndex);
        return input;
    }

    private void MergeHalvesFloat(float[] input, int startIndex, int middleIndex, int endIndex)
    {
        // s = 0, m = 3, e = 6
        var leftLength = middleIndex - startIndex + 1;
        // 4
        var rightLength = endIndex - middleIndex;
        // 3
        var tempLeft = new float[leftLength];
        var tempRight = new float[rightLength];

        for (int i = 0; i < leftLength; i++)
        {
            tempLeft[i] = input[startIndex + i];
        }

        for (int i = 0; i < rightLength; i++)
        {
            tempRight[i] = input[middleIndex + 1 + i];
        }

        var left = 0;
        var right = 0;
        var start = startIndex;

        while (left < leftLength && right < rightLength)
        {
            if (tempLeft[left] <= tempRight[right])
            {
                input[start] = tempLeft[left];
                left++;
            }
            else
            {
                input[start] = tempRight[right];
                right++;
            }

            start++;
        }

        while (left < leftLength)
        {
            input[start] = tempLeft[left];
            left++;
            start++;
        }

        while (right < rightLength)
        {
            input[start] = tempRight[right];
            right++;
            start++;
        }
    }

}