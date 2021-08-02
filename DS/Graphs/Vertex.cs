namespace DS.Graphs
{
    public class Vertex
    {
        public int Distance { get; set; } = int.MaxValue;
        public Vertex Parent { get; set; }
        public int Val { get; set; }
        public bool IsProcessed { get; set; }
    }
}