using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetcodeCsharp;

/// <summary>
/// 2. Add Two Numbers
/// </summary>
/// <remarks>https://leetcode.com/problems/add-two-numbers/</remarks>
[Category("Medium")]
public class AddTwoNumbersTests
{
    [TestCase(new int[] {2, 4, 3}, new int[] {5, 6, 4}, new int[] {7, 0, 8})]
    [TestCase(new int[] {0}, new int[] {0}, new int[] {0})]
    [TestCase(new int[] {9, 9, 9, 9, 9, 9, 9}, new int[] {9, 9, 9, 9}, new int[] {8, 9, 9, 9, 0, 0, 0, 1})]
    public void Solution_Returns_Correctly(int[] arr1, int[] arr2, int[] expectedArr)
    {
        // given inputs and expected
        var list1 = Solution.CreateListNode(arr1);
        var list2 = Solution.CreateListNode(arr2);
        var expected = Solution.CreateListNode(expectedArr);

        // when add two numbers
        var actual = new Solution().AddTwoNumbers(list1, list2);

        // then assert result are same
        while (expected != null || actual != null)
        {
            Assert.AreEqual(expected.val, actual.val);
            expected = expected.next;
            actual = actual.next;
        }
        Assert.Null(expected);
        Assert.Null(actual);
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var answer = new List<int>();
            var carry = 0;
            while (l1 != null || l2 != null)
            {
                var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
                
                carry = 0;
                if (sum >= 10)
                {
                    carry = 1;
                    sum -= 10;
                }

                answer.Add(sum);
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            if (carry > 0)
            {
                answer.Add(carry);
            }
            return CreateListNode(answer.ToArray());
        }

        public static ListNode CreateListNode(int[] arr, int index = 0)
        {
            return arr.Length == index + 1
                ? new ListNode(arr[index])
                : new ListNode(arr[index], CreateListNode(arr, index + 1));
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}