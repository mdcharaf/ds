using System.Collections.Generic;

namespace DS.LeetCode.Problems
{
    public class CombinationSumProblem
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            return GetCombinationSum(candidates, target, 0);
        }

        IList<IList<int>> GetCombinationSum(int[] arr, int target, int p)
        {
            if (target < 0) return null;
            if (target == 0) return new List<IList<int>>() {new List<int>()};

            var result = new List<IList<int>>();
            for (int i = p; i < arr.Length; i++)
            {
                var number = arr[i];
                var remainderResult = GetCombinationSum(arr, target - number, i);
                
                if (remainderResult == null) continue;
                
                foreach (var list in remainderResult)
                {
                    list.Add(number);
                }
                
                result.AddRange(remainderResult);
            }

            return result;
        }
    }
}