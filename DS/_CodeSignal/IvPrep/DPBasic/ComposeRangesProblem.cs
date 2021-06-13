using System;
using System.Collections.Generic;

namespace DS.CodeSignal.IvPrep.DPBasic
{
    public class ComposeRangesProblem
    {
        public static string[] ComposeRanges(int[] nums)
        {
            if (nums.Length == 0)
                return Array.Empty<string>();

            int p = 0;
            int q = 0;
            var result = new List<string>();

            while (p < nums.Length)
            {
                var i = p;
                q = p + 1;
                var start = nums[i];
                var end = string.Empty;

                if (q >= nums.Length)
                {
                    result.Add($"{start}");
                    break;
                }

                while (q < nums.Length && i < nums.Length && nums[q] - nums[i] == 1)
                {
                    end = nums[q].ToString();
                    q++;
                    i++;
                }

                if (end != string.Empty)
                    result.Add($"{start}->{end}");
                else
                    result.Add($"{start}");

                p = q;
            }

            return result.ToArray();
        }
    }
}