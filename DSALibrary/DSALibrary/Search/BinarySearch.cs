namespace DSALibrary.Search;

public class BinarySearch
{
    /// <summary>
    /// binary search only works on sorted inputs.
    /// it works by taking the middle element and comparing it to the target
    /// if the target is greater than the middle element, we run the search again
    /// from the range middle + 1 - end.
    /// if the target was smaller than the middle element we run the search
    /// from the range start - middle - 1.
    /// if the target is the middle we just return the middle index.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns> the index of the target element </returns>
    public int SearchArray(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        var middle = left + (right - left) / 2;

        while (left <= right)
        {
            middle = left + (right - left) / 2;
            if (target == nums[middle])
            {
                return middle;
            }
            
            if (target > nums[middle])
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }
}