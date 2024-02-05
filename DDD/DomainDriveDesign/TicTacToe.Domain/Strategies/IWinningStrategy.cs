using TicTacToe.Domain.DomainModel;

namespace TicTacToe.Domain.Strategies
{
    public interface IWinningStrategy
    {
        bool CheckIfPlayerWon(Board board, Player player);
    }
}
