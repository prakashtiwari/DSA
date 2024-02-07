namespace TicTacToe.Domain.DomainModel
{
    public abstract class Player
    {
        public PlayerType Type { get; set; }
        public string Name { get; set; }
        public Symbol Symbol { get; set; }

        public Player(PlayerType playerType, Symbol symbol)
        {
            this.Type = playerType;
            this.Symbol = symbol;
        }
        public abstract Move MakeMove(Board board);
     

    }
}
