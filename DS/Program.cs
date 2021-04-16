using System;
using System.Collections.Generic;
using System.Linq;
using DS.DP;
using DS.DP.Problems;

namespace DS
{
    class Program
    {
        static void Main(string[] args)
        {
            MountingScene.Main2(args);
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

        static void PrintTabulation()
        {
            // Console.WriteLine(Tabulation.Fib(6));
            // Console.WriteLine(Tabulation.Fib(7));
            // Console.WriteLine(Tabulation.Fib(8));
            // Console.WriteLine(Tabulation.Fib(50));

            // Console.WriteLine(Tabulation.GridTraveller(1, 1)); // 1
            // Console.WriteLine(Tabulation.GridTraveller(2, 3)); // 3
            // Console.WriteLine(Tabulation.GridTraveller(3, 2)); // 3
            // Console.WriteLine(Tabulation.GridTraveller(3, 3)); // 6
            // Console.WriteLine(Tabulation.GridTraveller(18, 18)); // 2333606220

            // Console.WriteLine(Tabulation.CanSum(7, new[] {2, 3})); // true
            // Console.WriteLine(Tabulation.CanSum(7, new[] {5, 3, 4, 7})); // true
            // Console.WriteLine(Tabulation.CanSum(7, new[] {2, 4})); // false
            // Console.WriteLine(Tabulation.CanSum(8, new[] {2, 3, 5})); // true
            // Console.WriteLine(Tabulation.CanSum(300, new[] {7, 14})); // false

            // PrintArray(Tabulation.HowSum(7, new long []{2, 3})); // [3, 2, 2]
            // PrintArray(Tabulation.HowSum(7, new long []{5, 3, 4, 7})); // [3, 4]
            // PrintArray(Tabulation.HowSum(7, new long []{2, 4})); // null
            // PrintArray(Tabulation.HowSum(8, new long []{2, 3, 5})); // [2, 2, 2, 2]
            // PrintArray(Tabulation.HowSum(300, new long []{7, 14})); // null

            // PrintArray(Tabulation.BestSum(7, new [] {5, 3, 4, 7})); //[7]
            // PrintArray(Tabulation.BestSum(8, new [] {2, 3, 5})); // [3, 5]
            // PrintArray(Tabulation.BestSum(8, new [] {1, 4, 5})); // [4, 4]
            // PrintArray(Tabulation.BestSum(100, new [] {1, 2, 5, 25})); // [25, 25, 25, 25]

            // Console.WriteLine(Tabulation.CountConstruct("purple", new[] {"purp", "p", "ur", "le", "purpl"})); //2
            // Console.WriteLine(Tabulation.CountConstruct("abcdef", new[] {"ab", "abc", "cd", "def", "abcd"})); //1
            // Console.WriteLine(Tabulation.CountConstruct("skateboard",
            //     new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"})); //0
            // Console.WriteLine(Tabulation.CountConstruct("enterpotentpot",
            //     new[] {"a", "p", "ent", "enter", "ot", "o", "t"})); //4
            // Console.WriteLine(Tabulation.CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //     new[] {"e", "eee", "ee", "eeee", "eeeee", "eeeeee", "eeeeeeee"})); //0

            // PrintArrayArray(Tabulation.AllConstruct("purple", new[] {"purp", "p", "ur", "le", "purpl"}));
            // PrintArrayArray(Tabulation.AllConstruct("abcdef", new[] {"ab", "abc", "cd", "def", "abcd", "ef", "c"}));
            // PrintArrayArray(Tabulation.AllConstruct("skateboard",
            //     new[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"})); 
            // PrintArrayArray(Tabulation.AllConstruct("enterpotentpot",
            //     new[] {"a", "p", "ent", "enter", "ot", "o", "t"})); 
            // PrintArrayArray(Tabulation.AllConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //     new[] {"e", "eee", "ee", "eeee", "eeeee", "eeeeee", "eeeeeeee"}));
            
            PrintArrayArray(Tabulation.AllConstruct2("ABC",
                new[] {"d", "a", "B", "c", "d"})); 
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
                Console.Write("[");
                foreach (var arr in arrs)
                {
                    if (arr == null)
                    {
                        Console.WriteLine("null");
                        continue;
                    }

                    Console.Write("[{0}] ", string.Join(", ", arr));
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }
    }
}