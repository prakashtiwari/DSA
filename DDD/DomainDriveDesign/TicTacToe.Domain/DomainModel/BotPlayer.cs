using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.Strategies;

namespace TicTacToe.Domain.DomainModel
{
    public class BotPlayer : Player
    {
        public BotDifficultyLevel BotDifficultyLevel { get; set; }
        public IBotPlayingStrategy botPlayingStrategy;
        public BotPlayer(Symbol symbol, BotDifficultyLevel botDifficultyLevel, IBotPlayingStrategy botPlayingStrategy) : base(PlayerType.BOT, symbol)
        {           
            this.BotDifficultyLevel = botDifficultyLevel;
            this.botPlayingStrategy = botPlayingStrategy;
        }
    }
}
