using System;
using System.Collections.Generic;
using System.Linq;

namespace DS.DP
{
    public class Slow
    {
        public static long Fib(long n)
        {
            if (n <= 2) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }

        public static long GridTraveller(long m, long n)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 || n == 1) return 1;

            return GridTraveller(m - 1, n) + GridTraveller(m, n - 1);
        }

        public static bool CanSum(long targetSum, int[] arr)
        {
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;

            foreach (var num in arr)
            {
                var remainder = targetSum - num;

                if (CanSum(remainder, arr)) return true;
            }

            return false;
        }

        public static int[] HowSum(long targetSum, int[] arr)
        {
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;

            foreach (var num in arr)
            {
                var remainder = targetSum - num;
                var result = HowSum(remainder, arr);

                if (result != null)
                {
                    return result.Concat(new[] {num}).ToArray();
                }
            }

            return null;
        }

        public static int[] BestSum(long targetSum, int[] arr)
        {
            if (targetSum < 0) return null;
            if (targetSum == 0) return Array.Empty<int>();

            int[] shortestCombination = null;

            foreach (var num in arr)
            {
                var remainder = targetSum - num;
                var remainderCombination = BestSum(remainder, arr);

                if (remainderCombination != null)
                {
                    var combination = remainderCombination.Concat(new[] {num}).ToArray();
                    if (shortestCombination == null || combination.Length < shortestCombination.Length)
                    {
                        shortestCombination = combination;
                    }
                }
            }

            return shortestCombination;
        }

        public static bool CanConstruct(string target, string[] words)
        {
            if (string.IsNullOrEmpty(target)) return true;

            foreach (var word in words)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Substring(word.Length);
                    if (CanConstruct(suffix, words))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static long CountConstruct(string target, string[] words)
        {
            if (string.IsNullOrEmpty(target)) return 1;

            long count = 0;
            foreach (var word in words)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Substring(word.Length);
                    count += CountConstruct(suffix, words);
                }
            }

            return count;
        }

        public static IList<string> AllConstruct(string target, string[] words)
        {
            if (string.IsNullOrEmpty(target))
                return new List<string>();
                

            var result = new List<string>();
            foreach (var word in words)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Substring(word.Length);
                    var suffixCombinations = AllConstruct(suffix, words);
                    if (suffixCombinations != null)
                    {
                        result.AddRange(suffixCombinations);
                        result.Add(word);
                    }
                }
            }

            return result.Count == 0 ? null : result;
        }
    }
}