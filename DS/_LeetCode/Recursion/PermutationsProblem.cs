using System.Collections.Generic;
using System.Linq;

namespace DS._LeetCode.Recursion
{
    public class PermutationsProblem
    {
        public static IList<IList<int>> Permute(int[] nums)
        {
            var result = GetPermutations(nums, 0);

            return result;
        }

        static IList<IList<int>> GetPermutations(int[] arr, int p)
        {
            if (p >= arr.Length) return new List<IList<int>> {new List<int>()};

            var perms = GetPermutations(arr, p + 1);
            var number = arr[p];
            
            var permsWithNum = new List<IList<int>>();

            foreach (var perm in perms)
            {
                for (int i = 0; i <= perm.Count; i++)
                {
                    var permCopy = perm.ToList();
                    permCopy.Insert(i, number);
                    
                    permsWithNum.Add(permCopy);
                }
            }

            return permsWithNum;
        }
    }
}