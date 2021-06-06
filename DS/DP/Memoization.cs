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

        static void PrintMemoization()
        {
            // Console.WriteLine(Slow.GridTraveller(1, 1)); // 1
            // Console.WriteLine(Slow.GridTraveller(2, 3)); // 3
            // Console.WriteLine(Slow.GridTraveller(3, 2)); // 3
            // Console.WriteLine(Slow.GridTraveller(3, 3)); // 6
            // Console.WriteLine(Memoization.GridTraveller(18, 18)); // 2333606220
            //
            // Console.WriteLine(Slow.CanSum(7, new[] {2, 3})); // true
            // Console.WriteLine(Slow.CanSum(7, new[] {5, 3, 4, 7})); // true
            // Console.WriteLine(Slow.CanSum(7, new[] {2, 4})); // false
            // Console.WriteLine(Slow.CanSum(8, new[] {2, 3, 5})); // true
            // Console.WriteLine(Memoization.CanSum(300, new[] {7, 14})); // false
            //
            // PrintArray(Slow.HowSum(7, new []{2, 3})); // [3, 2, 2]
            // PrintArray(Slow.HowSum(7, new []{5, 3, 4, 7})); // [3, 4]
            // PrintArray(Slow.HowSum(7, new []{2, 4})); // null
            // PrintArray(Slow.HowSum(8, new []{2, 3, 5})); // [2, 2, 2, 2]
            // PrintArray(Memoization.HowSum(300, new []{7, 14})); // null
            //
            // PrintArray(Slow.BestSum(7, new [] {5, 3, 4, 7})); //[7]
            // PrintArray(Slow.BestSum(8, new [] {2, 3, 5})); // [3, 5]
            // PrintArray(Slow.BestSum(8, new [] {1, 4, 5})); // [4, 4]
            // PrintArray(Memoization.BestSum(100, new [] {1, 2, 5, 25})); // [25, 25, 25, 25]
            //
            // Console.WriteLine(Slow.CanConstruct("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
            // Console.WriteLine(Slow.CanConstruct("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            // Console.WriteLine(Memoization.CanConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //     new[] {"e", "eee", "ee", "eeee", "eeeee", "eeeeee", "eeeeeeee"}));
            //
            // Console.WriteLine(Slow.CountConstruct("purple", new[] {"purp", "p", "ur", "le", "purpl"}));
            // Console.WriteLine(Slow.CountConstruct("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
            // Console.WriteLine(Slow.CountConstruct("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            // Console.WriteLine(Memoization.CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //     new[] {"e", "eee", "ee", "eeee", "eeeee", "eeeeee", "eeeeeeee"}));
            //
            // PrintArrayArray(Memoization.AllConstruct("purple", new[] {"purp", "p", "ur", "le", "purpl"}));
            // PrintArrayArray(Memoization.AllConstruct("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
            // PrintArrayArray(Memoization.AllConstruct("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            // PrintArrayArray(Memoization.AllConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //     new[] {"e", "eee", "ee", "eeee", "eeeee", "eeeeee", "eeeeeeee"}));
        }
    }
}