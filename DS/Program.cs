using System;
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
            
            PrintArray(Slow.BestSum(7, new [] {5, 3, 4, 7})); //[7]
            PrintArray(Slow.BestSum(8, new [] {2, 3, 5})); // [3, 5]
            PrintArray(Slow.BestSum(8, new [] {1, 4, 5})); // [4, 4]
            PrintArray(Memoization.BestSum(100, new [] {1, 2, 5, 25})); // [25, 25, 25, 25]
        }

        static void PrintArray(int[] arr)
        {
            if (arr == null)
                Console.WriteLine("null");
            else
            {
               Console.WriteLine("[{0}]", string.Join(", ", arr));
            }
        }
    }
}