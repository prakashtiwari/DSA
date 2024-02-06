using SnakeAndLadder.Model.DomainModel;
using System.Xml.Serialization;

namespace SnakeAndLadder.Model.Strategy
{
    public interface IPlayerMoveStrategy
    {
        public void Move(Player player, Board board, int position, int value);
    }
}
