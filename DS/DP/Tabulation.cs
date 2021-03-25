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
                    var targetSubString = TrySubstring(targetString, i, word.Length);
                    if (targetSubString != null && targetSubString.StartsWith(word))
                    {
                        if (i + word.Length < table.Length)
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
                    var targetSubstring = TrySubstring(targetString, i, word.Length);
                    if (targetSubstring != null && targetSubstring.StartsWith(word))
                    {
                        if (i + word.Length < table.Count)
                        {
                            foreach (var combination in table[i])
                            {
                                table[i + word.Length].Add(combination.Concat(new []{word}));
                            }
                        }
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
    }
}