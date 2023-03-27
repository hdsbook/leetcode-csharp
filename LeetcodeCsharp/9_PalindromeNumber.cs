using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 9. Palindrome Number
/// </summary>
/// <remarks>https://leetcode.com/problems/palindrome-number/</remarks>
[Category("Easy")]
public class PalindromeNumberTests
{
    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(10, false)]
    public void Solution_Returns_Correctly(int x, bool expected)
    {
        // when
        var actual = new Solution().IsPalindrome(x);

        // then
        actual.Should().Be(expected);
    }

    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(10, false)]
    public void Solution_WithoutConvertToString_ReturnsCorrectly(int x, bool expected)
    {
        // when
        var actual = new SolutionWithoutConvertToString().IsPalindrome(x);

        // then assert
        Assert.AreEqual(expected, actual);
    }

    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }
            else if (x < 10)
            {
                return true;
            }

            var str = x.ToString();
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return str == new string(charArray);
        }
    }

    public class SolutionWithoutConvertToString
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }
            else if (x < 10)
            {
                return true;
            }

            var reverseX = 0;
            var num = x;
            while (num > 0)
            {
                reverseX = reverseX * 10 + num % 10;
                num /= 10;
            }

            return x == reverseX;
        }
    }
}