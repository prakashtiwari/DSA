using TicTacToe.Domain.DomainModel;

namespace TicTacToe.Domain.Strategies
{
    public class RandonBotPlayingStrategy : IBotPlayingStrategy
    {
        public Move MakeNextMove(Board board, Player player)//This is good approach
        {
            foreach (var row in board.board)
            {
                foreach (var col in row)
                {
                    if (col.IsEmpty())
                    {
                       Move move = new Move();
                        move.Symbol= player.Symbol;
                        move.Cell = col;
                        move.Player = player;
                        return move;

                    }
                }
            }
            return null;
        }
    }
}
