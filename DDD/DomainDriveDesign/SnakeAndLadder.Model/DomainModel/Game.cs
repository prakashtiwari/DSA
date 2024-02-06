namespace SnakeAndLadder.Model.DomainModel
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Board Board { get; set; }
        public Dice Dice { get; set; }
        public int MaxButton { get; set; }
        public GameStatus Status { get; set; }
        public int LastPlayerMoveStatus { get; set; }
    }
}
