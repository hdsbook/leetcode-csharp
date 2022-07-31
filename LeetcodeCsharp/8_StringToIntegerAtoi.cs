using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LeetcodeCsharp;

/// <summary>
/// 8. String to Integer (atoi)
/// </summary>
/// <remarks>atoi stands for "ASCII to integer"</remarks>
/// <remarks>https://leetcode.com/problems/string-to-integer-atoi/</remarks>
[Category("Medium")]
public class StringToIntegerAtoiTests
{
    [TestCase("42", 42)]
    [TestCase("-42", -42)]
    [TestCase("4193 with words", 4193)]
    [TestCase("words and 987", 0)]
    [TestCase("-91283472332", -2147483648)]
    public void Solution_Returns_Correctly(string s, int expected)
    {
        // when
        var actual = new Solution().MyAtoi(s);

        // then assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase("42", 42)]
    [TestCase("-42", -42)]
    [TestCase("4193 with words", 4193)]
    [TestCase("words and 987", 0)]
    [TestCase("-91283472332", -2147483648)]
    public void Solution_WithRegex_ReturnsCorrectly(string s, int expected)
    {
        // when
        var actual = new SolutionWithRegex().MyAtoi(s);

        // then assert
        Assert.AreEqual(expected, actual);
    }
    
    public class Solution
    {
        public int MyAtoi(string s)
        {
            s = s.Trim(' ');
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var sign = s[0] == '-' ? -1 : 1;
            if (s[0] == '+' || s[0] == '-')
            {
                s = s.Substring(1);
            }

            int number = 0, digit = 0;
            foreach (var c in s)
            {
                if (!char.IsNumber(c))
                {
                    break;
                }

                // digit = (int) char.GetNumericValue(c);
                // digit = int.Parse(c.ToString());
                digit = c - '0';
                if (number > (Int32.MaxValue - digit) / 10)
                {
                    return sign > 0 ? Int32.MaxValue : Int32.MinValue;
                }

                number = number * 10 + digit;
            }

            return sign * number;
        }
    }

    /// <summary>
    /// 用正規表示法的解法 (但效能稍慢)
    /// </summary>
    public class SolutionWithRegex
    {
        public int MyAtoi(string s)
        {
            s = s.Trim(' ');
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var firstChar = s[0];
            var sign = firstChar == '-' ? -1 : 1;
            
            var pattern = "^([+-])?(\\d+)(.)*$";
            if (!Regex.IsMatch(s, pattern))
            {
                return 0;
            }

            s = Regex.Replace(s, pattern, "$2");
            var parseSuccess = Int32.TryParse(s, out var number);
            return parseSuccess 
                ? sign * number 
                : sign > 0 ? Int32.MaxValue : Int32.MinValue;
        }
    }
}