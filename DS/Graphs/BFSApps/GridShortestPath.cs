using System.Collections.Generic;

namespace DS.Graphs.BFSApps
{
    public class GridShortestPath
    {
        private readonly int[][] _directions = new[] { new[] {0, 1}, new[] {0, -1}, new[] {1, 0}, new[] {-1, 0}};
        
        public int GetShortestDistance(int[][] grid, int[] start, int[] dest)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var minSteps = 0;
            var queue = new Queue<int[]>();
            var visited = new bool[m, n];
        
            queue.Enqueue(start);
            visited[start[0], start[1]] = true;
        
            while (queue.Count > 0)
            {
                var length = queue.Count;
            
                for (int i = 0; i < length; i++)
                {
                    var current = queue.Dequeue();
                
                    if (current[0] == dest[0] && current[1] == dest[1])
                    {
                        return minSteps;
                    }
                
                    foreach (var direction in _directions)
                    {
                        var nextX = current[0] + direction[0];
                        var nextY = current[1] + direction[1];
                    
                        if (nextX >= 0 && nextX < m && 
                            nextY >= 0 && nextY < n && 
                            !visited[nextX, nextY] && 
                            grid[nextX][nextY] == 0)
                        {
                            queue.Enqueue(new[] {nextX, nextY});
                        }
                    
                    }
                }
            
                minSteps++;
            }
        
            return -1;
        }
    }
}