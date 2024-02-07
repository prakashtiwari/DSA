using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Domain.DomainModel
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(Symbol symbol) : base(PlayerType.HUMAN, symbol)
        {

        }
        public override Move MakeMove(Board board)
        {
            Console.WriteLine("Provide the row!");
            int row = 0;
            int.TryParse(Console.ReadLine(), out row);

            Console.WriteLine("Provide the column!");
            int col = 0;
            int.TryParse(Console.ReadLine(), out col);
            Move move = new Move();        
            move.Cell = board.GetCell(row - 1, col - 1);

            move.Player = this;
            move.Symbol=this.Symbol;
            return move;
        }
    }
}
