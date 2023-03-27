using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 121. Best Time to Buy and Sell Stock
/// </summary>
/// <remarks>https://leetcode.com/problems/best-time-to-buy-and-sell-stock/</remarks>
[Category("Easy")]
public class BestTimeToBuyAndSellStock
{
    [TestCase(new int[] {7,1,5,3,6,4}, 5)]
    [TestCase(new int[] {7,6,4,3,1}, 0)]
    public void Solution_Returns_Correctly(int[] prices, int expected)
    {
        // when
        var actual = new Solution().MaxProfit(prices);

        // then
        actual.Should().Be(expected);
    }

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1)
            {
                return 0;
            }
            else if (prices.Length == 2 && prices[0] <= prices[1])
            {
                return prices[1] - prices[0];
            }

            var lowerPrice = prices[0];
            var maxProfit = 0;
            for (var i = 0; i < prices.Length; i++)
            {
                if (prices[i] < lowerPrice)
                {
                    lowerPrice = prices[i];
                    continue;
                }

                if (prices[i] - lowerPrice > maxProfit)
                {
                    maxProfit = prices[i] - lowerPrice;
                }
            }

            return maxProfit;
        }
    }
}