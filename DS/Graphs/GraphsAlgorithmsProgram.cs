namespace DS.Graphs
{
    public class GraphsAlgorithmsProgram
    {
        public static void Run()
        {
            var arr = new[]
            {
                new[] {0, 1},
                new[] {0, 9},
                new[] {9, 8},
                new[] {8, 1},
                new[] {1, 0},
                new[] {8, 7},
                new[] {7, 3},
                new[] {3, 4},
                new[] {3, 2},
                new[] {3, 5},
                new[] {5, 6},
                new[] {6, 7},
                new[] {7, 10},
                new[] {10, 11},
            };
            
            var adjList = GraphsAlgorithms.BuildUndirectedAdjacencyList(arr);
            var visited = new bool[adjList.Count];
            
            GraphsAlgorithms.DFS(adjList, visited, 0);
        }
    }
}