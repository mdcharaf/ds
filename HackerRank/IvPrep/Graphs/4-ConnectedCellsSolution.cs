using System;
using System.IO;

namespace HackerRank.IvPrep.Graphs
{
    public class ConnectedCellsSolution
    {
        static int MaxRegion(int[][] grid)
        {
            // 1- Loop through the matrix
            // 2- Apply DFS for each cell that contains one and get the size
            
            int maxRegion = 0;
            
            for (int i = 0; i < grid.Length; i++)
            {
                var row = grid[i];
                for (int j = 0; j < row.Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int size = GetRegionSize(grid, i, j);
                        maxRegion = Math.Max(size, maxRegion);
                    }
                }
            }

            return maxRegion;
        }

        static int GetRegionSize(int[][] grid, int row, int column)
        {
            if (row < 0 || row >= grid.Length || column < 0 || column >= grid[row].Length)
                return 0;

            if (grid[row][column] == 0)
                return 0;

            // Marking cell as visited
            grid[row][column] = 0;
            
            int size = 1;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if (i == row && j == column)
                        continue;
                    
                    size += GetRegionSize(grid, i, j);
                }
            }

            return size;
        }
        
        static void Debug()
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int m = Convert.ToInt32(Console.ReadLine());

            int[][] grid = new int[n][];

            for (int i = 0; i < n; i++)
            {
                grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), gridTemp => Convert.ToInt32(gridTemp));
            }

            int res = MaxRegion(grid);

            // textWriter.WriteLine(res);
            Console.WriteLine(res);

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}