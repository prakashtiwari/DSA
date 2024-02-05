using TicTacToe.Domain.Strategies;

namespace TicTacToe.Domain.DomainModel
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Player Winner { get; set; }
        public Board Board { get; set; }
        List<IWinningStrategy> WinningStrategies { get; set; }

        public GameStatus Status { get; set; }
       public  List<Move> Moves { get; set; } //This is to Undo
    }
}
