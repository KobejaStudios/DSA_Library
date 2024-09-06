namespace DSALibrary.Sorting;

public class InsertionSort
{
    public int[] AscendingSortArray(int[] nums)
    {
        // we start loop at index 1 because index 0 is technically sorted using our method

        for (var i = 1; i < nums.Length; i++)
        {
            // create our second pointer which will always be looking at the element before i
            var j = i - 1;
            
            // keep j in bounds, check if the right value is less than the left
            // if so, swap values, move j pointer down to continue the checks
            while (j >= 0 && nums[j + 1] < nums[j])
            {
                (nums[j + 1], nums[j]) = (nums[j], nums[j + 1]);
                j--;
            }
        }

        return nums;
    }

    public int[] DescendingSortArray(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++)
        {
            var j = i - 1;

            while (j >= 0 && nums[j + 1] > nums[j])
            {
                (nums[j + 1], nums[j]) = (nums[j], nums[j + 1]);
                j--;
            }
        }

        return nums;
    }
}