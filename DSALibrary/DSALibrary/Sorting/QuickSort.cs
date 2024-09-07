namespace DSALibrary.Sorting;

/// <summary>
/// a 2 pointer divide and conqueror approach
/// we start with caching our pivot value, which is usually the end of the array
/// we then place a left and right pointer at the start of the array
/// left is used for our insert placement, right is used for our iterative checks
/// if array[right] less than pivot, swap values at left and right
/// move left pointer, move right pointer
/// </summary>
public class QuickSort
{
    public int[] SortArray(int[] input, int start, int end)
    {
        if (end - start + 1 <= 0) return input;

        var middle = start + (end - start) / 2;
        var pivotIndex = MedianOfThree(input, start, middle, end);
        
        var pivot = input[pivotIndex];
        var left = start;
        
        // swap pivot to end before starting the sorting
        (input[pivotIndex], input[end]) = (input[end], input[pivotIndex]);

        for (int right = start; right < end; right++)
        {
            if (input[right] < pivot)
            {
                (input[left], input[right]) = (input[right], input[left]);
                left++;
            }
        }
        
        // swap pivot with left
        (input[end], input[left]) = (input[left], input[end]);

        // we know pivot is in place so we partition from left - 1
        // and left + 1
        SortArray(input, start, left - 1);
        SortArray(input, left + 1, end);

        return input;
    }

    private int MedianOfThree(int[] input, int start, int middle, int end)
    {
        var a = input[start];
        var b = input[middle];
        var c = input[end];

        if ((a > b && a < c) || (a > c && a < b)) return start;
        if ((b > a && b < c) || (b > c && b < a)) return middle;
        return end;
    }
    
    private int MedianOfThree(float[] input, int start, int middle, int end)
    {
        var a = input[start];
        var b = input[middle];
        var c = input[end];

        if ((a > b && a < c) || (a > c && a < b)) return start;
        if ((b > a && b < c) || (b > c && b < a)) return middle;
        return end;
    }

    public float[] SortFloat(float[] input, int start, int end)
    {
        if (end - start + 1 <= 1) return input;

        var middle = start + (end - start) / 2;
        var pivotIndex = MedianOfThree(input, start, middle, end);

        var pivot = input[pivotIndex];
        var left = start;
        (input[pivotIndex], input[end]) = (input[end], input[pivotIndex]);

        for (int right = start; right < end; right++)
        {
            if (input[right] < pivot)
            {
                (input[left], input[right]) = (input[right], input[left]);
                left++;
            }
        }

        (input[end], input[left]) = (input[left], input[end]);

        SortFloat(input, start, left - 1);
        SortFloat(input, left + 1, end);
        return input;
    }

    /// <summary>
    /// a 2 pointer divide and conqueror approach
    /// we start with caching our pivot value, which is usually the end of the array
    /// we then place a left and right pointer at the start of the array
    /// left is used for our insert placement, right is used for our iterative checks
    /// if array[right] less than pivot, swap values at left and right
    /// move left pointer, move right pointer
    /// </summary>
    public int[] SortB(int[] input, int start, int end)
    {
        if (end - start + 1 <= 1) return input;

        var pivot = input[end];
        var left = start;

        for (int right = start; right < end; right++)
        {
            if (input[right] < pivot)
            {
                (input[left], input[right]) = (input[right], input[left]);
                left++;
            }
        }

        (input[end], input[left]) = (input[left], input[end]);

        SortB(input, start, left - 1);
        SortB(input, left + 1, end);

        return input;
    }
}