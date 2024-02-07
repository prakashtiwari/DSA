namespace TicTacToe.Domain.DomainModel
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Symbol Symbol { get; set; }

        public bool IsEmpty()
        {
            return false; //Symbol.
        }
        public void ClearCell()
        {
            this.Symbol = new Symbol { character = ' ' };
        }

    }
}
