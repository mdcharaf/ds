using System;
using System.Linq;

namespace DS.DP.Problems
{
    // https://open.kattis.com/problems/magicalcows

    public class MagicalCows
    {
        private const int MaxDays = 50;
        public static long[] CountFarms(int maxCows, int[] cowsCountPerFarm, int[] visitingDays)
        {
            var result = new long[visitingDays.Length];

            // Days/FarmsCount per cow table
            var table = new long[MaxDays + 1][];
            
            for (int i = 0; i < table.Length; i++)
                table[i] = new long[maxCows + 1];

            // Initialize CowsCount at Day 0
            foreach (var count in cowsCountPerFarm)
            {
                table[0][count]++;
            }

            for (int day = 0; day < MaxDays; day++)
            {
                for (int i = 1; i <= maxCows; i++)
                {
                    if (i <= maxCows / 2)
                    {
                        table[day + 1][i * 2] += table[day][i];
                    }
                    else
                    {
                        table[day + 1][i] += 2 * table[day][i];
                    }
                }
            }

            for (int i = 0; i < visitingDays.Length; i++)
            {
                var day = visitingDays[i];
                result[i] = table[day].Sum();
            }
            
            return result;
        }

        public static void RunMain(string[] args)
        {
            var cnm = Console.ReadLine().Split(' ');

            var c = Convert.ToInt32(cnm[0]);

            var n = Convert.ToInt32(cnm[1]);

            var m = Convert.ToInt32(cnm[2]);

            var cowsCountPerFarm = new int[n];
            var days = new int[m];

            for (int i = 0; i < n; i++)
            {
                cowsCountPerFarm[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < m; i++)
            {
                days[i] = int.Parse(Console.ReadLine());
            }

            var result = CountFarms(c, cowsCountPerFarm, days);

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }
    }
}