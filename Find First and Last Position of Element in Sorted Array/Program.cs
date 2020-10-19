using System;

namespace Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 2, 2, 2, 2, 3, 3 };
            var result = SearchRange(nums, 2);
            Console.WriteLine(result[0] + " , "+ result[1]);
        }

        static int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2];
            result[0] = FindPosition(nums, target);
            result[1] = FindPosition(nums, target, false);
            //result[0] = FindLeft(nums, target);
            //result[1] = FindRight(nums, target);
            return result;
        }

        private static int FindLeft(int[] nums, int target)
        {
            int index = -1;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] >= target) right = mid - 1;
                else left = mid + 1;
                if (nums[mid] == target) index = mid;
            }
            return index;
        }
        private static int FindRight(int[] nums, int target)
        {
            int index = -1;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] <= target) left = mid + 1;
                else right = mid - 1;
                if (nums[mid] == target) index = mid;
            }
            return index;
        }

        private static int FindPosition(int[] nums, int target, bool searchLeft = true)
        {
            int index = -1;
            int left = 0;
            int right = nums.Length - 1;
            while(left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] > target || (searchLeft && nums[mid] == target)) right = mid - 1;
                else left = mid + 1;
                if (nums[mid] == target) index = mid;
            }
            return index;
        }
    }

}
