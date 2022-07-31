using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 7. Reverse Integer
/// </summary>
/// <remarks>https://leetcode.com/problems/reverse-integer/</remarks>
[Category("Medium")]
public class ReverseIntegerTests
{
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(1534236469, 0)]
    public void Solution_Returns_Correctly(int x, int expected)
    {
        // when
        var actual = new Solution().Reverse(x);

        // then assert
        Assert.AreEqual(expected, actual);
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            if (x >= int.MaxValue || x <= int.MinValue)
            {
                return 0;
            }

            var sign = x < 0 ? -1 : 1;
            var charArray = Math.Abs(x).ToString().ToCharArray();
            Array.Reverse(charArray);
            var success = Int32.TryParse(new string(charArray), out var reverseInt);

            return success ? reverseInt * sign : 0;
        }
    }
}