using System.Collections.Generic;

namespace DS.LeetCode.Problems
{
    public class TwoSumProblem
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (map.ContainsKey(num))
                    map[num]++;
                else
                    map.Add(num, 1);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                map[num]--;

                var remaining = target - num;
                if (map.ContainsKey(remaining) && map[remaining]-- > 0)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] == remaining) return new int[] {i, j};
                    }
                }
            }

            return null;
        }
    }
}