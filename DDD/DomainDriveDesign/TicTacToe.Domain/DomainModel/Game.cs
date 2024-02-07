using TicTacToe.Domain.ExceptionDomain;
using TicTacToe.Domain.Strategies;

namespace TicTacToe.Domain.DomainModel
{
    public class Game
    {
        public List<Player> Players { get; }
        public Player Winner { get; private set; }
        public Board Board { get; set; }
        List<IWinningStrategy> WinningStrategies { get; }

        public GameStatus Status { get; set; }
        public List<Move> Moves { get; set; } //This will help to Undo
        public int LastPlayerMovedIndex { get; set; }
        public int NumberOfFilledCells;

        public Player GetLastPlayer(int position)
        {
            return Players[position];
        }
        private Game()
        {
            Players = new List<Player>();
            WinningStrategies = new List<IWinningStrategy>();
            this.Moves = new List<Move>();
            this.LastPlayerMovedIndex = -1;

        }
        public void MakeMove()
        {
            this.LastPlayerMovedIndex += 1;
            this.LastPlayerMovedIndex %= Players.Count;
            Move move = this.GetLastPlayer(this.LastPlayerMovedIndex).MakeMove(this.Board);
            this.Moves.Add(move);
            ++NumberOfFilledCells;
            foreach (var strategies in WinningStrategies)
            {

                if (strategies.CheckIfPlayerWon(this.Board, this.Players[LastPlayerMovedIndex]))
                {
                    this.Status = GameStatus.ENDED;
                    Winner = this.Players[LastPlayerMovedIndex];
                    return;
                }
            }

        }
        public class GameBuilder
        {

            public List<Player> Players { get; }
            public List<IWinningStrategy> WinningStrategies { get; }

            //Game game=new GameBuilder().AddPlayer(new HumanPlayer()).AddPlayer(new BotPlayer())
            public int dimenstion { get; set; }
            public Board Board { get; set; }
            public GameBuilder()
            {
                this.Players = new List<Player>();
                this.WinningStrategies = new List<IWinningStrategy>();
            }
            public GameBuilder AddPlayer(Player playes)
            {
                this.Players.Add(playes);
                return this;
            }
            public GameBuilder SetDimension(int dimension)
            {
                this.dimenstion = dimension;
                return this;
            }
            private bool CheckIfMaxSingleBot()
            {
                int botCount = 0;
                foreach (var player in this.Players)
                {
                    if (player.Type == PlayerType.BOT)
                        botCount++;
                }
                return botCount <= 1 ? true : false;

            }
            public Game Build()
            {
                if (!CheckIfMaxSingleBot())
                {
                    throw new MultipleBotException("More than required bot players.");
                }
                Game game = new Game();
                game.Players.AddRange(this.Players);
                game.Board = new Board(this.dimenstion);
                game.WinningStrategies.AddRange(this.WinningStrategies);
                return game;
            }

        }
    }
}
