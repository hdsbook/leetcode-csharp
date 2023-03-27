using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 53. Maximum Subarray
/// </summary>
/// <remarks>https://leetcode.com/problems/maximum-subarray/</remarks>
[Category("Medium")]
public class MaximumSubarray
{
    [TestCase(new int[] {-2,1,-3,4,-1,2,1,-5,4}, 6)]
    [TestCase(new int[] {5,4,-1,7,8}, 23)]
    [TestCase(new int[] {1}, 1)]
    public void Solution_Returns_Correctly(int[] nums, int expected)
    {
        // when
        var actual = new Solution().MaxSubArray(nums);

        // then
        actual.Should().Be(expected);
    }

    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            var sum = 0;
            var max = int.MinValue;
            foreach (var num in nums)
            {
                sum = Math.Max(sum + num, num);
                if (sum > max)
                {
                    max = sum;
                }
            }

            return max;
        }
    }
}