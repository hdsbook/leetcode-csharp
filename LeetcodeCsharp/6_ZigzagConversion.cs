using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 6. Zigzag Conversion
/// </summary>
/// <remarks>https://leetcode.com/problems/zigzag-conversion/</remarks>
[Category("Medium")]
public class ZigzagConversionTests
{
    [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [TestCase("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    public void Solution_Returns_Correctly(string s, int numRows, string expected)
    {
        // when
        var actual = new Solution().Convert(s, numRows);

        // then
        actual.Should().Be(expected);
    }

    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || s.Length <= 2 || numRows >= s.Length)
            {
                return s;
            }

            var strQueues = Enumerable.Range(0, numRows)
                .Select(x => new StringBuilder())
                .ToArray();

            var index = 0;
            var step = 1;
            foreach (var c in s)
            {
                strQueues[index].Append(c);
                index += step;
                if (index == 0 || index == numRows - 1)
                {
                    step *= -1;
                }
            }

            return string.Join("", strQueues.ToList());
        }
    }
}