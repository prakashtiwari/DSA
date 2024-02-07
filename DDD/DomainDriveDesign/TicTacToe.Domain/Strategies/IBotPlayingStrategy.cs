using TicTacToe.Domain.DomainModel;

namespace TicTacToe.Domain.Strategies
{
    public interface IBotPlayingStrategy
    {
        Move MakeNextMove(Board board, Player player);
    }
}
