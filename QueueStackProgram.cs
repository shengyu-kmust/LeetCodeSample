using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSample
{
    /// <summary>
    /// 栈和堆
    /// </summary>
    public static class QueueStackProgram
    {
        /// <summary>
        /// 有效括号，高频率  todo
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks>
        /// 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
        /// 有效字符串需满足：
        //  左括号必须用相同类型的右括号闭合。
        /// 左括号必须以正确的顺序闭合。
        /// 注意空字符串可被认为是有效字符串。
        /// </remarks>
        public static bool Method_20(string s)
        {
            SortedSet<int> a;

            // todo 有效括号
            // 参考：https://leetcode-cn.com/problems/valid-parentheses/solution/you-xiao-de-gua-hao-by-leetcode-solution/
            //[(){}[]]
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (
                    stack.Count > 0
                    &&
                    ((s[i] == '(' && stack.Peek() == ')')
                    ||
                    (s[i] == '[' && stack.Peek() == ']')
                    ||
                    (s[i] == '{' && stack.Peek() == '}'))
                    )
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            return stack.Count == 0;

            #region 解法1
            //            class Solution
            //        {
            //            public boolean isValid(String s)
            //            {
            //                int n = s.length();
            //                if (n % 2 == 1)
            //                {
            //                    return false;
            //                }

            //                Map<Character, Character> pairs = new HashMap<Character, Character>() {{
            //            put(')', '(');
            //                put(']', '[');
            //                put('}', '{');
            //            }
            //        };
            //        Deque<Character> stack = new LinkedList<Character>();
            //        for (int i = 0; i<n; i++) {
            //            char ch = s.charAt(i);
            //            if (pairs.containsKey(ch)) {
            //                if (stack.isEmpty() || stack.peek() != pairs.get(ch)) {
            //                    return false;
            //                }
            //                stack.pop();
            //            } else {
            //                stack.push(ch);
            //            }
            //        }
            //        return stack.isEmpty();
            //    }
            //}

            #endregion

        }

        /// <summary>
        /// 会议室，低频率
        /// </summary>
        /// <returns></returns>
        public static int Method_252(int[][] intervals)
        {
            // todo 会议室
            //给定一个会议时间安排的数组 intervals ，每个会议时间都会包括开始和结束的时间 intervals[i] = [starti, endi] ，请你判断一个人是否能够参加这里面的全部会议

            // 方法一，全部两两比较，暴力法
            #region 方法一
            //            public boolean canAttendMeetings(int[][] intervals)
            //            {
            //                for (int i = 0; i < intervals.length; i++)
            //                {
            //                    for (int j = i + 1; j < intervals.length; j++)
            //                    {
            //                        if (overlap(intervals[i], intervals[j]))
            //                            return false;
            //                    }
            //                }
            //                return true;
            //            }

            //            public static boolean overlap(int[] i1, int[] i2)
            //            {
            //                return ((i1[0] >= i2[0] && i1[0] < i2[1]) || (i2[0] >= i1[0] && i2[0] < i1[1]));
            //            }

            //public static boolean overlap(int[] i1, int[] i2)
            //{
            //    return (Math.min(i1[1], i2[1]) >
            //            Math.max(i1[0], i2[0]));
            //}


            #endregion
            return 0;
        }



        /// <summary>
        /// 会议室 II，低频率
        /// </summary>
        /// <returns></returns>
        public static int Method_253()
        {
            // todo 会议室2
            //给定一个会议时间安排的数组，每个会议时间都会包括开始和结束的时间[[s1, e1],[s2, e2],...] (si < ei)，为避免会议冲突，同时要考虑充分利用会议室资源，请你计算至少需要多少间会议室，才能满足这些会议安排。

            #region 方法1

            //            思路
            //                按照 开始时间 对会议进行排序。

            //初始化一个新的 最小堆，将第一个会议的结束时间加入到堆中。我们只需要记录会议的结束时间，告诉我们什么时候房间会空。

            //对每个会议，检查堆的最小元素（即堆顶部的房间）是否空闲。

            //若房间空闲，则从堆顶拿出该元素，将其改为我们处理的会议的结束时间，加回到堆中。
            //若房间不空闲。开新房间，并加入到堆中。
            //处理完所有会议后，堆的大小即为开的房间数量。这就是容纳这些会议需要的最小房间数。/
            //            class Solution
            //        {
            //            public int minMeetingRooms(int[][] intervals)
            //            {

            //                // Check for the base case. If there are no intervals, return 0
            //                if (intervals.length == 0)
            //                {
            //                    return 0;
            //                }

            //                // Min heap
            //                PriorityQueue<Integer> allocator =
            //                    new PriorityQueue<Integer>(
            //                        intervals.length,
            //                        new Comparator<Integer>()
            //                        {
            //                          public int compare(Integer a, Integer b)
            //                {
            //                    return a - b;
            //                }
            //            });

            //    // Sort the intervals by start time
            //    Arrays.sort(
            //        intervals,
            //        new Comparator<int[]>() {
            //          public int compare(final int[] a, final int[] b)
            //            {
            //                return a[0] - b[0];
            //            }
            //        });

            //    // Add the first meeting
            //    allocator.add(intervals[0][1]);

            //    // Iterate over remaining intervals
            //    for (int i = 1; i<intervals.length; i++) {

            //      // If the room due to free up the earliest is free, assign that room to this meeting.
            //      if (intervals[i][0] >= allocator.peek()) {
            //        allocator.poll();
            //      }

            //    // If a new room is to be assigned, then also we add to the heap,
            //    // If an old room is allocated, then also we have to add to the heap with updated end time.
            //    allocator.add(intervals[i][1]);
            //    }

            //// The size of the heap tells us the minimum rooms required for all the meetings.
            //return allocator.size();
            //  }
            //}

            #endregion
            return 0;
        }
    }

}
