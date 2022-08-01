using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 11. Container With Most Water
/// </summary>
/// <remarks>https://leetcode.com/problems/container-with-most-water/</remarks>
[Category("Medium")]
public class ContainerWithMostWaterTests
{
    [TestCase(new int[] {1, 1}, 1)]
    [TestCase(new int[] {1, 2}, 1)]
    [TestCase(new int[] {1, 8, 6, 2, 5, 4, 8, 3, 7}, 49)]
    public void Solution_Returns_Correctly(int[] height, int expected)
    {
        // when
        var actual = new Solution().MaxArea(height);

        // then assert
        Assert.AreEqual(expected, actual);
    }

    public class Solution
    {
        public int MaxArea(int[] height)
        {
            if (height.Length == 2)
            {
                return Math.Min(height[0], height[1]);
            }

            var maxArea = 0;
            var left = 0;
            var right = height.Length - 1;
            while (left < right)
            {
                var width = right - left;
                var area = Math.Min(height[left], height[right]) * width;
                maxArea = Math.Max(maxArea, area);

                if (height[left] > height[right])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return maxArea;
        }
    }
}