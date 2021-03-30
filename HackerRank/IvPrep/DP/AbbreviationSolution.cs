using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackerRank.IvPrep.DP
{
    public class AbbreviationSolution
    {
        static string Abbreviation(string source, string target)
        {
            var memo = new Dictionary<string, bool>();
            return CanConstruct(source, target, memo) ? "YES" : "NO";
        }

        private static bool CanConstruct(string source, string target, IDictionary<string, bool> memo)
        {
            if (memo.ContainsKey(source))
                return memo[source];
            
            if (source.Length < target.Length)
                return false;

            if (source.Length == target.Length)
                return source == target;

            for (int i = 0; i < source.Length; i++)
            {
                if (char.IsUpper(source[i]))
                {
                    if (i >= target.Length || source[i] != target[i])
                        return false;
                }
                else
                {
                    var removeSourceChar = source.Remove(i, 1);
                    var replaceSourceChar = removeSourceChar.Insert(i, char.ToUpper(source[i]).ToString());

                    var removeSourceCharResult = CanConstruct(removeSourceChar, target, memo);
                    var replaceSourceCharResult = CanConstruct(replaceSourceChar, target, memo);
                    
                    memo.Add(removeSourceChar, removeSourceCharResult);
                    memo.Add(replaceSourceChar, replaceSourceCharResult);
                    
                    return removeSourceCharResult || replaceSourceCharResult;
                }
            }

            return true;
        }

        public static void RunMain()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            var str = new StringBuilder();

            for (int qItr = 0; qItr < q; qItr++)
            {
                string a = Console.ReadLine();

                string b = Console.ReadLine();

                string result = Abbreviation(a, b);

                Console.WriteLine(result);
            }

            // Console.Clear();
            // Console.WriteLine(str.ToString());
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