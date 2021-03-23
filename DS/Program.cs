using System;
using System.Collections.Generic;
using System.Linq;
using DS.DP;

namespace DS
{
    class Program
    {
        static void Main(string[] args)
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

            // PrintArray(Slow.BestSum(7, new [] {5, 3, 4, 7})); //[7]
            // PrintArray(Slow.BestSum(8, new [] {2, 3, 5})); // [3, 5]
            // PrintArray(Slow.BestSum(8, new [] {1, 4, 5})); // [4, 4]
            // PrintArray(Memoization.BestSum(100, new [] {1, 2, 5, 25})); // [25, 25, 25, 25]

            // Console.WriteLine(Slow.CanConstruct("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
            // Console.WriteLine(Slow.CanConstruct("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            // Console.WriteLine(Memoization.CanConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //     new[] {"e", "eee", "ee", "eeee", "eeeee", "eeeeee", "eeeeeeee"}));

            // Console.WriteLine(Slow.CountConstruct("purple", new[] {"purp", "p", "ur", "le", "purpl"}));
            // Console.WriteLine(Slow.CountConstruct("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
            // Console.WriteLine(Slow.CountConstruct("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            // Console.WriteLine(Memoization.CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //     new[] {"e", "eee", "ee", "eeee", "eeeee", "eeeeee", "eeeeeeee"}));
            
            PrintArrayArray(Memoization.AllConstruct("purple", new[] {"purp", "p", "ur", "le", "purpl"}));
            PrintArrayArray(Memoization.AllConstruct("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"}));
            PrintArrayArray(Memoization.AllConstruct("skateboard", new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
            PrintArrayArray(Memoization.AllConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                new[] {"e", "eee", "ee", "eeee", "eeeee", "eeeeee", "eeeeeeee"}));
        }

        static void PrintArray<T>(IEnumerable<T> arr)
        {
            if (arr == null)
                Console.WriteLine("null");
            else
            {
                Console.WriteLine("[{0}]", string.Join(", ", arr));
            }
        }
        
        static void PrintArrayArray<T>(IEnumerable<IEnumerable<T>> arrs)
        {
            if (arrs == null)
                Console.WriteLine("null");
            else
            {
                foreach (var arr in arrs)
                {
                    if (arr == null)
                    {
                        Console.WriteLine("null");
                        continue;
                    }
                    
                    Console.WriteLine("[{0}]", string.Join(", ", arr));
                }
            }
        }
    }
}