namespace LeetCodeSample
{
    public class Sort
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="nums"></param>
        public void BobSort(int[] nums)
        {
            //index: 0,1,2,3....9
            //currentIndex: 1-9,1-8,1-7,...1-2,1-1
            // length=10
            int temp;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (nums[j] < nums[j - 1])
                    {
                        temp = nums[j - 1];
                        nums[j - 1] = nums[j];
                        nums[j] = temp;
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
            int temp;
            for (int currentMinIndex = 0; currentMinIndex < nums.Length - 1; currentMinIndex++)
            {
                for (int compareIndex = currentMinIndex + 1; compareIndex < nums.Length; compareIndex++)
                {
                    if (nums[compareIndex] < nums[currentMinIndex])
                    {
                        temp = nums[currentMinIndex];
                        nums[currentMinIndex] = nums[compareIndex];
                        nums[compareIndex] = temp;
                    }
                }
            }
        }

        #region 快排

        public static void quickSort(int[] arr)
        {
            qsort(arr, 0, arr.Length - 1);
        }
        private static void qsort(int[] arr, int low, int high)
        {
            if (low >= high)
                return;
            int pivot = partition(arr, low, high);        //将数组分为两部分
            qsort(arr, low, pivot - 1);                   //递归排序左子数组
            qsort(arr, pivot + 1, high);                  //递归排序右子数组
        }
        private static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[low];     //基准
            while (low < high)
            {
                while (low < high && arr[high] >= pivot) --high;
                arr[low] = arr[high];             //交换比基准大的记录到左端
                while (low < high && arr[low] <= pivot) ++low;
                arr[high] = arr[low];           //交换比基准小的记录到右端
            }
            //扫描完成，基准到位
            arr[low] = pivot;
            //返回的是基准的位置
            return low;
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
