using System.Collections;
using System.Collections.Generic;

namespace DS.CodeSignal.IvPrep.DPAdvanced
{
    public class RxMatchingProblem
    {
        bool RegularExpressionMatching(string s, string p)
        {
            return IsMatch(s, p, 0, 0, new Dictionary<string, bool>());
        }

        bool IsMatch(string s, string p, int i, int j, IDictionary<string, bool> memo)
        {
            if (i >= s.Length && j >= p.Length) return true;
            if (j >= p.Length) return false;

            var key = $"{i}{j}";
            if (memo.ContainsKey(key)) return memo[key];

            var match = i < s.Length && (s[i] == p[j] || p[j] == '.');

            bool result;
            if (j + 1 < p.Length && p[j + 1] == '*')
            {
                result = IsMatch(s, p, i, j + 2, memo) // don't use the *
                             || match && IsMatch(s, p, i + 1, j, memo); // Use the *
                memo.Add(key, result);
                return result;
            }

            result = match && IsMatch(s, p, i + 1, j + 1, memo);
            memo.Add(key, result);
            return result;
        }
    }
}