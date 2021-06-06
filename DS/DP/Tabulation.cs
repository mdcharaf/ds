using System;
using System.Collections.Generic;
using System.Linq;

namespace DS.DP
{
    /// <summary>
    /// 1- Visualize the problem as a table
    /// 2- Figure out Size of the table (watch out for n+1)
    /// 3- Initialize values of the table
    /// 4- Seed the trivial answer into the table
    /// 5- Iterate the table and implement the logic
    /// </summary>
    public class Tabulation
    {
        public static long Fib(long n)
        {
            var table = new long[n + 1];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = 0;
            }

            table[1] = 1;
            for (int i = 0; i < table.Length; i++)
            {
                if (i + 1 < table.Length)
                {
                    table[i + 1] += table[i];
                }

                if (i + 2 < table.Length)
                {
                    table[i + 2] += table[i];
                }
            }

            return table[n];
        }

        public static long GridTraveller(int n, int m)
        {
            var table = new long[n + 1, m + 1];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = 0;
                }
            }

            table[1, 1] = 1;

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (i + 1 < table.GetLength(0))
                    {
                        table[i + 1, j] += table[i, j];
                    }

                    if (j + 1 < table.GetLength(1))
                    {
                        table[i, j + 1] += table[i, j];
                    }
                }
            }

            return table[n, m];
        }

        public static bool CanSum(long targetSum, long[] arr)
        {
            var table = new bool[targetSum + 1];
            table[0] = true;

            for (int i = 0; i < table.Length; i++)
            {
                foreach (var number in arr)
                {
                    if (i + number < table.Length)
                    {
                        table[i + number] |= table[i];
                    }
                }
            }

            return table[targetSum];
        }

        public static long[] HowSum(long targetSum, long[] arr)
        {
            var table = new long [targetSum + 1][];
            table[0] = Array.Empty<long>();

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == null)
                    continue;

                foreach (var number in arr)
                {
                    if (i + number < table.Length)
                    {
                        var targetArray = table[i].Concat(new[] {number}).ToArray();
                        table[i + number] = targetArray;
                    }
                }
            }

            return table[targetSum];
        }

        public static int[] BestSum(int targetSum, int[] arr)
        {
            var table = new int[targetSum + 1][];
            table[0] = Array.Empty<int>();

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == null)
                    continue;

                foreach (var num in arr)
                {
                    if (i + num < table.Length)
                    {
                        if (table[i + num] == null || table[i].Length + 1 < table[i + num].Length)
                        {
                            table[i + num] = table[i].Concat(new[] {num}).ToArray();
                        }
                    }
                }
            }

            return table[targetSum];
        }

        public static long CountConstruct(string targetString, string[] words)
        {
            var table = new long[targetString.Length + 1];
            Array.Fill(table, 0);
            table[0] = 1;

            for (int i = 0; i < table.Length - 1; i++)
            {
                foreach (var word in words)
                {
                    if (i + word.Length >= table.Length)
                        continue;

                    var targetSubString = TrySubstring(targetString, i, word.Length);
                    if (targetSubString != null && targetSubString.Equals(word))
                    {
                        {
                            table[i + word.Length] += table[i];
                        }
                    }
                }
            }

            return table[targetString.Length];
        }

        public static IEnumerable<IEnumerable<string>> AllConstruct(string targetString, string[] words)
        {
            var table = new List<List<IEnumerable<string>>>();
            for (int i = 0; i < targetString.Length + 1; i++)
            {
                table.Add(new List<IEnumerable<string>>());
            }

            table[0].Add(new List<string>());

            for (int i = 0; i < table.Count - 1; i++)
            {
                foreach (var word in words)
                {
                    if (i + word.Length >= table.Count)
                        continue;

                    var targetSubstring = TrySubstring(targetString, i, word.Length);
                    if (targetSubstring != null && targetSubstring.Equals(word))
                    {
                        foreach (var combination in table[i])
                        {
                            table[i + word.Length].Add(combination.Concat(new[] {word}));
                        }
                    }
                }
            }

            return table[targetString.Length];
        }

        public static IEnumerable<IEnumerable<string>> AllConstruct2(string targetString, string[] words)
        {
            var table = new List<List<IEnumerable<string>>>();
            for (int i = 0; i < targetString.Length + 1; i++)
            {
                table.Add(new List<IEnumerable<string>>());
            }

            table[0].Add(new List<string>());
            var wordsList = new List<string>(words);

            for (int i = 0; i < table.Count - 1; i++)
            {
                for (int j = 0; j < wordsList.Count; j++)
                {
                    var word = wordsList[j];
                    if (i + word.Length >= table.Count)
                        continue;

                    var targetSubstring = TrySubstring(targetString, i, word.Length);
                    if (targetSubstring != null &&
                        targetSubstring.Equals(word, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (var combination in table[i])
                        {
                            table[i + word.Length].Add(combination.Concat(new[] {word}));
                        }

                        wordsList.RemoveAt(j--);
                    }
                }
            }

            return table[targetString.Length];
        }

        static string TrySubstring(string str, int start, int length)
        {
            try
            {
                return str.Substring(start, length);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
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

            // PrintArrayArray(Tabulation.AllConstruct2("ABC",
            //     new[] {"d", "a", "B", "c", "d"})); 

        }
    }
}