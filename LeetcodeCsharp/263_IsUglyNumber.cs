using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 263. Ugly Number
/// </summary>
/// <remarks>https://leetcode.com/problems/ugly-number/</remarks>
[Category("Easy")]
public class IsUglyNumberTests
{
    [TestCase(0, false)]
    [TestCase(1, false)]
    [TestCase(6, true)]
    [TestCase(8, true)]
    [TestCase(14, false)]
    public void Solution_Returns_Correctly(int num, bool expected)
    {
        // when check is ugly number
        var isUglyNumber = new Solution().IsUglyNumber(num);
            
        // then
        isUglyNumber.Should().Be(expected);
    }

    public class Solution
    {
        public bool IsUglyNumber(int num)
        {
            if (num <= 1)
            {
                return false;
            }

            var allowedFactors = new List<int> {2, 3, 5};
            foreach (var factor in allowedFactors)
            {
                while (num % factor == 0)
                {
                    num /= factor;
                }
            }

            return num == 1;
        }
    }
}