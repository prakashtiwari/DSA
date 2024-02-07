namespace TicTacToe.Domain.DomainModel
{
    public class Move
    {
        public Symbol Symbol { get; set; }
        public Cell Cell { get; set; }

        public Player Player { get; set; }
    }
}
