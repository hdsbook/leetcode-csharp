using System.Collections.Generic;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// @see https://leetcode.com/problems/two-sum/
/// </summary>
[Category("Easy")]
public class TwoSumTests
{
    [TestCase(new int[] {2, 7, 11, 15}, 9, new int[] {0, 1})]
    [TestCase(new int[] {3, 2, 4}, 6, new int[] {1, 2})]
    [TestCase(new int[] {3, 3}, 6, new int[] {0, 1})]
    public void Test1(int[] nums, int target, int[] expected)
    {
        var actual = new Solution().TwoSum(nums, target);

        Assert.AreEqual(expected, actual);
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[] { };

            var numsIndexMap = new Dictionary<int, int>();
            for (var index = 0; index < nums.Length; index++)
            {
                var num = nums[index];
                var complement = target - num;
                if (numsIndexMap.ContainsKey(complement))
                {
                    result = new[] {numsIndexMap[complement], index};
                    break;
                }

                numsIndexMap[num] = index;
            }

            return result;
        }
    }
}