namespace DSALibrary.Sorting;

public class BucketSort
{
    /// <summary>
    /// Bucket sort is used when there is a small range of values
    /// for this example we'll use the range 0 - 2, but even 0 - 10^5 is acceptable.
    /// what we do is count the frequency of each unique value, store in an array of length 2
    /// (or the upper bound of the range) and then iterate through the initial array and emptying
    /// the buckets at each index
    /// </summary>
    /// <returns></returns>
    public int[] SortArray(int[] nums, int rangeMin, int rangeMax)
    {
        var buckets = new int[rangeMax];

        foreach (var t in nums)
        {
            buckets[t]++;
        }

        var start = 0;

        for (int i = 0; i < buckets.Length; i++)
        {
            for (int j = 0; j < buckets[i]; j++)
            {
                nums[start] = i;
                start++;
            }
        }

        return nums;
    }
}