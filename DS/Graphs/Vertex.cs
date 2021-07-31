namespace DS.Graphs
{
    public class Vertex
    {
        public int Key { get; set; } = int.MaxValue;
        public int Parent { get; set; } = -1;
        public int Val { get; set; }
        public bool IsProcessed { get; set; }
    }
}