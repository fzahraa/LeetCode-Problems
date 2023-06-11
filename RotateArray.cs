using System;
using System.Collections.Generic;
using System.Text;
//Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.

//Example 1:

//Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
//Output:[5,6,7,1,2,3,4]
//Explanation:
//rotate 1 steps to the right: [7,1,2,3,4,5,6]
//rotate 2 steps to the right: [6,7,1,2,3,4,5]
//rotate 3 steps to the right: [5,6,7,1,2,3,4]
namespace LeetCode
{
    class RotateArray
    {
        public void RotateArrayOneTime(int[] nums)
        {
            int last = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >=0; i--)
            {
                nums[i + 1] = nums[i];
            }
            nums[0] = last;
        }
        //Method 1: Inefficient solution
        public void RotateKTimes(int[] nums, int k)
        {
            for(int i = 0; i < k ; i++)
            {
                RotateArrayOneTime(nums);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }
        public void reverseArray(int[] nums, int low, int high)
        {
            for (int i = low, j = high; i < j; i++, j--)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
        //Method 2: Efficient solution
        public void RotateUsingAuxiliaryArray(int[] nums, int k)
        {
            if(k > nums.Length)
            {
                k = k % nums.Length;
            }
            int[] auxA = new int[k];
            int j = 0;
            for (int i = nums.Length - k; i < nums.Length; i++)
            {
                auxA[j++] = nums[i];
            }
            reverseArray(auxA, 0, auxA.Length - 1);
            int pos = nums.Length - k;
            for (int i = 0; i < auxA.Length; i++)
            {
                nums[pos++] = auxA[i];
            }

            reverseArray(nums, 0, nums.Length - k - 1);

            reverseArray(nums, 0, nums.Length - 1);

        }
    }
}
