namespace LeetCodeSample
{
    public class Sort
    {
        public void Method1(int[] nums)
        {
            int maxIndex;
            int temp;
            for (int i = nums.Length - 1; i > -1; i--)
            {
                maxIndex = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (nums[j] > nums[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                temp = nums[i];
                nums[i] = nums[maxIndex];
                nums[maxIndex] = temp;
            }
        }
    }
}
