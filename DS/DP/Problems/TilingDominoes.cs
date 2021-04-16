using System;
using System.Collections.Generic;

namespace DS.DP.Problems
{
    // https://open.kattis.com/problems/trit...
    public class TilingDominoes
    {
        private const int MaxStates = 8;
        
        static long CountTilings(int n)
        {
            // exclude odd
            if (n % 2 != 0)
            {
                return 0;
            }
            
            // Initialize the states count table
            var states = new long[n + 1][];
            for (int i = 0; i < states.Length; i++)
            {
                states[i] = new long[MaxStates];
            }

            states[0][7] = 1;

            // Calculate state count based on previous state count
            for (int i = 1; i < states.Length; i++)
            {
                states[i][0] += states[i - 1][7];

                states[i][1] += states[i - 1][6];

                states[i][2] += states[i - 1][5];

                states[i][3] += states[i - 1][7];
                states[i][3] += states[i - 1][4];

                states[i][4] += states[i - 1][3];
                
                states[i][5] += states[i - 1][2];
                
                states[i][6] += states[i - 1][7];
                states[i][6] += states[i - 1][1];
                
                states[i][7] += states[i - 1][0];
                states[i][7] += states[i - 1][3];
                states[i][7] += states[i - 1][6];
            }

            return states[n][7];
        }

        public static void Main2(string[] args)
        {
            var inputs = new List<int>();
            var input = int.Parse(Console.ReadLine());

            while (input != -1)
            {
                inputs.Add(input);
                input = int.Parse(Console.ReadLine());
            }

            var results = new List<long>();
            foreach (var n in inputs)
            {
                results.Add(CountTilings(n));
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}