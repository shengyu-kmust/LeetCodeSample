namespace LeetCodeSample
{
    public class Sort
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="nums"></param>
        public void BubbleSort(int[] nums)
        {
            // 单指针(curIndex)两次for循环遍历，设长度为n，curIndex遍历为：1..n-1,1..n-2,...,1
            // 每次遍历都将当前指针和前指针做比较和值互换，使得当前指针的数值为较大的一个
            int temp;
            for (int i = nums.Length - 1; i >= 1; i--)
            {
                for (int curIndex = 1; curIndex <= i; curIndex++)
                {
                    if (nums[curIndex] < nums[curIndex - 1])
                    {
                        temp = nums[curIndex];
                        nums[curIndex] = nums[curIndex - 1];
                        nums[curIndex - 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="nums"></param>
        public void SelectSort(int[] nums)
        {
            /*
              双指针法，设和度为n
              指针curSetIndex为0至curSetIndex范围内最大值要放的位置，curSetIndex遍历为1..n-1
              指针compareIndex为当前要比较的位置,compareIndex遍历为：0..curSetIndex
              curMaxValIndex存储一每轮比较的当前最大数据的指针，比较完后再进行curMaxValIndex和curSetIndex的值的交换
             */
            int curMaxValIndex, temp;
            for (int curSetIndex = nums.Length - 1; curSetIndex >= 1; curSetIndex--)
            {
                curMaxValIndex = 0;
                for (int compareIndex = 0; compareIndex <= curSetIndex; compareIndex++)
                {
                    if (nums[curMaxValIndex] < nums[compareIndex])
                    {
                        curMaxValIndex = compareIndex;
                    }
                }
                temp = nums[curSetIndex];
                nums[curSetIndex] = nums[curMaxValIndex];
                nums[curMaxValIndex] = temp;
            }
        }

        #region 快排

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private void QuickSort(int[] nums, int start, int end)
        {
            // 递归边界
            if (start >= end)
            {
                return;//其实这里随便返回什么都可以，只要是退出递归即可
            }

            // 将本分区的所有值小于mid的移到左边，反之移到右边
            int midVal = nums[start];
            int lIndex = start;
            int rIndex = end;
            while (lIndex < rIndex)
            {
                while (lIndex < rIndex && nums[rIndex] >= midVal) rIndex--;
                nums[lIndex] = nums[rIndex];
                while (lIndex < rIndex && nums[lIndex] <= midVal) lIndex++;
                nums[rIndex] = nums[lIndex];
            }
            nums[lIndex] = midVal;

            QuickSort(nums, start, lIndex - 1); // 左分区排序
            QuickSort(nums, lIndex + 1, end); // 左分区排序

        }
        #endregion

        #region 并归
        //public static void mergeSort(int[] arr)
        //{
        //    int[] temp = new int[arr.length];
        //    internalMergeSort(arr, temp, 0, arr.length - 1);
        //}
        //private static void internalMergeSort(int[] arr, int[] temp, int left, int right)
        //{
        //    //当left==right的时，已经不需要再划分了
        //    if (left < right)
        //    {
        //        int middle = (left + right) / 2;
        //        internalMergeSort(arr, temp, left, middle);          //左子数组
        //        internalMergeSort(arr, temp, middle + 1, right);       //右子数组
        //        mergeSortedArray(arr, temp, left, middle, right);    //合并两个子数组
        //    }
        //}
        //// 合并两个有序子序列
        //private static void mergeSortedArray(int arr[], int temp[], int left, int middle, int right)
        //{
        //    int i = left;
        //    int j = middle + 1;
        //    int k = 0;
        //    while (i <= middle && j <= right)
        //    {
        //        temp[k++] = arr[i] <= arr[j] ? arr[i++] : arr[j++];
        //    }
        //    while (i <= middle)
        //    {
        //        temp[k++] = arr[i++];
        //    }
        //    while (j <= right)
        //    {
        //        temp[k++] = arr[j++];
        //    }
        //    //把数据复制回原数组
        //    for (i = 0; i < k; ++i)
        //    {
        //        arr[left + i] = temp[i];
        //    }
        //}
        #endregion

    }
}
