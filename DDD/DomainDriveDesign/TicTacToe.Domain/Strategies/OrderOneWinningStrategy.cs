using TicTacToe.Domain.DomainModel;

namespace TicTacToe.Domain.Strategies
{
    public class OrderOneWinningStrategy : IWinningStrategy
    {
        public bool CheckIfPlayerWon(Board board, Player player)
        {
            return false;
        }
    }
}
