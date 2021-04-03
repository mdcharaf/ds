using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRank.IvPrep.DP
{
    public class AbbreviationSolution
    {
        static string Abbreviation(string source, string target)
        {
            var memo = new Dictionary<string, bool>();
            return CanConstruct(source, target, 0, memo) ? "YES" : "NO";
        }

        private static bool CanConstruct(string source, string target, int start, IDictionary<string, bool> memo)
        {
            if (source.Length < target.Length)
                return false;

            if (memo.ContainsKey(source))
                return memo[source];

            for (int i = start; i < source.Length; i++)
            {
                if (char.IsUpper(source[i]))
                {
                    // if Exists an upper character at the end of the string || sourceChar != targetChar
                    if (i >= target.Length || source[i] != target[i])
                    {
                        memo.Add(source, false);
                        return false;
                    }
                }
                else
                {
                    var removeSourceChar = source.Remove(i, 1);

                    // If i is beyond target length then we just need to remove, no need to replace
                    if (i >= target.Length)
                    {
                        memo.Add(source, CanConstruct(removeSourceChar, target, i, memo));
                        return memo[source];
                    }

                    var replaceSourceChar =
                        removeSourceChar.Insert(i, char.ToUpper(source[i]).ToString());

                    // Only attempt replacing when if the upper source char equals target character
                    memo.Add(source,
                        char.ToUpper(source[i]) == target[i] && CanConstruct(replaceSourceChar, target, i, memo) ||
                        CanConstruct(removeSourceChar, target, i, memo));

                    return memo[source];
                }
            }

            memo.Add(source, true);
            return true;
        }

        public static void RunMain()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            var stringBuilder = new StringBuilder();
            var watch = new Stopwatch();
            // Console.WriteLine(Directory.GetCurrentDirectory());

            watch.Start();
            for (int qItr = 0; qItr < q; qItr++)
            {
                string a = Console.ReadLine();

                string b = Console.ReadLine();

                string result = Abbreviation(a, b);

                // Console.WriteLine(result);
                stringBuilder.AppendLine(result);
            }

            watch.Stop();
            stringBuilder.AppendLine(watch.Elapsed.TotalSeconds.ToString(CultureInfo.InvariantCulture));

            Console.Clear();
            Console.WriteLine(stringBuilder.ToString());
        }

        public static void RunTestCase()
        {
            var path = "/Users/muhammad/code/dotnet/DS/HackerRank/Testcases/13.txt";
            using (var streamReader = new StreamReader(path))
            {
                var q = int.Parse(streamReader.ReadLine());
                var stringBuilder = new StringBuilder();
                var watch = new Stopwatch();

                watch.Start();
                for (int qItr = 0; qItr < q; qItr++)
                {
                    var a = streamReader.ReadLine();

                    string b = streamReader.ReadLine();

                    watch.Start();
                    string result = Abbreviation(a, b);
                    watch.Stop();

                    // stringBuilder.AppendLine(result);
                }

                stringBuilder.AppendLine(watch.Elapsed.TotalSeconds.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine(stringBuilder.ToString());
            }
        }

        static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string a = Console.ReadLine();

                string b = Console.ReadLine();

                string result = Abbreviation(a, b);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}