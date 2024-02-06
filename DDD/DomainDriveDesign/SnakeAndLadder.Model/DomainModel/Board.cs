namespace SnakeAndLadder.Model.DomainModel
{
    public class Board
    {
        public int Dimension { get; set; }
        public Dictionary<int, ForeignEntity> position { get; set; }

    }
}
