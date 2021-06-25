namespace DS._LeetCode.Graphs
{
    public class NumberOfIslandsProblem
    {
        public static int NumIslands(char[][] grid) 
        {
            var m = grid.Length;
            var n = grid[0].Length;
        
            var visited = new bool[m][];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[n];
            }
        
            var islandsCount = 0;
        
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1' && !visited[i][j])
                    {
                        VisitIsland(grid, visited, i, j, m, n);
                        islandsCount++;

                    }
                }
            }
        
            return islandsCount;
        }
    
        static void VisitIsland(char[][] grid, bool[][] visited, int i, int j, int m, int n)
        {
            if (i >= m || j >= n) 
                return;
        
            if (grid[i][j] == '0')
                return;
        
            if (visited[i][j])
                return;
        
            visited[i][j] = true;
        
            VisitIsland(grid, visited, i + 1, j, m, n);
            VisitIsland(grid, visited, i - 1, j, m, n);
            VisitIsland(grid, visited, i, j + 1, m, n);
            VisitIsland(grid, visited, i, j - 1, m, n);
        }
    }
}