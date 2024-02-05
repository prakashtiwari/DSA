using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Domain.DomainModel
{
    public class Board
    {
        public int Dimension { get; set; }

        public List<List<Cell>> Cells { get; set; }
        Board() { }
    }
}
