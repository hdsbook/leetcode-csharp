using System.Collections.Generic;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 1. XXX
/// </summary>
/// <remarks>https://leetcode.com/problems/</remarks>
[Category("Easy")]
public class ExampleTests
{
    [TestCase(1, 2, 3)]
    public void Solution_Returns_Correctly(int a, int b, int expected)
    {
        // when
        var actual = new Solution().Sum(a, b);

        // then assert
        Assert.AreEqual(expected, actual);
    }

    public class Solution
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}