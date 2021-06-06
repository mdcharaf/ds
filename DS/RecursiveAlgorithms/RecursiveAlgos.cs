using System;
using System.Collections.Generic;
using System.Linq;

namespace DS.RecursiveAlgorithms
{
    /**
   * - Why use Recursion?
   *    . To break down large problems into multiple chuncks
   *    . its a fundamental use in advanced algorithms
   * 
   * - When to use Recursion?
   *    . For problems that contains smaller instances of the same problems (Bottom Up)
   *
   * - Anatomy of Recursion
   *    . Base Case: The smallest instance of the problem that is solved trivially
   *    . Recursive Case: An instance of the problem that shrinks the size of the input towards the base case
   */
    public class RecursiveAlgos
    {
        /// <summary>
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Factorial(int n)
        {
            if (n == 1)
                return 1;

            return n * Factorial(n - 1);
        }

        public static bool BinarySearch(int[] arr, int n)
        {
            Array.Sort(arr);

            return DoBinarySearch(0, arr.Length - 1, arr, n);
        }

        static bool DoBinarySearch(int p, int q, int[] arr, int n)
        {
            if (p > q)
            {
                return false;
            }

            var mid = (int) Math.Floor((double) (p + q) / 2);
            return arr[mid] == n || DoBinarySearch(mid, q, arr, n);
        }


        // Time: O(n^2)
        // Space: O(n)
        public static long Sum(int[] arr)
        {
            if (arr.Length == 0)
                return 0;

            return arr[0] + Sum(arr.Skip(1).ToArray());
        }

        // Time: O(n)
        // Space: O(n)
        public static long Sum2(int[] arr)
        {
            return DoSum(arr, 0);
        }

        static long DoSum(int[] arr, int index)
        {
            if (index == arr.Length)
                return 0;

            return arr[index] + DoSum(arr, index + 1);
        }

        // Time: O(2 ^ n)
        // Space: O(n) : Space complexity is usually the height of the tree. 
        public static long Fib(int n)
        {
            if (n <= 2)
                return 1;

            return Fib(n - 1) + Fib(n - 2);
        }

        // Time: O(2^n)
        // Space: O(n^2)
        public static IList<IEnumerable<string>> Combinations(IList<string> arr)
        {
            if (arr.Count == 0)
                return new List<IEnumerable<string>> {new List<string>()};

            var firstElement = arr[0];
            var rest = arr.Skip(1);

            var combsWithoutFirst = Combinations(rest.ToList());
            var combsWithFirst = new List<IEnumerable<string>>();

            foreach (var comb in combsWithoutFirst)
            {
                var combWithFirst = new List<string> {firstElement};
                combWithFirst.AddRange(comb);
                
                combsWithFirst.Add(combWithFirst);
            }

            var result = new List<IEnumerable<string>>();
            result.AddRange(combsWithoutFirst);
            result.AddRange(combsWithFirst);

            return result;
        }

        // public static IList<IList<string>> Permutations(IList<string> list)
        // {
        //     if (list.Count == 0)
        //         return new List<IList<string>> {new List<string>()};
        //
        //     var firstElement = list[0];
        //     var rest = list.Skip(1);
        //
        //     // perms without first
        //     var perms = Permutations(rest.ToList());
        //     var result = new List<IList<string>>();
        //
        //     for (int i = 0; i < perms.Count; i++)
        //     {
        //         perms[i].Insert(i, firstElement);
        //     }
        //
        //     result.AddRange(perms);
        //
        //     return result;
        // }
    }

    public static class RecursiveAlgosProgram
    {
        public static void Run()
        {
            // Console.WriteLine(RecursiveAlgos.Factorial(3));
            // Console.WriteLine(RecursiveAlgos.Factorial(4));
            // Console.WriteLine(RecursiveAlgos.Factorial(5));

            // var arr = new[] {1, 2, 3, 4};
            // Console.WriteLine(RecursiveAlgos.Sum2(arr));

            // Console.WriteLine(RecursiveAlgos.Fib(7)); // 13
            // Console.WriteLine(JsonConvert.SerializeObject(RecursiveAlgos.Combinations(new []{"a", "b", "c"})));
            // Console.WriteLine(JsonConvert.SerializeObject(RecursiveAlgos.Permutations(new []{"a", "b", "c"})));
        }
    }
}