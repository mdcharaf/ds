using System.Collections.Generic;

namespace DS.CodeSignal.IvPrep.DPBasic
{
    public class ComposeRangesProblem
    {
        public static string[] ComposeRanges(int[] nums)
        {
            var result = new List<string>();
            
            int p = 0;
            int q = 0;

            while (p < nums.Length)
            {
                int i = q + 1;
                while (nums[i] - nums[q] == 1)
                {
                    
                }
                
            }

            return result.ToArray();
        }
    }
}