using TicTacToe.Domain.DomainModel;
using TicTacToe.Domain.Strategies;

namespace TicTacToe.Domain.Factories
{
    public class BotPlayingStrategyFactory
    {
        public IBotPlayingStrategy CreateBotPlayingStrategy(BotDifficultyLevel botDifficultyLevel)
        {
            switch (botDifficultyLevel.ToString())
            {
                case "Simple":

                    return new RandonBotPlayingStrategy();
            }

        }
    }
}
