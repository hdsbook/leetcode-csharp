using System.Collections.Generic;
using FluentAssertions;
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

        // then
        actual.Should().Be(expected);
    }

    public class Solution
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}