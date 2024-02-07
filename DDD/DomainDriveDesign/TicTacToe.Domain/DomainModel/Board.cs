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

        public List<List<Cell>> board { get; set; }
        public Board(int dimension)
        {
            this.Dimension = dimension;
            board = new List<List<Cell>>();
            for (int i = 0; i < dimension; i++)
            {
                List<Cell> row = new List<Cell>();
                for (int j = 0; j < dimension; j++)
                {
                    row.Add(new Cell());
                }
                board.Add(row);
            }
        }
        public Cell GetCell(int row, int col)
        {
            return board[row][col];
        }
    }
}
