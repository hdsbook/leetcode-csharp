using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 3. Longest Substring Without Repeating Characters
/// </summary>
/// <remarks>https://leetcode.com/problems/longest-substring-without-repeating-characters/</remarks>
[Category("Medium")]
public class LongestSubstringWithoutRepeatingCharactersTests
{
    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    [TestCase("", 0)]
    [TestCase("dvdf", 3)]
    public void Solution_Returns_Correctly(string s, int expected)
    {
        // when
        var actual = new Solution().LengthOfLongestSubstring(s);

        // then assert
        Assert.AreEqual(expected, actual);
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var strLength = s.Length;
            if (strLength <= 1)
            {
                return strLength;
            }

            var charDic = new Dictionary<char, bool>();
            var maxLen = 0;
            var startIndex = 0;
            for (var endIndex = 0; endIndex < strLength; endIndex++)
            {
                var c = s[endIndex];
                while (charDic.ContainsKey(c) && startIndex <= endIndex)
                {
                    charDic.Remove(s[startIndex]);
                    startIndex++;
                }

                charDic[c] = true;
                maxLen = Math.Max(maxLen, charDic.Count);
            }

            return maxLen;
        }
    }
}