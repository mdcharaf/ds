using System;
using System.Collections.Generic;
using System.Linq;

namespace DS.DP
{
    // 1- Make it work
    //  - Visualize the problem as a tree
    //  - implement the tree using recursion
    //  - test it

    // 2- Make it efficient 
    //  - Add Memo object
    //  - Add a base case to return memo values
    //  - store return values into memo
    public class Memoization
    {
        public static long Fib(long n, IDictionary<long, long> memo = null)
        {
            memo ??= new Dictionary<long, long>();

            if (n <= 2) return 1;

            if (memo.ContainsKey(n)) return memo[n];

            memo.Add(n, Fib(n - 1, memo) + Fib(n - 2, memo));
            return memo[n];
        }


        public static long GridTraveller(long m, long n, IDictionary<string, long> memo = null)
        {
            memo ??= new Dictionary<string, long>();

            if (m == 0 || n == 0) return 0;
            if (m == 1 || n == 1) return 1;

            var nm = string.Join(",", n, m);
            var mn = string.Join(",", m, n);

            if (memo.ContainsKey(nm) || memo.ContainsKey(mn))
                return memo[nm];

            var result = GridTraveller(m - 1, n, memo) + GridTraveller(m, n - 1, memo);

            memo.TryAdd(nm, result);
            memo.TryAdd(mn, result);

            return result;
        }

        public static bool CanSum(long targetSum, int[] arr, IDictionary<long, bool> memo = null)
        {
            memo ??= new Dictionary<long, bool>();

            if (targetSum == 0) return true;
            if (targetSum < 0) return false;
            if (memo.ContainsKey(targetSum))
                return memo[targetSum];

            foreach (var num in arr)
            {
                var remainder = targetSum - num;

                if (CanSum(remainder, arr, memo))
                {
                    memo.Add(targetSum, true);
                    return true;
                }
            }

            memo.Add(targetSum, false);
            return false;
        }

        public static int[] HowSum(long targetSum, int[] arr, IDictionary<long, int[]> memo = null)
        {
            memo ??= new Dictionary<long, int[]>();

            if (targetSum < 0) return null;
            if (targetSum == 0) return Array.Empty<int>();
            if (memo.ContainsKey(targetSum)) return memo[targetSum];

            foreach (var num in arr)
            {
                var remainder = targetSum - num;
                var remainderResult = HowSum(remainder, arr, memo);

                if (remainderResult != null)
                {
                    var result = remainderResult.Concat(new[] {num}).ToArray();
                    memo.Add(targetSum, result);

                    return result;
                }
            }

            memo.Add(targetSum, null);
            return null;
        }

        public static int[] BestSum(long targetSum, int[] arr, IDictionary<long, int[]> memo = null)
        {
            memo ??= new Dictionary<long, int[]>();

            if (memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;

            int[] shortestCombination = null;

            foreach (var num in arr)
            {
                var remainder = targetSum - num;
                var remainderCombination = BestSum(remainder, arr, memo);

                if (remainderCombination != null)
                {
                    var combination = remainderCombination.Concat(new[] {num}).ToArray();
                    if (shortestCombination == null || combination.Length < shortestCombination.Length)
                    {
                        shortestCombination = combination;
                    }
                }
            }

            memo.Add(targetSum, shortestCombination);
            return shortestCombination;
        }

        public static bool CanConstruct(string target, string[] words, IDictionary<string, bool> memo = null)
        {
            memo ??= new Dictionary<string, bool>();

            if (string.IsNullOrEmpty(target)) return true;
            if (memo.ContainsKey(target)) return memo[target];

            foreach (var word in words)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Substring(word.Length);
                    if (CanConstruct(suffix, words, memo))
                    {
                        memo.Add(target, true);
                        return true;
                    }
                }
            }

            memo.Add(target, false);
            return false;
        }

        public static long CountConstruct(string target, string[] words, IDictionary<string, long> memo = null)
        {
            memo ??= new Dictionary<string, long>();
            if (string.IsNullOrEmpty(target)) return 1;
            if (memo.ContainsKey(target)) return memo[target];

            long count = 0;
            foreach (var word in words)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Substring(word.Length);
                    count += CountConstruct(suffix, words, memo);
                }
            }

            memo.Add(target, count);
            return count;
        }

        public static IList<IList<string>> AllConstruct(string target, string[] words,
            IDictionary<string, IList<IList<string>>> memo = null)
        {
            memo ??= new Dictionary<string, IList<IList<string>>>();
            if (string.IsNullOrEmpty(target)) return new List<IList<string>>();
            if (memo.ContainsKey(target)) return memo[target];

            List<IList<string>> result = null;
            foreach (var word in words)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Substring(word.Length);
                    var suffixCombination = AllConstruct(suffix, words, memo);

                    if (suffixCombination != null)
                    {
                        result ??= new List<IList<string>>();

                        var targetCombination = new List<List<string>>();
                        if (suffixCombination.Count == 0)
                            targetCombination.Add(new List<string>() {word});
                        else
                            targetCombination.AddRange(
                                suffixCombination.Select(sc => new List<string>(sc) {word}));

                        result.AddRange(targetCombination);
                    }
                }
            }

            memo.Add(target, result);
            return result;
        }
    }
}